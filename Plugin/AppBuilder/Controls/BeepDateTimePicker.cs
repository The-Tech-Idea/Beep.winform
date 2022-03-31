using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.Controls
{
    [AddinAttribute(Caption = "DateTimePicker", Name = "BeepDateTimePicker", misc = "BeepDateTimePicker", addinType = AddinType.Class, iconimage = "DateTimePicker.png")]
    public class BeepDateTimePicker:IAppComponent, IBeepControlInterface
    {
        public BeepDateTimePicker()
        {
            ComponentName = "Beep DatTimePicker";
            ID = new Guid().ToString();
            ComponentType = (new DateTimePicker()).GetType().AssemblyQualifiedName;
        }

        public string ID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public bool IsContainer { get; set; } = false;
        public bool IsTableView { get; set; } = false;
        public PanelControl Panelcontrol { get ; set ; }
        [JsonIgnore]
        public DMEEditor DMEEditor { get; set; }
        [JsonIgnore]
        public ScreenDesigner ScreenDesigner { get; set; }
        DateTimePicker picker;
        public IErrorsInfo Bind(IPassedArgs args)
        {
            picker = (DateTimePicker)Panelcontrol.BeepControl;

            try
            {
                if (picker != null)
                {
                    if (args != null)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Change Visual  {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }

        public IErrorsInfo ChangeVisual(IPassedArgs args)
        {
            picker = (DateTimePicker)Panelcontrol.BeepControl;

            try
            {
                if (picker != null)
                {
                    if (args != null)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Change Visual  {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }

        public IErrorsInfo Init(IPassedArgs args)
        {
            picker = (DateTimePicker)Panelcontrol.BeepControl;
            picker.ShowCheckBox=true;
            picker.Value = DateTime.Now;
            
            return DMEEditor.ErrorObject;
        }
    }
}
