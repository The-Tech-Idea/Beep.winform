

using BeepEnterprize.Winform.Vis;
using BeepEnterprize.Winform.Vis.Helpers;
using System.Collections.Generic;
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
        IDM_Addin SecondaryToolStrip { get; set; }
        IDM_Addin Tree { get; set; }
        IDM_Addin SecondaryTree { get; set; }
        IDM_Addin MenuStrip { get; set; }
        IDM_Addin SecondaryMenuStrip { get; set; }
        IDM_Addin CurrentDisplayedAddin { get; set; }
        bool IsDataModified { get; set; }
        bool IsShowingMainForm { get; set; }
        List<IFileStorage> ImagesUrls { get; set; }
        bool IsBeepDataOn { get; set; }
        bool IsAppOn { get; set; }
        bool IsDevModeOn { get; set; }
        int TreeIconSize { get; set; }
        bool TreeExpand { get; set; }

        int SecondaryTreeIconSize { get; set; }
        bool SecondaryTreeExpand { get; set; }
        string AppObjectsName { get; set; }
        string BeepObjectsName { get; set; }
        string LogoUrl { get; set; }
        string Title { get; set; }
        string IconUrl { get;set; }
         bool ShowLogWindow { get ; set ; }
    
         bool ShowTreeWindow { get ; set; } 

       
        IWaitForm WaitForm { get; set; }
        IErrorsInfo LoadSetting();
        IErrorsInfo SaveSetting();
        IVisHelper visHelper { get; set; }
        IErrorsInfo ShowMainPage();
        IErrorsInfo CallAddinRun();
        IErrorsInfo CloseAddin();
        IErrorsInfo PrintGrid(IPassedArgs passedArgs);
        IDM_Addin ShowUserControlPopUp(string usercontrolname, IDMEEditor pDMEEditor, string[] args, IPassedArgs e);
        IErrorsInfo ShowPage(string pagename,  PassedArgs Passedarguments,  DisplayType displayType = DisplayType.InControl);
        IErrorsInfo ShowWaitForm(PassedArgs Passedarguments);
        IErrorsInfo PasstoWaitForm(PassedArgs Passedarguments);
        IErrorsInfo CloseWaitForm();
    }
}