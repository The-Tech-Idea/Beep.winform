
using BeepEnterprize.Winform.Vis.Controls;

namespace BeepEnterprize.Winform.Vis.ETL.CopyEntityandData
{
    partial class uc_CopyEntities
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.scriptDataGridView = new System.Windows.Forms.DataGridView();
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LogtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EntitiesnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrorsAllowdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RunMainScripButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new TextProgressBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.loadDataLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Failed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.destinationentityname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCreated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsModified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sourcedatasourcename = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.destinationdatasourcename = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.scriptTypeComboBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errormessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorsAllowdnumericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadDataLogsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.scriptDataGridView);
            this.panel1.Controls.Add(this.LogtextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EntitiesnumericUpDown);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ErrorsAllowdnumericUpDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 557);
            this.panel1.TabIndex = 22;
            // 
            // scriptDataGridView
            // 
            this.scriptDataGridView.AllowUserToDeleteRows = false;
            this.scriptDataGridView.AllowUserToOrderColumns = true;
            this.scriptDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptDataGridView.AutoGenerateColumns = false;
            this.scriptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scriptDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Failed,
            this.destinationentityname,
            this.IsCreated,
            this.IsModified,
            this.sourcedatasourcename,
            this.destinationdatasourcename,
            this.scriptTypeComboBox,
            this.ddlDataGridViewTextBoxColumn,
            this.errormessageDataGridViewTextBoxColumn});
            this.scriptDataGridView.DataSource = this.scriptBindingSource;
            this.scriptDataGridView.Location = new System.Drawing.Point(3, 56);
            this.scriptDataGridView.Name = "scriptDataGridView";
            this.scriptDataGridView.ReadOnly = true;
            this.scriptDataGridView.ShowCellErrors = false;
            this.scriptDataGridView.Size = new System.Drawing.Size(1254, 264);
            this.scriptDataGridView.TabIndex = 33;
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // scriptBindingSource
            // 
            this.scriptBindingSource.DataSource = typeof(TheTechIdea.Beep.Editor.ETLScriptDet);
            // 
            // LogtextBox
            // 
            this.LogtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogtextBox.Location = new System.Drawing.Point(3, 326);
            this.LogtextBox.Multiline = true;
            this.LogtextBox.Name = "LogtextBox";
            this.LogtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogtextBox.Size = new System.Drawing.Size(1254, 182);
            this.LogtextBox.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "No.of Scripts:";
            // 
            // EntitiesnumericUpDown
            // 
            this.EntitiesnumericUpDown.Location = new System.Drawing.Point(126, 19);
            this.EntitiesnumericUpDown.Name = "EntitiesnumericUpDown";
            this.EntitiesnumericUpDown.ReadOnly = true;
            this.EntitiesnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.EntitiesnumericUpDown.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(256, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Errors Allowed:";
            // 
            // ErrorsAllowdnumericUpDown
            // 
            this.ErrorsAllowdnumericUpDown.Location = new System.Drawing.Point(377, 19);
            this.ErrorsAllowdnumericUpDown.Name = "ErrorsAllowdnumericUpDown";
            this.ErrorsAllowdnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.ErrorsAllowdnumericUpDown.TabIndex = 30;
            this.ErrorsAllowdnumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // RunMainScripButton
            // 
            this.RunMainScripButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RunMainScripButton.ForeColor = System.Drawing.Color.Black;
            this.RunMainScripButton.Location = new System.Drawing.Point(158, 4);
            this.RunMainScripButton.Name = "RunMainScripButton";
            this.RunMainScripButton.Size = new System.Drawing.Size(90, 25);
            this.RunMainScripButton.TabIndex = 24;
            this.RunMainScripButton.Text = "Run";
            this.RunMainScripButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copy Entities";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 72);
            this.panel2.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.RunMainScripButton);
            this.panel3.Controls.Add(this.StopButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 590);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1262, 39);
            this.panel3.TabIndex = 27;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.CustomText = "";
            this.progressBar1.Location = new System.Drawing.Point(254, 6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.LightGreen;
            this.progressBar1.Size = new System.Drawing.Size(734, 23);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.TextColor = System.Drawing.Color.Black;
            this.progressBar1.TextFont = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.progressBar1.VisualMode = ProgressBarDisplayMode.CurrProgress;
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StopButton.Location = new System.Drawing.Point(994, 6);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 28;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // loadDataLogsBindingSource
            // 
            this.loadDataLogsBindingSource.DataSource = typeof(TheTechIdea.Beep.Workflow.LoadDataLogResult);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "scriptType";
            this.dataGridViewTextBoxColumn1.HeaderText = "scriptType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "scriptType";
            this.dataGridViewTextBoxColumn2.HeaderText = "scriptType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "errormessage";
            this.dataGridViewTextBoxColumn3.HeaderText = "Messege";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Failed
            // 
            this.Failed.DataPropertyName = "Failed";
            this.Failed.HeaderText = "Failed";
            this.Failed.Name = "Failed";
            this.Failed.ReadOnly = true;
            // 
            // destinationentityname
            // 
            this.destinationentityname.DataPropertyName = "destinationentityname";
            this.destinationentityname.HeaderText = "Entity";
            this.destinationentityname.Name = "destinationentityname";
            this.destinationentityname.ReadOnly = true;
            // 
            // IsCreated
            // 
            this.IsCreated.DataPropertyName = "IsCreated";
            this.IsCreated.HeaderText = "IsCreated";
            this.IsCreated.Name = "IsCreated";
            this.IsCreated.ReadOnly = true;
            // 
            // IsModified
            // 
            this.IsModified.DataPropertyName = "IsModified";
            this.IsModified.HeaderText = "IsModified";
            this.IsModified.Name = "IsModified";
            this.IsModified.ReadOnly = true;
            // 
            // sourcedatasourcename
            // 
            this.sourcedatasourcename.DataPropertyName = "sourcedatasourcename";
            this.sourcedatasourcename.DataSource = this.dataConnectionsBindingSource;
            this.sourcedatasourcename.DisplayMember = "ConnectionName";
            this.sourcedatasourcename.HeaderText = "Source";
            this.sourcedatasourcename.Name = "sourcedatasourcename";
            this.sourcedatasourcename.ReadOnly = true;
            this.sourcedatasourcename.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sourcedatasourcename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sourcedatasourcename.ValueMember = "ConnectionName";
            // 
            // destinationdatasourcename
            // 
            this.destinationdatasourcename.DataPropertyName = "destinationdatasourcename";
            this.destinationdatasourcename.DataSource = this.dataConnectionsBindingSource;
            this.destinationdatasourcename.DisplayMember = "ConnectionName";
            this.destinationdatasourcename.HeaderText = "Destination";
            this.destinationdatasourcename.Name = "destinationdatasourcename";
            this.destinationdatasourcename.ReadOnly = true;
            this.destinationdatasourcename.ValueMember = "ConnectionName";
            // 
            // scriptTypeComboBox
            // 
            this.scriptTypeComboBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.scriptTypeComboBox.DataPropertyName = "scriptType";
            this.scriptTypeComboBox.HeaderText = "scriptType";
            this.scriptTypeComboBox.Name = "scriptTypeComboBox";
            this.scriptTypeComboBox.ReadOnly = true;
            this.scriptTypeComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.scriptTypeComboBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.scriptTypeComboBox.Visible = false;
            this.scriptTypeComboBox.Width = 62;
            // 
            // ddlDataGridViewTextBoxColumn
            // 
            this.ddlDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ddlDataGridViewTextBoxColumn.DataPropertyName = "ddl";
            this.ddlDataGridViewTextBoxColumn.HeaderText = "Script";
            this.ddlDataGridViewTextBoxColumn.Name = "ddlDataGridViewTextBoxColumn";
            this.ddlDataGridViewTextBoxColumn.ReadOnly = true;
            this.ddlDataGridViewTextBoxColumn.Visible = false;
            this.ddlDataGridViewTextBoxColumn.Width = 59;
            // 
            // errormessageDataGridViewTextBoxColumn
            // 
            this.errormessageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.errormessageDataGridViewTextBoxColumn.DataPropertyName = "errormessage";
            this.errormessageDataGridViewTextBoxColumn.HeaderText = "Messege";
            this.errormessageDataGridViewTextBoxColumn.Name = "errormessageDataGridViewTextBoxColumn";
            this.errormessageDataGridViewTextBoxColumn.ReadOnly = true;
            this.errormessageDataGridViewTextBoxColumn.Visible = false;
            this.errormessageDataGridViewTextBoxColumn.Width = 75;
            // 
            // uc_CopyEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "uc_CopyEntities";
            this.Size = new System.Drawing.Size(1262, 629);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorsAllowdnumericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadDataLogsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource scriptBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RunMainScripButton;
        private TextProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource loadDataLogsBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ErrorsAllowdnumericUpDown;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox LogtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown EntitiesnumericUpDown;
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView scriptDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Failed;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationentityname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCreated;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsModified;
        private System.Windows.Forms.DataGridViewComboBoxColumn sourcedatasourcename;
        private System.Windows.Forms.DataGridViewComboBoxColumn destinationdatasourcename;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptTypeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errormessageDataGridViewTextBoxColumn;
    }
}
