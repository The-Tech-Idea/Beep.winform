using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Controls
{
    [AddinAttribute(Caption = "Beep", Name = "ToolbarControl", misc = "Control")]
    public class ToolbarControl : IDM_Addin
    {
        public ToolbarControl(IDMEEditor pDMEEditor, TreeControl ptreeControl)
        {
            DMEEditor = pDMEEditor;
            Treecontrol = ptreeControl;

            vismanager = (VisManager)Treecontrol.Vismanager;
            TreeV = TreeV;
           

        }
        public TreeView TreeV { get; set; }
       
     
        private TreeControl Treecontrol { get; set; }
      
        public string ParentName { get ; set ; }
        public string ObjectName { get ; set ; }
        public string ObjectType { get; set; } 
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
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        public ToolStrip toolbarstrip { get; set; }
        public VisManager vismanager { get; set; }
        public List<ToolStripButton> menuitems { get; set; } = new List<ToolStripButton>();
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }
        private Size _iconsize = new Size(20, 20);
        private bool IsNewSizeSet = false;
        public Size IconSize { get { return _iconsize; } set { _iconsize = value; IsNewSizeSet = true; } }
        private ImageList GetImageList()
        {


            switch (IconSize.Height)
            {
                case 16:
                    return vismanager.Images16;
                    break;
                case 32:
                    return vismanager.Images32;
                    break;
                case 64:
                    return vismanager.Images64;
                    break;
                case 128:
                    return vismanager.Images128;
                    break;
                case 256:
                    return vismanager.Images256;
                    break;
                default:
                    return vismanager.Images;
                    break;
            }

        }
        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;

        }
        #region "MEnu and Tool"
        private bool IsMethodApplicabletoNode(AssemblyClassDefinition cls, IBranch br)
        {
            if (cls.classProperties == null)
            {
                return true;
            }
            if (cls.classProperties.ObjectType != null)
            {
                if (!cls.classProperties.ObjectType.Equals(br.BranchClass, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
            }
            return true;


        }
        public IErrorsInfo CreateToolbar()
        {
            try
            {

               
              
                    // toolbarstrip.AutoSize = false;

                toolbarstrip.ImageScalingSize = new Size(20, 20);
                toolbarstrip.Dock = System.Windows.Forms.DockStyle.Fill;
              //  toolbarstrip.Location = new System.Drawing.Point(342, 0);
                toolbarstrip.Name = "TreetoolStrip";
               // toolbarstrip.Size = new System.Drawing.Size(32, 580);
                toolbarstrip.Text = "toolStrip1";
                toolbarstrip.Stretch = true;
                
                //toolbarstrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.;
                toolbarstrip.ImageList = GetImageList();
                foreach (AssemblyClassDefinition cls in DMEEditor.ConfigEditor.GlobalFunctions.Where(x => x.componentType == "IFunctionExtension" && x.classProperties!=null && x.classProperties.ObjectType  !=null && x.classProperties.ObjectType.Equals(ObjectType,StringComparison.InvariantCultureIgnoreCase)))
                {
                  
                    foreach (var item in cls.Methods)
                    {
                        ToolStripButton toolStripButton1 = new ToolStripButton();
                        if (item.iconimage != null)
                        {
                            toolStripButton1.ImageIndex = vismanager.visHelper.GetImageIndex(item.iconimage, IconSize.Width);
                        }
                        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        toolStripButton1.TextAlign = ContentAlignment.BottomLeft;
                        //toolStripButton1.ImageAlign = ContentAlignment.TopRight;
                        toolStripButton1.Name = item.Name;
                        toolStripButton1.Size = new System.Drawing.Size(32, 64);
                        toolStripButton1.Text = item.Caption;
                        toolStripButton1.ToolTipText = item.Caption;
                        toolStripButton1.Click += RunFunction;
                        toolStripButton1.Tag = cls;
                        toolStripButton1.AutoSize = true;
                        toolStripButton1.Width = 32;
                        toolStripButton1.Font = new Font("Arial", 8, FontStyle.Regular);
                        toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
                        toolbarstrip.Items.Add(toolStripButton1);

                        ToolStripSeparator stripSeparator = new ToolStripSeparator();
                        toolbarstrip.Items.Add(stripSeparator);
                    }

                }
                ////-------------------------------------------------------------------------------------------

                return DMEEditor.ErrorObject;
            }
            catch (Exception ex)
            {

                return DMEEditor.ErrorObject;
            }
        }
        private void RunFunction(object sender, EventArgs e)
        {
            
            Treecontrol.RunFunction(sender, e);
        }
        #endregion
    }
}
