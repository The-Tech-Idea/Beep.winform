using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private ResourceManager resourceManager = new ResourceManager();
       
        public void CloseForm()
        {

            System.Threading.Thread.Sleep(1000);
            if (this.IsHandleCreated)
            {
                Close();
            }

        }
        
    }
}
