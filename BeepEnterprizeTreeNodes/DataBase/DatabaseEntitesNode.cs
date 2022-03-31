using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace  BeepEnterprize.Vis.Module
{
    public class DatabaseEntitesNode  : IBranch 
    {
        public DatabaseEntitesNode()
        {

        }
        public DatabaseEntitesNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename,IDataSource ds)
        {
            DataSource = ds;
            TreeEditor = pTreeEditor;
            DMEEditor = pDMEEditor;
            ParentBranchID = pParentNode.ID;
            BranchText = pBranchText;
            BranchType =  EnumPointType.Entity;
            IconImageName = pimagename;
            EntityStructure = new EntityStructure();
            EntityStructure.DataSourceID = ds.DatasourceName;
            EntityStructure.Viewtype = ViewType.Table;
            EntityStructure.EntityName = pBranchText;
            DataSourceName = ds.DatasourceName;

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
        public string BranchClass { get; set; } = "RDBMS";
        public List<IBranch> ChildBranchs { get ; set ; }
        public ITree TreeEditor { get ; set ; }
        public List<string> BranchActions { get ; set ; }
        public object TreeStrucure { get ; set ; }
        public  IVisManager  Visutil  { get ; set ; }
        public int MiscID { get; set; }
       
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
       
        [CommandAttribute(Caption = "Data Edit",iconimage = "edit_entity.ico")]
        public IErrorsInfo DataEdit()
        {

            try
            {
                List<ObjectItem> ob = new List<ObjectItem>(); ;
                ObjectItem it = new ObjectItem();
                it.obj = this;
                it.Name = "Branch";
                ob.Add(it);
                string[] args = new string[] { BranchText, DataSource.Dataconnection.ConnectionProp.SchemaName, null };
                PassedArgs Passedarguments = new PassedArgs
                {
                    Addin = null,
                    AddinName = null,
                    AddinType = "",
                    DMView = null,
                    CurrentEntity = BranchText,
                    Id = BranchID,
                    ObjectType = "RDBMSTABLE",
                    DataSource = DataSource,
                    ObjectName = BranchText,
                    Objects = ob,
                    DatasourceName = DataSource.DatasourceName,
                    EventType = "CRUDENTITY"

                };
             

                 Visutil.ShowPage("crudmanager",   Passedarguments);



              //  DMEEditor.AddLogMessage("Success", "Added Database Connection", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Create CRUD GRID";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Create View", iconimage = "createentity.ico"),]
        public IErrorsInfo CreateView()
        {
           
            try
            {
                PassedArgs args = new PassedArgs
                {
                    ObjectName = "DATABASE",
                    ObjectType = "TABLE",
                    EventType="CREATEVIEWBASEDONTABLE",
                    ParameterString1 = "Create View using Table",
                    Objects = new List<ObjectItem> { new ObjectItem { Name = "Branch", obj = this } }
                };
                DMEEditor.Passedarguments = args;
                IBranch pbr = TreeEditor.Branches.Where(x => x.BranchType == EnumPointType.Root && x.BranchClass == "VIEW").FirstOrDefault();
                TreeEditor.treeBranchHandler.SendActionFromBranchToBranch(pbr,this, "Create View using Table");

            }
            catch (Exception ex)
            {
                string mes = "Could not Added View ";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        //[BranchDelegate(Caption = "Copy Entity")]
        //public IErrorsInfo CopyEntity()
        //{

        //    try
        //    {
        //        // IBranch pbr = TreeEditor.Branches.Where(x => x.BranchType == EnumBranchType.Root && x.BranchClass == "VIEW").FirstOrDefault();
              
        //        EntityStructure = DataSource.GetEntityStructure(BranchText,true);
                
        //        PassedArgs args = new PassedArgs
        //        {
        //            ObjectName = "DATABASE",
        //            ObjectType = "TABLE",
        //            EventType = "COPYENTITY",
        //            ParameterString1 = "COPYENTITY",
        //            DataSource=DataSource,
        //            DatasourceName=DataSource.DatasourceName,
        //            CurrentEntity=BranchText,
        //            Objects = new List<ObjectItem> { new ObjectItem { Name = "Branch", obj = this }, new ObjectItem { Name = "Entity", obj = EntityStructure } }
        //        };
        //        TreeEditor.args = args;
               
        //       // TreeEditor.SendActionFromBranchToBranch(pbr, this, "Create View using Table");

        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Copy entites ";
        //        DMEEditor.AddLogMessage("Fail", mes + ex.Message, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
     
        [CommandAttribute(Caption = "View Structure", Hidden = false, iconimage = "structure.ico")]
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
        [CommandAttribute(Caption = "Field Properties", iconimage = "properties.ico")]
        public IErrorsInfo FieldProperties()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //   DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
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
                    Id = 0,
                    ObjectType = "DEFAULTS",
                    DataSource = null,
                    ObjectName = DataSourceName,

                    Objects = ob,

                    DatasourceName = DataSourceName,
                    EventType = "DEFAULTS"

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
        [CommandAttribute(Caption = "Drop", iconimage = "remove.ico")]
        public IErrorsInfo DropEntity()
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            bool entityexist = true;
            try
            {
              if(Visutil.Controlmanager.InputBoxYesNo("Beep DM","Are you sure you ?")== DialogResult.Yes)
                {
                   
                    EntityStructure = DataSource.GetEntityStructure(BranchText, true);
                    if (EntityStructure!=null) 
                    {
                        entityexist = DataSource.Entities[DataSource.GetEntityIdx(EntityStructure.EntityName)].Created;
                        if (entityexist && DataSource.CheckEntityExist(EntityStructure.EntityName))
                        {
                            DataSource.ExecuteSql($"Drop Table {EntityStructure.DatasourceEntityName}");
                        }
                        if (DMEEditor.ErrorObject.Flag == Errors.Ok|| !entityexist)
                        {
                            TreeEditor.treeBranchHandler.RemoveBranch(this);
                            DataSource.Entities.RemoveAt(DataSource.Entities.FindIndex(p => p.DatasourceEntityName == EntityStructure.DatasourceEntityName));
                            DMEEditor.AddLogMessage("Success", $"Droped Entity {EntityStructure.EntityName}", DateTime.Now, -1, null, Errors.Ok);
                        }
                        else
                        {

                            DMEEditor.AddLogMessage("Fail", $"Error Drpping Entity {EntityStructure.EntityName} - {DMEEditor.ErrorObject.Message}", DateTime.Now, -1, null, Errors.Failed);
                        }
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
