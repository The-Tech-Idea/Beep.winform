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
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.FunctionsandExtensions
{
    [AddinAttribute(Caption = "DataSource", Name = "DataSourceMenuFunctions", misc = "DataSourceMenuFunctions", addinType = AddinType.Class, iconimage = "datasource.ico",order =3)]
    public class DataSourceMenuFunctions : IFunctionExtension
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
        public DataSourceMenuFunctions(IDMEEditor pdMEEditor,VisManager pvisManager,TreeControl ptreeControl)
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

            DataSource = DMEEditor.GetDataSource(Passedarguments.DatasourceName);
            DMEEditor.OpenDataSource(Passedarguments.DatasourceName);
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            Passedarguments.DatasourceName = pbr.DataSourceName;
            Passedarguments.CurrentEntity = pbr.BranchText;
            RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == pbr.BranchClass && x.BranchType == EnumPointType.Root)];
        }
        [CommandAttribute(Name = "Copy Entities", Caption = "Copy Entities", Click = true, iconimage = "copyentities.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CopyEntities(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //   DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
                List<EntityStructure> ents = new List<EntityStructure>();
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);
                    string[] args = new string[] { pbr.BranchText, DataSource.Dataconnection.ConnectionProp.SchemaName, null };

                    Passedarguments.EventType = "COPYENTITIES";
                    Passedarguments.ParameterString1 = "COPYENTITIES";

                    DMEEditor.Passedarguments = Passedarguments;
                }
               
                DMEEditor.AddLogMessage("Success", $"Copy Entites", DateTime.Now, 0, null, Errors.Ok);
                Vismanager.Controlmanager.MsgBox("Beep", $"Copied  {TreeEditor.SelectedBranchs.Count} Entities Successfully");
            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Copy Entites ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Name = "Paste Entities", Caption = "Paste Entities", Click = true, iconimage = "pasteentities.ico", PointType = EnumPointType.DataPoint)]
        public void PasteEntities(IPassedArgs Passedarguments)
        {
            try
            {
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);
                   
                    string iconimage = "";
                    int cnt = 0;
                    List<EntityStructure> ls = new List<EntityStructure>();
                    if (DMEEditor.Passedarguments != null)
                    {

                        if (TreeEditor.SelectedBranchs.Count > 0 )
                        {
                           
                            
                            foreach (int item in TreeEditor.SelectedBranchs)
                            {
                                IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);
                                IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);

                                if (srcds != null)
                                {
                                    EntityStructure entity = (EntityStructure)srcds.GetEntityStructure(br.BranchText, true).Clone();
                                    bool IsView = false;
                                   
                                    if (DataSource.CheckEntityExist(entity.EntityName))
                                    {
                                        if (pbr.BranchClass == "VIEW")
                                        {
                                            //int entcnt=srcds.GetEntitesList().Where(p=>p.Equals(entity.DatasourceEntityName,StringComparison.InvariantCultureIgnoreCase)).Count();

                                            ////entity.EntityName = entity.EntityName +$"_{entcnt+1}"
                                            //entity.EntityName = entity.EntityName + $"_{srcds.DatasourceName}";
                                            IsView = false;
                                        }
                                        else
                                        {
                                            IsView = true;
                                            DMEEditor.AddLogMessage("Fail", $"Could Not Paste Entity {entity.EntityName}, it already exist", DateTime.Now, -1, null, Errors.Failed);
                                        }
                                    }
                                    if (!IsView)
                                    {
                                        entity.Caption = entity.EntityName.ToUpper();
                                        entity.DatasourceEntityName = entity.DatasourceEntityName;
                                        entity.Created = false;
                                        entity.DataSourceID = srcds.DatasourceName;
                                        entity.Id = cnt + 1;
                                        cnt += 1;
                                        entity.ParentId = 0;
                                        entity.ViewID = 0;
                                        entity.DatabaseType = srcds.DatasourceType;
                                        entity.Viewtype = ViewType.Table;
                                        
                                        ls.Add(entity);
                                    }

                                }
                            }
                            if (pbr.BranchClass == "VIEW")
                            {
                                DataViewDataSource ds = (DataViewDataSource)DMEEditor.GetDataSource(pbr.DataSourceName);
                                Vismanager.ShowWaitForm((PassedArgs)Passedarguments);
                                Passedarguments.ParameterString1 = $"Creating {ls.Count()} entities ...";
                                Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                                foreach (var item in ls)
                                {
                                    Passedarguments.ParameterString1 = $"Adding {item} and Child if there is ...";
                                    Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                                    ds.AddEntitytoDataView(item);
                                }
                                Passedarguments.ParameterString1 = $"Done ...";
                                Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                                Passedarguments.ParameterString1 = $"Done ...";
                                Vismanager.CloseWaitForm();
                                ds.WriteDataViewFile(ds.DatasourceName);
                            }
                            else
                            {
                                DMEEditor.ETL.Script = new ETLScriptHDR();
                                DMEEditor.ETL.Script.id = 1;
                                var progress = new Progress<PassedArgs>(percent => {
                                });
                                tokenSource = new CancellationTokenSource();
                                token = tokenSource.Token;
                                DMEEditor.ETL.Script.ScriptDTL = DMEEditor.ETL.GetCreateEntityScript(DataSource, ls, progress, token);
                                Vismanager.ShowPage("uc_CopyEntities", (PassedArgs)Passedargs, DisplayType.InControl);
                            }
                            pbr.CreateChildNodes();

                        }
                    }
                }
                DMEEditor.AddLogMessage("Success", $"Paste entities", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = $" Could not Added Entity {ex.Message} ";
                DMEEditor.AddLogMessage("Fail", mes, DateTime.Now, -1, mes, Errors.Failed);
            };

        }
        [CommandAttribute(Name = "Refresh", Caption = "Refresh", Click = true, iconimage = "refresh.ico", PointType = EnumPointType.DataPoint)]
        public void Refresh(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //     DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
                string iconimage;

                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);
                    if (DataSource != null)
                    {
                        //  DataSource.Dataconnection.OpenConnection();
                        if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                        {
                            if (Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                            {
                                pbr.CreateChildNodes();
                                //TreeEditor.HideWaiting();
                                DMEEditor.AddLogMessage("Success", $"Refresh entities", DateTime.Now, 0, null, Errors.Ok);
                                Vismanager.Controlmanager.MsgBox("Beep", "Refresh Entities Successfully");
                            }

                        }

                    }
                }


            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Filling Database Entites ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }

        }
//        [CommandAttribute(Name = "CreateNewEntities", Caption = "Create New Entities", Click = true, iconimage = "createnewentities.ico", PointType = EnumPointType.DataPoint)]
//        public void CreateNewEntities(IPassedArgs Passedarguments)
//        {
//            DMEEditor.ErrorObject.Flag = Errors.Ok;
//            //     DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
//            try
//            {
//                string iconimage;

//                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
//                if (pbr.BranchType == EnumPointType.DataPoint)
//                {
//                    GetValues(Passedarguments);
//                    if (DataSource != null)
//                    {
//                        //  DataSource.Dataconnection.OpenConnection();
//                        if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
//                        {
//                            if (Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
//                            {
//                               // pbr.CreateChildNodes();
//                                //TreeEditor.HideWaiting();
//                                DMEEditor.Passedarguments = Passedarguments;
//                                DMEEditor.Passedarguments.DatasourceName = DataSource.DatasourceName;
//                                Vismanager.ShowPage("uc_CopyEntities", (PassedArgs)DMEEditor.Passedarguments, DisplayType.InControl);
//                                DMEEditor.AddLogMessage("Success", $"Creatd New Entities in DataSource", DateTime.Now, 0, null, Errors.Ok);
////                                Vismanager.Controlmanager.MsgBox("Beep", $"Created New Entities in DataSource");
//                            }

//                        }

//                    }
//                }


//            }
//            catch (Exception ex)
//            {
//                DMEEditor.Logger.WriteLog($"Error in Filling Database Entites ({ex.Message}) ");
//                DMEEditor.ErrorObject.Flag = Errors.Failed;
//                DMEEditor.ErrorObject.Ex = ex;
//            }

//        }
        [CommandAttribute(Caption = "Drop Entities", Name = "dropentities", Click = true, iconimage = "dropentities.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo DropEntities(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            EntityStructure ent = new EntityStructure();
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            if (pbr.BranchType == EnumPointType.DataPoint)
            {
                try
                {
                    GetValues(Passedarguments);
                    if (Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure you ?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                    {
                        if (TreeEditor.SelectedBranchs.Count > 0)
                        {
                            foreach (int item in TreeEditor.SelectedBranchs)
                            {
                                IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);
                                if(br!= null)
                                {
                                    if (br.DataSourceName == Passedarguments.DatasourceName)
                                    {
                                        IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);
                                        ent = DataSource.GetEntityStructure(br.BranchText, false);
                                        if (!(br.BranchClass == "VIEW") && (DataSource.Category == DatasourceCategory.RDBMS))
                                        {
                                            DataSource.ExecuteSql($"Drop Table {ent.DatasourceEntityName}");
                                        }

                                        if (DMEEditor.ErrorObject.Flag == Errors.Ok)
                                        {
                                            TreeEditor.treeBranchHandler.RemoveBranch(br);
                                            DataSource.Entities.RemoveAt(DataSource.Entities.FindIndex(p => p.DatasourceEntityName == ent.DatasourceEntityName && p.DataSourceID == ent.DataSourceID));
                                            DMEEditor.AddLogMessage("Success", $"Droped Entity {ent.EntityName}", DateTime.Now, -1, null, Errors.Ok);
                                        }
                                        else
                                        {
                                            DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {ent.EntityName} - {DMEEditor.ErrorObject.Message}", DateTime.Now, -1, null, Errors.Failed);
                                        }
                                    }
                                }
                                
                            }
                            DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new DatasourceEntities { datasourcename = Passedarguments.DatasourceName, Entities = DataSource.Entities });
                            DMEEditor.AddLogMessage("Success", $"Deleted entities", DateTime.Now, 0, null, Errors.Ok);
                            Vismanager.Controlmanager.MsgBox("Beep", "Deleted Entities Successfully");
                        }
                    }
                }
                catch (Exception ex)
                {
                    DMEEditor.ErrorObject.Flag = Errors.Failed;
                    DMEEditor.ErrorObject.Ex = ex;
                    DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {ent.EntityName} - {ex.Message}", DateTime.Now, -1, null, Errors.Failed);
                }
            }

            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Import Data", Name = "ImportData", Click = true, iconimage = "importdata.ico", PointType = EnumPointType.Entity)]
        public IErrorsInfo ImportData(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            EntityStructure ent = new EntityStructure();
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            if (pbr.BranchType == EnumPointType.Entity)
            {
                try
                {
                    GetValues(Passedarguments);
                   
                    Vismanager.ShowPage("ImportDataManager", (PassedArgs)Passedarguments);

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
        [CommandAttribute(Caption = "Create Entity", Name = "CreateEntity", Click = true, iconimage = "createentity.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CreateEntity(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            EntityStructure ent = new EntityStructure();
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            if (pbr.BranchType == EnumPointType.DataPoint )
            {
                try
                {
                    GetValues(Passedarguments);
                    Passedarguments.DatasourceName = pbr.BranchText;
                    if(!pbr.BranchClass.Equals("View",StringComparison.InvariantCultureIgnoreCase))
                    {
                        Vismanager.ShowPage("uc_CreateEntity", (PassedArgs)Passedarguments, DisplayType.InControl);
                    }else
                        Vismanager.ShowPage("CreateEditEntityManager", (PassedArgs)Passedarguments, DisplayType.InControl);


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
        [CommandAttribute(Caption = "Create Report", Name = "CreateReportDefinition", Click = true, iconimage = "reportdesigner.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CreateReportDefinition(IPassedArgs Passedarguments)
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
                    IDataSource ds = DMEEditor.GetDataSource(Passedarguments.DatasourceName);
                    AppTemplate app= CreateReportDefinitionFromView(ds);
                    //if (!pbr.BranchClass.Equals("View", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    Vismanager.ShowPage("uc_CreateEntity", (PassedArgs)Passedarguments, DisplayType.InControl);
                    //}
                    //else
                    //    Vismanager.ShowPage("CreateEditEntityManager", (PassedArgs)Passedarguments, DisplayType.InControl);
                    DMEEditor.ConfigEditor.ReportsDefinition.Add(app);
                    DMEEditor.ConfigEditor.SaveReportDefinitionsValues();
                    IBranch reports = TreeEditor.Branches.FirstOrDefault(p=>p.BranchClass== "REPORT" && p.BranchType== EnumPointType.Root);
                    if(reports != null)
                    {
                        reports.CreateChildNodes();
                    }
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
        private AppTemplate CreateReportDefinitionFromView(IDataSource src)
        {
            AppTemplate app = new AppTemplate();
            app.DataSourceName = src.DatasourceName;
            app.Name = src.DatasourceName;
            app.ID = Guid.NewGuid().ToString();
            foreach (EntityStructure item in src.Entities)
            {
                AppBlock blk = new AppBlock();
                blk.filters = item.Filters;
                blk.Paramenters = item.Paramenters;
                blk.Fields = item.Fields;
                blk.Relations = item.Relations;
                blk.ViewID = src.DatasourceName;
                blk.CustomBuildQuery = item.CustomBuildQuery;
                
                foreach (EntityField flds in item.Fields)
                {
                    blk.BlockColumns.Add(new AppBlockColumns() { ColumnName = flds.fieldname, DisplayName = flds.fieldname, ColumnSeq = flds.FieldIndex });

                }
                app.Blocks.Add(blk);
            }
            return app;
        }

    }
}
