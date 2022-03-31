namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    partial class uc_createeditentityrelations
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
            this.relationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.beepGrid1 = new Beep.Winform.Controls.BeepGrid();
            this.ralationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedEntityIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedEntityColumnIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityColumnIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityColumnSequenceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beepGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // relationsBindingSource
            // 
            this.relationsBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.RelationShipKeys);
            // 
            // beepGrid1
            // 
            this.beepGrid1.AutoGenerateColumns = false;
            this.beepGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beepGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ralationNameDataGridViewTextBoxColumn,
            this.relatedEntityIDDataGridViewTextBoxColumn,
            this.relatedEntityColumnIDDataGridViewTextBoxColumn,
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn,
            this.entityColumnIDDataGridViewTextBoxColumn,
            this.entityColumnSequenceIDDataGridViewTextBoxColumn});
            this.beepGrid1.DataSource = this.relationsBindingSource;
            this.beepGrid1.Location = new System.Drawing.Point(145, 127);
            this.beepGrid1.Name = "beepGrid1";
            this.beepGrid1.Size = new System.Drawing.Size(663, 413);
            this.beepGrid1.TabIndex = 3;
            // 
            // ralationNameDataGridViewTextBoxColumn
            // 
            this.ralationNameDataGridViewTextBoxColumn.DataPropertyName = "RalationName";
            this.ralationNameDataGridViewTextBoxColumn.HeaderText = "RalationName";
            this.ralationNameDataGridViewTextBoxColumn.Name = "ralationNameDataGridViewTextBoxColumn";
            // 
            // relatedEntityIDDataGridViewTextBoxColumn
            // 
            this.relatedEntityIDDataGridViewTextBoxColumn.DataPropertyName = "RelatedEntityID";
            this.relatedEntityIDDataGridViewTextBoxColumn.HeaderText = "RelatedEntityID";
            this.relatedEntityIDDataGridViewTextBoxColumn.Name = "relatedEntityIDDataGridViewTextBoxColumn";
            // 
            // relatedEntityColumnIDDataGridViewTextBoxColumn
            // 
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.DataPropertyName = "RelatedEntityColumnID";
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.HeaderText = "RelatedEntityColumnID";
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.Name = "relatedEntityColumnIDDataGridViewTextBoxColumn";
            // 
            // relatedColumnSequenceIDDataGridViewTextBoxColumn
            // 
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn.DataPropertyName = "RelatedColumnSequenceID";
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn.HeaderText = "RelatedColumnSequenceID";
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn.Name = "relatedColumnSequenceIDDataGridViewTextBoxColumn";
            // 
            // entityColumnIDDataGridViewTextBoxColumn
            // 
            this.entityColumnIDDataGridViewTextBoxColumn.DataPropertyName = "EntityColumnID";
            this.entityColumnIDDataGridViewTextBoxColumn.HeaderText = "EntityColumnID";
            this.entityColumnIDDataGridViewTextBoxColumn.Name = "entityColumnIDDataGridViewTextBoxColumn";
            // 
            // entityColumnSequenceIDDataGridViewTextBoxColumn
            // 
            this.entityColumnSequenceIDDataGridViewTextBoxColumn.DataPropertyName = "EntityColumnSequenceID";
            this.entityColumnSequenceIDDataGridViewTextBoxColumn.HeaderText = "EntityColumnSequenceID";
            this.entityColumnSequenceIDDataGridViewTextBoxColumn.Name = "entityColumnSequenceIDDataGridViewTextBoxColumn";
            // 
            // uc_createeditentityrelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.beepGrid1);
            this.Name = "uc_createeditentityrelations";
            this.Controls.SetChildIndex(this.beepGrid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beepGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource relationsBindingSource;
        private Beep.Winform.Controls.BeepGrid beepGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ralationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedEntityIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedEntityColumnIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedColumnSequenceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityColumnIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityColumnSequenceIDDataGridViewTextBoxColumn;
    }
}
