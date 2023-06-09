namespace BeepEnterprize.Winform.Vis.Wizards.ManageDataConnection
{
    partial class uc_connectionTypes
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
            this.ConnectionTypesListView1 = new ReaLTaiizor.Controls.CrownListView();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.SuspendLayout();
            // 
            // ConnectionTypesListView1
            // 
            this.ConnectionTypesListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionTypesListView1.Location = new System.Drawing.Point(3, 49);
            this.ConnectionTypesListView1.Name = "ConnectionTypesListView1";
            this.ConnectionTypesListView1.Size = new System.Drawing.Size(586, 468);
            this.ConnectionTypesListView1.TabIndex = 1;
            this.ConnectionTypesListView1.Text = "crownListView1";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(3, 0);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(285, 46);
            this.bigLabel1.TabIndex = 2;
            this.bigLabel1.Text = "Connection Types";
            // 
            // uc_connectionTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.ConnectionTypesListView1);
            this.Name = "uc_connectionTypes";
            this.Size = new System.Drawing.Size(592, 517);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.CrownListView ConnectionTypesListView1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}
