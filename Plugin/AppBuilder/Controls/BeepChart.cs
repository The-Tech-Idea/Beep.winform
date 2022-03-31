using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.Controls
{
    [AddinAttribute(Caption = "Chart", Name = "BeepChart", misc = "BeepChart", addinType = AddinType.Class, iconimage = "Chart.png")]
    public class BeepChart : IAppComponent, IBeepControlInterface
    {
        public BeepChart()
        {
            ComponentName = "BeepChart";
            ID = new Guid().ToString();
            ComponentType = (new Chart()).GetType().AssemblyQualifiedName;
        }

        public string ID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public bool IsContainer { get; set; } = false;
        public PanelControl Panelcontrol { get ; set ; }
        public bool IsTableView { get; set; } = false;
        [JsonIgnore]
        public DMEEditor DMEEditor { get; set; }
        [JsonIgnore]
        public ScreenDesigner ScreenDesigner { get; set; }
        Chart chart;
        public IErrorsInfo Bind(IPassedArgs args)
        {
            chart = (Chart)Panelcontrol.BeepControl;

            try
            {
                if (chart != null)
                {
                    if (args != null)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Bind  {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }

        public IErrorsInfo ChangeVisual(IPassedArgs args)
        {
            chart = (Chart)Panelcontrol.BeepControl;

            try
            {
                if (chart != null)
                {
                    if (args != null)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Change Visual  {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }

        public IErrorsInfo Init(IPassedArgs args)
        {
            chart = (Chart)Panelcontrol.BeepControl;

            try
            {
                if (chart != null)
                {
                    // set up some data
                    var xvals = new[]
                        {
                    new DateTime(2012, 4, 4),
                    new DateTime(2012, 4, 5),
                    new DateTime(2012, 4, 6),
                    new DateTime(2012, 4, 7)
                };
                    var yvals = new[] { 1, 3, 7, 12 };

                    // create the chart
                   
                    chart.Size = new Size(150, 150);

                    var chartArea = new ChartArea();
                    chartArea.AxisX.LabelStyle.Format = "dd/MMM\nhh:mm";
                    chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                    chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
                    chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
                    chart.ChartAreas.Add(chartArea);

                    var series = new Series();
                    series.Name = "Series1";
                    series.ChartType = SeriesChartType.FastLine;
                    series.XValueType = ChartValueType.DateTime;
                    chart.Series.Add(series);

                    // bind the datapoints
                    chart.Series["Series1"].Points.DataBindXY(xvals, yvals);

                    // copy the series and manipulate the copy
                    chart.DataManipulator.CopySeriesValues("Series1", "Series2");
                    chart.DataManipulator.FinancialFormula(
                        FinancialFormula.WeightedMovingAverage,
                        "Series2"
                    );
                    chart.Series["Series2"].ChartType = SeriesChartType.FastLine;

                    // draw!
                    chart.Invalidate();

                    if (args != null)
                        {
                            chart.Text = args.CurrentEntity;
                        }
                        else
                            chart.Text = "Beep";
                }
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in init Button {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }
    }
}
