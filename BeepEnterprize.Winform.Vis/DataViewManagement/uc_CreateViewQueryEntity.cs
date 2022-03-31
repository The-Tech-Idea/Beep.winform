using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.DataViewManagement
{
    [AddinAttribute(Caption = "Entity in View Editor ", Name = "uc_CreateViewQueryEntity", misc = "VIEW", addinType = AddinType.Control)]
    public partial class uc_CreateViewQueryEntity : uc_BaseControl
    {
        public uc_CreateViewQueryEntity()
        {
            InitializeComponent();
        }
        IDMDataView MyDataView;
        public override void Run(IPassedArgs pPassedarg)
        {
            base.Run(pPassedarg);   

        }
        public override void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            base.SetConfig(pbl, plogger, putil, args, e, per);
            if (Passedarg.Objects.Where(i => i.Name == "IDMDataView").Any())
            {
                MyDataView = (IDMDataView)e.Objects.Where(c => c.Name == "IDMDataView").FirstOrDefault().obj;

            }
        }


    }
}
