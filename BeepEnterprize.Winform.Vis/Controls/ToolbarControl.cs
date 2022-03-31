using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
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
        public System.Windows.Forms.TreeView TreeV { get; set; }
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
        public string EntityName { get ; set ; }
        public IPassedArgs Passedarg { get ; set ; }
        public ToolStrip toolbarstrip { get; set; }
        public VisManager vismanager { get; set; }
        public List<ToolStripButton> menuitems { get; set; } = new List<ToolStripButton>();
        public void Run(IPassedArgs pPassedarg)
        {
            throw new NotImplementedException();
        }

        public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
        {
            DMEEditor = pbl;

        }
        #region "MEnu and Tool"
        public IErrorsInfo CreateToolbar()
        {
            try
            {

               
              
                    // toolbarstrip.AutoSize = false;

                toolbarstrip.ImageScalingSize = new Size(20, 20);
                toolbarstrip.Dock = System.Windows.Forms.DockStyle.Fill;
                toolbarstrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
                toolbarstrip.Location = new System.Drawing.Point(342, 0);
                toolbarstrip.Name = "TreetoolStrip";
                toolbarstrip.Size = new System.Drawing.Size(32, 580);
                toolbarstrip.Text = "toolStrip1";
                toolbarstrip.Stretch = true;
                
                //toolbarstrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.;
                toolbarstrip.ImageList = vismanager.Images;
                foreach (AssemblyClassDefinition cls in DMEEditor.ConfigEditor.GlobalFunctions.Where(x => x.componentType == "IFunctionExtension"))
                {
                  
                    foreach (var item in cls.Methods)
                    {
                        ToolStripButton toolStripButton1 = new ToolStripButton();
                        if (item.iconimage != null)
                        {
                            toolStripButton1.ImageIndex = vismanager.visHelper.GetImageIndex(item.iconimage);
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
            //IBranch br = null;
            //ToolStripItem item = (ToolStripItem)sender;
         
            //if (TreeV.SelectedNode != null)
            //{
            //    TreeNode n = TreeV.SelectedNode;

            //    br = Treecontrol.treeBranchHandler.GetBranch(Convert.ToInt32(n.Tag));
            //}
            Treecontrol.RunFunction(sender, e);
        }
        #endregion
    }
}
