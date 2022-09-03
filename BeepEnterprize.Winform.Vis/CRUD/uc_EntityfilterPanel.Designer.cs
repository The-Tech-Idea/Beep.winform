namespace BeepEnterprize.Winform.Vis.CRUD
{
    partial class uc_EntityfilterPanel
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
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // FilterPanel
            // 
            this.FilterPanel.BackColor = System.Drawing.Color.White;
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(464, 723);
            this.FilterPanel.TabIndex = 1;
            // 
            // uc_EntityfilterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FilterPanel);
            this.Name = "uc_EntityfilterPanel";
            this.Size = new System.Drawing.Size(464, 723);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FilterPanel;
    }
}
