using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Logger;
using TheTechIdea.Util;


namespace BeepEnterprize.Winform.Vis.Dashboard.LiveChart
{
    public class LiveDashboard : IDM_Addin,IDashboard
    {
        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; }
        public string AddinName { get ; set ; }
        public string Description { get ; set ; }
        public bool DefaultCreate { get ; set ; }
        public string DllPath { get ; set ; }
        public string DllName { get ; set ; }
        public string NameSpace { get ; set ; }
        public IErrorsInfo ErrorObject { get ; set ; }
        public IDMLogger Logger { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public EntityStructure EntityStructure { get ; set ; }
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        public string Name { get ; set ; }
        public List<IAppFilter> Filters { get ; set ; }
        public IDMDataView DataView { get ; set ; }
        public List<IDashboardComponent> Components { get ; set ; }
      //  public List<LiveCharts.Charts.ChartCore> Charts { get ; set ; }

        public event EventHandler<IDashboardComponent> Changed;
        public event EventHandler<IDashboardComponent> ItemSelected;

        public IPassedArgs Add(IDashboardComponent pComponent, List<IChartSeries> pChartSeries)
        {
            throw new NotImplementedException();
        }

        public IPassedArgs Add(List<IChartSeries> pChartSeries, Point pLocation, Size pSize)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IPassedArgs Load(string pathandfilename)
        {
            throw new NotImplementedException();
        }

        public void Run(IPassedArgs pPassedarg)
        {
          
        }

        public IPassedArgs Save(string pathandfilename)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            Passedarg = e;
           
        }
    }
}
