

using BeepEnterprize.Winform.Vis;
using BeepEnterprize.Winform.Vis.Helpers;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface IVisManager
    {
        IDMEEditor DMEEditor { get; set; }
        ErrorsInfo ErrorsandMesseges { get; set; }
        IControlManager Controlmanager { get; set; }
        IDM_Addin ToolStrip { get; set; }
        IDM_Addin Tree { get; set; }
        IDM_Addin MenuStrip { get; set; }

        IErrorsInfo loadpalette();
        IErrorsInfo savepalette();
        IVisHelper visHelper { get; set; }
        IErrorsInfo ShowMainPage();
        IErrorsInfo PrintGrid(IPassedArgs passedArgs);
        IErrorsInfo ShowPage(string pagename,  PassedArgs Passedarguments,  DisplayType displayType = DisplayType.InControl);
        IErrorsInfo ShowWaitForm(PassedArgs Passedarguments);
        IErrorsInfo PasstoWaitForm(PassedArgs Passedarguments);
        IErrorsInfo CloseWaitForm();
    }
}