using System;
using TheTechIdea;

namespace BeepEnterprize.Winform.Vis.Wizards
{
    public interface IWizardNode
    {
        int Index { get; set; }
        object Data { get; set; }
        string Description { get; set; }
        bool IsActive { get; set; }
        string Name { get; set; }
        IDM_Addin Addin { get; set; }
        string Type { get; set; }
        IWizardButton Wizardbutton { get; set; }
        event EventHandler<IWizardNode> WizardNodeClickEvent;
        event EventHandler<IWizardNode> WizardNodeEnterEvent;
        event EventHandler<IWizardNode> WizardNodeLeaveEvent;


        void LeaveButton();
        void OverButton();
    }
}