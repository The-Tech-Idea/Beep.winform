namespace AppBuilder
{
    partial class uc_ScreenDesigner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainsplitContainer = new System.Windows.Forms.SplitContainer();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.Mainpanel = new System.Windows.Forms.Panel();
            this.MenutoolStrip = new System.Windows.Forms.ToolStrip();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).BeginInit();
            this.MainsplitContainer.Panel1.SuspendLayout();
            this.MainsplitContainer.Panel2.SuspendLayout();
            this.MainsplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainsplitContainer
            // 
            this.MainsplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainsplitContainer.Name = "MainsplitContainer";
            // 
            // MainsplitContainer.Panel1
            // 
            this.MainsplitContainer.Panel1.AutoScroll = true;
            this.MainsplitContainer.Panel1.Controls.Add(this.ControlsPanel);
            this.MainsplitContainer.Panel1.Controls.Add(this.Mainpanel);
            this.MainsplitContainer.Panel1.Controls.Add(this.MenutoolStrip);
            // 
            // MainsplitContainer.Panel2
            // 
            this.MainsplitContainer.Panel2.Controls.Add(this.propertyGrid1);
            this.MainsplitContainer.Size = new System.Drawing.Size(986, 720);
            this.MainsplitContainer.SplitterDistance = 779;
            this.MainsplitContainer.TabIndex = 0;
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlsPanel.Location = new System.Drawing.Point(26, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(150, 1191);
            this.ControlsPanel.TabIndex = 0;
            // 
            // Mainpanel
            // 
            this.Mainpanel.AllowDrop = true;
            this.Mainpanel.AutoScroll = true;
            this.Mainpanel.Location = new System.Drawing.Point(182, 3);
            this.Mainpanel.Name = "Mainpanel";
            this.Mainpanel.Size = new System.Drawing.Size(844, 1188);
            this.Mainpanel.TabIndex = 3;
            // 
            // MenutoolStrip
            // 
            this.MenutoolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenutoolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MenutoolStrip.Location = new System.Drawing.Point(0, 0);
            this.MenutoolStrip.Name = "MenutoolStrip";
            this.MenutoolStrip.Size = new System.Drawing.Size(26, 1191);
            this.MenutoolStrip.Stretch = true;
            this.MenutoolStrip.TabIndex = 4;
            this.MenutoolStrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 2);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(201, 718);
            this.propertyGrid1.TabIndex = 0;
            // 
            // uc_ScreenDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainsplitContainer);
            this.Name = "uc_ScreenDesigner";
            this.Size = new System.Drawing.Size(986, 720);
            this.MainsplitContainer.Panel1.ResumeLayout(false);
            this.MainsplitContainer.Panel1.PerformLayout();
            this.MainsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).EndInit();
            this.MainsplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainsplitContainer;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel ControlsPanel;
        public System.Windows.Forms.Panel Mainpanel;
        private System.Windows.Forms.ToolStrip MenutoolStrip;
    }
}
