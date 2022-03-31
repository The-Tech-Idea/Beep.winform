using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Report;


namespace BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard
{
    public class MsChartDashBoard:IDashboard
    {
        public MsChartDashBoard(IDMEEditor pDMEEditor)
        {
            DMEEditor = pDMEEditor;
        }

        public string Name { get ; set ; }
        public string Description { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public List<IAppFilter> Filters { get ; set ; }
        public IDMDataView DataView { get ; set ; }
        public List<IDashboardComponent> Components { get ; set ; }=new List<IDashboardComponent>();

        public event EventHandler<IDashboardComponent> Changed;
        public event EventHandler<IDashboardComponent> ItemSelected;

        private DataViewDataSource dataViewDataSource;
        public List<string>  ChartTypes { get { return Enum.GetNames(typeof(SeriesChartType)).ToList(); } }
        public IPassedArgs Add(List<IChartSeries> pChartSeries, Point pLocation, Size pSize)
        {
            IDashboardComponent pComponent = new  MsChartComponent(DMEEditor);
            pComponent.ChartSeries = pChartSeries;
            pComponent.Left = pLocation.X;
            pComponent.Top = pLocation.Y;
            pComponent.Width = pSize.Width;
            pComponent.Height = pSize.Height;
            
            Components.Add(pComponent);
            return (IPassedArgs)DMEEditor.ErrorObject;
        }

        public IPassedArgs ApplyFilter(IDashboardComponent pComponent, List<IAppFilter> pFilters)
        {
            throw new NotImplementedException();
        }

        public IPassedArgs ApplyFilter(List<IAppFilter> pFilters)
        {
            throw new NotImplementedException();
        }

        public IPassedArgs DrawDashboard(IDMDataView pDataView, List<IAppFilter> pFilters)
        {
           if(pDataView == null)
           {
                DMEEditor.AddLogMessage("Beep", $"DataView {pDataView.ViewName} is Null", DateTime.Now, 0, pDataView.ViewName, TheTechIdea.Util.Errors.Failed);
                return (IPassedArgs)DMEEditor.ErrorObject;
           }
            if (pDataView.Entities.Count == 0)
            {
                DMEEditor.AddLogMessage("Beep", $"DataView {pDataView.ViewName} is Dont have any Entities", DateTime.Now, 0, pDataView.ViewName, TheTechIdea.Util.Errors.Failed);
                return (IPassedArgs)DMEEditor.ErrorObject;
            }
            if(Components.Count == 0)
            {
                DMEEditor.AddLogMessage("Beep", $"No Components in Dashboard", DateTime.Now, 0, pDataView.ViewName, TheTechIdea.Util.Errors.Failed);
                return (IPassedArgs)DMEEditor.ErrorObject;
            }
            try
            {
                DataView=pDataView;
                dataViewDataSource= (DataViewDataSource)DMEEditor.GetDataSource(DataView.DataViewDataSourceID);
                dataViewDataSource.Openconnection();
                if(dataViewDataSource.ConnectionStatus!= System.Data.ConnectionState.Open)
                {
                    DMEEditor.AddLogMessage("Beep", $"DataSource DataView {pDataView.ViewName} Could not be opend", DateTime.Now, 0, pDataView.ViewName, TheTechIdea.Util.Errors.Failed);
                    return (IPassedArgs)DMEEditor.ErrorObject;
                }
                dataViewDataSource.GetEntitesList();
                List<EntityStructure> cr = DataView.Entities.Where(cx => cx.ParentId == 0).ToList();
                int i = 0;
                foreach (EntityStructure tb in cr)
                {
                    if (string.IsNullOrEmpty(tb.DatasourceEntityName))
                    {
                        DataView.Entities[dataViewDataSource.EntityListIndex(tb.EntityName)].DatasourceEntityName = tb.EntityName;
                    }


                    i += 1;
                }
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Beep", $"Error in Creating Dashboard based on DataView {pDataView.ViewName} - {ex.Message}", DateTime.Now, 0, pDataView.ViewName, TheTechIdea.Util.Errors.Failed);
            }
            return (IPassedArgs)DMEEditor.ErrorObject;
        }
        private object LoadChartData(EntityStructure ent)
        {
            return dataViewDataSource.GetEntity(ent.EntityName, ent.Filters);
        }

        public IPassedArgs Save(string pathandfilename)
        {
           // string path = Path.Combine(ConfigPath, "QueryList.json");
            DMEEditor.ConfigEditor.JsonLoader.Serialize(pathandfilename, Components);
            return DMEEditor.Passedarguments;
        }

        public IPassedArgs Load(string pathandfilename)
        {
            //string path = Path.Combine(pathandfilename, "QueryList.json");
            Components = DMEEditor.ConfigEditor.JsonLoader.DeserializeObject<IDashboardComponent>(pathandfilename);
            return   DMEEditor.Passedarguments; ;
        }
    }
}
