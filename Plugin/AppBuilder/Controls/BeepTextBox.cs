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
    [AddinAttribute(Caption = "TextBox", Name = "BeepTextBox", misc = "BeepTextBox", addinType = AddinType.Class, iconimage = "TextBox.png")]
    public class BeepTextBox:IAppComponent, IBeepControlInterface
    {
        public BeepTextBox()
        {
            ComponentName = "Beep TextBox";
            ID = new Guid().ToString();
            ComponentType = (new TextBox()).GetType().AssemblyQualifiedName;
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
        TextBox textbox;
        public IErrorsInfo Bind(IPassedArgs args)
        {
            textbox = (TextBox)Panelcontrol.BeepControl;

            try
            {
                if (textbox != null)
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
            textbox = (TextBox)Panelcontrol.BeepControl;

            try
            {
                if (textbox != null)
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
            textbox = (TextBox)Panelcontrol.BeepControl;
            textbox.BorderStyle = BorderStyle.FixedSingle;
            
            return DMEEditor.ErrorObject;
        }
    }
}
