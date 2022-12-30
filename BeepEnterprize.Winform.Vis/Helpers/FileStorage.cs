using BeepEnterprize.Vis.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeepEnterprize.Winform.Vis.Helpers
{
    public class FileStorage : IFileStorage
    {
        public FileStorage()
        {
        }

        public string FileName { get ; set ; }
        public string Url { get ; set ; }
    }
}
