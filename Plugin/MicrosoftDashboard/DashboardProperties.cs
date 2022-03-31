using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.AppBuilder;
using TheTechIdea.Beep.AppModule;

namespace BeepEnterprize.Winform.Vis.Dashboard.MicrosoftDashboard
{
    public class DashboardProperties
    {
        public DashboardProperties()
        {

        }
        public string  Name { get; set; }
        public string Description { get; set; }
        public string   Title { get;set; }
        public string Url { get; set; }
        public int ControlCount { get; set; }
        public List<PanelControl> Controls { get; set; } = new List<PanelControl>();
    }
  
}
