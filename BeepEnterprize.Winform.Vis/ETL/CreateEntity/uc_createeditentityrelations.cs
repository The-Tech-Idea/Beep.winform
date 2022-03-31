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
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.ETL.CreateEntity
{
    [AddinAttribute(Caption = "Entity Editor Relation", Name = "uc_createeditentityrelations", misc = "ETL", addinType = AddinType.Control)]
    public partial class uc_createeditentityrelations : uc_BaseControl
    {
        public uc_createeditentityrelations()
        {
            InitializeComponent();
            TitleLabel.Text = "Entity Relations";
        }
        CreateEditEntityManager entityManager;
        public override void Run(IPassedArgs pPassedarg)
        {
            base.Run(pPassedarg);
            relationsBindingSource.DataSource = entityManager.EntityStructure.Relations;
            entityColumnIDComboBox.DataSource = entityManager.EntityStructure.Fields;
            uc_bindingNavigator1.bindingSource = relationsBindingSource;
            entityColumnIDComboBox.DisplayMember = "fieldname";
            entityColumnIDComboBox.ValueMember = "fieldname";
            relatedEntityIDComboBox.DataSource = entityManager.ds.Entities;
            relatedEntityIDComboBox.DisplayMember = "EntityName";
            //   relatedEntityIDComboBox.ValueMember = "EntityName";
            dataGridView1.DataSource = relationsBindingSource;
            dataGridView1.Refresh();
            dataGridView1.Invalidate();

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
          
            entityColumnIDComboBox.DisplayMember = "fieldname";
            entityColumnIDComboBox.ValueMember = "fieldname";
          
            relatedEntityIDComboBox.DisplayMember = "EntityName";
          //  relatedEntityIDComboBox.ValueMember = "EntityName";
            relatedEntityIDComboBox.SelectedValueChanged += RelatedEntityIDComboBox_SelectedValueChanged;
        }

        private void RelatedEntityIDComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            List<EntityField> ls = new List<EntityField>();
            if(relatedEntityIDComboBox.SelectedValue != null)
            {
                EntityStructure rnt = (EntityStructure)relatedEntityIDComboBox.SelectedValue;
                
                ls = rnt.Fields;
                relatedEntityColumnIDComboBox.DataSource = ls;
                relatedEntityColumnIDComboBox.DisplayMember = "fieldname";
                relatedEntityColumnIDComboBox.ValueMember = "fieldname";
            }
           
        }
        public void EndEdit()
        {
            relationsBindingSource.EndEdit();

        }
    }
}

