using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Json;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Wizards.ManageDataConnection
{
    public static class DataConnectionManager
    {
        public static List<ConnectionProperties> Conns { get; set; }
        public static DatasourceCategory Category { get; set; }
        public static string Filepath { get; set; }
        public static JsonDataSource dataSource { get; set; }
        public static IDMEEditor iDMEEditor;
        public  static void LoadDataConnections(IDMEEditor dMEEditor)
        {
            iDMEEditor = dMEEditor;
           
            Filepath = System.IO.Path.Combine(iDMEEditor.ConfigEditor.ConfigPath, "DataConnections.json");
            if (File.Exists(Filepath))
            {
                dataSource = new JsonDataSource(Filepath, dMEEditor.Logger, dMEEditor, DataSourceType.Json, dMEEditor.ErrorObject);
                Conns = iDMEEditor.Utilfunction.GetTypedList<ConnectionProperties>(dataSource.Records);
            }
           
        }
        public static void ChangeConnection(ConnectionProperties cn)
        {
            Conns[GetIndex(cn)] = cn;
        }
        public static void DeleteConnection(ConnectionProperties cn)
        {
            Conns.RemoveAt(GetIndex(cn));
        }
        public static void AddConnection(ConnectionProperties cn)
        {
            Conns.Add(cn);
        }
        public static void  UpdateDataSource()
        {
           dataSource.Records=Conns.Cast<object>().ToList();
           dataSource.SaveJsonFile();
        }
        public static int GetIndex(ConnectionProperties cn)
        {
            return Conns.FindIndex(p=>p.GuidID==cn.GuidID);
        }
    }
}
