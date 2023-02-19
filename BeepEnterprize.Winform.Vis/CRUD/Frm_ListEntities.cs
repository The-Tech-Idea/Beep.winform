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
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.CRUD
{
    [AddinAttribute(Caption = "List Entities", Name = "Frm_ListEntities", misc = "CRUD",displayType = DisplayType.InControl,addinType = AddinType.Control)]
    public partial class Frm_ListEntities : UserControl, IDM_Addin
    {
        CrudManager crudManager;
        public Frm_ListEntities(CrudManager pcrudManager)
        {

            InitializeComponent();
            crudManager = pcrudManager;
        }
        public Frm_ListEntities()
        {
            InitializeComponent();
        }

        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; } = "UserControl";
        public string AddinName { get ; set ; } = "List Entities";
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
        BindingSource EntitybindingSource;
        int CurrentRecordIndex;
        IDataSource ds;
        object objdata;
        bool IsCrudEnabled;
        Type CurrentType;
        public void Run(IPassedArgs pPassedarg)
        {
          //  throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;
            if (e.Objects.Where(c => c.Name == "CRUDMANAGER").Any())
            {
                crudManager = (CrudManager)e.Objects.Where(c => c.Name == "CRUDMANAGER").FirstOrDefault().obj;
            }
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
            SetupConnection(e.DatasourceName, (PassedArgs)e);
            if (crudManager != null)
            {
                EntitybindingSource = crudManager.EntitybindingSource;
                EntitybindingSource.PositionChanged += EntitybindingSource_PositionChanged;
                EntitybindingSource.DataError += EntitybindingSource_DataError;
                EntitybindingSource.CurrentChanged += EntitybindingSource_CurrentChanged;
                if (crudManager.EntityStructure != null)
                {
                    
                    EntityNameLabel.Text = crudManager.EntityStructure.EntityName;
                    SubtitleLabel.Text = $"{e.DatasourceName}";
                    NewButton.Click += NewButton_Click;
                    EditButton.Click += EditButton_Click;
                    DeleteButton.Click += DeleteButton_Click;
                    PrintButton.Click += PrintButton_Click;
                    SubmitButton.Click += SubmitButton_Click;
                    objdata = GetData();
                    RefreshData(objdata);
                }
               
            }
           

        }

        private void EntitybindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void EntitybindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
           
        }

        private void EntitybindingSource_PositionChanged(object sender, EventArgs e)
        {
          
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            objdata = GetData();
            RefreshData(objdata);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            //List<ReportColumn> columns= this.DataGridView1.Columns.Cast<DataGridViewColumn>()
            //                          .Select(x => new ReportColumn(x.DataPropertyName)
            //                          {
            //                              Title = x.HeaderText,
            //                              Width = x.Width
            //                          }).ToList();

            PassedArgs passedArgs = new PassedArgs
            {
                 Objects = new List<ObjectItem> {  new ObjectItem() { Name = "DATA", obj = objdata }, new ObjectItem() { Name = "DataGridView", obj = DataGridView1 } }
                //Objects = new List<ObjectItem> { new ObjectItem() { Name = "ReportColumn", obj = columns }, new ObjectItem() { Name = "DATA", obj = DataGridView1 } }
            };

            visManager.PrintGrid(passedArgs);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                crudManager.CurrentRecord = EntitybindingSource.Current;
                CurrentRecordIndex = EntitybindingSource.Position;

            }
            crudManager.DeleteEntity(crudManager.CurrentRecord);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            crudManager.TransType = TransActionType.Update;
            if (DataGridView1.SelectedRows.Count > 0)
            {
                crudManager.CurrentRecord = EntitybindingSource.Current;
                CurrentRecordIndex = EntitybindingSource.Position;
            }
            crudManager.EditEntity(crudManager.CurrentRecord);
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            crudManager.TransType = TransActionType.Insert;
            crudManager.NewEntity();
        }
        public void DeleteRecord(object record)
        {
            
            EntitybindingSource.Remove(record);
        }
       
        public void UpdateRecord(object record)
        {
            EntitybindingSource.RemoveAt(CurrentRecordIndex);
            EntitybindingSource.Add(record);
        }
        private void RefreshData(object obj)
        {
            EntitybindingSource.DataSource = obj;
            EntitybindingSource.ResetBindings(true);
            DataGridView1.AutoGenerateColumns = true;
            DataGridView1.DataSource = EntitybindingSource;
            crudManager.CurrentRecord = EntitybindingSource.Current;
            CurrentRecordIndex = EntitybindingSource.Position;
            DataGridView1.Refresh();
            EntityNameLabel.Text = crudManager.EntityStructure.EntityName;
            SubtitleLabel.Text = $"{crudManager.EntityStructure.DataSourceID}";
        }
        public object GetData()
        {
            return ds.GetEntity(crudManager.EntityStructure.DatasourceEntityName, crudManager.EntityStructure.Filters);
        }
        public void SetupConnection(string DatasourceName, PassedArgs e)
        {
            Passedarg = e;
            ds = DMEEditor.GetDataSource(DatasourceName);
            if (ds != null)
            {
                ds.Openconnection();
                if (ds != null && ds.ConnectionStatus == ConnectionState.Open)
                {
                    EntityName = e.CurrentEntity;
                    if (e.Objects.Where(c => c.Name == "EntityStructure").Any())
                    {
                        crudManager.EntityStructure = (EntityStructure)e.Objects.Where(c => c.Name == "EntityStructure").FirstOrDefault().obj;
                    }
                    else
                    {
                        crudManager.EntityStructure = ds.GetEntityStructure(EntityName, true);
                        e.Objects.Add(new ObjectItem { Name = "EntityStructure", obj = crudManager.EntityStructure });
                    }
                    if (crudManager.EntityStructure != null)
                    {
                        crudManager.EntityStructure.DataSourceID = DatasourceName;
                        if (crudManager.EntityStructure.Fields != null)
                        {
                            if (crudManager.EntityStructure.PrimaryKeys.Count > 0)
                            {
                                if (crudManager.EntityStructure.Fields.Count > 0)
                                {
                                //   SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                    crudManager.EntityStructure.Filters = new List<AppFilter>();
                                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                                    visManager.Controlmanager.CreateEntityFilterControls(crudManager.EntityStructure, defaults, e);
                                }
                                CurrentType = ds.GetEntityType(crudManager.EntityStructure.EntityName);
                            }
                            else
                            {
                                if (ds.Category != DatasourceCategory.RDBMS)
                                {
                                    IsCrudEnabled = true;
                                }
                                else
                                {
                                    IsCrudEnabled = false;
                                    visManager.Controlmanager.MsgBox("Beep", "Cannot Edit a table with no primary keys");
                                }
                                if (crudManager.EntityStructure.Fields.Count > 0)
                                {
                                    //   SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, null, e, DMEEditor.ErrorObject);
                                    crudManager.EntityStructure.Filters = new List<AppFilter>();
                                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
                                    visManager.Controlmanager.CreateEntityFilterControls(crudManager.EntityStructure, defaults, e);
                                }
                                CurrentType = ds.GetEntityType(crudManager.EntityStructure.EntityName);
                            }
                        }
                    }
                }
            }
        }
    }
}
