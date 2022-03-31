
using System;
using System.Drawing;

using static System.Net.Mime.MediaTypeNames;

namespace BeepEnterprize.Winform.Vis.Wizards
{
    public interface IWizardButton
    {
        string Title { get; set; }
        string Tooltip { get; set; }
        string Description { get; set; }
        Color ForColor { get; set; }
        Color BackColor { get; set; }
        Color HiBackColor { get; set; }
        Color HiForColor { get; set; }
        Color HoverBackColor { get; set; } 
        Color HoverForColor { get; set; }
        int Height { get; set; }
        bool IsActive { get; set; }
        bool IsChecked { get; set; }
        bool IsHover { get; set; }
        int Left { get; set; }
        int TabIndex { get; set; }
        int Top { get; set; }
        int Width { get; set; }

        bool Click();
        bool UnClick();
        void HoverButton();
        void LeaveButton();
        event EventHandler<IWizardButton> WizardNodeClickEvent;
        event EventHandler<IWizardButton> WizardNodeEnterEvent;
        event EventHandler<IWizardButton> WizardNodeLeaveEvent;

    }
}