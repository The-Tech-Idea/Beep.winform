
namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    partial class uc_MapFields
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
            this.DestFieldName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SourceFieldName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FieldMappingGridView = new System.Windows.Forms.DataGridView();
            this.mappedEntitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fieldMappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataMapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fromFieldNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toFieldNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.rulesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FieldMappingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappedEntitiesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldMappingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataMapBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DestFieldName
            // 
            this.DestFieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DestFieldName.DataPropertyName = "FieldName1";
            this.DestFieldName.DropDownWidth = 121;
            this.DestFieldName.HeaderText = "Dest. Field";
            this.DestFieldName.Name = "DestFieldName";
            this.DestFieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DestFieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SourceFieldName
            // 
            this.SourceFieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SourceFieldName.DataPropertyName = "FieldName2";
            this.SourceFieldName.DropDownWidth = 121;
            this.SourceFieldName.HeaderText = "Source Field";
            this.SourceFieldName.Name = "SourceFieldName";
            this.SourceFieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SourceFieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FieldMappingGridView
            // 
            this.FieldMappingGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.FieldMappingGridView.AutoGenerateColumns = false;
            this.FieldMappingGridView.BackgroundColor = System.Drawing.Color.White;
            this.FieldMappingGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldMappingGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FieldMappingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FieldMappingGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fromFieldNameDataGridViewTextBoxColumn,
            this.toFieldNameDataGridViewTextBoxColumn,
            this.rulesDataGridViewTextBoxColumn});
            this.FieldMappingGridView.DataSource = this.fieldMappingBindingSource;
            this.FieldMappingGridView.GridColor = System.Drawing.Color.White;
            this.FieldMappingGridView.Location = new System.Drawing.Point(20, 90);
            this.FieldMappingGridView.Name = "FieldMappingGridView";
            this.FieldMappingGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FieldMappingGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.FieldMappingGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FieldMappingGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            this.FieldMappingGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FieldMappingGridView.Size = new System.Drawing.Size(870, 443);
            this.FieldMappingGridView.TabIndex = 2;
            // 
            // mappedEntitiesBindingSource
            // 
            this.mappedEntitiesBindingSource.DataMember = "MappedEntities";
            this.mappedEntitiesBindingSource.DataSource = this.entityDataMapBindingSource;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map Fields";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 72);
            this.panel1.TabIndex = 6;
            // 
            // fieldMappingBindingSource
            // 
            this.fieldMappingBindingSource.DataMember = "FieldMapping";
            this.fieldMappingBindingSource.DataSource = this.mappedEntitiesBindingSource;
            // 
            // entityDataMapBindingSource
            // 
            this.entityDataMapBindingSource.DataSource = typeof(TheTechIdea.Beep.Workflow.Mapping.EntityDataMap);
            // 
            // fromFieldNameDataGridViewTextBoxColumn
            // 
            this.fromFieldNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fromFieldNameDataGridViewTextBoxColumn.DataPropertyName = "FromFieldName";
            this.fromFieldNameDataGridViewTextBoxColumn.HeaderText = "From FieldName";
            this.fromFieldNameDataGridViewTextBoxColumn.Name = "fromFieldNameDataGridViewTextBoxColumn";
            this.fromFieldNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fromFieldNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fromFieldNameDataGridViewTextBoxColumn.Width = 99;
            // 
            // toFieldNameDataGridViewTextBoxColumn
            // 
            this.toFieldNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.toFieldNameDataGridViewTextBoxColumn.DataPropertyName = "ToFieldName";
            this.toFieldNameDataGridViewTextBoxColumn.HeaderText = "To FieldName";
            this.toFieldNameDataGridViewTextBoxColumn.Name = "toFieldNameDataGridViewTextBoxColumn";
            this.toFieldNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.toFieldNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.toFieldNameDataGridViewTextBoxColumn.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldType1";
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 638;
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
            this.uc_bindingNavigator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uc_bindingNavigator1.BackColor = System.Drawing.Color.White;
            this.uc_bindingNavigator1.bindingSource = this.fieldMappingBindingSource;
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
            this.uc_bindingNavigator1.HightlightColor = System.Drawing.Color.Red;
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(20, 533);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(870, 31);
            this.uc_bindingNavigator1.TabIndex = 7;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // rulesDataGridViewTextBoxColumn
            // 
            this.rulesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rulesDataGridViewTextBoxColumn.DataPropertyName = "Rules";
            this.rulesDataGridViewTextBoxColumn.HeaderText = "Rules";
            this.rulesDataGridViewTextBoxColumn.Name = "rulesDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FieldType2";
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Rules";
            this.dataGridViewTextBoxColumn3.HeaderText = "Rules";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EntityName2";
            this.dataGridViewTextBoxColumn4.HeaderText = "EntityName2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EntityName1";
            this.dataGridViewTextBoxColumn5.HeaderText = "EntityName1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FieldIndex2";
            this.dataGridViewTextBoxColumn6.HeaderText = "FieldIndex2";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FieldIndex1";
            this.dataGridViewTextBoxColumn7.HeaderText = "FieldIndex1";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // uc_MapFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FieldMappingGridView);
            this.Name = "uc_MapFields";
            this.Size = new System.Drawing.Size(920, 570);
            ((System.ComponentModel.ISupportInitialize)(this.FieldMappingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappedEntitiesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldMappingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataMapBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource entityDataMapBindingSource;
        private System.Windows.Forms.BindingSource mappedEntitiesBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn DestFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn SourceFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridView FieldMappingGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewComboBoxColumn SourceFieldComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldType1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DestFieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldType2DataGridViewTextBoxColumn;
        private Beep.Winform.Controls.uc_bindingNavigator uc_bindingNavigator1;
        private System.Windows.Forms.BindingSource fieldMappingBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn fromFieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn toFieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rulesDataGridViewTextBoxColumn;
    }
}
