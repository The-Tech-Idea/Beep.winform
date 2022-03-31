using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
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

namespace Beep.DExpress.Common
{
    [AddinAttribute(Caption = "DevExpress Library", Name = "DxDashboardFunctions", misc = "DxDashboardFunctions", addinType = AddinType.Class, iconimage = "devexpress.ico",order =5)]
    public class DxDashboardFunctions : IFunctionExtension
    {
        public IDMEEditor DMEEditor { get; set; }
        public IPassedArgs Passedargs { get; set; }
        private VisManager Vismanager { get; set; }
        private ControlManager Controlmanager { get; set; }
        private CrudManager Crudmanager { get; set; }
        private MenuControl Menucontrol { get; set; }
        private ToolbarControl Toolbarcontrol { get; set; }
        private TreeControl TreeEditor { get; set; }

        private DxDataSourceInfo DataSourceInfo { get; set; }
        CancellationTokenSource tokenSource;

        CancellationToken token;
        
        IDataSource DataSource;
        IBranch pbr;
        IBranch RootBranch;
        public DxDashboardFunctions(IDMEEditor pdMEEditor, VisManager pvisManager, TreeControl ptreeControl)
        {
            DMEEditor = pdMEEditor;
            Vismanager = pvisManager;
           TreeEditor = ptreeControl;
            DataSourceInfo=new DxDataSourceInfo(pdMEEditor);
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
       
      
        [CommandAttribute(Caption = "Dashboard Designer", Name = "DashboardDesigner", Click = true, iconimage = "chart.ico", PointType = EnumPointType.DataPoint)]
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
                    DataSourceInfo.DxDataSources.Clear();
                    DataSourceInfo.AddEntities(GetEntitiesForDx());
                    Passedarguments.ReturnData = DataSourceInfo;
                   // Passedarguments.ReturnType = DxDataSourceInfo.GetType();
                    Vismanager.ShowPage("DxDashboardDesigner", (PassedArgs)Passedarguments, DisplayType.InControl);

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
        [CommandAttribute(Caption = "Report Designer", Name = "ReportDesigner", Click = true, iconimage = "Designer.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo ReportDesigner(IPassedArgs Passedarguments)
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
                    DataSourceInfo.DxDataSources.Clear();
                    DataSourceInfo.AddEntities(GetEntitiesForDx());
                    Passedarguments.ReturnData = DataSourceInfo;
                    // Passedarguments.ReturnType = DxDataSourceInfo.GetType();
                    Vismanager.ShowPage("DxDashboardDesigner", (PassedArgs)Passedarguments, DisplayType.InControl);

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
        private List<EntityStructure> GetEntitiesForDx()
        {
            List<EntityStructure> ls = new List<EntityStructure>();
            try
            {
               
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                  
                    if (DMEEditor.Passedarguments != null)
                    {

                        if (TreeEditor.SelectedBranchs.Count > 0)
                        {


                            foreach (int item in TreeEditor.SelectedBranchs)
                            {
                                IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);
                                IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);

                                if (srcds != null)
                                {
                                    EntityStructure entity = (EntityStructure)srcds.GetEntityStructure(br.BranchText, true).Clone();
                                    ls.Add(entity);
                                }
                            }
                        }
                    }
                }
                
                DMEEditor.AddLogMessage("Success", $"Paste entities", DateTime.Now, 0, null, Errors.Ok);
                return ls;
            }
            catch (Exception ex)
            {
                string mes = $" Could not Added Entity {ex.Message} ";
                DMEEditor.AddLogMessage("Fail", mes, DateTime.Now, -1, mes, Errors.Failed);
                return null;
            };
        }

    }
}
