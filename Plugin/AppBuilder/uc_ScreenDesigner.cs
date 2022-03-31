using BeepEnterprize.Winform.Vis;
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
using TheTechIdea.Beep.AppBuilder;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace AppBuilder
{
    [AddinAttribute(Caption = "App. Screen Editor", Name = "uc_ScreenDesigner", misc = "App", addinType = AddinType.Control,displayType = DisplayType.InControl)]
    public partial class uc_ScreenDesigner : UserControl,IDM_Addin
    {
        public uc_ScreenDesigner()
        {
            InitializeComponent();
        }

        public string ParentName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string AddinName { get; set; }
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
        ScreenDesigner screenDesigner;
        public void Run(IPassedArgs pPassedarg)
        {
        
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            Passedarg = e;
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            screenDesigner = new ScreenDesigner(DMEEditor);
            screenDesigner.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, e, DMEEditor.ErrorObject);
            screenDesigner.ControlsPanel = ControlsPanel;
            screenDesigner.ControlsPanel.AllowDrop = true;
            screenDesigner.propertyGrid1 = propertyGrid1;
            screenDesigner.Mainpanel = Mainpanel;
            screenDesigner.MainMenuToolStrip = MenutoolStrip;
            screenDesigner.Run(e);
        }
    }
}
