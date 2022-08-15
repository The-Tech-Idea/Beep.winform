
using Beep.Winform.Controls;

namespace TheTechIdea.ETL
{
    partial class uc_linkentitytoanother
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
            System.Windows.Forms.Label entityNameLabel;
            this.entitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entityNameTextBox = new System.Windows.Forms.TextBox();
            this.relationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relationsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedEntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedEntityColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldscomboBox = new System.Windows.Forms.ComboBox();
            this.fieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ParentEntitycomboBox = new System.Windows.Forms.ComboBox();
            this.otherentitiesbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ParentFieldcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.otherentityfieldsbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MainbindingNavigator = new uc_bindingNavigator();
            this.RelationbindingNavigator = new uc_bindingNavigator();
            entityNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherentitiesbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherentityfieldsbindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityNameLabel
            // 
            entityNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            entityNameLabel.AutoSize = true;
            entityNameLabel.Location = new System.Drawing.Point(174, 44);
            entityNameLabel.Name = "entityNameLabel";
            entityNameLabel.Size = new System.Drawing.Size(67, 13);
            entityNameLabel.TabIndex = 1;
            entityNameLabel.Text = "Entity Name:";
            // 
            // entitiesBindingSource
            // 
            this.entitiesBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityStructure);
            // 
            // entityNameTextBox
            // 
            this.entityNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.entityNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entitiesBindingSource, "EntityName", true));
            this.entityNameTextBox.Location = new System.Drawing.Point(250, 41);
            this.entityNameTextBox.Name = "entityNameTextBox";
            this.entityNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.entityNameTextBox.TabIndex = 2;
            // 
            // relationsBindingSource
            // 
            this.relationsBindingSource.DataMember = "Relations";
            this.relationsBindingSource.DataSource = this.entitiesBindingSource;
            // 
            // relationsDataGridView
            // 
            this.relationsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.relationsDataGridView.AutoGenerateColumns = false;
            this.relationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.RelatedEntityID,
            this.RelatedEntityColumnID,
            this.dataGridViewTextBoxColumn4});
            this.relationsDataGridView.DataSource = this.relationsBindingSource;
            this.relationsDataGridView.Location = new System.Drawing.Point(2, 108);
            this.relationsDataGridView.Name = "relationsDataGridView";
            this.relationsDataGridView.ReadOnly = true;
            this.relationsDataGridView.RowHeadersWidth = 62;
            this.relationsDataGridView.Size = new System.Drawing.Size(685, 289);
            this.relationsDataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RalationName";
            this.dataGridViewTextBoxColumn1.HeaderText = "RalationName";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // RelatedEntityID
            // 
            this.RelatedEntityID.DataPropertyName = "RelatedEntityID";
            this.RelatedEntityID.HeaderText = "RelatedEntityID";
            this.RelatedEntityID.MinimumWidth = 8;
            this.RelatedEntityID.Name = "RelatedEntityID";
            this.RelatedEntityID.ReadOnly = true;
            this.RelatedEntityID.Width = 150;
            // 
            // RelatedEntityColumnID
            // 
            this.RelatedEntityColumnID.DataPropertyName = "RelatedEntityColumnID";
            this.RelatedEntityColumnID.HeaderText = "RelatedEntityColumnID";
            this.RelatedEntityColumnID.MinimumWidth = 8;
            this.RelatedEntityColumnID.Name = "RelatedEntityColumnID";
            this.RelatedEntityColumnID.ReadOnly = true;
            this.RelatedEntityColumnID.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EntityColumnID";
            this.dataGridViewTextBoxColumn4.HeaderText = "EntityColumnID";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 104;
            // 
            // FieldscomboBox
            // 
            this.FieldscomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldscomboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.relationsBindingSource, "EntityColumnID", true));
            this.FieldscomboBox.DataSource = this.fieldsBindingSource;
            this.FieldscomboBox.DisplayMember = "fieldname";
            this.FieldscomboBox.FormattingEnabled = true;
            this.FieldscomboBox.Location = new System.Drawing.Point(89, 69);
            this.FieldscomboBox.Name = "FieldscomboBox";
            this.FieldscomboBox.Size = new System.Drawing.Size(121, 21);
            this.FieldscomboBox.TabIndex = 4;
            this.FieldscomboBox.ValueMember = "fieldname";
            // 
            // fieldsBindingSource
            // 
            this.fieldsBindingSource.DataMember = "Fields";
            this.fieldsBindingSource.DataSource = this.entitiesBindingSource;
            // 
            // ParentEntitycomboBox
            // 
            this.ParentEntitycomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ParentEntitycomboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.relationsBindingSource, "ParentEntityID", true));
            this.ParentEntitycomboBox.DataSource = this.otherentitiesbindingSource;
            this.ParentEntitycomboBox.DisplayMember = "DatasourceEntityName";
            this.ParentEntitycomboBox.FormattingEnabled = true;
            this.ParentEntitycomboBox.Location = new System.Drawing.Point(296, 69);
            this.ParentEntitycomboBox.Name = "ParentEntitycomboBox";
            this.ParentEntitycomboBox.Size = new System.Drawing.Size(121, 21);
            this.ParentEntitycomboBox.TabIndex = 5;
            this.ParentEntitycomboBox.ValueMember = "DatasourceEntityName";
            // 
            // otherentitiesbindingSource
            // 
            this.otherentitiesbindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityStructure);
            // 
            // ParentFieldcomboBox
            // 
            this.ParentFieldcomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ParentFieldcomboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.relationsBindingSource, "ParentEntityColumnID", true));
            this.ParentFieldcomboBox.FormattingEnabled = true;
            this.ParentFieldcomboBox.Location = new System.Drawing.Point(502, 69);
            this.ParentFieldcomboBox.Name = "ParentFieldcomboBox";
            this.ParentFieldcomboBox.Size = new System.Drawing.Size(121, 21);
            this.ParentFieldcomboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Field:";
            // 
            // otherentityfieldsbindingSource
            // 
            this.otherentityfieldsbindingSource.DataMember = "Fields";
            this.otherentityfieldsbindingSource.DataSource = this.otherentitiesbindingSource;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parent Entity:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Parent Field:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.RelationbindingNavigator);
            this.panel1.Controls.Add(this.MainbindingNavigator);
            this.panel1.Controls.Add(this.relationsDataGridView);
            this.panel1.Controls.Add(entityNameLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.entityNameTextBox);
            this.panel1.Controls.Add(this.ParentFieldcomboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ParentEntitycomboBox);
            this.panel1.Controls.Add(this.FieldscomboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 431);
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(234, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select Fields";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 51);
            this.panel2.TabIndex = 11;
            // 
            // MainbindingNavigator
            // 
            this.MainbindingNavigator.AddinName = null;
            this.MainbindingNavigator.BackColor = System.Drawing.Color.White;
            this.MainbindingNavigator.bindingSource = null;
            this.MainbindingNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainbindingNavigator.ButtonBorderSize = 0;
            this.MainbindingNavigator.CausesValidation = false;
            this.MainbindingNavigator.ControlHeight = 30;
            this.MainbindingNavigator.DefaultCreate = false;
            this.MainbindingNavigator.Description = null;
            this.MainbindingNavigator.DllName = null;
            this.MainbindingNavigator.DllPath = null;
            this.MainbindingNavigator.DMEEditor = null;
            this.MainbindingNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainbindingNavigator.EntityName = null;
            this.MainbindingNavigator.EntityStructure = null;
            this.MainbindingNavigator.ErrorObject = null;
            this.MainbindingNavigator.HightlightColor = System.Drawing.Color.Empty;
            this.MainbindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.MainbindingNavigator.Logger = null;
            this.MainbindingNavigator.Name = "MainbindingNavigator";
            this.MainbindingNavigator.NameSpace = null;
            this.MainbindingNavigator.ObjectName = null;
            this.MainbindingNavigator.ObjectType = null;
            this.MainbindingNavigator.ParentName = null;
            this.MainbindingNavigator.Passedarg = null;
            this.MainbindingNavigator.SelectedColor = System.Drawing.Color.Empty;
            this.MainbindingNavigator.Size = new System.Drawing.Size(691, 31);
            this.MainbindingNavigator.TabIndex = 10;
            this.MainbindingNavigator.VerifyDelete = true;
            // 
            // RelationbindingNavigator
            // 
            this.RelationbindingNavigator.AddinName = null;
            this.RelationbindingNavigator.BackColor = System.Drawing.Color.White;
            this.RelationbindingNavigator.bindingSource = null;
            this.RelationbindingNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RelationbindingNavigator.ButtonBorderSize = 0;
            this.RelationbindingNavigator.CausesValidation = false;
            this.RelationbindingNavigator.ControlHeight = 30;
            this.RelationbindingNavigator.DefaultCreate = false;
            this.RelationbindingNavigator.Description = null;
            this.RelationbindingNavigator.DllName = null;
            this.RelationbindingNavigator.DllPath = null;
            this.RelationbindingNavigator.DMEEditor = null;
            this.RelationbindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RelationbindingNavigator.EntityName = null;
            this.RelationbindingNavigator.EntityStructure = null;
            this.RelationbindingNavigator.ErrorObject = null;
            this.RelationbindingNavigator.HightlightColor = System.Drawing.Color.Empty;
            this.RelationbindingNavigator.Location = new System.Drawing.Point(0, 398);
            this.RelationbindingNavigator.Logger = null;
            this.RelationbindingNavigator.Name = "RelationbindingNavigator";
            this.RelationbindingNavigator.NameSpace = null;
            this.RelationbindingNavigator.ObjectName = null;
            this.RelationbindingNavigator.ObjectType = null;
            this.RelationbindingNavigator.ParentName = null;
            this.RelationbindingNavigator.Passedarg = null;
            this.RelationbindingNavigator.SelectedColor = System.Drawing.Color.Empty;
            this.RelationbindingNavigator.Size = new System.Drawing.Size(691, 31);
            this.RelationbindingNavigator.TabIndex = 11;
            this.RelationbindingNavigator.VerifyDelete = true;
            // 
            // uc_linkentitytoanother
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "uc_linkentitytoanother";
            this.Size = new System.Drawing.Size(693, 482);
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherentitiesbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherentityfieldsbindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource entitiesBindingSource;
        private System.Windows.Forms.TextBox entityNameTextBox;
        private System.Windows.Forms.BindingSource relationsBindingSource;
        private System.Windows.Forms.DataGridView relationsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn parententitytextbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBox FieldscomboBox;
        private System.Windows.Forms.BindingSource fieldsBindingSource;
        private System.Windows.Forms.ComboBox ParentEntitycomboBox;
        private System.Windows.Forms.ComboBox ParentFieldcomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource otherentitiesbindingSource;
        private System.Windows.Forms.BindingSource otherentityfieldsbindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedEntityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedEntityColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private uc_bindingNavigator MainbindingNavigator;
        private uc_bindingNavigator RelationbindingNavigator;
    }
}
