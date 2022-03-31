using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace Beep.Winform.Controls
{
    public partial class uc_BeepGrid : UserControl, IDM_Addin
    {
        public uc_BeepGrid()
        {
            InitializeComponent();
            Loadimages();
            InitPanels();
            foreach (Control c in this.Controls)
            {
                c.Click += (sender, e) => { this.InvokeOnClick(this, e); };
                c.MouseUp += (sender, e) => { this.OnMouseUp(e); };
                c.MouseDown += (sender, e) => { this.OnMouseDown(e); };
                c.MouseMove += (sender, e) => { this.OnMouseMove(e); };
            }
            dataGridView1 = new System.Windows.Forms.DataGridView();
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           
            dataGridView1.Location = new System.Drawing.Point(0, 22);
            dataGridView1.Name = "dataGridView1";
            
            dataGridView1.TabIndex = 2;
            Controls.Add(this.dataGridView1);
         //   this.Size = new System.Drawing.Size(250, 200);
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.BringToFront();
            WireAllControls(this);
        }
        public DataGridViewColumnCollection ColumnCollection { get { return dataGridView1.Columns; }  }

        public event EventHandler<BindingSource> CallPrinter;
        public event EventHandler<BindingSource> SendMessage;
        public event EventHandler<BindingSource> ShowSearch;
        public event EventHandler<BindingSource> NewRecordCreated;
        public event EventHandler<BindingSource> SaveCalled;
        public event EventHandler<BindingSource> DeleteCalled;


        private ToolTip searchtooltip;
        private ToolTip addtooltip;
        private ToolTip edittooltip;
        private ToolTip removetooltip;
        private ToolTip nexttooltip;
        private ToolTip previoustooltip;
        private ToolTip canceltooltip;
        private ToolTip savetooltip;
        private ToolTip printtooltip;
        private ToolTip sharetooltip;
        
        private ResourceManager resourceManager = new ResourceManager();
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
        public System.Windows.Forms.DataGridView dataGridView1 { get; set; }
        IVisManager visManager;
        BindingSource _bindingSource;
        public BindingSource bindingSource { get { return _bindingSource; } set { dataGridView1.DataSource = value; _bindingSource = value; dataGridView1.Refresh(); } }
        public bool VerifyDelete { get; set; } = true;
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs passarg, IErrorsInfo per)
        {
            DMEEditor = pbl;
            ErrorObject = pbl.ErrorObject;
            Logger = pbl.Logger;

            if (passarg.Objects.Where(c => c.Name == "VISUTIL").Any())
            {
                visManager = (IVisManager)passarg.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            }
            if (Passedarg.Objects.Where(c => c.Name == "BindingSource").Any())
            {
                bindingSource = (BindingSource)Passedarg.Objects.Where(c => c.Name == "BindingSource").FirstOrDefault().obj;
            }

            if (bindingSource != null)
            {
                this.bindingSource.DataSourceChanged += BindingSource_DataSourceChanged;
                this.bindingSource.ListChanged += BindingSource_ListChanged;
                this.bindingSource.CurrentChanged += BindingSource_CurrentChanged;
                this.Previousbutton.Click -= PreviouspictureBox_Click;
                this.NextButton.Click -= NextpictureBox_Click;
                this.Deletebutton.Click -= RemovepictureBox_Click;
             //   this..Click -= SavepictureBox_Click;
                this.Cancelbutton.Click -= RollbackpictureBox_Click;
              //  this.EditButton.Click -= EditpictureBox_Click;
              //  this.FindButton.Click -= FindpictureBox_Click;
                this.Printbutton.Click -= PrinterpictureBox_Click;
                this.Sharebutton.Click -= MessegepictureBox_Click;
                this.Newbutton.Click -= NewButton_Click;

                this.Newbutton.Click += NewButton_Click;
                this.Previousbutton.Click += PreviouspictureBox_Click;
                this.NextButton.Click += NextpictureBox_Click;
                this.Deletebutton.Click += RemovepictureBox_Click;
                this.SaveButton.Click += SavepictureBox_Click;
              //  this.RollbackButton.Click += RollbackpictureBox_Click;
               // this.EditButton.Click += EditpictureBox_Click;
             //   this.FindButton.Click += FindpictureBox_Click;
                this.Printbutton.Click += PrinterpictureBox_Click;
                this.Sharebutton.Click += MessegepictureBox_Click;
                datasourcechanged();
            }

        }

        private void WireAllControls(Control cont)
        {
            foreach (Control c in this.Controls)
            {
                c.Click += (sender, e) => { this.InvokeOnClick(this,e); };
                c.MouseUp += (sender, e) => { this.OnMouseUp(e); };
                c.MouseDown += (sender, e) => { this.OnMouseDown(e); };
                c.MouseMove += (sender, e) => { this.OnMouseMove(e); };
            }
        }
        private void InitPanels()
        {
           
            //foreach (Button item in GetAll(this, typeof(Button)))
            //{
            //    item.FlatAppearance.BorderSize = ButtonBorderSize;
            //    item.FlatAppearance.MouseDownBackColor = SelectedColor;
            //    item.FlatAppearance.MouseOverBackColor = HightlightColor;
            //}

            searchtooltip = new ToolTip();
            addtooltip = new ToolTip();
            edittooltip = new ToolTip();
            removetooltip = new ToolTip();
            nexttooltip = new ToolTip();
            previoustooltip = new ToolTip();
            canceltooltip = new ToolTip();
            savetooltip = new ToolTip();
            printtooltip = new ToolTip();
            sharetooltip = new ToolTip();

            //searchtooltip.SetToolTip(FindButton, "Find");
            //addtooltip.SetToolTip(NewButton, "New Record");
            //edittooltip.SetToolTip(EditButton, "Edit Current Record");
            //removetooltip.SetToolTip(RemoveButton, "Delete Current Record");
            //nexttooltip.SetToolTip(NextButton, "Next");
            //previoustooltip.SetToolTip(PrevoiusButton, "Previous");
            //canceltooltip.SetToolTip(RollbackButton, "Cancel or Rollback changes");
            //savetooltip.SetToolTip(SaveButton, "Save Changes");
            //printtooltip.SetToolTip(PrinterButton, "Print");
            //sharetooltip.SetToolTip(MessageButton, "Share");
           
        }
        private void Loadimages()
        {
            this.Filterbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "Filter.png");
            this.Sharebutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "ShareLink.png");
            this.Printbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "Print.png");
            ////CRUDSmall
            this.Cancelbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.CRUDSmall.", "cancel.png");
            this.Deletebutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.CRUDSmall.", "delete.png");
            this.Newbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.CRUDSmall.", "new.png");
            this.NextButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.CRUDSmall.", "next.png");
            this.Previousbutton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.CRUDSmall.", "previous.png");
            this.SaveButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.CRUDSmall.", "Save.png");
            //this.SaveButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "save.png");
            //this.NextButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "right.png");
            //this.PrevoiusButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "left.png");
            //this.RemoveButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "remove.png");
            //this.RollbackButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "cancel.png");
            //this.EditButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "edit.png");
            //this.FindButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "search.png");
            //this.MessageButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "messages.png");
            //this.PrinterButton.BackgroundImage = resourceManager.GetImage("Beep.Winform.Controls.gfx.", "printer.png");

        }
        #region "BindingSource Events"
        private void RollbackpictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this.Parent, "Are you sure you want to cancel Changes?", "Beep", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    bindingSource.CancelEdit();
                    //      FocusPicture(sender);
                };

            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }
        }
        private void SavepictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource.EndEdit();
                SaveCalled?.Invoke(sender, bindingSource);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }

        }
        private void RemovepictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteCalled?.Invoke(sender, bindingSource);
                if (bindingSource.Current != null)
                {
                    if (bindingSource.Count > 0)
                    {
                        if (VerifyDelete)
                        {
                            if (MessageBox.Show(this.Parent, "Are you sure you want to Delete Record?", "Beep", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                            {
                                bindingSource.RemoveCurrent();
                            };
                        }
                        else
                        {
                            bindingSource.RemoveCurrent();
                        }
                    }
                }


                //FocusPicture(sender);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }

        }
        private void MessegepictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                //  if (MessageBox.Show(this.Parent, "Are you sure you want to cancel Changes?", "Beep", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                //  {
                // bindingSource.CancelEdit();
                //FocusPicture(sender);
                SendMessage?.Invoke(this, bindingSource);
                // };

            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }
        }
        private void PrinterpictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                //  if (MessageBox.Show(this.Parent, "Are you sure you want to cancel Changes?", "Beep", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                //  {
                // bindingSource.CancelEdit();
                //      FocusPicture(sender);
                CallPrinter?.Invoke(this, bindingSource);
                // };

            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }
        }
        private void NextpictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource.Count > 0)
                    if (bindingSource[bindingSource.Count - 1] != null)
                        if (bindingSource.Position + 1 < bindingSource.Count)
                            bindingSource.MoveNext();
                ;

                // FocusPicture(sender);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }

        }
        private void PreviouspictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource.Count > 0)
                    if (bindingSource[bindingSource.Count - 1] != null)
                        if (bindingSource.Position > 0)
                            bindingSource.MovePrevious();
                ;
                //  FocusPicture(sender);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }

        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            try
            {

                bindingSource.AddNew();
                NewRecordCreated?.Invoke(this, bindingSource);

            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Binding Navigator", ex.Message, DateTime.Now, bindingSource.Position, ex.Message, Errors.Failed);
            }
        }
        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            datasourcechanged();

        }

        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            datasourcechanged();
        }
        private void BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            datasourcechanged();


        }
        private void datasourcechanged()
        {
            if (this.bindingSource != null)
            {
                if (this.bindingSource.List != null)
                {
                    this.MessageLabel.Text = (Convert.ToInt32(bindingSource.Position) + 1).ToString() + " From " + bindingSource.Count.ToString();
                }
                else
                    this.MessageLabel.Text = "-";
            }
        }

        #endregion
    }
}
