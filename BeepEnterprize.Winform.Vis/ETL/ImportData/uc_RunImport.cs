using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Workflow;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using Beep.Winform.Controls;
using System.Threading;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    public partial class uc_RunImport : UserControl, IDM_Addin
    {
        public uc_RunImport()
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

        VisManager visManager;
        CancellationTokenSource tokenSource;
        CancellationToken token;
        int errorcount = 0;
        bool isstopped = false;
        bool isloading = false;
        bool isfinish = false;
        public ImportDataManager importDataManager { get; set; }

        public void Run(IPassedArgs pPassedarg)
        {

            if (importDataManager.CurrentMappingDTL != null)
            {
                visManager.wizardManager.WizardNodeChangeEvent -= WizardManager_WizardNodeChangeEvent;
                visManager.wizardManager.WizardNodeChangeEvent += WizardManager_WizardNodeChangeEvent;
                entityDataMapBindingSource = importDataManager.entityDataMapBindingSource;

                mappedEntitiesBindingSource = importDataManager.mappedEntitiesBindingSource;
                DMEEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
            }
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;

            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "ImportDataManager").Any())
            {
                importDataManager = (ImportDataManager)e.Objects.Where(c => c.Name == "ImportDataManager").FirstOrDefault().obj;
            }
            loadDataLogsBindingSource.DataSource = DMEEditor.ETL.LoadDataLogs;

            this.RunScriptbutton.Click += RunScriptbutton_Click;
            this.StopButton.Click += StopButton_Click;

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopTask();
        }

        private void WizardManager_WizardNodeChangeEvent(object sender, Wizards.WizardManager.NodeChangeEventHandler e)
        {
            if (importDataManager.CurrentMappingDTL == null)
            {
                e.Cancel = true;
            }
            else if (importDataManager.CurrentMappingDTL.SelectedDestFields.Count == 0)
            {
                e.Cancel = true;
            }
            else if (importDataManager.CurrentMappingDTL.EntityFields.Count == 0)
            {
                e.Cancel = true;
            }
            else if (importDataManager.CurrentMappingDTL.FieldMapping.Count == 0)
            {
                e.Cancel = true;
            }

        }
        private void RunScriptbutton_Click(object sender, EventArgs e)
        {
            RunScripts();
        }

        private void RunScripts()
        {
            DMEEditor.ETL.StopErrorCount = this.ErrorsAllowdnumericUpDown.Value;
            errorcount = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = 3;
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            var progress = new Progress<PassedArgs>(percent => {
                progressBar1.CustomText = percent.ParameterInt1 + " out of " + percent.ParameterInt2;

                if (percent.ParameterInt2 > 0)
                {
                    progressBar1.Maximum = percent.ParameterInt2;

                }
                if(percent.ParameterInt1 > progressBar1.Maximum)
                {
                    progressBar1.Maximum = percent.ParameterInt1;
                }
                progressBar1.Value = percent.ParameterInt1;
                //this.Log_panel.BeginInvoke(new Action(() =>
                if (percent.EventType == "Update")
                {
                    update();
                }

                if (DMEEditor.ErrorObject.Flag == Errors.Failed)
                {
                     if (!string.IsNullOrEmpty(percent.EventType))
                    {
                        if (percent.EventType == "Stop")
                        {
                        tokenSource.Cancel();
                        }
                    }
                }


            });
            Action action =
           () =>
               MessageBox.Show("Start");
            var ScriptRun = Task.Run(() => {
                CancellationTokenRegistration ctr = token.Register(() => StopTask());
                DMEEditor.ETL.CreateImportScript(importDataManager.Mapping, importDataManager.CurrentMappingDTL);
                DMEEditor.ETL.RunImportScript(progress, token).Wait();
                if (!isstopped)
                {
                    MessageBox.Show("Finish");
                }

            }).ContinueWith(t => { update(); });

        }

        void StopTask()
        {
            // Attempt to cancel the task politely
            isstopped = true;
            isloading = false;
            isfinish = false;
            tokenSource.Cancel();
            MessageBox.Show("Job Stopped");

        }
        void update()
        {
            if(DMEEditor.ETL.LoadDataLogs.Count > 0)
            {
                this.LogtextBox.BeginInvoke(new Action(() => {
                    this.LogtextBox.AppendText($"{ DMEEditor.ETL.LoadDataLogs.Last().Rowindex} - { DMEEditor.ErrorObject.Message}" + Environment.NewLine);
                    LogtextBox.SelectionStart = LogtextBox.Text.Length;
                    LogtextBox.ScrollToCaret();
                }));
            }
           


}
    }
}
