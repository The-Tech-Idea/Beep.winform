namespace Beep.Winform.Controls
{
    partial class uc_lovControl
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
            this.ShowLovbutton = new System.Windows.Forms.Button();
            this.ValuetextBox = new System.Windows.Forms.TextBox();
            this.DisplaytextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ShowLovbutton
            // 
            this.ShowLovbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShowLovbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ShowLovbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowLovbutton.Location = new System.Drawing.Point(2, 1);
            this.ShowLovbutton.Name = "ShowLovbutton";
            this.ShowLovbutton.Size = new System.Drawing.Size(20, 20);
            this.ShowLovbutton.TabIndex = 0;
            this.ShowLovbutton.UseVisualStyleBackColor = true;
            // 
            // ValuetextBox
            // 
            this.ValuetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValuetextBox.Location = new System.Drawing.Point(25, 1);
            this.ValuetextBox.Name = "ValuetextBox";
            this.ValuetextBox.Size = new System.Drawing.Size(100, 20);
            this.ValuetextBox.TabIndex = 1;
            // 
            // DisplaytextBox
            // 
            this.DisplaytextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplaytextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplaytextBox.Location = new System.Drawing.Point(128, 1);
            this.DisplaytextBox.Name = "DisplaytextBox";
            this.DisplaytextBox.ReadOnly = true;
            this.DisplaytextBox.Size = new System.Drawing.Size(266, 20);
            this.DisplaytextBox.TabIndex = 2;
            // 
            // uc_lovControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.DisplaytextBox);
            this.Controls.Add(this.ValuetextBox);
            this.Controls.Add(this.ShowLovbutton);
            this.Name = "uc_lovControl";
            this.Size = new System.Drawing.Size(397, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowLovbutton;
        private System.Windows.Forms.TextBox ValuetextBox;
        private System.Windows.Forms.TextBox DisplaytextBox;
    }
}
