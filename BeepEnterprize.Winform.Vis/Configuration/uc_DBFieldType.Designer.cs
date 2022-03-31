using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis.Configuration
{
    partial class uc_DBFieldType
    {  /// <summary> 
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
            this.mappingDataGridView = new System.Windows.Forms.DataGridView();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.mappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSourcedataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NetDataTypedataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DataSourceDataTypedataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fav = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mappingDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mappingDataGridView
            // 
            this.mappingDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mappingDataGridView.AutoGenerateColumns = false;
            this.mappingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mappingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataSourcedataGridViewTextBoxColumn3,
            this.NetDataTypedataGridViewTextBoxColumn4,
            this.DataSourceDataTypedataGridViewTextBoxColumn5,
            this.Fav});
            this.mappingDataGridView.DataSource = this.mappingBindingSource;
            this.mappingDataGridView.Location = new System.Drawing.Point(2, 2);
            this.mappingDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.mappingDataGridView.Name = "mappingDataGridView";
            this.mappingDataGridView.RowHeadersWidth = 62;
            this.mappingDataGridView.RowTemplate.Height = 28;
            this.mappingDataGridView.Size = new System.Drawing.Size(774, 635);
            this.mappingDataGridView.TabIndex = 2;
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(2, 637);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(772, 31);
            this.uc_bindingNavigator1.TabIndex = 3;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // mappingBindingSource
            // 
            this.mappingBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.DatatypeMapping);
            // 
            // DataSourcedataGridViewTextBoxColumn3
            // 
            this.DataSourcedataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataSourcedataGridViewTextBoxColumn3.DataPropertyName = "DataSourceName";
            this.DataSourcedataGridViewTextBoxColumn3.HeaderText = "Data Source";
            this.DataSourcedataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.DataSourcedataGridViewTextBoxColumn3.Name = "DataSourcedataGridViewTextBoxColumn3";
            this.DataSourcedataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataSourcedataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NetDataTypedataGridViewTextBoxColumn4
            // 
            this.NetDataTypedataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NetDataTypedataGridViewTextBoxColumn4.DataPropertyName = "NetDataType";
            this.NetDataTypedataGridViewTextBoxColumn4.HeaderText = ".Net DataType";
            this.NetDataTypedataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.NetDataTypedataGridViewTextBoxColumn4.Name = "NetDataTypedataGridViewTextBoxColumn4";
            this.NetDataTypedataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NetDataTypedataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DataSourceDataTypedataGridViewTextBoxColumn5
            // 
            this.DataSourceDataTypedataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataSourceDataTypedataGridViewTextBoxColumn5.DataPropertyName = "DataType";
            this.DataSourceDataTypedataGridViewTextBoxColumn5.HeaderText = "Data Type";
            this.DataSourceDataTypedataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.DataSourceDataTypedataGridViewTextBoxColumn5.Name = "DataSourceDataTypedataGridViewTextBoxColumn5";
            this.DataSourceDataTypedataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Fav
            // 
            this.Fav.DataPropertyName = "Fav";
            this.Fav.HeaderText = "Fav";
            this.Fav.Name = "Fav";
            // 
            // uc_DBFieldType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.mappingDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_DBFieldType";
            this.Size = new System.Drawing.Size(778, 675);
            ((System.ComponentModel.ISupportInitialize)(this.mappingDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource mappingBindingSource;
        private System.Windows.Forms.DataGridView mappingDataGridView;
        private uc_bindingNavigator uc_bindingNavigator1;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataSourcedataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn NetDataTypedataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSourceDataTypedataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Fav;
    }
}
