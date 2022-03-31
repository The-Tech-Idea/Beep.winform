using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;

namespace BeepEnterprize.Winform.Vis.Dashboard.LiveChart.ViewModel
{
    public class ChartViewModel
    {
       
        public IEnumerable<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();
        public IEnumerable<Axis> YAxes { get; set; }
        public List<Axis> XAxes { get; set; }

    }
    public class LogarithmicPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
