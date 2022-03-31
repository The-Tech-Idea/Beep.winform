using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using TheTechIdea.Beep.AppBuilder.AppBuilder;
using TheTechIdea.Beep.AppBuilder.Controls;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    [AddinAttribute(Caption = "App Designer", Name = "AppDesigner", misc = "AppDesigner", addinType = AddinType.Class)]
    public class ScreenDesigner:IDM_Addin
    {
        public ScreenDesigner(IDMEEditor pDMEEditor)
        {
            DMEEditor = pDMEEditor;
            saveandLoad=new AppbuilderSaveandLoad(pDMEEditor);
        }
        public IApp App { get; set; }
        public DesignerProperties Properties { get; set; }=new DesignerProperties();
        public Control Mainpanel { get; set; } = new Control();
        public PropertyGrid propertyGrid1 { get; set; } = new PropertyGrid();
        public Panel ControlsPanel { get; set; } = new Panel();
        public Panel EntitiesPanel { get; set; } = new Panel();
        public Control SelectedControl { get; set; }
        public PanelControl SelectedPanelControl { get; set; }
        public PanelControl SelectedParentPanelControl { get; set; }
        public AppbuilderSaveandLoad saveandLoad { get; set; }
        public ToolStrip MainMenuToolStrip { get; set; }
        public ContextMenuStrip ControlMenu { get; set; } = new ContextMenuStrip();
    
        #region "Properties needed for Designer"
        DataViewDataSource dataViewDataSource;
        IDataSource ds;
        IVisManager visManager;
        Point currentPointerLocation = Point.Empty;
        Rectangle currentCellBounds = Rectangle.Empty;
        Point currentCell = Point.Empty;
        bool menushown = false;
        static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        static Size mouseOffset;
       // static int ControlCount = 0;
        
        ResourceManager resourceManager = new ResourceManager();
      

        List<Button> ControlsButtons = new List<Button>();
      
        #endregion
        #region "IDM_Addin Properties"
        public IDMEEditor DMEEditor { get; set; }
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
        public EntityStructure EntityStructure { get ; set ; }
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }

        #endregion
        #region "IDM_Addin Methods"
        public void Run(IPassedArgs pPassedarg)
        {
           if(pPassedarg != null)
            {
                //if (!string.IsNullOrEmpty(pPassedarg.DatasourceName))
                //{
                   
                    SetupButtonsIcons();
                    ControlMenu= SetupControlContextMenu( ToolStripItem_Click);
                    SetUpMainMenu();
                    saveandLoad.DMEEditor = DMEEditor;
                    saveandLoad.ScreenDesigner = this;
                    Mainpanel.AllowDrop = true;
                    Mainpanel.DragEnter += Mainpanel_DragEnter;
                    Mainpanel.DragDrop += Mainpanel_DragDrop;
                    Mainpanel.ControlRemoved += Mainpanel_ControlRemoved;
               // }
            }
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
        }
        #endregion
        #region "Drag andDrop"
        //public void SetupDragandDrop()
        //{
        //    foreach (AppBlockWinform blk in Blocks)
        //    {
        //        SetupDragandDropforBlock(blk);
        //    }
        //}
        //private void SetupDragandDropforBlock(AppBlockWinform blk)
        //{
        //    foreach (IAppField fld in blk.Fields)
        //    {
        //        PanelControl panelControl = Properties.Controls[Properties.Controls.FindIndex(o => o.AppField.ID == fld.ID)];
        //        panelControl.BeepControl.DragDrop += Control_DragDrop;
        //        panelControl.BeepControl.DragOver += Control_DragOver;
        //        panelControl.BeepControl.DragEnter += Control_DragEnter;
        //        panelControl.BeepControl.DragLeave += Control_DragLeave;
        //        panelControl.BeepControl.MouseDown += Control_MouseDown;
        //    }
        //    if (blk.ChildBlocks.Count > 0)
        //    {
        //        foreach (IAppBlock item in blk.ChildBlocks)
        //        {
        //            SetupDragandDropforBlock((AppBlockWinform)item);
        //        }

        //    }
        //}
        #endregion
        #region "MainPanel Activities"
        private void ToolStripItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;
            draggables.Remove(SelectedControl);
            Mainpanel.Controls.Remove(SelectedControl);
            Properties.Controls.Remove(SelectedPanelControl);
        }
        public void Mainpanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            
            
          
        }
        public void Mainpanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        public void Mainpanel_DragDrop(object sender, DragEventArgs e)
        {
            Properties.ControlCount++;
            string controlname = e.Data.GetData(DataFormats.Text).ToString();
            Point screenCoords = new Point(e.X, e.Y);
            Point controlRelatedCoords = Mainpanel.PointToClient(screenCoords);
            try
            {
               PanelControl panelControl= CreatePanelControl(controlname, controlRelatedCoords);
                panelControl.BeepControl = CreateGuiControl(panelControl, controlname + Properties.ControlCount, controlRelatedCoords);
                IBeepControlInterface controlInterface = (IBeepControlInterface)panelControl.AppComponent;
                controlInterface.Init(DMEEditor.Passedarguments);

            }
            catch (Exception ex )
            {

                DMEEditor.AddLogMessage("Beep", $"Error Dragedd item {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
        
            
            DMEEditor.AddLogMessage("Beep", $"Dragedd item", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
        }
        public void MainPanelControls_MouseMove(object sender, MouseEventArgs e)
        {
            // only if dragging is turned on
            if (draggables[(Control)sender] == true)
            {
                // calculations of control's new position
                Point newLocationOffset = e.Location - mouseOffset;
                ((Control)sender).Left += newLocationOffset.X;
                ((Control)sender).Top += newLocationOffset.Y;
            }
        }
        public void MainPanelControls_MouseUp(object sender, MouseEventArgs e)
        {
            draggables[(Control)sender] = false;
            

        }
        public void MainPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            // turning on dragging
            draggables[(Control)sender] = true;
            Control control = (Control)sender;
            SelectedControl = control;
            SelectedPanelControl=Properties.Controls[Properties.Controls.FindIndex(o=>o.BeepControl==control)];
           
            //if (e.Button== MouseButtons.Right)
            //{
            //    ControlMenu.Show();
            //    menushown = true;
            //}
        }
        public void MainPanelControls_Click(object sender, EventArgs e)
        {
            SelectedControl = sender as Control;
            if (SelectedControl != null)
            {
                this.propertyGrid1.SelectedObject = SelectedControl;
            }
            
        }
        #endregion
        #region "Control Activities"
        public bool IsControlInBoundries(IBeepControlInterface ctl,int x,int y,int width,int height)
        {
            bool retval = false;
            // Check Left and top
            if(ctl.Panelcontrol.BeepControl.ClientSize.Width >= x+width && ctl.Panelcontrol.BeepControl.ClientSize.Height >= y+height && x>0 && y>0)
            {
                retval = true;
            }
            return retval;
        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            button.DoDragDrop(button.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }
        private void Control_DragLeave(object sender, EventArgs e)
        {

        }
        private void Control_DragEnter(object sender, DragEventArgs e)
        {

        }
        private void Control_DragOver(object sender, DragEventArgs e)
        {

        }
        private void Control_DragDrop(object sender, DragEventArgs e)
        {

        }
        #endregion
        #region "Setup Menu and  Icons"
        private void SetupIconForControl(Button control)
        {
            
            if(control != null)
            {
                AssemblyClassDefinition definition= control.Tag as AssemblyClassDefinition;
                control.Image= resourceManager.GetImage("TheTechIdea.Beep.AppBuilder.Gfx.", definition.classProperties.iconimage);
                control.ImageAlign= System.Drawing.ContentAlignment.MiddleLeft;
                control.TextAlign= System.Drawing.ContentAlignment.MiddleCenter;
            }

        }
        private AssemblyClassDefinition GetAssemblyClassDefinition(string name,string type)
        {
            return DMEEditor.ConfigEditor.AppComponents.Where(p=>p.className == name && p.componentType == type).FirstOrDefault();
        }
        public ContextMenuStrip SetupControlContextMenu( EventHandler action)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripItem toolStripItem = new ToolStripButton();
            toolStripItem.Click += action;// ToolStripItem_Click;
            
            toolStripItem.Name = "Remove";
            toolStripItem.Text = "Remove";
            toolStripItem.Width = (toolStripItem.Text.Length * 20) + 50;
            toolStripItem.Image = resourceManager.GetImage("TheTechIdea.Beep.AppBuilder.Gfx.", "Remove.png");
            menu.Items.Add(toolStripItem);
            return menu;
        }
        private void SetUpMainMenu()
        {
            MainMenuToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            MainMenuToolStrip.Location = new System.Drawing.Point(0, 0);
            MainMenuToolStrip.Name = "MenutoolStrip";
            MainMenuToolStrip.Size = new System.Drawing.Size(32, 1191);
            MainMenuToolStrip.Stretch = true;
            MainMenuToolStrip.TabIndex = 4;
            MainMenuToolStrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            MainMenuToolStrip.Items.Clear();
            ToolStripButton LoadtoolStripItem = new ToolStripButton();
            LoadtoolStripItem.Click += MainMenu_Click;
            LoadtoolStripItem.Name = "Load";
            LoadtoolStripItem.Text = "Load";
            LoadtoolStripItem.ToolTipText = "Load Screen Layout";
            LoadtoolStripItem.DisplayStyle= System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            LoadtoolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            LoadtoolStripItem.Size = new System.Drawing.Size(29, 20);
            LoadtoolStripItem.Image = resourceManager.GetImage("TheTechIdea.Beep.AppBuilder.Gfx.", "UploadDocument.png");
            ToolStripButton SavetoolStripItem = new ToolStripButton();
            SavetoolStripItem.Click += MainMenu_Click;
            SavetoolStripItem.Name = "Save";
            SavetoolStripItem.Text = "Save";
            SavetoolStripItem.ToolTipText = "Save Screen Layout";
            SavetoolStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            SavetoolStripItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            SavetoolStripItem.Size = new System.Drawing.Size(29, 20);
            SavetoolStripItem.Image = resourceManager.GetImage("TheTechIdea.Beep.AppBuilder.Gfx.", "Save.png");
            MainMenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            LoadtoolStripItem,
            SavetoolStripItem});

        }
        private void MainMenu_Click(object sender, EventArgs e)
        {
            ToolStripButton stripButton =(ToolStripButton)sender;
            switch (stripButton.Name)
            {
                case "Load":
                    saveandLoad.LoadDesignerProperties();
                    break;
                case "Save":
                    saveandLoad.SaveDesignerProperties();
                    break;
            }
        }
        private void SetupButtonsIcons()
        {
            ControlsButtons.Clear();
            ControlsPanel.Controls.Clear();
            int i = 0;
            foreach (AssemblyClassDefinition definition in DMEEditor.ConfigEditor.AppComponents.Where(p=>p.componentType=="IAppComponent" && p.classProperties.Hidden==false).ToList())
            {
               
               // IAppComponent appField = (IAppComponent)Activator.CreateInstance(definition.type);
                //if(appField != null)
                //{
                    //Control control = (Control) DMEEditor.assemblyHandler.CreateInstanceFromString(appField.FieldType);
               Button button = new Button();
               button.Name = definition.classProperties.Caption;
                button.Text= definition.classProperties.Caption;
                
                button.Tag = definition;
               button.Width = ControlsPanel.Width - 6;
               button.Left = 3;
               button.Height = 25;
               button.Top = 3 + (i * 25)+2;
                button.DragDrop += Control_DragDrop;
                button.DragOver += Control_DragOver;
                button.DragEnter += Control_DragEnter;
                button.DragLeave += Control_DragLeave;
                button.MouseDown += Control_MouseDown;
                SetupIconForControl(button);
               ControlsButtons.Add(button);
               ControlsPanel.Controls.Add(button);
                i++;
               
            }

        }
        public PanelControl CreatePanelControl(string controlname,Point location,PanelControl ParentPanelControl=null)
        {
            try
            {
                AssemblyClassDefinition definition;
                PanelControl panelControl=new PanelControl();
                Button button = ControlsButtons.Where(b => b.Name == controlname).FirstOrDefault();
                if(button.Tag != null)
                {
                    definition = button.Tag as AssemblyClassDefinition;
                }else
                    definition=Properties.Controls.Where(b => b.Name == controlname).FirstOrDefault().ClassProperties;
                if(Properties.Controls != null)
                {
                    int idx = Properties.Controls.FindIndex(p => p.Name == controlname);
                    if (Properties.Controls.Count > 0 && idx!=-1)
                    {
                            panelControl = Properties.Controls[idx];
                  
                     
                    }else
                    { 
                        panelControl.AppField = new AppField();
                        panelControl.Name = controlname + Properties.ControlCount;
                        panelControl.AppComponent = (IAppComponent)DMEEditor.assemblyHandler.CreateInstanceFromString(definition.dllname, definition.PackageName, null);

                        panelControl.AppComponent.ComponentName = controlname + Properties.ControlCount;
                        panelControl.ClassProperties = definition;
                        Properties.Controls.Add(panelControl);
                    }
                }
                IBeepControlInterface controlInterface = (IBeepControlInterface)panelControl.AppComponent;
                controlInterface.ScreenDesigner = this;
                controlInterface.DMEEditor = (DMEEditor)DMEEditor;
                controlInterface.Panelcontrol= panelControl;
                panelControl.AppField.AppComponent = panelControl.AppComponent;
               
               
                if (ParentPanelControl != null)
                {
                    panelControl.ParentControl = ParentPanelControl;

                }
           
              
                return panelControl;
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Beep", $"Error in Creating Control on Panel{controlname} - {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                return null;
            }
           
        }
        public Control CreateGuiControl(PanelControl panelControl,string controlname, Point controlRelatedCoords, string name = null)
        {
            Control control = null;
            if (panelControl.ParentControl != null)
            {

            }
            else
            {
                if (name == null)
                {
                    Properties.ControlCount++;
                }
                control = (Control)DMEEditor.assemblyHandler.CreateInstanceFromString(panelControl.AppComponent.ComponentType);
                if (control != null)
                {
                    control.Name = name == null ? controlname : name;
                    panelControl.AppComponent.ComponentName = control.Name;
                    panelControl.Name = control.Name;
                    panelControl.BeepControl = control;
                    try
                    {
                        control.Text = controlname;

                    }
                    catch (Exception)
                    {


                    }

                    control.Location = controlRelatedCoords;
                    //control.Width = 100;
                    //control.Height = 25;
                    control.ContextMenuStrip = ControlMenu;
                    panelControl.Left = controlRelatedCoords.X;
                    panelControl.Top = controlRelatedCoords.Y;
                   
                    control.Click += MainPanelControls_Click;
                    control.MouseDown += MainPanelControls_MouseDown;
                    control.MouseUp += MainPanelControls_MouseUp;
                    control.MouseMove += MainPanelControls_MouseMove;



                }
                Mainpanel.Controls.Add(control);
                draggables.Add(control, false);
            }
          
          
            return control;
        }
        public void MapControltoParent()
        {
            foreach (PanelControl item in Properties.Controls)
            {
                if (item.ParentControl != null)
                {
                    PanelControl parent = Properties.Controls[Properties.Controls.FindIndex(p => p.Name == item.ParentControl.Name)];
                    if (parent != null)
                    {
                        item.BeepControl.Parent = parent.BeepControl;
                    }
                }
            }
        }
        #endregion

    }
}
