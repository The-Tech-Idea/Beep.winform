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
    public partial class BeepDialog : Form
    {
        public BeepDialog()
        {
            InitializeComponent();
            Loadimages();
            Yesbutton.Click -= Yesbutton_Click;
            Nobutton.Click -= Nobutton_Click;
            Cancelbutton.Click -= Cancelbutton_Click;
            Yesbutton.Click += Yesbutton_Click;
            Nobutton.Click += Nobutton_Click;
            Cancelbutton.Click += Cancelbutton_Click;
            //Yesbutton.MouseHover -= Yesbutton_MouseHover;
            //Nobutton.MouseHover -= Nobutton_MouseHover;
            //Cancelbutton.MouseHover -= Cancelbutton_MouseHover;

            //Yesbutton.MouseHover += Yesbutton_MouseHover;
            //Nobutton.MouseHover += Nobutton_MouseHover;
            //Cancelbutton.MouseHover += Cancelbutton_MouseHover;
            this.AcceptButton = Yesbutton;
            this.CancelButton = Cancelbutton;

            YestoolTip = new ToolTip();
            NotoolTip = new ToolTip();
            CanceltoolTip = new ToolTip();



    }
        private ToolTip YestoolTip;
        private ToolTip NotoolTip;
        private ToolTip CanceltoolTip;
        MessageBoxButtons Buttons;
        private ResourceManager resourceManager = new ResourceManager();
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            switch (Buttons)
            {
                case MessageBoxButtons.OK:
                    //  this.DialogResult = DialogResult.OK;

                    break;
                case MessageBoxButtons.OKCancel:
                    //   this.DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.DialogResult = DialogResult.Ignore;

                    break;
                case MessageBoxButtons.YesNoCancel:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                    // this.DialogResult = DialogResult.Yes;

                    break;
                case MessageBoxButtons.RetryCancel:
                    this.DialogResult = DialogResult.Cancel;

                    break;
                default:
                    break;
            }

           
          
            this.Close();
        }

        private void Nobutton_Click(object sender, EventArgs e)
        {
            switch (Buttons)
            {
                case MessageBoxButtons.OK:
              //      this.DialogResult = DialogResult.OK;

                    break;
                case MessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.DialogResult = DialogResult.Retry;

                    break;
                case MessageBoxButtons.YesNoCancel:
                    this.DialogResult = DialogResult.No;
                    break;
                case MessageBoxButtons.YesNo:
                    this.DialogResult = DialogResult.No;

                    break;
                case MessageBoxButtons.RetryCancel:
                    this.DialogResult = DialogResult.Cancel;

                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            switch (Buttons)
            {
                case MessageBoxButtons.OK:
                    this.DialogResult = DialogResult.OK;

                    break;
                case MessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.DialogResult = DialogResult.Abort;

                    break;
                case MessageBoxButtons.YesNoCancel:
                    this.DialogResult = DialogResult.Yes;
                    break;
                case MessageBoxButtons.YesNo:
                    this.DialogResult = DialogResult.Yes;

                    break;
                case MessageBoxButtons.RetryCancel:
                    this.DialogResult = DialogResult.Retry;

                    break;
                default:
                    break;
            }

            this.Close();
        }
        public bool AddControl(Control parent,UserControl control, string title, MessageBoxButtons buttons)
        {
            Buttons = buttons;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    YestoolTip.SetToolTip(Yesbutton, "OK");
                    Yesbutton.Visible = true;
                    Nobutton.Visible = false;
                    Cancelbutton.Visible = false;
                    
                    break;
                case MessageBoxButtons.OKCancel:
                    YestoolTip.SetToolTip(Yesbutton, "OK");
                    NotoolTip.SetToolTip(Nobutton, "Cancel");
                    Yesbutton.Visible = true;
                    Nobutton.Visible = true;
                    Cancelbutton.Visible = false;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    YestoolTip.SetToolTip(Yesbutton, "Abort");
                    NotoolTip.SetToolTip(Nobutton, "Retry");
                    CanceltoolTip.SetToolTip(Nobutton, "Ignore");
                    Yesbutton.Visible = true;
                    Nobutton.Visible = true;
                    Cancelbutton.Visible = true;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    YestoolTip.SetToolTip(Yesbutton, "Yes");
                    NotoolTip.SetToolTip(Nobutton, "No");
                    CanceltoolTip.SetToolTip(Nobutton, "Cancel");
                    Yesbutton.Visible = true;
                    Nobutton.Visible = true;
                    Cancelbutton.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    YestoolTip.SetToolTip(Yesbutton, "Yes");
                    NotoolTip.SetToolTip(Nobutton, "No");
                    Yesbutton.Visible = true;
                    Nobutton.Visible = true;
                    Cancelbutton.Visible = false;
                    break;
                case MessageBoxButtons.RetryCancel:
                    YestoolTip.SetToolTip(Yesbutton, "Retry");
                    NotoolTip.SetToolTip(Nobutton, "Cancel");
                    Yesbutton.Visible = true;
                    Nobutton.Visible = true;
                    Cancelbutton.Visible = false;
                    break;
                default:
                    break;
            }
            if (control != null)
            {
                Title = title;
                TitleLable.Text = title;
                control.Left = 0;
                control.Top = 0;
                int rem = Insidepanel.Height - control.Height;
                if (rem < 0)
                {
                    this.Height = this.Height + Math.Abs(rem);
                }
                else
                {

                    this.Height =  control.Height + TopPanel.Height + Bottompanel.Height;
                }
                this.Width = control.Width;
                Insidepanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;
               
              
               

                return true;
            }
            return false;
        }
        public string Title { get { return TitleLable.Text; } set { TitleLable.Text = value; } }

        #region "Resource Loaders"
        private void Loadimages()
        {
            this.Yesbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx." ,"checked.png");
            this.Nobutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx." ,"stop.png");
            this.Cancelbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx." ,"cancel.png");
          this.LogopictureBox.Image = resourceManager.GetImage("Beep.Winform.Controls.gfx." ,"SimpleInfoApps.png");
        }
     
      
        #endregion
    }
}
