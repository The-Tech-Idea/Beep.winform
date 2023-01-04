using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public  class CpythonConfig
    {
        public CpythonConfig() { }
        public string LastfilePath { get; set; }
        public string Script { get; set; }
        public string RuntimePath { get; set; }
        public string BinPath { get; set; }
        public string Packageinstallpath { get; set; }
        public string AiFolderpath { get; set; }
    }
}
