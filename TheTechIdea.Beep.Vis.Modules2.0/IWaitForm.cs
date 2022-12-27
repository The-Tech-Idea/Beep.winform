using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface IWaitForm
    {
        void SetText(string text);
        void SetTitle(string title);
        void SetTitle(string title, string text);
        void SetImage(string image);
        IErrorsInfo Show(PassedArgs Passedarguments);
        IErrorsInfo Close();
    }
}
