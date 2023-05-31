using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;

namespace BeepEnterprize.Winform.Vis
{
    public class AddinsShownData
    {
        public AddinsShownData() { }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public IDM_Addin Addin { get; set; }
        public string GuidID { get; set; } = Guid.NewGuid().ToString();
        public bool IsSingleton { get; set; } = false;
        public bool IsShown { get; set; }=false;
    }
}
