using System;
using System.Collections.Generic;
using System.Text;

namespace BeepEnterprize.Vis.Module
{
    public interface IDisplayContainer
    {
        bool AddControl(string TitleText, object control, ContainerTypeEnum pcontainerType);
        bool RemoveControl(string TitleText, object control);
    }
}
