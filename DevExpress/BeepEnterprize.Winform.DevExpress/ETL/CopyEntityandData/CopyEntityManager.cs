using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeepEnterprize.Winform.Vis.ETL.ImportData;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Workflow.Mapping;
using TheTechIdea.Beep.Vis;

using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.CopyEntityandData
{
    [AddinAttribute(Caption = "Copy Entity Manager", Name = "CopyEntityManager", misc = "ImportDataManager", addinType = AddinType.Class)]
    public class CopyEntityManager : IDM_Addin
    {
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

        CancellationTokenSource tokenSource;
        CancellationToken token;
        bool RequestCancle = false;

        int errorcount = 0;
        ImportDataManager importDataManager;
        VisManager visManager;
        bool IsOk = true;
        public List<EntityStructure> Entities { get; set; } = new List<EntityStructure>();
        public BindingList<EntityStructure> DestinationEntities { get; set; } = new BindingList<EntityStructure>();
        public string DestinationDataSource { get; set; }
        public ETLScriptHDR  syncDataSource { get; set; }
        public List<ETLScriptDet> SyncEntities { get; set; }
        public IDataSource ds { get; set; }

        public void Run(IPassedArgs pPassedarg)
        {
            Passedarg = pPassedarg;
            if (pPassedarg.Objects.Where(i => i.Name == "CopyEntityManager").Any())
            {
                pPassedarg.Objects.Remove(pPassedarg.Objects.Where(i => i.Name == "CopyEntityManager").FirstOrDefault());
            }
            pPassedarg.Objects.Add(new ObjectItem() { Name = "CopyEntityManager", obj = this });
            if (pPassedarg.Objects.Where(c => c.Name == "ImportDataManager").Any())
            {
                importDataManager = (ImportDataManager)pPassedarg.Objects.Where(c => c.Name == "ImportDataManager").FirstOrDefault().obj;
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
            if (e.Objects.Where(c => c.Name == "ENTITIES").Any())
            {
                Entities = (List<EntityStructure>)e.Objects.Where(c => c.Name == "ENTITIES").FirstOrDefault().obj;
            }
            DestinationDataSource = e.DatasourceName;
            if (Entities != null)
            {
                visManager.Controlmanager.MsgBox("Beep", "Missing Entities to import !!!");
                IsOk = false;
            }
            if (DestinationDataSource == null)
            {
                visManager.Controlmanager.MsgBox("Beep", "Missing Destination DataSource Name !!!");
                IsOk = false;
            }
            importDataManager = new ImportDataManager();
            importDataManager.SetConfig(pbl, plogger, putil, args, e, per);

           
        }

        public IErrorsInfo LoadCopyRun(string fromds,string fromentity,string tods,string toentity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Flag = Errors.Failed;

            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo SaveCopyRun(string fromds, string fromentity, string tods, string toentity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Flag = Errors.Failed;

            }
            return DMEEditor.ErrorObject;
        }

        public IErrorsInfo CreateLoadingScripts()
        {
            try
            {
                IDataSource SourceDS;
                if (importDataManager.mappedEntitiesBindingSource.Current != null)
                {
                    EntityDataMap_DTL MappingRecord = (EntityDataMap_DTL)importDataManager.mappedEntitiesBindingSource.Current;
                    if(MappingRecord.EntityDataSource!=null && MappingRecord.EntityName!=null && MappingRecord.FieldMapping!=null && MappingRecord.SelectedDestFields != null)
                    {
                        SourceDS = DMEEditor.GetDataSource(MappingRecord.EntityDataSource);
                        if(SourceDS.Openconnection()== System.Data.ConnectionState.Open)
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
                        DMEEditor.ErrorObject.Message = $"Missing Properties in Mapping Data " ;
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
        public IErrorsInfo CreateEntityScript()
        {
            try
            {
                var progress = new Progress<PassedArgs>(percent => {


                });
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                SyncEntities = DMEEditor.ETL.GetCreateEntityScript(ds, Entities, progress, token);
               
                
            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Flag = Errors.Failed;

            }
            return DMEEditor.ErrorObject;
        }
    }
    
}
