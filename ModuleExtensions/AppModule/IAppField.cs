using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TheTechIdea.Beep.DataBase;

namespace TheTechIdea.Beep.AppModule
{

    public interface IAppField
    {
        string ID { get; set; }
        string Datasourcename { get; set; }
        string Entityname { get; set; }
        IEntityField EntityField { get; set; }
        string CheckboxFalseValue { get; set; }
        bool CheckboxOtherValues { get; set; }
        string CheckboxTrueValue { get; set; }
        bool IsLabelDisplayed { get; set; }
        string Label { get; set; }
        bool Enabled { get; set; }
        IAppComponent AppComponent { get; set; }
        bool ValueRetrievedFromParent { get; set; }
        string LookupDisplay { get; set; }
        string LookupEntity { get; set; }
        string LookupValue { get; set; }
        event EventHandler<IAppBlock> Changed;
        event EventHandler<IAppBlock> PreFill;
        event EventHandler<IAppBlock> FillChilds;


    }
}
