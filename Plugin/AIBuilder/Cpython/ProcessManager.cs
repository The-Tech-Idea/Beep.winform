using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public class ProcessManager
    {
        public ProcessManager(ICPythonManager cPythonManager)
        {
            pythonManager = cPythonManager;
        }
        string tmpcsvfile;
        private ICPythonManager pythonManager;
        public BindingSource bindingSource { get; set; }
        public Process Process { get; set; }
        public int numOutputLines { get; set; }
        public List<string> outputdata { get; set; } = new List<string>();
      
        public void RunScript(string script)
        {
            string scripttorun = Path.Combine(pythonManager.AiFolderpath, "tmp.py");
            File.WriteAllText(scripttorun, script);
            //var t = Task.Run(() => {   });
            runPythonScriptcommandlineSync($@"{pythonManager.BinPath}\python.exe -q {Path.GetFileName(scripttorun)}", pythonManager.AiFolderpath);
            //int milliseconds = 2000;
            //Thread.Sleep(milliseconds);
            //   GetoutputText();
         

        }
        public void runPythonScriptcommandlineSync(string Command, string Commandpath)
        {


            Process Process = new Process();
            Process.StartInfo = new ProcessStartInfo("cmd.exe");
            // Process.StartInfo.Arguments = "/c";
            Process.StartInfo.CreateNoWindow = true;
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardInput = true;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.RedirectStandardError = true;

            Process.OutputDataReceived += Process_OutputDataReceived;
            Process.ErrorDataReceived += Process_ErrorDataReceived;
            Process.Exited += Process_Exited;
            Process.Start();
            // 4) Execute process and get output
            Process.BeginErrorReadLine();
            Process.BeginOutputReadLine();
            outputdata = new List<string>();
            Process.StandardInput.WriteLine($"set PATH={pythonManager.BinPath};%PATH%");
            Process.StandardInput.WriteLine($@"set PYTHONPATH={Path.Combine(pythonManager.BinPath, "lib")};{Path.Combine(pythonManager.DMEEditor.ConfigEditor.ExePath, "ProjectClasses")};{Path.Combine(pythonManager.DMEEditor.ConfigEditor.ExePath, "OtherDLL")};{Path.Combine(pythonManager.DMEEditor.ConfigEditor.ExePath, "ConnectionDrivers")};{pythonManager.DMEEditor.ConfigEditor.ExePath}");
            Process.StandardInput.WriteLine($@"set PATH={Path.Combine(pythonManager.BinPath, "scripts")};%PATH%");
            Process.StandardInput.WriteLine($@"cd {Commandpath} ");

            Process.StandardInput.WriteLine(Command);
            Process.StandardInput.WriteLine("exit");
            var output = new List<string>();

            while (Process.StandardOutput.Peek() > -1)
            {
                output.Add(Process.StandardOutput.ReadLine());
                pythonManager.NewMessege( Process.StandardOutput.ReadLine());
                pythonManager.DMEEditor.AddLogMessage("Python Module", $"{output.Last()}", DateTime.Now, numOutputLines, null, Errors.Failed);
            }

            while (Process.StandardError.Peek() > -1)
            {
                output.Add(Process.StandardError.ReadLine());
                pythonManager.NewMessege(Process.StandardError.ReadLine());
                pythonManager.DMEEditor.AddLogMessage("Python Module", $"Error in Python Module {output.Last()}", DateTime.Now, numOutputLines, null, Errors.Failed);

            }

            Process.WaitForExit();
            Process.Close();

        }
        public void runPythonScriptscommandlineAsync(string Command, string Commandpath)
        {

            Process.StartInfo.WorkingDirectory = Commandpath;
            Process.StandardInput.WriteLine($@"cd {Commandpath} ");

            Process.StandardInput.WriteLine(Command);
            // Process.StandardInput.WriteLine(">.");
            // Process.StandardInput.WriteLine("exit");




        }
        private void Process_Exited(object sender, EventArgs e)
        {
            if (outputdata.Count > 0)
            {
                ConvertStringtoDatatable();
            }

        }
        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                numOutputLines++;

                // Add the text to the collected output.
                outputdata.Append(Environment.NewLine + $"[{numOutputLines}] - {e.Data}");
                //this.OutputtextBox.BeginInvoke(new Action(() => {
                //    this.OutputtextBox.AppendText(Environment.NewLine +
                //    $"[{numOutputLines}] - {e.Data}");
                //}));

                pythonManager.DMEEditor.AddLogMessage("Python Module", $"Error in Python Module {e.Data}", DateTime.Now, numOutputLines, null, Errors.Failed);

            }
        }
        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                if ((!e.Data.ToLower().Contains("c:")) && (!e.Data.Contains("Microsoft")))
                {
                    numOutputLines++;


                    // Add the text to the collected output.

                    //this.OutputtextBox.BeginInvoke(new Action(() => {
                    //    this.OutputtextBox.AppendText(Environment.NewLine +
                    //    $">{e.Data}");
                    //}));
                    pythonManager.NewMessege(e.Data);
                    pythonManager.DMEEditor.AddLogMessage("Python Module", $"{e.Data}", DateTime.Now, numOutputLines, null, Errors.Failed);
                }
                else
                {

                    string withoutSubString = e.Data;
                    int indexOfSubString = e.Data.IndexOf(pythonManager.BinPath);
                    if (indexOfSubString != -1)
                    {
                        withoutSubString = e.Data.Remove(indexOfSubString, pythonManager.BinPath.Length);
                    }
                    if ((!withoutSubString.Contains("Microsoft")))
                    {
                        pythonManager.DMEEditor.AddLogMessage("Python Module", $">{withoutSubString}", DateTime.Now, numOutputLines, null, Errors.Ok);
                    }

                }


            }


        }
        public void SetupEnvVariables()
        {

            Process = new Process();

            Process.StartInfo = new ProcessStartInfo("cmd.exe");
            // Process.StartInfo.Arguments = "/c";
            Process.StartInfo.CreateNoWindow = true;
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardInput = true;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.RedirectStandardError = true;

            Process.OutputDataReceived += Process_OutputDataReceived;
            Process.ErrorDataReceived += Process_ErrorDataReceived;
            Process.Exited += Process_Exited;
            Process.Start();
            // 4) Execute process and get output
            Process.BeginErrorReadLine();
            Process.BeginOutputReadLine();
            outputdata = new List<string>();
            Process.StandardInput.WriteLine($@"set PATH={pythonManager.BinPath};%PATH%");
            Process.StandardInput.WriteLine($@"set PYTHONPATH={Path.Combine(pythonManager.BinPath, "lib")};{Path.Combine(pythonManager.DMEEditor.ConfigEditor.ExePath, "ProjectClasses")};{Path.Combine(pythonManager.DMEEditor.ConfigEditor.ExePath, "OtherDLL")};{Path.Combine(pythonManager.DMEEditor.ConfigEditor.ExePath, "ConnectionDrivers")};{pythonManager.DMEEditor.ConfigEditor.ExePath}");
            Process.StandardInput.WriteLine($@"set PATH={Path.Combine(pythonManager.BinPath, "scripts")};%PATH%");
            //      Process.StandardInput.WriteLine("exit");
            numOutputLines = 0;
            // Process.WaitForExit();
        }

        #region "Output Management"
      
        private DataTable ConvertStringtoDatatable()
        {
            DataTable dt;

            if (File.Exists(tmpcsvfile))
            {
                dt = pythonManager.DMEEditor.Utilfunction.CreateDataTableFromFile(tmpcsvfile);
            }
            else
                dt = null;
           
            return dt;
        }

        #endregion
    }
}
