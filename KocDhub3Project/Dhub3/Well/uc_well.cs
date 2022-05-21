using Beep.Winform.Controls;
using BeepEnterprize.Vis.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace Dhub3.Well
{
    public partial class uc_well : uc_BaseControl
    {
        public uc_well()
        {
            InitializeComponent();
            TitleLabel.Text = "Well Module";
        }
        public override  void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
           base.SetConfig(pbl, plogger, putil, args, e, per);
          
        }
    }
}
