using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    [AddinAttribute(Caption = "Create/Edit Manager", Name = "CreateEditEntityManager", misc = "CreateEditEntityManager", addinType = AddinType.Class)]
    public class CreateEditEntityManager : IDM_Addin
    {
        public CreateEditEntityManager()
        {

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
        public IDataSource ds { get; set; }
        public Type CurrentType { get; set; }
        public IEntityStructure entity { get; set ; }
        public DatasourceCategory DatasourceCategory { get; set ; }
        public string Entityname { get; set; }
        public string Datasourcename { get; set; }
        public bool IsNewEntity { get; set; }
        public void Run(IPassedArgs pPassedarg)
        {
            Passedarg = pPassedarg;
            if (pPassedarg.Objects.Where(i => i.Name == "CreateEditEntityManager").Any())
            {
                pPassedarg.Objects.Remove(pPassedarg.Objects.Where(i => i.Name == "CreateEditEntityManager").FirstOrDefault());
            }
            pPassedarg.Objects.Add(new ObjectItem() { Name = "CreateEditEntityManager", obj = this });
            Datasourcename = pPassedarg.DatasourceName;
            Entityname = pPassedarg.CurrentEntity;
          
            SetupConnection(pPassedarg.DatasourceName, (PassedArgs)pPassedarg);
            if (DMEEditor.ErrorObject.Flag == Errors.Ok)
            {
              
                visManager.wizardManager.Nodes.Clear();
                visManager.wizardManager.Title = Datasourcename;
                visManager.wizardManager.Description = Entityname;
                visManager.wizardManager.InitWizardForm();
                uc_createeditEntitymain uc_entitymain;
                uc_createeditentityfields uc_entityfields;
                uc_createeditentityrelations uc_entityrelations;

                uc_entitymain = new uc_createeditEntitymain();
                uc_entityfields = new uc_createeditentityfields();
                uc_entityrelations = new uc_createeditentityrelations();


                uc_entitymain.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);
                uc_entityfields.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);
                uc_entityrelations.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, new string[] { }, Passedarg, DMEEditor.ErrorObject);

                visManager.wizardManager.AddNode(uc_entitymain, "Create/Edit Entity ", "Create/Edit Entity");
                visManager.wizardManager.AddNode(uc_entityfields, "Entity Fields", "Entity Fields");
                visManager.wizardManager.AddNode(uc_entityrelations, "Entity Relations", "Entity Relations");
              
                ObjectItem ob;
                if (Passedarg.Objects.Where(c => c.Name == "Entity").Any())
                {
                    ob = (ObjectItem)Passedarg.Objects.Where(c => c.Name == "Entity");
                }
                else
                {
                    ob = new ObjectItem();
                    ob.Name = "Entity";
                    Passedarg.Objects.Add(ob);
                }
                ob.obj = entity;

                visManager.wizardManager.Show();
                visManager.wizardManager.WizardCloseEvent += WizardManager_WizardCloseEvent;
            }
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

        }
        private void WizardManager_WizardCloseEvent(object sender, BeepEnterprize.Vis.Module.IWizardManager e)
        {
            if (MessageBox.Show("Would you like to save Changes ?", "Beep", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Save();
            }
        }

        public void Save()
        {
            try
            {
                if (IsNewEntity)
                {

                }
                if(ds == null)
                {
                    MessageBox.Show( $"Cannot Find DataSource {Datasourcename}", "Beep", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        public IErrorsInfo SetupConnection(string DatasourceName, PassedArgs e)
        {
            Passedarg = e;
            ds = DMEEditor.GetDataSource(DatasourceName);
            ds.Openconnection();
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
            {
                EntityName = e.CurrentEntity;

                if (e.Objects.Where(c => c.Name == "EntityStructure").Any())
                {
                    EntityStructure = (EntityStructure)e.Objects.Where(c => c.Name == "EntityStructure").FirstOrDefault().obj;
                }
                else
                {
                    EntityStructure = ds.GetEntityStructure(EntityName, true);
                    e.Objects.Add(new ObjectItem { Name = "EntityStructure", obj = EntityStructure });
                }

                if (EntityStructure != null)
                {
                    if (EntityStructure.Fields != null)
                    {
                        if (EntityStructure.PrimaryKeys.Count > 0)
                        {
                            if (EntityStructure.Fields.Count > 0)
                            {
                                CurrentType = ds.GetEntityType(EntityStructure.EntityName);
                            }
                        }
                    }
                }
                else
                {
                    DMEEditor.ErrorObject.Flag = Errors.Failed;
                    visManager._controlManager.MsgBox("Fail", "Could not Get Entity from Data source");
                }

            }
            else
            {
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                visManager._controlManager.MsgBox("Fail", "Could not Open Data source");
            }
            return DMEEditor.ErrorObject;
        }

    }
}
