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
    public class WellReviewViewModel : BaseViewModel
    {
        public WELL_LATEST_DATA Well { get; set; }

        [ICommand]
        public IErrorsInfo GetWell(string puwi)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                Well = new WELL_LATEST_DATA();
                var parameters = new { UWI = puwi };
                var src = Task.Run(() => { return Repo.LoadData<WELL_LATEST_DATA>("select * from well_latest_data where uwi=:uwi", parameters); });
                src.Wait();
                Well = (WELL_LATEST_DATA)src.Result;
            }
            catch (Exception ex)
            {

                DMEditor.AddLogMessage("Beep", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEditor.ErrorObject;
        }
        [ICommand]
        public IErrorsInfo GetWell(int pwell_completion_id)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                Well = new WELL_LATEST_DATA();
                var parameters = new { well_completion_id = pwell_completion_id };
                var src = Task.Run(() => { return Repo.LoadData<WELL_LATEST_DATA>("select * from well_latest_data where well_completion_s=:well_completion_id", parameters); });
                src.Wait();
                Well = (WELL_LATEST_DATA)src.Result;
            }
            catch (Exception ex)
            {

                DMEditor.AddLogMessage("Beep", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEditor.ErrorObject;
        }


    }
}
