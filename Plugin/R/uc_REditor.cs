using Beep.Winform.Controls;
using BeepEnterprize.Vis.Module;
using RDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.R
{
    public partial class uc_REditor : UserControl,IDM_Addin
    {
        public uc_REditor()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string AddinName { get; set; }
        public string Description { get; set; }
        public bool DefaultCreate { get; set; }
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        public IVisManager visManager { get; set; }
        ResourceManager resourceManager  = new ResourceManager();
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }
        string rfolder;
        string aifolder;
        string FilenameLoaded;
        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            Passedarg = e;
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            REngine.SetEnvironmentVariables(); // <-- May be omitted; the next line would call it.
            REngine engine = REngine.GetInstance();
            //------------------------------------------- Set up and Create Required Folder ----------------------------
            if (!DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).Any())
            {
                if (Directory.Exists(Path.Combine(DMEEditor.ConfigEditor.ExePath, "AI")) == false)
                {
                    Directory.CreateDirectory(Path.Combine(DMEEditor.ConfigEditor.ExePath, "AI"));

                }
                if (!DMEEditor.ConfigEditor.Config.Folders.Any(item => item.FolderPath.Equals(Path.Combine(DMEEditor.ConfigEditor.ExePath, "AI"), StringComparison.OrdinalIgnoreCase)))
                {
                    DMEEditor.ConfigEditor.Config.Folders.Add(new StorageFolders(Path.Combine(DMEEditor.ConfigEditor.ExePath, "AI"), FolderFileTypes.Scripts));
                }
                aifolder = Path.Combine(DMEEditor.ConfigEditor.ExePath, "AI");
            }
            else
            {
                aifolder = DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath;
            }
            if (!DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("R")).Any())
            {
                if (Directory.Exists(Path.Combine(aifolder, "AI")) == false)
                {
                    Directory.CreateDirectory(Path.Combine(aifolder, "AI"));

                }
                if (!DMEEditor.ConfigEditor.Config.Folders.Any(item => item.FolderPath.Equals(Path.Combine(aifolder, "R"), StringComparison.OrdinalIgnoreCase)))
                {
                    DMEEditor.ConfigEditor.Config.Folders.Add(new StorageFolders(Path.Combine(aifolder, "R"), FolderFileTypes.Scripts));
                }
                rfolder = Path.Combine(aifolder, "AI");
            }
            else
            {
                rfolder = DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("R")).FirstOrDefault().FolderPath;
            }
            //------------------------------------------- Set up and Create Required Folder ----------------------------
            // TheTechIdea.Beep.R
            LoadScriptbutton.Image = resourceManager.GetImage("TheTechIdea.Beep.R.gfx.", "load64.png");
            Savebutton.Image = resourceManager.GetImage("TheTechIdea.Beep.R.gfx.", "save64.png");
            SaveAsbutton.Image = resourceManager.GetImage("TheTechIdea.Beep.R.gfx.", "saveas64.png");
            Runbutton.Image = resourceManager.GetImage("TheTechIdea.Beep.R.gfx.", "run64.png");

            LoadScriptbutton.Click += LoadScriptbutton_Click;
            Savebutton.Click += Savebutton_Click;
            SaveAsbutton.Click += SaveAsbutton_Click;
            Runbutton.Click += Runbutton_Click;

        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveAsbutton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadScriptbutton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #region "File Handling"
        private string lookfortmopcsv()
        {
            string retval = null;
            foreach (StorageFolders item in DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")))
            {
                if (File.Exists(Path.Combine(item.FolderPath, "tmp.csv")))
                {
                    retval = Path.Combine(item.FolderPath, "tmp.csv");
                }
            }
            if (retval == null)
            {
                File.CreateText(Path.Combine(aifolder, "tmp.csv"));
                retval = Path.Combine(aifolder, "tmp.csv");
            }
            return retval;
        }
        public void SaveTextAsFile()
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog()
                {
                    Title = "Save File",

                    DefaultExt = "py",
                    Filter = "python files(*.py) |*.py",

                    FilterIndex = 1,
                    RestoreDirectory = true

                    //ReadOnlyChecked = true,
                    //ShowReadOnly = true
                };
                saveFileDialog1.InitialDirectory = aifolder;
                //  saveFileDialog1.Multiselect = false;
                System.Windows.Forms.DialogResult result = saveFileDialog1.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK) // Test result.
                {
                    File.WriteAllText(saveFileDialog1.FileName, ScriptTextBox.Text);
                }
                FilenameLoaded = saveFileDialog1.FileName;
            }
            catch (Exception ex)
            {


                string errmsg = "Error in saving python script";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        public void SaveTexttoFile()
        {

            try
            {
                if (FilenameLoaded == null)
                {
                    SaveTextAsFile();
                }
                else
                {

                    File.WriteAllText(FilenameLoaded, ScriptTextBox.Text);
                    MessageBox.Show("Script Saved");
                }

            }
            catch (Exception ex)
            {


                string errmsg = "Error in saving python script";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        public string LoadScriptFile(string filename)
        {
            try
            {
                string loadfilename = "";
                System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (string.IsNullOrEmpty(filename))
                {
                    openFileDialog1 = new System.Windows.Forms.OpenFileDialog()
                    {
                        Title = "Browse Files",
                        CheckFileExists = true,
                        CheckPathExists = true,
                        DefaultExt = "py",
                        Filter = "python files(*.py) |*.py",
                        FilterIndex = 1,
                        RestoreDirectory = true

                        //ReadOnlyChecked = true,
                        //ShowReadOnly = true
                    };
                    openFileDialog1.InitialDirectory = aifolder;
                    openFileDialog1.Multiselect = false;
                    result = openFileDialog1.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        loadfilename = openFileDialog1.FileName;
                    }
                }
                else
                {
                    if (File.Exists(filename))
                    {
                        loadfilename = filename;
                    }

                }

                String line;
                ScriptTextBox.Clear();
                if (!string.IsNullOrEmpty(loadfilename)) // Test result.
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(loadfilename);
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        ScriptTextBox.AppendText(line + Environment.NewLine);
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    FilenameLoaded = loadfilename;
                    return FilenameLoaded;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                string errmsg = "Error in getting python script";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        #endregion
    }
}
