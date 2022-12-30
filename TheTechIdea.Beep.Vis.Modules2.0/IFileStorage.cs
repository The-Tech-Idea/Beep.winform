using System;
using System.Collections.Generic;
using System.Text;

namespace BeepEnterprize.Vis.Module
{
    public interface IFileStorage
    {
        string FileName { get; set; }
        string Url { get; set; }
    }
}
