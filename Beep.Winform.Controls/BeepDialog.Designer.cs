namespace Beep.Winform.Controls
{
    partial class BeepDialog
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LogopictureBox = new System.Windows.Forms.PictureBox();
            this.TitleLable = new System.Windows.Forms.Label();
            this.Bottompanel = new System.Windows.Forms.Panel();
            this.Yesbutton = new System.Windows.Forms.Button();
            this.Nobutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.Bottomlabel = new System.Windows.Forms.Label();
            this.Insidepanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            this.Bottompanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.LogopictureBox);
            this.TopPanel.Controls.Add(this.TitleLable);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(477, 46);
            this.TopPanel.TabIndex = 1;
            // 
            // LogopictureBox
            // 
            this.LogopictureBox.BackColor = System.Drawing.Color.White;
            this.LogopictureBox.Location = new System.Drawing.Point(11, 7);
            this.LogopictureBox.Name = "LogopictureBox";
            this.LogopictureBox.Size = new System.Drawing.Size(49, 30);
            this.LogopictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogopictureBox.TabIndex = 1;
            this.LogopictureBox.TabStop = false;
            // 
            // TitleLable
            // 
            this.TitleLable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLable.AutoSize = true;
            this.TitleLable.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLable.ForeColor = System.Drawing.Color.Gold;
            this.TitleLable.Location = new System.Drawing.Point(215, 11);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Size = new System.Drawing.Size(0, 26);
            this.TitleLable.TabIndex = 0;
            // 
            // Bottompanel
            // 
            this.Bottompanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Bottompanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bottompanel.Controls.Add(this.Yesbutton);
            this.Bottompanel.Controls.Add(this.Nobutton);
            this.Bottompanel.Controls.Add(this.Cancelbutton);
            this.Bottompanel.Controls.Add(this.Bottomlabel);
            this.Bottompanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottompanel.Location = new System.Drawing.Point(0, 187);
            this.Bottompanel.Name = "Bottompanel";
            this.Bottompanel.Size = new System.Drawing.Size(477, 46);
            this.Bottompanel.TabIndex = 2;
            // 
            // Yesbutton
            // 
            this.Yesbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Yesbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Yesbutton.FlatAppearance.BorderSize = 0;
            this.Yesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yesbutton.ForeColor = System.Drawing.Color.White;
            this.Yesbutton.Location = new System.Drawing.Point(11, 5);
            this.Yesbutton.Name = "Yesbutton";
            this.Yesbutton.Size = new System.Drawing.Size(26, 30);
            this.Yesbutton.TabIndex = 3;
            this.Yesbutton.Text = " ";
            this.Yesbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Yesbutton.UseCompatibleTextRendering = true;
            this.Yesbutton.UseVisualStyleBackColor = true;
            // 
            // Nobutton
            // 
            this.Nobutton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Nobutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Nobutton.FlatAppearance.BorderSize = 0;
            this.Nobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nobutton.ForeColor = System.Drawing.Color.White;
            this.Nobutton.Location = new System.Drawing.Point(438, 5);
            this.Nobutton.Name = "Nobutton";
            this.Nobutton.Size = new System.Drawing.Size(26, 30);
            this.Nobutton.TabIndex = 2;
            this.Nobutton.Text = " ";
            this.Nobutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Nobutton.UseCompatibleTextRendering = true;
            this.Nobutton.UseVisualStyleBackColor = true;
            this.Nobutton.Visible = false;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Cancelbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.FlatAppearance.BorderSize = 0;
            this.Cancelbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbutton.ForeColor = System.Drawing.Color.White;
            this.Cancelbutton.Location = new System.Drawing.Point(220, 5);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(26, 30);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = " ";
            this.Cancelbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cancelbutton.UseCompatibleTextRendering = true;
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // Bottomlabel
            // 
            this.Bottomlabel.AutoSize = true;
            this.Bottomlabel.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bottomlabel.ForeColor = System.Drawing.Color.White;
            this.Bottomlabel.Location = new System.Drawing.Point(26, 9);
            this.Bottomlabel.Name = "Bottomlabel";
            this.Bottomlabel.Size = new System.Drawing.Size(0, 26);
            this.Bottomlabel.TabIndex = 0;
            // 
            // Insidepanel
            // 
            this.Insidepanel.BackColor = System.Drawing.Color.White;
            this.Insidepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Insidepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Insidepanel.Location = new System.Drawing.Point(0, 46);
            this.Insidepanel.Name = "Insidepanel";
            this.Insidepanel.Size = new System.Drawing.Size(477, 141);
            this.Insidepanel.TabIndex = 3;
            // 
            // BeepDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(477, 233);
            this.ControlBox = false;
            this.Controls.Add(this.Insidepanel);
            this.Controls.Add(this.Bottompanel);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BeepDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BeepDialog";
            this.TopMost = true;
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            this.Bottompanel.ResumeLayout(false);
            this.Bottompanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        public System.Windows.Forms.Label TitleLable;
        private System.Windows.Forms.Panel Bottompanel;
        private System.Windows.Forms.Button Yesbutton;
        private System.Windows.Forms.Button Nobutton;
        private System.Windows.Forms.Button Cancelbutton;
        public System.Windows.Forms.Label Bottomlabel;
        public System.Windows.Forms.Panel Insidepanel;
        private System.Windows.Forms.PictureBox LogopictureBox;
    }
}