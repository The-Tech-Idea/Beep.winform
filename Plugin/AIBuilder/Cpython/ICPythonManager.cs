using Beep.Winform.Controls;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public interface ICPythonManager
    {
        IDMEEditor DMEEditor { get; set; }
        IDEManager IDEManager { get; set; }
        PIPManager PIPManager { get; set; }
        FileManager FileManager { get; set; }
        ProcessManager ProcessManager { get; set; }

        CpythonConfig Config { get; set; }
        string LastfilePath { get; set; }
        string RuntimePath { get; set; }
        string BinPath { get;set; }
        string Packageinstallpath { get; set; }
        string AiFolderpath { get; set; }
        string Script { get; set; }
        ResourceManager resourceManager { get; set; }
        void NewMessege(string messege);
    }
}