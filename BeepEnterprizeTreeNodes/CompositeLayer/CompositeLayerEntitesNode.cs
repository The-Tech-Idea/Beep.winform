using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.CompositeLayer;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace  BeepEnterprize.Vis.Module
{
    public class CompositeLayerEntitesNode : IBranch 
    {
        public CompositeLayerEntitesNode()
        {

        }
        public CompositeLayerEntitesNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, EntityStructure entity, int pID, EnumPointType pBranchType, string pimagename,IDataSource ds)
        {
            DataSource = ds;
            TreeEditor = pTreeEditor;
            DMEEditor = pDMEEditor;
            ParentBranchID = pParentNode.ID;
            BranchText = entity.EntityName;
            BranchType =  EnumPointType.Entity;
            IconImageName = "databaseentities.ico";
            DataSource = ds;
            compositeLayerDataSource = (CompositeLayerDataSource)ds;
            DataSourceName = ds.DatasourceName;
            EntityStructure = entity;
            
            if (pID != 0)
            {
                ID = pID;
                BranchID = ID;
            }
        }
        public int ID { get ; set ; }
        public EntityStructure EntityStructure { get; set; }
        public int Order { get; set; }
        public string Name { get; set; } = "";
        public string BranchText { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public IDataSource DataSource { get ; set ; }
        public string DataSourceName { get; set; }
        public int Level { get ; set ; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Entity;
        public int BranchID { get ; set ; }
        public string IconImageName { get ; set ; }
        public string BranchStatus { get ; set ; }
        public int ParentBranchID { get ; set ; }
        public string BranchDescription { get ; set ; }
        public string BranchClass { get; set; } = "CLAYER";
        public List<IBranch> ChildBranchs { get ; set ; }
        public ITree TreeEditor { get ; set ; }
        public List<string> BranchActions { get ; set ; }
        public object TreeStrucure { get ; set ; }
        public  IVisManager  Visutil  { get ; set ; }

        
        public int MiscID { get; set; }
        public CompositeLayerDataSource compositeLayerDataSource { get; set; }
       // public event EventHandler<PassedArgs> BranchSelected;
       // public event EventHandler<PassedArgs> BranchDragEnter;
       // public event EventHandler<PassedArgs> BranchDragDrop;
       // public event EventHandler<PassedArgs> BranchDragLeave;
       // public event EventHandler<PassedArgs> BranchDragClick;
       // public event EventHandler<PassedArgs> BranchDragDoubleClick;
       // public event EventHandler<PassedArgs> ActionNeeded;

        public IErrorsInfo CreateChildNodes()
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

        #region "Methods"
        //[BranchDelegate(Caption = "Single Record CRUD")]
        //public IErrorsInfo CRUDSingleRecord()
        //{

        //    try
        //    {
        //        List<ObjectItem> ob = new List<ObjectItem>(); ;
        //        ObjectItem it = new ObjectItem();
        //        it.obj = this;
        //        it.Name = "Branch";
        //        ob.Add(it);
        //        string[] args = new string[] { BranchText, DataSource.Dataconnection.ConnectionProp.SchemaName, null };
        //        PassedArgs Passedarguments = new PassedArgs
        //        {
        //            Addin = null,
        //            AddinName = null,
        //            AddinType = "",
        //            DMView = null,
        //            CurrentEntity = BranchText,
        //            Id = BranchID,
        //            ObjectType = "RDBMSTABLE",
        //            DataSource = DataSource,
        //            ObjectName = BranchText,
        //            Objects = ob,
        //            DatasourceName = DataSource.DatasourceName,
        //            EventType = "CRUDENTITY"

        //        };
        //        //ActionNeeded?.Invoke(this, Passedarguments);

        //         Visutil.ShowPage("Uc_DataTableSingleRecordEdit",   DMEEditor, args, Passedarguments);


        //        DMEEditor.AddLogMessage("Success", "Created Crud Single Record", DateTime.Now, 0, null, Errors.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Create Crud Single Record";
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
      
        //[CommandAttribute(Caption = "Create View")]
        //public IErrorsInfo CreateView()
        //{
           
        //    try
        //    {
        //        PassedArgs args = new PassedArgs
        //        {
        //            ObjectName = "DATABASE",
        //            ObjectType = "TABLE",
        //            EventType="CREATEVIEWBASEDONTABLE",
        //             ParameterString1= "Create View using Table",
        //            Objects = new List<ObjectItem> { new ObjectItem { Name = "Branch", obj = this } }
        //        };
        //        DMEEditor.Passedarguments = args;
        //        IBranch pbr = TreeEditor.Branches.Where(x => x.BranchType == EnumPointType.Root && x.BranchClass == "VIEW").FirstOrDefault();
        //        TreeEditor.treeBranchHandler.SendActionFromBranchToBranch(pbr,this, "Create View using Table");

        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Added View ";
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
        [CommandAttribute(Caption = "View Structure", Hidden = false)]
        public IErrorsInfo ViewStructure()
        {

            try
            {
                string[] args = { "New View", null, null };
                List<ObjectItem> ob = new List<ObjectItem>(); ;
                ObjectItem it = new ObjectItem();
                it.obj = this;
                it.Name = "Branch";
                ob.Add(it);
                PassedArgs Passedarguments = new PassedArgs
                {
                    Addin = null,
                    AddinName = null,
                    AddinType = "",
                    DMView = null,
                    CurrentEntity = BranchText,
                    ParameterString1=EntityStructure.DatasourceEntityName,
                    ParameterString2 = EntityStructure.OriginalEntityName,
                    Id = BranchID,
                    ObjectType = "RDBMSENTITY",
                    DataSource = DataSource,
                    ObjectName = EntityStructure.DataSourceID,
                    Objects = ob,
                    DatasourceName = EntityStructure.DataSourceID,
                    EventType = "RDBMSENTITY"

                };
                //ActionNeeded?.Invoke(this, Passedarguments);
                Visutil.ShowPage("uc_DataEntityStructureViewer", Passedarguments);



                //  DMEEditor.AddLogMessage("Success", "Edit Control Shown", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not show Edit Control";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Field Properties")]
        public IErrorsInfo FieldProperties()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
          
            try
            {
                string[] args = { "New Query Entity", null, null };
                List<ObjectItem> ob = new List<ObjectItem>(); ;
                ObjectItem it = new ObjectItem();
                it.obj = this;
                it.Name = "Branch";
                ob.Add(it);
                PassedArgs Passedarguments = new PassedArgs
                {
                    Addin = null,
                    AddinName = null,
                    AddinType = "",
                    DMView = null,
                    CurrentEntity = BranchText,
                    Id = ID,
                    ObjectType = "ENTITY",
                    DataSource = DataSource,
                    ObjectName = DataSourceName,

                    Objects = ob,

                    DatasourceName = DataSourceName,
                    EventType = "ENTITY"

                };
                // ActionNeeded?.Invoke(this, Passedarguments);
                Visutil.ShowPage("uc_fieldproperty", Passedarguments);
            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in Filling Database Entites ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;

        }
        //[CommandAttribute(Caption = "Remove Entity")]
        //public IErrorsInfo RemoveEntity()
        //{

        //    try
        //    {
        //      //  compositeLayerDataSource.LayerInfo.Entities
        //        if (EntityStructure == null)
        //        {
        //            EntityStructure = compositeLayerDataSource.GetEntityStructure(BranchText, true);

        //        }
        //        if (EntityStructure != null)
        //        {
        //            if (EntityStructure.Created == false)
        //            {
        //                if (Visutil.Controlmanager.InputBoxYesNo("Remove Entity", "Area you Sure ? you want to remove Entity???") ==BeepEnterprize.Vis.Module.DialogResult.Yes)
        //                {
        //                    compositeLayerDataSource.LayerInfo.Entities.Remove(EntityStructure);
        //                    DMEEditor.ConfigEditor.SaveCompositeLayersValues();
        //                    TreeEditor.treeBranchHandler.RemoveBranch(this);

        //                }
        //            }
        //        }
               
               

        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Remove Entity ";
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
        [CommandAttribute(Caption = "Drop Entity")]
        public IErrorsInfo DropEntity()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;

            try
            {
                if (Visutil.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure you ?") ==BeepEnterprize.Vis.Module.DialogResult.Yes)
                {
                    EntityStructure = DataSource.GetEntityStructure(BranchText, true);
                    if (EntityStructure.Created)
                    {
                        DataSource.ExecuteSql($"Drop Table {EntityStructure.DatasourceEntityName}");
                    }
                    
                    
                    if (DMEEditor.ErrorObject.Flag == Errors.Ok)
                    {
                        TreeEditor.treeBranchHandler.RemoveBranch(this);
                        compositeLayerDataSource.Entities.RemoveAt(DataSource.Entities.FindIndex(p => p.DatasourceEntityName == EntityStructure.DatasourceEntityName));
                        DMEEditor.ConfigEditor.SaveCompositeLayersValues();
                        DMEEditor.AddLogMessage("Success", $"Droped Entity {EntityStructure.EntityName}", DateTime.Now, -1, null, Errors.Ok);
                    }
                    else
                    {
                        DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {EntityStructure.EntityName} - {DMEEditor.ErrorObject.Message}", DateTime.Now, -1, null, Errors.Failed);
                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {EntityStructure.EntityName} - {ex.Message}", DateTime.Now, -1, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
        #endregion
    }
}
