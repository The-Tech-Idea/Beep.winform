using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Workflow.Mapping;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    public partial class uc_SelectMapping : UserControl,IDM_Addin
    {
        public uc_SelectMapping()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string AddinName { get; set; }
        public string Description { get; set; }
        public bool DefaultCreate { get; set; }
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        public EntityDataMap DataMap { get; set; }
        EntityDataMap_DTL dataMap_DTL;
        VisManager visManager;
        //   IDataSource ds;
        //  Type CurrentType;
        public ImportDataManager importDataManager { get; set; }
        public void Run(IPassedArgs pPassedarg)
        {
            Passedarg = pPassedarg;
            //if (pPassedarg.Objects.Where(c => c.Name == "EntityDataMap").Any())
            //{
            //    DataMap = (EntityDataMap)pPassedarg.Objects.Where(c => c.Name == "EntityDataMap").FirstOrDefault().obj;
            //}
            mappedEntitiesBindingSource.DataSource = importDataManager.Mapping.MappedEntities;
            mappedEntitiesBindingSource.CurrentChanged -= MappedEntitiesBindingSource_CurrentChanged;
            mappedEntitiesBindingSource.AddingNew -= MappedEntitiesBindingSource_AddingNew;
            uc_bindingNavigator1.NewRecordCreated -= Uc_bindingNavigator1_NewRecordCreated;

            mappedEntitiesBindingSource.CurrentChanged += MappedEntitiesBindingSource_CurrentChanged;
            mappedEntitiesBindingSource.AddingNew += MappedEntitiesBindingSource_AddingNew;

            uc_bindingNavigator1.bindingSource = mappedEntitiesBindingSource;
            uc_bindingNavigator1.SaveCalled += Uc_bindingNavigator1_SaveCalled;
            uc_bindingNavigator1.CallPrinter += Uc_bindingNavigator1_CallPrinter;
            uc_bindingNavigator1.SendMessage += Uc_bindingNavigator1_SendMessage;
            uc_bindingNavigator1.ShowSearch += Uc_bindingNavigator1_ShowSearch;
            uc_bindingNavigator1.NewRecordCreated += Uc_bindingNavigator1_NewRecordCreated;
            uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, pPassedarg, DMEEditor.ErrorObject);
            uc_bindingNavigator1.HightlightColor = Color.Yellow;
            this.dataGridView1.Refresh();
            GetMapDTL();
        }

        private void Uc_bindingNavigator1_SaveCalled(object sender, BindingSource e)
        {
            importDataManager.Save();
        }

        private void Uc_bindingNavigator1_NewRecordCreated(object sender, BindingSource e)
        {
            GetMapDTL();
            if (ShowNewMapping()== DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(importDataManager.CurrentMappingDTL.EntityDataSource))
                {
                    importDataManager.AddEntitytoMappedEntities(importDataManager.CurrentMappingDTL, importDataManager.CurrentMappingDTL.EntityDataSource, importDataManager.CurrentMappingDTL.EntityName, importDataManager.EntityStructure);
                }
            }
           
            mappedEntitiesBindingSource.EndEdit();
            this.dataGridView1.Refresh();
        }

        private void MappedEntitiesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            EntityDataMap_DTL dm= new EntityDataMap_DTL();
            e.NewObject = dm;

         
        }
        private DialogResult ShowNewMapping()
        {
            BeepDialog frm = new BeepDialog();
            uc_addeditImportData uc_AddeditImportData = new uc_addeditImportData();
            uc_AddeditImportData.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, DMEEditor.Passedarguments, DMEEditor.ErrorObject);
            uc_AddeditImportData.Run(DMEEditor.Passedarguments);
            frm.AddControl(this.Parent,uc_AddeditImportData,"New/Edit Map", MessageBoxButtons.OKCancel);
            DialogResult result= frm.ShowDialog();
            if ((result == DialogResult.Cancel))
            {
                mappedEntitiesBindingSource.RemoveCurrent();
            }
            this.dataGridView1.Refresh();
            return result;
            
        }
        private void MappedEntitiesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
           GetMapDTL();
        }
        private void GetMapDTL()
        {
            if (mappedEntitiesBindingSource.Current != null)
            {
                dataMap_DTL = (EntityDataMap_DTL)mappedEntitiesBindingSource.Current;
                ObjectItem ob;
                if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
                {
                    ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").FirstOrDefault();
                }
                else
                {
                    ob = new ObjectItem();
                    ob.Name = "EntityDataMap_DTL";
                    Passedarg.Objects.Add(ob);
                }
                ob.obj = dataMap_DTL;
                importDataManager.CurrentMappingDTL = dataMap_DTL;
                DMEEditor.Passedarguments= Passedarg  ;
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
            importDataManager.DataUpdated += ImportDataManager_DataUpdated;
        }

        private void ImportDataManager_DataUpdated(object sender, ImportDataManager e)
        {
           dataGridView1.Invalidate();
        }

        private void Uc_bindingNavigator1_ShowSearch(object sender, BindingSource e)
        {

        }

        private void Uc_bindingNavigator1_SendMessage(object sender, BindingSource e)
        {
           
        }

        private void Uc_bindingNavigator1_CallPrinter(object sender, BindingSource e)
        {

        }
     
     
    }
}
