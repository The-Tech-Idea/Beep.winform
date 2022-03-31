using TheTechIdea;

namespace BeepEnterprize.Vis.Module
{
    public interface IWizardState
    {
        PassedArgs args { get; set; }
        IWizardManager wizardManager { get; set; }
    }
}