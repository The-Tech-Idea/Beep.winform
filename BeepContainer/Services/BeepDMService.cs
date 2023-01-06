using System;
using System.Data;
using System.Linq;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.Containers.Models;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Workflow;
using TheTechIdea.Logger;
using TheTechIdea.Tools;
//using TheTechIdea.Tools.AssemblyHandling;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.Containers.Services
{
    public class BeepDMService : IBeepDMService
    {
        #region "System Components"

        public IDMEEditor DMEEditor { get; set; }
        public IConfigEditor Configeditor { get; set; }
        public IWorkFlowEditor WorkFlowEditor { get; set; }
        public IDMLogger Logger { get; set; }
        public IUtil Util { get; set; }
        public IErrorsInfo Erinfo { get; set; }
        public IJsonLoader JsonLoader { get; set; }
        public IAssemblyHandler LLoader { get; set; }
        public IClassCreator ClassCreator { get; set; }
        public IDataTypesHelper TypesHelper { get; set; }
        public IETL eTL { get; set; }

        #endregion

      
        private BeepContainer beepContainer;
       
        public BeepDMService(BeepContainer pBeepContainer)
        {
            beepContainer = pBeepContainer;
           
          
            ConfigureServices();

        }
        public IDataSource CreateConnection(string ConnName)
        {
            try
            {
                IDataSource src;
                string connname = $"{ConnName}_{DataSourceType.Oracle.ToString()}";
                AddConnection(connname, DataSourceType.Oracle);
                src = DMEEditor.GetDataSource(connname);
                src.Openconnection();
                return src;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public bool AddConnection(string pConnectionName, DataSourceType dataSourceType)
        {
            bool retval = true;
            ConnectionProperties connection;
            ConnectionProperties cn = DMEEditor.ConfigEditor.DataConnections.Where(o => o.ConnectionName.Equals(pConnectionName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            DMEEditor.ConfigEditor.DataConnections.Remove(cn);
            ConnectionDriversConfig configdr = DMEEditor.ConfigEditor.DataDriversClasses.Where(p => p.DatasourceType == dataSourceType).FirstOrDefault();
            if (!DMEEditor.ConfigEditor.DataConnections.Where(o => o.ConnectionName.Equals(pConnectionName, StringComparison.OrdinalIgnoreCase)).Any())
            {
                //ConnectionProperties cn = DMEEditor.ConfigEditor.DataConnections.Where(o => o.ConnectionName.Equals(pConnectionName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                //DMEEditor.ConfigEditor.DataConnections.Remove(cn);
                if (configdr != null)
                {
                    connection = new ConnectionProperties()
                    {
                        Category = DatasourceCategory.RDBMS,
                        ConnectionName = pConnectionName,
                        Database = "xe",
                        UserID = "kocuser",
                        Password = "xyz",
                        Host = "localhost",
                        Port = 1521,
                        DatabaseType = dataSourceType,
                        ConnectionString = configdr.ConnectionString,
                        DriverName = configdr.DriverClass,
                        DriverVersion = configdr.version
                    };
                    DMEEditor.ConfigEditor.AddDataConnection(connection);
                    DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                }
                else
                    retval = false;
            }
            return retval;
        }

        #region "Beep Setup"
        public void ConfigureServices()
        {
          //  CreateBeepEnv();
          

        }
        //private bool CreateBeepEnv()
        //{
        //    try
        //    {
        //        Logger = new DMLogger();
        //        JsonLoader = new JsonLoader();
        //        Util = new Util(Logger, Erinfo, Configeditor);
        //        Erinfo = new ErrorsInfo();
        //        TypesHelper = new DataTypesHelper(Logger, Erinfo);
        //        Configeditor = new ConfigEditor(Logger, Erinfo, JsonLoader);
        //        eTL = new ETL();
        //        WorkFlowEditor = new WorkFlowEditor();
        //        ClassCreator = new ClassCreator();
        //        DMEEditor = new DMEEditor(Logger,Util,Erinfo, Configeditor, WorkFlowEditor,ClassCreator,eTL,LLoader,TypesHelper);
        //        LLoader = new AssemblyHandlerCore(Configeditor, Erinfo, Logger, Util);
        //        LLoader.LoadAllAssembly();
        //        Configeditor.LoadedAssemblies = LLoader.Assemblies.Select(c => c.DllLib).ToList();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

      

        #endregion
    }
}
