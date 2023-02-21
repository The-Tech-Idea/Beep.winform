using TheTechIdea.Beep;

using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Util;
using TheTechIdea;
using TheTechIdea.Beep.Vis;
using BeepEnterprize.Vis.Module;
using TheTechIdea.Beep.Addin;

namespace BeepEnterprize.Winform.Vis.Configuration
{
    [AddinAttribute(Caption = "Field Mapping", Name = "uc_DBFieldType", misc = "Config", menu = "Configuration", addinType = AddinType.Control, displayType = DisplayType.Popup)]
    [AddinVisSchema(BranchID = 2, RootNodeName = "Configuration", Order = 2, ID = 2, BranchText = "Field Types", BranchType = EnumPointType.Function, IconImageName = "fieldtype.ico", BranchClass = "ADDIN", BranchDescription = "Data Sources Connection Drivers Setup Screen")]
    public partial class uc_DBFieldType : UserControl, IDM_Addin, IAddinVisSchema
    {
        public uc_DBFieldType()
        {
            InitializeComponent();
        }
        #region "IAddinVisSchema"
        public string RootNodeName { get; set; } = "DDL";
        public string CatgoryName { get; set; }
        public int Order { get; set; } = 2;
        public int ID { get; set; } = 2;
        public string BranchText { get; set; } = "Field Types";
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Entity;
        public int BranchID { get; set; } = 2;
        public string IconImageName { get; set; } = "fieldtype.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; } = "";
        public string BranchClass { get; set; } = "ADDIN";
        #endregion "IAddinVisSchema"
        public string AddinName { get; set; } = "Field Types";
        public string Description { get; set; } = "";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public string DllName { get; set; }
        public string DllPath { get; set; }
        public string NameSpace { get; set; }
        public string ParentName { get; set; }
      
        public DataSet Dset { get; set; }
        public Boolean DefaultCreate { get; set; } = true;
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IVisManager Visutil { get; set; }
        public IPassedArgs Passedarg { get; set; }

        // public event EventHandler<PassedArgs> OnObjectSelected;

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
            Visutil = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;


            try
            {
                DMEEditor.ConfigEditor.ReadDataTypeFile();
            }
            catch (Exception)
            {
            }
            this.DataSourcedataGridViewTextBoxColumn3.DataSource = DMEEditor.typesHelper.GetDataClasses();
            this.NetDataTypedataGridViewTextBoxColumn4.DataSource = DMEEditor.typesHelper.GetNetDataTypes2();
            try
            {
                mappingBindingSource.DataSource = DMEEditor.ConfigEditor.DataTypesMap;
            }
            catch (Exception ex)
            {

                ErrorObject.Flag = Errors.Failed;
                ErrorObject.Ex = ex;
                MessageBox.Show("Error Load Mapping ", "Beep");
                Logger.WriteLog($"Error Load Mapping ({ex.Message})");
            }
            uc_bindingNavigator1.bindingSource = mappingBindingSource;
            this.mappingDataGridView.DataSource = mappingBindingSource;
            this.mappingDataGridView.Refresh();
            uc_bindingNavigator1.SaveCalled += Uc_bindingNavigator1_SaveCalled;
            //this.mappingBindingNavigatorSaveItem.Click += MappingBindingNavigatorSaveItem_Click;
            this.mappingBindingSource.AddingNew += MappingBindingSource_AddingNew;
            this.mappingDataGridView.DataError += MappingDataGridView_DataError;
            uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, e, DMEEditor.ErrorObject);
            uc_bindingNavigator1.HightlightColor = Color.Yellow;

        }

        private void Uc_bindingNavigator1_SaveCalled(object sender, BindingSource e)
        {
            ErrorObject.Flag = Errors.Ok;
            try
            {
                this.Validate();
                this.mappingDataGridView.EndEdit();
                mappingBindingSource.EndEdit();

                DMEEditor.ConfigEditor.WriteDataTypeFile();
                Logger.WriteLog($"Successed in Saving Field Types");
                MessageBox.Show("Changes Saved Successfuly", "Beep");
            }
            catch (System.Exception ex)
            {
                ErrorObject.Flag = Errors.Failed;
                ErrorObject.Ex = ex;
                MessageBox.Show("Error Saving Datatypes", "Beep");
                Logger.WriteLog($"Error in Field Types ({ex.Message})");


            }
        }

        private void MappingDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void MappingBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            DatatypeMapping x = new DatatypeMapping();
            e.NewObject = x;

        }

        private void MappingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
        }



        private void FieldtypesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            e.ThrowException = false;
            //// commited, display an error message.
            //if (e.Exception != null &&
            //    e.Context == DataGridViewDataErrorContexts.Formatting)
            //{

            //}
        }
    }
}
