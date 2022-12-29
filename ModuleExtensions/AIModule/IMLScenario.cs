
using System;
using TheTechIdea.Beep.DataView;

namespace TheTechIdea.Beep.AI.Interface
{
    public interface IMLScenario
    {
        Guid GuidId { get; set; }
        int Id { get; set; }
        string ScenarioDescription { get; set; }
        string ScenarioName { get; set; }
        string TrainDataPath { get; set; }
        string TestDataPath { get; set; }
        string ModelPath { get; set; }

        string TestDataSourceName { get; set; }
        

        

    }
}