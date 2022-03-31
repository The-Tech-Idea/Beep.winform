using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace Beep.DExpress.Common
{
    public class BeepDxObjectDataSource
    {
        public IDMEEditor DMEEditor { get; set; }
        public EntityStructure Entity { get; set; }
        public List<AppFilter> ReportFilters { get; set; }
        public IDataSource  DataSource { get; set; }
        public string EntityName { get; set; }
        public BeepDxObjectDataSource()
        {
          

        }
        public IEnumerable<T> GetData<T>(List<AppFilter> Filters)
        {
            IEnumerable<T> retval =null;
            try
            {
               
                ReportFilters = Filters;
                if (DataSource != null)
                {
                    DataSource.Openconnection();
                    if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                    {
                        if (Filters != null)
                        {
                            retval =(IEnumerable<T>) DataSource.GetEntity(EntityName, ReportFilters);
                        }else
                        {
                            retval = (IEnumerable<T>)DataSource.GetEntity(EntityName, null);
                        }
                       
                    }
                    else
                    {
                        DMEEditor.AddLogMessage("Beep", $"Could not OPEN DataSource for Entity {EntityName}", DateTime.Now, 0, null, Errors.Failed);
                    }
                }
                else
                {
                    DMEEditor.AddLogMessage("Beep", $"Could not GET DataSource for Entity {EntityName}", DateTime.Now, 0, null, Errors.Failed);
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Could not ADD Parameters to Entity {EntityName}", DateTime.Now, 0, null, Errors.Failed);
            }

            return retval;
        }
    }
}
