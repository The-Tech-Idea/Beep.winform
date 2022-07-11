
namespace BeepEnterprize.Winform.Vis.MainForms
{
    partial class Frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.Toppanel = new System.Windows.Forms.Panel();
            this.ApptoolStrip = new System.Windows.Forms.ToolStrip();
            this.MaintoolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MainmenuStrip = new System.Windows.Forms.MenuStrip();
            this.MainSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SidePanelContainer = new System.Windows.Forms.SplitContainer();
            this.SidePanelCollapsebutton = new System.Windows.Forms.Button();
            this.PlugintreeView = new System.Windows.Forms.TreeView();
            this.FilterTextboxLine2 = new System.Windows.Forms.Panel();
            this.TextFilterLine = new System.Windows.Forms.Panel();
            this.Filterbutton = new System.Windows.Forms.Button();
            this.TreeFilterTextBox = new System.Windows.Forms.TextBox();
            this.DatatreeView = new System.Windows.Forms.TreeView();
            this.MainViewsplitContainer = new System.Windows.Forms.SplitContainer();
            this.MinMaxButton = new System.Windows.Forms.Button();
            this.LogPanelCollapsebutton = new System.Windows.Forms.Button();
            this.ContainerPanel = new BeepEnterprize.Winform.Vis.Controls.uc_Container();
            this.LogPanel = new System.Windows.Forms.TextBox();
            this.Toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer1)).BeginInit();
            this.MainSplitContainer1.Panel1.SuspendLayout();
            this.MainSplitContainer1.Panel2.SuspendLayout();
            this.MainSplitContainer1.SuspendLayout();
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
            // Toppanel
            // 
            this.Toppanel.Controls.Add(this.ApptoolStrip);
            this.Toppanel.Controls.Add(this.MaintoolStrip1);
            this.Toppanel.Controls.Add(this.MainmenuStrip);
            this.Toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toppanel.Location = new System.Drawing.Point(0, 0);
            this.Toppanel.Name = "Toppanel";
            this.Toppanel.Size = new System.Drawing.Size(1184, 69);
            this.Toppanel.TabIndex = 0;
            // 
            // ApptoolStrip
            // 
            this.ApptoolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ApptoolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ApptoolStrip.Location = new System.Drawing.Point(0, 24);
            this.ApptoolStrip.Name = "ApptoolStrip";
            this.ApptoolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ApptoolStrip.Size = new System.Drawing.Size(1184, 25);
            this.ApptoolStrip.Stretch = true;
            this.ApptoolStrip.TabIndex = 2;
            this.ApptoolStrip.Text = "toolStrip1";
            // 
            // MaintoolStrip1
            // 
            this.MaintoolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MaintoolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaintoolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MaintoolStrip1.Location = new System.Drawing.Point(0, 44);
            this.MaintoolStrip1.Name = "MaintoolStrip1";
            this.MaintoolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.MaintoolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.MaintoolStrip1.Stretch = true;
            this.MaintoolStrip1.TabIndex = 1;
            this.MaintoolStrip1.Text = "toolStrip1";
            // 
            // MainmenuStrip
            // 
            this.MainmenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainmenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainmenuStrip.Name = "MainmenuStrip";
            this.MainmenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.MainmenuStrip.Size = new System.Drawing.Size(1184, 24);
            this.MainmenuStrip.TabIndex = 0;
            this.MainmenuStrip.Text = "menuStrip1";
            // 
            // MainSplitContainer1
            // 
            this.MainSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer1.Location = new System.Drawing.Point(0, 69);
            this.MainSplitContainer1.Name = "MainSplitContainer1";
            // 
            // MainSplitContainer1.Panel1
            // 
            this.MainSplitContainer1.Panel1.Controls.Add(this.SidePanelContainer);
            // 
            // MainSplitContainer1.Panel2
            // 
            this.MainSplitContainer1.Panel2.Controls.Add(this.MainViewsplitContainer);
            this.MainSplitContainer1.Size = new System.Drawing.Size(1184, 712);
            this.MainSplitContainer1.SplitterDistance = 242;
            this.MainSplitContainer1.SplitterWidth = 2;
            this.MainSplitContainer1.TabIndex = 1;
            // 
            // SidePanelContainer
            // 
            this.SidePanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidePanelContainer.Location = new System.Drawing.Point(0, 0);
            this.SidePanelContainer.Name = "SidePanelContainer";
            this.SidePanelContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SidePanelContainer.Panel1
            // 
            this.SidePanelContainer.Panel1.Controls.Add(this.SidePanelCollapsebutton);
            this.SidePanelContainer.Panel1.Controls.Add(this.PlugintreeView);
            this.SidePanelContainer.Panel1.Controls.Add(this.FilterTextboxLine2);
            this.SidePanelContainer.Panel1.Controls.Add(this.TextFilterLine);
            this.SidePanelContainer.Panel1.Controls.Add(this.Filterbutton);
            this.SidePanelContainer.Panel1.Controls.Add(this.TreeFilterTextBox);
            // 
            // SidePanelContainer.Panel2
            // 
            this.SidePanelContainer.Panel2.Controls.Add(this.DatatreeView);
            this.SidePanelContainer.Size = new System.Drawing.Size(242, 712);
            this.SidePanelContainer.SplitterDistance = 398;
            this.SidePanelContainer.SplitterWidth = 1;
            this.SidePanelContainer.TabIndex = 0;
            // 
            // SidePanelCollapsebutton
            // 
            this.SidePanelCollapsebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SidePanelCollapsebutton.BackColor = System.Drawing.Color.Transparent;
            this.SidePanelCollapsebutton.Location = new System.Drawing.Point(219, 376);
            this.SidePanelCollapsebutton.Name = "SidePanelCollapsebutton";
            this.SidePanelCollapsebutton.Size = new System.Drawing.Size(20, 17);
            this.SidePanelCollapsebutton.TabIndex = 15;
            this.SidePanelCollapsebutton.UseVisualStyleBackColor = false;
            // 
            // PlugintreeView
            // 
            this.PlugintreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlugintreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlugintreeView.FullRowSelect = true;
            this.PlugintreeView.HideSelection = false;
            this.PlugintreeView.HotTracking = true;
            this.PlugintreeView.Location = new System.Drawing.Point(0, 39);
            this.PlugintreeView.Name = "PlugintreeView";
            this.PlugintreeView.ShowNodeToolTips = true;
            this.PlugintreeView.Size = new System.Drawing.Size(243, 356);
            this.PlugintreeView.TabIndex = 14;
            // 
            // FilterTextboxLine2
            // 
            this.FilterTextboxLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextboxLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterTextboxLine2.Location = new System.Drawing.Point(1, 7);
            this.FilterTextboxLine2.Name = "FilterTextboxLine2";
            this.FilterTextboxLine2.Size = new System.Drawing.Size(239, 2);
            this.FilterTextboxLine2.TabIndex = 12;
            // 
            // TextFilterLine
            // 
            this.TextFilterLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextFilterLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextFilterLine.Location = new System.Drawing.Point(1, 35);
            this.TextFilterLine.Name = "TextFilterLine";
            this.TextFilterLine.Size = new System.Drawing.Size(239, 2);
            this.TextFilterLine.TabIndex = 11;
            // 
            // Filterbutton
            // 
            this.Filterbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filterbutton.FlatAppearance.BorderSize = 0;
            this.Filterbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filterbutton.Location = new System.Drawing.Point(213, 8);
            this.Filterbutton.Name = "Filterbutton";
            this.Filterbutton.Size = new System.Drawing.Size(26, 29);
            this.Filterbutton.TabIndex = 10;
            this.Filterbutton.UseVisualStyleBackColor = true;
            // 
            // TreeFilterTextBox
            // 
            this.TreeFilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeFilterTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.TreeFilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeFilterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeFilterTextBox.Location = new System.Drawing.Point(6, 13);
            this.TreeFilterTextBox.Name = "TreeFilterTextBox";
            this.TreeFilterTextBox.Size = new System.Drawing.Size(201, 17);
            this.TreeFilterTextBox.TabIndex = 9;
            // 
            // DatatreeView
            // 
            this.DatatreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatatreeView.Location = new System.Drawing.Point(0, 0);
            this.DatatreeView.Name = "DatatreeView";
            this.DatatreeView.Size = new System.Drawing.Size(242, 313);
            this.DatatreeView.TabIndex = 2;
            // 
            // MainViewsplitContainer
            // 
            this.MainViewsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainViewsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainViewsplitContainer.Name = "MainViewsplitContainer";
            this.MainViewsplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainViewsplitContainer.Panel1
            // 
            this.MainViewsplitContainer.Panel1.Controls.Add(this.MinMaxButton);
            this.MainViewsplitContainer.Panel1.Controls.Add(this.LogPanelCollapsebutton);
            this.MainViewsplitContainer.Panel1.Controls.Add(this.ContainerPanel);
            // 
            // MainViewsplitContainer.Panel2
            // 
            this.MainViewsplitContainer.Panel2.Controls.Add(this.LogPanel);
            this.MainViewsplitContainer.Size = new System.Drawing.Size(940, 712);
            this.MainViewsplitContainer.SplitterDistance = 624;
            this.MainViewsplitContainer.TabIndex = 17;
            // 
            // MinMaxButton
            // 
            this.MinMaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MinMaxButton.Location = new System.Drawing.Point(1, 12);
            this.MinMaxButton.Name = "MinMaxButton";
            this.MinMaxButton.Size = new System.Drawing.Size(16, 21);
            this.MinMaxButton.TabIndex = 16;
            this.MinMaxButton.UseVisualStyleBackColor = false;
            // 
            // LogPanelCollapsebutton
            // 
            this.LogPanelCollapsebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LogPanelCollapsebutton.BackColor = System.Drawing.Color.Transparent;
            this.LogPanelCollapsebutton.Location = new System.Drawing.Point(896, 604);
            this.LogPanelCollapsebutton.Name = "LogPanelCollapsebutton";
            this.LogPanelCollapsebutton.Size = new System.Drawing.Size(20, 17);
            this.LogPanelCollapsebutton.TabIndex = 16;
            this.LogPanelCollapsebutton.UseVisualStyleBackColor = false;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.ContainerType = BeepEnterprize.Winform.Vis.Controls.ContainerTypeEnum.SinglePanel;
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(940, 624);
            this.ContainerPanel.TabIndex = 17;
            // 
            // LogPanel
            // 
            this.LogPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LogPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel.ForeColor = System.Drawing.Color.White;
            this.LogPanel.Location = new System.Drawing.Point(0, 0);
            this.LogPanel.Multiline = true;
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogPanel.Size = new System.Drawing.Size(940, 84);
            this.LogPanel.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 781);
            this.Controls.Add(this.MainSplitContainer1);
            this.Controls.Add(this.Toppanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainmenuStrip;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beep - The Plugable Integrated Platform";
            this.Toppanel.ResumeLayout(false);
            this.Toppanel.PerformLayout();
            this.MainSplitContainer1.Panel1.ResumeLayout(false);
            this.MainSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer1)).EndInit();
            this.MainSplitContainer1.ResumeLayout(false);
            this.SidePanelContainer.Panel1.ResumeLayout(false);
            this.SidePanelContainer.Panel1.PerformLayout();
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
        private System.Windows.Forms.Panel Toppanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer1;
       // private  System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip MainmenuStrip;
        private System.Windows.Forms.TextBox LogPanel;
        
        private System.Windows.Forms.ToolStrip MaintoolStrip1;
        private System.Windows.Forms.SplitContainer SidePanelContainer;
        private System.Windows.Forms.TreeView PlugintreeView;
        private System.Windows.Forms.Button Filterbutton;
        private System.Windows.Forms.TextBox TreeFilterTextBox;
        private System.Windows.Forms.TreeView DatatreeView;
        private System.Windows.Forms.Panel FilterTextboxLine2;
        private System.Windows.Forms.Panel TextFilterLine;
        private System.Windows.Forms.Button SidePanelCollapsebutton;
        private System.Windows.Forms.Button MinMaxButton;
        private System.Windows.Forms.Button LogPanelCollapsebutton;
        private System.Windows.Forms.SplitContainer MainViewsplitContainer;
        private Controls.uc_Container ContainerPanel;
        private System.Windows.Forms.ToolStrip ApptoolStrip;
    }
}