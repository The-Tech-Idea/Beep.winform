using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Beep.Report;

namespace TheTechIdea.Beep.AppModule
{
    public interface IAppScreen
    {
        string ID { get; set; }
        int DisplayOrder { get; set; }
        string Screenname { get; set; }
        string Description { get; set; }
        List<IAppBlock> Blocks { get; set; }
        string ImageLogoName { get; set; }
        string SubTitle { get; set; }
        string Title { get; set; }
        PassedArgs Args { get; set; }
        string Parentscreen { get; set; }
        AppComponentType ScreenType { get; set; }
        string Url { get; set; }

    }

}
