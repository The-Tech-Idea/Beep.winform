using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beep.Winform.Controls
{
    public class BeepGrid:DataGridView
    {
        public BeepGrid()
        {
            this.Toppanel = new System.Windows.Forms.Panel();
            this.Titlelabel = new System.Windows.Forms.Label();
            this.Sharebutton = new System.Windows.Forms.Button();
            this.Printbutton = new System.Windows.Forms.Button();
            this.Filterbutton = new System.Windows.Forms.Button();
            this.Bottompanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.Previousbutton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.Newbutton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            // 
            // Toppanel
            // 
            this.Toppanel.Controls.Add(this.Titlelabel);
            this.Toppanel.Controls.Add(this.Sharebutton);
            this.Toppanel.Controls.Add(this.Printbutton);
            this.Toppanel.Controls.Add(this.Filterbutton);
            this.Toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toppanel.Location = new System.Drawing.Point(0, 0);
            this.Toppanel.Name = "Toppanel";
            this.Toppanel.Size = new System.Drawing.Size(380, 22);
            this.Toppanel.TabIndex = 0;
            // 
            // Titlelabel
            // 
            this.Titlelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titlelabel.Location = new System.Drawing.Point(3, 1);
            this.Titlelabel.Name = "Titlelabel";
            this.Titlelabel.Size = new System.Drawing.Size(285, 20);
            this.Titlelabel.TabIndex = 9;
            this.Titlelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sharebutton
            // 
            this.Sharebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sharebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Sharebutton.Location = new System.Drawing.Point(308, 1);
            this.Sharebutton.Name = "Sharebutton";
            this.Sharebutton.Size = new System.Drawing.Size(20, 20);
            this.Sharebutton.TabIndex = 2;
            this.Sharebutton.UseVisualStyleBackColor = true;
            // 
            // Printbutton
            // 
            this.Printbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Printbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Printbutton.Location = new System.Drawing.Point(333, 1);
            this.Printbutton.Name = "Printbutton";
            this.Printbutton.Size = new System.Drawing.Size(20, 20);
            this.Printbutton.TabIndex = 1;
            this.Printbutton.UseVisualStyleBackColor = true;
            // 
            // Filterbutton
            // 
            this.Filterbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filterbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Filterbutton.Location = new System.Drawing.Point(357, 1);
            this.Filterbutton.Name = "Filterbutton";
            this.Filterbutton.Size = new System.Drawing.Size(20, 20);
            this.Filterbutton.TabIndex = 0;
            this.Filterbutton.UseVisualStyleBackColor = true;
            // 
            // Bottompanel
            // 
            this.Bottompanel.Controls.Add(this.SaveButton);
            this.Bottompanel.Controls.Add(this.MessageLabel);
            this.Bottompanel.Controls.Add(this.Cancelbutton);
            this.Bottompanel.Controls.Add(this.Deletebutton);
            this.Bottompanel.Controls.Add(this.Previousbutton);
            this.Bottompanel.Controls.Add(this.NextButton);
            this.Bottompanel.Controls.Add(this.Newbutton);
            this.Bottompanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottompanel.Location = new System.Drawing.Point(0, 326);
            this.Bottompanel.Name = "Bottompanel";
            this.Bottompanel.Size = new System.Drawing.Size(380, 20);
            this.Bottompanel.TabIndex = 1;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageLabel.Location = new System.Drawing.Point(86, 2);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(171, 20);
            this.MessageLabel.TabIndex = 8;
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cancelbutton.Location = new System.Drawing.Point(333, 1);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(20, 20);
            this.Cancelbutton.TabIndex = 7;
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // Deletebutton
            // 
            this.Deletebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Deletebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Deletebutton.Location = new System.Drawing.Point(308, 1);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(20, 20);
            this.Deletebutton.TabIndex = 6;
            this.Deletebutton.UseVisualStyleBackColor = true;
            // 
            // Previousbutton
            // 
            this.Previousbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Previousbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Previousbutton.Location = new System.Drawing.Point(5, 0);
            this.Previousbutton.Name = "Previousbutton";
            this.Previousbutton.Size = new System.Drawing.Size(20, 20);
            this.Previousbutton.TabIndex = 5;
            this.Previousbutton.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NextButton.Location = new System.Drawing.Point(30, 0);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(20, 20);
            this.NextButton.TabIndex = 4;
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // Newbutton
            // 
            this.Newbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Newbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Newbutton.Location = new System.Drawing.Point(54, 0);
            this.Newbutton.Name = "Newbutton";
            this.Newbutton.Size = new System.Drawing.Size(20, 20);
            this.Newbutton.TabIndex = 3;
            this.Newbutton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveButton.Location = new System.Drawing.Point(357, 1);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(20, 20);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.UseVisualStyleBackColor = true;

            this.Controls.Add(this.Bottompanel);
            this.Controls.Add(this.Toppanel);
            Bottompanel.SendToBack();
            Toppanel.SendToBack();

        }
        public event EventHandler<BindingSource> CallPrinter;
        public event EventHandler<BindingSource> SendMessage;
        public event EventHandler<BindingSource> ShowSearch;
        public event EventHandler<BindingSource> NewRecordCreated;
        public event EventHandler<BindingSource> SaveCalled;
        public event EventHandler<BindingSource> DeleteCalled;

        public System.Windows.Forms.Panel Toppanel;
        public System.Windows.Forms.Panel Bottompanel;
        public System.Windows.Forms.Button Filterbutton;
        public System.Windows.Forms.Button Printbutton;
        public System.Windows.Forms.Button Sharebutton;
        public System.Windows.Forms.Button Cancelbutton;
        public System.Windows.Forms.Button Deletebutton;
        public System.Windows.Forms.Button Previousbutton;
        public System.Windows.Forms.Button NextButton;
        public System.Windows.Forms.Button Newbutton;
        public System.Windows.Forms.Label MessageLabel;
        public System.Windows.Forms.Label Titlelabel;
        public System.Windows.Forms.Button SaveButton;
    }
}
