using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace  BeepEnterprize.Vis.Module
{
    public class DataViewNode  : IBranch 
    {
        public DataViewNode()
        {

        }
        public DataViewNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename,string ConnectionName)
        {

           

            TreeEditor = pTreeEditor;
            DMEEditor = pDMEEditor;
            ParentBranchID = pParentNode.ID;
            BranchText = pBranchText;
            BranchType = pBranchType;
        //   IconImageName = pimagename;

            ds = (DataViewDataSource)DMEEditor.GetDataSource(ConnectionName);
            //if (ds.Entities.Count > 0)
            //{
            //    ds.Entities.Clear();
            //    DMEEditor.ConfigEditor.SaveDataconnectionsValues();
            //}
            if (ds != null) MiscID = ds.ViewID ; 
            DataSourceName = ConnectionName;
            if (pID != 0)

            {
               
                    ID = pID;
                   
                BranchID = pID;
            }
        }
        #region "Properties"
        public int ID { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string Name { get; set; }
        public string BranchText { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public IDataSource DataSource { get; set; }
        public string DataSourceName { get; set; }
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.DataPoint;
        public int BranchID { get; set; }
        public string IconImageName { get; set; } = "dataviewnode.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchClass { get; set; } = "VIEW";
        public List<IBranch> ChildBranchs { get; set; } = new List<IBranch>();
        public ITree TreeEditor { get; set; }
        public List<string> BranchActions { get; set; }
        public object TreeStrucure { get; set; }
        public  IVisManager  Visutil { get; set; }
        public int MiscID { get; set; }
        DataViewDataSource ds;
        public IDMDataView DataView
        {
            get
            {
                if (ds != null)
                {
                    return ds.DataView;
                }
                else
                    return null;
               
            }
            set
            {
                ds.DataView = value;
            }
        }
     
        #endregion "Properties"
        #region "Interface Methods"
        public IErrorsInfo CreateChildNodes()
        {

            try
            {
                CreateViewEntites();

                DMEEditor.AddLogMessage("Success", "Added Child Nodes", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Child Nodes";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
            
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
                    BranchID = pID;
                    
                }

             //   DMEEditor.AddLogMessage("Success", "Set Config OK", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Set Config";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion "Interface Methods"
        #region "Exposed Interface"
        [CommandAttribute(Caption = "Edit", iconimage = "edit_entity.ico")]
        public IErrorsInfo Edit()
        {

            try
            {

                ds = (DataViewDataSource)DMEEditor.GetDataSource(DataSourceName);
                ds.Openconnection();
                if (ds != null)
                {
                    if (ds.ConnectionStatus != System.Data.ConnectionState.Open)
                    {
                        DMEEditor.Logger.WriteLog($"Could not Find DataView File " + DataSourceName);
                    }
                    else
                    {
                        string[] args = { "New Query Entity", null, null };
                        List<ObjectItem> ob = new List<ObjectItem>(); ;
                        ObjectItem it = new ObjectItem();
                        it.obj = this;
                        it.Name = "Branch";
                        ob.Add(it);
                        IBranch RootCompositeLayerBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "VIEW" && x.BranchType == EnumPointType.Root)];
                        it = new ObjectItem();
                        it.obj = RootCompositeLayerBranch;
                        it.Name = "RootAppBranch";
                        ob.Add(it);
                        PassedArgs Passedarguments = new PassedArgs
                        {
                            Addin = null,
                            AddinName = null,
                            AddinType = "",
                            DMView = DataView,
                            CurrentEntity = BranchText,
                            Id = 0,
                            ObjectType = "EDITVIEW",
                            DataSource = ds,
                            ObjectName = DataView.ViewName,

                            Objects = ob,

                            DatasourceName = null,
                            EventType = "EDITVIEW"

                        };
                        // ActionNeeded?.Invoke(this, Passedarguments);
                        Visutil.ShowPage("uc_ViewEditor", Passedarguments);
                    }
                }
                else
                {
                    DMEEditor.Logger.WriteLog($"Could not Find DataView File " + DataSourceName);
                }



            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Filling DataView Entites ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Get Entities", iconimage = "localdb.ico")]
        public IErrorsInfo CreateViewEntites()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            DMEEditor.Logger.WriteLog($"Filling View Entites ) ");
            string iconname;
            try
            {
               
                ds = (DataViewDataSource)DMEEditor.GetDataSource(DataSourceName);
                ds.Openconnection();
           
                if (ds != null )
                {
                 if (ds.ConnectionStatus != System.Data.ConnectionState.Open)
                    {
                        DMEEditor.Logger.WriteLog($"Could not Find DataView File " + DataSourceName);
                    }
                    else
                    {
                        bool loadv = false;
                        if (ChildBranchs.Count > 0)
                        {
                            if (Visutil.Controlmanager.InputBoxYesNo("Beep", "Do you want to over write th existing View Structure?") ==BeepEnterprize.Vis.Module.DialogResult.Yes)
                            {
                                TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                                ds.LoadView();
                                loadv = true;
                            }
                        }
                        else
                        {
                            if (DataView.Entities != null)
                            {
                                if (DataView.Entities.Count== 0)
                                {
                                    ds.LoadView();
                                }
                            }
                          
                            loadv = true;
                        }
                        if (loadv)
                        {
                            // ds.Dataview;// DMEEditor.viewEditor.Views[DMEEditor.viewEditor.ViewListIndex(DataView.id)];
                            if (ds != null)
                            {
                                if (DataView != null)
                                {
                                  //  TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                                    List<EntityStructure> cr = DataView.Entities.Where(cx => cx.ParentId == 0).ToList();
                                    int i = 0;
                                //    TreeEditor.ShowWaiting();
                                 //   TreeEditor.ChangeWaitingCaption($"Getting  DataView Entities Total:{DataView.Entities.Count}");
                                    foreach (EntityStructure tb in cr)
                                    {

                                        DataViewEntitiesNode dbent = new DataViewEntitiesNode(TreeEditor, DMEEditor, this, tb.EntityName, TreeEditor.SeqID, EnumPointType.Entity, ds.GeticonForViewType(tb.Viewtype), DataView.DataViewDataSourceID, tb);
                                        if (string.IsNullOrEmpty(tb.DatasourceEntityName))
                                        {
                                            DataView.Entities[ds.EntityListIndex(tb.EntityName)].DatasourceEntityName = tb.EntityName;
                                        }
                                        dbent.ID = tb.Id;
                                  //      TreeEditor.AddCommentsWaiting($"{i} - Added Main Entity {tb.EntityName} ");
                                        TreeEditor.treeBranchHandler.AddBranch(this, dbent);
                                        dbent.CreateChildNodes();
                                   //     TreeEditor.AddCommentsWaiting($"{i} - Added Child Branch for Entity {tb.EntityName} ");
                                        ChildBranchs.Add(dbent);
                                        i += 1;

                                    }
                               //     TreeEditor.HideWaiting();
                                    ds.WriteDataViewFile(DataSourceName);

                                    DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new DatasourceEntities { datasourcename = DataSourceName, Entities = DataView.Entities });
                                }

                            }
                            else
                            {
                                DMEEditor.Logger.WriteLog($"Could not Find Datasource File " + DataSourceName);
                            }
                            SaveView();
                        }
                  
                    }
                }else
                {
                    DMEEditor.Logger.WriteLog($"Could not Find DataView File " + DataSourceName);
                }
               


            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Filling DataView Entites ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Caption = "Save", iconimage = "save.ico")]
        public IErrorsInfo SaveView()
        {

            try
            {
                DMEEditor.ConfigEditor.SaveDataconnectionsValues();
               // ds.Dataview=DataView;
                ds.WriteDataViewFile(DataSourceName);
           
                DMEEditor.AddLogMessage("Success", "Saved View", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Save View";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Caption = "Remove", iconimage = "remove.ico")]
        public IErrorsInfo RemoveView()
        {

            try
            {
                if (Visutil.Controlmanager.InputBoxYesNo("Remove View", "Area you Sure ? you want to remove View???") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                {
                    ConnectionProperties cn = DMEEditor.ConfigEditor.DataConnections.Where(x => x.ConnectionName.Equals(Path.GetFileName(DataSourceName),StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    string file = Path.Combine(cn.FilePath, cn.FileName);
                    try
                    {

                      //ds.RemoveDataViewByVID(DataView.VID);
                        DMEEditor.ConfigEditor.RemoveDataConnection(DataSourceName);
                        DMEEditor.RemoveDataDource(DataSourceName);
                      
                        DMEEditor.AddLogMessage("Success", "Removed View from Views List", DateTime.Now, 0, null, Errors.Ok);
                    }
                    catch (Exception ex)
                    {
                        string mes = "Could not Remove View from Views List";
                        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
                    };

                    try
                    {

                        DMEEditor.DataSources.Remove(DMEEditor.DataSources.Where(x => x.DatasourceName.Equals(DataSourceName,StringComparison.OrdinalIgnoreCase)).FirstOrDefault());
                        DMEEditor.AddLogMessage("Success", "Removed View from DataSource List", DateTime.Now, 0, null, Errors.Ok);
                    }
                    catch (Exception ex)
                    {
                        string mes = "Could not Removed View from DataSource List";
                        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
                    };

                    if (Visutil.Controlmanager.InputBoxYesNo("Remove View", "Do you want to Delete the View File ???") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                    {
                      
                        File.Delete(file);
                    }
                    TreeEditor.treeBranchHandler.RemoveBranch(this);

                }

                DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                DMEEditor.AddLogMessage("Success", "Remove View", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Remove View";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
      //  [CommandAttribute(Caption = "Create Entity", iconimage = "add.ico")]
        //public IErrorsInfo CreateEntity()
        //{

        //    try
        //    {
        //        string[] args = { "New Query Entity", null, null };
        //        List<ObjectItem> ob = new List<ObjectItem>(); ;
        //        ObjectItem it = new ObjectItem();
        //        it.obj = this;
        //        it.Name = "Branch";
        //        ob.Add(it);
                
        //        PassedArgs Passedarguments = new PassedArgs
        //        {
        //            Addin = null,
        //            AddinName = null,
        //            AddinType = "",
        //            DMView = DataView,
        //            CurrentEntity = null,
        //            Id = DataView.Entities[0].Id,
        //            ObjectType = "NEWENTITY",
        //            DataSource = ds,
        //            ObjectName = DataView.ViewName,
                    
        //            Objects = ob,
                   
        //            DatasourceName = ds.DatasourceName,
        //            EventType = "NEWENTITY"

        //        };
        //        //ActionNeeded?.Invoke(this, Passedarguments);
        //        Visutil.ShowPage("Uc_DataViewEntityEditor", Passedarguments);

        //        DMEEditor.AddLogMessage("Success", "Created Query Entity", DateTime.Now, 0, null, Errors.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Create Query Entity";
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
        //[CommandAttribute(Caption = "Create Composed Layer", iconimage = "localdb.ico")]
        public IErrorsInfo CreateComposedLayer()
        {

            try
            {
                string[] args = { "New Query Entity", null, null };
                List<ObjectItem> ob = new List<ObjectItem>(); ;
                ObjectItem it = new ObjectItem();
                it.obj = this;
                it.Name = "Branch";
                ob.Add(it);
                IBranch RootCompositeLayerBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "CLAYER" && x.BranchType == EnumPointType.Root)];
                it = new ObjectItem();
                it.obj = RootCompositeLayerBranch;
                it.Name = "ParentBranch";
                ob.Add(it);
                PassedArgs Passedarguments = new PassedArgs
                {
                    Addin = null,
                    AddinName = null,
                    AddinType = "",
                    DMView = DataView,
                    CurrentEntity = null,
                    Id = DataView.Entities[0].Id,
                    ObjectType = "QUERYENTITY",
                    DataSource = ds,
                    ObjectName = DataView.ViewName,

                    Objects = ob,

                    DatasourceName = null,
                    EventType = "CLEARECOMPOSITELAYER"

                };
               // ActionNeeded?.Invoke(this, Passedarguments);
                Visutil.ShowPage("uc_CreateComposedLayerFromView", Passedarguments,DisplayType.Popup);

               // DMEEditor.AddLogMessage("Success", "Created Query Entity", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Create Query Entity";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        //[CommandAttribute(Caption = "Create App", iconimage = "localdb.ico"))]
        //public IErrorsInfo CreateApp()
        //{

        //    try
        //    {
        //        string[] args = { "New Query Entity", null, null };
        //        List<ObjectItem> ob = new List<ObjectItem>(); ;
        //        ObjectItem it = new ObjectItem();
        //        it.obj = this;
        //        it.Name = "Branch";
        //        ob.Add(it);
        //        IBranch RootCompositeLayerBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "APP" && x.BranchType == EnumPointType.Root)];
        //        it = new ObjectItem();
        //        it.obj = RootCompositeLayerBranch;
        //        it.Name = "RootAppBranch";
        //        ob.Add(it);
        //        PassedArgs Passedarguments = new PassedArgs
        //        {
        //            Addin = null,
        //            AddinName = null,
        //            AddinType = "",
        //            DMView = DataView,
        //            CurrentEntity = null,
        //            Id = DataView.Entities[0].Id,
        //            ObjectType = "QUERYENTITY",
        //            DataSource = ds,
        //            ObjectName = DataView.ViewName,

        //            Objects = ob,

        //            DatasourceName = null,
        //            EventType = "CREATAPP"

        //        };
        //        // ActionNeeded?.Invoke(this, Passedarguments);
        //        Visutil.ShowPage("uc_App", Passedarguments);

        //        DMEEditor.AddLogMessage("Success", "Created Query Entity", DateTime.Now, 0, null, Errors.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Create Query Entity";
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
        //[BranchDelegate(Caption = "Add Child Entity From IDataSource", Hidden = true)]
        //public IErrorsInfo AddChildEntityFromIDataSource()
        //{

        //    try
        //    {

        //        if (TreeEditor.args.Objects != null)
        //        {
        //            IBranch branchentity = (IBranch)TreeEditor.args.Objects.Where(x => x.Name == "ChildBranch").FirstOrDefault().obj;
        //            IDataSource childds = DMEEditor.GetDataSource(branchentity.DataSource.DatasourceName);
        //            if (childds != null)
        //            {
        //                EntityStructure entity = childds.GetEntityStructure(branchentity.BranchText, true);

        //                if (entity != null)
        //                {
        //                   // EntityStructure CurEntity = childds.GetEntityStructure(BranchText, true);
        //                    EntityStructure newentity = new EntityStructure();
        //                    newentity.Id = ds.NextHearId();
        //                    newentity.ParentId = 1;
        //                    newentity.ViewID = DataView.ViewID;
        //                    newentity.Viewtype = entity.Viewtype;
        //                    newentity.Relations = entity.Relations;
        //                    newentity.PrimaryKeys = entity.PrimaryKeys;
        //                    newentity.EntityName = entity.EntityName;
        //                    newentity.Fields = entity.Fields;
        //                    newentity.DataSourceID = entity.DataSourceID;
        //                    newentity.DatabaseType = entity.DatabaseType;
        //                    newentity.SchemaOrOwnerOrDatabase = entity.SchemaOrOwnerOrDatabase;
        //                    newentity.Created = false;
                          
        //                    ds.CreateEntityAs(newentity);

        //                    DataViewEntitiesNode dbent = new DataViewEntitiesNode(TreeEditor, DMEEditor, this, newentity.EntityName, TreeEditor.SeqID, EnumBranchType.Entity, "entity.ico", DataView.DataViewDataSourceID, newentity);

        //                    TreeEditor.treeBranchHandler.AddBranch(this, dbent);
        //                    dbent.CreateChildNodes();
        //                    ChildBranchs.Add(dbent);
        //                }
        //            }

        //        }



        //        DMEEditor.AddLogMessage("Success", "Created Query Entity", DateTime.Now, 0, null, Errors.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Create Query Entity";
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
      
        [CommandAttribute(Caption = "Clear View")]
        public IErrorsInfo ClearView()
        {

            try
            {
                // IBranch pbr = TreeEditor.Branches.Where(x => x.BranchType == EnumBranchType.Root && x.BranchClass == "VIEW").FirstOrDefault();
                //
                ds = (DataViewDataSource)DMEEditor.GetDataSource(DataSourceName);

                DMEEditor.OpenDataSource(DataSourceName);
                if (ds != null)
                {
                    DMEEditor.OpenDataSource(DataSourceName);
                  //  ds.Dataconnection.OpenConnection();
                    ds.Entities.Clear();
                    DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                    // ds.Dataview=DataView;
                    ds.WriteDataViewFile(DataSourceName);

                }
            }
            catch (Exception ex)
            {
                string mes = "Could not Added Entity ";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion Exposed Interface"
        #region "Other Methods"
        public IErrorsInfo GetFile()
        {

            try
            {


                DMEEditor.AddLogMessage("Success", "Loaded File", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Load File";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion"Other Methods"
    }
}
