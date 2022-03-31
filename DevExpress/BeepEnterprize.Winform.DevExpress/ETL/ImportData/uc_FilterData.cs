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
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Workflow.Mapping;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.ImportData
{
    public partial class uc_FilterData : UserControl,IDM_Addin
    {
        public uc_FilterData()
        {
            InitializeComponent();
        }

        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; }
        public string AddinName { get ; set ; }
        public string Description { get ; set ; }
        public bool DefaultCreate { get ; set ; }
        public string DllPath { get ; set ; }
        public string DllName { get ; set ; }
        public string NameSpace { get ; set ; }
        public IErrorsInfo ErrorObject { get ; set ; }
        public IDMLogger Logger { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public EntityStructure EntityStructure { get ; set ; }
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        VisManager visManager;
        //  IDataSource ds;
        //  Type CurrentType;
        public  ImportDataManager importDataManager { get; set; }
        public EntityDataMap_DTL DataMap { get; set; } 

        public void Run(IPassedArgs pPassedarg)
        {
            if (importDataManager.CurrentMappingDTL != null)
            {
                List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == pPassedarg.DatasourceName)].DatasourceDefaults;
                visManager.Controlmanager.CreateFieldsFilterControls(importDataManager.CurrentMappingDTL.EntityFields, importDataManager.CurrentMappingDTL.Filter, defaults, pPassedarg);
                DMEEditor.ErrorObject.Flag = Errors.Ok;
            }
            else
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
            }
           
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
            if (e.Objects.Where(c => c.Name == "ImportDataManager").Any())
            {
                importDataManager = (ImportDataManager)e.Objects.Where(c => c.Name == "ImportDataManager").FirstOrDefault().obj;
            }
          
            if (!e.Objects.Where(i => i.Name == "FilterPanel").Any())
            {
               e.Objects.Add(new ObjectItem() { Name = "FilterPanel", obj = MainPanel });
            }
         
        }
    }
}
