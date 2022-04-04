
using BeepEnterprize.Vis.Module;
using TheTechIdea.Beep;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Controls
{
    public interface ITreeBranchHandler
    {
        IDMEEditor DMEEditor { get; set; }

        IErrorsInfo AddBranch(IBranch ParentBranch, IBranch Branch);
        IErrorsInfo AddCategory(IBranch Rootbr);
        string CheckifBranchExistinCategory(string BranchName, string pRootName);
        IErrorsInfo CreateBranch(IBranch Branch);
        IBranch GetBranch(int pID);
        IBranch GetBranchByMiscID(int pID);
        IErrorsInfo MoveBranchToParent(IBranch ParentBranch, IBranch CurrentBranch);
        IErrorsInfo RemoveBranch(IBranch Branch);
        IErrorsInfo RemoveBranch(int id);
        IErrorsInfo RemoveCategoryBranch(int id);
        IErrorsInfo RemoveChildBranchs(IBranch branch);
        bool RemoveEntityFromCategory(string root, string foldername, string entityname);
        IErrorsInfo SendActionFromBranchToBranch(IBranch ToBranch, IBranch CurrentBranch, string ActionType);
    }
}