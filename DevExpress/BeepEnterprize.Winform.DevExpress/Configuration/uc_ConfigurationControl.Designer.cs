using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis
{
    partial class uc_ConfigurationControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addinFoldersDataGridView = new System.Windows.Forms.DataGridView();
            this.folderPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderFilesTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.foldersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.addinFoldersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foldersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addinFoldersDataGridView
            // 
            this.addinFoldersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addinFoldersDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addinFoldersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.addinFoldersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addinFoldersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folderPathDataGridViewTextBoxColumn,
            this.folderFilesTypeDataGridViewTextBoxColumn});
            this.addinFoldersDataGridView.DataSource = this.foldersBindingSource;
            this.addinFoldersDataGridView.EnableHeadersVisualStyles = false;
            this.addinFoldersDataGridView.Location = new System.Drawing.Point(2, 2);
            this.addinFoldersDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.addinFoldersDataGridView.Name = "addinFoldersDataGridView";
            this.addinFoldersDataGridView.RowHeadersVisible = false;
            this.addinFoldersDataGridView.RowHeadersWidth = 62;
            this.addinFoldersDataGridView.RowTemplate.Height = 28;
            this.addinFoldersDataGridView.Size = new System.Drawing.Size(995, 616);
            this.addinFoldersDataGridView.TabIndex = 0;
            // 
            // folderPathDataGridViewTextBoxColumn
            // 
            this.folderPathDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.folderPathDataGridViewTextBoxColumn.DataPropertyName = "FolderPath";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.folderPathDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.folderPathDataGridViewTextBoxColumn.HeaderText = "Folder Path";
            this.folderPathDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.folderPathDataGridViewTextBoxColumn.Name = "folderPathDataGridViewTextBoxColumn";
            // 
            // folderFilesTypeDataGridViewTextBoxColumn
            // 
            this.folderFilesTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.folderFilesTypeDataGridViewTextBoxColumn.DataPropertyName = "FolderFilesType";
            this.folderFilesTypeDataGridViewTextBoxColumn.HeaderText = "Folder Type";
            this.folderFilesTypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.folderFilesTypeDataGridViewTextBoxColumn.Name = "folderFilesTypeDataGridViewTextBoxColumn";
            this.folderFilesTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.folderFilesTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.folderFilesTypeDataGridViewTextBoxColumn.Width = 88;
            // 
            // foldersBindingSource
            // 
            this.foldersBindingSource.DataSource = typeof(TheTechIdea.Util.StorageFolders);
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(2, 618);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(995, 31);
            this.uc_bindingNavigator1.TabIndex = 1;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // uc_ConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addinFoldersDataGridView);
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uc_ConfigurationControl";
            this.Size = new System.Drawing.Size(999, 656);
            ((System.ComponentModel.ISupportInitialize)(this.addinFoldersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foldersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView addinFoldersDataGridView;
        private System.Windows.Forms.BindingSource foldersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn folderPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn folderFilesTypeDataGridViewTextBoxColumn;
        private uc_bindingNavigator uc_bindingNavigator1;
    }
}
