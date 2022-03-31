using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beep.Winform.Controls
{
    public partial class BeepForm : Form
    {
        public BeepForm()
        {
            InitializeComponent();
            Loadimages();
            this.FormClosing += BeepForm_FormClosing;
        }
        public event EventHandler<FormClosingEventArgs> PreClose;
        private void BeepForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
           PreClose?.Invoke(this, e);   
           
        }

        // private string _title;
        private ResourceManager resourceManager = new ResourceManager();
        public bool AddControl( UserControl control, string title)
        {
           
            if (control != null)
            {
                Title = title;
               // this.Text = title;
                control.Left = 0;
                control.Top = 0;
                int rem = Insidepanel.Height - control.Height;
                if (rem < 0)
                {
                    this.Height = this.Height + Math.Abs(rem);
                }
                else
                {

                    this.Height = control.Height;// + TopPanel.Height ;
                }
                this.Width = control.Width;
                Insidepanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;


                // this.FormBorderStyle = FormBorderStyle.None;
                //  this.ControlBox = false;
                Loadimages();
                //  this.Closebutton.Click += Closebutton_Click;

                return true;
            }
            return false;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string Title { get { return this.Text; } set { this.Text = value; } }


        #region "Resource Loaders"
        private void Loadimages()
        {
            //   this.Maxibutton.BackgroundImage = GetImage("maximize.png");
            //  this.Closebutton.BackgroundImage = GetImage("close.png");
            // this.Minbutton.BackgroundImage = GetImage("minimize.png");
            //this.LogoPictureBox.Image = GetImage("SimpleInfoApps.png");
            this.Icon = resourceManager.GetIcon("Beep.Winform.Controls.gfx.","logo.ico");
            //this.NextpictureBox.Image = GetImage("right.png");
            //this.PreviouspictureBox.Image = GetImage("left.png");
            //this.RemovepictureBox.Image = GetImage("remove.png");
            //this.RollbackpictureBox.Image = GetImage("back.png");
            //this.EditpictureBox.Image = GetImage("edit.png");
            //this.FindpictureBox.Image = GetImage("search.png");
            //this.MessegepictureBox.Image = GetImage("messages.png");
            //this.PrinterpictureBox.Image = GetImage("printer.png");
        }
        
        #endregion
    }
}
