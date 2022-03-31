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
using TheTechIdea.Beep.Workflow.Mapping;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    public partial class uc_addeditImportData : UserControl,IDM_Addin
    {
        public uc_addeditImportData()
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
        public EntityDataMap DataMap { get; set; }
        EntityDataMap_DTL dataMap_DTL;
        VisManager visManager;
        //  IDataSource ds;
        //  Type CurrentType;
        public  ImportDataManager importDataManager { get; set; }
        public void Run(IPassedArgs pPassedarg)
        {
            Passedarg = pPassedarg;
            //if (pPassedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            //{
            //    dataMap_DTL = (EntityDataMap_DTL)pPassedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").FirstOrDefault().obj;
            //}
            mappedEntitiesBindingSource.DataSource = importDataManager.CurrentMappingDTL;
            SourceDatasourcecomboBox.SelectedValueChanged -= SourceDatasourcecomboBox_SelectedValueChanged;
            SourceDatasourcecomboBox.SelectedValueChanged += SourceDatasourcecomboBox_SelectedValueChanged;
            dataConnectionsBindingSource.DataSource = importDataManager.dataConnectionsBindingSource.DataSource;

            // mappedEntitiesBindingSource.ResetBindings(false);
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

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                try
                {
                    
                    mappedEntitiesBindingSource.EndEdit();
                    
                    importDataManager.Save();
                    importDataManager.DataGotUpdated();
                  //  MessageBox.Show("Mapping Save Successfully", "Beep");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: Saving Mapping", "Beep", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DMEEditor.AddLogMessage("Import Mapping", "Error: Saving Mapping : " + ex.Message, DateTime.Now, 0, ex.Message, Errors.Failed);

                }
                this.ParentForm.Close();
            }
           
        }

      
      
        private void SourceDatasourcecomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SourceDatasourcecomboBox.Text))
            {
                IDataSource ds = DMEEditor.GetDataSource(SourceDatasourcecomboBox.Text);
                if (ds != null)
                {
                    ds.Openconnection();
                    if (ds.ConnectionStatus == ConnectionState.Open)
                    {
                        ds.GetEntitesList();
                        EntitysourcecomboBox.DataSource = ds.EntitiesNames;


                    } else
                    {
                        EntitysourcecomboBox.DataSource = null;
                        MessageBox.Show(this.ParentForm, "Beep", $"Could Not Open Data Source ({SourceDatasourcecomboBox.Text})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DMEEditor.AddLogMessage("Import Mapping", $"Could Not Open Data Source ({SourceDatasourcecomboBox.Text})", DateTime.Now, 0, $"Could Not Open Data Source ({SourceDatasourcecomboBox.Text})", Errors.Failed);
                    }    
                }else
                {
                    EntitysourcecomboBox.DataSource = null;
                    MessageBox.Show(this.ParentForm, "Beep", $"Could Not Get Data Source ({SourceDatasourcecomboBox.Text})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DMEEditor.AddLogMessage("Import Mapping", $"Could Not Get Data Source ({SourceDatasourcecomboBox.Text})", DateTime.Now, 0, $"Could Not Open Data Source ({SourceDatasourcecomboBox.Text})", Errors.Failed);

                }

            }
        }
    }
    
}
