using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;

namespace TheTechIdea.Beep.AppBuilder.AppBuilder
{
    public class AppField : IAppField
    {
        public AppField()
        {
            ID=Guid.NewGuid().ToString();
        }
        public string ID { get ; set ; }
        public string Datasourcename { get ; set ; }
        public string Entityname { get ; set ; }
        public IEntityField EntityField { get ; set ; }
        public string CheckboxFalseValue { get ; set ; }
        public bool CheckboxOtherValues { get ; set ; }
        public string CheckboxTrueValue { get ; set ; }
        public bool IsLabelDisplayed { get ; set ; }
        public string Label { get ; set ; }
        public bool Enabled { get ; set ; }
        public IAppComponent AppComponent { get ; set ; }
        public bool ValueRetrievedFromParent { get ; set ; }
        public string LookupDisplay { get ; set ; }
        public string LookupEntity { get ; set ; }
        public string LookupValue { get ; set ; }

        public event EventHandler<IAppBlock> Changed;
        public event EventHandler<IAppBlock> PreFill;
        public event EventHandler<IAppBlock> FillChilds;
    }
}
