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
using BeepEnterprize.Winform.Vis.Controls;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BeepEnterprize.Winform.Vis.Wizards.DataConnection
{
    [AddinAttribute(Caption = "File Connection", Name = "Frm_File", misc = "Wizard", addinType = AddinType.Form)]
    public partial class Frm_File : Form, IDM_Addin, IWizardComponent
    {
        public Frm_File()
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
        public IWizardManager wizardManager { get; set; }
        public IWizardState state { get; set; }
        public VisManager Visutil { get; set; }
        TreeControl tree;
        IBranch branch;
        List<ConnectionProperties> ds { get; set; } = new List<ConnectionProperties>();
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            Visutil = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            Logger = plogger;
            DMEEditor = pbl;
            //     DataSourceCategoryType = args[0];
            ErrorObject = per;
            tree = (TreeControl)Visutil.Tree;
            if (tree != null)
            {
                branch = tree.Branches[tree.Branches.FindIndex(x => x.BranchClass == "FILE" && x.BranchType == EnumPointType.Root)];
            }
            else
                branch = null;


            foreach (var item in DMEEditor.ConfigEditor.DataDriversClasses)
            {
                try
                {
                    if (!string.IsNullOrEmpty(item.PackageName))
                    {
                        driverNameComboBox.Items.Add(item.PackageName);
                    }


                }
                catch (Exception ex)
                {

                    Logger.WriteLog($"Error for Database connection  :{ex.Message}");
                }

            }
            try
            {
                foreach (var item in DMEEditor.ConfigEditor.DataDriversClasses)
                {
                    if (!string.IsNullOrEmpty(item.PackageName))
                    {
                        driverVersionComboBox.Items.Add(item.version);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            dataConnectionsBindingSource.DataSource = null;
            ds = DMEEditor.ConfigEditor.DataConnections.Where(x => x.Category == DatasourceCategory.RDBMS).ToList();

            if (ds == null)
            {
                ds = new List<ConnectionProperties>();
            }
        
        }
    }
}
