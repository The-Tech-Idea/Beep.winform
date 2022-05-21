using Beep.Winform.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Util;

namespace Dhub3.DataServices
{
    public class Dhub3DataServices
    {
        public Dhub3DataServices(DMEEditor editor,string dhubdbname,string edmdbname,string esearchdbname,string almsdbname)
        {
            DMeditor = editor;
            Dhubdbname = dhubdbname;
            Edmdbname = edmdbname;
            Esearchdbname = esearchdbname;
            Almsdbname = almsdbname;
            
        }
        public IDMEEditor DMeditor { get; set; }
       
        /// <summary>
        /// REsource Loading Manager
        /// </summary>
        public ResourceManager ResourceManager { get; set; }
        #region "Connection Handling"
        /// <summary>
        /// Data source Properties
        /// </summary>
        public string Dhubdbname { get; }
        public string Edmdbname { get; }
        public string Esearchdbname { get; }
        public string Almsdbname { get; }
        public RDBSource Dhubdb { get; set; }
        public RDBSource Edmdb { get; set; }
        public RDBSource Esearchdb { get; set; }
        public RDBSource Almsdb { get; set; }
        /// <summary>
        /// Method for Createing or getting existing Connections
        /// </summary>
        /// <param name="dbname"></param>
        /// <returns></returns>
        ///
        public IErrorsInfo CreateGetConnectionsDigitalHub()
        {
            DMeditor.ErrorObject.Ex = null;
            DMeditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                Dhubdb = CreateGetConnection(Dhubdbname);
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMeditor.ErrorObject;
        }
        public IErrorsInfo CreateGetConnectionsEDM()
        {
            DMeditor.ErrorObject.Ex = null;
            DMeditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                Edmdb = CreateGetConnection(Edmdbname);
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMeditor.ErrorObject;
        }
        public IErrorsInfo CreateGetConnectionsEsearch()
        {
            DMeditor.ErrorObject.Ex = null;
            DMeditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                Esearchdb = CreateGetConnection(Esearchdbname);
              
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMeditor.ErrorObject;
        }
        public IErrorsInfo CreateGetConnectionsAlms()
        {
            DMeditor.ErrorObject.Ex = null;
            DMeditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                Almsdb = CreateGetConnection(Almsdbname);
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMeditor.ErrorObject;
        }
        public IErrorsInfo CreateGetConnections()
        {
            try
            {
                Dhubdb = CreateGetConnection(Dhubdbname);
                Edmdb = CreateGetConnection(Edmdbname);
                Esearchdb = CreateGetConnection(Esearchdbname);
                Almsdb = CreateGetConnection(Almsdbname);
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMeditor.ErrorObject;
        }
        public RDBSource CreateGetConnection(string dbname)
        {
            RDBSource ds = null;
            try
            {
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;

                if (DMeditor.CheckDataSourceExist(dbname))
                {
                    ds = (RDBSource)DMeditor.GetDataSource(dbname);

                }
                else
                {
                    ds = CreateDB(dbname);
                }
                if(ds == null)
                {
                    DMeditor.ErrorObject.Ex = null;
                    DMeditor.ErrorObject.Flag = Errors.Failed;
                }
                else
                {
                    DMeditor.ErrorObject.Ex = null;
                    DMeditor.ErrorObject.Flag = Errors.Ok;
                }
               
            }
            catch (Exception ex)
            {

                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);

            }
            return ds;
        }
        public RDBSource CreateDB(string dbname)
        {
            DMeditor.ErrorObject.Ex = null;
            DMeditor.ErrorObject.Flag = Errors.Ok;
            RDBSource ds = new RDBSource(dbname, DMeditor.Logger, DMeditor, DataSourceType.Oracle, DMeditor.ErrorObject);
            try
            {
                if (dbname == Dhubdbname)
                {
                   
                     ds = new RDBSource(dbname, DMeditor.Logger, DMeditor, DataSourceType.Oracle, DMeditor.ErrorObject);
                    ds.RDBMSConnection.ConnectionProp.Host = "";
                    ds.RDBMSConnection.ConnectionProp.SchemaName = "";
                    ds.RDBMSConnection.ConnectionProp.UserID = "";
                    ds.RDBMSConnection.ConnectionProp.Password = "";
                    ds.RDBMSConnection.ConnectionProp.Database = "";
                    ds.RDBMSConnection.ConnectionProp.DatabaseType = DataSourceType.Oracle;

                }
                if (dbname == Edmdbname)
                {
                    ds = new RDBSource(dbname, DMeditor.Logger, DMeditor, DataSourceType.Oracle, DMeditor.ErrorObject);
                    ds.RDBMSConnection.ConnectionProp.Host = "";
                    ds.RDBMSConnection.ConnectionProp.SchemaName = "";
                    ds.RDBMSConnection.ConnectionProp.UserID = "";
                    ds.RDBMSConnection.ConnectionProp.Password = "";
                    ds.RDBMSConnection.ConnectionProp.Database = "";
                    ds.RDBMSConnection.ConnectionProp.DatabaseType = DataSourceType.Oracle;
                   
                }
                if (dbname == Esearchdbname)
                {
                    ds = new RDBSource(dbname, DMeditor.Logger, DMeditor, DataSourceType.Oracle, DMeditor.ErrorObject);
                    ds.RDBMSConnection.ConnectionProp.Host = "";
                    ds.RDBMSConnection.ConnectionProp.SchemaName = "";
                    ds.RDBMSConnection.ConnectionProp.UserID = "";
                    ds.RDBMSConnection.ConnectionProp.Password = "";
                    ds.RDBMSConnection.ConnectionProp.Database = "";
                    ds.RDBMSConnection.ConnectionProp.DatabaseType = DataSourceType.Oracle;
                    
                }
                if (dbname == Almsdbname)
                {
                    ds = new RDBSource(dbname, DMeditor.Logger, DMeditor, DataSourceType.SqlServer, DMeditor.ErrorObject);
                    ds.RDBMSConnection.ConnectionProp.Host = "";
                    ds.RDBMSConnection.ConnectionProp.SchemaName = "";
                    ds.RDBMSConnection.ConnectionProp.UserID = "";
                    ds.RDBMSConnection.ConnectionProp.Password = "";
                    ds.RDBMSConnection.ConnectionProp.Database = "";
                    ds.RDBMSConnection.ConnectionProp.DatabaseType = DataSourceType.SqlServer;
                    
                }
                
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                return null;

            }
            return ds;
        }
        #endregion  "Connection Handling"


    }
}
