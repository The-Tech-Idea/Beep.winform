﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheTechIdea.Beep.AI.Interface
{
    public interface ITrainedModel
    {
        string ModelName { get; set; }
        string AlgorithemName { get; set; }
        
    }
}
