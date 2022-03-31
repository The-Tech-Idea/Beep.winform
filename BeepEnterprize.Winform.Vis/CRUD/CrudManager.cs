using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Winform.Vis.ETL.ImportData;

using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.CRUD
{
    [AddinAttribute(Caption = "Crud Manager", Name = "CRUDMANAGER", misc = "CRUD",addinType =AddinType.Class)]
    public class CrudManager : IDM_Addin
    {
        public CrudManager()
        {

        }
        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; } = "CRUD MANAGER";
        public string ObjectType { get; set; } = "CODE";
        public string AddinName { get; set; } = "CRUD MANAGER";
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

        public bool IsCrudEnabled { get; set; } = true;

        public object CurrentRecord { get; set; }
        public Type CurrentType { get; set; }
        public  BindingSource EntitybindingSource { get; set; }
        public  Frm_ListEntities listEntities { get; set; }
        public ImportDataManager dataLoadingManager { get; set; } = new ImportDataManager();
        public Control queryFields { get; set; }
        IDataSource ds;
    
        public TransActionType TransType { get; set; } 
      
        VisManager visManager;


        public void Run(IPassedArgs pPassedarg)
        {
            visManager.Container.Controls.Clear();
            visManager.Container.Controls.Add(listEntities);
            listEntities.Dock = System.Windows.Forms.DockStyle.Fill;
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
            EntitybindingSource = new BindingSource();
         
            listEntities = new Frm_ListEntities(this);
            SetupConnection(e.DatasourceName, (PassedArgs)e);


        }
        public void SetupConnection(string DatasourceName,PassedArgs e)
        {
            Passedarg = e;
            ds = DMEEditor.GetDataSource(DatasourceName);
            // ds.Dataconnection.OpenConnection();

            ds.Openconnection();
            //  ds.ConnectionStatus = ds.Dataconnection.ConnectionStatus;
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
                    EntityStructure.DataSourceID = DatasourceName;
                    if (EntityStructure.Fields != null)
                    {
                        if (EntityStructure.PrimaryKeys.Count > 0)
                        {
                            if (EntityStructure.Fields.Count > 0)
                            {
                                listEntities.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                EntityStructure.Filters = new List<AppFilter>();
                                List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;

                                visManager.Controlmanager.CreateEntityFilterControls( EntityStructure, defaults,e);
                            }
                            CurrentType = ds.GetEntityType(EntityStructure.EntityName);
                        }
                        else
                        {
                            if(ds.Category!= DatasourceCategory.RDBMS)
                            {
                                IsCrudEnabled = true;
                            }
                            else
                            {
                                IsCrudEnabled = false;
                                visManager.Controlmanager.MsgBox("Beep", "Cannot Edit a table with no primary keys");
                            }
                            if (EntityStructure.Fields.Count > 0)
                            {
                                listEntities.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                EntityStructure.Filters = new List<AppFilter>();
                                List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                                visManager.Controlmanager.CreateEntityFilterControls(EntityStructure, defaults, e);
                            }
                            CurrentType = ds.GetEntityType(EntityStructure.EntityName);
                        }
                    }
                }
               
                
            }
        }
        public void EditEntity(object record)
        {
            if (!IsCrudEnabled) return;
            TransType = TransActionType.Update;
           
            if (EntityStructure.Viewtype != ViewType.Table)
            {
               visManager.Controlmanager.MsgBox("Beep","Cannot Edit an Non Table Structure");


            }
            else
            {
                if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                {
                    CurrentRecord = record;
                    if (record!=null)
                    {
                       // ob = EntitybindingSource.Current;
                        if (Passedarg.Objects.Where(i => i.Name == EntityStructure.EntityName).Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == EntityStructure.EntityName).FirstOrDefault());
                        }
                        if (Passedarg.Objects.Where(i => i.Name == "Entity").Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "Entity").FirstOrDefault());
                        }
                        if (Passedarg.Objects.Where(i => i.Name == "BindingSource").Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "BindingSource").FirstOrDefault());
                        }
                        //if (Passedarg.Objects.Where(i => i.Name == "Control").Any())
                        //{
                        //    Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "Control").FirstOrDefault());
                        //}
                        if (Passedarg.Objects.Where(i => i.Name == "CRUD").Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "CRUD").FirstOrDefault());
                        }
                        Passedarg.Objects.Add(new ObjectItem() { Name = EntityStructure.EntityName, obj = this });
                        Passedarg.Objects.Add(new ObjectItem() { Name = "Entity", obj = record });
                        Passedarg.Objects.Add(new ObjectItem() { Name = "BindingSource", obj = EntitybindingSource });
                        //Passedarg.Objects.Add(new ObjectItem() { Name = "Control", obj = newUpdateEntity.MainPanel });
                        Passedarg.Objects.Add(new ObjectItem() { Name = "CRUD", obj = this });
                        visManager.ShowUserControlPopUp("Frm_NewUpdateEntity", DMEEditor, new string[] { "" }, Passedarg);

                    }
                }


            }
        }
        public void DeleteEntity(object record)
        {
            if (!IsCrudEnabled) return;
            if (EntityStructure.Viewtype != ViewType.Table)
            {
                visManager.Controlmanager.MsgBox("Beep", "Cannot Edit an Non Table Structure");
            }
            else
            {
                if (visManager.Controlmanager.InputBoxYesNo("Beep", "Delete, Are you sure ? ") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                {
                    if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                    {
                        if (record!=null)
                        {
                            try
                            {
                                if (ds.DeleteEntity(EntityStructure.EntityName, CurrentRecord).Flag == Errors.Failed)
                                {
                                    visManager.Controlmanager.MsgBox("Beep","Failed to Delete Record");
                                }
                                else
                                {
                                    EntitybindingSource.RemoveCurrent();
                                   // listEntities.DeleteRecord(record);
                                    visManager.Controlmanager.MsgBox("Beep", "Success to Delete Record");
                                }
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                        }
                    }
                }
            }
        }
        public void NewEntity( )
        {
            if (!IsCrudEnabled) return;
            TransType = TransActionType.Insert;
           
            if (EntityStructure.Viewtype != ViewType.Table)
            {
                visManager.Controlmanager.MsgBox("Beep", "Cannot Edit an Non Table Structure");


            }
            else
            {
                if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                {
                    if (EntityStructure.EntityName != null)
                    {
                        if (EntitybindingSource.Current != null)
                        {
                            EntitybindingSource.RemoveCurrent();
                        }
                        EntitybindingSource.AddNew();
                        CurrentRecord = EntitybindingSource.Current;
                        // ob = EntitybindingSource.Current;
                        if (Passedarg.Objects.Where(i => i.Name == EntityStructure.EntityName).Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == EntityStructure.EntityName).FirstOrDefault());
                        }
                        if (Passedarg.Objects.Where(i => i.Name == "Entity").Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "Entity").FirstOrDefault());
                        }
                        if (Passedarg.Objects.Where(i => i.Name == "BindingSource").Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "BindingSource").FirstOrDefault());
                        }
                       
                        if (Passedarg.Objects.Where(i => i.Name == "CRUD").Any())
                        {
                            Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "CRUD").FirstOrDefault());
                        }
                        Passedarg.Objects.Add(new ObjectItem() { Name = EntityStructure.EntityName, obj = this });
                        //Passedarg.Objects.Add(new ObjectItem() { Name = "Entity", obj = record });
                        Passedarg.Objects.Add(new ObjectItem() { Name = "BindingSource", obj = EntitybindingSource });
                      //  Passedarg.Objects.Add(new ObjectItem() { Name = "Control", obj = newUpdateEntity.MainPanel });
                        Passedarg.Objects.Add(new ObjectItem() { Name = "CRUD", obj = this });
                        visManager.ShowUserControlPopUp("Frm_NewUpdateEntity", DMEEditor, new string[] { "" }, Passedarg);
                      
                    }
                }


            }
        }
        public void Load()
        {
            if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
            {
                if (EntityStructure.EntityName != null)
                {
                  
                    // ob = EntitybindingSource.Current;
                    if (Passedarg.Objects.Where(i => i.Name == EntityStructure.EntityName).Any())
                    {
                        Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == EntityStructure.EntityName).FirstOrDefault());
                    }
                    if (Passedarg.Objects.Where(i => i.Name == "Entity").Any())
                    {
                        Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "Entity").FirstOrDefault());
                    }
                    if (Passedarg.Objects.Where(i => i.Name == "BindingSource").Any())
                    {
                        Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "BindingSource").FirstOrDefault());
                    }
                    //if (Passedarg.Objects.Where(i => i.Name == "Control").Any())
                    //{
                    //    Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "Control").FirstOrDefault());
                    //}
                    if (Passedarg.Objects.Where(i => i.Name == "CRUD").Any())
                    {
                        Passedarg.Objects.Remove(Passedarg.Objects.Where(i => i.Name == "CRUD").FirstOrDefault());
                    }
                    Passedarg.Objects.Add(new ObjectItem() { Name = EntityStructure.EntityName, obj = this });
                    //Passedarg.Objects.Add(new ObjectItem() { Name = "Entity", obj = record });
                    Passedarg.Objects.Add(new ObjectItem() { Name = "BindingSource", obj = EntitybindingSource });
                    //  Passedarg.Objects.Add(new ObjectItem() { Name = "Control", obj = newUpdateEntity.MainPanel });
                    Passedarg.Objects.Add(new ObjectItem() { Name = "CRUD", obj = this });
                    visManager.ShowUserControlPopUp("Frm_NewUpdateEntity", DMEEditor, new string[] { "" }, Passedarg);

                }
            }
        }
        public bool CheckPKifNull(object record)
        {
            bool retval = false;
            if (record != null)
            {
                Type enttype = DMEEditor.Utilfunction.GetEntityType(EntityName, EntityStructure.Fields);
                var ti = Activator.CreateInstance(enttype);
                DataRow dr = DMEEditor.Utilfunction.GetDataRowFromobject(EntityName, enttype, record, EntityStructure);
                foreach (EntityField item in EntityStructure.PrimaryKeys)
                {
                    if(dr[item.fieldname] == null)
                    {
                        retval = true;
                    }
                }
            }
            return retval;
        }
        public object GetData()
        {
            return ds.GetEntity(EntityStructure.DatasourceEntityName,EntityStructure.Filters);
        }
       
        
    }
}
