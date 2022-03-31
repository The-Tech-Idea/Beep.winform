
using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis
{
    partial class uc_webapiQueryParameters
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
            this.entitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paramentersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.parameterNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.uc_bindingNavigator2 = new Beep.Winform.Controls.uc_bindingNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramentersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // entitiesBindingSource
            // 
            this.entitiesBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.EntityStructure);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ParentId,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.KeyToken});
            this.dataGridView1.DataSource = this.entitiesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(675, 265);
            this.dataGridView1.TabIndex = 46;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 41;
            // 
            // ParentId
            // 
            this.ParentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ParentId.DataPropertyName = "ParentId";
            this.ParentId.HeaderText = "ParentId";
            this.ParentId.Name = "ParentId";
            this.ParentId.Width = 72;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "EntityName";
            this.dataGridViewTextBoxColumn11.HeaderText = "EntityName";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "StatusDescription";
            this.dataGridViewTextBoxColumn12.HeaderText = "Description";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CustomBuildQuery";
            this.dataGridViewTextBoxColumn13.HeaderText = "Query";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // KeyToken
            // 
            this.KeyToken.DataPropertyName = "KeyToken";
            this.KeyToken.HeaderText = "Key Token";
            this.KeyToken.Name = "KeyToken";
            // 
            // fieldsBindingSource
            // 
            this.fieldsBindingSource.DataMember = "Fields";
            this.fieldsBindingSource.DataSource = this.entitiesBindingSource;
            // 
            // paramentersBindingSource
            // 
            this.paramentersBindingSource.DataMember = "Paramenters";
            this.paramentersBindingSource.DataSource = this.entitiesBindingSource;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterNameDataGridViewTextBoxColumn,
            this.parameterIndexDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.paramentersBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(74, 352);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(539, 248);
            this.dataGridView2.TabIndex = 49;
            // 
            // parameterNameDataGridViewTextBoxColumn
            // 
            this.parameterNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.parameterNameDataGridViewTextBoxColumn.DataPropertyName = "parameterName";
            this.parameterNameDataGridViewTextBoxColumn.HeaderText = "Parameter Name";
            this.parameterNameDataGridViewTextBoxColumn.Name = "parameterNameDataGridViewTextBoxColumn";
            // 
            // parameterIndexDataGridViewTextBoxColumn
            // 
            this.parameterIndexDataGridViewTextBoxColumn.DataPropertyName = "parameterIndex";
            this.parameterIndexDataGridViewTextBoxColumn.HeaderText = "Index";
            this.parameterIndexDataGridViewTextBoxColumn.Name = "parameterIndexDataGridViewTextBoxColumn";
            // 
            // uc_bindingNavigator1
            // 
            this.uc_bindingNavigator1.AddinName = null;
            this.uc_bindingNavigator1.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(3, 299);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(675, 31);
            this.uc_bindingNavigator1.TabIndex = 50;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // uc_bindingNavigator2
            // 
            this.uc_bindingNavigator2.AddinName = null;
            this.uc_bindingNavigator2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uc_bindingNavigator2.BackColor = System.Drawing.Color.White;
            this.uc_bindingNavigator2.bindingSource = null;
            this.uc_bindingNavigator2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_bindingNavigator2.ButtonBorderSize = 0;
            this.uc_bindingNavigator2.CausesValidation = false;
            this.uc_bindingNavigator2.ControlHeight = 30;
            this.uc_bindingNavigator2.DefaultCreate = false;
            this.uc_bindingNavigator2.Description = null;
            this.uc_bindingNavigator2.DllName = null;
            this.uc_bindingNavigator2.DllPath = null;
            this.uc_bindingNavigator2.DMEEditor = null;
            this.uc_bindingNavigator2.EntityName = null;
            this.uc_bindingNavigator2.EntityStructure = null;
            this.uc_bindingNavigator2.ErrorObject = null;
            this.uc_bindingNavigator2.HightlightColor = System.Drawing.Color.Red;
            this.uc_bindingNavigator2.Location = new System.Drawing.Point(74, 600);
            this.uc_bindingNavigator2.Logger = null;
            this.uc_bindingNavigator2.Name = "uc_bindingNavigator2";
            this.uc_bindingNavigator2.NameSpace = null;
            this.uc_bindingNavigator2.ObjectName = null;
            this.uc_bindingNavigator2.ObjectType = null;
            this.uc_bindingNavigator2.ParentName = null;
            this.uc_bindingNavigator2.Passedarg = null;
            this.uc_bindingNavigator2.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator2.Size = new System.Drawing.Size(539, 31);
            this.uc_bindingNavigator2.TabIndex = 51;
            this.uc_bindingNavigator2.VerifyDelete = true;
            // 
            // uc_webapiQueryParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_bindingNavigator2);
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "uc_webapiQueryParameters";
            this.Size = new System.Drawing.Size(693, 657);
            ((System.ComponentModel.ISupportInitialize)(this.entitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramentersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource entitiesBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fieldsBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource paramentersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyToken;
        private uc_bindingNavigator uc_bindingNavigator1;
        private uc_bindingNavigator uc_bindingNavigator2;
    }
}
