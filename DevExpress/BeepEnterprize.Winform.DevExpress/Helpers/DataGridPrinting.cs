using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;

namespace TheTechIdea.PrintManagers
{
    public class DataGridPrinting
    {
        private PrintDocument ThePrintDocument;
        private DataTable TheTable;
        private DataGridView TheDataGrid;

        //private PrintDialog printDialog1;
        
        private PrintPreviewDialog printPreviewDialog1;

        public int RowCount = 0;  // current count of rows;
        private const int kVerticalCellLeeway = 10;
        public int PageNumber = 1;
        public ArrayList Lines = new ArrayList();

        int PageWidth;
        int PageHeight;
        int TopMargin;
        int BottomMargin;

        private BeepForm form = new BeepForm();
        public Label Title { get; set; }=new Label();

        public DataGridPrinting(string pTitle,DataGridView aGrid,  DataTable aTable)
        {
            //
            // TODO: Add constructor logic here
            //
            TheDataGrid = aGrid;
            TheTable = aTable;
            Title.Text = pTitle;
            ThePrintDocument=new PrintDocument();
            printPreviewDialog1=new PrintPreviewDialog();
            printPreviewDialog1.Document = ThePrintDocument;
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
            TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
            BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
            printPreviewDialog1.Load += PrintPreviewDialog1_Load;
            ThePrintDocument.PrintPage += ThePrintDocument_PrintPage;
        }
        private void ThePrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawTopLabel(g);
            bool more = DrawDataGrid(g);
            if (more == true)
            {
                e.HasMorePages = true;
                PageNumber++;
            }
        }
        private void DrawTopLabel(Graphics g)
        {
            int TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;

            g.FillRectangle(new SolidBrush(Title.BackColor), Title.Location.X, Title.Location.Y + TopMargin, Title.Size.Width, Title.Size.Height);
            g.DrawString(Title.Text, Title.Font, new SolidBrush(Title.ForeColor), Title.Location.X + 50, Title.Location.Y + TopMargin, new StringFormat());
        }
        public void Print()
        {
           
            PageNumber = 1;
            RowCount = 0;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
            }
        }
        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Bounds = form.ClientRectangle;
        }
        public void DrawHeader(Graphics g)
        {
            SolidBrush ForeBrush = new SolidBrush(TheDataGrid.ColumnHeadersDefaultCellStyle.ForeColor);
            SolidBrush BackBrush = new SolidBrush(TheDataGrid.ColumnHeadersDefaultCellStyle.BackColor);
            Pen TheLinePen = new Pen(TheDataGrid.GridColor, 1);
            StringFormat cellformat = new StringFormat();
            cellformat.Trimming = StringTrimming.EllipsisCharacter;
            cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;



            int columnwidth = PageWidth / TheTable.Columns.Count;

            int initialRowCount = RowCount;

            // draw the table header
            float startxposition = TheDataGrid.Location.X;
            RectangleF nextcellbounds = new RectangleF(0, 0, 0, 0);

            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);

            HeaderBounds.X = TheDataGrid.Location.X;
            HeaderBounds.Y = TheDataGrid.Location.Y + TopMargin + (RowCount - initialRowCount) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);
            HeaderBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
            HeaderBounds.Width = PageWidth;

            g.FillRectangle(BackBrush, HeaderBounds);

            for (int k = 0; k < TheTable.Columns.Count; k++)
            {
                string nextcolumn = TheTable.Columns[k].ToString();
                RectangleF cellbounds = new RectangleF(startxposition, TheDataGrid.Location.Y + TopMargin + (RowCount - initialRowCount) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway),
                    columnwidth,
                    TheDataGrid.ColumnHeadersDefaultCellStyle.Font.SizeInPoints + kVerticalCellLeeway);
                nextcellbounds = cellbounds;

                if (startxposition + columnwidth <= PageWidth)
                {
                    g.DrawString(nextcolumn, TheDataGrid.ColumnHeadersDefaultCellStyle.Font, ForeBrush, cellbounds, cellformat);
                }

                startxposition = startxposition + columnwidth;

            }

            if (TheDataGrid.CellBorderStyle !=  DataGridViewCellBorderStyle.None)
                g.DrawLine(TheLinePen, TheDataGrid.Location.X, nextcellbounds.Bottom, PageWidth, nextcellbounds.Bottom);
        }
        public bool DrawRows(Graphics g)
        {
            int lastRowBottom = TopMargin;

            try
            {
                SolidBrush ForeBrush = new SolidBrush(TheDataGrid.ForeColor);
                SolidBrush BackBrush = new SolidBrush(TheDataGrid.BackColor);
                SolidBrush AlternatingBackBrush = new SolidBrush(TheDataGrid.AlternatingRowsDefaultCellStyle.ForeColor);
                Pen TheLinePen = new Pen(TheDataGrid.GridColor, 1);
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
                int columnwidth = PageWidth / TheTable.Columns.Count;

                int initialRowCount = RowCount;

                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);

                // draw vertical lines




                // draw the rows of the table
                for (int i = initialRowCount; i < TheTable.Rows.Count; i++)
                {
                    DataRow dr = TheTable.Rows[i];
                    int startxposition = TheDataGrid.Location.X;

                    RowBounds.X = TheDataGrid.Location.X;
                    RowBounds.Y = TheDataGrid.Location.Y + TopMargin + ((RowCount - initialRowCount) + 1) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);
                    RowBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
                    RowBounds.Width = PageWidth;
                    Lines.Add(RowBounds.Bottom);

                    if (i % 2 == 0)
                    {
                        g.FillRectangle(BackBrush, RowBounds);
                    }
                    else
                    {
                        g.FillRectangle(AlternatingBackBrush, RowBounds);
                    }


                    for (int j = 0; j < TheTable.Columns.Count; j++)
                    {
                        RectangleF cellbounds = new RectangleF(startxposition,
                            TheDataGrid.Location.Y + TopMargin + ((RowCount - initialRowCount) + 1) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway),
                            columnwidth,
                            TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);


                        if (startxposition + columnwidth <= PageWidth)
                        {
                            g.DrawString(dr[j].ToString(), TheDataGrid.Font, ForeBrush, cellbounds, cellformat);
                            lastRowBottom = (int)cellbounds.Bottom;
                        }

                        startxposition = startxposition + columnwidth;
                    }

                    RowCount++;

                    if (RowCount * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway) > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                    {
                        DrawHorizontalLines(g, Lines);
                        DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
                        return true;
                    }


                }

                DrawHorizontalLines(g, Lines);
                DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }
        void DrawHorizontalLines(Graphics g, ArrayList lines)
        {
            Pen TheLinePen = new Pen(TheDataGrid.GridColor, 1);

            if (TheDataGrid.CellBorderStyle == DataGridViewCellBorderStyle.None)
                return;

            for (int i = 0; i < lines.Count; i++)
            {
                g.DrawLine(TheLinePen, TheDataGrid.Location.X, (float)lines[i], PageWidth, (float)lines[i]);
            }
        }
        void DrawVerticalGridLines(Graphics g, Pen TheLinePen, int columnwidth, int bottom)
        {
            if (TheDataGrid.CellBorderStyle == DataGridViewCellBorderStyle.None)
                return;

            for (int k = 0; k < TheTable.Columns.Count; k++)
            {
                g.DrawLine(TheLinePen, TheDataGrid.Location.X + k * columnwidth,
                    TheDataGrid.Location.Y + TopMargin,
                    TheDataGrid.Location.X + k * columnwidth,
                    bottom);
            }
        }
        public bool DrawDataGrid(Graphics g)
        {

            try
            {
                DrawHeader(g);
                bool bContinue = DrawRows(g);
                return bContinue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

    }
}
