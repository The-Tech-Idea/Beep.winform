using BeepEnterprize.Winform.Vis.Controls;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    partial class uc_RunImport
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadDataLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StopButton = new System.Windows.Forms.Button();
            this.RunScriptbutton = new System.Windows.Forms.Button();
            this.mappedEntitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entityDataMapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ErrorsAllowdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new BeepEnterprize.Winform.Vis.Controls.TextProgressBar();
            this.LogtextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadDataLogsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappedEntitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataMapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorsAllowdnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 72);
            this.panel1.TabIndex = 5;
            // 
            // loadDataLogsBindingSource
            // 
            this.loadDataLogsBindingSource.DataSource = typeof(TheTechIdea.Beep.Workflow.LoadDataLogResult);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StopButton.Location = new System.Drawing.Point(803, 653);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 15;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // RunScriptbutton
            // 
            this.RunScriptbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RunScriptbutton.Location = new System.Drawing.Point(20, 653);
            this.RunScriptbutton.Name = "RunScriptbutton";
            this.RunScriptbutton.Size = new System.Drawing.Size(75, 23);
            this.RunScriptbutton.TabIndex = 13;
            this.RunScriptbutton.Text = "Run";
            this.RunScriptbutton.UseVisualStyleBackColor = true;
            // 
            // mappedEntitiesBindingSource
            // 
            this.mappedEntitiesBindingSource.DataMember = "MappedEntities";
            this.mappedEntitiesBindingSource.DataSource = this.entityDataMapBindingSource;
            // 
            // entityDataMapBindingSource
            // 
            this.entityDataMapBindingSource.DataSource = typeof(TheTechIdea.Beep.Workflow.Mapping.EntityDataMap);
            // 
            // ErrorsAllowdnumericUpDown
            // 
            this.ErrorsAllowdnumericUpDown.Location = new System.Drawing.Point(758, 83);
            this.ErrorsAllowdnumericUpDown.Name = "ErrorsAllowdnumericUpDown";
            this.ErrorsAllowdnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.ErrorsAllowdnumericUpDown.TabIndex = 26;
            this.ErrorsAllowdnumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(613, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Errors Allowed:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "currenrecordindex";
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "rundate";
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sourceDataSourceName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Source";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sourceEntityName";
            this.dataGridViewTextBoxColumn4.HeaderText = "EntityName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "errormessage";
            this.dataGridViewTextBoxColumn5.HeaderText = "Message";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "script";
            this.dataGridViewTextBoxColumn6.HeaderText = "script";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.CustomText = "";
            this.progressBar1.Location = new System.Drawing.Point(101, 653);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.LightGreen;
            this.progressBar1.Size = new System.Drawing.Size(696, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.TextColor = System.Drawing.Color.Black;
            this.progressBar1.TextFont = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.progressBar1.VisualMode = BeepEnterprize.Winform.Vis.Controls.ProgressBarDisplayMode.CurrProgress;
            // 
            // LogtextBox
            // 
            this.LogtextBox.Location = new System.Drawing.Point(20, 123);
            this.LogtextBox.Multiline = true;
            this.LogtextBox.Name = "LogtextBox";
            this.LogtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogtextBox.Size = new System.Drawing.Size(858, 524);
            this.LogtextBox.TabIndex = 27;
            // 
            // uc_RunImport
            // 
            this.Controls.Add(this.LogtextBox);
            this.Controls.Add(this.ErrorsAllowdnumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.RunScriptbutton);
            this.Controls.Add(this.panel1);
            this.Name = "uc_RunImport";
            this.Size = new System.Drawing.Size(899, 706);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadDataLogsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappedEntitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataMapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorsAllowdnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

     
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StopButton;
        private TextProgressBar progressBar1;
        private System.Windows.Forms.Button RunScriptbutton;
        private System.Windows.Forms.BindingSource mappedEntitiesBindingSource;
        private System.Windows.Forms.BindingSource entityDataMapBindingSource;
        private System.Windows.Forms.NumericUpDown ErrorsAllowdnumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource loadDataLogsBindingSource;
        private System.Windows.Forms.TextBox LogtextBox;
    }
}
