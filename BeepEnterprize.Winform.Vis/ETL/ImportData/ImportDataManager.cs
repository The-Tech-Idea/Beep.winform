using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Workflow;
using TheTechIdea.Beep.Workflow.Mapping;
using TheTechIdea.Beep.Vis;

using TheTechIdea.Logger;
using TheTechIdea.Util;
using System.Windows.Forms;
using static BeepEnterprize.Winform.Vis.Wizards.WizardManager;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    [AddinAttribute(Caption = "Import Manager", Name = "ImportDataManager", misc = "ImportDataManager", addinType = AddinType.Class)]
    public class ImportDataManager : IDM_Addin
    {
        public event EventHandler<ImportDataManager> DataUpdated;
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
        public IDataSource ds { get; set; }
        public Type CurrentType { get; set; }
        public EntityDataMap Mapping { get; set; }
        public EntityDataMap_DTL CurrentMappingDTL { get; set; }
        public string SourceEntityname { get; set; }
        public string SourceDatasourcename { get; set; }
        public string DestEntityname { get; set; }
        public string DestDatasourcename { get; set; }
        #region "Forms and Controls"
        //public event EventHandler<EntityDataMap_DTL> CallFilter;
        //public event EventHandler<EntityDataMap_DTL> CallMap;
        //public event EventHandler<EntityDataMap_DTL> CallRun;
        //public event EventHandler<EntityDataMap_DTL> CallSelect;
        //public event EventHandler<EntityDataMap_DTL> CallAddEdit;
        #endregion
        public System.Windows.Forms.BindingSource dataConnectionsBindingSource { get; set; }
        public System.Windows.Forms.BindingSource entityDataMapBindingSource { get; set; }
        public System.Windows.Forms.BindingSource mappedEntitiesBindingSource { get; set; }

        public void Run(IPassedArgs pPassedarg)
        {
            Passedarg = pPassedarg;
            if (pPassedarg.Objects.Where(i => i.Name == "ImportDataManager").Any())
            {
                pPassedarg.Objects.Remove(pPassedarg.Objects.Where(i => i.Name == "ImportDataManager").FirstOrDefault());
            }
            pPassedarg.Objects.Add(new ObjectItem() { Name = "ImportDataManager", obj = this });
            DestDatasourcename = pPassedarg.DatasourceName;
            DestEntityname = pPassedarg.CurrentEntity;
            SourceDatasourcename = pPassedarg.ParameterString1;
            SourceEntityname = pPassedarg.ParameterString2;
            SetupConnection(pPassedarg.DatasourceName, (PassedArgs)pPassedarg);
            if (DMEEditor.ErrorObject.Flag == Errors.Ok)
            {
                if (!string.IsNullOrEmpty(SourceDatasourcename))
                {
                    CreateEntityMap(SourceEntityname, SourceDatasourcename, DestEntityname, DestDatasourcename);
                }else
                    CreateEntityMap(pPassedarg.CurrentEntity, pPassedarg.DatasourceName);
                dataConnectionsBindingSource = new System.Windows.Forms.BindingSource();
                entityDataMapBindingSource = new System.Windows.Forms.BindingSource();
                mappedEntitiesBindingSource = new System.Windows.Forms.BindingSource();
                dataConnectionsBindingSource.DataSource = DMEEditor.ConfigEditor.DataConnections;
                entityDataMapBindingSource.DataSource = Mapping;

                entityDataMapBindingSource.BindingComplete -= EntityDataMapBindingSource_BindingComplete;
                
                mappedEntitiesBindingSource.BindingComplete -= MappedEntitiesBindingSource_BindingComplete;

                entityDataMapBindingSource.BindingComplete += EntityDataMapBindingSource_BindingComplete;
                mappedEntitiesBindingSource.DataSource = entityDataMapBindingSource;
                mappedEntitiesBindingSource.BindingComplete += MappedEntitiesBindingSource_BindingComplete;
                mappedEntitiesBindingSource.DataMember = "MappedEntities";
                visManager.wizardManager.Nodes.Clear();
                visManager.wizardManager.Title = DestDatasourcename;
                visManager.wizardManager.Description = DestEntityname;
                visManager.wizardManager.InitWizardForm();
                uc_FilterData uc_Filter;
                uc_MapFields uc_Map;
                uc_RunImport uc_Run;
                uc_SelectField uc_Select;
                uc_addeditImportData uc_addedit;
                uc_SelectMapping uc_SelectMapping;
                uc_Filter = new uc_FilterData();
                uc_Map = new uc_MapFields();
                uc_Run = new uc_RunImport();
                uc_Select = new uc_SelectField();
                uc_addedit = new uc_addeditImportData();
                uc_SelectMapping=new uc_SelectMapping();

                uc_SelectMapping.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);
                uc_Filter.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { },Passedarg, DMEEditor.ErrorObject);
                uc_Map.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);
                uc_Run.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);
                uc_Select.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);
               // uc_addedit.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);

               // visManager.wizardManager.AddNode(uc_addedit, "NewEditMapping", "New/Edit Mapping");
                visManager.wizardManager.AddNode(uc_SelectMapping, "SelectMapping", "Select Mapping");
                visManager.wizardManager.AddNode(uc_Select,"Selection", "Select Fields");
                visManager.wizardManager.AddNode(uc_Map,"Mapping", "Map Fields");
                visManager.wizardManager.AddNode(uc_Filter,"Filter", "Filter Fields");
                visManager.wizardManager.AddNode(uc_Run,"Import", "Run Import");
                ObjectItem ob;
                if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap").Any())
                {
                     ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap");
                    
                }else
                {
                    ob=new ObjectItem();
                    ob.Name = "EntityDataMap";
                   
                    Passedarg.Objects.Add(ob);
                }
                ob.obj = Mapping;
              
                visManager.wizardManager.Show();
                visManager.wizardManager.WizardCloseEvent += WizardManager_WizardCloseEvent;
                // visManager.ShowPage("Frm_ImportData", (PassedArgs)pPassedarg, TheTechIdea.Beep.Vis.DisplayType.Popup);
            }
            



        }
        private void WizardManager_WizardCloseEvent(object sender, NodeChangeEventHandler e)
        {

            if (MessageBox.Show("Would you like to save Changes ?", "Beep", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Save();
            }
        }
        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            Passedarg = e;
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
           
          
        }
        public IErrorsInfo SetupConnection(string DatasourceName, PassedArgs e)
        {
            Passedarg = e;
            ds = DMEEditor.GetDataSource(DatasourceName);
            ds.Openconnection();
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
            {
                EntityName = e.CurrentEntity;
               
                if (e.Objects.Where(c => c.Name == "EntityStructure").Any())
                {
                    EntityStructure = (EntityStructure)e.Objects.Where(c => c.Name == "EntityStructure").FirstOrDefault().obj;
                }
                else
                {
                    EntityStructure = ds.GetEntityStructure(EntityName, true);
                    e.Objects.Add(new ObjectItem { Name = "EntityStructure", obj = EntityStructure });
                }
              
                if (EntityStructure != null)
                {
                    if (EntityStructure.Fields != null)
                    {
                        if (EntityStructure.PrimaryKeys.Count > 0)
                        {
                            if (EntityStructure.Fields.Count > 0)
                            {
                                CurrentType = ds.GetEntityType(EntityStructure.EntityName);
                            }
                        }
                    }
                }else
                {
                    DMEEditor.ErrorObject.Flag = Errors.Failed;
                    visManager._controlManager.MsgBox("Fail", "Could not Get Entity from Data source");
                }

            }
            else
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                visManager._controlManager.MsgBox("Fail", "Could not Open Data source");
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo CreateEntityMap(string SourceEntityName,string SourceDataSourceName, string DestEntityName, string DestDataSourceName)
        {
            try
            {
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                IDataSource Destds=null;
              //  IDataSource Srcds=null;
                Mapping = DMEEditor.ConfigEditor.LoadMappingValues(DestEntityName, DestDataSourceName);
                if (Mapping == null)
                {
                    Mapping = new EntityDataMap();
                    Mapping.EntityName = DestEntityName;
                    Mapping.EntityDataSource = DestDataSourceName;
                }

                Destds = DMEEditor.GetDataSource(DestDataSourceName);
                Destds.Openconnection();
                EntityStructure destent = null;
                if (Destds != null && Destds.ConnectionStatus == ConnectionState.Open)
                {
                    destent = (EntityStructure)Destds.GetEntityStructure(DestEntityName, true).Clone();
                }
                else destent = (EntityStructure)Destds.GetEntityStructure(DestEntityName, false).Clone();

                Mapping.EntityFields = destent.Fields;
                Mapping.MappingName = $"{DestEntityName}_{DestDataSourceName}";
                if (Mapping.MappedEntities.Count > 0)
                {
                    if(!Mapping.MappedEntities.Where(p=>p.EntityName.Equals(SourceEntityName,StringComparison.OrdinalIgnoreCase) && p.EntityDataSource.Equals(SourceDataSourceName, StringComparison.OrdinalIgnoreCase)).Any())
                    {
                        Mapping.MappedEntities.Add(AddEntitytoMappedEntities(SourceDataSourceName, SourceEntityName, destent));
                    }
                   
                }
                else
                {
                    Mapping.MappedEntities = new List<EntityDataMap_DTL>();
                    Mapping.MappedEntities.Add(AddEntitytoMappedEntities(destent));
                }
                DMEEditor.ConfigEditor.SaveMappingValues(DestEntityName, DestDataSourceName, Mapping);
            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo CreateEntityMap( string DestEntityName, string DestDataSourceName)
        {
            try
            {
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                IDataSource Destds;
                //IDataSource Srcds;
                Mapping = DMEEditor.ConfigEditor.LoadMappingValues(DestEntityName, DestDataSourceName);
                if (Mapping == null)
                {
                    Mapping = new EntityDataMap();
                    Mapping.EntityName = DestEntityName;
                    Mapping.EntityDataSource = DestDataSourceName;
                }

                Destds = DMEEditor.GetDataSource(DestDataSourceName);
                Destds.Openconnection();
                EntityStructure destent = null;
                if (Destds != null && Destds.ConnectionStatus == ConnectionState.Open)
                {
                    destent = (EntityStructure)Destds.GetEntityStructure(DestEntityName, true).Clone();
                }
                else destent = (EntityStructure)Destds.GetEntityStructure(DestEntityName, false).Clone();
                //EntityDataMap_DTL det = new EntityDataMap_DTL();
                //det.SelectedDestFields = destent.Fields;
                //Mapping.EntityFields = destent.Fields;
                //Mapping.MappedEntities.Add(det);
                if (Mapping.MappedEntities == null)
                {
                    Mapping.MappedEntities = new List<EntityDataMap_DTL>();
                   
                }
                Mapping.MappingName = $"{DestEntityName}_{DestDataSourceName}";
                DMEEditor.ConfigEditor.SaveMappingValues(DestEntityName, DestDataSourceName, Mapping);
               

            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Flag = Errors.Failed;

            }
            return DMEEditor.ErrorObject;
        }
        public void Save()
        {
            
            mappedEntitiesBindingSource.EndEdit();
            entityDataMapBindingSource.EndEdit();
            DMEEditor.ConfigEditor.SaveMappingValues(Mapping.EntityName, Mapping.EntityDataSource, Mapping);
        }
        public EntityDataMap_DTL AddEntitytoMappedEntities( string SourceDataSourceName,string SourceEntityName,EntityStructure destent)
        {
            EntityDataMap_DTL det = new EntityDataMap_DTL();
            try
            {
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                if (!string.IsNullOrEmpty(SourceEntityName))
                {
                    det.EntityDataSource = SourceDataSourceName;
                    det.EntityName = SourceEntityName;
                    IDataSource Srcds = DMEEditor.GetDataSource(SourceDataSourceName);
                    Srcds.Openconnection();
                    EntityStructure srcent = null;
                    if (Srcds != null && Srcds.ConnectionStatus == ConnectionState.Open)
                    {
                        srcent = (EntityStructure)Srcds.GetEntityStructure(SourceEntityName, true).Clone();
                    }
                    else srcent = (EntityStructure)Srcds.GetEntityStructure(SourceEntityName, false).Clone();
                    det.EntityFields = srcent.Fields;
                }
               det.SelectedDestFields = destent.Fields;
               det.FieldMapping=MapEntityFields(det);
            }
            catch (Exception ex)
            {

                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Message = ex.Message;
            }
            return det;
        }
        public EntityDataMap_DTL AddEntitytoMappedEntities(EntityDataMap_DTL det, string SourceDataSourceName, string SourceEntityName, EntityStructure destent)
        {
            try
            {
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                if (!string.IsNullOrEmpty(SourceEntityName))
                {
                    det.EntityDataSource = SourceDataSourceName;
                    det.EntityName = SourceEntityName;
                    IDataSource Srcds = DMEEditor.GetDataSource(SourceDataSourceName);
                    Srcds.Openconnection();
                    EntityStructure srcent = null;
                    if (Srcds != null && Srcds.ConnectionStatus == ConnectionState.Open)
                    {
                        srcent = (EntityStructure)Srcds.GetEntityStructure(SourceEntityName, true).Clone();
                    }
                    else srcent = (EntityStructure)Srcds.GetEntityStructure(SourceEntityName, false).Clone();
                    det.EntityFields = srcent.Fields;
                }
               det.SelectedDestFields = destent.Fields;
                det.FieldMapping = MapEntityFields(det);
            }
            catch (Exception ex)
            {

                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Message = ex.Message;
            }
            return det;
        }
        public EntityDataMap_DTL AddEntitytoMappedEntities( EntityStructure destent)
        {
            EntityDataMap_DTL det = new EntityDataMap_DTL();
            try
            {
                DMEEditor.ErrorObject.Flag = Errors.Ok;
                det.SelectedDestFields = destent.Fields;
                det.FieldMapping = MapEntityFields(det);
            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Message = ex.Message;
            }
            return det;
        }
        public List<Mapping_rep_fields> MapEntityFields(EntityDataMap_DTL datamap)
        {
            List<Mapping_rep_fields> retval = new List<Mapping_rep_fields>();
            try
            {
                for (int i = 0; i < datamap.SelectedDestFields.Count; i++)
                {
                    Mapping_rep_fields x = new Mapping_rep_fields();
                    x.ToFieldName = datamap.SelectedDestFields[i].fieldname;
                    x.ToFieldType = datamap.SelectedDestFields[i].fieldtype;
                    foreach (EntityField item in datamap.EntityFields)
                    {
                        if(item.fieldname.Equals(x.ToFieldName,StringComparison.OrdinalIgnoreCase))
                        {
                            x.FromFieldName = item.fieldname;
                            x.FromFieldType = item.fieldtype;
                        }
                    }
                    retval.Add(x);
                }
            }
            catch (Exception ex)
            {
                retval = null;
            }
            return retval;
        }
        private void SetIteminPassedargs(EntityDataMap_DTL v)
        {
            if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                ObjectItem ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL");
                ob.obj = v;
            }
        }
        public void FilterData(EntityDataMap_DTL v)
        {
          
            if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                ObjectItem ob =(ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL");
                ob.obj = v;
            }
           
        }
        public void SelectFields(EntityDataMap_DTL v)
        {
            if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                ObjectItem ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL");
                ob.obj = v;
            }
           ;
        }
        public void MapFields(EntityDataMap_DTL v)
        {
            if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                ObjectItem ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL");
                ob.obj = v;
            }
        }
        public void RunImport(EntityDataMap_DTL v)
        {

            if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                ObjectItem ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL");
                ob.obj = v;
            }
           

        }
        public void AddEditMapping(EntityDataMap_DTL v)
        {

            if (Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL").Any())
            {
                ObjectItem ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "EntityDataMap_DTL");
                ob.obj = v;
            }

        }
        private void MappedEntitiesBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
               && e.Exception == null)
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }
        private void EntityDataMapBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
               && e.Exception == null)
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }

        public  void DataGotUpdated()
        {
            DataUpdated?.Invoke(this,this);
        }
        #region "Loading Data"
        public IErrorsInfo CreateLoadingScripts()
        {
            try
            {
                IDataSource SourceDS;
                if (mappedEntitiesBindingSource.Current != null)
                {
                    EntityDataMap_DTL MappingRecord = (EntityDataMap_DTL)mappedEntitiesBindingSource.Current;
                    if (MappingRecord.EntityDataSource != null && MappingRecord.EntityName != null && MappingRecord.FieldMapping != null && MappingRecord.SelectedDestFields != null)
                    {
                        SourceDS = DMEEditor.GetDataSource(MappingRecord.EntityDataSource);
                        if (SourceDS.Openconnection() == System.Data.ConnectionState.Open)
                        {


                        }
                        else
                        {
                            DMEEditor.ErrorObject.Message = $"Could not Connect to DataSource {MappingRecord.EntityDataSource}" + DMEEditor.ErrorObject.Message;
                            DMEEditor.ErrorObject.Flag = Errors.Failed;
                        }

                    }
                    else
                    {
                        DMEEditor.ErrorObject.Message = $"Missing Properties in Mapping Data ";
                        DMEEditor.ErrorObject.Flag = Errors.Failed;
                    }

                }
            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Flag = Errors.Failed;

            }
            return DMEEditor.ErrorObject;
        }
        #endregion

    }
}
