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
    public class HeavyOilVFieldViewModel : BaseViewModel
    {
        public List<WELL_LATEST_DATA> Wells { get; set; }

        [ICommand]
        public IErrorsInfo GetWells(string pfldid)
        {
            try
            {
                DMEditor.ErrorObject.Ex = null;
                DMEditor.ErrorObject.Flag = Errors.Ok;
                Wells = new List<WELL_LATEST_DATA>();
                var parameters = new { fldid = pfldid };
                var src = Task.Run(() => { return Repo.LoadData<List<WELL_LATEST_DATA>>("select * from well_latest_data where field_code=:fldid", parameters); });
                src.Wait();
                Wells =(List<WELL_LATEST_DATA>)src.Result;
            }
            catch (Exception ex)
            {

                DMEditor.AddLogMessage("Beep", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEditor.ErrorObject;
        }
      
    }
}
