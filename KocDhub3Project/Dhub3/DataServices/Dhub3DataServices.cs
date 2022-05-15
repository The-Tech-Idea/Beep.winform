using Beep.Winform.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Beep;
using TheTechIdea.Util;

namespace Dhub3.DataServices
{
    public class Dhub3DataServices
    {
        public Dhub3DataServices(DMEEditor editor)
        {
            DMeditor = editor;
        }
        public IDMEEditor DMeditor { get; set; }
        public ResourceManager ResourceManager { get; set; }
        public IErrorsInfo CreateGetConnection()
        {
            try
            {
                DMeditor.ErrorObject.Ex = null;
                DMeditor.ErrorObject.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Error in  {System.Reflection.MethodBase.GetCurrentMethod().Name} -  {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMeditor.ErrorObject;
        }
       
    }
}
