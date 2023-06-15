using System;
using System.Collections.Generic;
using System.Text;

namespace BeepEnterprize.Vis.Module
{
    public interface IPrivilege
    {
        string Name { get; }
        string ComponentName { get; set; }
        bool IsVisible { get; set; }
        bool IsLocked { get; set; }
        bool IsEnabled { get; set; }
        bool IsDisabled { get; set; }
        bool CanSelect { get; set; }
        bool CanDelete { get; set; }
        bool CanEdit { get; set; }
        bool CanInsert { get; set; }


    }
}
