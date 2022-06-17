
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
            this.MaintoolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MainmenuStrip = new System.Windows.Forms.MenuStrip();
            this.MainSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogPanel = new System.Windows.Forms.TextBox();
            this.SidePanelContainer = new System.Windows.Forms.SplitContainer();
            this.FilterTextboxLine2 = new System.Windows.Forms.Panel();
            this.TextFilterLine = new System.Windows.Forms.Panel();
            this.Filterbutton = new System.Windows.Forms.Button();
            this.TreeFilterTextBox = new System.Windows.Forms.TextBox();
            this.PlugintreeView = new System.Windows.Forms.TreeView();
            this.DatatreeView = new System.Windows.Forms.TreeView();
            this.Toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer1)).BeginInit();
            this.MainSplitContainer1.Panel1.SuspendLayout();
            this.MainSplitContainer1.Panel2.SuspendLayout();
            this.MainSplitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidePanelContainer)).BeginInit();
            this.SidePanelContainer.Panel1.SuspendLayout();
            this.SidePanelContainer.Panel2.SuspendLayout();
            this.SidePanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toppanel
            // 
            this.Toppanel.Controls.Add(this.MaintoolStrip1);
            this.Toppanel.Controls.Add(this.MainmenuStrip);
            this.Toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toppanel.Location = new System.Drawing.Point(0, 0);
            this.Toppanel.Name = "Toppanel";
            this.Toppanel.Size = new System.Drawing.Size(1184, 70);
            this.Toppanel.TabIndex = 0;
            // 
            // MaintoolStrip1
            // 
            this.MaintoolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaintoolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaintoolStrip1.Location = new System.Drawing.Point(0, 24);
            this.MaintoolStrip1.Name = "MaintoolStrip1";
            this.MaintoolStrip1.Size = new System.Drawing.Size(1184, 46);
            this.MaintoolStrip1.TabIndex = 1;
            this.MaintoolStrip1.Text = "toolStrip1";
            // 
            // MainmenuStrip
            // 
            this.MainmenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainmenuStrip.Name = "MainmenuStrip";
            this.MainmenuStrip.Size = new System.Drawing.Size(1184, 24);
            this.MainmenuStrip.TabIndex = 0;
            this.MainmenuStrip.Text = "menuStrip1";
            // 
            // MainSplitContainer1
            // 
            this.MainSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer1.Location = new System.Drawing.Point(0, 70);
            this.MainSplitContainer1.Name = "MainSplitContainer1";
            // 
            // MainSplitContainer1.Panel1
            // 
            this.MainSplitContainer1.Panel1.Controls.Add(this.SidePanelContainer);
            // 
            // MainSplitContainer1.Panel2
            // 
            this.MainSplitContainer1.Panel2.Controls.Add(this.ContainerPanel);
            this.MainSplitContainer1.Panel2.Controls.Add(this.panel1);
            this.MainSplitContainer1.Size = new System.Drawing.Size(1184, 691);
            this.MainSplitContainer1.SplitterDistance = 243;
            this.MainSplitContainer1.SplitterWidth = 2;
            this.MainSplitContainer1.TabIndex = 1;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContainerPanel.BackColor = System.Drawing.Color.White;
            this.ContainerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContainerPanel.Location = new System.Drawing.Point(16, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(919, 617);
            this.ContainerPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LogPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 617);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 74);
            this.panel1.TabIndex = 0;
            // 
            // LogPanel
            // 
            this.LogPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LogPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogPanel.ForeColor = System.Drawing.Color.White;
            this.LogPanel.Location = new System.Drawing.Point(16, 0);
            this.LogPanel.Multiline = true;
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogPanel.Size = new System.Drawing.Size(923, 74);
            this.LogPanel.TabIndex = 0;
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
            this.SidePanelContainer.Panel1.Controls.Add(this.PlugintreeView);
            this.SidePanelContainer.Panel1.Controls.Add(this.FilterTextboxLine2);
            this.SidePanelContainer.Panel1.Controls.Add(this.TextFilterLine);
            this.SidePanelContainer.Panel1.Controls.Add(this.Filterbutton);
            this.SidePanelContainer.Panel1.Controls.Add(this.TreeFilterTextBox);
            // 
            // SidePanelContainer.Panel2
            // 
            this.SidePanelContainer.Panel2.Controls.Add(this.DatatreeView);
            this.SidePanelContainer.Size = new System.Drawing.Size(243, 691);
            this.SidePanelContainer.SplitterDistance = 280;
            this.SidePanelContainer.TabIndex = 0;
            // 
            // FilterTextboxLine2
            // 
            this.FilterTextboxLine2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextboxLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterTextboxLine2.Location = new System.Drawing.Point(14, 8);
            this.FilterTextboxLine2.Name = "FilterTextboxLine2";
            this.FilterTextboxLine2.Size = new System.Drawing.Size(178, 2);
            this.FilterTextboxLine2.TabIndex = 12;
            // 
            // TextFilterLine
            // 
            this.TextFilterLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextFilterLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextFilterLine.Location = new System.Drawing.Point(13, 34);
            this.TextFilterLine.Name = "TextFilterLine";
            this.TextFilterLine.Size = new System.Drawing.Size(178, 2);
            this.TextFilterLine.TabIndex = 11;
            // 
            // Filterbutton
            // 
            this.Filterbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filterbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filterbutton.Location = new System.Drawing.Point(214, 8);
            this.Filterbutton.Name = "Filterbutton";
            this.Filterbutton.Size = new System.Drawing.Size(26, 28);
            this.Filterbutton.TabIndex = 10;
            this.Filterbutton.UseVisualStyleBackColor = true;
            // 
            // TreeFilterTextBox
            // 
            this.TreeFilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeFilterTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.TreeFilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeFilterTextBox.Location = new System.Drawing.Point(16, 16);
            this.TreeFilterTextBox.Name = "TreeFilterTextBox";
            this.TreeFilterTextBox.Size = new System.Drawing.Size(202, 13);
            this.TreeFilterTextBox.TabIndex = 9;
            // 
            // PlugintreeView
            // 
            this.PlugintreeView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PlugintreeView.Location = new System.Drawing.Point(0, 40);
            this.PlugintreeView.Name = "PlugintreeView";
            this.PlugintreeView.Size = new System.Drawing.Size(243, 240);
            this.PlugintreeView.TabIndex = 14;
            // 
            // DatatreeView
            // 
            this.DatatreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatatreeView.Location = new System.Drawing.Point(0, 0);
            this.DatatreeView.Name = "DatatreeView";
            this.DatatreeView.Size = new System.Drawing.Size(243, 407);
            this.DatatreeView.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SidePanelContainer.Panel1.ResumeLayout(false);
            this.SidePanelContainer.Panel1.PerformLayout();
            this.SidePanelContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SidePanelContainer)).EndInit();
            this.SidePanelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Toppanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer1;
        private System.Windows.Forms.Panel panel1;
       // private  System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip MainmenuStrip;
        private System.Windows.Forms.TextBox LogPanel;
        
        private System.Windows.Forms.ToolStrip MaintoolStrip1;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.SplitContainer SidePanelContainer;
        private System.Windows.Forms.TreeView PlugintreeView;
        private System.Windows.Forms.Panel FilterTextboxLine2;
        private System.Windows.Forms.Panel TextFilterLine;
        private System.Windows.Forms.Button Filterbutton;
        private System.Windows.Forms.TextBox TreeFilterTextBox;
        private System.Windows.Forms.TreeView DatatreeView;
    }
}