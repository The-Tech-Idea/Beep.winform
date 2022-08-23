
namespace BeepEnterprize.Winform.Vis.Wizards.DataConnection
{
    partial class Frm_SelectDataSource
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataConnectionsDataGridView = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 72);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Fields";
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // dataConnectionsDataGridView
            // 
            this.dataConnectionsDataGridView.AutoGenerateColumns = false;
            this.dataConnectionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataConnectionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.DeleteButton});
            this.dataConnectionsDataGridView.DataSource = this.dataConnectionsBindingSource;
            this.dataConnectionsDataGridView.Location = new System.Drawing.Point(22, 93);
            this.dataConnectionsDataGridView.Name = "dataConnectionsDataGridView";
            this.dataConnectionsDataGridView.Size = new System.Drawing.Size(823, 433);
            this.dataConnectionsDataGridView.TabIndex = 10;
            // 
            // EditButton
            // 
            this.EditButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditButton.HeaderText = "Edit";
            this.EditButton.Name = "EditButton";
            this.EditButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditButton.Text = "Edit";
            this.EditButton.Width = 31;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ConnectionName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "ConnectionName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // DeleteButton
            // 
            this.DeleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DeleteButton.HeaderText = "Delete";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Width = 44;
            // 
            // Frm_SelectDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 554);
            this.Controls.Add(this.dataConnectionsDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_SelectDataSource";
            this.Text = "Datasource Connection Management";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
        private System.Windows.Forms.DataGridView dataConnectionsDataGridView;
        private System.Windows.Forms.DataGridViewLinkColumn EditButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteButton;
    }
}