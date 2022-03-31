using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppBuilder.AppBuilder;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    public class PanelControl
    {
        public PanelControl()
        {
            ID = Guid.NewGuid().ToString(); ;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        [JsonIgnore]
        public Control BeepControl { get; set; }
      
        public AssemblyClassDefinition ClassProperties { get; set; }
        public PanelControl ParentControl { get; set; }

        public IAppField AppField { get; set; }
      
        public IAppComponent AppComponent { get; set; } 
        public List<ControlsProperties> ControlsProperties { get; set; } = new List<ControlsProperties>();

    }
    public class ControlsProperties
    {
        public ControlsProperties()
        {

        }
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
        
       

    }
}
