using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;

using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.CRUD
{
    [AddinAttribute(Caption = "New/Update Entity", Name = "Frm_NewUpdateEntity", misc = "CRUD")]
    public partial class Frm_NewUpdateEntity : UserControl, IDM_Addin
    {
        CrudManager crudManager;
        //public Frm_NewUpdateEntity(CrudManager pcrudManager)
        //{

        //    InitializeComponent();
        //    crudManager = pcrudManager;
        //}
        public Frm_NewUpdateEntity()
        {
            InitializeComponent();
            
        }

        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; } = "Form";
        public string AddinName { get ; set ; } = "New/Update Entity";
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

        public BindingSource EntitybindingSource { get; set; }
        VisManager visManager;
        IDataSource ds;
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }
        bool Currentchanged=false;
        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            Passedarg = e;
            SaveButton.Click += SaveButton_Click;
            
          
            if (e.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (VisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "BindingSource").Any())
            {
                EntitybindingSource = (BindingSource)e.Objects.Where(c => c.Name == "BindingSource").FirstOrDefault().obj;
            }
            if (e.Objects.Where(c => c.Name == "CRUD").Any())
            {
                crudManager = (CrudManager)e.Objects.Where(c => c.Name == "CRUD").FirstOrDefault().obj;
            }
            //if (e.Objects.Where(c => c.Name == "Entity").Any())
            //{
            //    EntityStructure = (EntityStructure)e.Objects.Where(c => c.Name == "Entity").FirstOrDefault().obj;
            //}
            ds = DMEEditor.GetDataSource(e.DatasourceName);
            ds.Openconnection();
            if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
            {
                EntityStructure = ds.GetEntityStructure(e.CurrentEntity, false);
                if (EntityStructure != null)
                {
                    if (EntityStructure.Fields != null)
                    {
                        if (EntityStructure.Fields.Count > 0)
                        {
                            //TitleHeader.Text = EntityStructure.EntityName;
                            //TitleHeader.Values.Description = $"From Data Source {EntityStructure.DataSourceID}";
                            EntityName = EntityStructure.EntityName;
                            if (Passedarg.Objects.Where(i => i.Name == "Control").Any())
                            {
                                Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "Control").FirstOrDefault());
                            }
                           
                            Passedarg.Objects.Add(new ObjectItem() { Name = "Control", obj = MainPanel });
                             visManager._controlManager.GenerateEntityonControl(EntityName, EntitybindingSource.Current, panel1.Height+20, EntityStructure.DataSourceID,crudManager.TransType, Passedarg);
                            //List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                            //visManager._controlManager.CreateEntityFilterControls(EntityStructure, defaults,  Passedarg);
                        }
                    }
                }
            }
            EntityNameLabel.Text = EntityName;
            EntitybindingSource.CurrentChanged += EntitybindingSource_CurrentChanged;
            visManager.PreClose += VisManager_PreClose;
        }
        private void VisManager_PreClose(object sender, FormClosingEventArgs e)
        {
            if (EntitybindingSource != null)
            {
                if (EntitybindingSource.Current != null)
                {
                    if (crudManager.TransType == TransActionType.Insert)
                    {
                        if (!Currentchanged)
                        {
                            EntitybindingSource.RemoveCurrent();
                        }
                       
                    }

                }
            }
        }
        private void EntitybindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (crudManager.TransType == TransActionType.Insert)
            {
                Currentchanged = true;
            }
           
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                EntitybindingSource.EndEdit();
                if (crudManager.TransType== TransActionType.Update)
                {
                    ds.UpdateEntity(EntityName, EntitybindingSource.Current);
                }
                else
                {
                    ds.InsertEntity(EntityName, EntitybindingSource.Current);
                }
                Currentchanged = true;
                visManager.Controlmanager.MsgBox("Beep", "Changes Saved");
            }
            catch (Exception ex)
            {
                visManager.Controlmanager.MsgBox("Beep", $"Error : Saving {ex.Message}");
                DMEEditor.AddLogMessage("Fail", $"Error : Saving {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
          

        }
    }
}
