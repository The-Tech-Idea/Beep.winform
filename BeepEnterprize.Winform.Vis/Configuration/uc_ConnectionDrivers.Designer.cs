using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis
{
    partial class uc_ConnectionDrivers
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
            this.connectiondriversConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.connectiondriversConfigDataGridView = new System.Windows.Forms.DataGridView();
            this.iconname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DatasourceCategoryComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DatasourceTypeComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.classHandlerComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CreateLocal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ADOType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectionString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.connectiondriversConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectiondriversConfigDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // connectiondriversConfigBindingSource
            // 
            this.connectiondriversConfigBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionDriversConfig);
            // 
            // connectiondriversConfigDataGridView
            // 
            this.connectiondriversConfigDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectiondriversConfigDataGridView.AutoGenerateColumns = false;
            this.connectiondriversConfigDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.connectiondriversConfigDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.connectiondriversConfigDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectiondriversConfigDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconname,
            this.DatasourceCategoryComboBox,
            this.DatasourceTypeComboBox,
            this.classHandlerComboBox,
            this.CreateLocal,
            this.ADOType,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ConnectionString});
            this.connectiondriversConfigDataGridView.DataSource = this.connectiondriversConfigBindingSource;
            this.connectiondriversConfigDataGridView.Location = new System.Drawing.Point(2, 2);
            this.connectiondriversConfigDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.connectiondriversConfigDataGridView.Name = "connectiondriversConfigDataGridView";
            this.connectiondriversConfigDataGridView.RowHeadersWidth = 62;
            this.connectiondriversConfigDataGridView.RowTemplate.Height = 28;
            this.connectiondriversConfigDataGridView.Size = new System.Drawing.Size(1331, 623);
            this.connectiondriversConfigDataGridView.TabIndex = 1;
            // 
            // iconname
            // 
            this.iconname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iconname.DataPropertyName = "iconname";
            this.iconname.HeaderText = "Icon";
            this.iconname.MinimumWidth = 8;
            this.iconname.Name = "iconname";
            this.iconname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iconname.Width = 44;
            // 
            // DatasourceCategoryComboBox
            // 
            this.DatasourceCategoryComboBox.DataPropertyName = "DatasourceCategory";
            this.DatasourceCategoryComboBox.HeaderText = "Category";
            this.DatasourceCategoryComboBox.Name = "DatasourceCategoryComboBox";
            // 
            // DatasourceTypeComboBox
            // 
            this.DatasourceTypeComboBox.DataPropertyName = "DatasourceType";
            this.DatasourceTypeComboBox.HeaderText = "Type";
            this.DatasourceTypeComboBox.Name = "DatasourceTypeComboBox";
            // 
            // classHandlerComboBox
            // 
            this.classHandlerComboBox.DataPropertyName = "classHandler";
            this.classHandlerComboBox.HeaderText = "Class Handler";
            this.classHandlerComboBox.MinimumWidth = 8;
            this.classHandlerComboBox.Name = "classHandlerComboBox";
            // 
            // CreateLocal
            // 
            this.CreateLocal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CreateLocal.DataPropertyName = "CreateLocal";
            this.CreateLocal.HeaderText = "Create Local";
            this.CreateLocal.MinimumWidth = 8;
            this.CreateLocal.Name = "CreateLocal";
            this.CreateLocal.Width = 96;
            // 
            // ADOType
            // 
            this.ADOType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ADOType.DataPropertyName = "ADOType";
            this.ADOType.HeaderText = "ADO Type";
            this.ADOType.MinimumWidth = 8;
            this.ADOType.Name = "ADOType";
            this.ADOType.Width = 79;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PackageName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Package Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 129;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DriverClass";
            this.dataGridViewTextBoxColumn2.HeaderText = "Driver Class";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 111;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "version";
            this.dataGridViewTextBoxColumn3.HeaderText = "Version";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 88;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "dllname";
            this.dataGridViewTextBoxColumn4.HeaderText = "DLL";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 62;
            // 
            // ConnectionString
            // 
            this.ConnectionString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConnectionString.DataPropertyName = "ConnectionString";
            this.ConnectionString.HeaderText = "Connection String";
            this.ConnectionString.MinimumWidth = 8;
            this.ConnectionString.Name = "ConnectionString";
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
            this.uc_bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_bindingNavigator1.BackColor = System.Drawing.Color.White;
            this.uc_bindingNavigator1.bindingSource = null;
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(2, 625);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(1331, 31);
            this.uc_bindingNavigator1.TabIndex = 2;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // uc_ConnectionDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectiondriversConfigDataGridView);
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_ConnectionDrivers";
            this.Size = new System.Drawing.Size(1335, 655);
            ((System.ComponentModel.ISupportInitialize)(this.connectiondriversConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectiondriversConfigDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource connectiondriversConfigBindingSource;
        private System.Windows.Forms.DataGridView connectiondriversConfigDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn iconname;
        private System.Windows.Forms.DataGridViewComboBoxColumn DatasourceCategoryComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn DatasourceTypeComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn classHandlerComboBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CreateLocal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ADOType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectionString;
        private uc_bindingNavigator uc_bindingNavigator1;
    }
}
