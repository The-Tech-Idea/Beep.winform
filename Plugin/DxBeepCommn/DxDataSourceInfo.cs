using DevExpress.DashboardCommon;
using DevExpress.Data.XtraReports.DataProviders;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Snap.Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;



namespace Beep.DExpress.Common
{
    public  class DxDataSourceInfo
    {
        public IDMEEditor DMEEditor { get; set; }
      
        public List<EntityStructure> Entities { get; set; } = new List<EntityStructure>();
        public List<ObjectDataSource> DxDataSources { get; set; } = new List<ObjectDataSource>();
        public List <BeepDxObjectDataSource> DxBeepObjects { get; set; } = new List<BeepDxObjectDataSource>();
        public List<DashboardObjectDataSource> DxDashboardDataSources { get; set; } = new List<DashboardObjectDataSource>();
        public DxDataSourceInfo(IDMEEditor pDMEEditor)
        {
            DMEEditor = pDMEEditor;
           
            DxDataSources = new List<ObjectDataSource>();
            Entities=new List<EntityStructure>();
        }
        public IErrorsInfo AddDataSources(List<IDataSource> pdataSources)
        {
            foreach (IDataSource ds in pdataSources)
            {
                AddDataSource(ds);

            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo AddDataSource(IDataSource pdataSources)
        {
          //  IDataSource ds = DMEEditor.GetDataSource(pdataSources);
            if (pdataSources != null)
            {
                pdataSources.Openconnection();
                if (pdataSources.ConnectionStatus == System.Data.ConnectionState.Open)
                {
                    foreach (string ent in pdataSources.GetEntitesList())
                    {
                        EntityStructure entity = (EntityStructure)pdataSources.GetEntityStructure(ent, true).Clone();
                        if (entity != null)
                        {
                            AddEntitytoDxDataSoures(entity);
                        }
                        else
                        {
                            DMEEditor.AddLogMessage("Beep", $"Could not Find Entity {ent}", DateTime.Now, 0, null, Errors.Failed);
                        }
                    }
                }
                else
                {
                    DMEEditor.AddLogMessage("Beep", $"Could not OPEN DataSource {pdataSources}", DateTime.Now, 0, null, Errors.Failed);
                }
            }
            else
            {
                DMEEditor.AddLogMessage("Beep", $"Could not GET DataSource  {pdataSources}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo AddEntities(List<EntityStructure> Entities)
        {
            foreach (var item in Entities)
            {
                AddEntitytoDxDataSoures(item);
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo AddEntitytoDxDataSoures(string datasourcename,string entityname)
        {
            IDataSource ds = DMEEditor.GetDataSource(datasourcename);
            if (ds != null)
            {
                ds.Openconnection();
                if (ds.ConnectionStatus == System.Data.ConnectionState.Open)
                {
                    EntityStructure entity = (EntityStructure)ds.GetEntityStructure(entityname, true).Clone();
                    if (entity != null)
                    {
                        AddEntitytoDxDataSoures(entity);
                    }
                    else
                    {
                        DMEEditor.AddLogMessage("Beep", $"Could not Find Entity {entityname}", DateTime.Now, 0, null, Errors.Failed);
                    }
                }
                else
                {
                    DMEEditor.AddLogMessage("Beep", $"Could not OPEN DataSource for Entity {entityname}", DateTime.Now, 0, null, Errors.Failed);
                }
            }
            else
            {
                DMEEditor.AddLogMessage("Beep", $"Could not GET DataSource for Entity {entityname}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo AddEntitytoDxDataSoures(EntityStructure entity)
        {
            IDataSource ds = DMEEditor.GetDataSource(entity.DataSourceID);
            if(ds != null)
            {
                ds.Openconnection();
                if(ds.ConnectionStatus== System.Data.ConnectionState.Open)
                {
                    BeepDxObjectDataSource t = new BeepDxObjectDataSource() {DMEEditor= DMEEditor, EntityName = entity.EntityName, Entity = entity, ReportFilters = null, DataSource = ds };
                    DxBeepObjects.Add(t);
                    ObjectDataSource objds = new ObjectDataSource();
                    objds.BeginUpdate();
                    objds.Name = $"{entity.DataSourceID}_{entity.EntityName}";
                    objds.DataSource = t;
                    objds.DataMember = "GetData";
                    objds.DataSourceType = typeof(BeepDxObjectDataSource);
                    //  DevExpress.DataAccess.ObjectBinding.Parameter[] ls=new DevExpress.DataAccess.ObjectBinding.Parameter[1];
                    //  ls[0]=new DevExpress.DataAccess.ObjectBinding.Parameter("EntityName", typeof(string),entity.EntityName);
                    //  ls[0] = new DevExpress.DataAccess.ObjectBinding.Parameter("Filters", typeof(List<ReportFilter>), null);

                  //  objds.Constructor=new ObjectConstructorInfo(new DevExpress.DataAccess.ObjectBinding.Parameter("Filters", typeof(List<ReportFilter>), null));

                    objds.EndUpdate();
                    DxDataSources.Add(objds);
                  
                   
                    

                    DashboardObjectDataSource dsobjds = new DashboardObjectDataSource();
                    dsobjds.BeginUpdate();
                    dsobjds.Name = $"{entity.DataSourceID}_{entity.EntityName}";
                    dsobjds.DataSource = t;
                    dsobjds.DataMember = "GetData";
                    dsobjds.DataSourceType = typeof(BeepDxObjectDataSource);
                   // dsobjds.Constructor = new ObjectConstructorInfo(new DevExpress.DataAccess.ObjectBinding.Parameter("Filters", typeof(List<ReportFilter>), null));
                    dsobjds.EndUpdate();
                    DxDashboardDataSources.Add(dsobjds);

                    SetParameters(entity.DataSourceID, entity.EntityName, null);
                    objds.Fill();
                    SetParameters(entity.DataSourceID, entity.EntityName, null);
                    dsobjds.Fill();
                  
                }
                else
                {
                    DMEEditor.AddLogMessage("Beep", $"Could not OPEN DataSource for Entity {entity.EntityName}", DateTime.Now, 0, null, Errors.Failed);
                }
            }else
            {
                DMEEditor.AddLogMessage("Beep", $"Could not GET DataSource for Entity {entity.EntityName}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo SetParameters(string pDataSourceName,string pEntityName,List<AppFilter> pReportFilter)
        {
             try
            {
                IDataSource ds = DMEEditor.GetDataSource(pDataSourceName);
              
                if (ds != null)
                {
                    ds.Openconnection();
                    if (ds.ConnectionStatus == System.Data.ConnectionState.Open)
                    {
                        EntityStructure entity = (EntityStructure)ds.GetEntityStructure(pEntityName, true).Clone();
                        ObjectDataSource objds = DxDataSources[DxDataSources.FindIndex(p => p.Name.Equals($"{entity.DataSourceID}_{entity.EntityName}", StringComparison.CurrentCultureIgnoreCase))];
                        DashboardObjectDataSource dsobjds = DxDashboardDataSources[DxDashboardDataSources.FindIndex(p => p.Name.Equals($"{entity.DataSourceID}_{entity.EntityName}", StringComparison.CurrentCultureIgnoreCase))];
                        // var EntityNameparameter = new DevExpress.DataAccess.ObjectBinding.Parameter("EntityName", typeof(string), pEntityName);
                        var FilterNameparameter = new DevExpress.DataAccess.ObjectBinding.Parameter("Filters", typeof(List<AppFilter>), null);
                        objds.Parameters.Clear();
                      //  objds.Parameters.Add(EntityNameparameter);
                        objds.Parameters.Add(FilterNameparameter);
                        dsobjds.Parameters.Clear();
                        //  objds.Parameters.Add(EntityNameparameter);
                        dsobjds.Parameters.Add(FilterNameparameter);
                        // objds.Fill();
                    }
                    else
                    {
                        DMEEditor.AddLogMessage("Beep", $"Could not OPEN DataSource for Entity {pEntityName}", DateTime.Now, 0, null, Errors.Failed);
                    }
                }
                else
                {
                    DMEEditor.AddLogMessage("Beep", $"Could not GET DataSource for Entity {pEntityName}", DateTime.Now, 0, null, Errors.Failed);
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Could not ADD Parameters to Entity {pEntityName}", DateTime.Now, 0, null, Errors.Failed);
            }
          
            return DMEEditor.ErrorObject;
        }
        public bool CheckifEntityExist(string datasourcename, string entityname)
        {
            return DxDataSources.Any(p => p.Name.Equals($"{datasourcename}_{entityname}", StringComparison.CurrentCultureIgnoreCase));
        }
        public bool RemoveEntity(string datasourcename, string entityname)
        {
            ObjectDataSource objds = DxDataSources[DxDataSources.FindIndex(p => p.Name.Equals($"{datasourcename}_{entityname}", StringComparison.CurrentCultureIgnoreCase))];
            return DxDataSources.Remove(objds);
        }
    }
}
