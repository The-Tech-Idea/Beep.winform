using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;

using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis
{
    public class ControlManager : IControlManager
    {
        public ControlManager(IDMEEditor pdmeeditor, IVisManager pVismanager)
        {
            DMEEditor = pdmeeditor;
            Vismanager = pVismanager;
            vismanager = (VisManager)pVismanager;
            DisplayPanel = (Control)vismanager.Container;
        }

        string DisplayField;
        public IDMEEditor DMEEditor { get; set; }
        public IVisManager Vismanager { get; set; }
        private VisManager vismanager { get; set; }
        public Control DisplayPanel { get; set; }
        public Control CrudFilterPanel { get; set; }
        public BindingSource EntityBindingSource { get; set; }
        public ErrorsInfo ErrorsandMesseges { get; set; }
        #region "MessegeBox and Dialogs"
        public BeepEnterprize.Vis.Module.DialogResult InputBoxYesNo(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            //   TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            //  textBox.Text = value;

            buttonOk.Text = "Yes";
            buttonCancel.Text = "No";
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.No;

            label.SetBounds(9, 20, 372, 13);
            // textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            BeepEnterprize.Vis.Module.DialogResult dialogResult = MapDialogResult(form.ShowDialog());
            //value = textBox.Text;
            return dialogResult;
        }
        public BeepEnterprize.Vis.Module.DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, textBox, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            BeepEnterprize.Vis.Module.DialogResult dialogResult = MapDialogResult(form.ShowDialog());
            value = textBox.Text;
            return dialogResult;
        }
        public void MsgBox(string title, string promptText)
        {

            try
            {
                MessageBox.Show(promptText, title);

                DMEEditor.AddLogMessage("Success", "Created Msgbox", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not create msgbox";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };

        }
        public BeepEnterprize.Vis.Module.DialogResult InputComboBox(string title, string promptText, List<string> itvalues, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            // TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            ComboBox combo = new ComboBox { Left = 50, Top = 50, Width = 400 };

            form.Text = title;
            label.Text = promptText;
            combo.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            combo.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            combo.Anchor = combo.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            foreach (string c in itvalues)
            {
                var t = combo.Items.Add(c);

            }
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, combo, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            BeepEnterprize.Vis.Module.DialogResult dialogResult = MapDialogResult(form.ShowDialog());
            value = combo.Text;
            return dialogResult;
        }
        public string DialogCombo(string text, List<object> comboSource, string DisplyMember, string ValueMember)
        {
            //comboSource = new DataTable();


            Form prompt = new Form();
            //prompt.RightToLeft = RightToLeft.Yes;
            prompt.Width = 500;
            prompt.Height = 200;
            Label textLabel = new Label() { Left = 350, Top = 20, Text = text };
            ComboBox combo = new ComboBox { Left = 50, Top = 50, Width = 400 };
            combo.DataSource = comboSource;
            combo.ValueMember = ValueMember;
            combo.DisplayMember = DisplyMember;
            Button confirmation = new Button() { Text = "Submit", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(combo);
            prompt.ShowDialog();

            return combo.SelectedValue.ToString();
        }
        public List<string> LoadFilesDialog(string exts, string dir, string filter)
        {
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog()
            {
                Title = "Browse Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = exts,
                Filter = filter,
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = dir


                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };

            openFileDialog1.Multiselect = true;
            BeepEnterprize.Vis.Module.DialogResult result = MapDialogResult(openFileDialog1.ShowDialog());

            return openFileDialog1.FileNames.ToList();
        }
        public string SelectFolderDialog()
        {
            string folderPath = string.Empty;
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = DMEEditor.ConfigEditor.Config.ProjectDataPath;
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ShowNewFolderButton = true;
            System.Windows.Forms.DialogResult result = folderBrowser.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = folderBrowser.SelectedPath;
                // ...
            }
            return folderPath;
        }
        public string LoadFileDialog(string exts, string dir,string filter)
        {
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog()
            {
                Title = "Browse Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = exts,
                Filter = filter,
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = dir


                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };
            openFileDialog1.InitialDirectory = dir;

            BeepEnterprize.Vis.Module.DialogResult result = MapDialogResult(openFileDialog1.ShowDialog());

            return openFileDialog1.FileName;
        }
        public string SaveFileDialog(string exts, string dir, string filter)
        {
            SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog()
            {
                Title = "Save File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = exts,
                Filter = filter,
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = dir


                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };
          

            BeepEnterprize.Vis.Module.DialogResult result = MapDialogResult(saveFileDialog1.ShowDialog());

            return saveFileDialog1.FileName;
        }
        #endregion
        #region "CRUD"
        public IErrorsInfo GenerateEntityonControl(string entityname, object record, int starttop, string datasourceid, TransActionType TranType, IPassedArgs passedArgs=null)
        {
            Control control = new Control();
            if (passedArgs.Objects.Where(c => c.Name == "BindingSource").Any())
            {
                EntityBindingSource = (BindingSource)passedArgs.Objects.Where(c => c.Name == "BindingSource").FirstOrDefault().obj;
            }
            if (passedArgs.Objects.Where(c => c.Name == "Control").Any())
            {
                control = (Control)passedArgs.Objects.Where(c => c.Name == "Control").FirstOrDefault().obj;
            }
            
            Dictionary<string, Control> controls = new Dictionary<string, Control>();
            ErrorsandMesseges = new ErrorsInfo();
            ErrorsandMesseges.Flag = Errors.Ok;
            TextBox t1 = new TextBox();
            EntityStructure TableCurrentEntity = new EntityStructure();
            DisplayField = null;
            if (record == null)
            {
                MessageBox.Show("Error", " record has no Data");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Message = "Error Table has no Data";
                return DMEEditor.ErrorObject;
            }

            IDataSource ds = DMEEditor.GetDataSource(datasourceid);
            List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == ds.DatasourceName)].DatasourceDefaults;
            TableCurrentEntity = ds.GetEntityStructure(entityname, false);
            Type enttype = ds.GetEntityType(entityname);
            var ti = Activator.CreateInstance(enttype);
            // ICustomTypeDescriptor, IEditableObject, IDataErrorInfo, INotifyPropertyChanged
            if (record.GetType().GetInterfaces().Contains(typeof(ICustomTypeDescriptor)))
            {
                DataRowView dv = (DataRowView)record;
                DataRow dr = dv.Row;
                foreach (EntityField col in TableCurrentEntity.Fields)
                {
                    // TrySetProperty<enttype>(ti, dr[col.fieldname], null);
                    if (dr[col.fieldname] != System.DBNull.Value)
                    {
                        System.Reflection.PropertyInfo PropAInfo = enttype.GetProperty(col.fieldname);
                        PropAInfo.SetValue(ti, dr[col.fieldname], null);
                    }else
                    {
                       
                        System.Reflection.PropertyInfo PropAInfo = enttype.GetProperty(col.fieldname);
                        PropAInfo.SetValue(ti, null, null);
                    }

                }


            }
            else
            {
                ti = record;
            }
          //  EntityBindingSource.Add(ti);
            //bindingsource.CurrentChanged += Bindingsource_CurrentChanged;
            //bindingsource.PositionChanged += Bindingsource_PositionChanged;
            //bindingsource.ListChanged += Bindingsource_ListChanged;
            // Create Filter Control
            // CreateFilterQueryGrid(entityname, TableCurrentEntity.Fields, null);
            //--- Get Max label size
            int maxlabelsize = 0;
            int maxDatasize = 0;
            foreach (EntityField col in TableCurrentEntity.Fields)
            {
                int x = getTextSize(col.fieldname);
                if (maxlabelsize < x)
                    maxlabelsize = x;
            }
            maxDatasize = control.Width - maxlabelsize - 20;
            try
            {
                var starth = starttop;

                TableCurrentEntity.Filters = new List<TheTechIdea.Beep.Report.AppFilter>();
                Control CurCTL=new Control();
                foreach (EntityField col in TableCurrentEntity.Fields)
                {
                    DefaultValue coldefaults = defaults.Where(o => o.propertyName == col.fieldname).FirstOrDefault();
                    if (coldefaults == null)
                    {
                        coldefaults = defaults.Where(o => col.fieldname.Contains(o.propertyName)).FirstOrDefault();
                    }
                    string coltype = col.fieldtype;
                    RelationShipKeys FK = TableCurrentEntity.Relations.Where(f => f.EntityColumnID == col.fieldname).FirstOrDefault();
                    //----------------------
                    Label l = new Label
                    {
                        Top = starth,
                        Left = 10,
                        AutoSize = false,
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = col.fieldname,
                        BackColor = Color.White,
                        ForeColor = Color.Red

                    };
                    l.Size = TextRenderer.MeasureText(col.fieldname, l.Font);
                    l.Height += 10;
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l.Width = maxlabelsize;
                    //---------------------

                    if (FK != null)
                    {
                        ComboBox cb = new ComboBox
                        {
                            Left = l.Left + l.Width + 10,
                            Top = starth
                        };
                       
                        cb.DataSource = GetDisplayLookup(datasourceid, FK.RelatedEntityID, FK.RelatedEntityColumnID, FK.EntityColumnID);
                        cb.DisplayMember = "DisplayField";
                        cb.ValueMember = FK.RelatedEntityColumnID;
                        cb.Width = maxDatasize;
                        cb.Height = l.Height;
                        cb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", EntityBindingSource, col.fieldname, true));
                        // cb.SelectedValueChanged += Cb_SelectedValueChanged;
                        cb.Anchor = AnchorStyles.Top;
                        control.Controls.Add(cb);
                        CurCTL = cb;
                        controls.Add(col.fieldname, cb);
                        starth = l.Bottom + 1;
                    }
                    else
                    {
                        switch (coltype)
                        {
                            case "System.DateTime":
                                DateTimePicker dt = new DateTimePicker
                                {
                                    Left = l.Left + l.Width + 10,
                                    Top = starth
                                };
                                 dt.DataBindings.Add(new System.Windows.Forms.Binding("Value", EntityBindingSource, col.fieldname, true));
                                dt.Width = maxDatasize;
                                dt.Height = l.Height;
                                //  dt.ValueChanged += Dt_ValueChanged;
                                dt.Anchor = AnchorStyles.Top;
                                control.Controls.Add(dt);
                                CurCTL = dt;
                                controls.Add(col.fieldname, dt);
                                break;
                            case "System.TimeSpan":
                                t1 = new TextBox
                                {
                                    Left = l.Left + l.Width + 10,
                                    Top = starth
                                };

                               t1.DataBindings.Add(new System.Windows.Forms.Binding("Text", EntityBindingSource, col.fieldname, true));
                                t1.TextAlign = HorizontalAlignment.Left;
                                t1.Width = maxDatasize;
                                t1.Height = l.Height;
                                control.Controls.Add(t1);
                                controls.Add(col.fieldname, t1);
                                //   t1.TextChanged += T_TextChanged;
                                //   t1.KeyPress += T_KeyPress;
                                CurCTL = t1;
                                t1.Anchor = AnchorStyles.Top;
                                break;
                            case "System.Boolean":
                                CheckBox ch1 = new CheckBox
                                {
                                    Left = l.Left + l.Width + 10,
                                    Top = starth
                                };

                                ch1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", EntityBindingSource, col.fieldname, true));
                                ch1.Text = "";
                                ch1.Width = maxDatasize;
                                ch1.Height = l.Height;
                               // ch1.CheckStateChanged += Ch1_CheckStateChanged; ;
                                ch1.Anchor = AnchorStyles.Top;
                                control.Controls.Add(ch1);
                                CurCTL = ch1;
                                controls.Add(col.fieldname, ch1);

                                break;
                            case "System.Char":
                                MyCheckBox ch2 = new MyCheckBox
                                {
                                    Left = l.Left + l.Width + 10,
                                    Top = starth
                                };

                                ch2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", EntityBindingSource, col.fieldname, true));
                                ch2.Text = "";
                                ch2.Width = maxDatasize;
                                ch2.Height = l.Height;
                                string[] v = coldefaults.propoertValue.Split(',');

                                if (coldefaults != null)
                                {
                                    ch2.TrueValue = v[0].ToCharArray()[0];
                                    ch2.FalseValue = v[1].ToCharArray()[0];
                                }
                                //ch2.CheckStateChanged += Ch1_CheckStateChanged; ;
                                ch2.Anchor = AnchorStyles.Top;
                                control.Controls.Add(ch2);
                                CurCTL = ch2;
                                controls.Add(col.fieldname, ch2);
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Decimal":
                            case "System.Double":
                            case "System.Single":
                            case "System.String":
                                if (TableCurrentEntity.Fields.Where(p => p.fieldname == col.fieldname).FirstOrDefault().Size1 > 1)
                                {
                                    t1 = new TextBox
                                    {
                                        Left = l.Left + l.Width + 10,
                                        Top = starth
                                    };

                                    t1.DataBindings.Add(new System.Windows.Forms.Binding("Text", EntityBindingSource, col.fieldname, true));
                                    t1.TextAlign = HorizontalAlignment.Left;
                                    t1.Width = maxDatasize;
                                    t1.Height = l.Height;

                                    //      t1.TextChanged += T_TextChanged;
                                    //      t1.KeyPress += T_KeyPress;
                                    CurCTL = t1;
                                    control.Controls.Add(t1);
                                    controls.Add(col.fieldname, t1);
                                    t1.Anchor = AnchorStyles.Top;
                                }
                                else
                                {
                                    ch2 = new MyCheckBox
                                    {
                                        Left = l.Left + l.Width + 10,
                                        Top = starth
                                    };

                                    ch2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", EntityBindingSource, col.fieldname, true));
                                    ch2.Text = "";
                                    ch2.Width = maxDatasize;
                                    ch2.Height = l.Height;



                                    if (coldefaults != null)
                                    {
                                        v = coldefaults.propoertValue.Split(',');
                                        ch2.TrueValue = v[0].ToCharArray()[0];
                                        ch2.FalseValue = v[1].ToCharArray()[0];
                                    }
                                    //      ch2.CheckStateChanged += Ch1_CheckStateChanged; ;
                                    CurCTL = ch2;
                                    control.Controls.Add(ch2);
                                    controls.Add(col.fieldname, ch2);
                                    ch2.Anchor = AnchorStyles.Top;
                                }
                                break;
                            default:
                                TextBox t = new TextBox();

                                t.Left = l.Left + l.Width + 10;
                                t.Top = starth;
                                t.DataBindings.Add(new System.Windows.Forms.Binding("Text", EntityBindingSource, col.fieldname, true));
                                t.TextAlign = HorizontalAlignment.Left;
                                t.Width = maxDatasize;
                                t.Height = l.Height;

                                //  t.TextChanged += T_TextChanged;
                                //   t.KeyPress += T_KeyPress;
                              
                                t.Anchor = AnchorStyles.Top;
                                CurCTL = t;
                                control.Controls.Add(t);
                                controls.Add(col.fieldname, t);
                                break;

                        }
                    }
                   
                    if (TableCurrentEntity.PrimaryKeys.Any(x => x.fieldname == col.fieldname))
                    {
                        if (TableCurrentEntity.Relations.Any(x => x.EntityColumnID == col.fieldname) && TranType != TransActionType.Insert)
                        {
                            CurCTL.Enabled = false;
                        }
                        if (col.IsAutoIncrement )
                        {
                            CurCTL.Enabled = false;
                        }

                    }
                   

                    l.Anchor = AnchorStyles.Top;
                    control.Controls.Add(l);

                    starth = l.Bottom + 1;
                    //this.databaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataConnectionsEntityBindingSource, "Database", true));

                }

            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Ex = ex;
                DMEEditor.Logger.WriteLog($"Error in Loading View ({ex.Message}) ");
            }
            return ErrorsandMesseges;
        }
        public void CreateEntityFilterControls( EntityStructure entityStructure, List<DefaultValue> dsdefaults, IPassedArgs passedArgs = null)
        {
            if (passedArgs.Objects.Where(i => i.Name == "FilterPanel").Any())
            {
                CrudFilterPanel = (Control)passedArgs.Objects.Where(c => c.Name == "FilterPanel").FirstOrDefault().obj;
            }
            CrudFilterPanel.Controls.Clear();
            BindingSource[] BindingData = new BindingSource[entityStructure.Fields.Count];
            int maxlabelsize = 0;
            int maxDatasize = 0;
            foreach (EntityField col in entityStructure.Fields)
            {
                int x = getTextSize(col.fieldname.ToUpper());
                if (maxlabelsize < x)
                    maxlabelsize = x;
            }
            maxDatasize = DisplayPanel.Width - maxlabelsize - 20;
            if (entityStructure.Filters != null)
            {
                entityStructure.Filters.Clear();
            }
            else
                entityStructure.Filters = new List<AppFilter>();
           
            List<string> FieldNames = new List<string>();
            var starth = 25;
            int startleft = maxlabelsize + 90;
            int valuewidth = 100;
            for (int i = 0; i <= entityStructure.Fields.Count - 1; i++)
            {
                AppFilter r = new AppFilter();
                r.FieldName = entityStructure.Fields[i].fieldname;
                r.Operator = null;
                r.FilterValue = null;
                r.FilterValue1 = null;
                r.valueType = entityStructure.Fields[i].fieldtype;
                entityStructure.Filters.Add(r);
                BindingData[i] = new BindingSource();
                BindingData[i].DataSource = r;
                FieldNames.Add(entityStructure.Fields[i].fieldname);
                EntityField col = entityStructure.Fields[i];
                try
                {
                    DefaultValue coldefaults = dsdefaults.Where(o => o.propertyName == col.fieldname).FirstOrDefault();
                    if (coldefaults == null)
                    {
                        coldefaults = dsdefaults.Where(o => col.fieldname.Contains(o.propertyName)).FirstOrDefault();
                    }
                    string coltype = col.fieldtype;
                    RelationShipKeys FK = entityStructure.Relations.Where(f => f.EntityColumnID == col.fieldname).FirstOrDefault();
                    //----------------------
                    Label l = new Label
                    {
                        Top = starth,
                        Left = 10,
                        AutoSize = false,
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = col.fieldname.ToUpper(),
                        BackColor = Color.White,
                        ForeColor = Color.Red

                    };
                    l.Size = TextRenderer.MeasureText(col.fieldname.ToUpper(), l.Font);
                    l.Height += 10;
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l.Width = maxlabelsize;
                    //---------------------
                    ComboBox cbcondition = new ComboBox
                    {
                        Left = l.Left + l.Width + 10,
                        Top = starth
                    };
                   
                    //cbcondition.DataSource = GetDisplayLookup(entityStructure.DataSourceID, FK.ParentEntityID, FK.ParentEntityColumnID, FK.EntityColumnID);
                    //cbcondition.DisplayMember = DisplayField;
                    //cbcondition.ValueMember = FK.ParentEntityColumnID;
                    cbcondition.DataSource = AddFilterTypes();
                    cbcondition.DisplayMember = "FilterDisplay";
                    cbcondition.ValueMember = "FilterValue";
                   // cbcondition.SelectedValueChanged += Cb_SelectedValueChanged;
                    cbcondition.Name = col.fieldname + "." + "Operator";
                    cbcondition.Width = 50;
                    cbcondition.Height = l.Height;
                    // cbcondition.SelectedText
                    cbcondition.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", BindingData[i], "Operator", true, DataSourceUpdateMode.OnPropertyChanged));
                    //  cbcondition.Anchor = AnchorStyles.Top;
                    CrudFilterPanel.Controls.Add(cbcondition);

                    if (FK != null)
                    {
                        ComboBox cb = new ComboBox
                        {
                            Left = startleft,
                            Top = starth
                        };
                    
                        cb.DataSource = GetDisplayLookup(entityStructure.DataSourceID, FK.RelatedEntityID, FK.RelatedEntityColumnID, FK.EntityColumnID);
                        cb.DisplayMember = "DisplayField";
                        cb.ValueMember = FK.RelatedEntityColumnID;
                        cb.Width = valuewidth;
                        cb.Height = l.Height;
                        cb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", BindingData[i], "FilterValue", true));
                        //  cb.SelectedValueChanged += Cb_SelectedValueChanged;
                        //cb.Anchor = AnchorStyles.Top;
                        CrudFilterPanel.Controls.Add(cb);
                        cb.Name = col.fieldname;
                        starth = l.Bottom + 1;
                    }
                    else
                    {
                        switch (coltype)
                        {
                            case "System.DateTime":
                                DateTimePicker dt = new DateTimePicker
                                {
                                    Left = startleft,
                                    Top = starth
                                };
                                dt.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue", true));

                                dt.Width = valuewidth;
                                dt.Height = l.Height;
                            //    dt.ValueChanged += Dt_ValueChanged;
                                //     dt.Anchor = AnchorStyles.Top;
                                dt.Tag = i;
                                dt.Format = DateTimePickerFormat.Short;
                                dt.Name = "From" + "." + col.fieldname;
                                CrudFilterPanel.Controls.Add(dt);
                                DateTimePicker dt1 = new DateTimePicker
                                {
                                    Left = dt.Left + 10 + dt.Width,
                                    Top = starth
                                };
                              
                                dt1.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue1", true));

                                dt1.Width = valuewidth;
                                dt1.Height = l.Height;
                                dt1.Format = DateTimePickerFormat.Short;
                             //   dt1.ValueChanged += Dt_ValueChanged;
                                //     dt.Anchor = AnchorStyles.Top;
                                dt1.Tag = i;
                                dt1.Name = "From" + "." + col.fieldname;
                                CrudFilterPanel.Controls.Add(dt1);
                                break;
                            case "System.TimeSpan":
                                TextBox t1 = new TextBox
                                {
                                    Left = startleft,
                                    Top = starth
                                };

                                t1.DataBindings.Add(new System.Windows.Forms.Binding("Text", BindingData[i], "FilterValue", true));
                                t1.TextAlign = HorizontalAlignment.Left;
                                t1.Width = valuewidth;
                                t1.Height = l.Height;

                                t1.Tag = i;
                               // t1.TextChanged += T_TextChanged;
                                //  t1.KeyPress += T_KeyPress;
                                //     t1.Anchor = AnchorStyles.Top;
                                t1.Name = col.fieldname;
                                CrudFilterPanel.Controls.Add(t1);
                                break;
                            case "System.Boolean":
                                CheckBox ch1 = new CheckBox
                                {
                                    Left = startleft,
                                    Top = starth
                                };

                                ch1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", BindingData[i], "FilterValue", true));
                                ch1.Text = "";
                                ch1.Width = valuewidth;
                                ch1.Height = l.Height;
                               // ch1.CheckStateChanged += Ch1_CheckStateChanged; ;
                                //       ch1.Anchor = AnchorStyles.Top;
                                ch1.Tag = i;
                                ch1.Name = col.fieldname;
                                CrudFilterPanel.Controls.Add(ch1);


                                break;
                            case "System.Char":
                                MyCheckBox ch2 = new MyCheckBox
                                {
                                    Left = startleft,
                                    Top = starth
                                };

                                ch2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", BindingData[i], "FilterValue", true));
                                ch2.Text = "";
                                ch2.Width = valuewidth;
                                ch2.Height = l.Height;
                                string[] v = coldefaults.propoertValue.Split(',');

                                if (coldefaults != null)
                                {
                                    ch2.TrueValue = v[0].ToCharArray()[0];
                                    ch2.FalseValue = v[1].ToCharArray()[0];
                                }
                              //  ch2.CheckStateChanged += Ch1_CheckStateChanged; ;
                                //   ch2.Anchor = AnchorStyles.Top;
                                ch2.Tag = i;
                                ch2.Name = col.fieldname;
                                CrudFilterPanel.Controls.Add(ch2);

                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Decimal":
                            case "System.Double":
                            case "System.Single":
                                NumericUpDown t3 = new NumericUpDown();

                                t3.Left = startleft;
                                t3.Top = starth;
                                t3.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue", true));
                                t3.TextAlign = HorizontalAlignment.Left;
                                t3.Width = valuewidth;
                                t3.Height = l.Height;
                                t3.Tag = i;
                                t3.Minimum = 0;
                              //  t3.TextChanged += T_TextChanged;
                                //t.KeyPress += T_KeyPress;
                                //if (entityStructure.PrimaryKeys.Where(x => x.fieldname == col.fieldname).FirstOrDefault() != null)
                                //{
                                //    t3.Enabled = false;
                                //}
                                CrudFilterPanel.Controls.Add(t3);

                                NumericUpDown t2 = new NumericUpDown();
                                t2.Left = t3.Left + t3.Width + 10;
                                t2.Top = starth;
                                t2.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue1", true));
                                t2.TextAlign = HorizontalAlignment.Left;
                                t2.Width = valuewidth;
                                t2.Height = l.Height;
                                t2.Tag = i;
                                t2.Maximum = 99999;
                             //   t2.TextChanged += T_TextChanged;
                                //t.KeyPress += T_KeyPress;
                                //if (entityStructure.PrimaryKeys.Where(x => x.fieldname == col.fieldname).FirstOrDefault() != null)
                                //{
                                //    t2.Enabled = false;
                                //}
                                //   t.Anchor = AnchorStyles.Top;

                                CrudFilterPanel.Controls.Add(t2);
                                //   t.Anchor = AnchorStyles.Top;
                                break;

                            case "System.String":
                                if (entityStructure.Fields.Where(p => p.fieldname == col.fieldname).FirstOrDefault().Size1 != 1)
                                {
                                    t1 = new TextBox
                                    {
                                        Left = startleft,
                                        Top = starth
                                    };

                                    t1.DataBindings.Add(new System.Windows.Forms.Binding("Text", BindingData[i], "FilterValue", true));
                                    t1.TextAlign = HorizontalAlignment.Left;
                                    t1.Width = valuewidth;
                                    t1.Height = l.Height;

                              //      t1.TextChanged += T_TextChanged;
                                    //  t1.KeyPress += T_KeyPress;
                                    //if (entityStructure.PrimaryKeys.Any(x => x.fieldname == col.fieldname))
                                    //{
                                    //    if (entityStructure.Relations.Any(x => x.EntityColumnID == col.fieldname))
                                    //    {
                                    //        t1.Enabled = false;
                                    //    }

                                    //}
                                    CrudFilterPanel.Controls.Add(t1);
                                    t1.Tag = i;
                                    //      t1.Anchor = AnchorStyles.Top;
                                }
                                else
                                {
                                    ch2 = new MyCheckBox
                                    {
                                        Left = startleft,
                                        Top = starth
                                    };

                                    ch2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", BindingData[i], "FilterValue", true));
                                    ch2.Text = "";
                                    ch2.Width = valuewidth;
                                    ch2.Height = l.Height;
                                    ch2.Tag = i;


                                    if (coldefaults != null)
                                    {
                                        v = coldefaults.propoertValue.Split(',');
                                        ch2.TrueValue = v[0].ToCharArray()[0];
                                        ch2.FalseValue = v[1].ToCharArray()[0];
                                    }
                                    // ch2.CheckStateChanged += Ch1_CheckStateChanged; ;

                                    CrudFilterPanel.Controls.Add(ch2);

                                    //     ch2.Anchor = AnchorStyles.Top;
                                }
                                break;
                            default:
                                TextBox t = new TextBox();

                                t.Left = startleft;
                                t.Top = starth;
                                t.DataBindings.Add(new System.Windows.Forms.Binding("Text", BindingData[i], "FilterValue", true));
                                t.TextAlign = HorizontalAlignment.Left;
                                t.Width = valuewidth;
                                t.Height = l.Height;
                                t.Tag = i;
                             //   t.TextChanged += T_TextChanged;
                                //t.KeyPress += T_KeyPress;
                                //if (entityStructure.PrimaryKeys.Where(x => x.fieldname == col.fieldname).FirstOrDefault() != null)
                                //{
                                //    t.Enabled = false;
                                //}
                                //   t.Anchor = AnchorStyles.Top;

                                CrudFilterPanel.Controls.Add(t);

                                break;

                        }
                    }
                    // l.Anchor = AnchorStyles.Top;
                    CrudFilterPanel.Controls.Add(l);
                    starth = l.Bottom + 1;

                }
                catch (Exception ex)
                {

                   // Logger.WriteLog($"Error in Loading View ({ex.Message}) ");
                }

            }


        }
        public void CreateFieldsFilterControls(List<EntityField> Fields, List<AppFilter> Filters, List<DefaultValue> dsdefaults, IPassedArgs passedArgs = null)
        {
            if (passedArgs.Objects.Where(i => i.Name == "FilterPanel").Any())
            {
                CrudFilterPanel = (Control)passedArgs.Objects.Where(c => c.Name == "FilterPanel").FirstOrDefault().obj;
            }
            CrudFilterPanel.Controls.Clear();
            BindingSource[] BindingData = new BindingSource[Fields.Count];
            int maxlabelsize = 0;
            int maxDatasize = 0;
            foreach (EntityField col in Fields)
            {
                int x = getTextSize(col.fieldname.ToUpper());
                if (maxlabelsize < x)
                    maxlabelsize = x;
            }
            maxDatasize = CrudFilterPanel.Width - maxlabelsize - 20;
            if (Filters != null)
            {
                Filters.Clear();
            }
            else
                Filters = new List<AppFilter>();

            List<string> FieldNames = new List<string>();
          
            CreateFilterFields(maxlabelsize, BindingData, Fields, Filters, dsdefaults, passedArgs);


        }
        private void CreateFilterFields(int maxlabelsize,BindingSource[] BindingData,List<EntityField> Fields, List<AppFilter> Filters, List<DefaultValue> dsdefaults, IPassedArgs passedArgs = null)
        {
            int labelleft = 100;
            var starth = 25;
            int startleft = labelleft + maxlabelsize + 90;
            int valuewidth = 100;
            for (int i = 0; i <= Fields.Count - 1; i++)
            {
                AppFilter r = new AppFilter();
                r.FieldName = Fields[i].fieldname;
                r.Operator = null;
                r.FilterValue = null;
                r.FilterValue1 = null;
                r.valueType = Fields[i].fieldtype;
                Filters.Add(r);
                BindingData[i] = new BindingSource();
                BindingData[i].DataSource = r;
               // FieldNames.Add(Fields[i].fieldname);
                EntityField col = Fields[i];
                try
                {
                    DefaultValue coldefaults = dsdefaults.Where(o => o.propertyName == col.fieldname).FirstOrDefault();
                    if (coldefaults == null)
                    {
                        coldefaults = dsdefaults.Where(o => col.fieldname.Contains(o.propertyName)).FirstOrDefault();
                    }
                    string coltype = col.fieldtype;
                    //RelationShipKeys FK = Relations.Where(f => f.EntityColumnID == col.fieldname).FirstOrDefault();
                    //----------------------
                    Label l = new Label
                    {
                        Top = starth,
                        Left = labelleft,
                        AutoSize = false,
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = col.fieldname.ToUpper(),
                        BackColor = Color.White,
                        ForeColor = Color.Red

                    };
                    l.Size = TextRenderer.MeasureText(col.fieldname.ToUpper(), l.Font);
                    l.Height += 10;
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l.Width = maxlabelsize;
                    //---------------------
                    ComboBox cbcondition = new ComboBox
                    {
                        Left = l.Left + l.Width + 10,
                        Top = starth
                    };
                    //string DisplayField = FK.EntityColumnID;
                    //cbcondition.DataSource = Visutil.controlEditor.GetDisplayLookup(ds.DatasourceName, FK.ParentEntityID, FK.ParentEntityColumnID);
                    //cbcondition.DisplayMember = DisplayField;
                    //cbcondition.ValueMember = FK.ParentEntityColumnID;
                    cbcondition.DataSource = AddFilterTypes();
                    cbcondition.DisplayMember = "FilterDisplay";
                    cbcondition.ValueMember = "FilterValue";
                    // cbcondition.SelectedValueChanged += Cb_SelectedValueChanged;
                    cbcondition.Name = col.fieldname + "." + "Operator";
                    cbcondition.Width = 50;
                    cbcondition.Height = l.Height;
                    // cbcondition.SelectedText
                    cbcondition.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", BindingData[i], "Operator", true, DataSourceUpdateMode.OnPropertyChanged));
                    //  cbcondition.Anchor = AnchorStyles.Top;
                    CrudFilterPanel.Controls.Add(cbcondition);


                    switch (coltype)
                    {
                        case "System.DateTime":
                            DateTimePicker dt = new DateTimePicker
                            {
                                Left = startleft,
                                Top = starth
                            };
                            dt.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue", true));

                            dt.Width = valuewidth;
                            dt.Height = l.Height;
                            //    dt.ValueChanged += Dt_ValueChanged;
                            //     dt.Anchor = AnchorStyles.Top;
                            dt.Tag = i;
                            dt.Format = DateTimePickerFormat.Short;
                            dt.Name = "From" + "." + col.fieldname;
                            CrudFilterPanel.Controls.Add(dt);
                            DateTimePicker dt1 = new DateTimePicker
                            {
                                Left = dt.Left + 10 + dt.Width,
                                Top = starth
                            };
                            dt1.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue1", true));

                            dt1.Width = valuewidth;
                            dt1.Height = l.Height;
                            dt1.Format = DateTimePickerFormat.Short;
                            //   dt1.ValueChanged += Dt_ValueChanged;
                            //     dt.Anchor = AnchorStyles.Top;
                            dt1.Tag = i;
                            dt1.Name = "From" + "." + col.fieldname;
                            CrudFilterPanel.Controls.Add(dt1);
                            break;
                        case "System.TimeSpan":
                            TextBox t1 = new TextBox
                            {
                                Left = startleft,
                                Top = starth
                            };

                            t1.DataBindings.Add(new System.Windows.Forms.Binding("Text", BindingData[i], "FilterValue", true));
                            t1.TextAlign = HorizontalAlignment.Left;
                            t1.Width = valuewidth;
                            t1.Height = l.Height;

                            t1.Tag = i;
                            // t1.TextChanged += T_TextChanged;
                            //  t1.KeyPress += T_KeyPress;
                            //     t1.Anchor = AnchorStyles.Top;
                            t1.Name = col.fieldname;
                            CrudFilterPanel.Controls.Add(t1);
                            break;
                        case "System.Boolean":
                            CheckBox ch1 = new CheckBox
                            {
                                Left = startleft,
                                Top = starth
                            };

                            ch1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", BindingData[i], "FilterValue", true));
                            ch1.Text = "";
                            ch1.Width = valuewidth;
                            ch1.Height = l.Height;
                            // ch1.CheckStateChanged += Ch1_CheckStateChanged; ;
                            //       ch1.Anchor = AnchorStyles.Top;
                            ch1.Tag = i;
                            ch1.Name = col.fieldname;
                            CrudFilterPanel.Controls.Add(ch1);


                            break;
                        case "System.Char":
                            MyCheckBox ch2 = new MyCheckBox
                            {
                                Left = startleft,
                                Top = starth
                            };

                            ch2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", BindingData[i], "FilterValue", true));
                            ch2.Text = "";
                            ch2.Width = valuewidth;
                            ch2.Height = l.Height;
                            string[] v = coldefaults.propoertValue.Split(',');

                            if (coldefaults != null)
                            {
                                ch2.TrueValue = v[0].ToCharArray()[0];
                                ch2.FalseValue = v[1].ToCharArray()[0];
                            }
                            //  ch2.CheckStateChanged += Ch1_CheckStateChanged; ;
                            //   ch2.Anchor = AnchorStyles.Top;
                            ch2.Tag = i;
                            ch2.Name = col.fieldname;
                            CrudFilterPanel.Controls.Add(ch2);

                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Decimal":
                        case "System.Double":
                        case "System.Single":
                            NumericUpDown t3 = new NumericUpDown();

                            t3.Left = startleft;
                            t3.Top = starth;
                            t3.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue", true));
                            t3.TextAlign = HorizontalAlignment.Left;
                            t3.Width = valuewidth;
                            t3.Height = l.Height;
                            t3.Tag = i;
                            t3.Minimum = 0;
                            //  t3.TextChanged += T_TextChanged;
                            //t.KeyPress += T_KeyPress;

                            CrudFilterPanel.Controls.Add(t3);

                            NumericUpDown t2 = new NumericUpDown();
                            t2.Left = t3.Left + t3.Width + 10;
                            t2.Top = starth;
                            t2.DataBindings.Add(new System.Windows.Forms.Binding("Value", BindingData[i], "FilterValue1", true));
                            t2.TextAlign = HorizontalAlignment.Left;
                            t2.Width = valuewidth;
                            t2.Height = l.Height;
                            t2.Tag = i;
                            t2.Maximum = 99999;
                            //   t2.TextChanged += T_TextChanged;
                            //t.KeyPress += T_KeyPress;

                            //   t.Anchor = AnchorStyles.Top;

                            CrudFilterPanel.Controls.Add(t2);
                            //   t.Anchor = AnchorStyles.Top;
                            break;

                        case "System.String":
                            if (Fields.Where(p => p.fieldname == col.fieldname).FirstOrDefault().Size1 != 1)
                            {
                                t1 = new TextBox
                                {
                                    Left = startleft,
                                    Top = starth
                                };

                                t1.DataBindings.Add(new System.Windows.Forms.Binding("Text", BindingData[i], "FilterValue", true));
                                t1.TextAlign = HorizontalAlignment.Left;
                                t1.Width = valuewidth;
                                t1.Height = l.Height;

                                //      t1.TextChanged += T_TextChanged;
                                //  t1.KeyPress += T_KeyPress;

                                CrudFilterPanel.Controls.Add(t1);
                                t1.Tag = i;
                                //      t1.Anchor = AnchorStyles.Top;
                            }
                            else
                            {
                                ch2 = new MyCheckBox
                                {
                                    Left = startleft,
                                    Top = starth
                                };

                                ch2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", BindingData[i], "FilterValue", true));
                                ch2.Text = "";
                                ch2.Width = valuewidth;
                                ch2.Height = l.Height;
                                ch2.Tag = i;


                                if (coldefaults != null)
                                {
                                    v = coldefaults.propoertValue.Split(',');
                                    ch2.TrueValue = v[0].ToCharArray()[0];
                                    ch2.FalseValue = v[1].ToCharArray()[0];
                                }
                                // ch2.CheckStateChanged += Ch1_CheckStateChanged; ;

                                CrudFilterPanel.Controls.Add(ch2);

                                //     ch2.Anchor = AnchorStyles.Top;
                            }
                            break;
                        default:
                            TextBox t = new TextBox();

                            t.Left = startleft;
                            t.Top = starth;
                            t.DataBindings.Add(new System.Windows.Forms.Binding("Text", BindingData[i], "FilterValue", true));
                            t.TextAlign = HorizontalAlignment.Left;
                            t.Width = valuewidth;
                            t.Height = l.Height;
                            t.Tag = i;
                            //   t.TextChanged += T_TextChanged;
                            //t.KeyPress += T_KeyPress;

                            //   t.Anchor = AnchorStyles.Top;

                            CrudFilterPanel.Controls.Add(t);

                            break;

                    }

                    // l.Anchor = AnchorStyles.Top;
                    CrudFilterPanel.Controls.Add(l);
                    starth = l.Bottom + 1;

                }
                catch (Exception ex)
                {

                    // Logger.WriteLog($"Error in Loading View ({ex.Message}) ");
                }

            }

        }
        #endregion
        #region "util"
        public List<FilterType> AddFilterTypes()
        {
            //{ null, "=", ">=", "<=", ">", "<", "Like", "Between" }
            List<FilterType> lsop = new List<FilterType>();
            FilterType filterType = new FilterType("");
            lsop.Add(filterType);

            filterType = new FilterType("=");
            lsop.Add(filterType);

            filterType = new FilterType(">=");
            lsop.Add(filterType);

            filterType = new FilterType("<=");
            lsop.Add(filterType);
            filterType = new FilterType(">");
            lsop.Add(filterType);

            filterType = new FilterType("<");
            lsop.Add(filterType);

            filterType = new FilterType("like");
            lsop.Add(filterType);

            filterType = new FilterType("Between");
            lsop.Add(filterType);
            return lsop;

        }
        private System.Windows.Forms.DialogResult MapDialogResult(BeepEnterprize.Vis.Module.DialogResult dialogResult)
        {
            System.Windows.Forms.DialogResult retval = System.Windows.Forms.DialogResult.None;
            switch (dialogResult)
            {

                case BeepEnterprize.Vis.Module.DialogResult.None:
                    retval = System.Windows.Forms.DialogResult.None;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.OK:
                    retval = System.Windows.Forms.DialogResult.OK;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.Cancel:
                    retval = System.Windows.Forms.DialogResult.Cancel;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.Abort:
                    retval = System.Windows.Forms.DialogResult.Abort;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.Retry:
                    retval = System.Windows.Forms.DialogResult.Retry;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.Ignore:
                    retval = System.Windows.Forms.DialogResult.Ignore;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.Yes:
                    retval = System.Windows.Forms.DialogResult.Yes;
                    break;
                case BeepEnterprize.Vis.Module.DialogResult.No:
                    retval = System.Windows.Forms.DialogResult.No;
                    break;
                default:
                    retval = System.Windows.Forms.DialogResult.None;
                    break;
            }
            return retval;
        }
        private BeepEnterprize.Vis.Module.DialogResult MapDialogResult(System.Windows.Forms.DialogResult dialogResult)
        {
            BeepEnterprize.Vis.Module.DialogResult retval = BeepEnterprize.Vis.Module.DialogResult.None;
            switch (dialogResult)
            {

                case System.Windows.Forms.DialogResult.None:
                    retval = BeepEnterprize.Vis.Module.DialogResult.None;
                    break;
                case System.Windows.Forms.DialogResult.OK:
                    retval = BeepEnterprize.Vis.Module.DialogResult.OK;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    retval = BeepEnterprize.Vis.Module.DialogResult.Cancel;
                    break;
                case System.Windows.Forms.DialogResult.Abort:
                    retval = BeepEnterprize.Vis.Module.DialogResult.Abort;
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    retval = BeepEnterprize.Vis.Module.DialogResult.Retry;
                    break;
                case System.Windows.Forms.DialogResult.Ignore:
                    retval = BeepEnterprize.Vis.Module.DialogResult.Ignore;
                    break;
                case System.Windows.Forms.DialogResult.Yes:
                    retval = BeepEnterprize.Vis.Module.DialogResult.Yes;
                    break;
                case System.Windows.Forms.DialogResult.No:
                    retval = BeepEnterprize.Vis.Module.DialogResult.No;
                    break;
                default:
                    retval = BeepEnterprize.Vis.Module.DialogResult.None;
                    break;
            }
            return retval;
        }
        public int getTextSize(string text)
        {
            Font font = new Font("Courier New", 10.0F);
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString(text, font);
            return Convert.ToInt32(size.Width);
        }
        public object GetDisplayLookup(string datasourceid, string Parententityname, string ParentKeyField,string EntityField)
        {
            object retval=null;
            try
            {
                if (Parententityname != null)
                {
                    IDataSource ds = DMEEditor.GetDataSource(datasourceid);
                    EntityStructure ent = ds.GetEntityStructure(Parententityname, false);
                    DisplayField = null;
                    // bool found = true;
                    // int i = 0;
                    List<DefaultValue> defaults = ds.Dataconnection.ConnectionProp.DatasourceDefaults.Where(o => o.propertyType == DefaultValueType.DisplayLookup).ToList();
                    List<string> fields = ent.Fields.Select(u => u.EntityName).ToList();
                    if (defaults != null)
                    {
                        DefaultValue defaultValue = defaults.Where(p => p.propertyName.Equals(EntityField, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                        if (defaultValue != null)
                        {
                            DisplayField = defaultValue.propoertValue;
                        }

                    }
                    if (string.IsNullOrWhiteSpace(DisplayField) || string.IsNullOrEmpty(DisplayField))
                    {
                        DisplayField = ent.Fields.Where(r => r.fieldname.Contains("NAME")).Select(u => u.fieldname).FirstOrDefault();
                    }
                    if (string.IsNullOrWhiteSpace(DisplayField) || string.IsNullOrEmpty(DisplayField))
                    {
                        DisplayField = ParentKeyField;
                    }
                    string qrystr = "select " + DisplayField + " as DisplayField," + ParentKeyField + "  from " + Parententityname;


                    retval = ds.RunQuery(qrystr);
                }
               

                return retval;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool ShowAlert()
        {
            throw new NotImplementedException();
        }

        public void ShowMessege()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
