using Beep.Winform.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public class IDEManager
    {
        public IDEManager(ICPythonManager cPythonManager)
        {
            pythonManager = cPythonManager;
        }
        private ICPythonManager pythonManager;
       
    }
}
