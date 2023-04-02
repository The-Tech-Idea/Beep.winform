using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beep.Winform.Vis.Wizards
{
    public class Theme
    {
       
        public Theme()
        {

        }
        public System.Drawing.Color PanelAltBackColor { get; set; } = System.Drawing.Color.SteelBlue;
        public System.Drawing.Color PanelBackColor { get; set; } = System.Drawing.Color.LightSteelBlue;
        public System.Drawing.Color PanelForColor { get; set; } = System.Drawing.Color.White;
        public System.Drawing.Color BackColor { get; set; } = System.Drawing.Color.SteelBlue;
        public System.Drawing.Color ForColor { get; set; } = System.Drawing.Color.White;

        public System.Drawing.Color SelectBackColor { get; set; } = System.Drawing.Color.SandyBrown;
        public System.Drawing.Color SelectForColor { get; set; } = System.Drawing.Color.White;

        public System.Drawing.Color HoverBackColor { get; set; } = System.Drawing.Color.Orange;
        public System.Drawing.Color HoverForColor { get; set; } = System.Drawing.Color.White;
        public bool Curved { get; set; } = false;
        public BorderStyle BorderStyle { get; set; }= BorderStyle.None;

    }
}
