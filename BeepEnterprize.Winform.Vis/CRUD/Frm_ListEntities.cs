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

using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.CRUD
{
    [AddinAttribute(Caption = "List Entities", Name = "Frm_ListEntities", misc = "CRUD")]
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
        public string ObjectType { get ; set ; } = "Form";
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

         //  visManager._controlManager.CrudFilterPanel = FilterPanel;
            EntitybindingSource = crudManager.EntitybindingSource;
            EntitybindingSource.PositionChanged += EntitybindingSource_PositionChanged;
            EntitybindingSource.DataError += EntitybindingSource_DataError;
            EntitybindingSource.CurrentChanged += EntitybindingSource_CurrentChanged;
            EntityNameLabel.Text = crudManager.EntityStructure.EntityName;
            SubtitleLabel.Text = $"{e.DatasourceName}";
            NewButton.Click += NewButton_Click;
            EditButton.Click += EditButton_Click;
            DeleteButton.Click += DeleteButton_Click;
            PrintButton.Click += PrintButton_Click;
            SubmitButton.Click += SubmitButton_Click;
            objdata = crudManager.GetData();
            RefreshData(objdata);

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
            objdata = crudManager.GetData();
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

       
    }
}
