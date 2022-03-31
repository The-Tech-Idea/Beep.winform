
using Beep.Winform.Controls;
using TheTechIdea.Beep.DataBase;

namespace TheTechIdea.ETL
{
    partial class uc_ViewEditor
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
            System.Windows.Forms.Label viewIDLabel;
            System.Windows.Forms.Label viewNameLabel;
            System.Windows.Forms.Label label1;
            this.dataViewDataSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewIDTextBox = new System.Windows.Forms.TextBox();
            this.viewNameTextBox = new System.Windows.Forms.TextBox();
            this.entitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entitiesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridEntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntityDataSourceID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ViewtypeComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewDatasourcecomboBox1 = new System.Windows.Forms.ComboBox();
            this.ChangeDatasourceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.EntityNameLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EntitiesbindingNavigator = new uc_bindingNavigator();
            this.DataViewbindingNavigator = new uc_bindingNavigator();
            viewIDLabel = new System.Windows.Forms.Label();
            viewNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewDataSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourcesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewIDLabel
            // 
            viewIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            viewIDLabel.AutoSize = true;
            viewIDLabel.Location = new System.Drawing.Point(29, 45);
            viewIDLabel.Name = "viewIDLabel";
            viewIDLabel.Size = new System.Drawing.Size(47, 13);
            viewIDLabel.TabIndex = 1;
            viewIDLabel.Text = "View ID:";
            viewIDLabel.Click += new System.EventHandler(this.viewIDLabel_Click);
            // 
            // viewNameLabel
            // 
            viewNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            viewNameLabel.AutoSize = true;
            viewNameLabel.Location = new System.Drawing.Point(12, 71);
            viewNameLabel.Name = "viewNameLabel";
            viewNameLabel.Size = new System.Drawing.Size(64, 13);
            viewNameLabel.TabIndex = 3;
            viewNameLabel.Text = "View Name:";
            viewNameLabel.Click += new System.EventHandler(this.viewNameLabel_Click);
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(550, 38);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 13);
            label1.TabIndex = 13;
            label1.Text = "DataSource";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataViewDataSourceBindingSource
            // 
            this.dataViewDataSourceBindingSource.AllowNew = true;
            this.dataViewDataSourceBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.DMDataView);
            // 
            // viewIDTextBox
            // 
            this.viewIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataViewDataSourceBindingSource, "ViewID", true));
            this.viewIDTextBox.Location = new System.Drawing.Point(82, 42);
            this.viewIDTextBox.Name = "viewIDTextBox";
            this.viewIDTextBox.Size = new System.Drawing.Size(121, 20);
            this.viewIDTextBox.TabIndex = 2;
            this.viewIDTextBox.TextChanged += new System.EventHandler(this.viewIDTextBox_TextChanged);
            // 
            // viewNameTextBox
            // 
            this.viewNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataViewDataSourceBindingSource, "ViewName", true));
            this.viewNameTextBox.Location = new System.Drawing.Point(82, 68);
            this.viewNameTextBox.Name = "viewNameTextBox";
            this.viewNameTextBox.Size = new System.Drawing.Size(320, 20);
            this.viewNameTextBox.TabIndex = 4;
            this.viewNameTextBox.TextChanged += new System.EventHandler(this.viewNameTextBox_TextChanged);
            // 
            // entitiesBindingSource
            // 
            this.entitiesBindingSource.DataMember = "Entities";
            this.entitiesBindingSource.DataSource = this.dataViewDataSourceBindingSource;
            // 
            // entitiesDataGridView
            // 
            this.entitiesDataGridView.AllowUserToOrderColumns = true;
            this.entitiesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.entitiesDataGridView.AutoGenerateColumns = false;
            this.entitiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entitiesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.GridEntityName,
            this.EntityDataSourceID,
            this.ViewtypeComboBox,
            this.dataGridViewTextBoxColumn2});
            this.entitiesDataGridView.DataSource = this.entitiesBindingSource;
            this.entitiesDataGridView.Location = new System.Drawing.Point(23, 109);
            this.entitiesDataGridView.Name = "entitiesDataGridView";
            this.entitiesDataGridView.Size = new System.Drawing.Size(620, 370);
            this.entitiesDataGridView.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 41;
            // 
            // GridEntityName
            // 
            this.GridEntityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GridEntityName.DataPropertyName = "EntityName";
            this.GridEntityName.HeaderText = "EntityName";
            this.GridEntityName.Name = "GridEntityName";
            // 
            // EntityDataSourceID
            // 
            this.EntityDataSourceID.DataPropertyName = "DataSourceID";
            this.EntityDataSourceID.DataSource = this.dataConnectionsBindingSource;
            this.EntityDataSourceID.DisplayMember = "ConnectionName";
            this.EntityDataSourceID.HeaderText = "DataSourceID";
            this.EntityDataSourceID.Name = "EntityDataSourceID";
            this.EntityDataSourceID.ValueMember = "ConnectionName";
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // ViewtypeComboBox
            // 
            this.ViewtypeComboBox.DataPropertyName = "Viewtype";
            this.ViewtypeComboBox.HeaderText = "Viewtype";
            this.ViewtypeComboBox.Name = "ViewtypeComboBox";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CustomBuildQuery";
            this.dataGridViewTextBoxColumn2.HeaderText = "CustomBuildQuery";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataSourcesBindingSource
            // 
            this.dataSourcesBindingSource.DataSource = typeof(TheTechIdea.IDataSource);
            // 
            // NewDatasourcecomboBox1
            // 
            this.NewDatasourcecomboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NewDatasourcecomboBox1.DataSource = this.dataConnectionsBindingSource;
            this.NewDatasourcecomboBox1.DisplayMember = "ConnectionName";
            this.NewDatasourcecomboBox1.FormattingEnabled = true;
            this.NewDatasourcecomboBox1.Location = new System.Drawing.Point(522, 54);
            this.NewDatasourcecomboBox1.Name = "NewDatasourcecomboBox1";
            this.NewDatasourcecomboBox1.Size = new System.Drawing.Size(121, 21);
            this.NewDatasourcecomboBox1.TabIndex = 12;
            this.NewDatasourcecomboBox1.ValueMember = "ConnectionName";
            this.NewDatasourcecomboBox1.SelectedIndexChanged += new System.EventHandler(this.NewDatasourcecomboBox1_SelectedIndexChanged);
            // 
            // ChangeDatasourceButton
            // 
            this.ChangeDatasourceButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChangeDatasourceButton.Location = new System.Drawing.Point(545, 81);
            this.ChangeDatasourceButton.Name = "ChangeDatasourceButton";
            this.ChangeDatasourceButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeDatasourceButton.TabIndex = 14;
            this.ChangeDatasourceButton.Text = "Change";
            this.ChangeDatasourceButton.UseVisualStyleBackColor = true;
            this.ChangeDatasourceButton.Click += new System.EventHandler(this.ChangeDatasourceButton_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "DataView Editor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EntityNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 72);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(10, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Entity";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EntityNameLabel
            // 
            this.EntityNameLabel.BackColor = System.Drawing.Color.Orange;
            this.EntityNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntityNameLabel.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold);
            this.EntityNameLabel.ForeColor = System.Drawing.Color.Black;
            this.EntityNameLabel.Location = new System.Drawing.Point(116, 32);
            this.EntityNameLabel.Name = "EntityNameLabel";
            this.EntityNameLabel.Size = new System.Drawing.Size(191, 23);
            this.EntityNameLabel.TabIndex = 16;
            this.EntityNameLabel.Text = "Entity Name";
            this.EntityNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EntitiesbindingNavigator);
            this.panel2.Controls.Add(this.DataViewbindingNavigator);
            this.panel2.Controls.Add(this.entitiesDataGridView);
            this.panel2.Controls.Add(this.ChangeDatasourceButton);
            this.panel2.Controls.Add(this.viewIDTextBox);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(viewIDLabel);
            this.panel2.Controls.Add(this.NewDatasourcecomboBox1);
            this.panel2.Controls.Add(this.viewNameTextBox);
            this.panel2.Controls.Add(viewNameLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 511);
            this.panel2.TabIndex = 16;
            // 
            // EntitiesbindingNavigator
            // 
            this.EntitiesbindingNavigator.AddinName = null;
            this.EntitiesbindingNavigator.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EntitiesbindingNavigator.BackColor = System.Drawing.Color.White;
            this.EntitiesbindingNavigator.bindingSource = null;
            this.EntitiesbindingNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntitiesbindingNavigator.ButtonBorderSize = 0;
            this.EntitiesbindingNavigator.CausesValidation = false;
            this.EntitiesbindingNavigator.ControlHeight = 30;
            this.EntitiesbindingNavigator.DefaultCreate = false;
            this.EntitiesbindingNavigator.Description = null;
            this.EntitiesbindingNavigator.DllName = null;
            this.EntitiesbindingNavigator.DllPath = null;
            this.EntitiesbindingNavigator.DMEEditor = null;
            this.EntitiesbindingNavigator.EntityName = null;
            this.EntitiesbindingNavigator.EntityStructure = null;
            this.EntitiesbindingNavigator.ErrorObject = null;
            this.EntitiesbindingNavigator.HightlightColor = System.Drawing.Color.Empty;
            this.EntitiesbindingNavigator.Location = new System.Drawing.Point(23, 480);
            this.EntitiesbindingNavigator.Logger = null;
            this.EntitiesbindingNavigator.Name = "EntitiesbindingNavigator";
            this.EntitiesbindingNavigator.NameSpace = null;
            this.EntitiesbindingNavigator.ObjectName = null;
            this.EntitiesbindingNavigator.ObjectType = null;
            this.EntitiesbindingNavigator.ParentName = null;
            this.EntitiesbindingNavigator.Passedarg = null;
            this.EntitiesbindingNavigator.SelectedColor = System.Drawing.Color.Empty;
            this.EntitiesbindingNavigator.Size = new System.Drawing.Size(620, 31);
            this.EntitiesbindingNavigator.TabIndex = 16;
            this.EntitiesbindingNavigator.VerifyDelete = true;
            // 
            // DataViewbindingNavigator
            // 
            this.DataViewbindingNavigator.AddinName = null;
            this.DataViewbindingNavigator.BackColor = System.Drawing.Color.White;
            this.DataViewbindingNavigator.bindingSource = this.dataViewDataSourceBindingSource;
            this.DataViewbindingNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataViewbindingNavigator.ButtonBorderSize = 0;
            this.DataViewbindingNavigator.CausesValidation = false;
            this.DataViewbindingNavigator.ControlHeight = 30;
            this.DataViewbindingNavigator.DefaultCreate = false;
            this.DataViewbindingNavigator.Description = null;
            this.DataViewbindingNavigator.DllName = null;
            this.DataViewbindingNavigator.DllPath = null;
            this.DataViewbindingNavigator.DMEEditor = null;
            this.DataViewbindingNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataViewbindingNavigator.EntityName = null;
            this.DataViewbindingNavigator.EntityStructure = null;
            this.DataViewbindingNavigator.ErrorObject = null;
            this.DataViewbindingNavigator.HightlightColor = System.Drawing.Color.Empty;
            this.DataViewbindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.DataViewbindingNavigator.Logger = null;
            this.DataViewbindingNavigator.Name = "DataViewbindingNavigator";
            this.DataViewbindingNavigator.NameSpace = null;
            this.DataViewbindingNavigator.ObjectName = null;
            this.DataViewbindingNavigator.ObjectType = null;
            this.DataViewbindingNavigator.ParentName = null;
            this.DataViewbindingNavigator.Passedarg = null;
            this.DataViewbindingNavigator.SelectedColor = System.Drawing.Color.Empty;
            this.DataViewbindingNavigator.Size = new System.Drawing.Size(657, 31);
            this.DataViewbindingNavigator.TabIndex = 15;
            this.DataViewbindingNavigator.VerifyDelete = true;
            // 
            // uc_ViewEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "uc_ViewEditor";
            this.Size = new System.Drawing.Size(657, 583);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewDataSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourcesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox viewIDTextBox;
        private System.Windows.Forms.TextBox viewNameTextBox;
        private System.Windows.Forms.DataGridView entitiesDataGridView;
        private System.Windows.Forms.BindingSource dataSourcesBindingSource;
        public System.Windows.Forms.BindingSource dataViewDataSourceBindingSource;
        public System.Windows.Forms.BindingSource entitiesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridEntityName;
        private System.Windows.Forms.DataGridViewComboBoxColumn EntityDataSourceID;
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn ViewtypeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox NewDatasourcecomboBox1;
        private System.Windows.Forms.Button ChangeDatasourceButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label EntityNameLabel;
        private System.Windows.Forms.Panel panel2;
        private uc_bindingNavigator DataViewbindingNavigator;
        private uc_bindingNavigator EntitiesbindingNavigator;
    }
}
