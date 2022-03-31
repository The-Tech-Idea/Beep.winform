namespace Beep.Winform.Controls
{
    partial class BeepForm
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
            this.FramePanel = new System.Windows.Forms.Panel();
            this.Insidepanel = new System.Windows.Forms.Panel();
            this.FramePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FramePanel
            // 
            this.FramePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FramePanel.Controls.Add(this.Insidepanel);
            this.FramePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FramePanel.Location = new System.Drawing.Point(0, 0);
            this.FramePanel.Name = "FramePanel";
            this.FramePanel.Size = new System.Drawing.Size(872, 608);
            this.FramePanel.TabIndex = 1;
            // 
            // Insidepanel
            // 
            this.Insidepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Insidepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Insidepanel.Location = new System.Drawing.Point(0, 0);
            this.Insidepanel.Name = "Insidepanel";
            this.Insidepanel.Size = new System.Drawing.Size(870, 606);
            this.Insidepanel.TabIndex = 0;
            // 
            // BeepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 608);
            this.Controls.Add(this.FramePanel);
            this.Name = "BeepForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BeepForm";
            this.FramePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel FramePanel;
        public System.Windows.Forms.Panel Insidepanel;
    }
}