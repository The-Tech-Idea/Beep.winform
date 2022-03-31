using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace  BeepEnterprize.Vis.Module
{
    public class DataViewRootNode  : IBranch ,IOrder,IBranchRootCategory
    {
        public DataViewRootNode()
        {

        }
        public DataViewRootNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename)
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
            //.GetImageIndex(ParentTree, MainNode, "dataview.ico");
        }
        #region "Properties"
        public int ID { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public int Order { get; set; } = 0;
        public string Name { get; set; }
        public string BranchText { get; set; } = "DataView";
        public IDMEEditor DMEEditor { get; set; }
        public IDataSource DataSource { get; set; }
        public string DataSourceName { get; set; }
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; }= EnumPointType.Root;
        public int BranchID { get; set; }
        public string IconImageName { get; set; } = "dataview.ico";
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

       // public event EventHandler<PassedArgs> BranchSelected;
       // public event EventHandler<PassedArgs> BranchDragEnter;
       // public event EventHandler<PassedArgs> BranchDragDrop;
       // public event EventHandler<PassedArgs> BranchDragLeave;
       // public event EventHandler<PassedArgs> BranchDragClick;
       // public event EventHandler<PassedArgs> BranchDragDoubleClick;
       // public event EventHandler<PassedArgs> ActionNeeded;

        public IDMDataView DataView { get; set; }
        public int DataViewID { get; set; }

        #endregion "Properties"
        #region "Interface Methods"
        public IErrorsInfo CreateChildNodes()
        {

            try
            {
                TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                foreach (ConnectionProperties i in DMEEditor.ConfigEditor.DataConnections.Where(c => c.Category == DatasourceCategory.VIEWS))
                {

                    if (TreeEditor.treeBranchHandler.CheckifBranchExistinCategory(i.ConnectionName, "VIEW") == null)
                    {
                        // ObjectDataSourcetemp = i.FileName;

                        CreateViewNode(i.ID,i.FileName, i.ConnectionName);

                        i.Drawn = true;
                    }
                }
                foreach (CategoryFolder i in DMEEditor.ConfigEditor.CategoryFolders.Where(x => x.RootName == "VIEW"))
                {

                    CreateCategoryNode(i);


                }

                //  DMEEditor.AddLogMessage("Success", "Added Database Connection", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Add Views";
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
                    ID = pID;
                }

            //    DMEEditor.AddLogMessage("Success", "Set Config OK", DateTime.Now, 0, null, Errors.Ok);
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
        [CommandAttribute(Caption = "Add Category")]
        public IErrorsInfo AddCategory()
        {

            try
            {
                TreeEditor.treeBranchHandler.AddCategory(this);
            }
            catch (Exception ex)
            {
                string mes = "Could not Add Category";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Create View")]
        public IErrorsInfo CreateView()
        {

            try
            {
                string viewname = null;
                string fullname = null;
                if (Visutil.Controlmanager.InputBox("Create View", "Please Enter Name of View (Name Should not exist already in Views)", ref viewname) == BeepEnterprize.Vis.Module.DialogResult.OK)
                {
                    if ((viewname != null) && DMEEditor.ConfigEditor.DataConnectionExist(viewname+".json")==false )
                    {
                       
                        
                        fullname = Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(x => x.FolderFilesType == FolderFileTypes.DataView).FirstOrDefault().FolderPath, viewname + ".json");
                        ConnectionProperties f = new ConnectionProperties
                        {

                            FileName = Path.GetFileName(fullname),
                            FilePath = Path.GetDirectoryName(fullname),
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
                        DataView = ds.DataView;
                        ds.WriteDataViewFile(fullname);
                        IBranch br = CreateViewNode(DataView.ViewID, DataView.ViewName, f.ConnectionName);
                        DMEEditor.AddLogMessage("Success", "Added View", DateTime.Now, 0, null, Errors.Ok);

                    }
                    else
                    {
                        //MessageBox.Show("Please Select Other Name, Data Connection by this name Exist");
                    }
                  
                }
                else
                {
                    Visutil.Controlmanager.MsgBox("DM Engine", "Please Try another name . DataSource Exist");
                }

            }
            catch (Exception ex)
            {
                string mes = "Could not Added View ";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Add View File")]
        public IErrorsInfo AddViewFile()
        {

            try
            {
                string viewname = null;
                string fullname = null;
               
                string filename = Visutil.Controlmanager.LoadFileDialog("json", DMEEditor.ConfigEditor.Config.Folders.Where(i => i.FolderFilesType == FolderFileTypes.DataView).FirstOrDefault().FolderPath, "json files (*.json)|*.txt|All files (*.*)|*.*");
                if (filename != null)
                {
                    viewname = Path.GetFileName(filename);
                    if ((viewname != null) && DMEEditor.ConfigEditor.DataConnectionExist(viewname+".json") == false)
                    {


                        fullname = filename;  //Path.Combine(Path.GetDirectoryName(openFileDialog1.FileName), Path.GetFileName(openFileDialog1.FileName));
                        ConnectionProperties f = new ConnectionProperties
                        {

                            FileName = Path.GetFileName(fullname),
                            FilePath = Path.GetDirectoryName(fullname),
                            Ext = Path.GetExtension(fullname),
                            ConnectionName = Path.GetFileName(fullname)
                        };

                        f.Category = DatasourceCategory.VIEWS;
                        f.DriverVersion = "1";
                        f.DriverName = "DataViewReader";

                        DMEEditor.ConfigEditor.DataConnections.Add(f);
                        DMEEditor.ConfigEditor.SaveDataconnectionsValues();

                        DataViewDataSource ds = (DataViewDataSource)DMEEditor.GetDataSource(f.ConnectionName);

                        DataSource = DMEEditor.GetDataSource(f.ConnectionName);
                        DataView = ds.DataView;
                      

                        ds.WriteDataViewFile(fullname);
                        CreateViewNode(DataView.ViewID, DataView.ViewName, f.ConnectionName);


                    }
                    DMEEditor.AddLogMessage("Success", "Added View", DateTime.Now, 0, null, Errors.Ok);
                }
                else
                {
                    Visutil.Controlmanager.MsgBox("DM Engine", "Please Try another name . DataSource Exist");
                }

            }
            catch (Exception ex)
            {
                string mes = "Could not Added View ";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Create View using Table",Hidden =true)]
        public IErrorsInfo CreateView(IBranch EntitySource)
        {

            try
            {
                string viewname = null;
                string fullname = null;
                if (Visutil.Controlmanager.InputBox("Create View", "Please Enter Name of View (Name Should not exist already in Views)", ref viewname) == BeepEnterprize.Vis.Module.DialogResult.OK)
                {
                    if ((viewname != null) && DMEEditor.ConfigEditor.DataConnectionExist(viewname+".json") == false)
                    {


                        fullname = Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(x => x.FolderFilesType == FolderFileTypes.DataView).FirstOrDefault().FolderPath, viewname + ".json");
                        ConnectionProperties f = new ConnectionProperties
                        {

                            FileName = Path.GetFileName(fullname),
                            FilePath = Path.GetDirectoryName(fullname),
                            Ext = Path.GetExtension(fullname),
                            ConnectionName = Path.GetFileName(fullname)
                        };

                        f.Category = DatasourceCategory.VIEWS;
                        f.DriverVersion = "1";
                        f.DriverName = "DataViewReader";

                        DMEEditor.ConfigEditor.DataConnections.Add(f);
                        DataViewDataSource ds = (DataViewDataSource)DMEEditor.GetDataSource(f.ConnectionName);
                       
                        if (EntitySource != null)
                        {
                           
                            int x = ds.AddEntitytoDataView(EntitySource.DataSource, EntitySource.BranchText, EntitySource.DataSource.Dataconnection.ConnectionProp.SchemaName, null);
                       
                        }
                        ds.WriteDataViewFile(fullname);
                        DataSource = DMEEditor.GetDataSource(f.ConnectionName);
                        DataView = ds.DataView;
                        DataView.EntityDataSourceID = EntitySource.DataSource.DatasourceName;
                        IBranch br = CreateViewNode(DataView.ViewID, DataView.ViewName, f.ConnectionName);


                        if (EntitySource != null)
                        {
                           
                          //  int x = DMEEditor.viewEditor.AddEntitytoDataView(EntitySource.DataSource, EntitySource.BranchText, EntitySource.DataSource.Dataconnection.ConnectionProp.SchemaName, null, DataView.id);
                            br.CreateChildNodes();
                        }
                      
                        // IBranch br = TreeEditor.treeBranchHandler.GetBranch(DataView.ViewName);



                    }
                    DMEEditor.AddLogMessage("Success", "Added View", DateTime.Now, 0, null, Errors.Ok);
                }
                else
                {
                    Visutil.Controlmanager.MsgBox("DM Engine", "Please Try another name . DataSource Exist");
                }

            }
            catch (Exception ex)
            {
                string mes = "Could not Added View ";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion Exposed Interface"
        #region "Other Methods"
        private IBranch CreateViewNode(int id, string ViewName,string Connectionname)
        {
            DataViewNode viewbr = null;
            try
            {

                viewbr = new DataViewNode(TreeEditor, DMEEditor, this, ViewName, TreeEditor.SeqID, EnumPointType.DataPoint, "dataview.ico", Connectionname);
            
               // viewbr.DataSource = DataSource;
                viewbr.DataSourceName = Connectionname;
                viewbr.ID = id;

                TreeEditor.treeBranchHandler.AddBranch(this, viewbr);
              
                ChildBranchs.Add(viewbr);

                DMEEditor.AddLogMessage("Success", "Added DataView Connection", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Add DataView Connection";
                viewbr = null;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };

            return viewbr;
        }
        public IErrorsInfo CreateCategoryNode(CategoryFolder p)
    {
        try
        {
                DataViewCategoryNode categoryBranch = new DataViewCategoryNode(TreeEditor, DMEEditor,this, p.FolderName, TreeEditor.SeqID, EnumPointType.Category, "category.ico");
                TreeEditor.treeBranchHandler.AddBranch(this, categoryBranch);
                ChildBranchs.Add(categoryBranch);
                categoryBranch.CreateChildNodes();

         
        }
        catch (Exception ex)
        {
                DMEEditor.Logger.WriteLog($"Error Creating Category  View Node ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
        }
        return DMEEditor.ErrorObject;

    }
        #endregion

}
}
