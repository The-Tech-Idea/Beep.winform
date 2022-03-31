
using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis
{
    partial class uc_datasourceDefaults
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
            this.datasourceDefaults1DataGridView = new System.Windows.Forms.DataGridView();
            this.datasourceDefaultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ValueTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypedataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datasourceDefaults1DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasourceDefaultsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // datasourceDefaults1DataGridView
            // 
            this.datasourceDefaults1DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datasourceDefaults1DataGridView.AutoGenerateColumns = false;
            this.datasourceDefaults1DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datasourceDefaults1DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.RuleComboBox,
            this.ValueTextBox,
            this.TypedataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.datasourceDefaults1DataGridView.DataSource = this.datasourceDefaultsBindingSource;
            this.datasourceDefaults1DataGridView.Location = new System.Drawing.Point(3, 3);
            this.datasourceDefaults1DataGridView.Name = "datasourceDefaults1DataGridView";
            this.datasourceDefaults1DataGridView.Size = new System.Drawing.Size(697, 688);
            this.datasourceDefaults1DataGridView.TabIndex = 1;
            // 
            // datasourceDefaultsBindingSource
            // 
            this.datasourceDefaultsBindingSource.DataSource = typeof(TheTechIdea.Util.DefaultValue);
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(3, 691);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(697, 31);
            this.uc_bindingNavigator1.TabIndex = 2;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "propertyName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Property Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // RuleComboBox
            // 
            this.RuleComboBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RuleComboBox.DataPropertyName = "Rule";
            this.RuleComboBox.HeaderText = "Rule";
            this.RuleComboBox.Name = "RuleComboBox";
            this.RuleComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RuleComboBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RuleComboBox.Width = 54;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.DataPropertyName = "propoertValue";
            this.ValueTextBox.HeaderText = "Static Default Value";
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TypedataGridViewTextBoxColumn3
            // 
            this.TypedataGridViewTextBoxColumn3.DataPropertyName = "propertyType";
            this.TypedataGridViewTextBoxColumn3.HeaderText = "Type";
            this.TypedataGridViewTextBoxColumn3.Name = "TypedataGridViewTextBoxColumn3";
            this.TypedataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TypedataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "propertyCategory";
            this.dataGridViewTextBoxColumn4.HeaderText = "Category";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // uc_datasourceDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.datasourceDefaults1DataGridView);
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Name = "uc_datasourceDefaults";
            this.Size = new System.Drawing.Size(703, 727);
            ((System.ComponentModel.ISupportInitialize)(this.datasourceDefaults1DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasourceDefaultsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource datasourceDefaultsBindingSource;
        private System.Windows.Forms.DataGridView datasourceDefaults1DataGridView;
        private uc_bindingNavigator uc_bindingNavigator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn RuleComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueTextBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypedataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
