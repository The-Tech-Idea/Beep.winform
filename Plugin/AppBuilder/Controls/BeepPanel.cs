using System;
using System.Collections.Generic;
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
    [AddinAttribute(Caption = "Panel", Name = "BeepPanel", misc = "BeepPanel", addinType = AddinType.Class, iconimage = "Panel.png")]
    public class BeepPanel : IAppComponent, IBeepControlInterface
    {
        public BeepPanel()
        {
            ID = new Guid().ToString();
            ComponentType = (new Panel()).GetType().AssemblyQualifiedName;
            IsContainer = true;
            container = new ContainerControl();
        }
        public string ID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public bool IsContainer { get; set; } = true;
        public bool IsTableView { get; set; } = false;
        public PanelControl Panelcontrol { get { return container.Panelcontrol; } set { container.Panelcontrol = value; } }

        static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        [JsonIgnore]
        public DMEEditor DMEEditor { get { return container.DMEEditor; } set { container.DMEEditor = value; } }
        [JsonIgnore]
        public ScreenDesigner ScreenDesigner { get { return container.ScreenDesigner; } set { container.ScreenDesigner = value; } }
       
        private ContainerControl container;

        public IErrorsInfo Bind(IPassedArgs args)
        {
            container.Container = (Panel)Panelcontrol.BeepControl;
            container.Bind(args);
            return DMEEditor.ErrorObject;

        }

        public IErrorsInfo ChangeVisual(IPassedArgs args)
        {

            container.Container = (Panel)Panelcontrol.BeepControl;
            container.ChangeVisual(args);


            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo Init(IPassedArgs args)
        {

            container.Container = (Panel)Panelcontrol.BeepControl;
            Panel p = (Panel)Panelcontrol.BeepControl;
            p.BorderStyle = BorderStyle.Fixed3D;
            container.Init(args);
            return DMEEditor.ErrorObject;

        }
    }
}