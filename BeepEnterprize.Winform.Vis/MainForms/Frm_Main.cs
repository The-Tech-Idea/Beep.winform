using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BeepEnterprize.Winform.Vis.Controls;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.MainForms
{
    [AddinAttribute(Caption ="Beep", Name ="MainForm", misc ="MainForm")]
    public partial class Frm_Main : Form, IDM_Addin
    {
        public Frm_Main()
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
     
        public VisManager visManager { get; set; }
        public bool startLoggin { get; set; } = false;
        public void Run(IPassedArgs pPassedarg)
        {
           
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            Passedarg = e;
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            Logger.Onevent += Logger_Onevent;
          
            ToolbarControl toolbar = (ToolbarControl)visManager.ToolStrip;
            MenuControl menu = (MenuControl)visManager.MenuStrip;
            TreeControl tree = (TreeControl)visManager.Tree;

          
            if (Passedarg.Objects.Where(i => i.Name == "TreeControl").Any())
            {
                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "TreeControl").FirstOrDefault());
            }
            if (Passedarg.Objects.Where(i => i.Name == "ControlManager").Any())
            {
                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "ControlManager").FirstOrDefault());
            }
            if (Passedarg.Objects.Where(i => i.Name == "MenuControl").Any())
            {
                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "MenuControl").FirstOrDefault());
            }
            if (Passedarg.Objects.Where(i => i.Name == "ToolbarControl").Any())
            {
                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "ToolbarControl").FirstOrDefault());
            }
            Passedarg.Objects.Add(new ObjectItem() { Name = "TreeControl", obj = tree });
            Passedarg.Objects.Add(new ObjectItem() { Name = "ControlManager", obj = visManager._controlManager });
            Passedarg.Objects.Add(new ObjectItem() { Name = "MenuControl", obj = menu });
            Passedarg.Objects.Add(new ObjectItem() { Name = "ToolbarControl", obj = toolbar });
            DMEEditor.Passedarguments = Passedarg;
            visManager.Container = ContainerPanel;
            tree.TreeV = treeView1;
            toolbar.TreeV = tree.TreeV;
            menu.TreeV = tree.TreeV;
            menu.vismanager = visManager;
            toolbar.vismanager = visManager;
            tree.CreateRootTree();
            menu.menustrip = MainMenuStrip;
            menu.CreateGlobalMenu();
            toolbar.toolbarstrip = MaintoolStrip1;
            toolbar.CreateToolbar();
            this.Shown += Frm_Main_Shown;
            startLoggin = true;
           

        }

        private void Frm_Main_Shown(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
            this.Text = "Beep - The Plugable Integrated Platform";
        }

        private void Logger_Onevent(object sender, string e)
        {
            if (startLoggin)
            {
                    this.LogPanel.BeginInvoke(new Action(() => {
                    this.LogPanel.AppendText(e + Environment.NewLine);
                    LogPanel.SelectionStart = LogPanel.Text.Length;
                    LogPanel.ScrollToCaret();
                }));
            }

        }
    }
}
