
using System.Collections.Generic;
using TheTechIdea.Beep.AppModule;

namespace TheTechIdea.Beep.AppModule
{
    public interface IAppMenuItem
    {
        string Caption { get; set; }
        string Description { get; set; }
        string IconUrl { get; set; }
        string ID { get; set; }
        bool IsChecked { get; set; }
        IAppScreen TargetUrl { get; set; }
        List<IAppMenuItem> MenuItems { get; set; }
    }
}