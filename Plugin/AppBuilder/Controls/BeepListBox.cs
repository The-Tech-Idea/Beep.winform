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
    [AddinAttribute(Caption = "ListBox", Name = "BeepListBox", misc = "BeepListBox", addinType = AddinType.Class, iconimage = "ListBox.png")]
    public class BeepListBox:IAppComponent, IBeepControlInterface
    {
        public BeepListBox()
        {
            ComponentName = "Beep ListBox";
            ID = new Guid().ToString();
            ComponentType = (new ListBox()).GetType().AssemblyQualifiedName;
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
        ListBox listBox;
        public IErrorsInfo Bind(IPassedArgs args)
        {
            listBox = (ListBox)Panelcontrol.BeepControl;

            try
            {
                if (listBox != null)
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
            listBox = (ListBox)Panelcontrol.BeepControl;

            try
            {
                if (listBox != null)
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
            listBox=(ListBox)Panelcontrol.BeepControl;
            listBox.BorderStyle = BorderStyle.Fixed3D;
            listBox.Items.AddRange(new string[] { "item1", "Item2", "Item3" });
            return DMEEditor.ErrorObject;
        }
    }
}
