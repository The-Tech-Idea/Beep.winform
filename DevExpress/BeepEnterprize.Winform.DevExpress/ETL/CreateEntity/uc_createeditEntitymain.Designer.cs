namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    partial class uc_createeditEntitymain
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label captionLabel;
            System.Windows.Forms.Label entityNameLabel;
            System.Windows.Forms.Label originalEntityNameLabel;
            System.Windows.Forms.Label datasourceEntityNameLabel;
            System.Windows.Forms.Label createdLabel;
            System.Windows.Forms.Label customBuildQueryLabel;
            System.Windows.Forms.Label categoryLabel;
            this.entitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.entityNameTextBox = new System.Windows.Forms.TextBox();
            this.originalEntityNameTextBox = new System.Windows.Forms.TextBox();
            this.datasourceEntityNameTextBox = new System.Windows.Forms.TextBox();
            this.createdMyCheckBox = new BeepEnterprize.Winform.Vis.Controls.MyCheckBox();
            this.customBuildQueryTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            idLabel = new System.Windows.Forms.Label();
            captionLabel = new System.Windows.Forms.Label();
            entityNameLabel = new System.Windows.Forms.Label();
            originalEntityNameLabel = new System.Windows.Forms.Label();
            datasourceEntityNameLabel = new System.Windows.Forms.Label();
            createdLabel = new System.Windows.Forms.Label();
            customBuildQueryLabel = new System.Windows.Forms.Label();
            categoryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // entitiesBindingSource
            // 
            this.entitiesBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityStructure);
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idLabel.Location = new System.Drawing.Point(260, 92);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(28, 23);
            idLabel.TabIndex = 3;
            idLabel.Text = "Id:";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(294, 95);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 4;
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel.Location = new System.Drawing.Point(214, 118);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new System.Drawing.Size(74, 23);
            captionLabel.TabIndex = 4;
            captionLabel.Text = "Caption:";
            // 
            // captionTextBox
            // 
            this.captionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "Caption", true));
            this.captionTextBox.Location = new System.Drawing.Point(294, 121);
            this.captionTextBox.Name = "captionTextBox";
            this.captionTextBox.Size = new System.Drawing.Size(472, 20);
            this.captionTextBox.TabIndex = 5;
            // 
            // entityNameLabel
            // 
            entityNameLabel.AutoSize = true;
            entityNameLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            entityNameLabel.Location = new System.Drawing.Point(178, 144);
            entityNameLabel.Name = "entityNameLabel";
            entityNameLabel.Size = new System.Drawing.Size(110, 23);
            entityNameLabel.TabIndex = 5;
            entityNameLabel.Text = "Entity Name:";
            // 
            // entityNameTextBox
            // 
            this.entityNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "EntityName", true));
            this.entityNameTextBox.Location = new System.Drawing.Point(294, 147);
            this.entityNameTextBox.Name = "entityNameTextBox";
            this.entityNameTextBox.Size = new System.Drawing.Size(472, 20);
            this.entityNameTextBox.TabIndex = 6;
            // 
            // originalEntityNameLabel
            // 
            originalEntityNameLabel.AutoSize = true;
            originalEntityNameLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            originalEntityNameLabel.Location = new System.Drawing.Point(114, 170);
            originalEntityNameLabel.Name = "originalEntityNameLabel";
            originalEntityNameLabel.Size = new System.Drawing.Size(174, 23);
            originalEntityNameLabel.TabIndex = 7;
            originalEntityNameLabel.Text = "Original Entity Name:";
            // 
            // originalEntityNameTextBox
            // 
            this.originalEntityNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "OriginalEntityName", true));
            this.originalEntityNameTextBox.Location = new System.Drawing.Point(294, 173);
            this.originalEntityNameTextBox.Name = "originalEntityNameTextBox";
            this.originalEntityNameTextBox.Size = new System.Drawing.Size(472, 20);
            this.originalEntityNameTextBox.TabIndex = 8;
            // 
            // datasourceEntityNameLabel
            // 
            datasourceEntityNameLabel.AutoSize = true;
            datasourceEntityNameLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            datasourceEntityNameLabel.Location = new System.Drawing.Point(86, 196);
            datasourceEntityNameLabel.Name = "datasourceEntityNameLabel";
            datasourceEntityNameLabel.Size = new System.Drawing.Size(202, 23);
            datasourceEntityNameLabel.TabIndex = 9;
            datasourceEntityNameLabel.Text = "Datasource Entity Name:";
            // 
            // datasourceEntityNameTextBox
            // 
            this.datasourceEntityNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "DatasourceEntityName", true));
            this.datasourceEntityNameTextBox.Location = new System.Drawing.Point(294, 199);
            this.datasourceEntityNameTextBox.Name = "datasourceEntityNameTextBox";
            this.datasourceEntityNameTextBox.Size = new System.Drawing.Size(472, 20);
            this.datasourceEntityNameTextBox.TabIndex = 10;
            // 
            // createdLabel
            // 
            createdLabel.AutoSize = true;
            createdLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            createdLabel.Location = new System.Drawing.Point(212, 224);
            createdLabel.Name = "createdLabel";
            createdLabel.Size = new System.Drawing.Size(76, 23);
            createdLabel.TabIndex = 11;
            createdLabel.Text = "Created:";
            // 
            // createdMyCheckBox
            // 
            this.createdMyCheckBox.Checked = 'N';
            this.createdMyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.entitiesBindingSource, "Created", true));
            this.createdMyCheckBox.FalseValue = 'N';
            this.createdMyCheckBox.Location = new System.Drawing.Point(294, 225);
            this.createdMyCheckBox.Name = "createdMyCheckBox";
            this.createdMyCheckBox.Size = new System.Drawing.Size(104, 24);
            this.createdMyCheckBox.TabIndex = 12;
            this.createdMyCheckBox.TrueValue = 'Y';
            this.createdMyCheckBox.UseVisualStyleBackColor = true;
            // 
            // customBuildQueryLabel
            // 
            customBuildQueryLabel.AutoSize = true;
            customBuildQueryLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            customBuildQueryLabel.Location = new System.Drawing.Point(122, 252);
            customBuildQueryLabel.Name = "customBuildQueryLabel";
            customBuildQueryLabel.Size = new System.Drawing.Size(166, 23);
            customBuildQueryLabel.TabIndex = 13;
            customBuildQueryLabel.Text = "Custom Build Query:";
            // 
            // customBuildQueryTextBox
            // 
            this.customBuildQueryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "CustomBuildQuery", true));
            this.customBuildQueryTextBox.Location = new System.Drawing.Point(294, 255);
            this.customBuildQueryTextBox.Multiline = true;
            this.customBuildQueryTextBox.Name = "customBuildQueryTextBox";
            this.customBuildQueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.customBuildQueryTextBox.Size = new System.Drawing.Size(472, 241);
            this.customBuildQueryTextBox.TabIndex = 14;
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            categoryLabel.Location = new System.Drawing.Point(203, 499);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new System.Drawing.Size(85, 23);
            categoryLabel.TabIndex = 15;
            categoryLabel.Text = "Category:";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "Category", true));
            this.categoryTextBox.Location = new System.Drawing.Point(294, 502);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(189, 20);
            this.categoryTextBox.TabIndex = 16;
            // 
            // uc_createeditEntitymain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(categoryLabel);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(customBuildQueryLabel);
            this.Controls.Add(this.customBuildQueryTextBox);
            this.Controls.Add(createdLabel);
            this.Controls.Add(this.createdMyCheckBox);
            this.Controls.Add(datasourceEntityNameLabel);
            this.Controls.Add(this.datasourceEntityNameTextBox);
            this.Controls.Add(originalEntityNameLabel);
            this.Controls.Add(this.originalEntityNameTextBox);
            this.Controls.Add(entityNameLabel);
            this.Controls.Add(this.entityNameTextBox);
            this.Controls.Add(captionLabel);
            this.Controls.Add(this.captionTextBox);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Name = "uc_createeditEntitymain";
            this.Size = new System.Drawing.Size(924, 574);
            this.Controls.SetChildIndex(this.idTextBox, 0);
            this.Controls.SetChildIndex(idLabel, 0);
            this.Controls.SetChildIndex(this.captionTextBox, 0);
            this.Controls.SetChildIndex(captionLabel, 0);
            this.Controls.SetChildIndex(this.entityNameTextBox, 0);
            this.Controls.SetChildIndex(entityNameLabel, 0);
            this.Controls.SetChildIndex(this.originalEntityNameTextBox, 0);
            this.Controls.SetChildIndex(originalEntityNameLabel, 0);
            this.Controls.SetChildIndex(this.datasourceEntityNameTextBox, 0);
            this.Controls.SetChildIndex(datasourceEntityNameLabel, 0);
            this.Controls.SetChildIndex(this.createdMyCheckBox, 0);
            this.Controls.SetChildIndex(createdLabel, 0);
            this.Controls.SetChildIndex(this.customBuildQueryTextBox, 0);
            this.Controls.SetChildIndex(customBuildQueryLabel, 0);
            this.Controls.SetChildIndex(this.categoryTextBox, 0);
            this.Controls.SetChildIndex(categoryLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource entitiesBindingSource;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox captionTextBox;
        private System.Windows.Forms.TextBox entityNameTextBox;
        private System.Windows.Forms.TextBox originalEntityNameTextBox;
        private System.Windows.Forms.TextBox datasourceEntityNameTextBox;
        private Controls.MyCheckBox createdMyCheckBox;
        private System.Windows.Forms.TextBox customBuildQueryTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
    }
}
