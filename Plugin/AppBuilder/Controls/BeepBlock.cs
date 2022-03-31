using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.Controls
{
    [AddinAttribute(Caption = "Block", Name = "BeepBlock", misc = "BeepBlock", addinType = AddinType.Class, iconimage = "GroupBox.png")]
    public class BeepBlock : IAppComponent, IBeepControlInterface
    {
        public BeepBlock()
        {
            ID = new Guid().ToString();
            ComponentType = (new GroupBox()).GetType().AssemblyQualifiedName;
            IsContainer = true;
            container = new ContainerControl();
        }
        public string ID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public PanelControl Panelcontrol { get { return container.Panelcontrol; } set { container.Panelcontrol = value; } }
      
        static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        [JsonIgnore]
        public DMEEditor DMEEditor { get { return container.DMEEditor; }  set { container.DMEEditor = value; } }
        [JsonIgnore]
        public ScreenDesigner ScreenDesigner { get { return container.ScreenDesigner; } set { container.ScreenDesigner = value; } }
        public bool IsContainer { get ; set ; }=true;
        public bool IsTableView { get; set; } = false;
        private ContainerControl container;

        public IErrorsInfo Bind(IPassedArgs args)
        {
            container.Container = (GroupBox)Panelcontrol.BeepControl;
            container.Bind(args);
            return DMEEditor.ErrorObject;

        }

        public IErrorsInfo ChangeVisual(IPassedArgs args)
        {

            container.Container = (GroupBox)Panelcontrol.BeepControl;
            container.ChangeVisual(args);

         
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo Init(IPassedArgs args)
        {

            container.Container = (GroupBox)Panelcontrol.BeepControl;
            GroupBox p = (GroupBox)Panelcontrol.BeepControl;
            p.FlatStyle = FlatStyle.Standard;
            container.Init(args);
            return DMEEditor.ErrorObject;

        }

        public IErrorsInfo Remove(PanelControl control)
        {
            return container.Remove(control);
        }
      
    }
}