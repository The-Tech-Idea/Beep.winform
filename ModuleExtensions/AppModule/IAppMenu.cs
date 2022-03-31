using System.Collections.Generic;
using TheTechIdea.Beep.AppModule;

namespace TheTechIdea.Beep.AppModule
{
    public interface IAppMenu
    {
        string Caption { get; set; }
        string IconUrl { get; set; }
        string ID { get; set; }
        List<IAppMenuItem> MenuItems { get; set; }
        IDM_Addin TargetUrl { get; set; }
    }
}