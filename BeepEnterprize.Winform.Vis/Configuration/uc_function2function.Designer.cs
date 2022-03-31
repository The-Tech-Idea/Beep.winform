
using Beep.Winform.Controls;

namespace BeepEnterprize.Winform.Vis
{
    partial class uc_function2function
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
            System.Windows.Forms.Label fromClassLabel;
            System.Windows.Forms.Label fromMethodLabel;
            System.Windows.Forms.Label toClassLabel;
            System.Windows.Forms.Label toMethodLabel;
            System.Windows.Forms.Label eventLabel;
            System.Windows.Forms.Label actionTypeLabel;
            this.function2FunctionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.function2FunctionsDataGridView = new System.Windows.Forms.DataGridView();
            this.FromClassdataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromMethoddataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToClassdataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToMethoddataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromClassComboBox = new System.Windows.Forms.ComboBox();
            this.fromMethodComboBox = new System.Windows.Forms.ComboBox();
            this.toClassComboBox = new System.Windows.Forms.ComboBox();
            this.toMethodComboBox = new System.Windows.Forms.ComboBox();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.actionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uc_bindingNavigator1 = new Beep.Winform.Controls.uc_bindingNavigator();
            fromClassLabel = new System.Windows.Forms.Label();
            fromMethodLabel = new System.Windows.Forms.Label();
            toClassLabel = new System.Windows.Forms.Label();
            toMethodLabel = new System.Windows.Forms.Label();
            eventLabel = new System.Windows.Forms.Label();
            actionTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.function2FunctionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.function2FunctionsDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromClassLabel
            // 
            fromClassLabel.AutoSize = true;
            fromClassLabel.Location = new System.Drawing.Point(12, 19);
            fromClassLabel.Name = "fromClassLabel";
            fromClassLabel.Size = new System.Drawing.Size(61, 13);
            fromClassLabel.TabIndex = 2;
            fromClassLabel.Text = "From Class:";
            // 
            // fromMethodLabel
            // 
            fromMethodLabel.AutoSize = true;
            fromMethodLabel.Location = new System.Drawing.Point(418, 19);
            fromMethodLabel.Name = "fromMethodLabel";
            fromMethodLabel.Size = new System.Drawing.Size(72, 13);
            fromMethodLabel.TabIndex = 4;
            fromMethodLabel.Text = "From Method:";
            // 
            // toClassLabel
            // 
            toClassLabel.AutoSize = true;
            toClassLabel.Location = new System.Drawing.Point(14, 17);
            toClassLabel.Name = "toClassLabel";
            toClassLabel.Size = new System.Drawing.Size(51, 13);
            toClassLabel.TabIndex = 6;
            toClassLabel.Text = "To Class:";
            // 
            // toMethodLabel
            // 
            toMethodLabel.AutoSize = true;
            toMethodLabel.Location = new System.Drawing.Point(219, 19);
            toMethodLabel.Name = "toMethodLabel";
            toMethodLabel.Size = new System.Drawing.Size(62, 13);
            toMethodLabel.TabIndex = 8;
            toMethodLabel.Text = "To Method:";
            // 
            // eventLabel
            // 
            eventLabel.AutoSize = true;
            eventLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            eventLabel.Location = new System.Drawing.Point(638, 19);
            eventLabel.Name = "eventLabel";
            eventLabel.Size = new System.Drawing.Size(64, 13);
            eventLabel.TabIndex = 10;
            eventLabel.Text = "From Event:";
            // 
            // actionTypeLabel
            // 
            actionTypeLabel.AutoSize = true;
            actionTypeLabel.Location = new System.Drawing.Point(218, 19);
            actionTypeLabel.Name = "actionTypeLabel";
            actionTypeLabel.Size = new System.Drawing.Size(67, 13);
            actionTypeLabel.TabIndex = 11;
            actionTypeLabel.Text = "Action Type:";
            // 
            // function2FunctionsBindingSource
            // 
            this.function2FunctionsBindingSource.DataSource = typeof(TheTechIdea.Util.Function2FunctionAction);
            // 
            // function2FunctionsDataGridView
            // 
            this.function2FunctionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.function2FunctionsDataGridView.AutoGenerateColumns = false;
            this.function2FunctionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.function2FunctionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FromClassdataGridViewTextBoxColumn1,
            this.ActionType,
            this.Event,
            this.FromMethoddataGridViewTextBoxColumn2,
            this.ToClassdataGridViewTextBoxColumn3,
            this.ToMethoddataGridViewTextBoxColumn4});
            this.function2FunctionsDataGridView.DataSource = this.function2FunctionsBindingSource;
            this.function2FunctionsDataGridView.Location = new System.Drawing.Point(3, 131);
            this.function2FunctionsDataGridView.Name = "function2FunctionsDataGridView";
            this.function2FunctionsDataGridView.Size = new System.Drawing.Size(846, 471);
            this.function2FunctionsDataGridView.TabIndex = 0;
            // 
            // FromClassdataGridViewTextBoxColumn1
            // 
            this.FromClassdataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FromClassdataGridViewTextBoxColumn1.DataPropertyName = "FromClass";
            this.FromClassdataGridViewTextBoxColumn1.HeaderText = "From Class";
            this.FromClassdataGridViewTextBoxColumn1.Name = "FromClassdataGridViewTextBoxColumn1";
            this.FromClassdataGridViewTextBoxColumn1.ReadOnly = true;
            this.FromClassdataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ActionType
            // 
            this.ActionType.DataPropertyName = "ActionType";
            this.ActionType.HeaderText = "Action Type";
            this.ActionType.Name = "ActionType";
            this.ActionType.ReadOnly = true;
            // 
            // Event
            // 
            this.Event.DataPropertyName = "Event";
            this.Event.HeaderText = "From Event";
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            // 
            // FromMethoddataGridViewTextBoxColumn2
            // 
            this.FromMethoddataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FromMethoddataGridViewTextBoxColumn2.DataPropertyName = "FromMethod";
            this.FromMethoddataGridViewTextBoxColumn2.HeaderText = "From Method";
            this.FromMethoddataGridViewTextBoxColumn2.Name = "FromMethoddataGridViewTextBoxColumn2";
            this.FromMethoddataGridViewTextBoxColumn2.ReadOnly = true;
            this.FromMethoddataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ToClassdataGridViewTextBoxColumn3
            // 
            this.ToClassdataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToClassdataGridViewTextBoxColumn3.DataPropertyName = "ToClass";
            this.ToClassdataGridViewTextBoxColumn3.HeaderText = "To Class";
            this.ToClassdataGridViewTextBoxColumn3.Name = "ToClassdataGridViewTextBoxColumn3";
            this.ToClassdataGridViewTextBoxColumn3.ReadOnly = true;
            this.ToClassdataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ToMethoddataGridViewTextBoxColumn4
            // 
            this.ToMethoddataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToMethoddataGridViewTextBoxColumn4.DataPropertyName = "ToMethod";
            this.ToMethoddataGridViewTextBoxColumn4.HeaderText = "To Method";
            this.ToMethoddataGridViewTextBoxColumn4.Name = "ToMethoddataGridViewTextBoxColumn4";
            this.ToMethoddataGridViewTextBoxColumn4.ReadOnly = true;
            this.ToMethoddataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fromClassComboBox
            // 
            this.fromClassComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.function2FunctionsBindingSource, "FromClass", true));
            this.fromClassComboBox.FormattingEnabled = true;
            this.fromClassComboBox.Location = new System.Drawing.Point(79, 15);
            this.fromClassComboBox.Name = "fromClassComboBox";
            this.fromClassComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromClassComboBox.TabIndex = 0;
            // 
            // fromMethodComboBox
            // 
            this.fromMethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.function2FunctionsBindingSource, "FromMethod", true));
            this.fromMethodComboBox.FormattingEnabled = true;
            this.fromMethodComboBox.Location = new System.Drawing.Point(496, 15);
            this.fromMethodComboBox.Name = "fromMethodComboBox";
            this.fromMethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromMethodComboBox.TabIndex = 2;
            // 
            // toClassComboBox
            // 
            this.toClassComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.function2FunctionsBindingSource, "ToClass", true));
            this.toClassComboBox.FormattingEnabled = true;
            this.toClassComboBox.Location = new System.Drawing.Point(71, 14);
            this.toClassComboBox.Name = "toClassComboBox";
            this.toClassComboBox.Size = new System.Drawing.Size(121, 21);
            this.toClassComboBox.TabIndex = 0;
            // 
            // toMethodComboBox
            // 
            this.toMethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.function2FunctionsBindingSource, "ToMethod", true));
            this.toMethodComboBox.FormattingEnabled = true;
            this.toMethodComboBox.Location = new System.Drawing.Point(287, 16);
            this.toMethodComboBox.Name = "toMethodComboBox";
            this.toMethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.toMethodComboBox.TabIndex = 1;
            // 
            // eventComboBox
            // 
            this.eventComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.function2FunctionsBindingSource, "Event", true));
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(708, 15);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(121, 21);
            this.eventComboBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(actionTypeLabel);
            this.panel1.Controls.Add(this.fromMethodComboBox);
            this.panel1.Controls.Add(eventLabel);
            this.panel1.Controls.Add(this.actionTypeComboBox);
            this.panel1.Controls.Add(this.fromClassComboBox);
            this.panel1.Controls.Add(this.eventComboBox);
            this.panel1.Controls.Add(fromClassLabel);
            this.panel1.Controls.Add(fromMethodLabel);
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 52);
            this.panel1.TabIndex = 12;
            // 
            // actionTypeComboBox
            // 
            this.actionTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.function2FunctionsBindingSource, "ActionType", true));
            this.actionTypeComboBox.FormattingEnabled = true;
            this.actionTypeComboBox.Location = new System.Drawing.Point(291, 15);
            this.actionTypeComboBox.Name = "actionTypeComboBox";
            this.actionTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.actionTypeComboBox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.toMethodComboBox);
            this.panel2.Controls.Add(this.toClassComboBox);
            this.panel2.Controls.Add(toClassLabel);
            this.panel2.Controls.Add(toMethodLabel);
            this.panel2.Location = new System.Drawing.Point(171, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(423, 52);
            this.panel2.TabIndex = 13;
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
            this.uc_bindingNavigator1.Location = new System.Drawing.Point(3, 602);
            this.uc_bindingNavigator1.Logger = null;
            this.uc_bindingNavigator1.Name = "uc_bindingNavigator1";
            this.uc_bindingNavigator1.NameSpace = null;
            this.uc_bindingNavigator1.ObjectName = null;
            this.uc_bindingNavigator1.ObjectType = null;
            this.uc_bindingNavigator1.ParentName = null;
            this.uc_bindingNavigator1.Passedarg = null;
            this.uc_bindingNavigator1.SelectedColor = System.Drawing.Color.Green;
            this.uc_bindingNavigator1.Size = new System.Drawing.Size(846, 31);
            this.uc_bindingNavigator1.TabIndex = 14;
            this.uc_bindingNavigator1.VerifyDelete = true;
            // 
            // uc_function2function
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_bindingNavigator1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.function2FunctionsDataGridView);
            this.Name = "uc_function2function";
            this.Size = new System.Drawing.Size(852, 641);
            ((System.ComponentModel.ISupportInitialize)(this.function2FunctionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.function2FunctionsDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource function2FunctionsBindingSource;
        private System.Windows.Forms.DataGridView function2FunctionsDataGridView;
        private System.Windows.Forms.ComboBox fromClassComboBox;
        private System.Windows.Forms.ComboBox fromMethodComboBox;
        private System.Windows.Forms.ComboBox toClassComboBox;
        private System.Windows.Forms.ComboBox toMethodComboBox;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox actionTypeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromClassdataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromMethoddataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToClassdataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToMethoddataGridViewTextBoxColumn4;
        private uc_bindingNavigator uc_bindingNavigator1;
    }
}
