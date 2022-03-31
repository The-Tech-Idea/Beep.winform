using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeepEnterprize.Winform.Vis.Dashboard
{
    public interface IChartSeries
    {
        string SeriesType { get; set; }
        // ignored
        [JsonIgnore]
        List<Object> SeriesData { get; set; }
        string SeriesName { get; set; }
        List<string> XAxes { get; set; }
        List<string> YAxes { get; set; }
    }
}
