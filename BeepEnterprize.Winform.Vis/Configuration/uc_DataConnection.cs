using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;

using TheTechIdea.Beep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TheTechIdea.Util;
using TheTechIdea;

using TheTechIdea.Beep.Vis;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using TheTechIdea.Beep.Addin;
//using TheTechIdea.Beep.ViewModels;

namespace BeepEnterprize.Winform.Vis
{
    [AddinAttribute(Caption = "DataConnection Configuration", Name = "uc_DataConnection", misc = "Config", menu = "Configuration", displayType = DisplayType.Popup, addinType = AddinType.Control)]
    [AddinVisSchema(BranchID = 1, RootNodeName = "Configuration", Order = 1, ID = 1, BranchText = "Connection Manager", BranchType = EnumPointType.Function, IconImageName = "createentity.ico", BranchClass = "ADDIN", BranchDescription = "Data Sources Connection Drivers Setup Screen")]
    public partial class uc_DataConnection : UserControl ,IDM_Addin, IAddinVisSchema
    {
        public uc_DataConnection()
        {
            InitializeComponent();
        }
        public string AddinName { get; set; } = "RDBMS Data Connection Manager";
        public string Description { get; set; } = "RDBMS Data Connection Manager";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public string DllName { get; set; }
        public string DllPath { get; set; }
        public string NameSpace { get; set; }
        public string ParentName { get; set; }
        public Boolean DefaultCreate { get; set; } = true;
        public IRDBSource DestConnection { get; set; }
        public DataSet Dset { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IRDBSource SourceConnection { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        public IUtil util { get; set; }
        public VisManager Visutil { get; set; }
        public IDMEEditor DMEEditor { get; set; }
       // DataConnectionViewModel viewModel;
        #region "IAddinVisSchema"
        public string RootNodeName { get; set; } = "Configuration";
        public string CatgoryName { get; set; }
        public int Order { get; set; } = 1;
        public int ID { get; set; } = 1;
        public string BranchText { get; set; } = "Connection Manager";
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Entity;
        public int BranchID { get; set; } = 1;
        public string IconImageName { get; set; } = "connections.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; } = "";
        public string BranchClass { get; set; } = "ADDIN";
        #endregion "IAddinVisSchema"
        string DataSourceCategoryType =DatasourceCategory.RDBMS.ToString();

        TreeControl tree;
        IBranch branch;
        List<ConnectionProperties> ds { get; set; }= new List<ConnectionProperties>();
       // public event EventHandler<PassedArgs> OnObjectSelected;

        public void RaiseObjectSelected()
        {

        }

        public void Run(IPassedArgs pPassedarg)
        {

        }

        public void SetConfig(IDMEEditor pDMEEditor, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs obj, IErrorsInfo per)
        {
            Passedarg = obj;
            Visutil = (VisManager)obj.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            Logger = plogger;
            DMEEditor = pDMEEditor;
       //     DataSourceCategoryType = args[0];
            ErrorObject = per;
            tree = (TreeControl)Visutil.Tree;
            if (tree != null)
            {
                branch = tree.Branches[tree.Branches.FindIndex(x => x.BranchClass == "RDBMS" && x.BranchType == EnumPointType.Root)];
            }
            else
                branch = null;
           

            foreach (var item in Enum.GetValues(typeof(DataSourceType)))
            {
                databaseTypeComboBox.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(DatasourceCategory)))
            {
                CategorycomboBox.Items.Add(item);
                var it=DatasourceCategorycomboBox.Items.Add(item);
                
            }
            foreach (var item in DMEEditor.ConfigEditor.DataDriversClasses)
            {
                try
                {if (!string.IsNullOrEmpty(item.PackageName))
                    {
                        driverNameComboBox.Items.Add(item.PackageName);
                    }
                    
                  
                }
                catch (Exception ex)
                {

                    Logger.WriteLog($"Error for Database connection  :{ex.Message}");
                }
             
            }
            try
            {
                foreach (var item in DMEEditor.ConfigEditor.DataDriversClasses)
                {
                    if (!string.IsNullOrEmpty(item.PackageName))
                    {
                        driverVersionComboBox.Items.Add(item.version);
                    }
                }
            }
            catch (Exception ex)
            {

               
            }
            
            //util.ConfigEditor.LoadDataConnectionsValues();
            dataConnectionsBindingSource.DataSource = null;
            ds =DMEEditor.ConfigEditor.DataConnections.Where(x=>x.Category==DatasourceCategory.RDBMS).ToList();

            //if (ds.FirstOrDefault() == null)
            //{
            //    ConnectionProperties x = new ConnectionProperties();
            //    x.Category = DatasourceCategory.RDBMS;
            //    x.ID = DMEEditor.ConfigEditor.DataConnections.Count + 1;
            //    DMEEditor.ConfigEditor.DataConnections.Add(x);

            //}
            if (ds == null)
            {
                ds = new List<ConnectionProperties>();
            }
            dataConnectionsBindingSource.DataSource = ds;
        //    headersBindingSource.DataSource = ds;
            // dataConnectionsBindingSource.ResetBindings(true);
            dataConnectionsBindingSource.AddingNew += DataConnectionsBindingSource_AddingNew;
         
            dataConnectionsBindingSource.AllowNew = true;
           // headersBindingSource.AllowNew = true;
          //  entitiesBindingSource.AddingNew += EntitiesBindingSource_AddingNew;
          //  headersBindingSource.AddingNew += HeadersBindingSource_AddingNew;
           // this.dataConnectionsBindingNavigatorSaveItem.Click += DataConnectionsBindingNavigatorSaveItem_Click;
            driverNameComboBox.SelectedValueChanged += DriverNameComboBox_SelectedValueChanged;
            DatasourceCategorycomboBox.SelectedValueChanged += DatasourceCategorycomboBox_SelectedValueChanged;
            this.Headesbutton.Click += Headesbutton_Click;
            this.Querybutton.Click += Querybutton_Click;
            uc_bindingNavigator1.bindingSource = dataConnectionsBindingSource;
            uc_bindingNavigator1.SaveCalled += Uc_bindingNavigator1_SaveCalled;
            uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, obj, DMEEditor.ErrorObject);
            uc_bindingNavigator1.HightlightColor = Color.Yellow;

        }

        private void Uc_bindingNavigator1_SaveCalled(object sender, BindingSource e)
        {
            ErrorObject.Flag = Errors.Ok;
            try

            {

                dataConnectionsBindingSource.EndEdit();

                ds = (List<ConnectionProperties>)dataConnectionsBindingSource.DataSource;
                foreach (var item in ds)
                {
                    DMEEditor.ConfigEditor.UpdateDataConnection(item, DataSourceCategoryType);
                }
                
                DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                if (branch != null)
                {
                    branch.CreateChildNodes();

                }

                MessageBox.Show("Changes Saved Successfuly", "Beep");
            }
            catch (Exception ex)
            {

                ErrorObject.Flag = Errors.Failed;
                MessageBox.Show("Error Saving Database connection", "Beep");
                ErrorObject.Message = $"Error saving Data for Database connection:{ex.Message}";
                Logger.WriteLog($"Error saving Data for Database connection  :{ex.Message}");
            }
        }

        private void Querybutton_Click(object sender, EventArgs e)
        {
            string[] args = { "New Query Entity", null, null };
            PassedArgs Passedarguments = new PassedArgs
            {
                Addin = null,
                AddinName = null,
                AddinType = "",
                DMView = null,
                CurrentEntity = null,

                ObjectType = "DATACONNECTION",
                DataSource = null,
                ObjectName = this.connectionNameTextBox.Text,

                Objects = null,

                DatasourceName = this.connectionNameTextBox.Text,
                EventType = "WEBAPIQUERY"

            };
            //   ActionNeeded?.Invoke(this, Passedarguments);
            Visutil.ShowUserControlPopUp("uc_webapiQueryParameters", DMEEditor, args, Passedarguments);

        }

        private void Headesbutton_Click(object sender, EventArgs e)
        {
            string[] args = { "New Query Entity", null, null };
            PassedArgs Passedarguments = new PassedArgs
            {
                Addin = null,
                AddinName = null,
                AddinType = "",
                DMView = null,
                CurrentEntity = null,

                ObjectType = "DATACONNECTION",
                DataSource = null,
                ObjectName = this.connectionNameTextBox.Text,
                
                Objects = null,

                DatasourceName = this.connectionNameTextBox.Text,
                EventType = "WEBAPIQUERY"

            };
            //   ActionNeeded?.Invoke(this, Passedarguments);
            Visutil.ShowUserControlPopUp("uc_webapiHeaders", DMEEditor, args, Passedarguments);
        }

        private void DatasourceCategorycomboBox_SelectedValueChanged(object sender, EventArgs e)

        {
            foreach (var item in ds)
            {
                DMEEditor.ConfigEditor.UpdateDataConnection(item, DataSourceCategoryType);
            }
          
            DataSourceCategoryType = DatasourceCategorycomboBox.Text;
            ds = DMEEditor.ConfigEditor.DataConnections.Where(x => x.Category.ToString() == DataSourceCategoryType).ToList();
            dataConnectionsBindingSource.DataSource = ds;
            //headersBindingSource.DataSource = ds;
            // dataConnectionsBindingSource.ResetBindings(true);
        }

        private void DriverNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string pkname = driverNameComboBox.Text;
            driverVersionComboBox.Items.Clear();
            foreach (var item in DMEEditor.ConfigEditor.DataDriversClasses.Where(c => c.PackageName == pkname))
            {
                driverVersionComboBox.Items.Add(item.version);
            }
        }

        private void DataConnectionsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            ConnectionProperties x = new ConnectionProperties();
            x.Category = DatasourceCategory.RDBMS;
            if (DMEEditor.ConfigEditor.DataConnections.Count > 0)
            {
                x.ID =  DMEEditor.ConfigEditor.DataConnections.Max(y => y.ID) + 1;
            }
            else
                x.ID = 1;
          
            e.NewObject = x;
        }

       

    }
}
