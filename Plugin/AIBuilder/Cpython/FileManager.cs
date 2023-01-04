using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public class FileManager
    {
        public FileManager(ICPythonManager cPythonManager,IJsonLoader jsonLoader)
        {
            pythonManager = cPythonManager;
            JsonLoader = jsonLoader;
        }
        ICPythonManager pythonManager;

        IJsonLoader JsonLoader { get; }
        public string FilenameLoaded { get; set; }
        public string  Tmpcsvfile { get; set; }
        public byte[] lasttmpcsvhash { get; set; }
        #region "File Handling"
        public string Lookfortmopcsv()
        {
            string retval = null;
            foreach (StorageFolders item in pythonManager.DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")))
            {
                if (File.Exists(Path.Combine(item.FolderPath, "tmp.csv")))
                {
                    retval = Path.Combine(item.FolderPath, "tmp.csv");
                }
            }
            if (retval == null)
            {
                File.CreateText(Path.Combine(pythonManager.AiFolderpath, "tmp.csv"));
                retval = Path.Combine(pythonManager.AiFolderpath, "tmp.csv");
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
                saveFileDialog1.InitialDirectory = pythonManager.AiFolderpath;
                //  saveFileDialog1.Multiselect = false;
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    File.WriteAllText(saveFileDialog1.FileName, pythonManager.Script);
                }
                FilenameLoaded = saveFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                    string errmsg = "Error in saving python script";
                pythonManager.DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
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

                    File.WriteAllText(FilenameLoaded,pythonManager.Script);
                    MessageBox.Show("Script Saved");
                }

            }
            catch (Exception ex)
            {


                string errmsg = "Error in saving python script";
                pythonManager.DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        public string LoadScriptFile(string filename)
        {
            try
            {
                string loadfilename = "";
                DialogResult result = DialogResult.None;
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
                    openFileDialog1.InitialDirectory = pythonManager.AiFolderpath;
                    openFileDialog1.Multiselect = false;
                    result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
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
                pythonManager.Script = "";
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
                        pythonManager.Script+=line + Environment.NewLine;
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
              
                string errmsg = "Error in getting python script";
                pythonManager.DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                return null;
            }
        }
        public void CreatedHashTmp()
        {
            if (lasttmpcsvhash != GetFileHash(Tmpcsvfile))
            {
                
                lasttmpcsvhash = GetFileHash(Tmpcsvfile);
            }
        }
        private byte[] GetFileHash(string fileName)
        {
            HashAlgorithm sha1 = HashAlgorithm.Create();
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                return sha1.ComputeHash(stream);
        }
        #endregion
        #region "Configuration File"
        public void CreateLoadConfig()
        {
            string configfile = Path.Combine(pythonManager.DMEEditor.ConfigEditor.ConfigPath, "cpython.config");
            if (File.Exists(configfile))
            {
                 pythonManager.Config =JsonLoader.DeserializeSingleObject<CpythonConfig>(configfile);
            }
            else
            {
                if (pythonManager.Config == null)
                {
                    pythonManager.Config = new CpythonConfig();
                }
                JsonLoader.Serialize(configfile, pythonManager.Config);
            }
        }
        public void SaveConfig()
        {
            string configfile = Path.Combine(pythonManager.DMEEditor.ConfigEditor.ConfigPath, "cpython.config");
            if (pythonManager.Config == null)
            {
                pythonManager.Config = new CpythonConfig();
            }
            else
            {
                pythonManager.Config.BinPath = pythonManager.BinPath;
                pythonManager.Config.LastfilePath = pythonManager.LastfilePath;
                pythonManager.Config.RuntimePath=pythonManager.RuntimePath;
                pythonManager.Config.Packageinstallpath = pythonManager.Packageinstallpath;
                pythonManager.Config.AiFolderpath = pythonManager.AiFolderpath;
                
            }
            JsonLoader.Serialize(configfile, pythonManager.Config);
           
        }
        #endregion
    }
}
