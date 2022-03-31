
using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppModule
{
   public interface IAppComponent
    {
        string ID { get; set; }
        string ComponentName { get; set; }
        string ComponentType { get; set; }
        bool IsTableView { get; set; }
        bool IsContainer { get; set; } 
     
    }
}
