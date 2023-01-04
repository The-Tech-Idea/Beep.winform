using Beep.Winform.Controls;
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
        public EventHandler<string> SendMessege;
        public CPythonManager() { }
        public CPythonManager(IDMEEditor dMEEditor,IJsonLoader jsonLoader, string runtimepath="")
        {
            RuntimePath = runtimepath;
            DMEEditor= dMEEditor;
            PIPManager = new PIPManager(this);
            ProcessManager=new ProcessManager(this);
            IDEManager=new IDEManager(this);    
            FileManager= new FileManager(this, jsonLoader);
            AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }
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
 
            if (string.IsNullOrEmpty(runtimepath))
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    BinPath = Path.Combine(DMEEditor.ConfigEditor.Config.ClassPath, AppName, "python-3.9.5-embed-amd64");
                    DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x64"), FolderFileTypes.ConnectionDriver);

                }
                else
                {
                    BinPath = Path.Combine(DMEEditor.ConfigEditor.Config.ClassPath, AppName, "python-3.9.5-embed-win32");
                    DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x86"), FolderFileTypes.ConnectionDriver);
                }
            }
            else
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    BinPath = Path.Combine(runtimepath, "python-3.9.5-embed-amd64");
                    DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x64"), FolderFileTypes.ConnectionDriver);

                }
                else
                {
                    BinPath = Path.Combine(runtimepath, "python-3.9.5-embed-win32");
                    DMEEditor.assemblyHandler.LoadAssembly(Path.Combine(DMEEditor.ConfigEditor.Config.ConnectionDriversPath, "sqllite\\x86"), FolderFileTypes.ConnectionDriver);
                }
            }
           
          
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
            FileManager.Tmpcsvfile = FileManager.Lookfortmopcsv();
            Packageinstallpath = Path.Combine(BinPath, @"Lib\site-packages");
            FileManager.CreatedHashTmp();
            ProcessManager.SetupEnvVariables();
        }

    }
}
