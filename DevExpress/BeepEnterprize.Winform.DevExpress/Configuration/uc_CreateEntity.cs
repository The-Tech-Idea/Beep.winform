using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Util;
using TheTechIdea;
using TheTechIdea.Beep.Vis;

namespace BeepEnterprize.Winform.Vis.Configuration
{
    [AddinAttribute(Caption = "Entity Creator", Name = "uc_CreateEntity", misc = "Config", menu = "null", addinType = AddinType.Control, displayType = DisplayType.Popup)]
    public partial class uc_CreateEntity : UserControl, IDM_Addin, IAddinVisSchema
    {
        public uc_CreateEntity()
        {
            InitializeComponent();
        }




        public string AddinName { get; set; } = "Entity Creator";
        public string Description { get; set; } = "Entity Creator for all DataSource's";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public string ParentName { get; set; }
        public Boolean DefaultCreate { get; set; } = true;
        public IDataSource DestConnection { get; set; }
        public IDataSource SourceConnection { get; set; }
        public DataSet Dset { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        #region "IAddinVisSchema"
        public string RootNodeName { get; set; } = "DDL";
        public string CatgoryName { get; set; }
        public int Order { get; set; } = 2;
        public int ID { get; set; } = 2;
        public string BranchText { get; set; } = "Entity Creator";
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Entity;
        public int BranchID { get; set; } = 2;
        public string IconImageName { get; set; } = "createentity.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; } = "";
        public string BranchClass { get; set; } = "DDL";
        #endregion "IAddinVisSchema"
        private EntityStructure tb = new EntityStructure();
        // public event EventHandler<PassedArgs> OnObjectSelected;
        string datasourcename = null;
        public void RaiseObjectSelected()
        {

        }

        public void Run(IPassedArgs pPassedarg)
        {

        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            Passedarg = e;
            Logger = plogger;
            DMEEditor = pbl;
            ErrorObject = per;
            //foreach (ConnectionProperties c in DMEEditor.ConfigEditor.DataConnections.Where(c => c.Category == DatasourceCategory.RDBMS))
            //{
            //    var t = databaseTypeComboBox.Items.Add(c.ConnectionName);

            //}
            mappingBindingSource.DataSource = DMEEditor.ConfigEditor.DataTypesMap.Distinct();
            List<EntityStructure> entityStructures = new List<EntityStructure>();
            
            entitiesBindingSource.DataSource = entityStructures;
           
            entitiesBindingSource.AddNew();
            fieldsBindingSource.DataSource = entitiesBindingSource;
            fieldsBindingSource.DataMember = "Fields";
            fieldtypeDataGridViewTextBoxColumn.DataSource = mappingBindingSource;
            fieldsDataGridView.DataSource = fieldsBindingSource;
            //fieldtypeDataGridViewTextBoxColumn.DataSource = DMEEditor.typesHelper.GetNetDataTypes2();
            //    uc_bindingNavigator2.SaveCalled += Uc_bindingNavigator1_SaveCalled;
            // uc_bindingNavigator2.bindingSource.DataSource = entitiesBindingSource;

            this.entitiesBindingSource.AddingNew += EntitiesBindingSource_AddingNew;
            this.fieldsBindingSource.AddingNew += FieldsBindingSource_AddingNew;
            this.CreateinDBbutton.Click += CreateinDBbutton_Click1;
            this.fieldsDataGridView.DataError += FieldsDataGridView_DataError;
          //  this.databaseTypeComboBox.SelectedIndexChanged += DatabaseTypeComboBox_SelectedIndexChanged;
            // this.fieldsDataGridView.RowValidated += FieldsDataGridView_RowValidated;
            this.fieldsDataGridView.RowValidating += FieldsDataGridView_RowValidating;
            this.fieldsDataGridView.CellEndEdit += FieldsDataGridView_CellEndEdit;

            uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, e, DMEEditor.ErrorObject);
            uc_bindingNavigator1.bindingSource = fieldsBindingSource;
            uc_bindingNavigator1.SaveCalled += Uc_bindingNavigator1_SaveCalled1;
            uc_bindingNavigator1.HightlightColor = Color.Yellow;
            if (!string.IsNullOrEmpty(e.DatasourceName))
            {
                datasourcename = e.DatasourceName;
                this.DataSourceName.Text = datasourcename;
                UpdateFieldTypes();
            }
            else
                return;

        }

        private void Uc_bindingNavigator1_SaveCalled1(object sender, BindingSource e)
        {
            save();
        }

        private void FieldsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(datasourcename))
            {
                return;
            }
            DataGridViewRow row = fieldsDataGridView.Rows[e.RowIndex];
            DataGridViewCell fieldtype = row.Cells[2];
            DataGridViewCell size1 = row.Cells[3];
            DataGridViewCell nperc = row.Cells[4];
            DataGridViewCell nscale = row.Cells[5];
            if (e.ColumnIndex == 2)
            {
                if (fieldtype.Value.ToString().Contains("N"))
                {
                    size1.ReadOnly = false;
                    nperc.ReadOnly = true;
                    nscale.ReadOnly = true;
                }
                if (fieldtype.Value.ToString().Contains("P,S"))
                {
                    size1.ReadOnly = true;
                    nperc.ReadOnly = false;
                    nscale.ReadOnly = false;
                }
            }
        }

        private void FieldsDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (string.IsNullOrEmpty(datasourcename))
            {
                return;
            }
            DataGridViewRow row = fieldsDataGridView.Rows[e.RowIndex];
            DataGridViewCell id = row.Cells[0];
            DataGridViewCell fieldname = row.Cells[1];
            DataGridViewCell fieldtype = row.Cells[2];
            DataGridViewCell size1 = row.Cells[3];
            DataGridViewCell nperc = row.Cells[4];

            DataGridViewCell nscale = row.Cells[5];
            DataGridViewCell Autoinc = row.Cells[6];
            DataGridViewCell isdbnull = row.Cells[7];
            DataGridViewCell ischeck = row.Cells[8];
            DataGridViewCell isunique = row.Cells[9];
            DataGridViewCell iskey = row.Cells[10];

            //   e.Cancel = !(IsDoc(Docnamecell) && IsGender(Gendercell) && IsAddress(Addresscell) && IsContactno(Contactnocell) && IsDate(Datecell));
        }
        private void UpdateFieldTypes()
        {
            if (!string.IsNullOrEmpty(datasourcename) && string.IsNullOrEmpty(this.EntityName))
            {
                ConnectionProperties connection = DMEEditor.ConfigEditor.DataConnections.Where(o => o.ConnectionName.Equals(datasourcename, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                ConnectionDriversConfig conf = DMEEditor.Utilfunction.LinkConnection2Drivers(connection);
                if (conf != null)
                {
                    mappingBindingSource.DataSource = DMEEditor.ConfigEditor.DataTypesMap.Where(p => p.DataSourceName.Equals(conf.classHandler, StringComparison.InvariantCultureIgnoreCase) ).Distinct();
                }
            }
        }
       

        private void FieldsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (string.IsNullOrEmpty(datasourcename) && string.IsNullOrEmpty(this.EntityName))
            {
                return;
            }
            EntityStructure entityStructure = (EntityStructure)entitiesBindingSource.Current;
            EntityField entityField = new EntityField();
            entityField.EntityName = entityStructure.EntityName;
            e.NewObject = entityField;

        }

        private void EntitiesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            EntityStructure entityStructure = new EntityStructure();
            entityStructure.Drawn = false;
            entityStructure.Editable = true;
            e.NewObject = entityStructure;
        }

        private void save()
        {
            try
            {
                fieldsBindingSource.EndEdit();
                entitiesBindingSource.EndEdit();
                DMEEditor.ConfigEditor.SaveTablesEntities();
                MessageBox.Show("Table Creation is Saved", "Beep");
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Fail", $"Could not Save Entity Creation Script {ex.Message}", DateTime.Now, -1, "", Errors.Failed);
            }

        }
        private void CreateinDBbutton_Click1(object sender, EventArgs e)
        {

            try
            {
                tb = (EntityStructure)entitiesBindingSource.Current;
                SourceConnection = DMEEditor.GetDataSource(datasourcename);
                DMEEditor.OpenDataSource(datasourcename);
                //SourceConnection.Dataconnection.OpenConnection();
                SourceConnection.ConnectionStatus = SourceConnection.Dataconnection.ConnectionStatus;
                if (SourceConnection.ConnectionStatus == ConnectionState.Open)
                {
                    tb.DatasourceEntityName = tb.EntityName;

                    SourceConnection.CreateEntityAs(tb);
                    if (DMEEditor.ErrorObject.Flag == Errors.Ok)
                    {
                        MessageBox.Show("Entity Creation Success", "Beep");
                        DMEEditor.AddLogMessage("Success", "Table Creation Success", DateTime.Now, -1, "", Errors.Failed);
                    }
                    else
                    {
                        string mes = "Entity Creation Failed";
                        MessageBox.Show(mes, "Beep");
                        DMEEditor.AddLogMessage("Create Table", mes, DateTime.Now, -1, mes, Errors.Failed);
                    }

                }
                else
                {
                    MessageBox.Show("Entity Creation Not Success Could not open Database", "Beep");
                    DMEEditor.AddLogMessage("Fail", "Table Creation Not Success Could not open Database", DateTime.Now, -1, "", Errors.Failed);
                }

            }
            catch (Exception ex)
            {
                string mes = "Entity Creation Failed";
                MessageBox.Show(mes, "Beep");
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };

        }


        private void FieldsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void SaveTableConfigbutton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void NewTablebutton_Click(object sender, EventArgs e)
        {
            entitiesBindingSource.AddNew();
        }
    }
}
