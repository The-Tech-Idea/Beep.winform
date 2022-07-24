using System;
using System.Data;
using System.Drawing;
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
        public bool IsBeepDataOn { get; set; } = true;
        public bool IsAppOn { get; set; } = true;
        public VisManager visManager { get; set; }
        public bool startLoggin { get; set; } = false;
        public void Run(IPassedArgs pPassedarg)
        {
           
        }
        TreeControl ApptreeControl;
        MenuControl AppmenuControl;
        ToolbarControl ApptoolbarControl;

        ToolbarControl BeeptoolbarControl;
        MenuControl BeepmenuControl;
        TreeControl BeepTreeControl;
        
        bool IsTreeSideOpen = true;
        bool IsSidePanelsOpen = true;
        bool IsLogPanelOpen = true;
        int LogPanelHeight;
       // private System.Windows.Forms.Button MinMaxButton;
        Image CollapseLeft;
        Image Collapseright;
        Image CollapseUp;
        Image CollapseDown;
        Image ListSearch;
        bool _IsDevModeOn = true;
        bool IsDevModeOn { get { return _IsDevModeOn; } set { _IsDevModeOn = value; DevModeOn(); } }
       // bool IsAddingControl = false;
        
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
            if (Passedarg.ParameterInt1 > 0)
            {
                if(Passedarg.ParameterInt1 > 1)
                {
                    IsDevModeOn=true;
                }
                
               
            }
            //---------- Init Controls --------------
           
            BeepTreeControl = (TreeControl)visManager.Tree;
            BeeptoolbarControl = (ToolbarControl)visManager.ToolStrip;
            BeepmenuControl = (MenuControl)visManager.MenuStrip;

            ApptreeControl = (TreeControl)visManager.SecondaryTree;
            AppmenuControl = (MenuControl)visManager.SecondaryMenuStrip;
            ApptoolbarControl = (ToolbarControl)visManager.SecondaryToolStrip;
            //----------------------------------------

            if (Passedarg.Objects.Where(i => i.Name == "TreeControl").Any())
            {
                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "TreeControl").FirstOrDefault());
            }
            if (Passedarg.Objects.Where(i => i.Name == "ControlManager").Any())
            {
                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "ControlManager").FirstOrDefault());
            }
            //--------- Save Controls and Objects in PassedArgs
            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "ControlManager", obj = visManager._controlManager });

            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "TreeControl", obj = BeepTreeControl });
            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "MenuControl", obj = BeepmenuControl });
            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "ToolbarControl", obj = BeeptoolbarControl });

            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "AppTreeControl", obj = ApptreeControl });
            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "AppMenuControl", obj = AppmenuControl });
            DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "AppToolbarControl", obj = ApptoolbarControl });
       //     DMEEditor.Passedarguments = Passedarg;

            //-------------------------------------------------
            if (!visManager.WaitFormShown)
            {
                visManager.ShowWaitForm((PassedArgs)Passedarg);
            }

            
            //------------- Setup Control Container to Display controls and addons
            visManager.Container = ContainerPanel;
            //--------------------------------------------------------------------
            
            if(DMEEditor.Passedarguments.ParameterString1 != null)
            {
                if (DMEEditor.Passedarguments.ParameterString1.Equals("NoApp", StringComparison.InvariantCultureIgnoreCase))
                {
                    IsAppOn = false;
                }
            }
            if (IsBeepDataOn)
            {
                ///------------ Setup Beep Data Management 

                BeepTreeControl.TreeType = "Beep";
                BeepTreeControl.ObjectType = "Beep";
                BeeptoolbarControl.ObjectType = "Beep";
                BeepmenuControl.ObjectType = "Beep";

                BeepTreeControl.TreeV = BeepTreeView;
                BeepmenuControl.TreeV = BeepTreeView;
                BeeptoolbarControl.TreeV = BeepTreeView;
               
                BeeptoolbarControl.vismanager = visManager;
                BeepmenuControl.vismanager = visManager;
                //  you can change icon size in Tree controls  ex. Apptree.IconSize = new Size(24, 24);

                Passedarg.ParameterString1 = "Loading Beep Data Management Functions and Tree";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);
                BeepTreeControl.CreateRootTree();

                Passedarg.ParameterString1 = "Loading Function Extensions ToolBar for Beep  Data Management";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);

                BeeptoolbarControl.toolbarstrip = BeeptoolStrip;
                BeeptoolbarControl.CreateToolbar();
                
                Passedarg.ParameterString1 = "Loading Function Extensions Menu for Beep  Data Management";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);

                BeepmenuControl.menustrip = Beepmenustrip;
                BeepmenuControl.CreateGlobalMenu();
                if (Beepmenustrip.Items.Count == 0)
                {
                    Beepmenustrip.Visible = false;
                }
                BeepmenuControl.IsBeepDataOn = true;
              
            }
            else
             BeepmenuControl.IsBeepDataOn = false;
              
            ///----------------------------------------
            if (IsAppOn)
            {
                ///------------ Setup App  
                ApptreeControl.TreeType = "dhub";
                ApptreeControl.ObjectType = "dhub";
                ApptoolbarControl.ObjectType = "dhub";
                AppmenuControl.ObjectType = "dhub";

                ApptreeControl.TreeV = AppTreeView;
                ApptoolbarControl.TreeV = AppTreeView;
                AppmenuControl.TreeV = AppTreeView;

                AppmenuControl.vismanager = visManager;
                ApptoolbarControl.vismanager = visManager;

                Passedarg.ParameterString1 = "Loading DHUB Functions and Tree";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);
                ApptreeControl.CreateRootTree();

                Passedarg.ParameterString1 = "Loading App Toobar Functions ";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);
                
                Passedarg.ParameterString1 = "Loading Function Extensions ToolBar for App ";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);
                
                ApptoolbarControl.toolbarstrip = ApptoolStrip;
                 
                ApptoolbarControl.CreateToolbar();

                Passedarg.ParameterString1 = "Loading Function Extensions Menu for App ";
                visManager.PasstoWaitForm((PassedArgs)Passedarg);
                AppmenuControl.menustrip = AppmenuStrip;
               
                AppmenuControl.CreateGlobalMenu();
                if (AppmenuStrip.Items.Count == 0)
                {
                    AppmenuStrip.Visible = false;
                }
                AppmenuControl.IsAppOn = true;
              
            }else
                AppmenuControl.IsAppOn = false;
            ///----------------------------------------
        

           


            //Appmenu.menustrip = appme;
            //Appmenu.CreateGlobalMenu();

            this.Shown += Frm_Main_Shown;
            startLoggin = true;
            visManager.CloseWaitForm();
            this.Filterbutton.Click += Filterbutton_Click;
            this.SidePanelCollapsebutton.Click += SidePanelCollapsebutton_Click;
            this.MinMaxButton.Click += MinMaxButton_Click;
            this.LogPanelCollapsebutton.Click += LogPanelCollapsebutton_Click;
            LogPanelHeight = LogPanel.Height;
          
            MainSplitContainer1.Panel1MinSize = 40;

            ListSearch = (Bitmap)Properties.Resources.ResourceManager.GetObject("ListBoxSearch");
            CollapseLeft = (Bitmap)Properties.Resources.ResourceManager.GetObject("CollapseLeft");
            Collapseright = (Bitmap)Properties.Resources.ResourceManager.GetObject("Collapseright");
            CollapseUp = (Bitmap)Properties.Resources.ResourceManager.GetObject("CollapseUp");
            CollapseDown = (Bitmap)Properties.Resources.ResourceManager.GetObject("CollapseDown");

            this.SidePanelCollapsebutton.Image = CollapseDown;
            this.MinMaxButton.Image= CollapseLeft;
            this.LogPanelCollapsebutton.Image = CollapseDown;
            Filterbutton.Image = ListSearch;
            if (IsBeepDataOn == false) RemoveBeepGui();
            if (IsAppOn == false) RemoveAppGui();
        }

        private void RemoveAppGui()
        {
            ApptoolStrip.Visible = false;
            AppmenuStrip.Visible = false;
            AppmenuStrip.Height = 0;
            ApptoolStrip.Width = 0;
            TopMenuPanel.Height = 35;
            tableLayoutPanel2.ColumnStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.ColumnStyles[1].Width = 0;
            tableLayoutPanel2.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel2.ColumnStyles[0].Width = 30;
            tableLayoutPanel2.Width = 25;
            panel1.Width = 35;
            
            SidePanelCollapsebutton.Visible = false;
            SidePanelContainer.Panel1Collapsed = true;
        }

        private void RemoveBeepGui()
        {
            LogPanelCollapsebutton.Visible = false;
            MainViewsplitContainer.Panel2Collapsed = true;
            Beepmenustrip.Height = 0;
            Beepmenustrip.Visible = false;
            BeeptoolStrip.Visible = false;
            BeeptoolStrip.Width = 0;
            TopMenuPanel.Height = 35;
            tableLayoutPanel2.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel2.ColumnStyles[0].Width = 0;
            tableLayoutPanel2.ColumnStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.ColumnStyles[1].Width = 30;
            tableLayoutPanel2.Width = 25;
            panel1.Width = 35;
            
          
            SidePanelCollapsebutton.Visible = false;
            SidePanelContainer.Panel2Collapsed = true;
        }

        public void DevModeOn()
        {

            if (_IsDevModeOn)
            {
                LogPanelCollapsebutton.Visible = false;
                MainViewsplitContainer.Panel2Collapsed = true;
                SidePanelCollapsebutton.Visible = false;
                SidePanelContainer.Panel2Collapsed = true;
            }
            else
            {
                LogPanelCollapsebutton.Visible = true;
                MainViewsplitContainer.Panel2Collapsed = false;
                SidePanelCollapsebutton.Visible = true;
                SidePanelContainer.Panel2Collapsed = false;
            }
        }
        private void LogPanelCollapsebutton_Click(object sender, EventArgs e)
        {
            //IsLogPanelOpen
            if (IsLogPanelOpen)
            {
                MainViewsplitContainer.Panel2Collapsed = true;
                LogPanelCollapsebutton.Image = CollapseUp;
                IsLogPanelOpen = false;
            }
            else
            {
                LogPanelCollapsebutton.Image = CollapseDown;
                MainViewsplitContainer.Panel2Collapsed = false;
                IsLogPanelOpen = true;
            }
        }
        private void SidePanelCollapsebutton_Click(object sender, EventArgs e)
        {
            //IsSidePanelsOpen
            if (IsSidePanelsOpen)
            {
                SidePanelContainer.Panel2Collapsed = true;
                SidePanelCollapsebutton.Image = CollapseUp;
                IsSidePanelsOpen = false;
            }
            else
            {
                SidePanelContainer.Panel2Collapsed = false;
                SidePanelCollapsebutton.Image = CollapseDown;
                IsSidePanelsOpen = true;
            }
        }
        private void MinMaxButton_Click(object sender, EventArgs e)
        {
            if (IsTreeSideOpen)
            {
                MainSplitContainer1.Panel1Collapsed = true;
                MinMaxButton.Image = Collapseright;
                IsTreeSideOpen =false;
            }
            else
            {
                MainSplitContainer1.Panel1Collapsed = false;
                MinMaxButton.Image = CollapseLeft;
                IsTreeSideOpen = true;
            }
        }
        private void Filterbutton_Click(object sender, EventArgs e)
        {
            ApptreeControl.Filterstring=TreeFilterTextBox.Text;
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
