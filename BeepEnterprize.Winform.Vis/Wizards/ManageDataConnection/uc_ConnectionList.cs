using BeepEnterprize.Vis.Module;
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
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Wizards.ManageDataConnection
{
    [AddinAttribute(Caption = "Connection List", Name = "uc_ConnectionList", misc = "App", ObjectType = "Beep", addinType = AddinType.Control, displayType = DisplayType.InControl)]
    public partial class uc_ConnectionList : UserControl, IDM_Addin
    {
        public uc_ConnectionList()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string AddinName { get; set; } = "Connection Types";
        public string Description { get; set; } = "Connection Types";
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public bool DefaultCreate { get; set; } = true;
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
        public IVisManager Visutil { get; set; }
        bool IDM_Addin.DefaultCreate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        IProgress<PassedArgs> progress;
        CancellationToken token;
        IBranch RootAppBranch;
        IBranch branch;

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

            Visutil = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;

            if (e.Objects.Where(c => c.Name == "Branch").Any())
            {
                branch = (IBranch)e.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "RootAppBranch").Any())
            {
                RootAppBranch = (IBranch)e.Objects.Where(c => c.Name == "RootAppBranch").FirstOrDefault().obj;
            }

            DataConnectionManager.LoadDataConnections(DMEEditor);

           // this.ConnectionslistcrownListView.Items = DataConnectionManager.Conns.Select(p=>p.ConnectionName);

            //foreach (string item in Enum.GetValues(typeof(DatasourceCategory)))
            //{
            //    ConnectionTypesListView1.Items.Add(new ReaLTaiizor.Child.Crown.CrownListItem() { Text = item });
            //    //  var it = DatasourceCategorycomboBox.Items.Add(item);

            //}
        }
    }
}

