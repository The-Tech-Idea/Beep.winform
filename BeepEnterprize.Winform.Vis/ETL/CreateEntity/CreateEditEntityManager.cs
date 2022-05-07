using BeepEnterprize.Vis.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using static BeepEnterprize.Winform.Vis.Wizards.WizardManager;

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
        public DataViewDataSource dvs { get; set; }
        public Type CurrentType { get; set; }
  
        public DatasourceCategory DatasourceCategory { get; set ; }
        public string Entityname { get; set; }
        public string Datasourcename { get; set; }
        public bool IsNewEntity { get; set; }
        uc_createeditEntitymain uc_entitymain;
        uc_createeditentityfields uc_entityfields;
        uc_createeditentityrelations uc_entityrelations;
        IBranch ViewBranch;
        public bool IsViewDataSource { get; set; } = false;
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
          
          //  SetupConnection(pPassedarg.DatasourceName, (PassedArgs)pPassedarg);
            if (DMEEditor.ErrorObject.Flag == Errors.Ok)
            {
              
                visManager.wizardManager.Nodes.Clear();
                visManager.wizardManager.Title = Datasourcename;
                visManager.wizardManager.Description = Entityname;
                visManager.wizardManager.InitWizardForm();
              

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
                ob.obj = EntityStructure;
                if (Passedarg.Objects.Where(c => c.Name == "Branch").Any())
                {
                    ViewBranch = (IBranch)Passedarg.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;
                  
                }
              
               
               
                //RootBranch = TreeEditor.Branches[visManager..FindIndex(x => x.BranchClass == pbr.BranchClass && x.BranchType == EnumPointType.Root)];
                visManager.wizardManager.Show();
                visManager.wizardManager.WizardCloseEvent -= WizardManager_WizardCloseEvent;
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
            Datasourcename = e.DatasourceName;
            Entityname = e.CurrentEntity;
            if (!string.IsNullOrEmpty(Datasourcename))
            {
                ds=DMEEditor.GetDataSource(Datasourcename);
               // dvs = (DataViewDataSource)DMEEditor.GetDataSource(Datasourcename);
            }
            if(ds != null)
            {
                if (ds.Category == DatasourceCategory.VIEWS)
                {
                    dvs = (DataViewDataSource)DMEEditor.GetDataSource(Datasourcename);
                    IsViewDataSource = true;
                }
              
                if(!string.IsNullOrEmpty(e.CurrentEntity))
                {
                    EntityStructure = dvs.GetEntityStructure(e.CurrentEntity, false);
                    IsNewEntity = false;
                }
                else
                {
                    IsNewEntity = true;
                    EntityStructure = new EntityStructure() { DataSourceID=e.DatasourceName };
                    EntityStructure.Created = false;
                    EntityStructure.Editable = true;
                    EntityStructure.DataSourceID = e.DatasourceName;
                    EntityStructure.Viewtype = ViewType.Query;
                }
            }
            else
            {
                return;
            }
            
        }
        private void WizardManager_WizardCloseEvent(object sender, NodeChangeEventHandler e)
        {
            if (!ValidateRequiredFields())
            {
                e.Cancel = true;
                
                MessageBox.Show($"Entity Property Missing", "Beep", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Would you like to save Changes ?", "Beep", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Save();
            }
        }
        public bool ValidateRequiredFields()
        {
            if(EntityStructure == null)
            {
                return false;
            }
            if(EntityStructure.Fields == null)
            {
                return false;
            }
            if(EntityStructure.DatasourceEntityName == null)
            {
                return false;
            }
            if (EntityStructure.DataSourceID == null)
            {
                return false;
            }
            if (EntityStructure.OriginalEntityName == null)
            {
                return false;
            }
            if (EntityStructure.EntityName == null)
            {
                return false;
            }
            if (EntityStructure.CustomBuildQuery == null)
            {
                return false;
            }
            return true;
        }
        public void Save()
        {
            try
            {
                if (!string.IsNullOrEmpty(EntityStructure.DataSourceID))
                {
                    ds = DMEEditor.GetDataSource(EntityStructure.DataSourceID);
                }

                if (ds != null)
                {
                    uc_entitymain.EndEdit();
                    uc_entityfields.EndEdit();
                    uc_entityrelations.EndEdit();
                    if (IsNewEntity)
                    {
                        switch (dvs.Category)
                        {
                           case DatasourceCategory.VIEWS:
                                dvs.CreateEntityAs(EntityStructure);
                                break;
                            case DatasourceCategory.FILE:
                            case DatasourceCategory.STREAM:
                                break;
                            case DatasourceCategory.WEBAPI:
                                break;
                            case DatasourceCategory.NOSQL:
                            case DatasourceCategory.RDBMS:

                                break;
                        }
                        dvs.WriteDataViewFile(dvs.DataViewDataSourceID);
                        ViewBranch.CreateChildNodes();
                  
                    }
                    else
                    {
                        dvs.Entities[ds.Entities.FindIndex(o => o.OriginalEntityName == EntityStructure.OriginalEntityName)] = EntityStructure;
                    }
                  //  DMEEditor.ConfigEditor.SaveDataSourceEntitiesValues(new DatasourceEntities() { Entities = ds.Entities, datasourcename = ds.DatasourceName });
                    MessageBox.Show($"Saved Entity in DataSource {Datasourcename}", "Beep", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Cannot Find DataSource {Datasourcename}", "Beep", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
