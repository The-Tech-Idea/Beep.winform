using CommunityToolkit.Mvvm.Input;
using KOC.DHUB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Util;

namespace KOC.DHUB3.ViewModels
{
    public partial class WellReviewViewModel : BaseViewModel
    {
        public WELL_LATEST_DATA Well { get; set; }

        [ICommand]
        private void GetWellByUWI(string puwi)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                Well = Repo.GetWell(puwi);
            }
            catch (Exception ex)
            {
                DMEditor.ErrorObject.Ex = ex;
                DMEditor.ErrorObject.Message = $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}";
                DMEditor.ErrorObject.Flag = Errors.Failed;
            }
           // return DMEditor.ErrorObject;
        }
        [ICommand]
        private void GetWellByCompletion(int pwell_completion_id)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                Well = Repo.GetWell(pwell_completion_id);
            }
            catch (Exception ex)
            {
                DMEditor.ErrorObject.Ex = ex;
                DMEditor.ErrorObject.Message = $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}";
                DMEditor.ErrorObject.Flag = Errors.Failed;
            }
          //  return DMEditor.ErrorObject;
        }


    }
}
