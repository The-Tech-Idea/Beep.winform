namespace BeepEnterprize.Winform.Vis.DataViewManagement
{
    partial class uc_CreateComposedLayerFromView
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataConnectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EmbeddedDatabaseTypecomboBox = new System.Windows.Forms.ComboBox();
            this.InstallFoldercomboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.Okbutton = new System.Windows.Forms.Button();
            this.CreateLayerButton = new System.Windows.Forms.Button();
            this.CreateEntitiesbutton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ViewNameLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 72);
            this.panel2.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(401, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Data View";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewNameLabel
            // 
            this.ViewNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ViewNameLabel.BackColor = System.Drawing.Color.Orange;
            this.ViewNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewNameLabel.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold);
            this.ViewNameLabel.ForeColor = System.Drawing.Color.Black;
            this.ViewNameLabel.Location = new System.Drawing.Point(507, 34);
            this.ViewNameLabel.Name = "ViewNameLabel";
            this.ViewNameLabel.Size = new System.Drawing.Size(191, 23);
            this.ViewNameLabel.TabIndex = 18;
            this.ViewNameLabel.Text = "View Name";
            this.ViewNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Composite Data Creator";
            // 
            // dataConnectionsBindingSource
            // 
            this.dataConnectionsBindingSource.DataSource = typeof(TheTechIdea.Util.ConnectionProperties);
            // 
            // databaseTextBox
            // 
            this.databaseTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.databaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsBindingSource, "Database", true));
            this.databaseTextBox.Location = new System.Drawing.Point(212, 154);
            this.databaseTextBox.Name = "databaseTextBox";
            this.databaseTextBox.Size = new System.Drawing.Size(248, 20);
            this.databaseTextBox.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Composed Layer Name";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Class  Database Type";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Installation Folder";
            // 
            // EmbeddedDatabaseTypecomboBox
            // 
            this.EmbeddedDatabaseTypecomboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmbeddedDatabaseTypecomboBox.FormattingEnabled = true;
            this.EmbeddedDatabaseTypecomboBox.Location = new System.Drawing.Point(212, 127);
            this.EmbeddedDatabaseTypecomboBox.Name = "EmbeddedDatabaseTypecomboBox";
            this.EmbeddedDatabaseTypecomboBox.Size = new System.Drawing.Size(248, 21);
            this.EmbeddedDatabaseTypecomboBox.TabIndex = 37;
            // 
            // InstallFoldercomboBox
            // 
            this.InstallFoldercomboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InstallFoldercomboBox.FormattingEnabled = true;
            this.InstallFoldercomboBox.Location = new System.Drawing.Point(212, 100);
            this.InstallFoldercomboBox.Name = "InstallFoldercomboBox";
            this.InstallFoldercomboBox.Size = new System.Drawing.Size(446, 21);
            this.InstallFoldercomboBox.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Cancelbutton);
            this.panel1.Controls.Add(this.Okbutton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 49);
            this.panel1.TabIndex = 39;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Cancelbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancelbutton.Location = new System.Drawing.Point(619, 4);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(95, 42);
            this.Cancelbutton.TabIndex = 41;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // Okbutton
            // 
            this.Okbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Okbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Okbutton.Location = new System.Drawing.Point(10, 4);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(86, 42);
            this.Okbutton.TabIndex = 40;
            this.Okbutton.Text = "OK";
            this.Okbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Okbutton.UseVisualStyleBackColor = true;
            // 
            // CreateLayerButton
            // 
            this.CreateLayerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateLayerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CreateLayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateLayerButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CreateLayerButton.Location = new System.Drawing.Point(212, 180);
            this.CreateLayerButton.Name = "CreateLayerButton";
            this.CreateLayerButton.Size = new System.Drawing.Size(248, 104);
            this.CreateLayerButton.TabIndex = 0;
            this.CreateLayerButton.Text = "Create Layer";
            this.CreateLayerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CreateLayerButton.UseCompatibleTextRendering = true;
            this.CreateLayerButton.UseVisualStyleBackColor = true;
            // 
            // CreateEntitiesbutton
            // 
            this.CreateEntitiesbutton.Location = new System.Drawing.Point(10, 79);
            this.CreateEntitiesbutton.Name = "CreateEntitiesbutton";
            this.CreateEntitiesbutton.Size = new System.Drawing.Size(62, 42);
            this.CreateEntitiesbutton.TabIndex = 1;
            this.CreateEntitiesbutton.Text = "Create Entities";
            this.CreateEntitiesbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateEntitiesbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CreateEntitiesbutton.UseVisualStyleBackColor = true;
            this.CreateEntitiesbutton.Visible = false;
            // 
            // uc_CreateComposedLayerFromView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CreateEntitiesbutton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CreateLayerButton);
            this.Controls.Add(this.databaseTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EmbeddedDatabaseTypecomboBox);
            this.Controls.Add(this.InstallFoldercomboBox);
            this.Controls.Add(this.panel2);
            this.Name = "uc_CreateComposedLayerFromView";
            this.Size = new System.Drawing.Size(717, 353);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConnectionsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ViewNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dataConnectionsBindingSource;
        private System.Windows.Forms.TextBox databaseTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox EmbeddedDatabaseTypecomboBox;
        private System.Windows.Forms.ComboBox InstallFoldercomboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateLayerButton;
        private System.Windows.Forms.Button CreateEntitiesbutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button Okbutton;
    }
}
