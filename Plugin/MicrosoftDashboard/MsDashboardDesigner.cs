using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Beep.Winform.Controls;
using BeepEnterprize.Vis.Module;
using Newtonsoft.Json;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppBuilder;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard
{
    [AddinAttribute(Caption = "MS Dashboard Designer", Name = "MsDashboardDesigner", misc = "VIEW", addinType = AddinType.Control,displayType = DisplayType.InControl )]
    public partial class MsDashboardDesigner : UserControl,IDM_Addin
    {
        public MsDashboardDesigner()
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

        MsChartDashBoard  MsChartDashBoard { get ; set ; }
        IDMDataView  DataView { get; set; }
        bool propertiesExpanded = true;
        bool propertiesIsResizeing = false;
        bool EntitesExpanded = true;
        bool EntitiesIsResizeing = false;
        int propertieswidth = 0;
        Beep.Winform.Controls.ResourceManager resourceManager { get; set; } = new Beep.Winform.Controls.ResourceManager();
        IBranch branch = null;
        IBranch Parentbranch = null;
        DataViewDataSource dataViewDataSource;
        IDataSource ds;
        // VisManager visManager;
        Point currentPointerLocation = Point.Empty;
        Rectangle currentCellBounds = Rectangle.Empty;
        Point currentCell = Point.Empty;
        DashboardProperties dashboardProperties = new DashboardProperties();
        private static Dictionary<Control, bool> draggables =
                 new Dictionary<Control, bool>();
        private static Size mouseOffset;

        private static int ControlCount = 0;

        #region "ContextMenu"
        ContextMenuStrip ContextMenu1 = new ContextMenuStrip();
        private System.Windows.Forms.ToolStripMenuItem addColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeColumnToolStripMenuItem;
        #endregion
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
            if (!string.IsNullOrEmpty(e.DatasourceName))
            {
                MsChartDashBoard = new MsChartDashBoard(DMEEditor);
                ds = DMEEditor.GetDataSource(e.DatasourceName);
                if(ds != null)
                {
                    if (ds.Category== DatasourceCategory.VIEWS)
                    {
                        dataViewDataSource=(DataViewDataSource)ds;
                        dataViewDataSource.Openconnection();
                        if (dataViewDataSource.ConnectionStatus != System.Data.ConnectionState.Open)
                        {
                            DMEEditor.AddLogMessage("Beep", $"DataSource DataView {e.DatasourceName} Could not be opend", DateTime.Now, 0, e.DatasourceName, TheTechIdea.Util.Errors.Failed);
                            MessageBox.Show($"DataSource DataView {e.DatasourceName} Could not be opend", "Beep");
                            Close();
                        }
                    }
                    else
                    {
                        DMEEditor.AddLogMessage("Beep", $"DataSource   {e.DatasourceName} Should be a DataView", DateTime.Now, 0, e.DatasourceName, TheTechIdea.Util.Errors.Failed);
                        MessageBox.Show($"DataSource   {e.DatasourceName} Should be a DataView", "Beep");
                        Close();
                    }
                }
                

            }
            else
            {
                DMEEditor.AddLogMessage("Beep", $"No DataSource Name Passed", DateTime.Now, 0,null, TheTechIdea.Util.Errors.Failed);
                MessageBox.Show($"No DataSource Name Passed","Beep");
                Close();
            }
            propertieswidth = this.splitContainer2.Panel2.Width;
           
            //this.splitContainer2.Panel2.Resize += Panel2_Resize;
            PropertiesExpandbutton.Click += PropertiesExpandbutton_Click;
            EntitiesExpandbutton.Click += EntitiesExpandbutton_Click;
            SetupButtonsIcons();
            SetupContextMenu();
            SetupDragandDrop();
            ContextMenu1.ItemClicked += ContextMenu1_ItemClicked;
            this.Savebutton.Click += Savebutton_Click;
            this.Loadbutton.Click += Loadbutton_Click;
        

        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            loadproperties();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            saveproperties();
        }

        private void ContextMenu1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EntitiesExpandbutton_Click(object sender, EventArgs e)
        {
            EntitiesIsResizeing = true;
            EntitesExpanded = !EntitesExpanded;
            this.splitContainer1.Panel1Collapsed = !EntitesExpanded;
            if (EntitesExpanded)
            {
                //   this.splitContainer2.SplitterDistance = splitContainer2.Width- propertieswidth;
                EntitiesIsResizeing = false;
                EntitiesExpandbutton.BackgroundImage = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "CollapseLeft.png");
            }
            else
            {
                //  this.splitContainer2.SplitterDistance = splitContainer2.Width - PropertiesExpandbutton.Width-1;
                EntitiesIsResizeing = false;
                EntitiesExpandbutton.BackgroundImage = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Collapseright.png");
            }
        }
        private void PropertiesExpandbutton_Click(object sender, EventArgs e)
        {
            propertiesIsResizeing = true;
            propertiesExpanded = !propertiesExpanded;
            this.splitContainer2.Panel2Collapsed = !propertiesExpanded;
            if (propertiesExpanded)
            {
                //   this.splitContainer2.SplitterDistance = splitContainer2.Width- propertieswidth;
                propertiesIsResizeing = false;
                PropertiesExpandbutton.BackgroundImage = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Collapseright.png");
            }
            else
            {
                //  this.splitContainer2.SplitterDistance = splitContainer2.Width - PropertiesExpandbutton.Width-1;
                propertiesIsResizeing = false;
                PropertiesExpandbutton.BackgroundImage = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "CollapseLeft.png");
            }

        }
        private void Mainpanel_MouseClick(object sender, MouseEventArgs e)
        {
            currentPointerLocation = e.Location;
            if(e.Button == MouseButtons.Left)
            {
                this.Mainpanel.Invalidate();
                this.Mainpanel.Update();
            }
        
        }
        private void Mainpanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.CellBounds.Contains(currentPointerLocation))
            {
                currentCellBounds = e.CellBounds;
                currentCell = new Point(e.Row, e.Column);
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
            }
            else
            {
                using (var brush = new SolidBrush(Mainpanel.BackColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
            }
        }
        #region "Drag andDrop"
        private void SetupDragandDrop()
        {

            ButtonBox.DragDrop += Control_DragDrop;
            ButtonBox.DragOver += Control_DragOver;
            ButtonBox.DragEnter += Control_DragEnter;
            ButtonBox.DragLeave += Control_DragLeave;

            CheckBoxbutton.DragDrop += Control_DragDrop;
            CheckBoxbutton.DragOver += Control_DragOver;
            CheckBoxbutton.DragEnter += Control_DragEnter;
            CheckBoxbutton.DragLeave += Control_DragLeave;

            ComboBoxbutton.DragDrop += Control_DragDrop;
            ComboBoxbutton.DragOver += Control_DragOver;
            ComboBoxbutton.DragEnter += Control_DragEnter;
            ComboBoxbutton.DragLeave += Control_DragLeave;

            LabelButton.DragDrop += Control_DragDrop;
            LabelButton.DragOver += Control_DragOver;
            LabelButton.DragEnter += Control_DragEnter;
            LabelButton.DragLeave += Control_DragLeave;

            ListBoxbutton.DragDrop += Control_DragDrop;
            ListBoxbutton.DragOver += Control_DragOver;
            ListBoxbutton.DragEnter += Control_DragEnter;
            ListBoxbutton.DragLeave += Control_DragLeave;


            Calendarbutton.DragDrop += Control_DragDrop;
            Calendarbutton.DragOver += Control_DragOver;
            Calendarbutton.DragEnter += Control_DragEnter;
            Calendarbutton.DragLeave += Control_DragLeave;


            Chartbutton.DragDrop += Control_DragDrop;
            Chartbutton.DragOver += Control_DragOver;
            Chartbutton.DragEnter += Control_DragEnter;
            Chartbutton.DragLeave += Control_DragLeave;

            ButtonBox.MouseDown += Control_MouseDown;
            CheckBoxbutton.MouseDown += Control_MouseDown;
            ComboBoxbutton.MouseDown += Control_MouseDown;
            LabelButton.MouseDown += Control_MouseDown;
            ListBoxbutton.MouseDown += Control_MouseDown;
            Chartbutton.MouseDown += Control_MouseDown;
            Calendarbutton.MouseDown += Control_MouseDown;
            Mainpanel.DragEnter += Mainpanel_DragEnter;
            Mainpanel.DragDrop += Mainpanel_DragDrop;
            Mainpanel.ControlRemoved += Mainpanel_ControlRemoved;
        }

        private void Mainpanel_ControlRemoved(object sender, ControlEventArgs e)
        {
           
            Control control = e.Control ;
            if (!draggables.ContainsKey(control))
            {  // return if control is not draggable
                return;
            }
            
            draggables.Remove(control);
        }

        private void Mainpanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Mainpanel_DragDrop(object sender, DragEventArgs e)
        {
            string controlname = e.Data.GetData(DataFormats.Text).ToString();
            Point screenCoords=new Point(e.X, e.Y);
            Point controlRelatedCoords = Mainpanel.PointToClient(screenCoords);
           
            CreateControl(controlname, controlRelatedCoords);

            DMEEditor.AddLogMessage("Beep", $"Dragedd item", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
        }

        private void MainPanelControls_MouseMove(object sender, MouseEventArgs e)
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

        private void MainPanelControls_MouseUp(object sender, MouseEventArgs e)
        {
            draggables[(Control)sender] = false;
        }

        private void MainPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            // turning on dragging
            draggables[(Control)sender] = true;
        }

        private void MainPanelControls_Click(object sender, EventArgs e)
        {
           Control control=sender as Control;
            if (control != null)
            {
                this.propertyGrid1.SelectedObject = control;
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Button button=sender as Button;
            button.DoDragDrop(button.Text, DragDropEffects.Copy |DragDropEffects.Move);
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
        #region "Setup Icons"
        private void SetupContextMenu()
        {
            this.addColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // addColumnToolStripMenuItem
            // 
            this.addColumnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightToolStripMenuItem,
            this.leftToolStripMenuItem});
            this.addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
            this.addColumnToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addColumnToolStripMenuItem.Text = "Add Column";

            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rightToolStripMenuItem.Text = "Right";
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.leftToolStripMenuItem.Text = "Left";
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem,
            this.downToolStripMenuItem});
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addRowToolStripMenuItem.Text = "Add Row";
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.upToolStripMenuItem.Text = "Up";
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downToolStripMenuItem.Text = "Down";
            // 
            // removeRowToolStripMenuItem
            // 
            this.removeRowToolStripMenuItem.Name = "removeRowToolStripMenuItem";
            this.removeRowToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeRowToolStripMenuItem.Text = "Remove Row";
            // 
            // removeColumnToolStripMenuItem
            // 
            this.removeColumnToolStripMenuItem.Name = "removeColumnToolStripMenuItem";
            this.removeColumnToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeColumnToolStripMenuItem.Text = "Remove Column";
            ContextMenu1.Items.AddRange(new ToolStripItem[] { addColumnToolStripMenuItem, rightToolStripMenuItem, leftToolStripMenuItem, addRowToolStripMenuItem, upToolStripMenuItem, downToolStripMenuItem, removeRowToolStripMenuItem, removeColumnToolStripMenuItem });
        }
        private void SetupButtonsIcons()
        {
            PropertiesExpandbutton.BackgroundImage = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Collapseright.png");
            EntitiesExpandbutton.BackgroundImage = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "CollapseLeft.png");

            ButtonBox.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Button.png");
            ButtonBox.Text = "Button";
            CheckBoxbutton.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "CheckBoxChecked.png");
            CheckBoxbutton.Text = "CheckBox";
            ComboBoxbutton.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "ComboBox.png");
            ComboBoxbutton.Text = "ComboBox";
            LabelButton.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Label.png");
            LabelButton.Text = "Label";
            ListBoxbutton.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "ListBox.png");
            ListBoxbutton.Text = "ListBox";
            Chartbutton.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Chart.png");
            Chartbutton.Text = "Chart";
            Calendarbutton.Image = resourceManager.GetImage("BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard.Gfx.", "Calendar.png");
            Calendarbutton.Text = "DateTimePicker";

        }
        private void CreateControl(string controlname,Point controlRelatedCoords,string name=null)
        {
            if(name == null)
            {
                ControlCount++;
            }
            switch (controlname)
            {
                case "Button":
                    Button button = new Button();
                    button.Name = name==null ? "Button" + ControlCount :name ; 
                    button.Text = "Button";
                    button.FlatStyle = FlatStyle.Standard;
                    button.Location = controlRelatedCoords;
                    button.Width = 100;
                    button.Height = 25;
                    button.Click += MainPanelControls_Click;
                    button.MouseDown += MainPanelControls_MouseDown;
                    button.MouseUp += MainPanelControls_MouseUp;
                    button.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(button, false);
                    Mainpanel.Controls.Add(button);
                    break;
                case "Label":
                    Label label = new Label();
                    label.Name = name == null ? "Label" + ControlCount : name;
                    label.Text = "Label";
                    label.BorderStyle = BorderStyle.Fixed3D;
                    label.Location = controlRelatedCoords;
                    label.Width = 100;
                    label.Height = 25;
                    label.Click += MainPanelControls_Click;
                    label.MouseDown += MainPanelControls_MouseDown;
                    label.MouseUp += MainPanelControls_MouseUp;
                    label.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(label, false);
                    Mainpanel.Controls.Add(label);
                    break;
                case "ComboBox":
                    ComboBox comboBox = new ComboBox();
                    comboBox.Text = "Combo";
                    comboBox.Name = name == null ? "Combo" + ControlCount : name;
                    comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    comboBox.Location = controlRelatedCoords;
                    comboBox.Width = 100;
                    comboBox.Height = 25;
                    comboBox.Click += MainPanelControls_Click;
                    comboBox.MouseDown += MainPanelControls_MouseDown;
                    comboBox.MouseUp += MainPanelControls_MouseUp;
                    comboBox.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(comboBox, false);
                    Mainpanel.Controls.Add(comboBox);
                    break;
                case "ListBox":
                    ListBox listBox = new ListBox();
                    listBox.Text = "List";
                    listBox.Name = name == null ? "List" + ControlCount : name;
                    listBox.BorderStyle = BorderStyle.FixedSingle;
                    listBox.Location = controlRelatedCoords;
                    listBox.Width = 100;
                    listBox.Height = 25;
                    listBox.Click += MainPanelControls_Click;
                    listBox.MouseDown += MainPanelControls_MouseDown;
                    listBox.MouseUp += MainPanelControls_MouseUp;
                    listBox.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(listBox, false);

                    Mainpanel.Controls.Add(listBox);
                    break;
                case "CheckBox":
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = "Check";
                    checkBox.Name = name == null ? "Check" + ControlCount : name;
                    checkBox.FlatStyle = FlatStyle.Flat;
                    checkBox.Location = controlRelatedCoords;
                    checkBox.Width = 100;
                    checkBox.Height = 25;
                    checkBox.Click += MainPanelControls_Click;
                    checkBox.MouseDown += MainPanelControls_MouseDown;
                    checkBox.MouseUp += MainPanelControls_MouseUp;
                    checkBox.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(checkBox, false);
                    Mainpanel.Controls.Add(checkBox);
                    break;
                case "DateTimePicker":
                    DateTimePicker calendar = new DateTimePicker();
                    calendar.Name = name == null ? "DateTimePicker" + ControlCount : name;
                    calendar.Location = controlRelatedCoords;
                    calendar.Width = 100;
                    calendar.Height = 25;
                    calendar.Click += MainPanelControls_Click;
                    calendar.MouseDown += MainPanelControls_MouseDown;
                    calendar.MouseUp += MainPanelControls_MouseUp;
                    calendar.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(calendar, false);
                    Mainpanel.Controls.Add(calendar);
                    break;
                case "Chart":
                    Chart chart = new Chart();
                    chart.BackColor = Color.BlanchedAlmond;
                    chart.Text = "Chart";
                    chart.Name = name == null ? "Chart" + ControlCount : name;
                    chart.BorderlineColor = System.Drawing.Color.Black;
                    chart.BorderlineWidth = 2;
                    chart.Location = controlRelatedCoords;
                    chart.Width = 150;
                    chart.Height = 150;
                    chart.Click += MainPanelControls_Click;
                    chart.MouseDown += MainPanelControls_MouseDown;
                    chart.MouseUp += MainPanelControls_MouseUp;
                    chart.MouseMove += MainPanelControls_MouseMove;
                    draggables.Add(chart, false);
                    Mainpanel.Controls.Add(chart);
                    break;
            }
        }
        #endregion

        #region "Json"
        private void saveproperties()
        {
            dashboardProperties = new DashboardProperties();
            dashboardProperties.Name = ds.DatasourceName;
            dashboardProperties.ControlCount = ControlCount;
            foreach (Control ctl in Mainpanel.Controls)
            {
                
            //    DMEEditor.ConfigEditor.JsonLoader.Serialize(Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(o => o.FolderFilesType == FolderFileTypes.Reports).FirstOrDefault().FolderPath, ctl.Name), ctl);
                BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                Type type = ctl.GetType();
                PropertyInfo[] properties = type.GetProperties(flags);
                PanelControl control=new PanelControl();
                control.Name = ctl.Name;
                control.Type=type.ToString().Substring(type.ToString().LastIndexOf(".") + 1); ;
                foreach (PropertyInfo prop in properties)
                {
                    var vl = prop.GetValue(ctl, null);
                    object ret = null;
                    if (vl != null)
                    {
                         ret= prop.GetValue(ctl, null);
                    }
                    if (ret != null)
                    {
                        if (!ret.ToString().Equals("System.Windows.Forms.AccessibleRole", StringComparison.InvariantCultureIgnoreCase) && prop.CanWrite && !prop.Name.Equals("Parent",StringComparison.InvariantCultureIgnoreCase))
                        {
                            Console.WriteLine(ret.ToString());
                            control.ControlsProperties.Add(new ControlsProperties() { Name = prop.Name, Type = prop.PropertyType.AssemblyQualifiedName, Value = ret });
                        }
                        if (prop.Name == "Name")
                        {

                        }
                    }
                  
                   
                }
                  dashboardProperties.Controls.Add(control);              
            }
            DMEEditor.ConfigEditor.JsonLoader.Serialize(Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(o=>o.FolderFilesType== FolderFileTypes.Reports).FirstOrDefault().FolderPath,ds.DatasourceName), dashboardProperties);
        }
        private OpenFileDialog openFile=new OpenFileDialog();
        private void loadproperties()
        {
            openFile=new OpenFileDialog();
            openFile.InitialDirectory = DMEEditor.ConfigEditor.Config.Folders.Where(o => o.FolderFilesType == FolderFileTypes.Reports).FirstOrDefault().FolderPath;
            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dashboardProperties = new DashboardProperties();
                ControlCount = dashboardProperties.ControlCount;
                dashboardProperties = DMEEditor.ConfigEditor.JsonLoader.DeserializeSingleObject<DashboardProperties>(Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(o => o.FolderFilesType == FolderFileTypes.Reports).FirstOrDefault().FolderPath, openFile.FileName));
                if(dashboardProperties != null)
                {
                    ControlCount = dashboardProperties.ControlCount;
                    foreach (PanelControl item in dashboardProperties.Controls)
                    {
                        string vsname = item.Type;
                        Control control =new Control();
                        BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                        
                        //Type type = control.GetType();
                        //PropertyInfo[] properties = type.GetProperties(flags);
                        Point location=new Point();
                        var val = item.ControlsProperties.FirstOrDefault(p => p.Name.Equals("Location", StringComparison.InvariantCultureIgnoreCase)).Value;
                        string[] vs=val.ToString().Split('\u002C');
                        location = new Point(int.Parse(vs[0]), int.Parse(vs[1]));
                        CreateControl(vsname, location,item.Name);

                    }
                    SetPropertiesforControls();
                }
               
            }
           
        }
        private void SetPropertiesforControls()
        {
            Type t=null;
            string properttypename=null;
            foreach (Control ctl in Mainpanel.Controls)
            {
                BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                Type type = ctl.GetType();
                PropertyInfo[] properties = type.GetProperties(flags);
               
              
                PanelControl panelControl = dashboardProperties.Controls.FirstOrDefault(p => p.Name.Equals(ctl.Name.Substring(ctl.Name.LastIndexOf(".") + 1), StringComparison.InvariantCultureIgnoreCase));
                foreach (PropertyInfo prop in properties)
                {
                    ControlsProperties ctlprop = panelControl.ControlsProperties.FirstOrDefault(p => p.Name.Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase));
                    if (ctlprop != null)
                    {
                        try
                        {
                            //   System.Windows.Forms.Appearance appearance = Appearance.Button;
                            
                            t = prop.PropertyType;
                             properttypename = t.Name;
                            if (t != null)
                            {
                                if (t.IsEnum)
                                {
                                    ctlprop.Value = Enum.Parse(t, ctlprop.Value.ToString());
                                    prop.SetValue(ctl, ctlprop.Value, null);
                                }                               
                                else
                                {
                                    string[] vls;
                                    bool skip=false;
                                    switch (properttypename)
                                    {
                                        case "Cursor":
                                             try
                                                {
                                                    ctlprop.Value = (System.Windows.Forms.Cursor)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {
                                                    PropertyInfo[] cursorproperties = typeof(System.Windows.Forms.Cursors).GetProperties();
                                                    PropertyInfo cursorprop = cursorproperties.Where(o => o.Name.Equals(ctlprop.Value.ToString(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                                    ctlprop.Value = cursorprop.GetValue(typeof(System.Windows.Forms.Cursors), null);
                                                }

                                           

                                          
                                            break;
                                        case "IWindowTarget":
                                        case "ImeMode":
                                        case "BindingContext":
                                            skip = true;
                                            break;
                                        case "BackgroundImageLayout":
                                               ctlprop.Value =  Enum.Parse(t, ctlprop.Value.ToString());
                                            break;
                                        case "Padding":
                                            Padding padding;
                                          
                                                try
                                                {
                                                    ctlprop.Value = (Padding)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {
                                                    vls = ctlprop.Value.ToString().Split(',');
                                                    padding = new Padding(int.Parse(vls[0]), int.Parse(vls[1]), int.Parse(vls[2]), int.Parse(vls[3]));
                                                    ctlprop.Value = padding;
                                                }

                                            
                                            break;
                                        case "Rectangle":
                                            Rectangle rectangle;
                                         
                                                try
                                                {
                                                    ctlprop.Value = (Rectangle)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {
                                                    vls = ctlprop.Value.ToString().Split(',');
                                                     rectangle = new Rectangle(int.Parse(vls[0]), int.Parse(vls[1]), int.Parse(vls[2]), int.Parse(vls[3]));
                                                    ctlprop.Value = rectangle;
                                                }

                                           
                                            

                                            break;
                                      
                                        case "Font":
                                            //Microsoft Sans Serif, 12pt, style=Bold, Underline, Strikeout,Regular
                                          
                                                try
                                                {
                                                    ctlprop.Value = (Font)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {

                                                    vls = ctlprop.Value.ToString().Split(',');
                                                    FontStyle fontStyle = new FontStyle();
                                                    if (vls.Length == 3)
                                                    {
                                                        string[] style = vls[2].Split(',');
                                                        if (style.Contains("Italic "))
                                                        {
                                                            fontStyle = fontStyle | FontStyle.Italic;
                                                        }
                                                        if (style.Contains("Bold"))
                                                        {
                                                            fontStyle = fontStyle | FontStyle.Bold;
                                                        }
                                                        if (style.Contains("Underline"))
                                                        {
                                                            fontStyle = fontStyle | FontStyle.Underline;
                                                        }
                                                        if (style.Contains("Strikeout"))
                                                        {
                                                            fontStyle = fontStyle | FontStyle.Strikeout;
                                                        }
                                                        if (style.Contains("Regular"))
                                                        {
                                                            fontStyle = fontStyle | FontStyle.Regular;
                                                        }
                                                    }
                                                    string valpnt = vls[1].Substring(0, vls[1].IndexOf('p') );
                                                    Font font = new Font(vls[0], float.Parse(valpnt), fontStyle);
                                                    ctlprop.Value = font;
                                                }
                                           
                                           
                                           
                                           

                                            break;
                                        case "Color[]":
                                          
                                            string colors = ctlprop.Value.ToString();
                                            colors = colors.Remove(colors.Length - 1);
                                            colors = colors.Remove(0,1);
                                            colors = Regex.Replace(colors, @"\s", "");
                                            colors.Trim();
                                            colors = colors.Replace("\\", "");
                                            string[] colrs= colors.Split( '"' );

                                            if(colrs.Length > 0)
                                            {
                                                int cnt=colrs.Where(c=>c.Length>1).Count();
                                               Color[] colorsColors = new Color[cnt];
                                                int j=0;
                                               for (int i = 0; i < colrs.Length; i++)
                                               {
                                                    if (colrs[i].Length > 1)
                                                    {
                                                        if (colrs[i].Contains(","))
                                                        {
                                                            string[] rgbs = colrs[i].Split(',');
                                                            colorsColors[j] = Color.FromArgb(int.Parse(rgbs[0]), int.Parse(rgbs[1]), int.Parse(rgbs[2]));
                                                        }
                                                        else
                                                            colorsColors[j] = Color.FromName(colrs[i]);
                                                        j++;
                                                    }
                                                
                                                }
                                             ctlprop.Value = colorsColors;
                                            }
                                         
                                            break;
                                        case "Color":
                                            try
                                            {
                                                ctlprop.Value = (Color) ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {

                                                ctlprop.Value = Color.FromName(ctlprop.Value.ToString());
                                            }
                                        
                                            break;
                                        case "Size":
                                           try
                                                {
                                                    ctlprop.Value = (Size)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {

                                                    Size size = new Size();
                                                    vls = ctlprop.Value.ToString().Split(',');
                                                    size.Width = int.Parse(vls[0]);
                                                    size.Height = int.Parse(vls[1]);
                                                    ctlprop.Value = size;
                                                }
                                               
                                          
                                            break;
                                        case "Point":
                                          

                                                try
                                                {
                                                    ctlprop.Value = (Point)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {

                                                    Point point = new Point();
                                                    vls = ctlprop.Value.ToString().Split(',');
                                                    point.X = int.Parse(vls[0]);
                                                    point.Y = int.Parse(vls[1]);
                                                    ctlprop.Value = point;
                                                }
                                                
                                           
                                           
                                            break;
                                        case "Height":
                                        case "Width":
                                        case "Left":
                                        case "Top":
                                        case "Int32":
                                            ctlprop.Value = Int32.Parse(ctlprop.Value.ToString());
                                            break;
                                        case "BorderSkin":
                                          
                                                try
                                                {
                                                    ctlprop.Value = (BorderSkin)ctlprop.Value;
                                                }
                                                catch (Exception)
                                                {
                                                    BorderSkin a = new BorderSkin();
                                                    a = DMEEditor.ConfigEditor.JsonLoader.DeserializeSingleObjectFromjsonString<BorderSkin>(ctlprop.Value.ToString());
                                                    ctlprop.Value = a;
                                                }
                                           
                                      
                                            break;
                                        case "AutoCompleteStringCollection":
                                            
                                            try
                                            {
                                                ctlprop.Value = (AutoCompleteStringCollection)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {
                                                AutoCompleteStringCollection a = new AutoCompleteStringCollection();
                                                a = DMEEditor.ConfigEditor.JsonLoader.DeserializeSingleObjectFromjsonString<AutoCompleteStringCollection>(ctlprop.Value.ToString());
                                                ctlprop.Value = a;
                                            }
                                            break;
                                    }
                                    if (!skip)
                                    {
                                        prop.SetValue(ctl, ctlprop.Value, null);
                                    }
                                    
                                }
                            }
                           
                        }
                        catch (Exception ex)
                        {

                           DMEEditor.AddLogMessage($"{prop.Name}_{properttypename}");
                        }
                       
                    }
                }
            }
        }
        public static T GetTfromString<T>(string mystring)
        {
            var foo = TypeDescriptor.GetConverter(typeof(T));
            return (T)(foo.ConvertFromInvariantString(mystring));
        }
        #endregion

        private void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
            
        }

        
    }
}

