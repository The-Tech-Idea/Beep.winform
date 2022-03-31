using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.MapEntities
{
    public class MapEntitiesManager : IDM_Addin
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

        VisManager visManager;
        IDataSource ds;

        public void Run(IPassedArgs pPassedarg)
        {
            visManager.Container.Controls.Clear();
          //  visManager.Container.Controls.Add(listEntities);
          //  listEntities.Dock = System.Windows.Forms.DockStyle.Fill;
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
            SetupConnection(e.DatasourceName, (PassedArgs)e);
        }
        public void SetupConnection(string DatasourceName, PassedArgs e)
        {
            Passedarg = e;
            ds = DMEEditor.GetDataSource(DatasourceName);
            ds.Openconnection();
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
                              //  listEntities.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                EntityStructure.Filters = new List<AppFilter>();
                                List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                                visManager.Controlmanager.CreateEntityFilterControls(EntityStructure, defaults);
                            }
                          //  CurrentType = ds.GetEntityType(EntityStructure.EntityName);
                        }
                        else
                        {
                            if (ds.Category != DatasourceCategory.RDBMS)
                            {
                                if (EntityStructure.Fields.Count > 0)
                                {
                                  //  listEntities.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                    EntityStructure.Filters = new List<AppFilter>();
                                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                                    visManager.Controlmanager.CreateEntityFilterControls(EntityStructure, defaults);
                                }
                              //  CurrentType = ds.GetEntityType(EntityStructure.EntityName);
                            }
                            else
                            {
                                visManager.Controlmanager.MsgBox("Beep", "Cannot Edit a table with no primary keys");
                            }

                        }
                    }
                }


            }
        }
    }
}
