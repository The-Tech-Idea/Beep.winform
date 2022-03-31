using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;

namespace BeepEnterprize.Winform.Vis.Dashboard
{
    public interface IDashboard
    {
        string Name { get; set; }
        string Description { get; set; }
        [JsonIgnore]
        IDMEEditor DMEEditor { get; set; }
        List<IAppFilter> Filters { get; set; }
        IDMDataView DataView { get; set; }
        List<IDashboardComponent> Components { get; set; }
        
        event EventHandler<IDashboardComponent> Changed;
        event EventHandler<IDashboardComponent> ItemSelected;

        IPassedArgs DrawDashboard(IDMDataView pDataView, List<IAppFilter> pFilters );
        IPassedArgs Add(List<IChartSeries> pChartSeries, Point pLocation,Size pSize);
        IPassedArgs ApplyFilter(IDashboardComponent pComponent, List<IAppFilter> pFilters);
        IPassedArgs ApplyFilter( List<IAppFilter> pFilters);
        IPassedArgs Save(string pathandfilename);
        IPassedArgs Load(string pathandfilename);

    }
}
