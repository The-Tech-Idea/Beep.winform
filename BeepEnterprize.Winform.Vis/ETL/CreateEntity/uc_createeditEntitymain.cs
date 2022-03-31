using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    [AddinAttribute(Caption = "Entity Editor", Name = "uc_createeditEntitymain", misc = "ETL", addinType = AddinType.Control)]
    public partial class uc_createeditEntitymain : uc_BaseControl
    {
       

        public uc_createeditEntitymain()
        {
            InitializeComponent();
            TitleLabel.Text = "Entity Editor";
        }
       
        CreateEditEntityManager entityManager;
        public override void Run(IPassedArgs pPassedarg)
        {
            entitiesBindingSource.DataSource = entityManager.EntityStructure;
        }
        public override void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            base.SetConfig(pbl, plogger, putil, args, e, per);
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "CreateEditEntityManager").Any())
            {
                entityManager = (CreateEditEntityManager)e.Objects.Where(c => c.Name == "CreateEditEntityManager").FirstOrDefault().obj;
            }
            RunQuertybutton.Click += RunQuertybutton_Click;
            entitiesBindingSource.DataSource = entityManager.EntityStructure;
            dataSourceIDComboBox.DataSource = DMEEditor.ConfigEditor.DataConnections.Where(p => p.Category == DatasourceCategory.RDBMS).ToList();
            dataSourceIDComboBox.DisplayMember = "ConnectionName";
            
        }
        public void EndEdit()
        {
            DataGridViewbindingSource.EndEdit();

        }
        private void RunQuertybutton_Click(object sender, EventArgs e)
        {
           if(visManager != null)
            {
                if (!string.IsNullOrEmpty(customBuildQueryTextBox.Text))
                {
                    if (this.dataSourceIDComboBox.SelectedValue != null)
                    {
                        ConnectionProperties p = (ConnectionProperties)this.dataSourceIDComboBox.SelectedValue;
                        IDataSource ds = DMEEditor.GetDataSource(p.ConnectionName);
                        if (ds != null)
                        {
                            ds.Openconnection();
                            if (ds.ConnectionStatus == ConnectionState.Open)
                            {
                                DataGridViewbindingSource.DataSource = null;
                                dataGridView1.DataSource = null;
                                DataTable retval  = (DataTable)ds.RunQuery(customBuildQueryTextBox.Text);
                                if (retval != null)
                                {
                                    EntityStructure st = DMEEditor.Utilfunction.GetEntityStructure(retval);
                                    Type type = DMEEditor.Utilfunction.GetEntityType("tab", st.Fields);
                                  
                                    if (st != null)
                                    {
                                        entityManager.EntityStructure.Fields = st.Fields;
                                        DataGridViewbindingSource.DataSource = retval;
                                        dataGridView1.DataSource = DataGridViewbindingSource;
                                        dataGridView1.AutoGenerateColumns = true;
                                        dataGridView1.Invalidate();
                                        dataGridView1.Refresh();
                                    }
                                    else
                                        DMEEditor.AddLogMessage("Beep", "Could not Get Data From DataSource", DateTime.Now, 0, null, Errors.Failed);

                                }
                              
                            }
                            else
                                DMEEditor.AddLogMessage("Beep", "Could not Open DataSource", DateTime.Now, 0, null, Errors.Failed);
                        }else
                        DMEEditor.AddLogMessage("Beep", "Could not Get DataSource", DateTime.Now, 0, null, Errors.Failed);
                    }else
                        DMEEditor.AddLogMessage("Beep", "No DataSource Selected", DateTime.Now, 0, null, Errors.Failed);
                }else
                    DMEEditor.AddLogMessage("Beep", "No Query Found", DateTime.Now, 0, null, Errors.Failed);
            }
        }
        
       
    }
}
