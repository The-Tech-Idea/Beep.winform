using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Helpers;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Controls
{
    [AddinAttribute(Caption = "Beep", Name = "MenuControl", misc = "Control")]
    public class MenuControl : IDM_Addin
    {
        public MenuControl(IDMEEditor pDMEEditor, TreeControl ptreeControl)
        {
            DMEEditor = pDMEEditor;
            Treecontrol = ptreeControl;

            vismanager = (VisManager)Treecontrol.Vismanager;
            TreeV = (System.Windows.Forms.TreeView)Treecontrol.TreeV;
           // CreateToolbar();

        }
        public TreeView TreeV { get; set; }
     
        private TreeControl Treecontrol { get; set; }
      
        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get ; set ; }
        public string AddinName { get ; set ; }
        public string Description { get ; set ; }
        public bool DefaultCreate { get ; set ; }
        public string DllPath { get ; set ; }
        public string DllName { get ; set ; }
        public string NameSpace { get ; set ; }
        public IErrorsInfo ErrorObject { get ; set ; }
        public IDMLogger Logger { get ; set ; }
        public IDMEEditor DMEEditor { get ; set ; }
        public EntityStructure EntityStructure { get ; set ; }
        public bool IsBeepDataOn { get; set; } = true;
        public bool IsAppOn { get; set; } = true;
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        public MenuStrip menustrip { get; set; }
        public  VisManager vismanager { get; set; }
        public List<ToolStripMenuItem> menuitems { get; set; } = new List<ToolStripMenuItem>();
        VisHelper visHelper { get { return (VisHelper)vismanager.visHelper; }  }
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;
        }
        public IErrorsInfo CreateGlobalMenu()
        {
            try
            {
              
              
                List<AssemblyClassDefinition> extentions = DMEEditor.ConfigEditor.GlobalFunctions.Where(o=>o.classProperties!=null && o.classProperties.ObjectType!=null && o.classProperties.ObjectType.Equals(ObjectType,StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p.Order).ToList();
                foreach (AssemblyClassDefinition cls in extentions)
                {
                    Type type = cls.type;
                    AddinAttribute attrib = (AddinAttribute)type.GetCustomAttribute(typeof(AddinAttribute), true);
                    if (attrib != null)
                    {
                        menustrip.ImageList = vismanager.Images;
                        ToolStripMenuItem Extensionsmenu = new ToolStripMenuItem();

                        Extensionsmenu.Name = attrib.Name;
                      //  Extensionsmenu.Size = new System.Drawing.Size(37, 20);
                        Extensionsmenu.Text = attrib.Caption;
                        Extensionsmenu.Tag = attrib.TypeId;
                        Extensionsmenu.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                        Extensionsmenu.ImageIndex = vismanager.visHelper.GetImageIndex(attrib.iconimage);
                        menuitems.Add(Extensionsmenu);
                        menustrip.Items.Add(Extensionsmenu);
                        foreach (MethodsClass item in cls.Methods)
                        {
                            ToolStripMenuItem menuItem = new ToolStripMenuItem();
                            menuItem.Name = item.Name;
                       //     menuItem.Size = new System.Drawing.Size(24, 24);
                            menuItem.Text = item.Caption;
                            menuItem.Tag = cls;
                            menuItem.Click += RunToolStripFunction;
                            menuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                            menuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                            menuItem.Image = visHelper.GetImage(item.iconimage);
                            Extensionsmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem });
                           
                           
                        }
                        
                    }

                }
                if (ObjectType == "Beep")
                {
                    ToolStripMenuItem Configmenu = new ToolStripMenuItem();
                    Configmenu.Name = "Config";
                    // Configmenu.Size = new System.Drawing.Size(37, 20);
                    Configmenu.Text = "Configuration";
                    Configmenu.Tag = "Config";
                    Configmenu.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                    Configmenu.ImageIndex = vismanager.visHelper.GetImageIndex("configuration.ico");
                    foreach (AddinTreeStructure item in DMEEditor.ConfigEditor.AddinTreeStructure)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem();
                        menuItem.Name = item.NodeName;
                        //  menuItem.Size = new System.Drawing.Size(37, 20);
                        menuItem.Text = item.NodeName;
                        menuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        menuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                        menuItem.Tag = item.className;
                        menuItem.Click += RunConfigFunction;
                        menuItem.Image = visHelper.GetImage(item.Imagename);
                        // menuItem.ImageIndex = vismanager.visHelper.GetImageIndex(item.Imagename);
                        Configmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem });
                    }
                    menustrip.Items.Add(Configmenu);
                }
             
                ////-------------------------------------------------------------------------------------------
                
                
                return DMEEditor.ErrorObject;
            }
            catch (Exception ex)
            {

                return DMEEditor.ErrorObject;
            }
        }
     
        
        private void RunToolStripFunction(object sender, EventArgs e)
        {
            
            Treecontrol.RunFunction(sender, e);
        }
        private void RunConfigFunction(object sender, EventArgs e)
        {
          //  Treecontrol.RunFunction(sender, e);
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            PassedArgs Passedarguments = new PassedArgs
            {  // Obj= obj,
                Addin = null,
                AddinName = null,
                AddinType = null,
                DMView = null,
                CurrentEntity = menuItem.Name,
                ObjectName = menuItem.Name,

                ObjectType = menuItem.Tag.ToString(),

                EventType = "Run"

            };
            vismanager.ShowUserControlPopUp(menuItem.Tag.ToString(), DMEEditor, null, Passedarguments);
        }
    }
}
