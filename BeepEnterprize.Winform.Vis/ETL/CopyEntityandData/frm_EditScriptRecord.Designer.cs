namespace BeepEnterprize.Winform.Vis.ETL.CopyEntityandData
{
    partial class frm_EditScriptRecord
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label destinationentitynameLabel;
            System.Windows.Forms.Label sourceentitynameLabel;
            this.scriptDTLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.destinationentitynameTextBox = new System.Windows.Forms.TextBox();
            this.sourceentitynameTextBox = new System.Windows.Forms.TextBox();
            destinationentitynameLabel = new System.Windows.Forms.Label();
            sourceentitynameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scriptDTLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // scriptDTLBindingSource
            // 
            this.scriptDTLBindingSource.DataSource = typeof(TheTechIdea.Beep.Editor.ETLScriptDet);
            // 
            // destinationentitynameLabel
            // 
            destinationentitynameLabel.AutoSize = true;
            destinationentitynameLabel.Location = new System.Drawing.Point(95, 86);
            destinationentitynameLabel.Name = "destinationentitynameLabel";
            destinationentitynameLabel.Size = new System.Drawing.Size(112, 13);
            destinationentitynameLabel.TabIndex = 1;
            destinationentitynameLabel.Text = "destinationentityname:";
            // 
            // destinationentitynameTextBox
            // 
            this.destinationentitynameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptDTLBindingSource, "destinationentityname", true));
            this.destinationentitynameTextBox.Location = new System.Drawing.Point(213, 83);
            this.destinationentitynameTextBox.Name = "destinationentitynameTextBox";
            this.destinationentitynameTextBox.Size = new System.Drawing.Size(100, 20);
            this.destinationentitynameTextBox.TabIndex = 2;
            // 
            // sourceentitynameLabel
            // 
            sourceentitynameLabel.AutoSize = true;
            sourceentitynameLabel.Location = new System.Drawing.Point(114, 60);
            sourceentitynameLabel.Name = "sourceentitynameLabel";
            sourceentitynameLabel.Size = new System.Drawing.Size(93, 13);
            sourceentitynameLabel.TabIndex = 3;
            sourceentitynameLabel.Text = "sourceentityname:";
            // 
            // sourceentitynameTextBox
            // 
            this.sourceentitynameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptDTLBindingSource, "sourceentityname", true));
            this.sourceentitynameTextBox.Location = new System.Drawing.Point(213, 57);
            this.sourceentitynameTextBox.Name = "sourceentitynameTextBox";
            this.sourceentitynameTextBox.Size = new System.Drawing.Size(100, 20);
            this.sourceentitynameTextBox.TabIndex = 4;
            // 
            // frm_EditScriptRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 188);
            this.Controls.Add(sourceentitynameLabel);
            this.Controls.Add(this.sourceentitynameTextBox);
            this.Controls.Add(destinationentitynameLabel);
            this.Controls.Add(this.destinationentitynameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frm_EditScriptRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Name";
            ((System.ComponentModel.ISupportInitialize)(this.scriptDTLBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource scriptDTLBindingSource;
        private System.Windows.Forms.TextBox destinationentitynameTextBox;
        private System.Windows.Forms.TextBox sourceentitynameTextBox;
    }
}