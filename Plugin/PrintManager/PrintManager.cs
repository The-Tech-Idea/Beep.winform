using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.DataManagment_Engine.Addin;
using TheTechIdea.PrintManagers;
using TheTechIdea.Util;

namespace PrintManager
{
    [AddinAttribute(Caption = "Print Manager", Name = "PrintManager", misc = "PrintManager", addinType = AddinType.Class)]
    public class PrintManager : IPrintManager
    {
        public PrintManager(IDMEEditor pDMEEditor)
        {
            DMEEditor = pDMEEditor;
           // printPreviewDialog1.Load += PrintPreviewDialog1_Load;
        }

       

        private DataGridPrinting dataGridPrinting;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public IDMEEditor DMEEditor { get ; set ; }
        public string Title { get; set ; }

        public IErrorsInfo Print<T>(T obj)
        {
            try
            {

             //   dataGridPrinting = new DataGridPrinting(obj, printDocument1, dataSet11.Customers);
            }
            catch (Exception)
            {

                throw;
            }
            return DMEEditor.ErrorObject;
        }

        public IErrorsInfo Print(IAppDefinition ReportDef)
        {
            throw new NotImplementedException();
        }

        public IErrorsInfo PrintList<T>(List<T> ls)
        {
            throw new NotImplementedException();
        }

        public IErrorsInfo PrintTable(DataTable dataTable)
        {
            throw new NotImplementedException();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
           // DrawTopLabel(g);
            bool more = dataGridPrinting.DrawDataGrid(g);
            if (more == true)
            {
                e.HasMorePages = true;
                dataGridPrinting.PageNumber++;
            }
        }

        //void DrawTopLabel(Graphics g)
        //{
        //    int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;

        //    g.FillRectangle(new SolidBrush(label1.BackColor), label1.Location.X, label1.Location.Y + TopMargin, label1.Size.Width, label1.Size.Height);
        //    g.DrawString(Title, Title.Font, new SolidBrush(label1.ForeColor), label1.Location.X + 50, label1.Location.Y + TopMargin, new StringFormat());
        //}
      
        //private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        //{
        //    printPreviewDialog1.Bounds = ClientRectangle;
        //}
    }
}
