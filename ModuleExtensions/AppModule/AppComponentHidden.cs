using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.AppBuilder
{
    [AddinAttribute(Caption = "AppComponentHidden", Name = "AppComponentHidden", misc = "AppComponentHidden", addinType = AddinType.Class,Hidden =true)]
    public class AppComponentHidden : IAppComponent
    {
        public AppComponentHidden()
        {

        }
        public string ID { get ; set ; }
        public string ComponentName { get ; set ; }
        public string ComponentType { get ; set ; }
        public bool IsContainer { get; set; } = false;
        public bool IsTableView { get ; set ; }=false;
    }
}
