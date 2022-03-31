using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;
using DevExpress.XtraPrintingLinks;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using TheTechIdea;
using TheTechIdea.Beep.AppManager;

namespace Beep.DExpress.SimpleReporting
{
    [AddinAttribute(Caption = "Simple Report Manager", Name = "DxSimpleReporting", misc = "Reporting", addinType = AddinType.Class)]
    public class DxSimpleReporting : IReportDMWriter
    {
        public IAppDefinition Definition { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public bool Html { get ; set ; }
        public bool Text { get ; set ; }
        public bool Csv { get ; set ; }
        public bool PDF { get ; set ; }
        public bool Excel { get ; set ; }
        public string OutputFile { get ; set ; }
        private PrintingSystem printingSystem = new PrintingSystem();

        public IErrorsInfo RunReport(ReportType reportType, string outputFile)
        {
            List<DataGrid> grids = GetDataGrids();
            if (grids.Count == 0)
            {
                for (int i = 0; i < grids.Count-1; i++)
                {
                    DataGridLink dgLink = new DataGridLink();
                    dgLink.DataGrid = grids[0];
                    printingSystem.Links.Add(dgLink);
                    dgLink.ShowPreviewDialog();
                }
            }
            return DMEEditor.ErrorObject;
        }
        private List<DataGrid> GetDataGrids()
        {
            List<DataGrid> grids = new List<DataGrid>();
            try
            {
               
                if (Definition.Blocks.Count > 0)
                {
                    foreach (AppBlock item in Definition.Blocks)
                    {
                        
                        DataTable dt=new DataTable();
                        dt= GetDataTable(item);
                        DataGrid grid=new DataGrid();
                        if (dt.Rows.Count > 0)
                        {
                            grid.DataSource = dt;
                            grid.Refresh();
                            grids.Add(grid);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return grids;
        }
        private DataTable GetDataTable(AppBlock item)
        {
            DataTable dt = null;
            try
            {
                if (item!=null)
                {
                    if (string.IsNullOrEmpty(item.ViewID))
                    {
                        IDataSource dataSource = DMEEditor.GetDataSource(item.ViewID);
                        if (dataSource != null)
                        {
                            dataSource.Openconnection();
                            if(dataSource.ConnectionStatus== ConnectionState.Open)
                            {
                                dt = (DataTable)dataSource.GetEntity(item.EntityID, item.filters);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
