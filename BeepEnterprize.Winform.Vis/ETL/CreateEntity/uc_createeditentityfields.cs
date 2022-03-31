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
    [AddinAttribute(Caption = "Entity Editor Fields", Name = "uc_createeditentityfields", misc = "ETL", addinType = AddinType.Control)]
    public partial class uc_createeditentityfields : uc_BaseControl
    {
        public uc_createeditentityfields()
        {
            InitializeComponent();
            TitleLabel.Text = "Entity Fields";
        }
        CreateEditEntityManager entityManager;
        public override void Run(IPassedArgs pPassedarg)
        {
            fieldsBindingSource.DataSource = null;
            fieldsBindingSource.DataSource = entityManager.EntityStructure.Fields;
            uc_bindingNavigator1.bindingSource = fieldsBindingSource;
            dataGridView1.DataSource = fieldsBindingSource;
            //dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Invalidate();
            dataGridView1.Refresh();

            fieldtypeDataGridViewTextBoxColumn.DataSource = DMEEditor.typesHelper.GetNetDataTypes2();

        }
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
          
            //this.fieldsBindingSource.AddingNew += FieldsBindingSource_AddingNew;
            this.dataGridView1.DataError += FieldsDataGridView_DataError;
            this.dataGridView1.RowValidating += FieldsDataGridView_RowValidating;
            this.dataGridView1.CellEndEdit += FieldsDataGridView_CellEndEdit;
        }
        private void FieldsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell fieldtype = row.Cells[2];
            DataGridViewCell size1 = row.Cells[3];
            DataGridViewCell nperc = row.Cells[4];
            DataGridViewCell nscale = row.Cells[5];
            if (e.ColumnIndex == 2)
            {
                if (fieldtype.Value.ToString().Contains("N"))
                {
                    size1.ReadOnly = false;
                    nperc.ReadOnly = true;
                    nscale.ReadOnly = true;
                }
                if (fieldtype.Value.ToString().Contains("P,S"))
                {
                    size1.ReadOnly = true;
                    nperc.ReadOnly = false;
                    nscale.ReadOnly = false;
                }
            }
        }
        private void FieldsDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell id = row.Cells[0];
            DataGridViewCell fieldname = row.Cells[1];
            DataGridViewCell fieldtype = row.Cells[2];
            DataGridViewCell size1 = row.Cells[3];
            DataGridViewCell nperc = row.Cells[4];

            DataGridViewCell nscale = row.Cells[5];
            DataGridViewCell Autoinc = row.Cells[6];
            DataGridViewCell isdbnull = row.Cells[7];
            DataGridViewCell ischeck = row.Cells[8];
            DataGridViewCell isunique = row.Cells[9];
            DataGridViewCell iskey = row.Cells[10];

            //   e.Cancel = !(IsDoc(Docnamecell) && IsGender(Gendercell) && IsAddress(Addresscell) && IsContactno(Contactnocell) && IsDate(Datecell));
        }
        private void FieldsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        public void EndEdit()
        {
            fieldsBindingSource.EndEdit();

        }
    }
}

