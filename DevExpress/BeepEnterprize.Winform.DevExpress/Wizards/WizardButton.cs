using System;
using System.Drawing;



namespace BeepEnterprize.Winform.Vis.Wizards
{
    public class WizardButton : IWizardButton
    {
        public WizardButton(string title, string text, int index, int left, int top, int width, int height, Color forcolor, Color backcolor)
        {
            button = new System.Windows.Forms.Button();
            button.Name = title;
            button.Text = text;
            button.Location = new System.Drawing.Point(left, top);
            button.Width = width;
            button.Height = height;
            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            button.UseVisualStyleBackColor = false;
            ForColor = forcolor;
            BackColor = backcolor;
            button.BackColor = backcolor;
            button.ForeColor = forcolor;
            _ForColor = forcolor;
            _BackColor = backcolor;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            WizardNodeClickEvent?.Invoke(this, this);
        }

        public event EventHandler<IWizardButton> WizardNodeClickEvent;
        public event EventHandler<IWizardButton> WizardNodeEnterEvent;
        public event EventHandler<IWizardButton> WizardNodeLeaveEvent;
        public bool IsActive { get; set; }
        public string Title { get { return button.Text; } set { button.Text = value; } }
        public string Tooltip { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public bool IsHover { get; set; }
        public int Left { get { return button.Left; } set { button.Left = value; } }
        public int Top { get { return button.Top; } set { button.Top = value; } }
        public int Width { get { return button.Width; } set { button.Width = value; } }
        public int Height { get { return button.Height; } set { button.Height = value; } }
        public int TabIndex { get { return button.TabIndex; } set { button.TabIndex = value; } }
        public System.Drawing.Color _BackColor;
        public System.Drawing.Color _ForColor;

        public System.Drawing.Color BackColor { get { return _BackColor; } set { _BackColor = value; } }
        public System.Drawing.Color ForColor { get { return _ForColor; } set { _ForColor = value; } }

        public System.Drawing.Color HiBackColor { get; set; } = System.Drawing.Color.SandyBrown;
        public System.Drawing.Color HiForColor { get; set; } = System.Drawing.Color.White;

        public System.Drawing.Color HoverBackColor { get; set; } = System.Drawing.Color.Orange;
        public System.Drawing.Color HoverForColor { get; set; } = System.Drawing.Color.White;
        #region "Winform"
        public System.Windows.Forms.Button button { get; }
        public Font Font { get { return button.Font; } set { button.Font = value; } }
        #endregion
        #region "Button Events"
        private void Button_MouseLeave(object sender, System.EventArgs e)
        {
            LeaveButton();
              WizardNodeLeaveEvent?.Invoke(this, this);
            IsHover = false;
        }
        private void Button_MouseEnter(object sender, System.EventArgs e)
        {
            HoverButton();
            WizardNodeEnterEvent?.Invoke(this, this);
        }
        public void HighLightButton()
        {
            button.BackColor = HiBackColor;
            button.ForeColor = HiForColor;

        }
        public void HoverButton()
        {
            button.BackColor = HoverBackColor;
            button.ForeColor = HoverForColor;
            IsHover = false;
        }
        public bool Click()
        {
            HighLightButton();
            IsHover = true;
            return true;
        }
        public bool UnClick()
        {
            button.BackColor = BackColor;
            button.ForeColor = ForColor;
            IsHover = false;
            return false;
        }
        public void LeaveButton()
        {
            button.BackColor = BackColor;
            button.ForeColor = ForColor;
            IsHover = false;
          
        }
        #endregion
        #region "Help methods"
        private Image InvertImageColors(Image p)
        {
            Bitmap pic = new Bitmap(p);
            for (int y = 0; y < pic.Height - 1; y++)
            {
                for (int x = 0; x < pic.Width; y++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, 255 - inv.R, 255 - inv.G, 255 - inv.B);
                    pic.SetPixel(x, y, inv);
                }
            }
            return pic;
        }
        #endregion



    }
}
