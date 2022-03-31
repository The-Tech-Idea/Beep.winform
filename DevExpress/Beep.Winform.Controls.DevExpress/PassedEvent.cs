using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beep.Winform.Controls
{
    public class PassedEventArgs
    {
        public PassedEventArgs()
        {

        }
        public string EventName { get; set; }   
        public bool Cancel { get; set; }
        public string Message { get; set; }
        public Action<PassedEventArgs> DoAction { get; set; }
    }
}
