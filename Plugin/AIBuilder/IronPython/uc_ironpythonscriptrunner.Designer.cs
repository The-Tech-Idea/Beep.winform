
namespace AIBuilder.IronPython
{
    partial class uc_ironpythonscriptrunner
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RunonIronScriptbutton = new System.Windows.Forms.Button();
            this.SaveFilebutton = new System.Windows.Forms.Button();
            this.LoadFilebutton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.process1 = new System.Diagnostics.Process();
            this.OutputtextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scripttextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RunonCpythonbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.RunonCpythonbutton);
            this.panel1.Controls.Add(this.RunonIronScriptbutton);
            this.panel1.Controls.Add(this.SaveFilebutton);
            this.panel1.Controls.Add(this.LoadFilebutton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 649);
            this.panel1.TabIndex = 1;
            // 
            // RunonIronScriptbutton
            // 
            this.RunonIronScriptbutton.Location = new System.Drawing.Point(2, 152);
            this.RunonIronScriptbutton.Name = "RunonIronScriptbutton";
            this.RunonIronScriptbutton.Size = new System.Drawing.Size(191, 23);
            this.RunonIronScriptbutton.TabIndex = 2;
            this.RunonIronScriptbutton.Text = "Run pn Iron Python";
            this.RunonIronScriptbutton.UseVisualStyleBackColor = true;
            // 
            // SaveFilebutton
            // 
            this.SaveFilebutton.Location = new System.Drawing.Point(2, 123);
            this.SaveFilebutton.Name = "SaveFilebutton";
            this.SaveFilebutton.Size = new System.Drawing.Size(191, 23);
            this.SaveFilebutton.TabIndex = 1;
            this.SaveFilebutton.Text = "Save File";
            this.SaveFilebutton.UseVisualStyleBackColor = true;
            // 
            // LoadFilebutton
            // 
            this.LoadFilebutton.Location = new System.Drawing.Point(2, 94);
            this.LoadFilebutton.Name = "LoadFilebutton";
            this.LoadFilebutton.Size = new System.Drawing.Size(191, 23);
            this.LoadFilebutton.TabIndex = 0;
            this.LoadFilebutton.Text = "Load File";
            this.LoadFilebutton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // process1
            // 
            this.process1.EnableRaisingEvents = true;
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.ErrorDialog = true;
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // OutputtextBox
            // 
            this.OutputtextBox.AcceptsReturn = true;
            this.OutputtextBox.AcceptsTab = true;
            this.OutputtextBox.BackColor = System.Drawing.Color.Black;
            this.OutputtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputtextBox.ForeColor = System.Drawing.Color.White;
            this.OutputtextBox.Location = new System.Drawing.Point(0, 0);
            this.OutputtextBox.Multiline = true;
            this.OutputtextBox.Name = "OutputtextBox";
            this.OutputtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputtextBox.Size = new System.Drawing.Size(1007, 194);
            this.OutputtextBox.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(195, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scripttextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputtextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1009, 649);
            this.splitContainer1.SplitterDistance = 449;
            this.splitContainer1.TabIndex = 2;
            // 
            // scripttextBox
            // 
            this.scripttextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scripttextBox.Location = new System.Drawing.Point(0, 43);
            this.scripttextBox.Name = "scripttextBox";
            this.scripttextBox.Size = new System.Drawing.Size(1007, 404);
            this.scripttextBox.TabIndex = 2;
            this.scripttextBox.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1007, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iron Python Engine";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunonCpythonbutton
            // 
            this.RunonCpythonbutton.Location = new System.Drawing.Point(2, 181);
            this.RunonCpythonbutton.Name = "RunonCpythonbutton";
            this.RunonCpythonbutton.Size = new System.Drawing.Size(191, 23);
            this.RunonCpythonbutton.TabIndex = 3;
            this.RunonCpythonbutton.Text = "Run on CPython";
            this.RunonCpythonbutton.UseVisualStyleBackColor = true;
            this.RunonCpythonbutton.Visible = false;
            // 
            // pictureBox1
            // 
          //  this.pictureBox1.Image = global::AIBuilder.Properties.Resources.python_96px2;
            this.pictureBox1.Location = new System.Drawing.Point(27, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // uc_ironpythonscriptrunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "uc_ironpythonscriptrunner";
            this.Size = new System.Drawing.Size(1204, 649);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveFilebutton;
        private System.Windows.Forms.Button LoadFilebutton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Diagnostics.Process process1;
        public System.Windows.Forms.TextBox OutputtextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RunonIronScriptbutton;
        private System.Windows.Forms.RichTextBox scripttextBox;
        private System.Windows.Forms.Button RunonCpythonbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
