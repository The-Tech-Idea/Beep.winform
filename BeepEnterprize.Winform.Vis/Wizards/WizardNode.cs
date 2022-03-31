using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;

namespace BeepEnterprize.Winform.Vis.Wizards
{
    public class WizardNode : IWizardNode, IEquatable<WizardNode>
    {
        public event EventHandler<IWizardNode> WizardNodeClickEvent;
        public  event EventHandler<IWizardNode> WizardNodeEnterEvent;
        public  event EventHandler<IWizardNode> WizardNodeLeaveEvent;
        
        public WizardNode(IDM_Addin node, string title, string text, int index, int left, int top, int width, int height, Color forcolor, Color backcolor)
        {
            Wizardbutton = new WizardButton(title, text, index, left, top, width, height, forcolor, backcolor);
            Addin = node;
            Index = index;
            Name = title;
            Description = text;
            Wizardbutton.WizardNodeClickEvent += Wizardbutton_WizardNodeClickEvent;
            Wizardbutton.WizardNodeEnterEvent += Wizardbutton_WizardNodeEnterEvent;
            Wizardbutton.WizardNodeLeaveEvent += Wizardbutton_WizardNodeLeaveEvent;
        }

        
        public WizardNode(string title, string text, int index, int left, int top, int width, int height, Color forcolor, Color backcolor)
        {
            Wizardbutton = new WizardButton(title, text, index, left, top, width, height, forcolor, backcolor);
            Wizardbutton.WizardNodeClickEvent += Wizardbutton_WizardNodeClickEvent;
            Wizardbutton.WizardNodeEnterEvent += Wizardbutton_WizardNodeEnterEvent;
            Wizardbutton.WizardNodeLeaveEvent += Wizardbutton_WizardNodeLeaveEvent;
        }
        public int Index { get; set; }
        public IDM_Addin Addin { get; set; }
        public string Name { get; set; }
        public bool IsActive { get { return Wizardbutton.IsActive; } set { if (!value) { Wizardbutton.UnClick(); } else Wizardbutton.Click(); } } 
        public string Description { get; set; }
        public object Data { get; set; } = null;
        public string Type { get; set; }
        public IWizardButton Wizardbutton { get; set; }
        private void Wizardbutton_WizardNodeClickEvent(object sender, IWizardButton e)
        {
            WizardNodeClickEvent?.Invoke(this, this);
        }
        private void Wizardbutton_WizardNodeLeaveEvent(object sender, IWizardButton e)
        {
           WizardNodeLeaveEvent?.Invoke(this, this);
        }
        private void Wizardbutton_WizardNodeEnterEvent(object sender, IWizardButton e)
        {
           WizardNodeEnterEvent?.Invoke(this, this);
        }
        public  void LeaveButton()
        {
            Wizardbutton.LeaveButton();
        }
        public void OverButton()
        {
            Wizardbutton.HoverButton();
        }
        public bool Equals(WizardNode other)
        {
            return this == other;
        }
    }
}
