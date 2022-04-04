using System.Collections.Generic;
using System.Data;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis
{
    public interface IControlManager
    {
        string DialogCombo(string text, List<object> comboSource, string DisplyMember, string ValueMember);
        IErrorsInfo GenerateEntityonControl(string entityname, object record, int width, string datasourceid, TransActionType TranType,  IPassedArgs passedArgs = null);
        
        DialogResult InputBox(string title, string promptText, ref string value);
        DialogResult InputBoxYesNo(string title, string promptText);
        DialogResult InputComboBox(string title, string promptText, List<string> itvalues, ref string value);
        string LoadFileDialog(string exts, string dir, string filter);
        List<string> LoadFilesDialog(string exts, string dir, string filter);
        string SaveFileDialog(string exts, string dir, string filter);
        void MsgBox(string title, string promptText);
        List<FilterType> AddFilterTypes();
        void CreateEntityFilterControls(  EntityStructure entityStructure, List<DefaultValue> dsdefaults, IPassedArgs passedArgs = null);
        void CreateFieldsFilterControls(List<EntityField> Fields, List<AppFilter> Filters, List<DefaultValue> dsdefaults, IPassedArgs passedArgs = null);
    }
}