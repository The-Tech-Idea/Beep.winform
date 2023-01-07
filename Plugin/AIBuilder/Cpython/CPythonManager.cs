using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
   
    public class CPythonManager : ICPythonManager
    {
        public event EventHandler<string> SendMessege;
        public CPythonManager() { }
        public CPythonManager(IDMEEditor dMEEditor,IJsonLoader jsonLoader,Scintilla scintilla, string runtimepath="")
        {
            RuntimePath = runtimepath;
            DMEEditor= dMEEditor;
            PIPManager = new PIPManager(this);
            ProcessManager=new ProcessManager(this);
            IDEManager=new IDEManager(this);    
            FileManager= new FileManager(this, jsonLoader);
            MenuManager = new MenuManager(this, scintilla);
            AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Init();
        }
        public MenuManager MenuManager { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public CpythonConfig Config { get; set; }
        public string LastfilePath { get; set; }
        public string Script { get; set; }
        public string RuntimePath { get; set; }
        public string BinPath { get; set; }
        public string Packageinstallpath { get; set; }
        public string AiFolderpath { get; set; }
        public IDEManager IDEManager { get; set; } 
        public ProcessManager ProcessManager { get; set; } 
        public PIPManager PIPManager { get; set; }
        public FileManager FileManager { get; set; }
        String AppName;
        public ResourceManager resourceManager { get; set; } = new ResourceManager();
        public void NewMessege(string messege)
        {
            SendMessege?.Invoke(this,messege);
        }
        public void Init(string runtimepath="")
        {
            FileManager.CreateLoadConfig();

            // Setup runtime Path to Bin 
            SetRuntimePath(runtimepath);

            // Setup AI Folder in Beep Directory
            SetAiFolderPath();
           //------------------------------------
            FileManager.Tmpcsvfile = FileManager.Lookfortmopcsv();
            Packageinstallpath = Path.Combine(BinPath, @"Lib\site-packages");
            Config.Packageinstallpath = Packageinstallpath;
            FileManager.CreatedHashTmp();
            ProcessManager.SetupEnvVariables();
        }
        public IErrorsInfo SetRuntimePath(string runtimepath)
        {
           
            try
            {
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                if (string.IsNullOrEmpty(runtimepath))
                {
                    RuntimePath = Path.Combine(DMEEditor.ConfigEditor.Config.ClassPath, AppName);
                  
                }
                else
                {
                    RuntimePath = runtimepath;
                }

                if (Environment.Is64BitOperatingSystem)
                {
                    BinPath = Path.Combine(RuntimePath, "python-3.9.5-embed-amd64");
                   
                    DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x64"), FolderFileTypes.ConnectionDriver);
                }
                else
                {
                    BinPath = Path.Combine(RuntimePath, "python-3.9.5-embed-win32");
                  
                    DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x86"), FolderFileTypes.ConnectionDriver);
                }

                if(!IsRunTimeFound(BinPath))
               
                {
                    BinPath = null; Config.RuntimePath= null; Config.BinPath= null;Config.RuntimePath= null;
                    DMEEditor.AddLogMessage("Beep AI", "Error Could not Find Runtime", DateTime.Now, 0, runtimepath, Errors.Failed);
                }
              

            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Beep AI", ex.Message, DateTime.Now, 0, runtimepath, Errors.Failed);
            }
            return DMEEditor.ErrorObject;
         
        }
        public void SetAiFolderPath()
        {
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
                AiFolderpath = Path.Combine(DMEEditor.ConfigEditor.ExePath, "AI");
            }
            else
            {
                AiFolderpath = DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath;
            }
            Config.AiFolderpath = AiFolderpath;
        }
        private bool IsRunTimeFound(string path)
        {
          
            return File.Exists( Path.Combine(path, "python.exe"));
        }

       
    }
}
