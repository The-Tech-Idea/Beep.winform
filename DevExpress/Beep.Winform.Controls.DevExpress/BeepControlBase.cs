using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Beep.Winform.Controls
{
    public class BeepControlBase:Control 
    {
        public BeepControlBase():base()
        {
            init();

        }
        public BeepControlBase(string title, string text, int index, int left, int top, int width, int height, Color forcolor, Color backcolor)
        {
           
            Name = title;
            Text = text;
            Location = new System.Drawing.Point(left, top);
            Width = width;
            Height = height;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            BackColor = backcolor;
            ForeColor = forcolor;
            _ForeColor = forcolor;
            _BackColor = backcolor;
            init();
        }
        private void init()
        {
            _ComboButton.Click += Lov_Click;
            _ComboButton.MouseHover += _ComboButton_MouseHover;
            _ComboButton.MouseLeave += _ComboButton_MouseLeave;
            _ComboButton.MouseEnter += _ComboButton_MouseEnter;
             LovList = new List<LovListItem>();

            // Controls.Add(Lovpanel);
            Controls.Add(_ComboButton);
           // Lovpanel.Hide();
            _ComboButton.Hide();
            Height = 22;
            Width = 120;
            BorderLess = false;
            colors();
            initLov();

        }
        private void colors()
        {
            SelectBackColor  = System.Drawing.Color.SandyBrown;
            SelectForeColor  = System.Drawing.Color.White;
            HoverBackColor  = System.Drawing.Color.SteelBlue;
            HoverForeColor  = System.Drawing.Color.Orange;
        }
        private void initLov()
        {
            Lovpanel = new Panel();
            Lovpanel.Left = 0;
            Lovpanel.Top = 0;
            Lovpanel.Height = 200;
            Lovpanel.Width = Width;
            Lovpanel.BackColor = _BackColor;
            Lovpanel.ForeColor = _ForeColor;

            LovView.Font = Font;
            LovView.ForeColor = SelectForeColor;
            LovView.BackColor = ToolTippanel.BackColor;
            LovList = new List<LovListItem>();
            LovView.DataSource = LovList;


            LovView.AllowUserToAddRows = false;
            LovView.AllowUserToDeleteRows = false;
            LovView.AutoGenerateColumns = true;
            LovView.MultiSelect = false;
            LovView.SelectionChanged += LovView_SelectionChanged;
            LovView.Click += LovView_SelectionChanged;
            Lovpanel.Controls.Add(LovView);
            LovView.Dock = DockStyle.Fill;
        }
        #region "Extra Properties"
        public Image Image { get; set; }
        public Image ErrorImage { get; set; }
        public Image HoverImage { get; set; }
        public Image SelectedImage { get; set; }
        public bool BorderLess { get; set; }
        public object Value { get; set; } = null;
        public string ObjectType { get; set; }

        public System.Drawing.Color SelectBackColor { get; set; } 
        public System.Drawing.Color SelectForeColor { get; set; }

        public System.Drawing.Color HoverBackColor { get; set; } 
        public System.Drawing.Color HoverForeColor { get; set; }

     
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public bool IsChecked { get; set; } = false;
        public Char TrueValue { get; set; } = '1';
        public Char FalseValue { get; set; } = '0';
        public bool IsHover { get; set; }= false;
        public bool IsSelected { get; set; }=   false;
        private bool _islov = false;
        private bool _showLov = false;
        public bool IsLov { get { return _islov; } set { LovSet(value); _islov = value ; } }
        public string LovQuery { get; set; }
        public string LovUrl { get; set; }
        public List<LovListItem> LovList { get; set; }
        //public string KeyLovID { get; set; }
        //public string DisplayLovField { get; set; }
        public string ReturnKeyLovID { get; set; }
        public string ReturnDisplayLovField { get; set; }
        #endregion
        private  PassedEventArgs args = new PassedEventArgs();
        private System.Drawing.Color _BackColor;
        private System.Drawing.Color _ForeColor;
        private Button _ComboButton=new Button();
        public TextBox ValueTextBox { get;set; }=new TextBox();
        public TextBox DisplayTextBox { get; set; }=new TextBox();
        BeepForm popup;
        #region "Winform"
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (IsLov)
            {
                _ComboButton.Left = Width-22;
                _ComboButton.Width = 19;
                if (_ComboButton.Height>21)
                {
                    _ComboButton.Height =19;
                }
                else if (Height < _ComboButton.Height)
                {
                    _ComboButton.Height = Height - 3;
                }

                _ComboButton.Top = 2;
                _ComboButton.Text = "+";
              //  _ComboButton.Height = 20;
                _ComboButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }
            if (IsHover && !IsSelected)
            {
                Rectangle borderRectangle = this.ClientRectangle;
                borderRectangle.Inflate(+1, +1);
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, HoverForeColor , ButtonBorderStyle.Inset);
                ControlPaint.DrawBorder(e.Graphics, borderRectangle, HoverForeColor, ButtonBorderStyle.Inset);
                // ControlPaint.DrawBorder3D(e.Graphics, borderRectangle, Border3DStyle.RaisedOuter, Border3DSide.Bottom);

            }
            else  if (!BorderLess && !IsHover)
            {
                ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.SunkenInner, Border3DSide.All);
            }

           


        }
        #endregion
        #region "Events"
        #region "ToolTip"
        Panel ToolTippanel = new Panel();
        Label ToolTiplabel = new Label();
        Panel Lovpanel;
        DataGridView LovView = new DataGridView();
        
        ToolTip _tooltip=new ToolTip();
        #endregion
        private void LovSet (bool newlovval)
        {
            if (newlovval)
            {
                if (Lovpanel == null) { initLov(); }
                if (_islov == false)
                {
                    Width = Width + 22;
                   
                    _ComboButton.Show();
                    this.Invalidate();
                }
            }
            else
            {
                if (_islov)
                {
                    Width = Width - 22;
                    Height = Height- 4;
                    _ComboButton.Hide();
                    this.Invalidate();
                }
            }
        }
        protected override void OnClick(EventArgs e)
        {
            SelectControl();
            IsSelected=true;
            base.OnClick(e);
            this.Invalidate();
        }
        protected override void OnMouseHover(EventArgs e)
        {
           if (!string.IsNullOrEmpty(Tooltip))
           {
                    ShowToolTip();
            }

            IsHover = true;
            base.OnMouseHover(e);
            this.Invalidate();

        }
        protected override void OnMouseLeave(EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(Tooltip))
            {
              HideToolTip();
            }

            IsHover =false;
            base.OnMouseLeave(e);
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            //IsHover = true;
            //_ComboButton.Invalidate();
            //this.Invalidate(true);
            base.OnMouseEnter(e);
        }
        private void _ComboButton_MouseLeave(object sender, EventArgs e)
        {
            _ComboButton.BackColor = _BackColor;
            _ComboButton.ForeColor = _ForeColor;
            _ComboButton.Invalidate();
           

        }

        private void _ComboButton_MouseHover(object sender, EventArgs e)
        {

                if (!string.IsNullOrEmpty(Tooltip))
                {
                    ShowToolTip();
                }
            _ComboButton.Invalidate();
        }
        private void _ComboButton_MouseEnter(object sender, EventArgs e)
        {
            _ComboButton.BackColor = HoverBackColor;
            _ComboButton.ForeColor = HoverForeColor;
            _ComboButton.Invalidate();
            this.Invalidate();
        }
        private void HideToolTip()
        {
            //  ToolTippanel.Hide();
            // In this example, button1 is the control displaying the ToolTip.
            _tooltip.SetToolTip(this, null);
        }
        private void ShowToolTip()
        {
            //if (Tooltip == null)
            //{
            //    ToolTippanel.Left = Left;
            //    ToolTippanel.Top = Top - 100;
            //    ToolTippanel.Height = 100;
            //    ToolTippanel.Width = Width;
            //    ToolTippanel.BackColor = _BackColor;
            //    ToolTippanel.ForeColor = _ForeColor;
            //    ToolTiplabel.Text = Tooltip;
            //    ToolTiplabel.Font = Font;
            //    ToolTiplabel.ForeColor = SelectForeColor;
            //    ToolTiplabel.BackColor = ToolTippanel.BackColor;
            //    ToolTippanel.Controls.Add(ToolTiplabel);
            //    ToolTiplabel.Dock = DockStyle.Fill;
            //    ToolTiplabel.Text=Tooltip;
            //}

            ////ToolTippanel.Show();
            //try
            //{
            //    toolTip = new Popup(customToolTip = new CustomToolTip());
            //    toolTip.AutoClose = true;
            //    toolTip.FocusOnOpen = true;
            //    toolTip.ShowingAnimation = toolTip.HidingAnimation = PopupAnimations.Blend;
            //    toolTip.Show(ToolTiplabel);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            if (!string.IsNullOrEmpty(Tooltip))
            {
                _tooltip.SetToolTip(this, Tooltip);
            }
          
        }
        private void ShowLov()
        {
          
            if (IsLov)
            {
                if ((!string.IsNullOrEmpty(LovQuery) && !string.IsNullOrEmpty(LovUrl)) || (LovList.Count != 0))
                {
                    if (LovList.Count > 0)
                    {
                        _showLov = true;
                    }
                    else
                        _showLov = false;
                }
            }
            if (_showLov)
            {
                popup = new BeepForm();
                
                popup.Controls.Add(Lovpanel);
                popup.Width = Lovpanel.Width;
                popup.Height = Lovpanel.Height;
                Lovpanel.Dock = DockStyle.Fill;
                LovView.DataSource = LovList;
                LovView.Refresh();
                popup.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                popup.Left = this.Left;
                popup.Top = this.Top - 200;
                popup.ShowDialog();
            }
            else { if (popup != null) popup.Close(); }
        }
        private void SelectControl()
        {

            BackColor = SelectBackColor;
            ForeColor = SelectForeColor;
        }
      
    
        #endregion
        #region "New Events"
        public event EventHandler<PassedEventArgs> LovSelected;
        public event EventHandler<PassedEventArgs> LovClick;
        #endregion
        #region "New Methods"
        private void LovView_SelectionChanged(object sender, EventArgs e)
        {
            Int32 selectedRowCount = LovView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                ReturnKeyLovID= (LovView.SelectedRows[0].Cells["KeyLovID"].Value).ToString(); ;
                ReturnDisplayLovField = (LovView.SelectedRows[0].Cells["DisplayField"].Value).ToString(); ;
                args = new PassedEventArgs() { EventName = "LovSelected", Cancel = false };
                LovSelected?.Invoke(this, args);
                if (!args.Cancel)
                {
                    Lovpanel.Hide();
                    Lovpanel.Invalidate();
                    this.Invalidate();
                }
            }

        }
        private void Lov_Click(object sender, EventArgs e)
        {
            args = new PassedEventArgs() { EventName = "LovClick" ,Cancel=false};
            LovClick?.Invoke(this, args);
            if (!args.Cancel)
            {
                ShowLov();
            }
            
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
