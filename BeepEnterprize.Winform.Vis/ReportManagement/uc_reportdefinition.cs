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
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ReportBuilder
{
    [AddinAttribute(Caption = "Report Definition", Name = "uc_reportdefinition", misc = "Reporting", menu = "Reporting",iconimage = "reportdesigner.ico",displayType = DisplayType.InControl,addinType = AddinType.Control)]
    public partial class uc_reportdefinition : UserControl, IDM_Addin
    {

        public uc_reportdefinition()
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

        // public event EventHandler<PassedArgs> OnObjectSelected;

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
            // RootBranch = (IBranch)e.Objects.Where(c => c.Name == "RootReportBranch").FirstOrDefault().obj;
            this.reportWritersClassesBindingSource.DataSource = DMEEditor.ConfigEditor.ReportWritersClasses;
            this.reportsBindingSource.DataSource = DMEEditor.ConfigEditor.ReportsDefinition;
            this.reportsBindingSource.AddingNew += ReportsBindingSource_AddingNew;
            this.blocksBindingSource.DataSource = reportsBindingSource;
            blockColumnsBindingSource.DataSource = blocksBindingSource;
            this.blocksBindingSource.AddingNew += BlocksBindingSource_AddingNew;
            this.AddBlockbutton.Click += AddBlockbutton_Click;
            if (string.IsNullOrEmpty(e.CurrentEntity))
            {
                reportsBindingSource.AddNew();
                blocksBindingSource.AddNew();
                this.nameTextBox.Enabled = true;
            }
            else
            {
                reportsBindingSource.DataSource = DMEEditor.ConfigEditor.ReportsDefinition[DMEEditor.ConfigEditor.ReportsDefinition.FindIndex(x => x.Name == e.CurrentEntity)];
                this.nameTextBox.Enabled = false;
            }
            foreach (ConnectionProperties item in DMEEditor.ConfigEditor.DataConnections.Where(x => x.Category == DatasourceCategory.VIEWS))
            {
                this.viewIDComboBox.Items.Add(item.ConnectionName);
            }
            this.viewIDComboBox.SelectedValueChanged += ViewIDComboBox_SelectedValueChanged;
          //  this.Savebutton.Click += Savebutton_Click;
            this.RunReportbutton.Click += RunReportbutton_Click;
            this.blocksBindingSource.CurrentChanged += BlocksBindingSource_CurrentChanged;
            this.packageNameComboBox.SelectedValueChanged += PackageNameComboBox_SelectedValueChanged;
            uc_bindingNavigator1.bindingSource = blocksBindingSource;
            uc_bindingNavigator1.SaveCalled += Uc_bindingNavigator1_SaveCalled;
            uc_bindingNavigator1.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, e, DMEEditor.ErrorObject);

            #region "Drag and Drop events"

            //  this.HeaderpictureBox.DragEnter += HeaderpictureBox_DragEnter;

            #endregion
        }

        private void Uc_bindingNavigator1_SaveCalled(object sender, BindingSource e)
        {
            Save();
        }





        //private void BlockColumnsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        e.RowIndex >= 0)
        //    {
        //        //if ((object)column == (object)color)
        //        //{
        //        //    colorDialog.Color = Color.Blue;
        //        //    colorDialog.ShowDialog();
        //        //}
        //    }

        //}

        //private void BlockColumnsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Ignore clicks that are not in our 
        //    if (e.ColumnIndex == blockColumnsDataGridView.Columns["MyButtonColumn"].Index && e.RowIndex >= 0)
        //    {
        //        Console.WriteLine("Button on row {0} clicked", e.RowIndex);
        //    }
        //}

        private void BlocksBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            AppBlock x = (AppBlock)blocksBindingSource.Current;
            if(x != null)
            {
                if (x.BlockColumns.Count() == 0)
                {
                    if (!string.IsNullOrEmpty(this.viewIDComboBox.Text) && !string.IsNullOrEmpty(this.entityIDComboBox.Text))
                    {
                        ds = (DataViewDataSource)DMEEditor.GetDataSource(this.viewIDComboBox.Text);
                        //  ds.Dataconnection.OpenConnection();
                        DMEEditor.OpenDataSource(ds.DatasourceName);
                        ds.ConnectionStatus = ds.Dataconnection.ConnectionStatus;
                        if (ds.ConnectionStatus == ConnectionState.Open)
                        {
                            EntityStructure ent = (EntityStructure)ds.GetEntityStructure(this.entityIDComboBox.Text, true).Clone();
                            List<AppBlockColumns> ls = new List<AppBlockColumns>();
                            if (ent != null)
                            {
                                x.Fields = ent.Fields;
                                x.filters = ent.Filters;
                                x.Relations = ent.Relations;
                                x.EntityID = ent.DatasourceEntityName;
                                x.ViewID = ent.DataSourceID;
                                int i = 0;
                                foreach (EntityField item in ent.Fields)
                                {
                                    AppBlockColumns c = new AppBlockColumns();
                                    c.ColumnName = item.fieldname;
                                    c.ColumnSeq = i;
                                    c.DisplayName = item.fieldname;
                                    c.Show = true;
                                    i += 1;

                                    ls.Add(c);
                                }
                                x.BlockColumns = ls;
                            }
                        }
                    }
                }
            }
          
        }
        private void Save()
        {
            try

            {
                if (string.IsNullOrEmpty(this.nameTextBox.Text))
                {
                    DMEEditor.AddLogMessage("Fail", $"Please Check All required Fields entered", DateTime.Now, 0, null, Errors.Ok);
                    MessageBox.Show($"Please Check All required Fields entered");
                }
                else
                {
                    blockColumnsBindingSource.MoveFirst();
                    blocksBindingSource.MoveFirst();
                    reportsBindingSource.MoveFirst();
                    blockColumnsBindingSource.EndEdit();
                    this.blocksBindingSource.EndEdit();
                    this.reportsBindingSource.EndEdit();
                    DMEEditor.ConfigEditor.SaveReportDefinitionsValues();
                    if (RootBranch != null)
                    {
                        RootBranch.CreateChildNodes();

                    }
               
                    MessageBox.Show($"Generated Report:{nameTextBox.Text}");
                    DMEEditor.AddLogMessage("Success", $"Generated Report", DateTime.Now, 0, null, Errors.Ok);
                    
                }


            }
            catch (Exception ex)
            {
                string errmsg = "Error in Generating Report";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);

            }

        }
        private void RunReportbutton_Click(object sender, EventArgs e)
        {
            if (!this.nameTextBox.Text.Any(x => Char.IsWhiteSpace(x)))
            {
                string projectData = DMEEditor.ConfigEditor.Config.Folders.Where(h => h.FolderFilesType == FolderFileTypes.ProjectData).FirstOrDefault().FolderPath;
                if (!string.IsNullOrEmpty(this.packageNameComboBox.Text))
                {
                    IReportDMWriter report = (IReportDMWriter)DMEEditor.assemblyHandler.GetInstance(this.packageNameComboBox.SelectedValue.ToString());
                    report.Definition = (IAppDefinition)this.reportsBindingSource.Current;
                    report.DMEEditor = DMEEditor;
                    report.RunReport((ReportType)Enum.Parse(typeof(ReportType), this.ReportOutPutTypecomboBox.Text), Path.Combine(projectData, this.nameTextBox.Text + "." + this.ReportOutPutTypecomboBox.Text));
                    if (DMEEditor.ErrorObject.Flag == Errors.Ok)
                    {
                        if (!string.IsNullOrEmpty(report.OutputFile))
                        {

                            ShowReport(report.OutputFile);
                        }

                    }
                }
            }
            else
            {
                this.nameTextBox.Text = this.nameTextBox.Text.Replace(" ", "");
                MessageBox.Show("Report Name Should not have any spaces");
            }


        }
        private void ShowReport(string htmlfile)
        {

            List<ObjectItem> ob = new List<ObjectItem>(); ;
            ObjectItem it = new ObjectItem();
            it.obj = this;
            it.Name = "Branch";
            ob.Add(it);
            string[] args = new string[] { htmlfile, null };
            PassedArgs Passedarguments = new PassedArgs
            {
                Addin = null,
                AddinName = null,
                AddinType = "",
                DMView = null,
                CurrentEntity = htmlfile,

                ObjectType = "HTMLREPORT",

                ObjectName = htmlfile,
                Objects = ob,

                EventType = "HTMLREPORT"

            };


            Vismanager.ShowPage("uc_Webview",  Passedarguments);
        }
      

        private void AddBlockbutton_Click(object sender, EventArgs e)
        {
            blocksBindingSource.AddNew();
            AppBlock x = (AppBlock)blocksBindingSource.Current;
            if (!string.IsNullOrEmpty(this.viewIDComboBox.Text))
            {
                ds = (DataViewDataSource)DMEEditor.GetDataSource(this.viewIDComboBox.Text);
                EntityStructure ent = (EntityStructure)ds.GetEntityStructure(this.entityIDComboBox.Text, true).Clone();
                x.EntityID = ent.DatasourceEntityName;
                x.ViewID = ent.DataSourceID;
                List<AppBlockColumns> ls = new List<AppBlockColumns>();
                if (ent != null)
                {
                    int i = 0;
                    foreach (EntityField item in ent.Fields)
                    {
                        AppBlockColumns c = new AppBlockColumns();
                        c.ColumnName = item.fieldname;
                        c.ColumnSeq = i;
                        c.DisplayName = item.fieldname;
                        c.Show = true;
                        i += 1;

                        ls.Add(c);
                    }

                }
                x.BlockColumns = ls;

            }

        }

        private void BlocksBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AppBlock x = new AppBlock();
            e.NewObject = x;
           
        }

        private void ReportsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AppTemplate x = new AppTemplate();
            x.Title.Text = null;
            x.SubTitle.Text = null;
            x.Header.Text = null;
            x.Footer.Text = null;
            x.Blocks = new List<AppBlock>();
            e.NewObject = x;
        }

        private void ViewIDComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.viewIDComboBox.Text))
            {
                ds = (DataViewDataSource)DMEEditor.GetDataSource(this.viewIDComboBox.Text);
                if (ds != null)
                {
                    this.entityIDComboBox.Items.Clear();
                    List<string> ls = ds.GetEntitesList().ToList();
                    foreach (string item in ls)
                    {
                        this.entityIDComboBox.Items.Add(item);
                    }

                }
            }
        }
        private void PackageNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.viewIDComboBox.Text))
            {

                if (!string.IsNullOrEmpty(this.packageNameComboBox.Text))
                {
                    this.ReportOutPutTypecomboBox.Items.Clear();

                    foreach (var item in Enum.GetValues(typeof(ReportType)))
                    {
                        this.ReportOutPutTypecomboBox.Items.Add(item);
                    }

                }
            }
        }
    }
}

