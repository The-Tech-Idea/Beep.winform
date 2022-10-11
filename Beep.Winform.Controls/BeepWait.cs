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

namespace Beep.Winform.Controls
{
    public partial class BeepWait : Form
    {
       
        public BeepWait()
        {
            InitializeComponent();
          

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
        
    }
}
