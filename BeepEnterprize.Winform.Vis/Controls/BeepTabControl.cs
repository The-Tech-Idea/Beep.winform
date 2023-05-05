using System;
using System.Drawing;
using System.Windows.Forms;

namespace BeepEnterprize.Winform.Vis.Controls
{
    public class BeepTabControl:TabControl
    {
        public event EventHandler<EventArgs> CloseButtonClick;
        public event EventHandler<EventArgs> NextButtonClick;
        public event EventHandler<EventArgs> PrevButtonClick;
        private RectangleF closeButton = new RectangleF();
        private RectangleF nextButton = new RectangleF();
        private RectangleF prevButton = new RectangleF();
        private Image closeButtonImage;
        private Image nextButtonImage;
        private Image prevButtonImage;
        public BeepTabControl()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Padding = new Point(14, 4);
            this.DrawItem += BeepTabControl_DrawItem;
            this.MouseClick += BeepTabControl_MouseClick;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            //this.HandleCreated += (s, e) => RecalculateTabSizes();
            //this.ControlAdded += (s, e) => RecalculateTabSizes();
            //this.ControlRemoved += (s, e) => RecalculateTabSizes();
            //this.FontChanged += (s, e) => RecalculateTabSizes();

            closeButtonImage = global::BeepEnterprize.Winform.Vis.Properties.Resources.close;
            nextButtonImage = global::BeepEnterprize.Winform.Vis.Properties.Resources.Collapseright;
            prevButtonImage = global::BeepEnterprize.Winform.Vis.Properties.Resources.CollapseLeft;
        }
       
        private void RecalculateTabSizes()
        {
            if (this.TabPages.Count == 0)
            {
                return;
            }

            int paddingWidth = 25; // Additional padding for the Close button
            int paddingHeight = 8; // Additional padding for the tab height
            int maxHeight = 0; // Keep track of the maximum height
            using (Graphics g = this.CreateGraphics())
            {
                int[] tabWidths = new int[this.TabPages.Count];

                for (int i = 0; i < this.TabPages.Count; i++)
                {
                    var tabPage = this.TabPages[i];
                    SizeF textSize = g.MeasureString(tabPage.Text, tabPage.Font);

                    int tabWidth = (int)textSize.Width + paddingWidth;
                    int tabHeight = (int)textSize.Height + paddingHeight;

                    if (tabHeight > maxHeight)
                    {
                        maxHeight = tabHeight;
                    }

                    tabWidths[i] = tabWidth;
                }

                for (int i = 0; i < this.TabPages.Count; i++)
                {
                    this.SizeMode = TabSizeMode.Fixed;
                    this.ItemSize = new Size(tabWidths[i], maxHeight);
                }
            }

            this.Invalidate(); // Redraw the control to apply the new tab sizes
        }

        private void BeepTabControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Close button click
            if (closeButton.Contains(e.Location))
            {
                TabPage tabPage = null;
                for (int i = 0; i < this.TabCount; i++)
                {
                    if (this.GetTabRect(i).Contains(e.Location))
                    {
                        tabPage = this.TabPages[i];
                        break;
                    }
                }

                if (tabPage != null)
                {
                    this.TabPages.Remove(tabPage);
                    CloseButtonClick?.Invoke(this, new EventArgs());
                }
            }

            // Next button click
            if (nextButton.Contains(e.Location))
            {
                if (this.SelectedIndex < this.TabCount - 1)
                {
                    this.SelectedIndex++;
                    NextButtonClick?.Invoke(this, new EventArgs());
                }
            }

            // Previous button click
            if (prevButton.Contains(e.Location))
            {
                if (this.SelectedIndex > 0)
                {
                    this.SelectedIndex--;
                    PrevButtonClick?.Invoke(this, new EventArgs());
                }
            }
        }

        private void BeepTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = this.TabPages[e.Index];
            var tabRect = this.GetTabRect(e.Index);
            tabRect.Inflate(-3,-4);
            // Adjust the string drawing position and provide extra space for the close button
            float textPadding = 4; // Space between the text and the close button
            float maxTextWidth = tabRect.Width - closeButtonImage.Width - textPadding;
            e.Graphics.DrawString(tabPage.Text, tabPage.Font, Brushes.Black, new RectangleF(tabRect.Left, tabRect.Top, maxTextWidth, tabRect.Height));

            // Close button
            int closeButtonPadding = 4; // Padding from the right edge of the tab
            closeButton = new RectangleF(tabRect.Right - closeButtonImage.Width - closeButtonPadding, tabRect.Top + (tabRect.Height - closeButtonImage.Height) / 2, closeButtonImage.Width, closeButtonImage.Height);
            e.Graphics.DrawImage(closeButtonImage, closeButton.Location);

            // Next button
            if (e.Index == this.TabCount - 1)
            {
                nextButton = new RectangleF(this.Width - 20, tabRect.Top+1, nextButtonImage.Width, nextButtonImage.Height);
                e.Graphics.DrawImage(nextButtonImage, nextButton.Location);
            }

            // Previous button
            if (e.Index == 0)
            {
                prevButton = new RectangleF(this.Width - 40, tabRect.Top+1, prevButtonImage.Width, prevButtonImage.Height);
                e.Graphics.DrawImage(prevButtonImage, prevButton.Location);
            }
            //// Close button
            //closeButton = new RectangleF(tabRect.Right - 15, tabRect.Top + 4, 12, 12);
            //e.Graphics.FillRectangle(Brushes.Red, closeButton);
            //e.Graphics.DrawString("X", tabPage.Font, Brushes.White, closeButton.Location);

            //// Next button
            //if (e.Index == this.TabCount - 1)
            //{
            //    nextButton = new RectangleF(this.Width - 40, tabRect.Top, 12, 12);
            //    e.Graphics.FillRectangle(Brushes.Gray, nextButton);
            //    e.Graphics.DrawString(">", tabPage.Font, Brushes.White, nextButton.Location);
            //}

            //// Previous button
            //if (e.Index == 0)
            //{
            //    prevButton = new RectangleF(this.Width - 60, tabRect.Top, 12, 12);
            //    e.Graphics.FillRectangle(Brushes.Gray, prevButton);
            //    e.Graphics.DrawString("<", tabPage.Font, Brushes.White, prevButton.Location);
            //}
        }
    }
}
