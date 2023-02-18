using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;

namespace BeepEnterprize.Winform.Vis.MainForms
{
    partial class Frm_Main_1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main_1));
            this.metroStyleManager1 = new ReaLTaiizor.Manager.MetroStyleManager();
            this.airForm1 = new ReaLTaiizor.Forms.AirForm();
            this.Filterbutton = new ReaLTaiizor.Controls.CrownButton();
            this.TreeFilterTextBox = new ReaLTaiizor.Controls.CrownDropDownList();
            this.BackGroundpanel = new ReaLTaiizor.Controls.Panel();
            this.MenuSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AppmenuStrip = new ReaLTaiizor.Controls.CrownMenuStrip();
            this.Beepmenustrip = new ReaLTaiizor.Controls.CrownMenuStrip();
            this.MainSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ApptoolStrip = new ReaLTaiizor.Controls.CrownToolStrip();
            this.BeeptoolStrip = new ReaLTaiizor.Controls.CrownToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.sidepanelView = new ReaLTaiizor.Controls.Panel();
            this.SidePanelContainer = new System.Windows.Forms.SplitContainer();
            this.SidePanelCollapsebutton = new ReaLTaiizor.Controls.CrownButton();
            this.AppTreeView = new ReaLTaiizor.Controls.ForeverTreeView();
            this.BeepTreeView = new ReaLTaiizor.Controls.ForeverTreeView();
            this.MainViewsplitContainer = new System.Windows.Forms.SplitContainer();
            this.MinMaxButton = new ReaLTaiizor.Controls.CrownButton();
            this.LogPanelCollapsebutton = new ReaLTaiizor.Controls.CrownButton();
            this.uc_Container1 = new BeepEnterprize.Winform.Vis.Controls.uc_Container_1();
            this.ClearLogPanelButton = new ReaLTaiizor.Controls.CrownButton();
            this.LogPanel = new ReaLTaiizor.Controls.CrownTextBox();
            this.airForm1.SuspendLayout();
            this.BackGroundpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSplitContainer1)).BeginInit();
            this.MenuSplitContainer1.Panel1.SuspendLayout();
            this.MenuSplitContainer1.Panel2.SuspendLayout();
            this.MenuSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer1)).BeginInit();
            this.MainSplitContainer1.Panel1.SuspendLayout();
            this.MainSplitContainer1.Panel2.SuspendLayout();
            this.MainSplitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.BeeptoolStrip.SuspendLayout();
            this.sidepanelView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidePanelContainer)).BeginInit();
            this.SidePanelContainer.Panel1.SuspendLayout();
            this.SidePanelContainer.Panel2.SuspendLayout();
            this.SidePanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewsplitContainer)).BeginInit();
            this.MainViewsplitContainer.Panel1.SuspendLayout();
            this.MainViewsplitContainer.Panel2.SuspendLayout();
            this.MainViewsplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.CustomTheme = "C:\\Users\\f_ald\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.metroStyleManager1.OwnerForm = this;
            this.metroStyleManager1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.metroStyleManager1.ThemeAuthor = "Taiizor";
            this.metroStyleManager1.ThemeName = "MetroLight";
            // 
            // airForm1
            // 
            this.airForm1.BackColor = System.Drawing.Color.White;
            this.airForm1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.airForm1.Controls.Add(this.Filterbutton);
            this.airForm1.Controls.Add(this.TreeFilterTextBox);
            this.airForm1.Controls.Add(this.BackGroundpanel);
            this.airForm1.Customization = "AAAA/1paWv9ycnL/";
            this.airForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airForm1.Image = null;
            this.airForm1.Location = new System.Drawing.Point(0, 0);
            this.airForm1.MinimumSize = new System.Drawing.Size(112, 35);
            this.airForm1.Movable = true;
            this.airForm1.Name = "airForm1";
            this.airForm1.NoRounding = false;
            this.airForm1.Sizable = true;
            this.airForm1.Size = new System.Drawing.Size(1280, 700);
            this.airForm1.SmartBounds = true;
            this.airForm1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.airForm1.TabIndex = 0;
            this.airForm1.Text = "Beep The Data Platform";
            this.airForm1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.airForm1.Transparent = false;
            // 
            // Filterbutton
            // 
            this.Filterbutton.Image = global::BeepEnterprize.Winform.Vis.Properties.Resources.Search;
            this.Filterbutton.Location = new System.Drawing.Point(1032, 3);
            this.Filterbutton.Name = "Filterbutton";
            this.Filterbutton.Padding = new System.Windows.Forms.Padding(5);
            this.Filterbutton.Size = new System.Drawing.Size(28, 26);
            this.Filterbutton.TabIndex = 3;
            // 
            // TreeFilterTextBox
            // 
            this.TreeFilterTextBox.Location = new System.Drawing.Point(1060, 3);
            this.TreeFilterTextBox.Name = "TreeFilterTextBox";
            this.TreeFilterTextBox.Size = new System.Drawing.Size(136, 26);
            this.TreeFilterTextBox.TabIndex = 1;
            // 
            // BackGroundpanel
            // 
            this.BackGroundpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackGroundpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.BackGroundpanel.Controls.Add(this.MenuSplitContainer1);
            this.BackGroundpanel.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.BackGroundpanel.Location = new System.Drawing.Point(3, 32);
            this.BackGroundpanel.Name = "BackGroundpanel";
            this.BackGroundpanel.Padding = new System.Windows.Forms.Padding(5);
            this.BackGroundpanel.Size = new System.Drawing.Size(1274, 668);
            this.BackGroundpanel.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.BackGroundpanel.TabIndex = 0;
            this.BackGroundpanel.Text = "panel1";
            // 
            // MenuSplitContainer1
            // 
            this.MenuSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuSplitContainer1.Location = new System.Drawing.Point(5, 5);
            this.MenuSplitContainer1.Name = "MenuSplitContainer1";
            this.MenuSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MenuSplitContainer1.Panel1
            // 
            this.MenuSplitContainer1.Panel1.Controls.Add(this.AppmenuStrip);
            this.MenuSplitContainer1.Panel1.Controls.Add(this.Beepmenustrip);
            // 
            // MenuSplitContainer1.Panel2
            // 
            this.MenuSplitContainer1.Panel2.Controls.Add(this.MainSplitContainer1);
            this.MenuSplitContainer1.Size = new System.Drawing.Size(1264, 658);
            this.MenuSplitContainer1.SplitterDistance = 49;
            this.MenuSplitContainer1.TabIndex = 0;
            // 
            // AppmenuStrip
            // 
            this.AppmenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.AppmenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.AppmenuStrip.Location = new System.Drawing.Point(0, 24);
            this.AppmenuStrip.Name = "AppmenuStrip";
            this.AppmenuStrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.AppmenuStrip.Size = new System.Drawing.Size(1264, 24);
            this.AppmenuStrip.TabIndex = 0;
            this.AppmenuStrip.Text = "crownMenuStrip1";
            // 
            // Beepmenustrip
            // 
            this.Beepmenustrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Beepmenustrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Beepmenustrip.Location = new System.Drawing.Point(0, 0);
            this.Beepmenustrip.Name = "Beepmenustrip";
            this.Beepmenustrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.Beepmenustrip.Size = new System.Drawing.Size(1264, 24);
            this.Beepmenustrip.TabIndex = 1;
            this.Beepmenustrip.Text = "crownMenuStrip2";
            // 
            // MainSplitContainer1
            // 
            this.MainSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer1.Name = "MainSplitContainer1";
            // 
            // MainSplitContainer1.Panel1
            // 
            this.MainSplitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.MainSplitContainer1.Panel1.Controls.Add(this.sidepanelView);
            // 
            // MainSplitContainer1.Panel2
            // 
            this.MainSplitContainer1.Panel2.Controls.Add(this.MainViewsplitContainer);
            this.MainSplitContainer1.Size = new System.Drawing.Size(1264, 605);
            this.MainSplitContainer1.SplitterDistance = 274;
            this.MainSplitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ApptoolStrip, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BeeptoolStrip, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(60, 603);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // ApptoolStrip
            // 
            this.ApptoolStrip.AutoSize = false;
            this.ApptoolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ApptoolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApptoolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ApptoolStrip.Location = new System.Drawing.Point(30, 0);
            this.ApptoolStrip.Name = "ApptoolStrip";
            this.ApptoolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ApptoolStrip.Size = new System.Drawing.Size(30, 603);
            this.ApptoolStrip.Stretch = true;
            this.ApptoolStrip.TabIndex = 3;
            this.ApptoolStrip.Text = "crownToolStrip2";
            // 
            // BeeptoolStrip
            // 
            this.BeeptoolStrip.AutoSize = false;
            this.BeeptoolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.BeeptoolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeeptoolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.BeeptoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.BeeptoolStrip.Location = new System.Drawing.Point(0, 0);
            this.BeeptoolStrip.Name = "BeeptoolStrip";
            this.BeeptoolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.BeeptoolStrip.Size = new System.Drawing.Size(30, 603);
            this.BeeptoolStrip.Stretch = true;
            this.BeeptoolStrip.TabIndex = 2;
            this.BeeptoolStrip.Text = "crownToolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // sidepanelView
            // 
            this.sidepanelView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.sidepanelView.Controls.Add(this.SidePanelContainer);
            this.sidepanelView.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.sidepanelView.Location = new System.Drawing.Point(61, 3);
            this.sidepanelView.Name = "sidepanelView";
            this.sidepanelView.Padding = new System.Windows.Forms.Padding(1);
            this.sidepanelView.Size = new System.Drawing.Size(210, 599);
            this.sidepanelView.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.sidepanelView.TabIndex = 0;
            this.sidepanelView.Text = "panel1";
            // 
            // SidePanelContainer
            // 
            this.SidePanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidePanelContainer.Location = new System.Drawing.Point(1, 1);
            this.SidePanelContainer.Name = "SidePanelContainer";
            this.SidePanelContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SidePanelContainer.Panel1
            // 
            this.SidePanelContainer.Panel1.Controls.Add(this.SidePanelCollapsebutton);
            this.SidePanelContainer.Panel1.Controls.Add(this.AppTreeView);
            // 
            // SidePanelContainer.Panel2
            // 
            this.SidePanelContainer.Panel2.Controls.Add(this.BeepTreeView);
            this.SidePanelContainer.Size = new System.Drawing.Size(208, 597);
            this.SidePanelContainer.SplitterDistance = 325;
            this.SidePanelContainer.TabIndex = 0;
            // 
            // SidePanelCollapsebutton
            // 
            this.SidePanelCollapsebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SidePanelCollapsebutton.Location = new System.Drawing.Point(189, 301);
            this.SidePanelCollapsebutton.Name = "SidePanelCollapsebutton";
            this.SidePanelCollapsebutton.Padding = new System.Windows.Forms.Padding(5);
            this.SidePanelCollapsebutton.Size = new System.Drawing.Size(16, 21);
            this.SidePanelCollapsebutton.TabIndex = 3;
            // 
            // AppTreeView
            // 
            this.AppTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.AppTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.AppTreeView.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.AppTreeView.ForeColor = System.Drawing.Color.White;
            this.AppTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.AppTreeView.Location = new System.Drawing.Point(0, 0);
            this.AppTreeView.Name = "AppTreeView";
            this.AppTreeView.Size = new System.Drawing.Size(208, 325);
            this.AppTreeView.TabIndex = 4;
            // 
            // BeepTreeView
            // 
            this.BeepTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BeepTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.BeepTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.BeepTreeView.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.BeepTreeView.ForeColor = System.Drawing.Color.White;
            this.BeepTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.BeepTreeView.Location = new System.Drawing.Point(0, 0);
            this.BeepTreeView.Name = "BeepTreeView";
            this.BeepTreeView.Size = new System.Drawing.Size(208, 268);
            this.BeepTreeView.TabIndex = 0;
            // 
            // MainViewsplitContainer
            // 
            this.MainViewsplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainViewsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainViewsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainViewsplitContainer.Name = "MainViewsplitContainer";
            this.MainViewsplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainViewsplitContainer.Panel1
            // 
            this.MainViewsplitContainer.Panel1.Controls.Add(this.MinMaxButton);
            this.MainViewsplitContainer.Panel1.Controls.Add(this.LogPanelCollapsebutton);
            this.MainViewsplitContainer.Panel1.Controls.Add(this.uc_Container1);
            // 
            // MainViewsplitContainer.Panel2
            // 
            this.MainViewsplitContainer.Panel2.Controls.Add(this.ClearLogPanelButton);
            this.MainViewsplitContainer.Panel2.Controls.Add(this.LogPanel);
            this.MainViewsplitContainer.Size = new System.Drawing.Size(986, 605);
            this.MainViewsplitContainer.SplitterDistance = 478;
            this.MainViewsplitContainer.SplitterWidth = 5;
            this.MainViewsplitContainer.TabIndex = 0;
            // 
            // MinMaxButton
            // 
            this.MinMaxButton.Location = new System.Drawing.Point(4, 4);
            this.MinMaxButton.Name = "MinMaxButton";
            this.MinMaxButton.Padding = new System.Windows.Forms.Padding(5);
            this.MinMaxButton.Size = new System.Drawing.Size(16, 21);
            this.MinMaxButton.TabIndex = 4;
            // 
            // LogPanelCollapsebutton
            // 
            this.LogPanelCollapsebutton.Location = new System.Drawing.Point(964, 452);
            this.LogPanelCollapsebutton.Name = "LogPanelCollapsebutton";
            this.LogPanelCollapsebutton.Padding = new System.Windows.Forms.Padding(5);
            this.LogPanelCollapsebutton.Size = new System.Drawing.Size(16, 21);
            this.LogPanelCollapsebutton.TabIndex = 3;
            // 
            // uc_Container1
            // 
            this.uc_Container1.AutoScroll = true;
            this.uc_Container1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_Container1.ContainerType = ContainerTypeEnum.SinglePanel;
            this.uc_Container1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Container1.Location = new System.Drawing.Point(0, 0);
            this.uc_Container1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uc_Container1.Name = "uc_Container1";
            this.uc_Container1.Size = new System.Drawing.Size(984, 476);
            this.uc_Container1.TabIndex = 3;
            // 
            // ClearLogPanelButton
            // 
            this.ClearLogPanelButton.Location = new System.Drawing.Point(964, 3);
            this.ClearLogPanelButton.Name = "ClearLogPanelButton";
            this.ClearLogPanelButton.Padding = new System.Windows.Forms.Padding(5);
            this.ClearLogPanelButton.Size = new System.Drawing.Size(16, 21);
            this.ClearLogPanelButton.TabIndex = 4;
            // 
            // LogPanel
            // 
            this.LogPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.LogPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LogPanel.Location = new System.Drawing.Point(0, 32);
            this.LogPanel.Multiline = true;
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogPanel.Size = new System.Drawing.Size(984, 88);
            this.LogPanel.TabIndex = 0;
            // 
            // Frm_Main_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 700);
            this.Controls.Add(this.airForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(112, 35);
            this.Name = "Frm_Main_1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formTheme1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.airForm1.ResumeLayout(false);
            this.BackGroundpanel.ResumeLayout(false);
            this.MenuSplitContainer1.Panel1.ResumeLayout(false);
            this.MenuSplitContainer1.Panel1.PerformLayout();
            this.MenuSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MenuSplitContainer1)).EndInit();
            this.MenuSplitContainer1.ResumeLayout(false);
            this.MainSplitContainer1.Panel1.ResumeLayout(false);
            this.MainSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer1)).EndInit();
            this.MainSplitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.BeeptoolStrip.ResumeLayout(false);
            this.BeeptoolStrip.PerformLayout();
            this.sidepanelView.ResumeLayout(false);
            this.SidePanelContainer.Panel1.ResumeLayout(false);
            this.SidePanelContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SidePanelContainer)).EndInit();
            this.SidePanelContainer.ResumeLayout(false);
            this.MainViewsplitContainer.Panel1.ResumeLayout(false);
            this.MainViewsplitContainer.Panel2.ResumeLayout(false);
            this.MainViewsplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewsplitContainer)).EndInit();
            this.MainViewsplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Manager.MetroStyleManager metroStyleManager1;
        private ReaLTaiizor.Forms.AirForm airForm1;
        private ReaLTaiizor.Controls.Panel BackGroundpanel;
        private System.Windows.Forms.SplitContainer MenuSplitContainer1;
        private System.Windows.Forms.SplitContainer MainSplitContainer1;
        private System.Windows.Forms.SplitContainer MainViewsplitContainer;
        private ReaLTaiizor.Controls.CrownMenuStrip Beepmenustrip;
        private ReaLTaiizor.Controls.Panel sidepanelView;
        private System.Windows.Forms.SplitContainer SidePanelContainer;
        private ReaLTaiizor.Controls.CrownTextBox LogPanel;
        private ReaLTaiizor.Controls.CrownButton ClearLogPanelButton;
        private ReaLTaiizor.Controls.CrownButton LogPanelCollapsebutton;
        private ReaLTaiizor.Controls.CrownDropDownList TreeFilterTextBox;
        private ReaLTaiizor.Controls.CrownMenuStrip AppmenuStrip;
        private ReaLTaiizor.Controls.CrownButton Filterbutton;
        private ReaLTaiizor.Controls.CrownButton SidePanelCollapsebutton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ReaLTaiizor.Controls.CrownToolStrip ApptoolStrip;
        private ReaLTaiizor.Controls.CrownToolStrip BeeptoolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ReaLTaiizor.Controls.ForeverTreeView AppTreeView;
        private ReaLTaiizor.Controls.ForeverTreeView BeepTreeView;
        private ReaLTaiizor.Controls.CrownButton MinMaxButton;
        private uc_Container_1 uc_Container1;
    }
}