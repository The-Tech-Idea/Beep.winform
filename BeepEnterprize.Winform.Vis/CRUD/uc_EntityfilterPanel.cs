using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BeepEnterprize.Winform.Vis.CRUD
{
    [AddinAttribute(Caption = "Filter Entities", Name = "uc_EntityfilterPanel", misc = "CRUD", addinType = AddinType.Control)]
    public partial class uc_EntityfilterPanel : UserControl,IDM_Addin
    {
        public uc_EntityfilterPanel()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; } = "UserControl";
        public string AddinName { get; set; } = "Filter Entities";
        public string Description { get; set; }
        public bool DefaultCreate { get; set; }
        public string DllPath { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public IErrorsInfo ErrorObject { get; set; }
        public IDMLogger Logger { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string EntityName { get; set; }
        public IPassedArgs Passedarg { get; set; }

        VisManager visManager;
        BindingSource EntitybindingSource;
        int CurrentRecordIndex;
        IDataSource ds;
        object objdata;
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;

            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (e.Objects.Where(i => i.Name == "FilterPanel").Any())
            {
                e.Objects.Remove(e.Objects.Where(i => i.Name == "FilterPanel").FirstOrDefault());
            }
            e.Objects.Add(new ObjectItem() { Name = "FilterPanel", obj = FilterPanel });
            DMEEditor.Passedarguments = e;
        }
    }
}
