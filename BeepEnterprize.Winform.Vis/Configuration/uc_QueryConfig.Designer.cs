
using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis
{
    partial class uc_QueryConfig
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
            this.queryListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DatabaseTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.queryListDataGridView = new System.Windows.Forms.DataGridView();
            this.DatabasetypeComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SQLTypeComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.queryListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseTypebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // queryListBindingSource
            // 
            this.queryListBindingSource.DataSource = typeof(TheTechIdea.Util.QuerySqlRepo);
            // 
            // DatabaseTypebindingSource
            // 
            this.DatabaseTypebindingSource.DataSource = typeof(TheTechIdea.Util.QuerySqlRepo);
            // 
            // queryListDataGridView
            // 
            this.queryListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryListDataGridView.AutoGenerateColumns = false;
            this.queryListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queryListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabasetypeComboBox,
            this.SQLTypeComboBox,
            this.dataGridViewTextBoxColumn3});
            this.queryListDataGridView.DataSource = this.queryListBindingSource;
            this.queryListDataGridView.Location = new System.Drawing.Point(3, 3);
            this.queryListDataGridView.Name = "queryListDataGridView";
            this.queryListDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.queryListDataGridView.RowHeadersWidth = 62;
            this.queryListDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.queryListDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.queryListDataGridView.Size = new System.Drawing.Size(1019, 599);
            this.queryListDataGridView.TabIndex = 2;
            // 
            // DatabasetypeComboBox
            // 
            this.DatabasetypeComboBox.DataPropertyName = "DatabaseType";
            this.DatabasetypeComboBox.HeaderText = "DatabaseType";
            this.DatabasetypeComboBox.MinimumWidth = 8;
            this.DatabasetypeComboBox.Name = "DatabasetypeComboBox";
            this.DatabasetypeComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DatabasetypeComboBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DatabasetypeComboBox.Width = 150;
            // 
            // SQLTypeComboBox
            // 
            this.SQLTypeComboBox.DataPropertyName = "Sqltype";
            this.SQLTypeComboBox.HeaderText = "Sqltype";
            this.SQLTypeComboBox.MinimumWidth = 8;
            this.SQLTypeComboBox.Name = "SQLTypeComboBox";
            this.SQLTypeComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SQLTypeComboBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SQLTypeComboBox.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Sql";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Sql";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
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
            this.uc_bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uc_bindingNavigator1.EntityName = null;
            this.uc_bindingNavigator1.EntityStructure = null;
            this.uc_bindingNavigator1.ErrorObject = null;
            this.uc_bindingNavigator1.HightlightColor = System.Drawing.Color.Red;
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(0, 603);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(1025, 31);
            this.uc_bindingNavigator1.TabIndex = 3;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // uc_QueryConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.queryListDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_QueryConfig";
            this.Size = new System.Drawing.Size(1025, 634);
            ((System.ComponentModel.ISupportInitialize)(this.queryListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseTypebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource queryListBindingSource;
        private System.Windows.Forms.BindingSource DatabaseTypebindingSource;
        private System.Windows.Forms.DataGridView queryListDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn DatabasetypeComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn SQLTypeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private uc_bindingNavigator uc_bindingNavigator1;
    }
}
