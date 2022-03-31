using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Workflow;
using TheTechIdea.Beep.Workflow.Mapping;

using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    public partial class uc_MapFields : UserControl,IDM_Addin
    {
        public uc_MapFields()
        {
            InitializeComponent();
        }

        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; }
        public string AddinName { get ; set ; }
        public string Description { get ; set ; }
        public bool DefaultCreate { get ; set ; }
        public string DllPath { get ; set ; }
        public string DllName { get ; set ; }
        public string NameSpace { get ; set ; }
        public IErrorsInfo ErrorObject { get ; set ; }
        public IDMLogger Logger { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public EntityStructure EntityStructure { get ; set ; }
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        VisManager visManager;
        //  IDataSource ds;
        //  Type CurrentType;
        public ImportDataManager importDataManager { get; set; }
        public EntityDataMap_DTL DataMap { get; set; }
        public void Run(IPassedArgs pPassedarg)
        {
            if (importDataManager.CurrentMappingDTL != null)
            {
                visManager.wizardManager.WizardNodeChangeEvent -= WizardManager_WizardNodeChangeEvent;
                visManager.wizardManager.WizardNodeChangeEvent += WizardManager_WizardNodeChangeEvent;
                fromFieldNameDataGridViewTextBoxColumn.DataSource = importDataManager.CurrentMappingDTL.EntityFields;
                fromFieldNameDataGridViewTextBoxColumn.ValueMember = "fieldname";
                fromFieldNameDataGridViewTextBoxColumn.DisplayMember = "fieldname";
                toFieldNameDataGridViewTextBoxColumn.DataSource = importDataManager.CurrentMappingDTL.SelectedDestFields;
                toFieldNameDataGridViewTextBoxColumn.ValueMember = "fieldname";
                toFieldNameDataGridViewTextBoxColumn.DisplayMember = "fieldname";
                fieldMappingBindingSource.DataSource = importDataManager.CurrentMappingDTL.FieldMapping; //DataMap.FieldMapping;
                uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, pPassedarg, DMEEditor.ErrorObject);
                uc_bindingNavigator1.HightlightColor = Color.Yellow;
                uc_bindingNavigator1.bindingSource = fieldMappingBindingSource;
                FieldMappingGridView.DataSource = fieldMappingBindingSource;
                FieldMappingGridView.Refresh();
                DMEEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
            }
           
          
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;

            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "ImportDataManager").Any())
            {
                importDataManager = (ImportDataManager)e.Objects.Where(c => c.Name == "ImportDataManager").FirstOrDefault().obj;
            }

            FieldMappingGridView.DataError += FieldMappingGridView_DataError;
          
            //uc_bindingNavigator1.CallPrinter += Uc_bindingNavigator1_CallPrinter;
            //uc_bindingNavigator1.SendMessage += Uc_bindingNavigator1_SendMessage;
            //uc_bindingNavigator1.ShowSearch += Uc_bindingNavigator1_ShowSearch;
            // uc_bindingNavigator1.SetConfig(DMEEditor, plogger, putil, args, e, per);
            uc_bindingNavigator1.VerifyDelete = false;
        }

        private void WizardManager_WizardNodeChangeEvent(object sender, Wizards.WizardManager.NodeChangeEventHandler e)
        {
            if (importDataManager.CurrentMappingDTL == null)
            {
                e.Cancel = true;
            }
            else if (importDataManager.CurrentMappingDTL.SelectedDestFields.Count==0)
            {
                e.Cancel = true;
            }else if (importDataManager.CurrentMappingDTL.EntityFields.Count == 0)
            {
                e.Cancel = true;
            }
            
        }

        private void FieldMappingGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          //  DMEEditor.AddLogMessage("fail", e.Exception.Message, DateTime.Now, 0, null, Errors.Failed);
            e.Cancel = true;
        }

        private void MappedEntitiesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Mapping_rep_fields x = new Mapping_rep_fields();
            e.NewObject = x;

        }
    }
}
