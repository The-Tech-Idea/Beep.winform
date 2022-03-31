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
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace Beep.DExpress.ReportBuilder
{
    [AddinAttribute(Caption = "Report Create", Name = "uc_DXreports", misc = "Reporting")]
    public partial class uc_DXreports : UserControl, IDM_Addin
    {
        public uc_DXreports()
        {
            InitializeComponent();
        }
        public string ParentName { get; set; }
        public string AddinName { get; set; } = "Reports Definition";
        public string Description { get; set; } = "Reports Definition";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public Boolean DefaultCreate { get; set; } = true;
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public DataSet Dset { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }
        //  private IDMDataView MyDataView;
        public IVisManager Vismanager { get; set; }
        DataViewDataSource ds;
        IBranch RootBranch;
        IBranch branch;
        public void RaiseObjectSelected()
        {
            throw new NotImplementedException();
        }

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
            Vismanager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            if (Passedarg.Objects.Where(i => i.Name == "Branch").Any())
            {
                branch = (IBranch)e.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;

            }
            if (Passedarg.Objects.Where(i => i.Name == "RootReportBranch").Any())
            {
                RootBranch = (IBranch)e.Objects.Where(c => c.Name == "RootReportBranch").FirstOrDefault().obj;

            }

           
           
            this.reportWritersClassesBindingSource.DataSource = DMEEditor.ConfigEditor.ReportWritersClasses;
            this.reportslistBindingSource.DataSource = DMEEditor.ConfigEditor.Reportslist;
            this.Savebutton.Click += Savebutton_Click;

            if (string.IsNullOrEmpty(e.CurrentEntity))
            {
                reportslistBindingSource.AddNew();
                this.reportDefinitionLabel1.Text = e.ObjectName;
                this.reportNameTextBox.Enabled = true;
            }
            else
            {
                reportslistBindingSource.DataSource = DMEEditor.ConfigEditor.Reportslist[DMEEditor.ConfigEditor.Reportslist.FindIndex(x => x.ReportName.Equals(e.CurrentEntity,StringComparison.OrdinalIgnoreCase))];
                this.reportNameTextBox.Enabled = false;
            }
            //foreach (ConnectionProperties item in DMEEditor.ConfigEditor.DataConnections.Where(x => x.Category == DatasourceCategory.VIEWS))
            //{
            //    this.viewIDComboBox.Items.Add(item.ConnectionName);
            //}



        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            try

            {
                if (string.IsNullOrEmpty(this.reportEngineComboBox.Text) || string.IsNullOrEmpty(this.reportNameTextBox.Text) )
                {
                    DMEEditor.AddLogMessage("Fail", $"Please Check All required Fields entered", DateTime.Now, 0, null, Errors.Ok);
                    MessageBox.Show($"Please Check All required Fields entered");
                }
                else
                {
                  
                   
                    this.reportslistBindingSource.EndEdit();
                    DMEEditor.ConfigEditor.SaveReportsValues();
                    branch.CreateChildNodes();
                    MessageBox.Show($"Generated Report:{reportNameTextBox.Text}");
                    DMEEditor.AddLogMessage("Success", $"Generated Report", DateTime.Now, 0, null, Errors.Ok);
                    this.ParentForm.Close();
                }


            }
            catch (Exception ex)
            {
                string errmsg = "Error in Generating Report";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);

            }
        }
    }
}
