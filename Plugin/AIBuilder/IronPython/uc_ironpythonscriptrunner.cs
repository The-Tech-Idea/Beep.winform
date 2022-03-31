using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.IO;
using AI;
using System.Text.RegularExpressions;
using System.Diagnostics;
using BeepEnterprize.Vis.Module;
using TheTechIdea.Beep.Vis;

namespace AIBuilder.IronPython
{
    [AddinAttribute(Caption = "Iron Python Editor", Name = "uc_ironpythonscriptrunner", misc = "AI", addinType = AddinType.Control)]
    public partial class uc_ironpythonscriptrunner : UserControl,IDM_Addin
    {
        public uc_ironpythonscriptrunner()
        {
            InitializeComponent();
        }
        public string ParentName { get; set; }
        public string AddinName { get; set; } = "Iron Python";
        public string Description { get; set; } = "Iron Python";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public Boolean DefaultCreate { get; set; } = true;
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public DataSet Dset { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }

        // public event EventHandler<PassedArgs> OnObjectSelected;
        //private IDMDataView MyDataView;
        public IVisManager Visutil { get; set; }
        //  DataViewDataSource ds;
        IBranch RootAppBranch;
        IBranch branch;
        //  App app;
        Stream outstream;
        StreamWriter erstream;
        TextBoxWriter BoxWriter;
        public ScriptEngine engine { get; set; }
        public ScriptScope scope { get; set; }
        public void RaiseObjectSelected()
        {
            throw new NotImplementedException();
        }

        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            Passedarg = e;
            Logger = plogger;
            ErrorObject = per;
            DMEEditor = pbl;
            Visutil = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            if (e.Objects.Where(c => c.Name == "Branch").Any())
            {
                branch = (IBranch)e.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "RootAppBranch").Any())
            {
                RootAppBranch = (IBranch)e.Objects.Where(c => c.Name == "RootAppBranch").FirstOrDefault().obj;
            }
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
            ICollection<string> searchPaths = engine.GetSearchPaths();

            // Now modify the search paths to include the directory
            // where the standard library has been installed
            searchPaths.Add(Path.Combine(DMEEditor.ConfigEditor.Config.ClassPath,"Lib"));
            searchPaths.Add(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "SqlLite"));
            searchPaths.Add(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "SqlLite\\x86"));
            searchPaths.Add(DMEEditor.ConfigEditor.Config.ClassPath);
            searchPaths.Add(DMEEditor.ConfigEditor.Config.ConnectionDriversPath);
            engine.SetSearchPaths(searchPaths);
            // engine.Runtime.IO.SetErrorOutput(erstream, Encoding.UTF8);
            BoxWriter = new TextBoxWriter(this.OutputtextBox);
            MemoryStream outputStream = new MemoryStream();
            StreamWriter outputStreamWriter = new StreamWriter(outputStream);
        
            scope.SetVariable("DMEEditor", DMEEditor);
            engine.Runtime.IO.SetOutput(outputStream, BoxWriter);
            engine.Runtime.IO.SetErrorOutput(outputStream, BoxWriter);
            //  Console.SetOut(TextWriter.Synchronized(BoxWriter));
            try
            {

                scripttextBox.Multiline = true;
                scripttextBox.WordWrap = false;
                scripttextBox.AcceptsTab = true;
                scripttextBox.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
                scripttextBox.Dock = DockStyle.Fill;
                scripttextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                scripttextBox.SelectionColor = Color.Black;
            }
            catch (Exception rr)
            {

              
            }
            try
            {
                DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x86"),FolderFileTypes.ConnectionDriver);
            }
            catch (Exception dberr)
            {

                
            }
           
            
            this.LoadFilebutton.Click += LoadFilebutton_Click;
            this.SaveFilebutton.Click += SaveFilebutton_Click;
            this.RunonIronScriptbutton.Click += RunScriptbutton_Click;
            this.RunonCpythonbutton.Click += RunonCpythonbutton_Click;
        }

        private void RunonCpythonbutton_Click(object sender, EventArgs e)
        {
            RunCpython();
        }

        private void RunScriptbutton_Click(object sender, EventArgs e)
        {
            // Execute the script
            // We execute this script from Visual Studio
            // so the program will executed from bin\Debug or bin\Release
            Microsoft.Scripting.Hosting.ScriptSource pythonScript =
                engine.CreateScriptSourceFromString(this.scripttextBox.Text);
            //var compiled = pythonScript.Compile();
            //var result = compiled.Execute(scope);
            try
            {
                pythonScript.Execute();
            }
            catch (Exception ex)
            {
                this.OutputtextBox.AppendText(Environment.NewLine + ex.Message);
               
            }
             
            
        }

        private void SaveFilebutton_Click(object sender, EventArgs e)
        {
            try
            {
                //saveFileDialog1 = new System.Windows.Forms.SaveFileDialog()
                //{
                //    Title = "Save File",
                   
                //    DefaultExt = "py",
                //    Filter = "python files(*.py) |*.py",
                    
                //    FilterIndex = 1,
                //    RestoreDirectory = true

                //    //ReadOnlyChecked = true,
                //    //ShowReadOnly = true
                //};
                //saveFileDialog1.InitialDirectory = DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath;
                //  saveFileDialog1.Multiselect = false;
                string filter = "python files(*.py) |*.py";
                string ext = "py";
                string result = Visutil.Controlmanager.SaveFileDialog(ext, DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath, filter);
                if (result!=null) // Test result.
                {

                    File.WriteAllText(result, scripttextBox.Text);
                }
            }
            catch (Exception ex)
            {


                string errmsg = "Error in saving python script";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        private void LoadFilebutton_Click(object sender, EventArgs e)
        {
            try
            {
                //openFileDialog1 = new System.Windows.Forms.OpenFileDialog()
                //{
                //    Title = "Browse Files",
                //    CheckFileExists = true,
                //    CheckPathExists = true,
                //    DefaultExt = "py",
                //    Filter = "python files(*.py) |*.py",
                //    FilterIndex = 1,
                //    RestoreDirectory = true

                //    //ReadOnlyChecked = true,
                //    //ShowReadOnly = true
                //};
               
               // openFileDialog1.InitialDirectory = DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath;
               
               
                String line;
                string filter = "python files(*.py) |*.py";
                string ext = "py";
                string result= Visutil.Controlmanager.LoadFileDialog(ext, DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath,filter);
                if (result!=null) // Test result.
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        scripttextBox.AppendText(line+Environment.NewLine);
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                  
                }
            }
            catch (Exception ex)
            {

                string errmsg = "Error in getting python script";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        void ParseLine(string line)
        {
            Regex r = new Regex("([ \\t{}():;])");
            String[] tokens = r.Split(line);
            foreach (string token in tokens)
            {
                // Set the tokens default color and font.  
                scripttextBox.SelectionColor = Color.Black;
                scripttextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                // Check whether the token is a keyword.   
                String[] keywords = { "public", "void", "using", "static", "class" };
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (keywords[i] == token)
                    {
                        // Apply alternative color and font to highlight keyword.  
                        scripttextBox.SelectionColor = Color.Blue;
                        scripttextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                        break;
                    }
                }
                scripttextBox.SelectedText = token;
            }
            scripttextBox.SelectedText = "\n";
        }
        private void RunCpython()
        {
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            string classpath;
            if (Environment.Is64BitOperatingSystem)
            {
                classpath = Path.Combine(DMEEditor.ConfigEditor.Config.ClassPath, "python-3.9.5-embed-amd64");

            }
            else
            {
                classpath = Path.Combine(DMEEditor.ConfigEditor.Config.ClassPath, "python-3.9.5-embed-win32");
            }

            psi.FileName = $@"{classpath}\python.exe";

            // 2) Provide script and arguments
          string scripttorun=  Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath,"tmp.py");
            File.WriteAllText(scripttorun, scripttextBox.Text);
            var script = this.scripttextBox.Text;
            //  var start = "2019-1-1";
            // var end = "2019-1-22";

            psi.Arguments = $"\"{scripttorun}\""; // $"\"{script}\" \"{start}\" \"{end}\"";

            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // 4) Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output
            if (!string.IsNullOrEmpty(results))
            {
                this.OutputtextBox.AppendText(Environment.NewLine);
                this.OutputtextBox.AppendText(results);
             
            }

            if (!string.IsNullOrEmpty(errors))
            {
                this.OutputtextBox.AppendText(Environment.NewLine);
                this.OutputtextBox.AppendText(errors);
              
            }
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);
        }
    }
}
