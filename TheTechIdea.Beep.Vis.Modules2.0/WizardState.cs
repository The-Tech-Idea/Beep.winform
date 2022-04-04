using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;

namespace BeepEnterprize.Vis.Module
{
    public class WizardState : IWizardState
    {
        public WizardState(IWizardManager pwizardManager)
        {
            wizardManager = pwizardManager;
        }
        public PassedArgs args { get; set; }
        public IWizardManager wizardManager { get; set; }

    }
}
