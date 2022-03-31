using Beep.DExpress.Common;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    [AddinAttribute(Caption = "Snap Report Designer", Name = "Frm_DxSnapDesigner", misc = "Reporting", menu = "Reporting", addinType = AddinType.Form, displayType = DisplayType.InControl)]
    public partial class Frm_DxSnapDesigner : Form, IDM_Addin
    {
        DxDataSourceInfo sourceInfo;
        public Frm_DxSnapDesigner()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "Form";
        public string AddinName { get; set; } = "Snap Report Designer";
        public string Description { get; set; } = "Snap Report Designer";
        public bool DefaultCreate { get; set; } = true;
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        #region "IAddinVisSchema"
        public string RootNodeName { get; set; } = "Reporting";
        public string CatgoryName { get; set; }
        public int Order { get; set; } = 1;
        public int ID { get; set; } = 1;
        public string BranchText { get; set; } = "Snap Report Designer";
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Entity;
        public int BranchID { get; set; } = 1;
        public string IconImageName { get; set; } = "snapdesigner.ico";
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

        string reportpath;
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
           // snapControl1.BeforeExport += SnapControl1_BeforeExport;
            // snapControl1.DocumentLoaded += SnapControl1_DocumentLoaded;
            if (Passedarg.Objects.Where(i => i.Name == "Branch").Any())
            {
                branch = (IBranch)e.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;

            }
            if (Passedarg.Objects.Where(i => i.Name == "RootReportBranch").Any())
            {
                RootBranch = (IBranch)e.Objects.Where(c => c.Name == "RootReportBranch").FirstOrDefault().obj;

            }
            if (e != null)
            {
                if (e.Objects != null)
                {
                    if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
                    {
                        Vismanager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
                    }

                    if (e.Objects.Where(c => c.Name == "ReportDefinition").Any())
                    {
                        ReportDefinition = (IAppDefinition)e.Objects.Where(c => c.Name == "ReportDefinition").FirstOrDefault().obj;
                      
                        reportOutput = new ReportDataManager(DMEEditor, ReportDefinition);
                        reportpath=reportOutput.GetReportFilePath(ReportDefinition);
                        //if (File.Exists(reportpath + ".snx"))
                        //{
                        //    snapControl1.LoadDocument(reportpath+".snx");
                        //}else
                        //{
                        //    snapControl1.SaveDocument(reportpath + ".snx");
                        //}
                        //fileNewItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //fileOpenItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        //fileSaveAsItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        // fileSaveItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        snapControl1.CreateNewDocument();
                       
                        snapControl1.Document.BeginUpdateDataSource();
                        //foreach (ReportBlock item in ReportDefinition.Blocks)
                        //{
                        //    snapControl1.Document.DataSources.Add(item.EntityID, reportOutput.GetList(item));
                        //}
                      //  BindingSource bindingSource = new BindingSource();
                      //  bindingSource.DataSource = reportOutput.GetDataSet();
                     //   bindingSource.DataMember = "CUSTOMERS";
                         snapControl1.Document.DataSources.Add(ReportDefinition.Name, reportOutput.GetDataSet());
                        //snapControl1.Document.DataSource = bindingSource;
                         snapControl1.Document.EndUpdateDataSource();
                        
                    }
                }
            }
          
            
           
        }


       

     
    }
}
