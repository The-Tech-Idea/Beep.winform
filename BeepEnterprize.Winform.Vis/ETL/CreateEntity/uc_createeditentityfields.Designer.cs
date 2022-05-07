namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    partial class uc_createeditentityfields
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fieldIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isKeyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.size1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericPrecisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericScaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAutoIncrementDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allowDBNullDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCheckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isUniqueDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Location = new System.Drawing.Point(260, 5);
            // 
            // fieldsBindingSource
            // 
            this.fieldsBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityField);
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
            this.uc_bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_bindingNavigator1.BackColor = System.Drawing.Color.White;
            this.uc_bindingNavigator1.bindingSource = this.fieldsBindingSource;
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(12, 561);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Orange;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(847, 28);
            this.uc_bindingNavigator1.TabIndex = 35;
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
            this.fieldIndexDataGridViewTextBoxColumn,
            this.fieldnameDataGridViewTextBoxColumn,
            this.fieldtypeDataGridViewTextBoxColumn,
            this.isKeyDataGridViewCheckBoxColumn,
            this.size1DataGridViewTextBoxColumn,
            this.numericPrecisionDataGridViewTextBoxColumn,
            this.numericScaleDataGridViewTextBoxColumn,
            this.isAutoIncrementDataGridViewCheckBoxColumn,
            this.allowDBNullDataGridViewCheckBoxColumn,
            this.isCheckDataGridViewCheckBoxColumn,
            this.isUniqueDataGridViewCheckBoxColumn,
            this.checkedDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.fieldsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(847, 489);
            this.dataGridView1.TabIndex = 34;
            // 
            // fieldIndexDataGridViewTextBoxColumn
            // 
            this.fieldIndexDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fieldIndexDataGridViewTextBoxColumn.DataPropertyName = "FieldIndex";
            this.fieldIndexDataGridViewTextBoxColumn.HeaderText = "Idx";
            this.fieldIndexDataGridViewTextBoxColumn.Name = "fieldIndexDataGridViewTextBoxColumn";
            this.fieldIndexDataGridViewTextBoxColumn.Width = 46;
            // 
            // fieldnameDataGridViewTextBoxColumn
            // 
            this.fieldnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fieldnameDataGridViewTextBoxColumn.DataPropertyName = "fieldname";
            this.fieldnameDataGridViewTextBoxColumn.HeaderText = "FieldName";
            this.fieldnameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.fieldnameDataGridViewTextBoxColumn.Name = "fieldnameDataGridViewTextBoxColumn";
            // 
            // fieldtypeDataGridViewTextBoxColumn
            // 
            this.fieldtypeDataGridViewTextBoxColumn.DataPropertyName = "fieldtype";
            this.fieldtypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.fieldtypeDataGridViewTextBoxColumn.Name = "fieldtypeDataGridViewTextBoxColumn";
            this.fieldtypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldtypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isKeyDataGridViewCheckBoxColumn
            // 
            this.isKeyDataGridViewCheckBoxColumn.DataPropertyName = "IsKey";
            this.isKeyDataGridViewCheckBoxColumn.HeaderText = "IsKey";
            this.isKeyDataGridViewCheckBoxColumn.Name = "isKeyDataGridViewCheckBoxColumn";
            // 
            // size1DataGridViewTextBoxColumn
            // 
            this.size1DataGridViewTextBoxColumn.DataPropertyName = "Size1";
            this.size1DataGridViewTextBoxColumn.HeaderText = "Size1";
            this.size1DataGridViewTextBoxColumn.Name = "size1DataGridViewTextBoxColumn";
            // 
            // numericPrecisionDataGridViewTextBoxColumn
            // 
            this.numericPrecisionDataGridViewTextBoxColumn.DataPropertyName = "NumericPrecision";
            this.numericPrecisionDataGridViewTextBoxColumn.HeaderText = "Precision";
            this.numericPrecisionDataGridViewTextBoxColumn.Name = "numericPrecisionDataGridViewTextBoxColumn";
            // 
            // numericScaleDataGridViewTextBoxColumn
            // 
            this.numericScaleDataGridViewTextBoxColumn.DataPropertyName = "NumericScale";
            this.numericScaleDataGridViewTextBoxColumn.HeaderText = "Scale";
            this.numericScaleDataGridViewTextBoxColumn.Name = "numericScaleDataGridViewTextBoxColumn";
            // 
            // isAutoIncrementDataGridViewCheckBoxColumn
            // 
            this.isAutoIncrementDataGridViewCheckBoxColumn.DataPropertyName = "IsAutoIncrement";
            this.isAutoIncrementDataGridViewCheckBoxColumn.HeaderText = "IsAutoIncrement";
            this.isAutoIncrementDataGridViewCheckBoxColumn.Name = "isAutoIncrementDataGridViewCheckBoxColumn";
            // 
            // allowDBNullDataGridViewCheckBoxColumn
            // 
            this.allowDBNullDataGridViewCheckBoxColumn.DataPropertyName = "AllowDBNull";
            this.allowDBNullDataGridViewCheckBoxColumn.HeaderText = "AllowDBNull";
            this.allowDBNullDataGridViewCheckBoxColumn.Name = "allowDBNullDataGridViewCheckBoxColumn";
            // 
            // isCheckDataGridViewCheckBoxColumn
            // 
            this.isCheckDataGridViewCheckBoxColumn.DataPropertyName = "IsCheck";
            this.isCheckDataGridViewCheckBoxColumn.HeaderText = "IsCheck";
            this.isCheckDataGridViewCheckBoxColumn.Name = "isCheckDataGridViewCheckBoxColumn";
            // 
            // isUniqueDataGridViewCheckBoxColumn
            // 
            this.isUniqueDataGridViewCheckBoxColumn.DataPropertyName = "IsUnique";
            this.isUniqueDataGridViewCheckBoxColumn.HeaderText = "IsUnique";
            this.isUniqueDataGridViewCheckBoxColumn.Name = "isUniqueDataGridViewCheckBoxColumn";
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "Checked";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            // 
            // uc_createeditentityfields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "uc_createeditentityfields";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.uc_bindingNavigator1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource fieldsBindingSource;
        private Beep.Winform.Controls.uc_bindingNavigator uc_bindingNavigator1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isKeyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn size1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numericPrecisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numericScaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAutoIncrementDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowDBNullDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUniqueDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
    }
}
