using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeepEnterprize.Winform.Vis.Controls
{
    public partial class uc_Container : UserControl
    {
        public ContainerTypeEnum ContainerType { get; set; }
        private Panel ContainerPanel=new Panel();
        private TabControl TabContainerPanel = new TabControl();
        public uc_Container()
        {
            InitializeComponent();
        }
        public bool AddControl(string TitleText,Control control, ContainerTypeEnum pcontainerType)
        {
            if (control == null || control != null && control.Controls.Contains(control)) { return false; }
            switch (pcontainerType)
            {
                case ContainerTypeEnum.SinglePanel:
                    AddToSingle(TitleText, control);
                    break;
                case ContainerTypeEnum.TabbedPanel:
                    AddToTabbed(TitleText, control);
                    break;
                default:
                    break;
            }
            return control != null && control.Controls.Contains(control);
        }
        private bool AddToTabbed(string TitleText,Control control)
        {
            if(ContainerType== ContainerTypeEnum.SinglePanel)
            {
                if (Controls.Contains(ContainerPanel))
                {
                    Controls.Remove(ContainerPanel);
                }
              
            }
            if (!Controls.Contains(TabContainerPanel))
            {
                TabContainerPanel = new TabControl();
                TabContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
                TabContainerPanel.Location = new System.Drawing.Point(0, Line1panel.Height+2);
                TabContainerPanel.Name = "ControlPanel";
                TabContainerPanel.Size = new System.Drawing.Size(this.Width, this.Height- Line1panel.Height + 2);
                TabContainerPanel.TabPages.Clear();
                Controls.Add(TabContainerPanel);
                
            }
            TabContainerPanel.TabPages.Add(TitleText);
            TabContainerPanel.TabPages[TabContainerPanel.TabPages.Count-1].Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.TitleLabel.Text = TitleText;
            return true;
        }
        private bool AddToSingle(string TitleText, Control control)
        {
            if (ContainerType == ContainerTypeEnum.TabbedPanel)
            {
                if (Controls.Contains(TabContainerPanel))
                {
                    Controls.Remove(TabContainerPanel);
                }

            }
            if (!Controls.Contains(ContainerPanel))
            {
                ContainerPanel = new Panel();
                ContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
                ContainerPanel.Location = new System.Drawing.Point(20, Line1panel.Height + 2);
                ContainerPanel.Name = "ControlPanel";
                ContainerPanel.Dock = DockStyle.None;
                ContainerPanel.Size = new System.Drawing.Size(this.Width-20, this.Height - Line1panel.Height + 2);
                Controls.Add(ContainerPanel);
            }
            ContainerPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            this.TitleLabel.Text = TitleText;
            return true;
        }
    }
    public enum ContainerTypeEnum
    {
        SinglePanel,
        TabbedPanel
    }
}
