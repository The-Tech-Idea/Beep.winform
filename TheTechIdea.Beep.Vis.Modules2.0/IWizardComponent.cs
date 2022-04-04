using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeepEnterprize.Vis.Module
{
    public interface IWizardComponent
    {
        IWizardManager wizardManager { get; set; }
        IWizardState state { get; set; }
    }
}
