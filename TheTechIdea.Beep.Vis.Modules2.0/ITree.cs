using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Winform.Vis.Controls;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Vis.Module
{
    public interface ITree
    {
            string CategoryIcon { get; set; }
            string SelectIcon { get; set; }
            string  TreeType { get; set; }
            IBranch CurrentBranch { get; set; }
            IDMEEditor DMEEditor { get; set; }
           
            PassedArgs args { get; set; }
            int SeqID { get; }
            List<IBranch> Branches { get; set; }
            IVisManager VisManager { get; set; }
            int SelectedBranchID { get; set; }
            List<int> SelectedBranchs { get; set; }
            ITreeBranchHandler treeBranchHandler { get; set; }
            IErrorsInfo RunMethod(object branch, string MethodName);
            IErrorsInfo CreateRootTree();
            IErrorsInfo CreateFunctionExtensions(MethodsClass item);
            string Filterstring { set; }


    }
}
