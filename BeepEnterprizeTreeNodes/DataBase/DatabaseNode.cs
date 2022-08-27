using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace  BeepEnterprize.Vis.Module
{
    [AddinAttribute(Caption = "RDBMS", Name = "DatabaseNode.Beep", misc = "Beep", iconimage = "database.ico", menu = "Beep", ObjectType = "Beep")]
    public class DatabaseNode  : IBranch 
    {
        public DatabaseNode()
        {

        }
        public DatabaseNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename)
        {
            TreeEditor = pTreeEditor;
            DMEEditor = pDMEEditor;
            ParentBranchID = pParentNode.ID;
            BranchText = pBranchText;
            BranchType = pBranchType;
            IconImageName = pimagename;
            DataSourceName = pBranchText;
            if (pID != 0)
            {
                ID = pID;
                BranchID = ID;
            }
        }
        public IErrorsInfo SetConfig(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename)
        {

            try
            {
                TreeEditor = pTreeEditor;
                DMEEditor = pDMEEditor;
                ParentBranchID = pParentNode.ID;
                BranchText = pBranchText;
                BranchType = pBranchType;
                IconImageName = pimagename;
                if (pID != 0)
                {
                    ID = pID;
                    BranchID = ID;
                }
                DMEEditor.AddLogMessage("Success", "Set Config OK", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Set Config";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        public object ParentBranch { get; set; }
        public string Name { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string BranchText { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public IDataSource DataSource { get; set; }
        public string DataSourceName { get; set; }
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.DataPoint;
        public int BranchID { get; set; }
        public string IconImageName { get; set; }
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchClass { get; set; } = "RDBMS";
        public List<IBranch> ChildBranchs { get; set; } = new List<IBranch>();
        public ITree TreeEditor { get; set; }
        public List<string> BranchActions { get; set; }
        public List<Delegate> Delegates { get; set; }
        public int ID { get; set; }
        public object TreeStrucure { get ; set ; }
        public  IVisManager  Visutil  { get ; set ; }
        public int MiscID { get; set; }
        public string ObjectType { get; set; } = "Beep";
        public IErrorsInfo CreateChildNodes()
        {
           return GetDatabaseEntites();
        }
        public IErrorsInfo CreateDelegateMenu()
        {
            throw new NotImplementedException();
        }
        public IErrorsInfo ExecuteBranchAction(string ActionName)
        {
            throw new NotImplementedException();
        }
        public IErrorsInfo MenuItemClicked(string ActionNam)
        {
            throw new NotImplementedException();
        }
        public IErrorsInfo RemoveChildNodes()
        {
            throw new NotImplementedException();
        }
        [CommandAttribute(Caption = "Get Entities", iconimage = "get_childs.ico")]
        public IErrorsInfo GetDatabaseEntites()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //     DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            PassedArgs passedArgs = new PassedArgs { DatasourceName = BranchText };
            try
            {
                EntityStructure ent;
                string iconimage;
                DataSource = (IRDBSource)DMEEditor.GetDataSource(BranchText);
                Visutil.ShowWaitForm(passedArgs);
                if (DataSource != null)
                {
                  
                    DataSource.Openconnection();
                    if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                    {
                        passedArgs.ParameterString1 = "Connection Successful";
                        Visutil.PasstoWaitForm(passedArgs);
                        passedArgs.ParameterString1 = "Getting Entities";
                        Visutil.PasstoWaitForm(passedArgs);
                        
                        List<string> ename = DataSource.Entities.Select(o => o.EntityName.ToUpper()).ToList();
                        DataSource.GetEntitesList();
                        List<string> existing = DataSource.EntitiesNames.ToList();
                        List<string> diffnames = ename.Except(existing).ToList();
                        TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                        int i = 0;
                        if(existing.Count > 0) // there is entities in Datasource
                        {
                            foreach (string tb in diffnames) //
                            {
                               ent = DataSource.GetEntityStructure(tb, true);
                                if(ent != null)
                                {
                                    if (ent.Created == false)
                                    {
                                        DataSource.Entities.Remove(ent);
                                        DataSource.EntitiesNames.Remove(tb);
                                    }
                                    else
                                    {
                                        iconimage = "databaseentities.ico";
                                        DatabaseEntitesNode dbent = new DatabaseEntitesNode(TreeEditor, DMEEditor, this, tb, TreeEditor.SeqID, EnumPointType.Entity, iconimage, DataSource);
                                        dbent.DataSourceName = DataSource.DatasourceName;
                                        dbent.DataSource = DataSource;
                                        ChildBranchs.Add(dbent);
                                        TreeEditor.treeBranchHandler.AddBranch(this, dbent);
                                        i += 1;
                                    }
                                  
                                }
                            }
                            passedArgs.ParameterString1 = $"Getting {existing.Count} Entities";
                            Visutil.PasstoWaitForm(passedArgs);
                            //------------------------------- Draw Existing Entities
                            foreach (string tb in existing) //
                            {
                                ent = DataSource.GetEntityStructure(tb, false);
                                if (ent.Created == false)
                                {
                                    DataSource.Entities.Remove(ent);
                                    DataSource.EntitiesNames.Remove(tb);
                                    //   iconimage = "entitynotcreated.ico";
                                }
                                else
                                {
                                    iconimage = "databaseentities.ico";
                                    DatabaseEntitesNode dbent = new DatabaseEntitesNode(TreeEditor, DMEEditor, this, tb, TreeEditor.SeqID, EnumPointType.Entity, iconimage, DataSource);
                                    dbent.DataSourceName = DataSource.DatasourceName;
                                    dbent.DataSource = DataSource;
                                    ChildBranchs.Add(dbent);
                                    TreeEditor.treeBranchHandler.AddBranch(this, dbent);
                                    i += 1;
                                }
                              
                            }
                            //------------------------------------------------------

                        }else
                        {
                            passedArgs.ParameterString1 = passedArgs.ParameterString1+Environment.NewLine+ "No Entities Found";
                            Visutil.PasstoWaitForm(passedArgs);
                        }


                        passedArgs.ParameterString1 = passedArgs.ParameterString1+Environment.NewLine +  "Done";
                        Visutil.PasstoWaitForm(passedArgs);
                        DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new TheTechIdea.Beep.ConfigUtil.DatasourceEntities { datasourcename = DataSourceName, Entities = DataSource.Entities });
                    }
                    else
                    {
                        passedArgs.ParameterString1 = passedArgs.ParameterString1+ Environment.NewLine + "Could not Open Connection";
                        Visutil.PasstoWaitForm(passedArgs);
                    }
                }else
                {
                    passedArgs.ParameterString1 = passedArgs.ParameterString1 + Environment.NewLine + "Could not Get Datsource";
                    Visutil.PasstoWaitForm(passedArgs);
                }
                Visutil.CloseWaitForm();
            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Connecting to DataSource ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                passedArgs.ParameterString1 = "Could not Open Connection";
                Visutil.PasstoWaitForm(passedArgs);
                Visutil.CloseWaitForm();
            }
    
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Caption = "Scan for New Entities", iconimage = "Scan.ico")]
        public IErrorsInfo ScanDatabaseEntites()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            PassedArgs passedArgs = new PassedArgs { DatasourceName = BranchText };
            try
            {
                string iconimage;
                DataSource = (IRDBSource)DMEEditor.GetDataSource(BranchText);
                if (DataSource != null)
                {
                    Visutil.ShowWaitForm(passedArgs);
                    DataSource.Openconnection();
                    if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                    {
                        if (Visutil.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                        {
                            passedArgs.ParameterString1 = "Connection Successful";
                            Visutil.PasstoWaitForm(passedArgs);
                            passedArgs.ParameterString1 = "Getting Entities";
                            Visutil.PasstoWaitForm(passedArgs);
                            DataSource.GetEntitesList();
                            List<string> ename = DataSource.Entities.Select(p => p.EntityName.ToUpper()).ToList();
                            List<string> diffnames = ename.Except(DataSource.EntitiesNames).ToList();
                          //  DataSource.Entities.Clear();
                           // TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                            int i = 0;
                            // TreeEditor.ShowWaiting();
                            //  TreeEditor.ChangeWaitingCaption($"Getting  RDBMS Entities Total:{DataSource.EntitiesNames.Count}");
                            passedArgs.ParameterString1 = $"Getting {diffnames.Count} Entities";
                            Visutil.PasstoWaitForm(passedArgs);
                            foreach (string tb in diffnames)
                            {

                                if (!ChildBranchs.Where(x => x.Name.Equals(tb, StringComparison.OrdinalIgnoreCase)).Any())
                                {
                                    EntityStructure ent = DataSource.GetEntityStructure(tb, true);
                                    if (ent.Created == false)
                                    {
                                        iconimage = "entitynotcreated.ico";
                                    }
                                    else
                                    {
                                        iconimage = "databaseentities.ico";
                                    }
                                    DatabaseEntitesNode dbent = new DatabaseEntitesNode(TreeEditor, DMEEditor, this, tb, TreeEditor.SeqID, EnumPointType.Entity, iconimage, DataSource);

                                    dbent.DataSourceName = DataSource.DatasourceName;
                                    dbent.DataSource = DataSource;
                                    ChildBranchs.Add(dbent);
                                    i += 1;
                                    TreeEditor.treeBranchHandler.AddBranch(this, dbent);

                                }

                            }
                            passedArgs.ParameterString1 = "Done";
                            Visutil.PasstoWaitForm(passedArgs);
                            DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new TheTechIdea.Beep.ConfigUtil.DatasourceEntities { datasourcename = DataSourceName, Entities = DataSource.Entities });

                        }

                    }else
                    {
                        passedArgs.ParameterString1 = "Could not Open Connection";
                        Visutil.PasstoWaitForm(passedArgs);
                    }
                    Visutil.CloseWaitForm();
                }

              

            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Filling Database Entites ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                passedArgs.ParameterString1 = "Could not Open Connection";
                Visutil.PasstoWaitForm(passedArgs);
                Visutil.CloseWaitForm();
            }
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Caption = "Refresh Entities", iconimage = "refresh.ico")]
        public IErrorsInfo RefreshDatabaseEntites()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            PassedArgs passedArgs = new PassedArgs { DatasourceName = BranchText };
            try
            {
                string iconimage;
                DataSource = (IRDBSource)DMEEditor.GetDataSource(BranchText);
                if (DataSource != null)
                {

                    Visutil.ShowWaitForm(passedArgs);
                    DataSource.Openconnection();
                    if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                    {
                        if (Visutil.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                        {
                            passedArgs.ParameterString1 = "Connection Successful";
                            Visutil.PasstoWaitForm(passedArgs);
                            passedArgs.ParameterString1 = "Getting Entities";
                            Visutil.PasstoWaitForm(passedArgs);
                            DataSource.Entities.Clear();
                            DataSource.GetEntitesList();
                            //TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                            int i = 0;
                            passedArgs.ParameterString1 = $"Getting {DataSource.EntitiesNames.Count} Entities";
                            Visutil.PasstoWaitForm(passedArgs);
                            foreach (string tb in DataSource.EntitiesNames)
                            {
                                if(!ChildBranchs.Where(x=>x.Name.Equals(tb,StringComparison.OrdinalIgnoreCase)).Any())
                                {
                                    EntityStructure ent = DataSource.GetEntityStructure(tb, true);
                                    if (ent.Created == false)
                                    {
                                        iconimage = "entitynotcreated.ico";
                                    }
                                    else
                                    {
                                        iconimage = "databaseentities.ico";
                                    }
                                    DatabaseEntitesNode dbent = new DatabaseEntitesNode(TreeEditor, DMEEditor, this, tb, TreeEditor.SeqID, EnumPointType.Entity, iconimage, DataSource);
                                    //   TreeEditor.treeBranchHandler.AddBranch(this, dbent);
                                    dbent.DataSourceName = DataSource.DatasourceName;
                                    dbent.DataSource = DataSource;
                                    ChildBranchs.Add(dbent);
                                    TreeEditor.treeBranchHandler.AddBranch(this, dbent);
                                    i += 1;
                                }
                            
                            }

                            passedArgs.ParameterString1 = "Done";
                            Visutil.PasstoWaitForm(passedArgs);
                            DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new TheTechIdea.Beep.ConfigUtil.DatasourceEntities { datasourcename = DataSourceName, Entities = DataSource.Entities });
                        }

                    }
                    else
                    {
                        passedArgs.ParameterString1 = "Could not Open Connection";
                        Visutil.PasstoWaitForm(passedArgs);
                    }


                }

                Visutil.CloseWaitForm();


            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Connecting to DataSource ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                passedArgs.ParameterString1 = "Could not Open Connection";
                Visutil.PasstoWaitForm(passedArgs);
                Visutil.CloseWaitForm();
            }
            return DMEEditor.ErrorObject;

        }
        //[CommandAttribute(Caption = "Drop Entities", iconimage = "remove.ico")]
        //public IErrorsInfo DropEntities()
        //{
        //    DMEEditor.ErrorObject.Flag = Errors.Ok;
        //    try
        //    {
        //        if (Visutil.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure you ?") ==BeepEnterprize.Vis.Module.DialogResult.Yes)
        //        {
        //            if (TreeEditor.SelectedBranchs.Count > 0)
        //            {
        //                foreach (int item in TreeEditor.SelectedBranchs)
        //                {
        //                    IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);
        //                    if (br != null)
        //                    {
        //                        if (br.DataSourceName == DataSourceName)
        //                        {
        //                            IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);
        //                            EntityStructure ent = DataSource.GetEntityStructure(br.BranchText, false);
        //                            DataSource.ExecuteSql($"Drop Table {ent.DatasourceEntityName}");
        //                            if (DMEEditor.ErrorObject.Flag == Errors.Ok)
        //                            {
        //                                TreeEditor.treeBranchHandler.RemoveBranch(br);
        //                                DataSource.Entities.RemoveAt(DataSource.Entities.FindIndex(p => p.DatasourceEntityName == ent.DatasourceEntityName));
        //                                DMEEditor.AddLogMessage("Success", $"Droped Entity {ent.EntityName}", DateTime.Now, -1, null, Errors.Ok);
        //                            }
        //                            else
        //                            {
        //                                DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {ent.EntityName} - {DMEEditor.ErrorObject.Message}", DateTime.Now, -1, null, Errors.Failed);
        //                            }
        //                        }
        //                    }
                           
        //                }
        //                DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new TheTechIdea.Beep.ConfigUtil.DatasourceEntities { datasourcename = DataSourceName, Entities = DataSource.Entities });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DMEEditor.ErrorObject.Flag = Errors.Failed;
        //        DMEEditor.ErrorObject.Ex = ex;
        //        DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {EntityStructure.EntityName} - {ex.Message}", DateTime.Now, -1, null, Errors.Failed);
        //    }
        //    return DMEEditor.ErrorObject;
        //}
        //[CommandAttribute(Caption = "Create POCO Classes")]
        //public IErrorsInfo CreatePOCOlasses()
        //{
        //    DMEEditor.ErrorObject.Flag = Errors.Ok;
        //    PassedArgs passedArgs = new PassedArgs { DatasourceName = BranchText };
        //    try
        //    {
        //        string iconimage;
        //        DataSource = (IRDBSource)DMEEditor.GetDataSource(BranchText);
        //        if (DataSource != null)
        //        {
        //            Visutil.ShowWaitForm(passedArgs);
        //            DataSource.Openconnection();

        //            if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
        //            {
        //                if (Visutil.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
        //                {
                           
        //                    int i = 0;
        //                    passedArgs.ParameterString1 = $"Creating POCO {DataSource.EntitiesNames.Count} Entities";
        //                    Visutil.PasstoWaitForm(passedArgs);
        //                    foreach (string tb in DataSource.EntitiesNames)
        //                    {
        //                   //     TreeEditor.AddCommentsWaiting($"{i} - Added {tb} to {DataSourceName}");
        //                        EntityStructure ent = DataSource.GetEntityStructure(tb, true);
                              
        //                        DMEEditor.classCreator.CreateClass(ent.EntityName, ent.Fields, DMEEditor.ConfigEditor.ExePath);
        //                        i += 1;
        //                    }
        //                    passedArgs.ParameterString1 = "Done";
        //                    Visutil.PasstoWaitForm(passedArgs);
        //                }

        //            }
        //            else
        //            {
        //                passedArgs.ParameterString1 = "Could not Open Connection";
        //                Visutil.PasstoWaitForm(passedArgs);
        //            }


        //        }

        //        Visutil.CloseWaitForm();

        //    }
        //    catch (Exception ex)
        //    {
        //        DMEEditor.Logger.WriteLog($"Error in Creating POCO Entites ({ex.Message}) ");
        //        DMEEditor.ErrorObject.Flag = Errors.Failed;
        //        DMEEditor.ErrorObject.Ex = ex;
        //        passedArgs.ParameterString1 = "Could not Open Connection";
        //        Visutil.PasstoWaitForm(passedArgs);
        //        Visutil.CloseWaitForm();
        //    }
        //    return DMEEditor.ErrorObject;

        //}
        private void update()
        {

        }

        public  IBranch  CreateCategoryNode(CategoryFolder p)
        {
            throw new NotImplementedException();
        }
    }
}
