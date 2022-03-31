using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.DExpress.Common;
using BeepEnterprize.Vis.Module;
using DevExpress.DashboardCommon;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace Beep.DExpress.DxDashboard
{
    [AddinAttribute(Caption = "Dx DashBoard Designer", Name = "DxDashboardDesigner", misc = "Reporting", addinType = AddinType.Control)]
    public partial class uc_DxDashBoardDesigner : UserControl, IDM_Addin
    {
        public uc_DxDashBoardDesigner()
        {
            InitializeComponent();
        }
        public string ParentName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string AddinName { get; set; }
        public string Description { get; set; }
        public bool DefaultCreate { get; set; }
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        IVisManager Vismanager;
        IBranch RootBranch;
        IBranch branch;
        DxDataSourceInfo datasSourceInfo;
        public ReportDataManager reportOutput { get; set; }
        public IAppDefinition ReportDefinition { get; set; }
        DataSet ds;
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            Passedarg = e;
            Logger = plogger;
            ErrorObject = per;
            DMEEditor = pbl;
            Vismanager = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            if (Passedarg.Objects.Where(i => i.Name == "Branch").Any())
            {
                branch = (IBranch)e.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;

            }
            if (Passedarg.Objects.Where(i => i.Name == "RootReportBranch").Any())
            {
                RootBranch = (IBranch)e.Objects.Where(c => c.Name == "RootReportBranch").FirstOrDefault().obj;

            }
            if (e.Objects.Where(c => c.Name == "ReportDefinition").Any())
            {
                ReportDefinition = (IAppDefinition)e.Objects.Where(c => c.Name == "ReportDefinition").FirstOrDefault().obj;
                reportOutput = new ReportDataManager(DMEEditor, ReportDefinition);
            }
            Dashboard dashboard = new Dashboard();
            dashboardDesigner1.DashboardLoaded += DashboardDesigner1_DashboardLoaded;
            dashboardDesigner1.DataLoading += DashboardDesigner1_DataLoading;
            dashboardDesigner1.Dashboard = new Dashboard();
            reportOutput.DMEEditor = DMEEditor;
            datasSourceInfo = new DxDataSourceInfo(DMEEditor);
            ds = reportOutput.GetDataSet();
            if(ds != null)
            {
                if(ds.Tables.Count > 0)
                {
                    foreach(DataTable tb in ds.Tables)
                    {
                        DashboardObjectDataSource dt1 = new DashboardObjectDataSource(tb.TableName);
                        dashboard.DataSources.Add(dt1);
                    }

                }
            }
            dashboardDesigner1.Dashboard = dashboard;

            //if (e.ReturnData != null)
            //{
            //    datasSourceInfo = (DxDataSourceInfo)e.ReturnData;
            //    if (datasSourceInfo.DxDataSources != null)
            //    {
            //        if (datasSourceInfo.DxDataSources.Count > 0)
            //        {
            //            dashboardDesigner1.Dashboard.DataSources.Clear();
            //            foreach (var item in datasSourceInfo.DxDashboardDataSources)
            //            {
            //                dashboardDesigner1.Dashboard.DataSources.Add(item);
            //            }
            //        }
            //    }
            //}
        }
        private void DashboardDesigner1_DashboardLoaded(object sender, DevExpress.DashboardWin.DashboardLoadedEventArgs e)
        {

        }

        private void DashboardDesigner1_DataLoading(object sender, DataLoadingEventArgs e)
        {
            foreach (DataTable tb in ds.Tables)
            {
                if (e.DataSourceName == tb.TableName)
                {
                    e.Data =tb;
                }
               
            }

        }

    }
}
