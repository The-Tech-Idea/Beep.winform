using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.Report;

namespace BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard
{
    public class MsChartComponent : IDashboardComponent
    {
        public MsChartComponent(IDMEEditor pDMEEditor)
        {
            DMEEditor=pDMEEditor;
        }
        public string Name { get ; set ; }
        public string Description { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public List<AppFilter> Filters { get ; set ; }=new List<AppFilter>();
        public IDashboard Dashboard { get ; set ; }
        public List<IChartSeries> ChartSeries { get; set; }=new List<IChartSeries>();
        public string EntityName { get ; set ; }
        public string DataSourceName { get; set; }
        public int Left { get ; set ; }
        public int Top { get ; set ; }
        public int Width { get ; set ; }
        public int Height { get ; set ; }

        private IDataSource ds;
       
        
        public event EventHandler<IDashboardComponent> Changed;
        public event EventHandler<IDashboardComponent> ItemSelected;
        public event EventHandler<IDashboardComponent> DrawFinish;
        public event EventHandler<IDashboardComponent> UpdateTick;
        public event EventHandler<IDashboardComponent> Hover;
        public event EventHandler<IDashboardComponent> RangeChanged;
        private bool IsCreated = false;
        private bool IsDrawn = false;
        private Control DrawBack = new Control();
        public Chart ChartComponent { get; set; }


        public IPassedArgs Draw(string pDatasourceName,string pEntityName, int pleft, int ptop, int pwidth, int pheight, List<AppFilter> pFilters, IPassedArgs args)
        {
            if (!string.IsNullOrEmpty(pEntityName) && !string.IsNullOrEmpty(pDatasourceName))
            {
                EntityName = EntityName.Trim();
                DataSourceName = DataSourceName.Trim();
                Filters = pFilters;
                //if (args.Objects.Where(c => c.Name == "IChartSeries").Any())
                //{
                //    ChartSeries = (List<IChartSeries>)args.Objects.Where(c => c.Name == "IChartSeries").FirstOrDefault().obj;
                //}
                if (args.Objects.Where(c => c.Name == "Control").Any())
                {
                    DrawBack = (Control)args.Objects.Where(c => c.Name == "Control").FirstOrDefault().obj;
                }
                try
                {
                    ds = DMEEditor.GetDataSource(pDatasourceName);
                    if (ds == null)
                    {
                        DMEEditor.AddLogMessage("Beep", $"Could not Find DataSource {DataSourceName}", DateTime.Now, 0, pEntityName, TheTechIdea.Util.Errors.Failed);
                        return (IPassedArgs)DMEEditor.ErrorObject;
                    }
                    ds.Openconnection();
                    if (ds.ConnectionStatus == System.Data.ConnectionState.Closed)
                    {
                        DMEEditor.AddLogMessage("Beep", $"Could not Open DataSource {DataSourceName}", DateTime.Now, 0, pEntityName, TheTechIdea.Util.Errors.Failed);
                        return (IPassedArgs)DMEEditor.ErrorObject;
                    }
                    if (!IsCreated)
                    {
                        ChartComponent = new Chart();
                        IsCreated = true;
                    }
                    
                    ChartComponent.Name = $"{EntityName}_{DataSourceName}";
                    if(ChartSeries != null)
                    {
                        if(ChartSeries[0].SeriesData != null)
                        {
                            ChartComponent.Series.Clear();
                            Series s = new Series() { ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ChartSeries[0].SeriesType) };
                            ChartComponent.DataSource = ChartSeries[0];
                            s.XValueMember = ChartSeries[0].XAxes[0];
                            s.YValueMembers = ChartSeries[0].YAxes[0];
                            ChartComponent.Series.Add(s);
                        }
                        else
                        {
                            DMEEditor.AddLogMessage("Beep", $"Could not Find Data in DataSource {DataSourceName}", DateTime.Now, 0, pEntityName, TheTechIdea.Util.Errors.Failed);
                            return (IPassedArgs)DMEEditor.ErrorObject;
                        }
                            
                        //------------------ Draw Chart on DrawBack Control ------------
                        
                        //-- 
                        ChartComponent.Left = pleft;
                        ChartComponent.Top = ptop;
                        ChartComponent.Width = pwidth;
                        ChartComponent.Height = pheight;
                        ChartComponent.Titles.Clear();
                        ChartComponent.Titles.Add(ChartSeries[0].SeriesName);
                        if (!IsDrawn)
                        {
                            DrawBack.Controls.Add(ChartComponent);
                            IsDrawn = true;
                        }
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    DMEEditor.AddLogMessage("Beep", $"Error Drawing Chart for {EntityName}-{ex.Message}", DateTime.Now, 0, pEntityName, TheTechIdea.Util.Errors.Failed);

                }
            }else
                DMEEditor.AddLogMessage("Beep", $"Missing DataSourceName or EntityName for  Drawing Chart", DateTime.Now, 0, pEntityName, TheTechIdea.Util.Errors.Failed);


            return (IPassedArgs)DMEEditor.ErrorObject;
        }
        private object LoadChartData()
        {
            return ds.GetEntity(EntityName, Filters);
        }

        public IPassedArgs ApplyFilter(List<IAppFilter> pFilters)
        {
            throw new NotImplementedException();
        }
    }
}
