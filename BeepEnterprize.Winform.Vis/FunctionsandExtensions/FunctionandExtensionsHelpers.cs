using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using BeepEnterprize.Winform.Vis.CRUD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.FunctionsandExtensions
{
    internal class FunctionandExtensionsHelpers
    {
        public IDMEEditor DMEEditor { get; set; }
        public IPassedArgs Passedargs { get; set; }
        public VisManager Vismanager { get; set; }
        public ControlManager Controlmanager { get; set; }
        public CrudManager Crudmanager { get; set; }
        public MenuControl Menucontrol { get; set; }
        public ToolbarControl Toolbarcontrol { get; set; }
        public TreeControl TreeEditor { get; set; }

        CancellationTokenSource tokenSource;

        CancellationToken token;

        public  IDataSource DataSource { get; set; }
        public IBranch pbr { get; set; }
        public IBranch RootBranch { get; set; }
        public IBranch ParentBranch { get; set; }
        public IBranch ViewRootBranch { get; set; }
        public FunctionandExtensionsHelpers(IDMEEditor pdMEEditor, VisManager pvisManager, TreeControl ptreeControl)
        {
            DMEEditor = pdMEEditor;
            Vismanager = pvisManager;
            TreeEditor = ptreeControl;
        }
        public void GetValues(IPassedArgs Passedarguments)
        {
            if (Passedarguments.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                Vismanager = (VisManager)Passedarguments.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
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
           
            if (Passedarguments.Objects.Where(i => i.Name == "Branch").Any())
            {
                Passedarguments.Objects.Remove(Passedarguments.Objects.Where(c => c.Name == "Branch").FirstOrDefault());
            }
            if (Passedarguments.Id > 0)
            {
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            }

           
            if (pbr != null)
            {
                Passedarguments.DatasourceName = pbr.DataSourceName;
                Passedarguments.CurrentEntity = pbr.BranchText;
                if (pbr.ParentBranchID > 0)
                {
                    ParentBranch = TreeEditor.treeBranchHandler.GetBranch(pbr.ParentBranchID);
                    Passedarguments.Objects.Add(new ObjectItem() { Name = "ParentBranch", obj = ParentBranch });
                }
                Passedarguments.Objects.Add(new ObjectItem() { Name = "Branch", obj = pbr });
                if (pbr.BranchType != EnumPointType.Root)
                {
                    int idx = TreeEditor.Branches.FindIndex(x => x.BranchClass == pbr.BranchClass && x.BranchType == EnumPointType.Root);
                    if (idx > 0)
                    {
                        RootBranch = TreeEditor.Branches[idx];

                    }

                }
                else
                {
                    RootBranch = pbr;
                }

                Passedarguments.Objects.Add(new ObjectItem() { Name = "RootBranch", obj = RootBranch });
            }
         

            if (Passedarguments.Objects.Where(i => i.Name == "RootBranch").Any())
            {
                Passedarguments.Objects.Remove(Passedarguments.Objects.Where(c => c.Name == "RootBranch").FirstOrDefault());
            }
         
            if (Passedarguments.Objects.Where(i => i.Name == "ParentBranch").Any())
            {
                Passedarguments.Objects.Remove(Passedarguments.Objects.Where(c => c.Name == "ParentBranch").FirstOrDefault());
            }
            if (Passedarguments.DatasourceName != null)
            {
                DataSource = DMEEditor.GetDataSource(Passedarguments.DatasourceName);
                DMEEditor.OpenDataSource(Passedarguments.DatasourceName);
            }
           
            
          
            ViewRootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "VIEW" && x.BranchType == EnumPointType.Root)];
        }
        public Errors CreateView(string viewname)
        {
          
             try
            {
                DMEEditor.ErrorObject.Ex = null;
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                if ((viewname != null) && DMEEditor.ConfigEditor.DataConnectionExist(viewname + ".json") == false)
                {
                    string fullname = Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(x => x.FolderFilesType == FolderFileTypes.DataView).FirstOrDefault().FolderPath, viewname + ".json");
                    ConnectionProperties f = new ConnectionProperties
                    {

                        FileName = Path.GetFileName(fullname),
                        FilePath = "./DataViews/", //'Path.GetDirectoryName(fullname),
                        Ext = Path.GetExtension(fullname),
                        ConnectionName = Path.GetFileName(fullname)
                    };

                    f.Category = DatasourceCategory.VIEWS;
                    f.DriverVersion = "1";
                    f.DriverName = "DataViewReader";

                    DMEEditor.ConfigEditor.DataConnections.Add(f);
                    DMEEditor.ConfigEditor.SaveDataconnectionsValues();

                    DataViewDataSource ds = (DataViewDataSource)DMEEditor.GetDataSource(f.ConnectionName);
                    ds.DataView = ds.GenerateView(f.ConnectionName, f.ConnectionName);

                    ds.WriteDataViewFile(fullname);
                    // pdr,CreateViewNode(ds.DataView.ViewID, ds.DataView.ViewName, f.ConnectionName);
                    DMEEditor.AddLogMessage("Success", "Added View", DateTime.Now, 0, null, Errors.Ok);

                }
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject.Flag;
            
           
        }
        public List<EntityStructure> CreateEntitiesListFromSelectedBranchs ()
        {
            List<EntityStructure> ls = new List<EntityStructure>();
            try
            {
                DMEEditor.ErrorObject.Ex = null;
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                int cnt = 0;
                foreach (int item in TreeEditor.SelectedBranchs)
                {
                   
                    IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);
                    IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);
                    if(br.BranchType== EnumPointType.Entity)
                    {
                        if (srcds != null)
                        {
                            EntityStructure entity = (EntityStructure)srcds.GetEntityStructure(br.BranchText, false).Clone();
                            bool IsView = false;

                            //if (DataSource.CheckEntityExist(entity.EntityName))
                            //{
                            //    if (pbr.BranchClass == "VIEW")
                            //    {
                            //        IsView = false;
                            //    }
                            //    else
                            //    {
                            //        IsView = true;
                            //        DMEEditor.AddLogMessage("Fail", $"Could Not Paste Entity {entity.EntityName}, it already exist", DateTime.Now, -1, null, Errors.Failed);
                            //    }
                            //}
                            //if (!IsView)
                            //{
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
                          //  }

                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return ls;

        }
        public Errors AddEntitiesToView(string datasourcename,List<EntityStructure> ls, IPassedArgs Passedarguments)
        {
             try
            {       DataViewDataSource ds = (DataViewDataSource)DMEEditor.GetDataSource(datasourcename);
                    Vismanager.ShowWaitForm((PassedArgs)Passedarguments);
                    Passedarguments.ParameterString1 = $"Creating {ls.Count()} entities ...";
                    Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                    foreach (var item in ls)
                    {
                        Passedarguments.ParameterString1 = $"Adding {item.EntityName} and Child if there is ...";
                        Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                        try
                        {
                        if (ds.AddEntitytoDataView(item) ==-1)
                        {
                           
                        }
                        }
                        catch (Exception ex1)
                        {
                          DMEEditor.AddLogMessage("Dhub3", $"Error in adding {item.EntityName} - {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex1.Message}", DateTime.Now, 0, null, Errors.Ok);
                        }
                      
                    }
                    Passedarguments.ParameterString1 = $"Done ...";
                    Vismanager.PasstoWaitForm((PassedArgs)Passedarguments);
                    Passedarguments.ParameterString1 = $"Done ...";
                    Vismanager.CloseWaitForm();
                    ds.WriteDataViewFile(ds.DatasourceName);
                //}
                //else
                //{
                //    DMEEditor.ETL.Script = new ETLScriptHDR();
                //    DMEEditor.ETL.Script.id = 1;
                //    var progress = new Progress<PassedArgs>(percent => {
                //    });
                //    tokenSource = new CancellationTokenSource();
                //    token = tokenSource.Token;
                //    DMEEditor.ETL.Script.ScriptDTL = DMEEditor.ETL.GetCreateEntityScript(DataSource, ls, progress, token);
                //    Vismanager.ShowPage("uc_CopyEntities", (PassedArgs)Passedargs, DisplayType.InControl);
                //}
                DMEEditor.ErrorObject.Ex = null;
                DMEEditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject.Flag;
        }
        public List<EntityStructure> CreateEntitiesListFromDataSource(string Datasourcename)
        {
            List<EntityStructure> ls = new List<EntityStructure>();
            try
            {
                DMEEditor.ErrorObject.Ex = null;
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                int cnt = 0;
                List<string> lsnames = new List<string>();
                IDataSource ds = DMEEditor.GetDataSource(Datasourcename);
                lsnames = ds.GetEntitesList();
                foreach (string item in lsnames)
                {
                            EntityStructure entity = (EntityStructure)ds.GetEntityStructure(item, false).Clone();
                            entity.Caption = entity.EntityName.ToUpper();
                            entity.DatasourceEntityName = entity.DatasourceEntityName;
                            entity.Created = false;
                            entity.DataSourceID = entity.DataSourceID;
                            entity.Id = cnt + 1;
                            cnt += 1;
                            entity.ParentId = 0;
                            entity.ViewID = 0;
                            entity.DatabaseType = entity.DatabaseType;
                            entity.Viewtype = ViewType.Table;
                            ls.Add(entity);

                }
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return ls;

        }
        public virtual List<ConnectionProperties> LoadFiles(string Directoryname = null)
        {
            List<ConnectionProperties> retval = new List<ConnectionProperties>();
            try
            {
                string extens = DMEEditor.ConfigEditor.CreateFileExtensionString();
                List<string> filenames = new List<string>();
                if (Directoryname == null)
                {
                    filenames = Vismanager.Controlmanager.LoadFilesDialog("*", DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.DataFiles).FirstOrDefault().FolderPath, extens);
                }
                else
                {
                    DirectorySearch(Directoryname);
                }
                retval = CreateFileConnections(filenames);
                return retval;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                DMEEditor.AddLogMessage(ex.Message, "Could not Load Files ", DateTime.Now, -1, mes, Errors.Failed);
                return null;
            };
        }
        public void DirectorySearch(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    // Console.WriteLine(Path.GetFileName(f));
                    CreateFileDataConnection(f);
                    //  ExtensionsHelpers.TreeEditor.treeBranchHandler.MoveBranchToCategory
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    TreeEditor.treeBranchHandler.AddCategory(pbr, d);
                    // Console.WriteLine(Path.GetFileName(d));
                    DirectorySearch(d);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<ConnectionProperties> CreateFileConnections(List<string> filenames)
        {
            List<ConnectionProperties> retval = new List<ConnectionProperties>();
            try
            {
                foreach (String file in filenames)
                {
                    {
                        ConnectionProperties c = CreateFileDataConnection(file);
                        if (c != null)
                        {
                            retval.Add(c);
                        }
                    }
                }
                return retval;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                DMEEditor.AddLogMessage(ex.Message, "Could not Load Files ", DateTime.Now, -1, mes, Errors.Failed);
                return null;
            };
        }
        public ConnectionProperties CreateFileDataConnection(string file)
        {
            try
            {
                ConnectionProperties f = new ConnectionProperties
                {
                    FileName = Path.GetFileName(file),
                    FilePath = Path.GetDirectoryName(file),
                    Ext = Path.GetExtension(file).Replace(".", "").ToLower(),
                    ConnectionName = Path.GetFileName(file)


                };
                if (f.FilePath.Contains(DMEEditor.ConfigEditor.ExePath))
                {
                    f.FilePath.Replace(DMEEditor.ConfigEditor.ExePath, ".");
                }
                if (f.FilePath.Contains(DMEEditor.ConfigEditor.Config.DataFilePath))
                {
                    f.FilePath.Replace(DMEEditor.ConfigEditor.Config.DataFilePath, ".");
                }
                if (f.FilePath.Contains(DMEEditor.ConfigEditor.Config.ProjectDataPath))
                {
                    f.FilePath.Replace(DMEEditor.ConfigEditor.Config.ProjectDataPath, ".");
                }
                string ext = Path.GetExtension(file).Replace(".", "").ToLower();
                List<ConnectionDriversConfig> clss = DMEEditor.ConfigEditor.DataDriversClasses.Where(p => p.extensionstoHandle != null  && p.extensionstoHandle.Contains(ext) && p.Favourite == true).ToList();
                ConnectionDriversConfig c = clss.Where(o => o.extensionstoHandle.Contains(ext) && o.Favourite == true).FirstOrDefault();
                if (c is null)
                {
                    c = clss.Where(o => o.classHandler.Equals("CSVDataSource", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                }
                if (c != null)
                {
                    f.DriverName = c.PackageName;
                    f.DriverVersion = c.version;
                    f.Category = c.DatasourceCategory;

                    switch (f.Ext.ToLower())
                    {
                        case "txt":
                            f.DatabaseType = DataSourceType.Text;
                            break;
                        case "csv":
                            f.DatabaseType = DataSourceType.CSV;
                            break;
                        case "xml":
                            f.DatabaseType = DataSourceType.xml;
                            break;
                        case "json":
                            f.DatabaseType = DataSourceType.Json;
                            break;
                        case "xls":
                        case "xlsx":
                            f.DatabaseType = DataSourceType.Xls;
                            break;
                        default:
                            f.DatabaseType = DataSourceType.Text;
                            break;
                    }
                    f.Category = DatasourceCategory.FILE;
                    return f;

                }
                else
                {
                    DMEEditor.AddLogMessage("Beep", $"Could not Load File {f.ConnectionName}", DateTime.Now, -1, null, Errors.Failed);
                }
                return f;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                DMEEditor.AddLogMessage(ex.Message, "Could not Load Files ", DateTime.Now, -1, mes, Errors.Failed);
                return null;
            };
        }
        public AppTemplate CreateReportDefinitionFromView(IDataSource src)
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
        public CategoryFolder AddtoFolder(string foldername)
        {
            CategoryFolder retval = null;
            try
            {
                IBranch Rootbr = RootBranch;
                if (!string.IsNullOrEmpty(foldername))
                {
                    if (DMEEditor.Passedarguments == null)
                    {
                        DMEEditor.Passedarguments = new PassedArgs();
                    }
                    if (foldername != null)
                    {
                        if (foldername.Length > 0)
                        {
                            if (!DMEEditor.ConfigEditor.CategoryFolders.Where(p => p.RootName.Equals(Rootbr.BranchClass, StringComparison.InvariantCultureIgnoreCase) && p.ParentName.Equals(Rootbr.BranchText, StringComparison.InvariantCultureIgnoreCase) && p.FolderName.Equals(foldername, StringComparison.InvariantCultureIgnoreCase)).Any())
                            {
                                retval = DMEEditor.ConfigEditor.AddFolderCategory(foldername, Rootbr.BranchClass, Rootbr.BranchText);
                                Rootbr.CreateCategoryNode(retval);
                                DMEEditor.ConfigEditor.SaveCategoryFoldersValues();
                            }
                        }
                    }
                }
                DMEEditor.AddLogMessage("Success", "Added Category", DateTime.Now, 0, null, Errors.Failed);
            }
            catch (Exception ex)
            {
                string mes = "Could not Add Category";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return retval;
        }

    }
}
