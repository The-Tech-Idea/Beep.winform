using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.AppModule
{
    public interface IBreadCrumb
    {
        Dictionary<string, string> keyValues { get; set; }
        string screenname { get; set; }

        bool Equals(IBreadCrumb other);
        bool Equals(object obj);
        int GetHashCode();
    }

}
