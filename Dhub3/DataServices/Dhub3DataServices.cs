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
       
        public Dhub3DataServices(IDMEEditor editor)
        {
            DMeditor = editor;
        }
        public IDMEEditor DMeditor { get; set; }
        public ResourceManager ResourceManager { get; set; }
        public IErrorsInfo CreateGetConnection()
        {
            try
            {

            }
            catch (Exception ex)
            {
                DMeditor.AddLogMessage("Dhub3", $"Could not Get/Create Data Connection {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
        }

    }
}
