using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Report;
using GeoMap = LiveChartsCore.SkiaSharpView.WinForms.GeoMap;
using LiveChartsCore.Geo;

namespace BeepEnterprize.Winform.Vis.Dashboard.LiveChart
{
    public class LiveComponent : IDashboardComponent
    {
        public LiveComponent()
        {
           
          
        }
        public string Name { get ; set ; }
        public string Description { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public List<AppFilter> Filters { get ; set ; }
        public string EntityName { get ; set ; }
        public IDashboard Dashboard { get; set; }
        public List<IChartSeries> ChartSeries { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public event EventHandler<IDashboardComponent> Changed;
        public event EventHandler<IDashboardComponent> ItemSelected;
        public event EventHandler<IDashboardComponent> DrawFinish;

        public event EventHandler<IDashboardComponent> UpdateTick;
        public event EventHandler<IDashboardComponent> Hover;
        public event EventHandler<IDashboardComponent> RangeChanged;
        public IEnumerable<ISeries> SeriesCollection { get; set; }
        public IEnumerable<IMapElement> MapSeries { get; set; }
        public IEnumerable<Axis> Yaxes { get; set; }
        public IEnumerable<Axis> Xaxes { get; set; }
        public Chart Chart { get; set; }
        public GeoMap Map { get; set; }

        public List<string> SeriesNames { get; set; }

        public IPassedArgs Draw(string pDatasourceName, string pEntityName,int pleft,int ptop,int pwidth,int pheight, List<AppFilter> pFilters,IPassedArgs args)
        {

            if (!string.IsNullOrEmpty(pEntityName))
            {
                Left = pleft;
                Top = ptop;
                Width = pwidth;
                Height = pheight;
                if (pFilters != null)
                {
                    Filters = pFilters;
                }

                if (args.Objects.Where(c => c.Name == "SeriesCollection").Any())
                {
                    SeriesCollection = (IEnumerable<ISeries>)args.Objects.Where(c => c.Name == "SeriesCollection").FirstOrDefault().obj;
                }
                if (args.Objects.Where(c => c.Name == "MapElements").Any())
                {
                    MapSeries = (IEnumerable<IMapElement>)args.Objects.Where(c => c.Name == "MapElements").FirstOrDefault().obj;
                }
                if (args.Objects.Where(c => c.Name == "XAxes").Any())
                {
                    Xaxes = (IEnumerable<Axis>)args.Objects.Where(c => c.Name == "XAxes").FirstOrDefault().obj;
                }
                if (args.Objects.Where(c => c.Name == "YAxes").Any())
                {
                    Yaxes = (IEnumerable<Axis>)args.Objects.Where(c => c.Name == "YAxes").FirstOrDefault().obj;
                }
                if (!string.IsNullOrEmpty(args.Category))
                {
                    switch (args.Category)
                    {
                        case "Heat":
                            try
                            {
                                Chart = new CartesianChart()
                                {
                                    Series = SeriesCollection,
                                    XAxes = Xaxes,
                                    YAxes = Yaxes,
                                    LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                                    Width = pwidth,
                                    Height = pheight,
                                    Location = new System.Drawing.Point(pleft, ptop),
                                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
                                };
                                DMEEditor.AddLogMessage("Beep", $"Successfuly Created Cartesian Chart ", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
                            }
                            catch (Exception ex)
                            {
                                DMEEditor.AddLogMessage("Beep", $"Error Creating Cartesian Chart {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
                            }

                            break;
                        case "Candle":
                            try
                            {
                                Chart = new CartesianChart()
                                {
                                    Series = SeriesCollection,
                                    XAxes = Xaxes,
                                    LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                                    Width = pwidth,
                                    Height = pheight,
                                    Location = new System.Drawing.Point(pleft, ptop),
                                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
                                };
                                DMEEditor.AddLogMessage("Beep", $"Successfuly Created Cartesian Chart ", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
                            }
                            catch (Exception ex)
                            {
                                DMEEditor.AddLogMessage("Beep", $"Error Creating Cartesian Chart {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
                            }
                            break;
                        case "StackedArea":
                        case "StackedBar":
                        case "Scatter":
                        case "Bar":
                        case "StepLine":
                        case "Line":
                            try
                            {
                                Chart = new CartesianChart()
                                {
                                    Series = SeriesCollection,
                                    LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                                    Width = pwidth,
                                    Height = pheight,
                                    Location = new System.Drawing.Point(pleft, ptop),
                                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
                                };
                                DMEEditor.AddLogMessage("Beep", $"Successfuly Created Cartesian Chart ", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
                            }
                            catch (Exception ex)
                            {
                                DMEEditor.AddLogMessage("Beep", $"Error Creating Cartesian Chart {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
                            }
                            break;
                        case "GeoMap":
                            try
                            {
                                Map = new GeoMap()
                                {
                                    Shapes = MapSeries,
                                    MapProjection = LiveChartsCore.Geo.MapProjection.Mercator,
                                    Width = pwidth,
                                    Height = pheight,
                                    Location = new System.Drawing.Point(pleft, ptop),
                                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
                                };

                                DMEEditor.AddLogMessage("Beep", $"Successfuly Created GeoMap Chart ", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
                            }
                            catch (Exception ex)
                            {
                                DMEEditor.AddLogMessage("Beep", $"Error Creating GeoMap Chart {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
                            }

                            break;
                        case "Pie":
                            try
                            {
                                Chart = new PieChart()
                                {
                                    Series = SeriesCollection,
                                    LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                                    Width = pwidth,
                                    Height = pheight,
                                    Location = new System.Drawing.Point(pleft, ptop),
                                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
                                };
                                DMEEditor.AddLogMessage("Beep", $"Successfuly Created Pie Chart ", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
                            }
                            catch (Exception ex)
                            {
                                DMEEditor.AddLogMessage("Beep", $"Error Creating Pie Chart {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
                            }
                            break;

                    }
                }
            

            
            }
         
            return args;
           
        }

        public IPassedArgs ApplyFilter(List<IAppFilter> pFilters)
        {
            throw new NotImplementedException();
        }
    }
}