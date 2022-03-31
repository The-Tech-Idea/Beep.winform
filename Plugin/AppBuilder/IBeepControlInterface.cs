using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    public interface IBeepControlInterface
    {
        PanelControl Panelcontrol { get; set; }
        DMEEditor DMEEditor { get; set; }
        ScreenDesigner ScreenDesigner { get; set; }
        IErrorsInfo Init(IPassedArgs args);
        IErrorsInfo ChangeVisual(IPassedArgs args);
        IErrorsInfo Bind(IPassedArgs args);
    
    }
}
