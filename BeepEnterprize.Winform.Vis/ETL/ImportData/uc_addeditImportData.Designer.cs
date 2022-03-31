namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    partial class uc_addeditImportData
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
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EntitysourcecomboBox = new System.Windows.Forms.ComboBox();
            this.mappedEntitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SourceDatasourcecomboBox = new System.Windows.Forms.ComboBox();
            this.kryptonLabel5 = new System.Windows.Forms.Label();
            this.kryptonLabel4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappedEntitiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // EntitysourcecomboBox
            // 
            this.EntitysourcecomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EntitysourcecomboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mappedEntitiesBindingSource, "EntityName", true));
            this.EntitysourcecomboBox.FormattingEnabled = true;
            this.EntitysourcecomboBox.Location = new System.Drawing.Point(181, 58);
            this.EntitysourcecomboBox.Name = "EntitysourcecomboBox";
            this.EntitysourcecomboBox.Size = new System.Drawing.Size(256, 21);
            this.EntitysourcecomboBox.TabIndex = 38;
            // 
            // SourceDatasourcecomboBox
            // 
            this.SourceDatasourcecomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SourceDatasourcecomboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mappedEntitiesBindingSource, "EntityDataSource", true));
            this.SourceDatasourcecomboBox.DataSource = this.dataConnectionsBindingSource;
            this.SourceDatasourcecomboBox.DisplayMember = "ConnectionName";
            this.SourceDatasourcecomboBox.FormattingEnabled = true;
            this.SourceDatasourcecomboBox.Location = new System.Drawing.Point(181, 31);
            this.SourceDatasourcecomboBox.Name = "SourceDatasourcecomboBox";
            this.SourceDatasourcecomboBox.Size = new System.Drawing.Size(256, 21);
            this.SourceDatasourcecomboBox.TabIndex = 37;
            this.SourceDatasourcecomboBox.ValueMember = "ConnectionName";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kryptonLabel5.BackColor = System.Drawing.Color.Orange;
            this.kryptonLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kryptonLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.ForeColor = System.Drawing.Color.White;
            this.kryptonLabel5.Location = new System.Drawing.Point(33, 58);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(146, 20);
            this.kryptonLabel5.TabIndex = 34;
            this.kryptonLabel5.Text = "Entity";
            this.kryptonLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kryptonLabel4.BackColor = System.Drawing.Color.Orange;
            this.kryptonLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kryptonLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.White;
            this.kryptonLabel4.Location = new System.Drawing.Point(33, 31);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(146, 20);
            this.kryptonLabel4.TabIndex = 33;
            this.kryptonLabel4.Text = "Data Source";
            this.kryptonLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uc_addeditImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.EntitysourcecomboBox);
            this.Controls.Add(this.SourceDatasourcecomboBox);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel4);
            this.Name = "uc_addeditImportData";
            this.Size = new System.Drawing.Size(461, 103);
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappedEntitiesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
        private System.Windows.Forms.ComboBox EntitysourcecomboBox;
        private System.Windows.Forms.ComboBox SourceDatasourcecomboBox;
        private System.Windows.Forms.Label kryptonLabel5;
        private System.Windows.Forms.Label kryptonLabel4;
        private System.Windows.Forms.BindingSource mappedEntitiesBindingSource;
    }
}
