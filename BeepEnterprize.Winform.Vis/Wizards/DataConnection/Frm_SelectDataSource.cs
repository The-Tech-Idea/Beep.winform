using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
 
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Wizards.DataConnection
{
    [AddinAttribute(Caption = "Select DataSource", Name = "DataConnection", misc = "FirstNode",key =0,addinType = AddinType.Form)]
    public partial class Frm_SelectDataSource : Form,IDM_Addin, IWizardComponent
    {
        public Frm_SelectDataSource()
        {
            InitializeComponent();
        }

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
        public IWizardManager wizardManager { get ; set ; }
        public IWizardState state { get ; set ; }

        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            this.dataConnectionsDataGridView.CellContentClick += DataConnectionsDataGridView_CellContentClick;
        }

        private void DataConnectionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connnectioname = Convert.ToString(dataConnectionsDataGridView.Rows[e.RowIndex].Cells["ConnectionName"].Value);
            if (e.ColumnIndex == 2)
            {

            }
            if (e.ColumnIndex == 3)
            {

            }
        }
    }
}
