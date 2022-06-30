using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Beep.Vis;

namespace BeepEnterprize.Winform.Vis.Controls.TreeControls
{
    public class MenuList
    {
        public MenuList()
        {

        }
        public MenuList(string objectType, string branchClass, EnumPointType pointType)
        {
            ObjectType = objectType;
            BranchClass = branchClass;
            PointType = pointType;
        }
        public ContextMenuStrip Menu { get; set; }
        public List<MenuItem> Items { get; set; }
        public EnumPointType  PointType { get; set; }
        public string ObjectType { get; set; }
        public string BranchClass { get; set; } 
        public string branchname { get; set; }

    }
}
