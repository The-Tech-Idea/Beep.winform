using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.Controls
{
    [AddinAttribute(Caption = "GridView", Name = "BeepGridView", misc = "BeepGridView", addinType = AddinType.Class, iconimage = "GridApplication.png")]
    public class BeepGridView : IAppComponent, IBeepControlInterface
    {

        public BeepGridView()
        {
            ID = new Guid().ToString();
            ComponentType = (new uc_BeepGrid()).GetType().AssemblyQualifiedName;
            IsContainer = false;
            IsTableView = true;

        }
        public string ID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public PanelControl Panelcontrol { get; set; }

        [JsonIgnore]
        public DMEEditor DMEEditor { get; set; }
        [JsonIgnore]
        public ScreenDesigner ScreenDesigner { get; set; }
        public bool IsContainer { get; set; } = true;
        public bool IsTableView { get; set; } = false;
        uc_BeepGrid beepGrid;
        DataGridView gridView;
        private DataGridViewCell clickedCell;
        public IErrorsInfo Bind(IPassedArgs args)
        {
            beepGrid = (uc_BeepGrid)Panelcontrol.BeepControl;
            gridView = beepGrid.dataGridView1;
            return DMEEditor.ErrorObject;

        }

        public IErrorsInfo ChangeVisual(IPassedArgs args)
        {

            beepGrid = (uc_BeepGrid)Panelcontrol.BeepControl;

            gridView = beepGrid.dataGridView1;

            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo Init(IPassedArgs args)
        {

            beepGrid = (uc_BeepGrid)Panelcontrol.BeepControl;
            gridView = beepGrid.dataGridView1;
           // beepGrid.Size = new System.Drawing.Size(200, 100);
            gridView.CellFormatting += dataGridView1_CellFormatting;
            StyleGrid(gridView);
            gridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            return DMEEditor.ErrorObject;

        }

        public IErrorsInfo Remove(PanelControl control)
        {
            return DMEEditor.ErrorObject;
        }
        private void StyleGrid(DataGridView dataGridView1)
        {


            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // Set property values appropriate for read-only display and 
            // limited interactivity. 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Set the selection background color for all the cells.
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows. 
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            // Set the row and column header styles.
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;
        }
        // Changes the foreground color of cells in the "Ratings" column 
        // depending on the number of stars. 
        private void dataGridView1_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gridView.Columns["Rating"].Index
                && e.Value != null)
            {
                switch (e.Value.ToString().Length)
                {
                    case 1:
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case 2:
                        e.CellStyle.SelectionForeColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Yellow;
                        break;
                    case 3:
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case 4:
                        e.CellStyle.SelectionForeColor = Color.Blue;
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                }
            }
        }

    }
}
