
namespace BeepEnterprize.Winform.Vis.CRUD
{
    partial class Frm_ListEntities
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
            this.kryptonPanel2 = new System.Windows.Forms.Panel();
            this.kryptonSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.EntityNameLabel = new System.Windows.Forms.Label();
            this.NewButton = new System.Windows.Forms.Button();
            this.SubtitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonPanel2.Controls.Add(this.panel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1173, 592);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 89);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.FilterPanel);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.DataGridView1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1173, 503);
            this.kryptonSplitContainer1.SplitterDistance = 409;
            this.kryptonSplitContainer1.TabIndex = 1;
            // 
            // FilterPanel
            // 
            this.FilterPanel.BackColor = System.Drawing.Color.White;
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(409, 503);
            this.FilterPanel.TabIndex = 0;
            // 
            // DataGridView1
            // 
            this.DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowHeadersWidth = 10;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.ShowCellErrors = false;
            this.DataGridView1.ShowEditingIcon = false;
            this.DataGridView1.ShowRowErrors = false;
            this.DataGridView1.Size = new System.Drawing.Size(760, 503);
            this.DataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PrintButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SubmitButton);
            this.panel1.Controls.Add(this.LoadDataButton);
            this.panel1.Controls.Add(this.EntityNameLabel);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.SubtitleLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 89);
            this.panel1.TabIndex = 9;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintButton.ForeColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(1087, 60);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(81, 25);
            this.PrintButton.TabIndex = 10;
            this.PrintButton.Text = "Print";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "DataSource";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gold;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Entity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.ForeColor = System.Drawing.Color.White;
            this.SubmitButton.Location = new System.Drawing.Point(652, 60);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(81, 25);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDataButton.ForeColor = System.Drawing.Color.White;
            this.LoadDataButton.Location = new System.Drawing.Point(739, 60);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(81, 25);
            this.LoadDataButton.TabIndex = 7;
            this.LoadDataButton.Text = "UpLoad";
            // 
            // EntityNameLabel
            // 
            this.EntityNameLabel.BackColor = System.Drawing.Color.White;
            this.EntityNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntityNameLabel.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold);
            this.EntityNameLabel.ForeColor = System.Drawing.Color.Black;
            this.EntityNameLabel.Location = new System.Drawing.Point(117, 61);
            this.EntityNameLabel.Name = "EntityNameLabel";
            this.EntityNameLabel.Size = new System.Drawing.Size(247, 23);
            this.EntityNameLabel.TabIndex = 4;
            this.EntityNameLabel.Text = "Entity Name";
            this.EntityNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewButton.ForeColor = System.Drawing.Color.White;
            this.NewButton.Location = new System.Drawing.Point(1000, 60);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(81, 25);
            this.NewButton.TabIndex = 2;
            this.NewButton.Text = "New";
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.BackColor = System.Drawing.Color.White;
            this.SubtitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubtitleLabel.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubtitleLabel.ForeColor = System.Drawing.Color.Black;
            this.SubtitleLabel.Location = new System.Drawing.Point(117, 37);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(247, 23);
            this.SubtitleLabel.TabIndex = 6;
            this.SubtitleLabel.Text = "Entity Name";
            this.SubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(68, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Entity Editor";
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Location = new System.Drawing.Point(826, 60);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(81, 25);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Edit";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(913, 60);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(81, 25);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            // 
            // Frm_ListEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "Frm_ListEntities";
            this.Size = new System.Drawing.Size(1173, 592);
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel kryptonPanel2;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.SplitContainer kryptonSplitContainer1;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Label EntityNameLabel;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label SubtitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button PrintButton;
    }
}