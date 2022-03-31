using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface IBranchRootCategory
    {
        IErrorsInfo CreateCategoryNode(CategoryFolder p);
        
    }
}
