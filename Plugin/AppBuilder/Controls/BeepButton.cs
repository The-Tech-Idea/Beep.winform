using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppBuilder.Controls;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.AppBuilder.Controls
{
    [AddinAttribute(Caption = "Button", Name = "BeepButton", misc = "BeepButton", addinType = AddinType.Class, iconimage = "Button.png")]
    public class BeepButton : IAppComponent, IBeepControlInterface
    {
        public BeepButton()
        {
            ID = new Guid().ToString();
            ComponentType = (new Button()).GetType().AssemblyQualifiedName;
        }
        public string ID { get ; set ; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public bool IsContainer { get; set; } = false;
        public PanelControl Panelcontrol { get ; set ; }
        [JsonIgnore]
        public DMEEditor DMEEditor { get; set; }
        [JsonIgnore]
        public ScreenDesigner ScreenDesigner { get; set; }
        Button button;
        public bool IsTableView { get; set; } = false;
        public IErrorsInfo Bind(IPassedArgs args)
        {
            button = (Button)Panelcontrol.BeepControl;

            try
            {
                if (button != null)
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
            button = (Button)Panelcontrol.BeepControl;

            try
            {
                if (button != null)
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
             button = (Button)Panelcontrol.BeepControl;
           
            try
            {
                if (button != null)
                {
                    if (args != null)
                    {
                        if (string.IsNullOrEmpty(args.CurrentEntity))
                        {
                            button.Text = args.CurrentEntity;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in init Button {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }

        
    }
}
