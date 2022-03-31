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
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    [AddinAttribute(Caption = "Entity Editor Relation", Name = "uc_createeditentityrelations", misc = "ETL", addinType = AddinType.Control)]
    public partial class uc_createeditentityrelations : uc_BaseControl
    {
        public uc_createeditentityrelations()
        {
            InitializeComponent();
            TitleLabel.Text = "Entity Relations";
        }
        CreateEditEntityManager entityManager;
        public override void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            base.SetConfig(pbl, plogger, putil, args, e, per);
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "CreateEditEntityManager").Any())
            {
                entityManager = (CreateEditEntityManager)e.Objects.Where(c => c.Name == "CreateEditEntityManager").FirstOrDefault().obj;
            }
        }
    }
}

