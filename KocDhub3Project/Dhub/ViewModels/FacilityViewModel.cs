using CommunityToolkit.Mvvm.ComponentModel;
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
    public class FacilityViewModel:BaseViewModel
    {
        [ObservableProperty]
        private List<WELL_LATEST_DATA> wells;

        [ICommand]
        public IErrorsInfo GetWells(string pfacilityid)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
               
                wells =Repo.GetFacilityWells(pfacilityid);
            }
            catch (Exception ex)
            {
                DMEditor.ErrorObject.Ex = ex;
                DMEditor.ErrorObject.Message = $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}";
                DMEditor.ErrorObject.Flag = Errors.Failed;
            }
            return DMEditor.ErrorObject;
        }
    }
}
