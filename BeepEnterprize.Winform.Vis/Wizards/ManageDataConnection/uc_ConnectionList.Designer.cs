namespace BeepEnterprize.Winform.Vis.Wizards.ManageDataConnection
{
    partial class uc_ConnectionList
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
            this.components = new System.ComponentModel.Container();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.ConnectionslistcrownListView = new ReaLTaiizor.Controls.CrownListView();
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(3, 0);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(206, 46);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "Connections";
            // 
            // ConnectionslistcrownListView
            // 
            this.ConnectionslistcrownListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionslistcrownListView.Location = new System.Drawing.Point(11, 49);
            this.ConnectionslistcrownListView.Name = "ConnectionslistcrownListView";
            this.ConnectionslistcrownListView.Size = new System.Drawing.Size(523, 520);
            this.ConnectionslistcrownListView.TabIndex = 1;
            this.ConnectionslistcrownListView.Text = "crownListView1";
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // uc_ConnectionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConnectionslistcrownListView);
            this.Controls.Add(this.bigLabel1);
            this.Name = "uc_ConnectionList";
            this.Size = new System.Drawing.Size(537, 579);
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.CrownListView ConnectionslistcrownListView;
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
    }
}
