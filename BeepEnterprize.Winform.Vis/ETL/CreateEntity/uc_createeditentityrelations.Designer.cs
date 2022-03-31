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
            System.Windows.Forms.Label entityColumnIDLabel;
            System.Windows.Forms.Label relatedEntityIDLabel;
            System.Windows.Forms.Label relatedEntityColumnIDLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.relationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ralationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedEntityIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedEntityColumnIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityColumnIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityColumnSequenceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityColumnIDComboBox = new System.Windows.Forms.ComboBox();
            this.relatedEntityIDComboBox = new System.Windows.Forms.ComboBox();
            this.relatedEntityColumnIDComboBox = new System.Windows.Forms.ComboBox();
            entityColumnIDLabel = new System.Windows.Forms.Label();
            relatedEntityIDLabel = new System.Windows.Forms.Label();
            relatedEntityColumnIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityColumnIDLabel
            // 
            entityColumnIDLabel.AutoSize = true;
            entityColumnIDLabel.Location = new System.Drawing.Point(17, 67);
            entityColumnIDLabel.Name = "entityColumnIDLabel";
            entityColumnIDLabel.Size = new System.Drawing.Size(88, 13);
            entityColumnIDLabel.TabIndex = 37;
            entityColumnIDLabel.Text = "Entity Column ID:";
            // 
            // relatedEntityIDLabel
            // 
            relatedEntityIDLabel.AutoSize = true;
            relatedEntityIDLabel.Location = new System.Drawing.Point(242, 67);
            relatedEntityIDLabel.Name = "relatedEntityIDLabel";
            relatedEntityIDLabel.Size = new System.Drawing.Size(90, 13);
            relatedEntityIDLabel.TabIndex = 38;
            relatedEntityIDLabel.Text = "Related Entity ID:";
            // 
            // relatedEntityColumnIDLabel
            // 
            relatedEntityColumnIDLabel.AutoSize = true;
            relatedEntityColumnIDLabel.Location = new System.Drawing.Point(475, 67);
            relatedEntityColumnIDLabel.Name = "relatedEntityColumnIDLabel";
            relatedEntityColumnIDLabel.Size = new System.Drawing.Size(128, 13);
            relatedEntityColumnIDLabel.TabIndex = 39;
            relatedEntityColumnIDLabel.Text = "Related Entity Column ID:";
            // 
            // relationsBindingSource
            // 
            this.relationsBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.RelationShipKeys);
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
            this.uc_bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_bindingNavigator1.BackColor = System.Drawing.Color.White;
            this.uc_bindingNavigator1.bindingSource = this.relationsBindingSource;
            this.uc_bindingNavigator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_bindingNavigator1.ButtonBorderSize = 0;
            this.uc_bindingNavigator1.CausesValidation = false;
            this.uc_bindingNavigator1.ControlHeight = 30;
            this.uc_bindingNavigator1.DefaultCreate = false;
            this.uc_bindingNavigator1.Description = null;
            this.uc_bindingNavigator1.DllName = null;
            this.uc_bindingNavigator1.DllPath = null;
            this.uc_bindingNavigator1.DMEEditor = null;
            this.uc_bindingNavigator1.EntityName = null;
            this.uc_bindingNavigator1.EntityStructure = null;
            this.uc_bindingNavigator1.ErrorObject = null;
            this.uc_bindingNavigator1.HightlightColor = System.Drawing.Color.DodgerBlue;
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(12, 542);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Orange;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(875, 28);
            this.uc_bindingNavigator1.TabIndex = 37;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn,
            this.ralationNameDataGridViewTextBoxColumn,
            this.relatedEntityIDDataGridViewTextBoxColumn,
            this.relatedEntityColumnIDDataGridViewTextBoxColumn,
            this.entityColumnIDDataGridViewTextBoxColumn,
            this.entityColumnSequenceIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.relationsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 109);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(875, 433);
            this.dataGridView1.TabIndex = 36;
            // 
            // relatedColumnSequenceIDDataGridViewTextBoxColumn
            // 
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn.DataPropertyName = "RelatedColumnSequenceID";
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn.HeaderText = "SequenceID";
            this.relatedColumnSequenceIDDataGridViewTextBoxColumn.Name = "relatedColumnSequenceIDDataGridViewTextBoxColumn";
            // 
            // ralationNameDataGridViewTextBoxColumn
            // 
            this.ralationNameDataGridViewTextBoxColumn.DataPropertyName = "RalationName";
            this.ralationNameDataGridViewTextBoxColumn.HeaderText = "Ralation Name";
            this.ralationNameDataGridViewTextBoxColumn.Name = "ralationNameDataGridViewTextBoxColumn";
            // 
            // relatedEntityIDDataGridViewTextBoxColumn
            // 
            this.relatedEntityIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.relatedEntityIDDataGridViewTextBoxColumn.DataPropertyName = "RelatedEntityID";
            this.relatedEntityIDDataGridViewTextBoxColumn.HeaderText = "Related EntityID";
            this.relatedEntityIDDataGridViewTextBoxColumn.Name = "relatedEntityIDDataGridViewTextBoxColumn";
            // 
            // relatedEntityColumnIDDataGridViewTextBoxColumn
            // 
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.DataPropertyName = "RelatedEntityColumnID";
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.HeaderText = "Related EntityColumn";
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.Name = "relatedEntityColumnIDDataGridViewTextBoxColumn";
            this.relatedEntityColumnIDDataGridViewTextBoxColumn.Width = 122;
            // 
            // entityColumnIDDataGridViewTextBoxColumn
            // 
            this.entityColumnIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.entityColumnIDDataGridViewTextBoxColumn.DataPropertyName = "EntityColumnID";
            this.entityColumnIDDataGridViewTextBoxColumn.HeaderText = "Entity Column";
            this.entityColumnIDDataGridViewTextBoxColumn.Name = "entityColumnIDDataGridViewTextBoxColumn";
            this.entityColumnIDDataGridViewTextBoxColumn.Width = 88;
            // 
            // entityColumnSequenceIDDataGridViewTextBoxColumn
            // 
            this.entityColumnSequenceIDDataGridViewTextBoxColumn.DataPropertyName = "EntityColumnSequenceID";
            this.entityColumnSequenceIDDataGridViewTextBoxColumn.HeaderText = "Entity Column Sequence";
            this.entityColumnSequenceIDDataGridViewTextBoxColumn.Name = "entityColumnSequenceIDDataGridViewTextBoxColumn";
            // 
            // entityColumnIDComboBox
            // 
            this.entityColumnIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.relationsBindingSource, "EntityColumnID", true));
            this.entityColumnIDComboBox.FormattingEnabled = true;
            this.entityColumnIDComboBox.Location = new System.Drawing.Point(111, 64);
            this.entityColumnIDComboBox.Name = "entityColumnIDComboBox";
            this.entityColumnIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.entityColumnIDComboBox.TabIndex = 38;
            // 
            // relatedEntityIDComboBox
            // 
            this.relatedEntityIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.relationsBindingSource, "RelatedEntityID", true));
            this.relatedEntityIDComboBox.FormattingEnabled = true;
            this.relatedEntityIDComboBox.Location = new System.Drawing.Point(338, 64);
            this.relatedEntityIDComboBox.Name = "relatedEntityIDComboBox";
            this.relatedEntityIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.relatedEntityIDComboBox.TabIndex = 39;
            // 
            // relatedEntityColumnIDComboBox
            // 
            this.relatedEntityColumnIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.relationsBindingSource, "RelatedEntityColumnID", true));
            this.relatedEntityColumnIDComboBox.FormattingEnabled = true;
            this.relatedEntityColumnIDComboBox.Location = new System.Drawing.Point(609, 64);
            this.relatedEntityColumnIDComboBox.Name = "relatedEntityColumnIDComboBox";
            this.relatedEntityColumnIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.relatedEntityColumnIDComboBox.TabIndex = 40;
            // 
            // uc_createeditentityrelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(relatedEntityColumnIDLabel);
            this.Controls.Add(this.relatedEntityColumnIDComboBox);
            this.Controls.Add(relatedEntityIDLabel);
            this.Controls.Add(this.relatedEntityIDComboBox);
            this.Controls.Add(entityColumnIDLabel);
            this.Controls.Add(this.entityColumnIDComboBox);
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "uc_createeditentityrelations";
            this.Size = new System.Drawing.Size(898, 590);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.uc_bindingNavigator1, 0);
            this.Controls.SetChildIndex(this.entityColumnIDComboBox, 0);
            this.Controls.SetChildIndex(entityColumnIDLabel, 0);
            this.Controls.SetChildIndex(this.relatedEntityIDComboBox, 0);
            this.Controls.SetChildIndex(relatedEntityIDLabel, 0);
            this.Controls.SetChildIndex(this.relatedEntityColumnIDComboBox, 0);
            this.Controls.SetChildIndex(relatedEntityColumnIDLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.BindingSource relationsBindingSource;
        private Beep.Winform.Controls.uc_bindingNavigator uc_bindingNavigator1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedColumnSequenceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ralationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedEntityIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedEntityColumnIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityColumnIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityColumnSequenceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox entityColumnIDComboBox;
        private System.Windows.Forms.ComboBox relatedEntityIDComboBox;
        private System.Windows.Forms.ComboBox relatedEntityColumnIDComboBox;
    }
}
