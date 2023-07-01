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
        public static IErrorsInfo OpenConnection(IDMEEditor DMEEditor, string DatasourceName)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            DMEEditor.ErrorObject.Message = null;
            try
            {
                IDataSource ds;

                ds = DMEEditor.GetDataSource(DatasourceName);
                if (ds != null)
                {
                    ds.Openconnection();

                    if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                    {
                        DMEEditor.ErrorObject.Flag = Errors.Ok;
                    }
                    else
                        DMEEditor.AddLogMessage("Beep", $"Could not Connect to  DataSource  {DatasourceName}", DateTime.Now, 0, null, Errors.Failed);
                }
                else
                    DMEEditor.AddLogMessage("Beep", $"Could not Find DataSource  {DatasourceName}", DateTime.Now, 0, null, Errors.Failed);


            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Beep", $"Error And Failure not Connect to  DataSource  {DatasourceName}- {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }

            return DMEEditor.ErrorObject;

        }
        public static ConnectionState SetupEntityConnection(IDMEEditor DMEEditor, string DatasourceName,string entityname,EntityStructure entityStructure = null)
        {
            IDataSource ds;
         
            ds = DMEEditor.GetDataSource(DatasourceName);
          
            Type CurrentType;
            if (ds != null)
            {
                ds.Openconnection();
               
                if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                {
                   string EntityName = entityname;

                    if (entityStructure == null)
                    {
                     
                        entityStructure = ds.GetEntityStructure(EntityName, false);
                      
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
                                    CurrentType = ds.GetEntityType(entityStructure.EntityName);
                                }
                             
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
            DMEEditor.ErrorObject.Message = null;
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            List<DefaultValue> defaults = null;
            try
            {
                ConnectionProperties cn = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == DatasourceName)];
                if (cn != null)
                {
                    defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == DatasourceName)].DatasourceDefaults;
                }
                else DMEEditor.AddLogMessage("Beep", $"Could not Find DataSource  {DatasourceName}", DateTime.Now, 0, null, Errors.Failed);
               
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Beep", $"Could not Save DataSource Defaults Values {DatasourceName}- {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
              
            }
            return defaults;

        }
        public static IErrorsInfo Savedefaults(IDMEEditor DMEEditor, List<DefaultValue> defaults, string DatasourceName)
        {
            DMEEditor.ErrorObject.Message = null;
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            try
            {

                ConnectionProperties cn = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == DatasourceName)];
                if (cn != null)
                {
                    cn.DatasourceDefaults = defaults;
                    DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                }
                else DMEEditor.AddLogMessage("Beep", $"Could not Find DataSource  {DatasourceName}", DateTime.Now, 0, null, Errors.Failed);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Beep", $"Could not Save DataSource Defaults Values {DatasourceName}- {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }

            return DMEEditor.ErrorObject;
        }
    }
}
