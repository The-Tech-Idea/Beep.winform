using BeepEnterprize.Vis.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Util;

namespace Beep.Winform.Controls
{
    public partial class BeepWait : Form,IWaitForm
    {
       
        public BeepWait()
        {
            InitializeComponent();
            LogopictureBox.Visible= false;

        }

     
        // private ResourceManager resourceManager = new ResourceManager();
        public static void InvokeAction(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
        public void CloseForm()
        {

            System.Threading.Thread.Sleep(2000);
            if (this.IsHandleCreated)
            {
             this.Invoke(new Action(Close));
            }

        }

        public void SetImage(string image)
        {
            Title.Visible= false;
            LogopictureBox.Visible = true;
            LogopictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            LogopictureBox.Image=Image.FromFile(image);
        }

        public void SetText(string text)
        {
            messege.BeginInvoke(new Action(() => {
                messege.AppendText(text + Environment.NewLine);
                messege.SelectionStart = messege.Text.Length;
                messege.ScrollToCaret();
            }));
        }

        public void SetTitle(string title)
        {
            Title.Visible = true;
            LogopictureBox.Visible = false;
            Title.Text = title;
        }

        public void SetTitle(string title, string text)
        {
            throw new NotImplementedException();
        }

        public IErrorsInfo Show(PassedArgs Passedarguments)
        {
            throw new NotImplementedException();
        }

        IErrorsInfo  IWaitForm.Close()
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(Close));
                }
            }
            catch (Exception)
            {

               
            }
            return null;
          
        }
    }
}
