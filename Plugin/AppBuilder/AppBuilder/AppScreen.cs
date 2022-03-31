using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    [AddinAttribute(Caption = "Beep App Screen", Name = "BeepAppScreen", misc = "BeepAppScreen", addinType = AddinType.Class, iconimage = "appscreen.ico")]
    public class AppScreen : IAppScreen
    {
        public AppScreen()
        {
            ID=Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        public string Screenname { get; set; }
        public string ImageLogoName { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Datasourcename { get; set; }
        public List<AppModule.IAppBlock> Blocks { get; set; } = new List<AppModule.IAppBlock>();
        public List<IAppDefinition> Reports { get; set; } = new List<IAppDefinition>();
        public PassedArgs Args { get; set; } = new PassedArgs();
        public string Parentscreen { get; set; }
        public int DisplayOrder { get ; set ; }
        public AppComponentType ScreenType { get ; set ; }
        public string Url { get ; set ; }
       
    }
}
