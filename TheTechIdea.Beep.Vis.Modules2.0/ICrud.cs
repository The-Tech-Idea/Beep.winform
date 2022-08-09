using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface ICrud<T>
    {
        Task<IErrorsInfo> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> GetByFilter(string Filter);
        Task<IEnumerable<T>> GetByFilter(List<AppFilter> Filter);
        Task<IErrorsInfo> Insert(T doc);
        Task<IErrorsInfo> Update(T doc);

    }
}
