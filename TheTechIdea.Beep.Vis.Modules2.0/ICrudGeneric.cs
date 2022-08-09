using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface ICrudGeneric<T>
    {
        Task Delete(string entity, string datasourcename, int id);
        Task<T> Get(string entity, string datasourcename, int id);
        Task<IEnumerable<T>> Get(string entity, string datasourcename);
        Task<IEnumerable<T>> Get(string entity, string datasourcename, string ItemName);
        Task Insert(string entity, string datasourcename, T doc);
        Task Update(string entity, string datasourcename, T doc);

    }
   
}
