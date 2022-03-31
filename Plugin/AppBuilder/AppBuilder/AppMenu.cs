using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.AppModule;

namespace TheTechIdea.Beep.AppBuilder
{
    public class AppMenu : IAppMenu
    {
        public AppMenu()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        public string Caption { get; set; }
        public string IconUrl { get; set; }
        public IDM_Addin TargetUrl { get; set; }
        public List<IAppMenuItem> MenuItems { get; set; }
    }
}
