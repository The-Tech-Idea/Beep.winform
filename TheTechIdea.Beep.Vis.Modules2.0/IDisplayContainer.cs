using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea;

namespace BeepEnterprize.Vis.Module
{
    public interface IDisplayContainer
    {
        bool AddControl(string TitleText, IDM_Addin control, ContainerTypeEnum pcontainerType);
        bool RemoveControl(string TitleText, IDM_Addin control);
        bool ShowControl(string TitleText, IDM_Addin control);
        event EventHandler<ContainerEvents> AddinAdded;
        event EventHandler<ContainerEvents> AddinRemoved;
        event EventHandler<ContainerEvents> AddinMoved;
        event EventHandler<ContainerEvents> AddinChanging;
        event EventHandler<ContainerEvents> AddinChanged;
        
        
        
    }
    public class ContainerEvents : EventArgs
    {
        public ContainerEvents() { }
       public ContainerTypeEnum ContainerType { get; set; }
        public string TitleText { get; set; }   
        public IDM_Addin Control { get; set; }

    }
}
