using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using DevExpress.Data.Browsing.Design;
using DevExpress.XtraReports.Native.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace Beep.DExpress.ReportBuilder
{
    [AddinAttribute(Caption = "Report Designer", Name = "Frm_DxDesigner", misc = "Reporting", menu = "Reporting", addinType = AddinType.Form, displayType = DisplayType.InControl)]
    public partial class Frm_DxDesigner : Form, IDM_Addin
    {
        public Frm_DxDesigner()
        {
            InitializeComponent();
        }

        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; } = "Form";
        public string AddinName { get ; set ; } = "Report Designer";
        public string Description { get ; set ; } = "Report Designer";
        public bool DefaultCreate { get; set; } = true;
        public string DllPath { get ; set ; }
        public string DllName { get ; set ; }
        public string NameSpace { get ; set ; }
        public IErrorsInfo ErrorObject { get ; set ; }
        public IDMLogger Logger { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public EntityStructure EntityStructure { get ; set ; }
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        #region "IAddinVisSchema"
        public string RootNodeName { get; set; } = "Reporting";
        public string CatgoryName { get; set; }
        public int Order { get; set; } = 1;
        public int ID { get; set; } = 1;
        public string BranchText { get; set; } = "Report Designer";
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Entity;
        public int BranchID { get; set; } = 1;
        public string IconImageName { get; set; } = "reportdesigner.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; } = "";
        public string BranchClass { get; set; } = "REPORTING";
        #endregion "IAddinVisSchema"
        IVisManager Vismanager;
        IBranch RootBranch;
        IBranch branch;
        public IAppDefinition ReportDefinition { get; set; }
        public ReportDataManager reportOutput { get; set; }
        XRDesignPanel xrDesignPanel1;
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }
        private void BindReportToData(object data)
        {
            if (data != null)
            {
                if (reportDesigner1.ActiveDesignPanel.Report == null)
                    return;
                // Create a data source and bind it to a report.
                reportDesigner1.ActiveDesignPanel.Report.DataSource = data;// CreateDataSource();

                // Update the Field List.
                FieldListDockPanel fieldList = fieldListDockPanel1;
                IDesignerHost host =
                    (IDesignerHost)reportDesigner1.ActiveDesignPanel.GetService(typeof(IDesignerHost));

                // Clear the Data Context cache.
                ((DataContextServiceBase)host.GetService(typeof(IDataContextService))).Dispose();

                fieldList.UpdateDataSource(host);
            }
           
        }
        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            Passedarg = e;
            Logger = plogger;
            ErrorObject = per;
            DMEEditor = pbl;
           
            if (e != null)
            {
                if (e.Objects != null)
                {
                    if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
                    {
                        Vismanager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
                    }
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
                        //  XtraReport report = new XtraReport();
                        //reportDesigner1.OpenReport();
                        this.reportDesigner1.DesignPanelLoaded += ReportDesigner1_DesignPanelLoaded; ;
                        reportDesigner1.CreateNewReport();
                        BindReportToData(reportOutput.GetDataSet());
                      
                        
                        //snapControl1.Document.DataSources.Add("Data", reportOutput.GetDataSet());
                        //snapControl1.Document.EndUpdateDataSource();
                        // snapControl1.ShowPrintPreview();
                    }
                }
            }

        }

        private void ReportDesigner1_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            var d = e.DesignerHost;
            d.Activate();
        }
    }
}
