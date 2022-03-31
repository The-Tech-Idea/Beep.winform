
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Workflow.Mapping;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    public partial class uc_SelectField : UserControl,IDM_Addin
    {
        public uc_SelectField()
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
        public EntityDataMap_DTL DataMap { get; set; } 
        VisManager visManager;
        //   IDataSource ds;
        //  Type CurrentType;
        public ImportDataManager importDataManager { get; set; }
        public void Run(IPassedArgs pPassedarg)
        {
            if (pPassedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                DataMap = (EntityDataMap_DTL)pPassedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").FirstOrDefault().obj;
            }
            if (importDataManager.CurrentMappingDTL != null)
            {
                visManager.wizardManager.WizardNodeChangeEvent -= WizardManager_WizardNodeChangeEvent;
                visManager.wizardManager.WizardNodeChangeEvent += WizardManager_WizardNodeChangeEvent;
                selectedDestFieldsBindingSource.DataSource = importDataManager.CurrentMappingDTL.SelectedDestFields;
                SourceEntityFieldsbindingSource.DataSource = importDataManager.Mapping.EntityFields;
                AvailableFieldsGrid.Refresh();
                SelectedFieldsGrid.Refresh();
                this.AddFieldButton.Click -= AddFieldButton_Click;
                this.RemoveFieldbutton.Click -= RemoveFieldbutton_Click;

                this.AddFieldButton.Click += AddFieldButton_Click;
                this.RemoveFieldbutton.Click += RemoveFieldbutton_Click;
                DMEEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
            }
            

        }
        private void WizardManager_WizardNodeChangeEvent(object sender, Wizards.WizardManager.NodeChangeEventHandler e)
        {
            if (importDataManager.CurrentMappingDTL == null)
            {
                e.Cancel = true;
            }
            else if (importDataManager.CurrentMappingDTL.SelectedDestFields.Count == 0)
            {
                e.Cancel = true;
            }
            else if (importDataManager.CurrentMappingDTL.EntityFields.Count == 0)
            {
                e.Cancel = true;
            }

        }
        private void RemoveFieldbutton_Click(object sender, System.EventArgs e)
        {
            if(selectedDestFieldsBindingSource != null)
            {
                if(selectedDestFieldsBindingSource.Count > 0)
                {
                    if (selectedDestFieldsBindingSource.Current != null)
                    {
                        selectedDestFieldsBindingSource.RemoveCurrent();
                    }
                }
            }
        }

        private void AddFieldButton_Click(object sender, System.EventArgs e)
        {
            if (SourceEntityFieldsbindingSource != null)
            {
                if (SourceEntityFieldsbindingSource.Count > 0)
                {
                    if (SourceEntityFieldsbindingSource.Current != null)
                    {
                        EntityField fld =(EntityField) SourceEntityFieldsbindingSource.Current;
                        if (!CheckifFieldExistinList(fld))
                        {
                            selectedDestFieldsBindingSource.Add(fld);
                        }
                       
                    }
                }
            }
        }
        private bool CheckifFieldExistinList(EntityField fld)
        {
           
            if (selectedDestFieldsBindingSource != null)
            {
                if (selectedDestFieldsBindingSource.Count > 0)
                {
                    List<EntityField> ls = (List<EntityField>) selectedDestFieldsBindingSource.List;
                    return ls.Any(p => p.fieldname.Equals(fld.fieldname, System.StringComparison.OrdinalIgnoreCase)); ;

                }else return false;

            }
            else return false;
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
 
        }
    }
}
