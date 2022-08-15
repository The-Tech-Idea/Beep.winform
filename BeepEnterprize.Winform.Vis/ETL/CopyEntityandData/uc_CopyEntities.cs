using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Winform.Vis.ETL.ImportData;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Editor;
using TheTechIdea.Beep.Vis;

using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.CopyEntityandData
{
    [AddinAttribute(Caption = "Copy Entities", Name = "uc_CopyEntities", misc = "ImportDataManager", addinType = AddinType.Control)]
    public partial class uc_CopyEntities : UserControl,IDM_Addin
    {
        public uc_CopyEntities()
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
        CancellationTokenSource tokenSource;
        CancellationToken token;
        int errorcount = 0;
        bool isstopped = false;
        bool isloading = false;
        bool isfinish = false;
        IDataSource dataSource;
        List<EntityStructure> Entities = new List<EntityStructure>(); 
        public List<ETLScriptDet> SyncEntities { get; set; }
        VisManager visManager;
        bool IsOk = true;
        public CopyEntityManager copyEntityManager { get; set; }
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
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
            //if (e.Objects.Where(c => c.Name == "CopyEntityManager").Any())
            //{
            //    copyEntityManager = (CopyEntityManager)e.Objects.Where(c => c.Name == "CopyEntityManager").FirstOrDefault().obj;
            //}
           // dataSource=DMEEditor.GetDataSource(e.DatasourceName);
            this.dataConnectionsBindingSource.DataSource = DMEEditor.ConfigEditor.DataConnections;

            scriptBindingSource.DataSource = DMEEditor.ETL.Script.ScriptDTL;
            EntitiesnumericUpDown.Minimum = 0;
            //if (dataSource != null)
            //{
            //dataSource.Openconnection();
            // if(dataSource.ConnectionStatus== ConnectionState.Open)
            // {
            
                   
                    EntitiesnumericUpDown.Maximum = DMEEditor.ETL.Script.ScriptDTL.Count() + 1;
                    EntitiesnumericUpDown.Value = DMEEditor.ETL.Script.ScriptDTL.Count();
                   
               // }
           // }
            this.RunMainScripButton.Click += RunMainScripButton_Click;
            this.StopButton.Click += StopButton_Click;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopTask();
        }

        private void RunMainScripButton_Click(object sender, EventArgs e)
        {
            RunScripts();
        }
       
        private void RunScripts()
        {
            //if (Entities.Count > 0)
            //{
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
                    if (percent.ParameterInt1 > progressBar1.Maximum)
                    {
                        progressBar1.Maximum = percent.ParameterInt1;
                    }
                    progressBar1.Value = percent.ParameterInt1;
                    if (percent.EventType == "Update" && DMEEditor.ErrorObject.Flag == Errors.Failed)
                    {
                     //   update();
                    }
                    if (!string.IsNullOrEmpty(percent.EventType))
                    {
                        if (percent.EventType == "Stop")
                        {
                            tokenSource.Cancel();
                        }
                    }
                });
                Action action =
               () =>
                   MessageBox.Show("Start");
                var ScriptRun = Task.Run(() => {
                    CancellationTokenRegistration ctr = token.Register(() => StopTask());
                    DMEEditor.ETL.RunCreateScript(progress, token).Wait();
                    if (!isstopped)
                    {
                        MessageBox.Show("Finish");
                    }

                }).ContinueWith(t => { update(); });

          //  }
           

        }

        void StopTask()
        {
            // Attempt to cancel the task politely
            isstopped = true;
            isloading = false;
            isfinish = false;
            tokenSource.Cancel();
           // MessageBox.Show("Job Stopped");

        }
        void update()
        {
            if (DMEEditor.ETL.LoadDataLogs.Count > 0)
            {
                this.LogtextBox.BeginInvoke(new Action(() =>
                {
                    this.LogtextBox.AppendText($"{ DMEEditor.ETL.LoadDataLogs.Last().Rowindex} - { DMEEditor.ETL.LoadDataLogs.Last().InputLine}" + Environment.NewLine);
                    LogtextBox.SelectionStart = LogtextBox.Text.Length;
                    LogtextBox.ScrollToCaret();
                }));
                   scriptDataGridView.Invalidate();
            }



        }
    }
}
