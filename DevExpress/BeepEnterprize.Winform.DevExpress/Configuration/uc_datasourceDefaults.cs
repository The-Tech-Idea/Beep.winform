using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using TheTechIdea.Beep.Vis;
using BeepEnterprize.Vis.Module;
using TheTechIdea;

namespace BeepEnterprize.Winform.Vis
{
    [AddinAttribute(Caption = "DataConnection Defaults", Name = "uc_datasourceDefaults", misc = "Config", menu = "Configuration", addinType = AddinType.Control, displayType = DisplayType.Popup)]
    public partial class uc_datasourceDefaults : UserControl, IDM_Addin
    {
        public uc_datasourceDefaults()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string AddinName { get; set; } = "Data Source Default Values";
        public string Description { get; set; } = "Data Source Default Values";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public Boolean DefaultCreate { get; set; } = false;
        public string DllPath { get ; set ; }
        public string DllName { get ; set ; }
        public string NameSpace { get ; set ; }
        public DataSet Dset { get ; set ; }
        public IErrorsInfo ErrorObject { get ; set ; }
        public IDMLogger Logger { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public EntityStructure EntityStructure { get ; set ; }
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }

       // public event EventHandler<PassedArgs> OnObjectSelected;
        public IVisManager Visutil { get; set; }
        public void RaiseObjectSelected()
        {
            throw new NotImplementedException();
        }

        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            Passedarg = e;
            Logger = plogger;
            ErrorObject = per;
            DMEEditor = pbl;
            Visutil = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;

            foreach (var item in Enum.GetValues(typeof(DefaultValueType)))
            {
                this.TypedataGridViewTextBoxColumn3.Items.Add(item);
            }
            foreach (AssemblyClassDefinition item in DMEEditor.ConfigEditor.Rules)
            {
                RuleComboBox.Items.Add(item.classProperties.Name);
            }
            RuleComboBox.Items.Add("");
            this.datasourceDefaultsBindingSource.DataSource = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == e.DatasourceName)].DatasourceDefaults;
            uc_bindingNavigator1.bindingSource = datasourceDefaultsBindingSource;
            uc_bindingNavigator1.SaveCalled += Uc_bindingNavigator1_SaveCalled;
            //this.datasourceDefaultsBindingNavigatorSaveItem.Click += DatasourceDefaultsBindingNavigatorSaveItem_Click;
            this.datasourceDefaultsBindingSource.AddingNew += DatasourceDefaultsBindingSource_AddingNew;
            this.datasourceDefaults1DataGridView.DataError += DatasourceDefaults1DataGridView_DataError;
            this.datasourceDefaults1DataGridView.EditingControlShowing += DatasourceDefaults1DataGridView_EditingControlShowing;
            uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, e, DMEEditor.ErrorObject);
            uc_bindingNavigator1.HightlightColor = Color.Yellow;

            datasourceDefaults1DataGridView.CellValueChanged += DatasourceDefaults1DataGridView_CellValueChanged;

        }

        private void DatasourceDefaults1DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
               if (datasourceDefaults1DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    datasourceDefaults1DataGridView.Rows[e.RowIndex].Cells[3].Value = DefaultValueType.Rule;
                }
                else
                {
                    datasourceDefaults1DataGridView.Rows[e.RowIndex].Cells[3].Value = DefaultValueType.ReplaceValue;
                }
            }

        }

        private void Uc_bindingNavigator1_SaveCalled(object sender, BindingSource e)
        {
            try
            {
                // DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(x => x.ConnectionName == EntityName)].Headers = (List<WebApiHeader>)this.headersBindingSource.List;
                DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                MessageBox.Show("Saved Successfully");
            }
            catch (Exception ex)
            {
                string errmsg = "Error in saving defaults";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                MessageBox.Show($"{errmsg}:{ex.Message}");
            }
        }

        private void DatasourceDefaults1DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (datasourceDefaults1DataGridView.CurrentCell.ColumnIndex == 0 || datasourceDefaults1DataGridView.CurrentCell.ColumnIndex == 2 | datasourceDefaults1DataGridView.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                {
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
                }
            }
        }

        private void DatasourceDefaults1DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void DatasourceDefaultsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            DefaultValue defv = new DefaultValue();

            e.NewObject = defv;
        }

    }
}
