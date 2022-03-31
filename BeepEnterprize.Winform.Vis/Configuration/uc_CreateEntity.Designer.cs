using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis.Configuration
{
    partial class uc_CreateEntity
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
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
            this.statusdescriptionLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.entitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CreateinDBbutton = new System.Windows.Forms.Button();
            this.SaveTableConfigbutton = new System.Windows.Forms.Button();
            this.fieldsDataGridView = new System.Windows.Forms.DataGridView();
            this.statusdescriptionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.fieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataSourceName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.size1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericPrecisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericScaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAutoIncrementDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allowDBNullDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCheckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isUniqueDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isKeyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusdescriptionLabel
            // 
            this.statusdescriptionLabel.AutoSize = true;
            this.statusdescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusdescriptionLabel.Location = new System.Drawing.Point(181, 127);
            this.statusdescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusdescriptionLabel.Name = "statusdescriptionLabel";
            this.statusdescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.statusdescriptionLabel.TabIndex = 18;
            this.statusdescriptionLabel.Text = "Creating Status:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(207, 86);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(109, 20);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Table Name:";
            // 
            // entitiesBindingSource
            // 
            this.entitiesBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityStructure);
            // 
            // CreateinDBbutton
            // 
            this.CreateinDBbutton.Location = new System.Drawing.Point(576, 160);
            this.CreateinDBbutton.Margin = new System.Windows.Forms.Padding(2);
            this.CreateinDBbutton.Name = "CreateinDBbutton";
            this.CreateinDBbutton.Size = new System.Drawing.Size(237, 26);
            this.CreateinDBbutton.TabIndex = 23;
            this.CreateinDBbutton.Text = "Create";
            this.CreateinDBbutton.UseVisualStyleBackColor = true;
            // 
            // SaveTableConfigbutton
            // 
            this.SaveTableConfigbutton.Location = new System.Drawing.Point(934, 482);
            this.SaveTableConfigbutton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveTableConfigbutton.Name = "SaveTableConfigbutton";
            this.SaveTableConfigbutton.Size = new System.Drawing.Size(79, 26);
            this.SaveTableConfigbutton.TabIndex = 22;
            this.SaveTableConfigbutton.Text = "Save";
            this.SaveTableConfigbutton.UseVisualStyleBackColor = true;
            this.SaveTableConfigbutton.Visible = false;
            // 
            // fieldsDataGridView
            // 
            this.fieldsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fieldsDataGridView.AutoGenerateColumns = false;
            this.fieldsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fieldsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.fieldsDataGridView.ColumnHeadersHeight = 21;
            this.fieldsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldnameDataGridViewTextBoxColumn,
            this.fieldtypeDataGridViewTextBoxColumn,
            this.size1DataGridViewTextBoxColumn,
            this.size2DataGridViewTextBoxColumn,
            this.numericPrecisionDataGridViewTextBoxColumn,
            this.numericScaleDataGridViewTextBoxColumn,
            this.isAutoIncrementDataGridViewCheckBoxColumn,
            this.allowDBNullDataGridViewCheckBoxColumn,
            this.isCheckDataGridViewCheckBoxColumn,
            this.isUniqueDataGridViewCheckBoxColumn,
            this.isKeyDataGridViewCheckBoxColumn,
            this.checkedDataGridViewCheckBoxColumn});
            this.fieldsDataGridView.DataSource = this.fieldsBindingSource;
            this.fieldsDataGridView.Location = new System.Drawing.Point(48, 210);
            this.fieldsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.fieldsDataGridView.Name = "fieldsDataGridView";
            this.fieldsDataGridView.RowHeadersWidth = 62;
            this.fieldsDataGridView.RowTemplate.Height = 28;
            this.fieldsDataGridView.Size = new System.Drawing.Size(920, 299);
            this.fieldsDataGridView.TabIndex = 20;
            // 
            // statusdescriptionTextBox
            // 
            this.statusdescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "StatusDescription", true));
            this.statusdescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusdescriptionTextBox.Location = new System.Drawing.Point(325, 121);
            this.statusdescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.statusdescriptionTextBox.Name = "statusdescriptionTextBox";
            this.statusdescriptionTextBox.Size = new System.Drawing.Size(488, 26);
            this.statusdescriptionTextBox.TabIndex = 19;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "EntityName", true));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(325, 86);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(247, 26);
            this.nameTextBox.TabIndex = 17;
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
            this.uc_bindingNavigator1.BackColor = System.Drawing.Color.White;
            this.uc_bindingNavigator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_bindingNavigator1.ButtonBorderSize = 0;
            this.uc_bindingNavigator1.CausesValidation = false;
            this.uc_bindingNavigator1.ControlHeight = 30;
            this.uc_bindingNavigator1.DefaultCreate = false;
            this.uc_bindingNavigator1.Description = null;
            this.uc_bindingNavigator1.DllName = null;
            this.uc_bindingNavigator1.DllPath = null;
            this.uc_bindingNavigator1.DMEEditor = null;
            this.uc_bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uc_bindingNavigator1.EntityName = null;
            this.uc_bindingNavigator1.EntityStructure = null;
            this.uc_bindingNavigator1.ErrorObject = null;
            this.uc_bindingNavigator1.HightlightColor = System.Drawing.Color.Red;
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(0, 517);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(1079, 31);
            this.uc_bindingNavigator1.TabIndex = 29;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // fieldsBindingSource
            // 
            this.fieldsBindingSource.DataMember = "Fields";
            this.fieldsBindingSource.DataSource = this.entitiesBindingSource;
            // 
            // mappingBindingSource
            // 
            this.mappingBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.DatatypeMapping);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DataSourceName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 68);
            this.panel1.TabIndex = 30;
            // 
            // DataSourceName
            // 
            this.DataSourceName.AutoSize = true;
            this.DataSourceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataSourceName.Location = new System.Drawing.Point(320, 23);
            this.DataSourceName.Name = "DataSourceName";
            this.DataSourceName.Size = new System.Drawing.Size(142, 25);
            this.DataSourceName.TabIndex = 26;
            this.DataSourceName.Text = "Data Source";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "Create Entity";
            // 
            // fieldnameDataGridViewTextBoxColumn
            // 
            this.fieldnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fieldnameDataGridViewTextBoxColumn.DataPropertyName = "fieldname";
            this.fieldnameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.fieldnameDataGridViewTextBoxColumn.Name = "fieldnameDataGridViewTextBoxColumn";
            this.fieldnameDataGridViewTextBoxColumn.Width = 60;
            // 
            // fieldtypeDataGridViewTextBoxColumn
            // 
            this.fieldtypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fieldtypeDataGridViewTextBoxColumn.DataPropertyName = "fieldtype";
            this.fieldtypeDataGridViewTextBoxColumn.DataSource = this.mappingBindingSource;
            this.fieldtypeDataGridViewTextBoxColumn.DisplayMember = "NetDataType";
            this.fieldtypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.fieldtypeDataGridViewTextBoxColumn.Name = "fieldtypeDataGridViewTextBoxColumn";
            this.fieldtypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldtypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fieldtypeDataGridViewTextBoxColumn.ValueMember = "NetDataType";
            this.fieldtypeDataGridViewTextBoxColumn.Width = 56;
            // 
            // size1DataGridViewTextBoxColumn
            // 
            this.size1DataGridViewTextBoxColumn.DataPropertyName = "Size1";
            this.size1DataGridViewTextBoxColumn.HeaderText = "Size1";
            this.size1DataGridViewTextBoxColumn.Name = "size1DataGridViewTextBoxColumn";
            // 
            // size2DataGridViewTextBoxColumn
            // 
            this.size2DataGridViewTextBoxColumn.DataPropertyName = "Size2";
            this.size2DataGridViewTextBoxColumn.HeaderText = "Size2";
            this.size2DataGridViewTextBoxColumn.Name = "size2DataGridViewTextBoxColumn";
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
            // isKeyDataGridViewCheckBoxColumn
            // 
            this.isKeyDataGridViewCheckBoxColumn.DataPropertyName = "IsKey";
            this.isKeyDataGridViewCheckBoxColumn.HeaderText = "IsKey";
            this.isKeyDataGridViewCheckBoxColumn.Name = "isKeyDataGridViewCheckBoxColumn";
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "Checked";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            // 
            // uc_CreateEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fieldsDataGridView);
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.CreateinDBbutton);
            this.Controls.Add(this.SaveTableConfigbutton);
            this.Controls.Add(this.statusdescriptionLabel);
            this.Controls.Add(this.statusdescriptionTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_CreateEntity";
            this.Size = new System.Drawing.Size(1079, 548);
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource entitiesBindingSource;
        private System.Windows.Forms.Button CreateinDBbutton;
        private System.Windows.Forms.Button SaveTableConfigbutton;
        private System.Windows.Forms.DataGridView fieldsDataGridView;
        private System.Windows.Forms.TextBox statusdescriptionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label statusdescriptionLabel;
        private System.Windows.Forms.Label nameLabel;
        private uc_bindingNavigator uc_bindingNavigator1;
        private System.Windows.Forms.BindingSource fieldsBindingSource;
        private System.Windows.Forms.BindingSource mappingBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DataSourceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn size1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn size2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numericPrecisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numericScaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAutoIncrementDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowDBNullDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUniqueDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isKeyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
    }
}
