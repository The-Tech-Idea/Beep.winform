
namespace BeepEnterprize.Winform.Vis.Wizards.DataConnection
{
    partial class Frm_File
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
            System.Windows.Forms.Label fileNameLabel;
            System.Windows.Forms.Label filePathLabel;
            System.Windows.Forms.Label connectionStringLabel;
            System.Windows.Forms.Label connectionNameLabel;
            System.Windows.Forms.Label driverVersionLabel;
            System.Windows.Forms.Label driverNameLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.connectionNameTextBox = new System.Windows.Forms.TextBox();
            this.driverVersionComboBox = new System.Windows.Forms.ComboBox();
            this.driverNameComboBox = new System.Windows.Forms.ComboBox();
            this.SaveFilebutton = new System.Windows.Forms.Button();
            fileNameLabel = new System.Windows.Forms.Label();
            filePathLabel = new System.Windows.Forms.Label();
            connectionStringLabel = new System.Windows.Forms.Label();
            connectionNameLabel = new System.Windows.Forms.Label();
            driverVersionLabel = new System.Windows.Forms.Label();
            driverNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(667, 72);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Files Connection";
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(110, 135);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(57, 13);
            fileNameLabel.TabIndex = 11;
            fileNameLabel.Text = "File Name:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "FileName", true));
            this.fileNameTextBox.Location = new System.Drawing.Point(169, 132);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(435, 20);
            this.fileNameTextBox.TabIndex = 12;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Location = new System.Drawing.Point(116, 161);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new System.Drawing.Size(51, 13);
            filePathLabel.TabIndex = 12;
            filePathLabel.Text = "File Path:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "FilePath", true));
            this.filePathTextBox.Location = new System.Drawing.Point(169, 158);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(435, 20);
            this.filePathTextBox.TabIndex = 13;
            // 
            // connectionStringLabel
            // 
            connectionStringLabel.AutoSize = true;
            connectionStringLabel.Location = new System.Drawing.Point(73, 187);
            connectionStringLabel.Name = "connectionStringLabel";
            connectionStringLabel.Size = new System.Drawing.Size(94, 13);
            connectionStringLabel.TabIndex = 13;
            connectionStringLabel.Text = "Connection String:";
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "ConnectionString", true));
            this.connectionStringTextBox.Location = new System.Drawing.Point(169, 184);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(435, 20);
            this.connectionStringTextBox.TabIndex = 14;
            // 
            // connectionNameLabel
            // 
            connectionNameLabel.AutoSize = true;
            connectionNameLabel.Location = new System.Drawing.Point(72, 109);
            connectionNameLabel.Name = "connectionNameLabel";
            connectionNameLabel.Size = new System.Drawing.Size(95, 13);
            connectionNameLabel.TabIndex = 14;
            connectionNameLabel.Text = "Connection Name:";
            // 
            // connectionNameTextBox
            // 
            this.connectionNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "ConnectionName", true));
            this.connectionNameTextBox.Location = new System.Drawing.Point(169, 106);
            this.connectionNameTextBox.Name = "connectionNameTextBox";
            this.connectionNameTextBox.Size = new System.Drawing.Size(435, 20);
            this.connectionNameTextBox.TabIndex = 15;
            // 
            // driverVersionLabel
            // 
            driverVersionLabel.AutoSize = true;
            driverVersionLabel.Location = new System.Drawing.Point(91, 236);
            driverVersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            driverVersionLabel.Name = "driverVersionLabel";
            driverVersionLabel.Size = new System.Drawing.Size(76, 13);
            driverVersionLabel.TabIndex = 42;
            driverVersionLabel.Text = "Driver Version:";
            // 
            // driverVersionComboBox
            // 
            this.driverVersionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "DriverVersion", true));
            this.driverVersionComboBox.FormattingEnabled = true;
            this.driverVersionComboBox.Location = new System.Drawing.Point(169, 234);
            this.driverVersionComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.driverVersionComboBox.Name = "driverVersionComboBox";
            this.driverVersionComboBox.Size = new System.Drawing.Size(82, 21);
            this.driverVersionComboBox.TabIndex = 40;
            // 
            // driverNameLabel
            // 
            driverNameLabel.AutoSize = true;
            driverNameLabel.Location = new System.Drawing.Point(98, 211);
            driverNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            driverNameLabel.Name = "driverNameLabel";
            driverNameLabel.Size = new System.Drawing.Size(69, 13);
            driverNameLabel.TabIndex = 41;
            driverNameLabel.Text = "Driver Name:";
            // 
            // driverNameComboBox
            // 
            this.driverNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "DriverName", true));
            this.driverNameComboBox.FormattingEnabled = true;
            this.driverNameComboBox.Location = new System.Drawing.Point(169, 209);
            this.driverNameComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.driverNameComboBox.Name = "driverNameComboBox";
            this.driverNameComboBox.Size = new System.Drawing.Size(218, 21);
            this.driverNameComboBox.TabIndex = 39;
            // 
            // SaveFilebutton
            // 
            this.SaveFilebutton.Font = new System.Drawing.Font("Haettenschweiler", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveFilebutton.Location = new System.Drawing.Point(309, 268);
            this.SaveFilebutton.Name = "SaveFilebutton";
            this.SaveFilebutton.Size = new System.Drawing.Size(122, 47);
            this.SaveFilebutton.TabIndex = 43;
            this.SaveFilebutton.Text = "Save";
            this.SaveFilebutton.UseVisualStyleBackColor = true;
            // 
            // Frm_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 336);
            this.Controls.Add(this.SaveFilebutton);
            this.Controls.Add(driverVersionLabel);
            this.Controls.Add(this.driverVersionComboBox);
            this.Controls.Add(driverNameLabel);
            this.Controls.Add(this.driverNameComboBox);
            this.Controls.Add(connectionNameLabel);
            this.Controls.Add(this.connectionNameTextBox);
            this.Controls.Add(connectionStringLabel);
            this.Controls.Add(this.connectionStringTextBox);
            this.Controls.Add(filePathLabel);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_File";
            this.Text = "Frm_File";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TextBox connectionStringTextBox;
        private System.Windows.Forms.TextBox connectionNameTextBox;
        private System.Windows.Forms.ComboBox driverVersionComboBox;
        private System.Windows.Forms.ComboBox driverNameComboBox;
        private System.Windows.Forms.Button SaveFilebutton;
    }
}