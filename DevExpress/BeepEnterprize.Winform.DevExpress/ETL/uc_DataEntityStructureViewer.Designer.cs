
using System.Windows.Forms;

namespace TheTechIdea.ETL
{
    partial class uc_DataEntityStructureViewer
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label customBuildQueryLabel;
            System.Windows.Forms.Label viewIDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label viewtypeLabel;
            System.Windows.Forms.Label dataSourceIDLabel;
            System.Windows.Forms.Label showLabel;
            System.Windows.Forms.Label keyTokenLabel;
            System.Windows.Forms.Label editableLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label captionLabel;
            System.Windows.Forms.Label label4;
            this.primaryKeysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relationShipsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ValidateFieldsbutton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fieldsDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.relationShipsDataGridView = new System.Windows.Forms.DataGridView();
            this.ValidateFKbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customBuildQueryTextBox = new System.Windows.Forms.TextBox();
            this.ValidateQuerybutton = new System.Windows.Forms.Button();
            this.SaveEntitybutton = new System.Windows.Forms.Button();
            this.viewIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.viewtypeComboBox = new System.Windows.Forms.ComboBox();
            this.dataSourceIDComboBox = new System.Windows.Forms.ComboBox();
            this.showCheckBox = new System.Windows.Forms.CheckBox();
            this.keyTokenTextBox = new System.Windows.Forms.TextBox();
            this.editableCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.captionTextBox1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.EntityNameLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataHierarchyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.size1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAutoIncrementDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allowDBNullDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCheckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isUniqueDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isKeyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fieldIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedEntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedEntityColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedColumnSequenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            customBuildQueryLabel = new System.Windows.Forms.Label();
            viewIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            viewtypeLabel = new System.Windows.Forms.Label();
            dataSourceIDLabel = new System.Windows.Forms.Label();
            showLabel = new System.Windows.Forms.Label();
            keyTokenLabel = new System.Windows.Forms.Label();
            editableLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            captionLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.primaryKeysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipsDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHierarchyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            label2.Location = new System.Drawing.Point(15, 10);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 13);
            label2.TabIndex = 16;
            label2.Text = "Fields";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            label1.Location = new System.Drawing.Point(8, 10);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 13);
            label1.TabIndex = 15;
            label1.Text = "Relations";
            // 
            // customBuildQueryLabel
            // 
            customBuildQueryLabel.AutoSize = true;
            customBuildQueryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            customBuildQueryLabel.Location = new System.Drawing.Point(2, 7);
            customBuildQueryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            customBuildQueryLabel.Name = "customBuildQueryLabel";
            customBuildQueryLabel.Size = new System.Drawing.Size(117, 13);
            customBuildQueryLabel.TabIndex = 6;
            customBuildQueryLabel.Text = "Custom Build Query";
            // 
            // viewIDLabel
            // 
            viewIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            viewIDLabel.AutoSize = true;
            viewIDLabel.Location = new System.Drawing.Point(302, 58);
            viewIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            viewIDLabel.Name = "viewIDLabel";
            viewIDLabel.Size = new System.Drawing.Size(47, 13);
            viewIDLabel.TabIndex = 26;
            viewIDLabel.Text = "View ID:";
            // 
            // nameLabel
            // 
            nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(311, 33);
            nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 24;
            nameLabel.Text = "Name:";
            // 
            // viewtypeLabel
            // 
            viewtypeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            viewtypeLabel.AutoSize = true;
            viewtypeLabel.Location = new System.Drawing.Point(534, 58);
            viewtypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            viewtypeLabel.Name = "viewtypeLabel";
            viewtypeLabel.Size = new System.Drawing.Size(53, 13);
            viewtypeLabel.TabIndex = 21;
            viewtypeLabel.Text = "Viewtype:";
            // 
            // dataSourceIDLabel
            // 
            dataSourceIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            dataSourceIDLabel.AutoSize = true;
            dataSourceIDLabel.Location = new System.Drawing.Point(58, 58);
            dataSourceIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataSourceIDLabel.Name = "dataSourceIDLabel";
            dataSourceIDLabel.Size = new System.Drawing.Size(84, 13);
            dataSourceIDLabel.TabIndex = 20;
            dataSourceIDLabel.Text = "Data Source ID:";
            // 
            // showLabel
            // 
            showLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            showLabel.AutoSize = true;
            showLabel.Location = new System.Drawing.Point(770, 57);
            showLabel.Name = "showLabel";
            showLabel.Size = new System.Drawing.Size(37, 13);
            showLabel.TabIndex = 37;
            showLabel.Text = "Show:";
            // 
            // keyTokenLabel
            // 
            keyTokenLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            keyTokenLabel.AutoSize = true;
            keyTokenLabel.Location = new System.Drawing.Point(78, 87);
            keyTokenLabel.Name = "keyTokenLabel";
            keyTokenLabel.Size = new System.Drawing.Size(62, 13);
            keyTokenLabel.TabIndex = 35;
            keyTokenLabel.Text = "Key Token:";
            // 
            // editableLabel
            // 
            editableLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            editableLabel.AutoSize = true;
            editableLabel.Location = new System.Drawing.Point(759, 29);
            editableLabel.Name = "editableLabel";
            editableLabel.Size = new System.Drawing.Size(48, 13);
            editableLabel.TabIndex = 33;
            editableLabel.Text = "Editable:";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(760, 86);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 39;
            label3.Text = "Created:";
            // 
            // captionLabel
            // 
            captionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            captionLabel.AutoSize = true;
            captionLabel.Location = new System.Drawing.Point(96, 33);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new System.Drawing.Size(46, 13);
            captionLabel.TabIndex = 41;
            captionLabel.Text = "Caption:";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(511, 33);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 13);
            label4.TabIndex = 43;
            label4.Text = "Original Name:";
            // 
            // primaryKeysBindingSource
            // 
            this.primaryKeysBindingSource.DataMember = "PrimaryKeys";
            this.primaryKeysBindingSource.DataSource = this.dataHierarchyBindingSource;
            // 
            // relationShipsBindingSource
            // 
            this.relationShipsBindingSource.DataMember = "Relations";
            this.relationShipsBindingSource.DataSource = this.dataHierarchyBindingSource;
            // 
            // fieldsBindingSource
            // 
            this.fieldsBindingSource.DataMember = "Fields";
            this.fieldsBindingSource.DataSource = this.dataHierarchyBindingSource;
            // 
            // ValidateFieldsbutton
            // 
            this.ValidateFieldsbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValidateFieldsbutton.Location = new System.Drawing.Point(886, 10);
            this.ValidateFieldsbutton.Margin = new System.Windows.Forms.Padding(2);
            this.ValidateFieldsbutton.Name = "ValidateFieldsbutton";
            this.ValidateFieldsbutton.Size = new System.Drawing.Size(99, 23);
            this.ValidateFieldsbutton.TabIndex = 29;
            this.ValidateFieldsbutton.Text = "Validate Fields";
            this.ValidateFieldsbutton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.fieldsDataGridView);
            this.panel3.Controls.Add(label2);
            this.panel3.Controls.Add(this.ValidateFieldsbutton);
            this.panel3.Location = new System.Drawing.Point(3, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 260);
            this.panel3.TabIndex = 30;
            // 
            // fieldsDataGridView
            // 
            this.fieldsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsDataGridView.AutoGenerateColumns = false;
            this.fieldsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fieldnameDataGridViewTextBoxColumn,
            this.fieldtypeDataGridViewTextBoxColumn,
            this.size1DataGridViewTextBoxColumn,
            this.size2DataGridViewTextBoxColumn,
            this.fieldCategoryDataGridViewTextBoxColumn,
            this.isAutoIncrementDataGridViewCheckBoxColumn,
            this.allowDBNullDataGridViewCheckBoxColumn,
            this.isCheckDataGridViewCheckBoxColumn,
            this.isUniqueDataGridViewCheckBoxColumn,
            this.isKeyDataGridViewCheckBoxColumn,
            this.fieldIndexDataGridViewTextBoxColumn,
            this.entityNameDataGridViewTextBoxColumn});
            this.fieldsDataGridView.DataSource = this.fieldsBindingSource;
            this.fieldsDataGridView.Location = new System.Drawing.Point(11, 36);
            this.fieldsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.fieldsDataGridView.Name = "fieldsDataGridView";
            this.fieldsDataGridView.RowHeadersWidth = 62;
            this.fieldsDataGridView.RowTemplate.Height = 28;
            this.fieldsDataGridView.Size = new System.Drawing.Size(985, 220);
            this.fieldsDataGridView.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.relationShipsDataGridView);
            this.panel2.Controls.Add(this.ValidateFKbutton);
            this.panel2.Controls.Add(label1);
            this.panel2.Location = new System.Drawing.Point(3, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 251);
            this.panel2.TabIndex = 32;
            // 
            // relationShipsDataGridView
            // 
            this.relationShipsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.relationShipsDataGridView.AutoGenerateColumns = false;
            this.relationShipsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relationShipsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelatedEntityID,
            this.RelatedEntityColumnID,
            this.RelatedColumnSequenceID});
            this.relationShipsDataGridView.DataSource = this.relationShipsBindingSource;
            this.relationShipsDataGridView.Location = new System.Drawing.Point(2, 37);
            this.relationShipsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.relationShipsDataGridView.Name = "relationShipsDataGridView";
            this.relationShipsDataGridView.RowHeadersWidth = 62;
            this.relationShipsDataGridView.RowTemplate.Height = 28;
            this.relationShipsDataGridView.Size = new System.Drawing.Size(512, 210);
            this.relationShipsDataGridView.TabIndex = 10;
            // 
            // ValidateFKbutton
            // 
            this.ValidateFKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValidateFKbutton.Location = new System.Drawing.Point(379, 5);
            this.ValidateFKbutton.Margin = new System.Windows.Forms.Padding(2);
            this.ValidateFKbutton.Name = "ValidateFKbutton";
            this.ValidateFKbutton.Size = new System.Drawing.Size(130, 23);
            this.ValidateFKbutton.TabIndex = 11;
            this.ValidateFKbutton.Text = "Validate FK Relations";
            this.ValidateFKbutton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.customBuildQueryTextBox);
            this.panel1.Controls.Add(this.ValidateQuerybutton);
            this.panel1.Controls.Add(customBuildQueryLabel);
            this.panel1.Location = new System.Drawing.Point(523, 378);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 251);
            this.panel1.TabIndex = 31;
            // 
            // customBuildQueryTextBox
            // 
            this.customBuildQueryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customBuildQueryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customBuildQueryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "CustomBuildQuery", true));
            this.customBuildQueryTextBox.Location = new System.Drawing.Point(3, 29);
            this.customBuildQueryTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.customBuildQueryTextBox.Multiline = true;
            this.customBuildQueryTextBox.Name = "customBuildQueryTextBox";
            this.customBuildQueryTextBox.Size = new System.Drawing.Size(473, 218);
            this.customBuildQueryTextBox.TabIndex = 7;
            // 
            // ValidateQuerybutton
            // 
            this.ValidateQuerybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValidateQuerybutton.Location = new System.Drawing.Point(376, 2);
            this.ValidateQuerybutton.Margin = new System.Windows.Forms.Padding(2);
            this.ValidateQuerybutton.Name = "ValidateQuerybutton";
            this.ValidateQuerybutton.Size = new System.Drawing.Size(99, 23);
            this.ValidateQuerybutton.TabIndex = 8;
            this.ValidateQuerybutton.Text = "Validate Query";
            this.ValidateQuerybutton.UseVisualStyleBackColor = true;
            // 
            // SaveEntitybutton
            // 
            this.SaveEntitybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveEntitybutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.SaveEntitybutton.Location = new System.Drawing.Point(915, 34);
            this.SaveEntitybutton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveEntitybutton.Name = "SaveEntitybutton";
            this.SaveEntitybutton.Size = new System.Drawing.Size(99, 23);
            this.SaveEntitybutton.TabIndex = 28;
            this.SaveEntitybutton.Text = "Save";
            this.SaveEntitybutton.UseVisualStyleBackColor = true;
            // 
            // viewIDTextBox
            // 
            this.viewIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.viewIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "ViewID", true));
            this.viewIDTextBox.Location = new System.Drawing.Point(353, 54);
            this.viewIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.viewIDTextBox.Name = "viewIDTextBox";
            this.viewIDTextBox.ReadOnly = true;
            this.viewIDTextBox.Size = new System.Drawing.Size(142, 20);
            this.viewIDTextBox.TabIndex = 27;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "EntityName", true));
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(353, 29);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(142, 20);
            this.nameTextBox.TabIndex = 25;
            // 
            // viewtypeComboBox
            // 
            this.viewtypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.viewtypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "Viewtype", true));
            this.viewtypeComboBox.Enabled = false;
            this.viewtypeComboBox.FormattingEnabled = true;
            this.viewtypeComboBox.Location = new System.Drawing.Point(591, 54);
            this.viewtypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.viewtypeComboBox.Name = "viewtypeComboBox";
            this.viewtypeComboBox.Size = new System.Drawing.Size(151, 21);
            this.viewtypeComboBox.TabIndex = 23;
            // 
            // dataSourceIDComboBox
            // 
            this.dataSourceIDComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataSourceIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "DataSourceID", true));
            this.dataSourceIDComboBox.Enabled = false;
            this.dataSourceIDComboBox.FormattingEnabled = true;
            this.dataSourceIDComboBox.Location = new System.Drawing.Point(146, 54);
            this.dataSourceIDComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.dataSourceIDComboBox.Name = "dataSourceIDComboBox";
            this.dataSourceIDComboBox.Size = new System.Drawing.Size(143, 21);
            this.dataSourceIDComboBox.TabIndex = 22;
            // 
            // showCheckBox
            // 
            this.showCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showCheckBox.Checked = true;
            this.showCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dataHierarchyBindingSource, "Show", true));
            this.showCheckBox.Location = new System.Drawing.Point(818, 52);
            this.showCheckBox.Name = "showCheckBox";
            this.showCheckBox.Size = new System.Drawing.Size(47, 24);
            this.showCheckBox.TabIndex = 38;
            this.showCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyTokenTextBox
            // 
            this.keyTokenTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.keyTokenTextBox.Location = new System.Drawing.Point(146, 83);
            this.keyTokenTextBox.Name = "keyTokenTextBox";
            this.keyTokenTextBox.Size = new System.Drawing.Size(100, 20);
            this.keyTokenTextBox.TabIndex = 36;
            // 
            // editableCheckBox
            // 
            this.editableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editableCheckBox.Checked = true;
            this.editableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dataHierarchyBindingSource, "Editable", true));
            this.editableCheckBox.Enabled = false;
            this.editableCheckBox.Location = new System.Drawing.Point(818, 27);
            this.editableCheckBox.Name = "editableCheckBox";
            this.editableCheckBox.Size = new System.Drawing.Size(47, 24);
            this.editableCheckBox.TabIndex = 34;
            this.editableCheckBox.ThreeState = true;
            this.editableCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dataHierarchyBindingSource, "Created", true));
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(818, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(47, 24);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // captionTextBox1
            // 
            this.captionTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.captionTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "Caption", true));
            this.captionTextBox1.Location = new System.Drawing.Point(146, 29);
            this.captionTextBox1.Name = "captionTextBox1";
            this.captionTextBox1.Size = new System.Drawing.Size(143, 20);
            this.captionTextBox1.TabIndex = 42;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataHierarchyBindingSource, "OriginalEntityName", true));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(591, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 44;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.EntityNameLabel);
            this.panel4.Controls.Add(this.TitleLabel);
            this.panel4.Controls.Add(this.SaveEntitybutton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1017, 61);
            this.panel4.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gold;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(14, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Entity";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EntityNameLabel
            // 
            this.EntityNameLabel.BackColor = System.Drawing.Color.Orange;
            this.EntityNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntityNameLabel.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold);
            this.EntityNameLabel.ForeColor = System.Drawing.Color.Black;
            this.EntityNameLabel.Location = new System.Drawing.Point(120, 36);
            this.EntityNameLabel.Name = "EntityNameLabel";
            this.EntityNameLabel.Size = new System.Drawing.Size(191, 23);
            this.EntityNameLabel.TabIndex = 29;
            this.EntityNameLabel.Text = "Entity Name";
            this.EntityNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gold;
            this.TitleLabel.Location = new System.Drawing.Point(12, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(271, 32);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "DataView Entity Editor";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.captionTextBox1);
            this.panel5.Controls.Add(this.dataSourceIDComboBox);
            this.panel5.Controls.Add(label4);
            this.panel5.Controls.Add(dataSourceIDLabel);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.viewtypeComboBox);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(viewtypeLabel);
            this.panel5.Controls.Add(captionLabel);
            this.panel5.Controls.Add(this.nameTextBox);
            this.panel5.Controls.Add(nameLabel);
            this.panel5.Controls.Add(label3);
            this.panel5.Controls.Add(this.viewIDTextBox);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(viewIDLabel);
            this.panel5.Controls.Add(showLabel);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.showCheckBox);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(keyTokenLabel);
            this.panel5.Controls.Add(this.editableCheckBox);
            this.panel5.Controls.Add(this.keyTokenTextBox);
            this.panel5.Controls.Add(editableLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 61);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1017, 674);
            this.panel5.TabIndex = 46;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // dataHierarchyBindingSource
            // 
            this.dataHierarchyBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityStructure);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // fieldnameDataGridViewTextBoxColumn
            // 
            this.fieldnameDataGridViewTextBoxColumn.DataPropertyName = "fieldname";
            this.fieldnameDataGridViewTextBoxColumn.HeaderText = "fieldname";
            this.fieldnameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fieldnameDataGridViewTextBoxColumn.Name = "fieldnameDataGridViewTextBoxColumn";
            this.fieldnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // fieldtypeDataGridViewTextBoxColumn
            // 
            this.fieldtypeDataGridViewTextBoxColumn.DataPropertyName = "fieldtype";
            this.fieldtypeDataGridViewTextBoxColumn.HeaderText = "fieldtype";
            this.fieldtypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fieldtypeDataGridViewTextBoxColumn.Name = "fieldtypeDataGridViewTextBoxColumn";
            this.fieldtypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldtypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fieldtypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // size1DataGridViewTextBoxColumn
            // 
            this.size1DataGridViewTextBoxColumn.DataPropertyName = "Size1";
            this.size1DataGridViewTextBoxColumn.HeaderText = "Size1";
            this.size1DataGridViewTextBoxColumn.MinimumWidth = 8;
            this.size1DataGridViewTextBoxColumn.Name = "size1DataGridViewTextBoxColumn";
            this.size1DataGridViewTextBoxColumn.Width = 150;
            // 
            // size2DataGridViewTextBoxColumn
            // 
            this.size2DataGridViewTextBoxColumn.DataPropertyName = "Size2";
            this.size2DataGridViewTextBoxColumn.HeaderText = "Size2";
            this.size2DataGridViewTextBoxColumn.MinimumWidth = 8;
            this.size2DataGridViewTextBoxColumn.Name = "size2DataGridViewTextBoxColumn";
            this.size2DataGridViewTextBoxColumn.Width = 150;
            // 
            // fieldCategoryDataGridViewTextBoxColumn
            // 
            this.fieldCategoryDataGridViewTextBoxColumn.DataPropertyName = "fieldCategory";
            this.fieldCategoryDataGridViewTextBoxColumn.HeaderText = "fieldCategory";
            this.fieldCategoryDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fieldCategoryDataGridViewTextBoxColumn.Name = "fieldCategoryDataGridViewTextBoxColumn";
            this.fieldCategoryDataGridViewTextBoxColumn.Visible = false;
            this.fieldCategoryDataGridViewTextBoxColumn.Width = 150;
            // 
            // isAutoIncrementDataGridViewCheckBoxColumn
            // 
            this.isAutoIncrementDataGridViewCheckBoxColumn.DataPropertyName = "IsAutoIncrement";
            this.isAutoIncrementDataGridViewCheckBoxColumn.HeaderText = "IsAutoIncrement";
            this.isAutoIncrementDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.isAutoIncrementDataGridViewCheckBoxColumn.Name = "isAutoIncrementDataGridViewCheckBoxColumn";
            this.isAutoIncrementDataGridViewCheckBoxColumn.Width = 150;
            // 
            // allowDBNullDataGridViewCheckBoxColumn
            // 
            this.allowDBNullDataGridViewCheckBoxColumn.DataPropertyName = "AllowDBNull";
            this.allowDBNullDataGridViewCheckBoxColumn.HeaderText = "AllowDBNull";
            this.allowDBNullDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.allowDBNullDataGridViewCheckBoxColumn.Name = "allowDBNullDataGridViewCheckBoxColumn";
            this.allowDBNullDataGridViewCheckBoxColumn.Width = 150;
            // 
            // isCheckDataGridViewCheckBoxColumn
            // 
            this.isCheckDataGridViewCheckBoxColumn.DataPropertyName = "IsCheck";
            this.isCheckDataGridViewCheckBoxColumn.HeaderText = "IsCheck";
            this.isCheckDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.isCheckDataGridViewCheckBoxColumn.Name = "isCheckDataGridViewCheckBoxColumn";
            this.isCheckDataGridViewCheckBoxColumn.Visible = false;
            this.isCheckDataGridViewCheckBoxColumn.Width = 150;
            // 
            // isUniqueDataGridViewCheckBoxColumn
            // 
            this.isUniqueDataGridViewCheckBoxColumn.DataPropertyName = "IsUnique";
            this.isUniqueDataGridViewCheckBoxColumn.HeaderText = "IsUnique";
            this.isUniqueDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.isUniqueDataGridViewCheckBoxColumn.Name = "isUniqueDataGridViewCheckBoxColumn";
            this.isUniqueDataGridViewCheckBoxColumn.Width = 150;
            // 
            // isKeyDataGridViewCheckBoxColumn
            // 
            this.isKeyDataGridViewCheckBoxColumn.DataPropertyName = "IsKey";
            this.isKeyDataGridViewCheckBoxColumn.HeaderText = "IsKey";
            this.isKeyDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.isKeyDataGridViewCheckBoxColumn.Name = "isKeyDataGridViewCheckBoxColumn";
            this.isKeyDataGridViewCheckBoxColumn.Width = 150;
            // 
            // fieldIndexDataGridViewTextBoxColumn
            // 
            this.fieldIndexDataGridViewTextBoxColumn.DataPropertyName = "FieldIndex";
            this.fieldIndexDataGridViewTextBoxColumn.HeaderText = "FieldIndex";
            this.fieldIndexDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fieldIndexDataGridViewTextBoxColumn.Name = "fieldIndexDataGridViewTextBoxColumn";
            this.fieldIndexDataGridViewTextBoxColumn.Visible = false;
            this.fieldIndexDataGridViewTextBoxColumn.Width = 150;
            // 
            // entityNameDataGridViewTextBoxColumn
            // 
            this.entityNameDataGridViewTextBoxColumn.DataPropertyName = "EntityName";
            this.entityNameDataGridViewTextBoxColumn.HeaderText = "EntityName";
            this.entityNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.entityNameDataGridViewTextBoxColumn.Name = "entityNameDataGridViewTextBoxColumn";
            this.entityNameDataGridViewTextBoxColumn.Visible = false;
            this.entityNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // RelatedEntityID
            // 
            this.RelatedEntityID.DataPropertyName = "RelatedEntityID";
            this.RelatedEntityID.HeaderText = "Entity";
            this.RelatedEntityID.Name = "RelatedEntityID";
            // 
            // RelatedEntityColumnID
            // 
            this.RelatedEntityColumnID.DataPropertyName = "RelatedEntityColumnID";
            this.RelatedEntityColumnID.HeaderText = "Column";
            this.RelatedEntityColumnID.Name = "RelatedEntityColumnID";
            // 
            // RelatedColumnSequenceID
            // 
            this.RelatedColumnSequenceID.DataPropertyName = "RelatedColumnSequenceID";
            this.RelatedColumnSequenceID.HeaderText = "Sequence";
            this.RelatedColumnSequenceID.Name = "RelatedColumnSequenceID";
            // 
            // uc_DataEntityStructureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Name = "uc_DataEntityStructureViewer";
            this.Size = new System.Drawing.Size(1017, 735);
            ((System.ComponentModel.ISupportInitialize)(this.primaryKeysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relationShipsDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHierarchyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource primaryKeysBindingSource;
        private System.Windows.Forms.BindingSource dataHierarchyBindingSource;
        private System.Windows.Forms.BindingSource relationShipsBindingSource;
        private System.Windows.Forms.BindingSource fieldsBindingSource;
        private System.Windows.Forms.Button ValidateFieldsbutton;
        private System.Windows.Forms.Panel panel3;
        private DataGridView fieldsDataGridView;
        private System.Windows.Forms.Panel panel2;
        private DataGridView relationShipsDataGridView;
        private System.Windows.Forms.Button ValidateFKbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox customBuildQueryTextBox;
        private System.Windows.Forms.Button ValidateQuerybutton;
        private System.Windows.Forms.Button SaveEntitybutton;
        private System.Windows.Forms.TextBox viewIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox viewtypeComboBox;
        private System.Windows.Forms.ComboBox dataSourceIDComboBox;
        private System.Windows.Forms.CheckBox showCheckBox;
        private System.Windows.Forms.TextBox keyTokenTextBox;
        private System.Windows.Forms.CheckBox editableCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox captionTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn size1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn size2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAutoIncrementDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowDBNullDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUniqueDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isKeyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityNameDataGridViewTextBoxColumn;
        private Panel panel4;
        private Label TitleLabel;
        private Label label5;
        private Label EntityNameLabel;
        private Panel panel5;
        private DataGridViewTextBoxColumn RelatedEntityID;
        private DataGridViewTextBoxColumn RelatedEntityColumnID;
        private DataGridViewTextBoxColumn RelatedColumnSequenceID;
    }
}
