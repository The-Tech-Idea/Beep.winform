using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Report;

namespace BeepEnterprize.Winform.Vis.Dashboard
{
    public interface IDashboardComponent
    {
        string Name { get; set; }    
        string Description { get; set; }
        [JsonIgnore]
        IDMEEditor DMEEditor { get; set; }
        List<AppFilter> Filters { get; set; }
        IDashboard Dashboard { get; set; }
        List<IChartSeries> ChartSeries { get; set; }
        
        string EntityName { get; set; }
        int Left { get; set; }
        int Top { get; set; }
        int Width { get; set; }
        int Height { get; set; }

        event EventHandler<IDashboardComponent> Changed;
        event EventHandler<IDashboardComponent> ItemSelected;
        event EventHandler<IDashboardComponent> DrawFinish;
        event EventHandler<IDashboardComponent> UpdateTick;
        event EventHandler<IDashboardComponent> Hover;
        event EventHandler<IDashboardComponent> RangeChanged;
        IPassedArgs Draw(string pDatasourceName, string pEntityName, int pleft, int ptop, int pwidth, int pheight, List<AppFilter> pFilters, IPassedArgs args);
        IPassedArgs ApplyFilter(List<IAppFilter> pFilters);

    }
}
