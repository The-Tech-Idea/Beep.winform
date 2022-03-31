using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using BeepEnterprize.Winform.Vis.CRUD;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard
{
    [AddinAttribute(Caption = "App and Dashboard", Name = "AppAndDashboardFunctions", misc = "AppAndDashboardFunctions", addinType = AddinType.Class, iconimage = "design.ico", order =4)]
    public class AppAndDashboardFunctions : IFunctionExtension
    {
        public IDMEEditor DMEEditor { get; set; }
        public IPassedArgs Passedargs { get; set; }
        private VisManager Vismanager { get; set; }
        private ControlManager Controlmanager { get; set; }
        private CrudManager Crudmanager { get; set; }
        private MenuControl Menucontrol { get; set; }
        private ToolbarControl Toolbarcontrol { get; set; }
        private TreeControl TreeEditor { get; set; }

        CancellationTokenSource tokenSource;

        CancellationToken token;
        
        IDataSource DataSource;
        IBranch pbr;
        IBranch RootBranch;
        public AppAndDashboardFunctions(IDMEEditor pdMEEditor, VisManager pvisManager, TreeControl ptreeControl)
        {
            DMEEditor = pdMEEditor;
            Vismanager = pvisManager;
           TreeEditor = ptreeControl;
        }
        private void GetValues(IPassedArgs Passedarguments)
        {

            if (Passedarguments.Objects.Where(c => c.Name == "Vismanager").Any())
            {
                Vismanager = (VisManager)Passedarguments.Objects.Where(c => c.Name == "Vismanager").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "TreeControl").Any())
            {
                TreeEditor = (TreeControl)Passedarguments.Objects.Where(c => c.Name == "TreeControl").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "CrudManager").Any())
            {
                Crudmanager = (CrudManager)Passedarguments.Objects.Where(c => c.Name == "CrudManager").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "ControlManager").Any())
            {
                Controlmanager = (ControlManager)Passedarguments.Objects.Where(c => c.Name == "ControlManager").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "MenuControl").Any())
            {
                Menucontrol = (MenuControl)Passedarguments.Objects.Where(c => c.Name == "MenuControl").FirstOrDefault().obj;
            }

            if (Passedarguments.Objects.Where(c => c.Name == "ToolbarControl").Any())
            {
                Toolbarcontrol = (ToolbarControl)Passedarguments.Objects.Where(c => c.Name == "ToolbarControl").FirstOrDefault().obj;
            }

          //  DataSource = DMEEditor.GetDataSource(Passedarguments.DatasourceName);
          //  DMEEditor.OpenDataSource(Passedarguments.DatasourceName);
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            Passedarguments.DatasourceName = pbr.DataSourceName;
            Passedarguments.CurrentEntity = pbr.BranchText;
            RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == pbr.BranchClass && x.BranchType == EnumPointType.Root)];

        }
       
      
        [CommandAttribute(Caption = "Designer", Name = "Designer", Click = true, iconimage = "design.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo Dashboard(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            EntityStructure ent = new EntityStructure();
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            if (pbr.BranchType == EnumPointType.DataPoint)
            {
                try
                {
                    GetValues(Passedarguments);
                    Passedarguments.DatasourceName = pbr.BranchText;
                    Vismanager.ShowPage("uc_ScreenDesigner", (PassedArgs)Passedarguments, DisplayType.InControl);

                }
                catch (Exception ex)
                {
                    DMEEditor.ErrorObject.Flag = Errors.Failed;
                    DMEEditor.ErrorObject.Ex = ex;
                    DMEEditor.AddLogMessage("Fail", $"Error running Import {ent.EntityName} - {ex.Message}", DateTime.Now, -1, null, Errors.Failed);
                }
            }

            return DMEEditor.ErrorObject;
        }


    }
}
