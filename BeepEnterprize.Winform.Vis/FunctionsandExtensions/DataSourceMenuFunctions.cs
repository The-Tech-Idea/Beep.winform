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
        //private VisManager Vismanager { get; set; }
        //private ControlManager Controlmanager { get; set; }
        //private CrudManager Crudmanager { get; set; }
        //private MenuControl Menucontrol { get; set; }
        //private ToolbarControl Toolbarcontrol { get; set; }
        //private TreeControl TreeEditor { get; set; }

        CancellationTokenSource tokenSource;

        CancellationToken token;
        
        //IDataSource DataSource;
        //IBranch pbr;
        //IBranch RootBranch;
        //IBranch ParentBranch;

        private FunctionandExtensionsHelpers ExtensionsHelpers;
        public DataSourceMenuFunctions(IDMEEditor pdMEEditor,VisManager pvisManager,TreeControl ptreeControl)
        {
            DMEEditor = pdMEEditor;
            //Vismanager = pvisManager;
            //TreeEditor = ptreeControl;
            ExtensionsHelpers=new FunctionandExtensionsHelpers(DMEEditor, pvisManager, ptreeControl);
        }
     
        [CommandAttribute(Name = "Copy Entities", Caption = "Copy Entities", Click = true, iconimage = "copyentities.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CopyEntities(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //   DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
                List<EntityStructure> ents = new List<EntityStructure>();
                ExtensionsHelpers.GetValues(Passedarguments);
               
                if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
                {
                 
                    string[] args = new string[] { ExtensionsHelpers.pbr.BranchText, ExtensionsHelpers.DataSource.Dataconnection.ConnectionProp.SchemaName, null };

                    Passedarguments.EventType = "COPYENTITIES";
                    Passedarguments.ParameterString1 = "COPYENTITIES";

                    DMEEditor.Passedarguments = Passedarguments;
                }
               
                DMEEditor.AddLogMessage("Success", $"Copy Entites", DateTime.Now, 0, null, Errors.Ok);
                ExtensionsHelpers.Vismanager.Controlmanager.MsgBox("Beep", $"Copied  {ExtensionsHelpers.TreeEditor.SelectedBranchs.Count} Entities Successfully");
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
                ExtensionsHelpers.GetValues(Passedarguments);
               
                if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
                {
                   
                   
                    string iconimage = "";
                    int cnt = 0;
                    List<EntityStructure> ls = new List<EntityStructure>();
                    if (DMEEditor.Passedarguments != null)
                    {

                        if (ExtensionsHelpers.TreeEditor.SelectedBranchs.Count > 0 )
                        {
                           
                            
                            foreach (int item in ExtensionsHelpers.TreeEditor.SelectedBranchs)
                            {
                                IBranch br = ExtensionsHelpers.TreeEditor.treeBranchHandler.GetBranch(item);
                                IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);

                                if (srcds != null)
                                {
                                    EntityStructure entity = (EntityStructure)srcds.GetEntityStructure(br.BranchText, true).Clone();
                                    bool IsView = false;
                                   
                                    if (ExtensionsHelpers.DataSource.CheckEntityExist(entity.EntityName))
                                    {
                                        if (ExtensionsHelpers.pbr.BranchClass == "VIEW")
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
                            if (ExtensionsHelpers.pbr.BranchClass == "VIEW")
                            {
                                DataViewDataSource ds = (DataViewDataSource)DMEEditor.GetDataSource(ExtensionsHelpers.pbr.DataSourceName);
                                ExtensionsHelpers.Vismanager.ShowWaitForm((PassedArgs)Passedarguments);
                                Passedarguments.ParameterString1 = $"Creating {ls.Count()} entities ...";
                                ExtensionsHelpers.Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                                foreach (var item in ls)
                                {
                                    Passedarguments.ParameterString1 = $"Adding {item} and Child if there is ...";
                                    ExtensionsHelpers.Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                                    ds.AddEntitytoDataView(item);
                                }
                                Passedarguments.ParameterString1 = $"Done ...";
                                ExtensionsHelpers.Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                                Passedarguments.ParameterString1 = $"Done ...";
                                ExtensionsHelpers.Vismanager.CloseWaitForm();
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
                                DMEEditor.ETL.Script.ScriptDTL = DMEEditor.ETL.GetCreateEntityScript(ExtensionsHelpers.DataSource, ls, progress, token);
                                ExtensionsHelpers.Vismanager.ShowPage("uc_CopyEntities", (PassedArgs)Passedargs, DisplayType.InControl);
                            }
                            ExtensionsHelpers.pbr.CreateChildNodes();

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
                ExtensionsHelpers.GetValues(Passedarguments);
               
                if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
                {
                    
                    if (ExtensionsHelpers.DataSource != null)
                    {
                        //  DataSource.Dataconnection.OpenConnection();
                        if (ExtensionsHelpers.DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                        {
                            if (ExtensionsHelpers.Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                            {
                                ExtensionsHelpers.pbr.CreateChildNodes();
                                //TreeEditor.HideWaiting();
                                DMEEditor.AddLogMessage("Success", $"Refresh entities", DateTime.Now, 0, null, Errors.Ok);
                                ExtensionsHelpers.Vismanager.Controlmanager.MsgBox("Beep", "Refresh Entities Successfully");
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
        [CommandAttribute(Name = "CreateViewFromDataSource", Caption = "Create View From DataSource", Click = true, iconimage = "createnewentities.ico", PointType = EnumPointType.DataPoint)]
        public void CreateViewFromDataSource(IPassedArgs Passedarguments)
        {
            try
            {
                ExtensionsHelpers.GetValues(Passedarguments);
                if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
                {
                    List<EntityStructure> ls = new List<EntityStructure>();
                    if (DMEEditor.Passedarguments != null)
                    {
                        //if (ExtensionsHelpers.TreeEditor.SelectedBranchs.Count > 0)
                        //{
                            string viewname = null;
                            if(ExtensionsHelpers.Vismanager._controlManager.InputBox("Beep","Please Enter New View Name",ref viewname) == DialogResult.OK)
                            {
                                if (!string.IsNullOrEmpty(viewname))
                                {
                                    if (DMEEditor.CheckDataSourceExist(viewname + ".json"))
                                    {
                                        DMEEditor.AddLogMessage("Beep",$"View Name Exist, please Try another one", DateTime.Now, -1, null, Errors.Failed);
                                        ExtensionsHelpers.Vismanager._controlManager.MsgBox("Beep", $"View Name Exist, please Try another one");
                                       return;
                                    }
                                }
                                else
                                {
                                    DMEEditor.AddLogMessage("Beep", $"please enter a valid Viewname", DateTime.Now, -1, null, Errors.Failed);
                                ExtensionsHelpers.Vismanager._controlManager.MsgBox("Beep", $"View Name Exist, please Try another one");
                                return;
                                }
                                if (ExtensionsHelpers.CreateView(viewname) == Errors.Ok)
                                {
                                    ls = ExtensionsHelpers.CreateEntitiesListFromDataSource(ExtensionsHelpers.pbr.BranchText);
                                    if (ExtensionsHelpers.AddEntitiesToView(viewname+".json", ls, Passedarguments) == Errors.Ok)
                                    {
                                        ExtensionsHelpers.ViewRootBranch.CreateChildNodes();
                                    }
                                }
                            }
                        //}
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
        [CommandAttribute(Caption = "Drop Entities", Name = "dropentities", Click = true, iconimage = "dropentities.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo DropEntities(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            EntityStructure ent = new EntityStructure();
            ExtensionsHelpers.GetValues(Passedarguments);
            if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
            {
                try
                {
                   
                    if (ExtensionsHelpers.Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure you ?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                    {
                        if (ExtensionsHelpers.TreeEditor.SelectedBranchs.Count > 0)
                        {
                            foreach (int item in ExtensionsHelpers.TreeEditor.SelectedBranchs)
                            {
                                IBranch br = ExtensionsHelpers.TreeEditor.treeBranchHandler.GetBranch(item);
                                if(br!= null)
                                {
                                    if (br.DataSourceName == Passedarguments.DatasourceName)
                                    {
                                        IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);
                                        ent = ExtensionsHelpers.DataSource.GetEntityStructure(br.BranchText, false);
                                        if (!(br.BranchClass == "VIEW") && (ExtensionsHelpers.DataSource.Category == DatasourceCategory.RDBMS))
                                        {
                                            ExtensionsHelpers.DataSource.ExecuteSql($"Drop Table {ent.DatasourceEntityName}");
                                        }

                                        if (DMEEditor.ErrorObject.Flag == Errors.Ok)
                                        {
                                            ExtensionsHelpers.TreeEditor.treeBranchHandler.RemoveBranch(br);
                                            ExtensionsHelpers.DataSource.Entities.RemoveAt(ExtensionsHelpers.DataSource.Entities.FindIndex(p => p.DatasourceEntityName == ent.DatasourceEntityName && p.DataSourceID == ent.DataSourceID));
                                            DMEEditor.AddLogMessage("Success", $"Droped Entity {ent.EntityName}", DateTime.Now, -1, null, Errors.Ok);
                                        }
                                        else
                                        {
                                            DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {ent.EntityName} - {DMEEditor.ErrorObject.Message}", DateTime.Now, -1, null, Errors.Failed);
                                        }
                                    }
                                }
                                
                            }
                            DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new DatasourceEntities { datasourcename = Passedarguments.DatasourceName, Entities = ExtensionsHelpers.DataSource.Entities });
                            DMEEditor.AddLogMessage("Success", $"Deleted entities", DateTime.Now, 0, null, Errors.Ok);
                            ExtensionsHelpers.Vismanager.Controlmanager.MsgBox("Beep", "Deleted Entities Successfully");
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
            ExtensionsHelpers.GetValues(Passedarguments);
            if (ExtensionsHelpers.pbr.BranchType == EnumPointType.Entity)
            {
                try
                {
                    ExtensionsHelpers.GetValues(Passedarguments);

                    ExtensionsHelpers.Vismanager.ShowPage("ImportDataManager", (PassedArgs)Passedarguments);

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
            ExtensionsHelpers.GetValues(Passedarguments);
          
            if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint )
            {
                try
                {
                   
                    Passedarguments.DatasourceName = ExtensionsHelpers.pbr.BranchText;
                    Passedarguments.CurrentEntity = null;
                    if (!ExtensionsHelpers.pbr.BranchClass.Equals("View",StringComparison.InvariantCultureIgnoreCase))
                    {
                        ExtensionsHelpers.Vismanager.ShowPage("uc_CreateEntity", (PassedArgs)Passedarguments, DisplayType.InControl);
                    }else
                        ExtensionsHelpers.Vismanager.ShowPage("CreateEditEntityManager", (PassedArgs)Passedarguments, DisplayType.InControl);


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
            ExtensionsHelpers.GetValues(Passedarguments);
            if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
            {
                try
                {
                    
                    Passedarguments.DatasourceName = ExtensionsHelpers.pbr.BranchText;
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
                    IBranch reports = ExtensionsHelpers.TreeEditor.Branches.FirstOrDefault(p=>p.BranchClass== "REPORT" && p.BranchType== EnumPointType.Root);
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
