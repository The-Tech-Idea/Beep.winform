using System;
using System.Collections.Generic;
using System.Text;

namespace ML.NET.Interface
{
    public class MLProcess
    {
        public MLProcess() { }  
        public MLProcess(string name) { Name = name; }
        public string Name { get; set; }


    }
}
