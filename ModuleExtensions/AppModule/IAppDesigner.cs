using System;
using System.Collections.Generic;
using System.Text;

namespace TheTechIdea.Beep.AppModule
{
    public interface IAppDesigner
    {
        IDMEEditor DMEEditor { get; set; }
        bool Winform { get; set; }
        bool WPF { get; set; }
        bool Web { get; set; }
        bool Andriod { get; set; }
        bool IOS { get; set; }
        List<IApp> Apps { get; set; }
        void StartDesign();
        void LoadDesign();
        void SaveDesign();

    }
}
