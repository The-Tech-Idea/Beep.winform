using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beep.Winform.Controls
{
    [Serializable]
    public class LovListItem
    {
        public LovListItem()
        {

        }
        public string KeyID { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
    }
}
