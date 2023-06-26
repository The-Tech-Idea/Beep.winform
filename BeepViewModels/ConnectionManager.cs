using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace Beep.ViewModels
{
    public static class ConnectionManager
    {
        public static ConnectionState SetupConnection(IDMEEditor DMEEditor, string DatasourceName, PassedArgs e)
        {
            IDataSource ds;
            PassedArgs Passedarg = e;
            ds = DMEEditor.GetDataSource(DatasourceName);
            EntityStructure entityStructure = null;
            Type CurrentType;
            if (ds != null)
            {
                ds.Openconnection();
                //  ds.ConnectionStatus = ds.Dataconnection.ConnectionStatus;
                if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                {
                   string EntityName = e.CurrentEntity;

                    if (e.Objects.Where(c => c.Name == "EntityStructure").Any())
                    {
                        entityStructure = (EntityStructure)e.Objects.Where(c => c.Name == "EntityStructure").FirstOrDefault().obj;
                    }
                    else
                    {
                        entityStructure = ds.GetEntityStructure(EntityName, true);
                        e.Objects.Add(new ObjectItem { Name = "EntityStructure", obj = entityStructure });
                    }
                    if (entityStructure != null)
                    {
                        entityStructure.DataSourceID = DatasourceName;
                        if (entityStructure.Fields != null)
                        {
                            if (entityStructure.PrimaryKeys.Count > 0)
                            {
                                if (entityStructure.Fields.Count > 0)
                                {
                                    listEntities.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                    entityStructure.Filters = new List<AppFilter>();
                                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;

                                    visManager.Controlmanager.CreateEntityFilterControls(entityStructure, defaults, e);
                                }
                                CurrentType = ds.GetEntityType(entityStructure.EntityName);
                            }
                            else
                            {
                                if (ds.Category != DatasourceCategory.RDBMS)
                                {
                                    IsCrudEnabled = true;
                                }
                                else
                                {
                                    IsCrudEnabled = false;
                                    visManager.Controlmanager.MsgBox("Beep", "Cannot Edit a table with no primary keys");
                                }
                                if (entityStructure.Fields.Count > 0)
                                {
                                    listEntities.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                    entityStructure.Filters = new List<AppFilter>();
                                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                                    visManager.Controlmanager.CreateEntityFilterControls(entityStructure, defaults, e);
                                }
                                CurrentType = ds.GetEntityType(entityStructure.EntityName);
                            }
                        }
                    }


                }
            }
            return ds.ConnectionStatus;
        }
        public static List<DefaultValue> Getdefaults(IDMEEditor DMEEditor, string DatasourceName, PassedArgs e)
        {
            IDataSource ds;
            PassedArgs Passedarg = e;
            List<DefaultValue> defaults = null;
            if (SetupConnection(DMEEditor, DatasourceName, e)== ConnectionState.Open)
            {
                ds = DMEEditor.GetDataSource(DatasourceName);
                 defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
            }
            return defaults; 
        }
    }
}
