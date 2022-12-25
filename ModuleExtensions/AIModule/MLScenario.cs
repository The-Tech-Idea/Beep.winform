using System;
using System.Collections.Generic;
using System.Text;

namespace ML.NET.Interface
{
    public class MLScenario
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDescription { get; set; }
        public MLScenario() { }

    }
    
}
