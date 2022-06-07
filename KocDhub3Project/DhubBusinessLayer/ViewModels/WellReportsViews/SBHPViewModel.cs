using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KOC.DHUB3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TheTechIdea.Util;

namespace KOC.DHUB3.ViewModels.WellReportsViews
{
    public partial class SBHPViewModel :BaseViewModel
    {
        [ObservableProperty]
        WELL_LATEST_DATA well;
        [ICommand]
        private void GetWellByUWI(string puwi)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                well = Repo.GetWell(puwi);
            }
            catch (Exception ex)
            {
                DMEditor.ErrorObject.Ex = ex;
                DMEditor.ErrorObject.Message = $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}";
                DMEditor.ErrorObject.Flag = Errors.Failed;
            }
            //  return DMEditor.ErrorObject;
        }
        [ICommand]
        private void GetWellByCompletion(int pwell_completion_id)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                well = Repo.GetWell(pwell_completion_id);
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
