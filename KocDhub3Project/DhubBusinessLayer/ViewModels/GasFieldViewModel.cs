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
    public partial class GasFieldViewModel : BaseViewModel
    {
       
        [ObservableProperty]
        List<WELL_LATEST_DATA> wells;

        [ICommand]
        private void GetWells(string pfldid)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                wells = new List<WELL_LATEST_DATA>();

                wells = Repo.GetFieldWells(pfldid);
            }
            catch (Exception ex)
            {
                DMEditor.ErrorObject.Ex = ex;
                DMEditor.ErrorObject.Message = $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}";
                DMEditor.ErrorObject.Flag = Errors.Failed;
            }
           // return DMEditor.ErrorObject;
        }
    }
}
