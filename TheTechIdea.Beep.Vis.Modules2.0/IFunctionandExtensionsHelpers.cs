using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using BeepEnterprize.Winform.Vis.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface IFunctionandExtensionsHelpers
    {
        IControlManager Controlmanager { get; set; }
        IDM_Addin Crudmanager { get; set; }
        IDataSource DataSource { get; set; }
        IDMEEditor DMEEditor { get; set; }
        IDM_Addin Menucontrol { get; set; }
        IBranch ParentBranch { get; set; }
        IPassedArgs Passedargs { get; set; }
        IBranch pbr { get; set; }
        IProgress<PassedArgs> progress { get; set; }
        IBranch RootBranch { get; set; }
        CancellationToken token { get; set; }
        IDM_Addin Toolbarcontrol { get; set; }
        ITree TreeEditor { get; set; }
        IBranch ViewRootBranch { get; set; }
        IVisManager Vismanager { get; set; }

        Errors AddEntitiesToView(string datasourcename, List<EntityStructure> ls, IPassedArgs Passedarguments);
        CategoryFolder AddtoFolder(string foldername);
        bool AskToCopyFile(string filename, string sourcPath);
        bool CopyFileToLocal(string sourcePath, string destinationPath, string filename);
        List<EntityStructure> CreateEntitiesListFromDataSource(string Datasourcename);
        List<EntityStructure> CreateEntitiesListFromSelectedBranchs();
        List<ConnectionProperties> CreateFileConnections(List<string> filenames);
        ConnectionProperties CreateFileDataConnection(string file);
        AppTemplate CreateReportDefinitionFromView(IDataSource src);
        Errors CreateView(string viewname);
        void DirectorySearch(string dir);
        void GetValues(IPassedArgs Passedarguments);
        ConnectionProperties LoadFile();
        List<ConnectionProperties> LoadFiles(string Directoryname = null);
    }
}