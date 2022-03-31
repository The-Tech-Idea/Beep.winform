using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.DataView;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Controls
{
    public class TreeBranchHandler : ITreeBranchHandler
    {
        public TreeBranchHandler(IDMEEditor pDMEEditor, TreeControl ptreeControl)
        {
            DMEEditor = pDMEEditor;
            Tree = ptreeControl;
            Treecontrol = ptreeControl;
            visManager = (VisManager)Treecontrol.Vismanager;
            TreeV = Treecontrol.TreeV;
            CreateDelagates();

        }
        public System.Windows.Forms.TreeView TreeV { get; set; }
        private TreeControl Treecontrol { get; set; }
        public IDMEEditor DMEEditor { get; set; }
       // public System.Windows.Forms.TreeView treeControl { get; set; }
        private ITree Tree { get; set; }

        private VisManager visManager { get; set; }


        #region "Branch Handling"

        public IErrorsInfo CreateBranch(IBranch Branch)
        {
            throw new NotImplementedException();
        }
        public IErrorsInfo AddBranch(IBranch ParentBranch, IBranch Branch)
        {
            try
            {
                AssemblyClassDefinition cls = DMEEditor.ConfigEditor.BranchesClasses.Where(x => x.PackageName == Branch.ToString()).FirstOrDefault();
                Branch.Name = cls.PackageName;
                TreeNode p = Treecontrol.GetTreeNodeByTag(ParentBranch.BranchID.ToString(), TreeV.Nodes);
                TreeNode n = p.Nodes.Add(Branch.BranchText);
                if (visManager.visHelper.GetImageIndex(Branch.IconImageName) == -1)
                {
                    n.ImageIndex = visManager.visHelper.GetImageIndexFromConnectioName(Branch.BranchText);
                    n.SelectedImageIndex = visManager.visHelper.GetImageIndexFromConnectioName(Branch.BranchText);
                }
                else
                {
                    n.ImageKey = Branch.IconImageName;
                    n.SelectedImageKey = Branch.IconImageName;
                }

                Branch.TreeEditor = Tree;
                Branch.Visutil = visManager;
                n.Tag = Branch.BranchID;
                n.ContextMenuStrip = Treecontrol.CreateMenuMethods(Branch);
                Treecontrol.CreateGlobalMenu(Branch, n);
                Branch.DMEEditor = DMEEditor;
                // ITreeView treeView = (ITreeView)Branch;
                //  treeView.Visutil = Visutil;
                Tree.Branches.Add(Branch);
                if (!DMEEditor.ConfigEditor.objectTypes.Any(i => i.ObjectType == Branch.BranchClass && i.ObjectName == Branch.BranchType.ToString() + "_" + Branch.BranchClass))
                {
                    DMEEditor.ConfigEditor.objectTypes.Add(new TheTechIdea.Beep.Workflow.ObjectTypes { ObjectType = Branch.BranchClass, ObjectName = Branch.BranchType.ToString() + "_" + Branch.BranchClass });
                }
                if (Branch.BranchType == EnumPointType.Entity)
                {
                    if (Branch.BranchClass == "VIEW")
                    {
                        //   DataViewDataSource dataViewDatasource = (DataViewDataSource)DMEEditor.GetDataSource(Branch.DataSourceName);
                        EntityStructure e = Branch.EntityStructure;
                        EntityStructure parententity = GetBranch(Branch.ParentBranchID).EntityStructure;
                        if (e != null && parententity != null)
                        {
                            switch (e.Viewtype)
                            {
                                case ViewType.Table:
                                    if (e.DataSourceID != parententity.DataSourceID)
                                    {
                                        n.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        n.ForeColor = Color.Black;
                                        n.BackColor = Color.LightYellow;
                                    }

                                    break;
                                case ViewType.Query:
                                    if (e.DataSourceID != parententity.DataSourceID)
                                    {
                                        n.ForeColor = Color.Red;
                                    }
                                    else
                                    {
                                        n.ForeColor = Color.Red;
                                        n.BackColor = Color.LightYellow;
                                    }
                                    break;
                                case ViewType.Code:
                                    break;
                                case ViewType.File:
                                    if (e.DataSourceID != parententity.DataSourceID)
                                    {
                                        n.ForeColor = Color.Blue;
                                    }
                                    else
                                    {
                                        n.ForeColor = Color.Blue;
                                        n.BackColor = Color.LightYellow;
                                    }
                                    break;
                                case ViewType.Url:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (Branch.EntityStructure != null)
                    {
                        if (Branch.EntityStructure.Created == false && Branch.BranchClass != "VIEW")
                        {
                            n.ForeColor = Color.Red;
                            n.BackColor = Color.LightYellow;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                string mes = "Could not Add Branch to " + ParentBranch.BranchText;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }
        public string CheckifBranchExistinCategory(string BranchName, string pRootName)
        {
            //bool retval = false;
            List<CategoryFolder> ls = DMEEditor.ConfigEditor.CategoryFolders.Where(x => x.RootName == pRootName).ToList();
            foreach (CategoryFolder item in ls)
            {
                foreach (string f in item.items)
                {
                    if (f == BranchName)
                    {
                        return item.FolderName;
                    }
                }
            }
            return null;
        }

        public bool RemoveEntityFromCategory(string root, string foldername, string entityname)
        {

            try
            {
                CategoryFolder f = DMEEditor.ConfigEditor.CategoryFolders.Where(x => x.RootName == root && x.FolderName == foldername).FirstOrDefault();
                if (f != null)
                {
                    f.items.Remove(entityname);
                }

                return true;
            }
            catch (Exception ex)
            {
                string mes = "";
                DMEEditor.AddLogMessage(ex.Message, "Could not remove entity from category" + mes, DateTime.Now, -1, mes, Errors.Failed);
                return false;
            };
        }
        public IErrorsInfo RemoveBranch(IBranch Branch)
        {

            try
            {

                TreeNode n = Treecontrol.GetTreeNodeByTag(Branch.BranchID.ToString(), TreeV.Nodes);
                RemoveChildBranchs(Branch);
                Tree.Branches.Remove(Branch);
                if (n != null)
                {
                    n.Remove();
                }


                // DMEEditor.AddLogMessage("Success", "removed node and childs", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not  remove node and childs";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }
        public IErrorsInfo RemoveChildBranchs(IBranch branch)
        {
            try
            {
                if (branch.ChildBranchs != null)
                {
                    if (branch.ChildBranchs.Count > 0)
                    {
                        foreach (IBranch item in branch.ChildBranchs)
                        {
                            if (branch.ChildBranchs.Count > 0)
                            {
                                RemoveBranch(item);
                            }
                            if(Tree.SelectedBranchs.Contains(item.BranchID))
                            {
                                Tree.SelectedBranchs.Remove(item.BranchID);
                            }
                            Tree.Branches.Remove(item);
                        }

                        branch.ChildBranchs.Clear();
                        TreeNode n = Treecontrol.GetTreeNodeByTag(branch.BranchID.ToString(), TreeV.Nodes);
                        if (n != null)
                        {
                            n.Nodes.Clear();

                        }
                    }
                }




                //  DMEEditor.AddLogMessage("Success", "removed childs", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not  remove   childs";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        public IBranch GetBranch(int pID)
        {
            return Tree.Branches.Where(c => c.BranchID == pID).FirstOrDefault();
        }
        public IBranch GetBranchByMiscID(int pID)
        {
            return Tree.Branches.Where(c => c.MiscID == pID).FirstOrDefault();
        }
        public IErrorsInfo MoveBranchToParent(IBranch ParentBranch, IBranch CurrentBranch)
        {

            try
            {
                TreeNode ParentBranchNode = Treecontrol.GetTreeNodeByTag(ParentBranch.BranchID.ToString(), TreeV.Nodes);
                TreeNode CurrentBranchNode = Treecontrol.GetTreeNodeByTag(CurrentBranch.BranchID.ToString(), TreeV.Nodes);
                string foldername = CheckifBranchExistinCategory(CurrentBranch.BranchText, CurrentBranch.BranchClass);
                if (foldername != null)
                {
                    RemoveEntityFromCategory(ParentBranch.BranchClass, foldername, CurrentBranch.BranchText);
                }
                TreeV.Nodes.Remove(CurrentBranchNode);


                CategoryFolder CurFodler = DMEEditor.ConfigEditor.CategoryFolders.Where(y => y.RootName == ParentBranch.BranchClass).FirstOrDefault();
                if (CurFodler != null)
                {
                    if (CurFodler.items.Contains(CurrentBranch.BranchText) == false)
                    {
                        CurFodler.items.Remove(CurrentBranch.BranchText);
                    }
                }

                CategoryFolder NewFolder = DMEEditor.ConfigEditor.CategoryFolders.Where(y => y.FolderName == ParentBranch.BranchText && y.RootName == ParentBranch.BranchClass).FirstOrDefault();
                if (NewFolder != null)
                {
                    if (NewFolder.items.Contains(CurrentBranch.BranchText) == false)
                    {
                        NewFolder.items.Add(CurrentBranch.BranchText);
                    }
                }
                if ((ParentBranch.BranchType == EnumPointType.Entity) && (ParentBranch.BranchClass == "VIEW" && CurrentBranch.BranchClass == "VIEW") && (ParentBranch.DataSourceName == CurrentBranch.DataSourceName))
                {
                    DataViewDataSource vds = (DataViewDataSource)DMEEditor.GetDataSource(CurrentBranch.DataSourceName);
                    if (vds.Entities[vds.EntityListIndex(ParentBranch.MiscID)].Id == vds.Entities[vds.EntityListIndex(CurrentBranch.MiscID)].ParentId)
                    {

                    }
                    else
                    {
                        vds.Entities[vds.EntityListIndex(CurrentBranch.MiscID)].ParentId = vds.Entities[vds.EntityListIndex(ParentBranch.MiscID)].Id;
                    }


                }

                ParentBranchNode.Nodes.Add(CurrentBranchNode);

                DMEEditor.ConfigEditor.SaveCategoryFoldersValues();

                DMEEditor.AddLogMessage("Success", "Moved Branch successfully", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Moved Branch";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo RemoveBranch(int id)
        {

            try
            {
                RemoveBranch(Tree.Branches.Where(x => x.BranchID == id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                string mes = "Could not  remove node and childs";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }
        public IErrorsInfo AddCategory(IBranch Rootbr)
        {

            try
            {
                DMEEditor.Passedarguments = new PassedArgs();
                string foldername = "";
                // Visutil.controlEditor.InputBox("Enter Category Name", "What Category you want to Add", ref foldername);
                if (foldername != null)
                {
                    if (foldername.Length > 0)
                    {
                        CategoryFolder x = DMEEditor.ConfigEditor.AddFolderCategory(foldername, Rootbr.BranchClass, foldername);
                        IBranchRootCategory f = (IBranchRootCategory)Rootbr;
                        f.CreateCategoryNode(x);
                        DMEEditor.ConfigEditor.SaveCategoryFoldersValues();

                    }
                }
                DMEEditor.AddLogMessage("Success", "Added Category", DateTime.Now, 0, null, Errors.Failed);
            }
            catch (Exception ex)
            {
                string mes = "Could not Add Category";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo RemoveCategoryBranch(int id)
        {

            try
            {
                IBranch CategoryBranch = GetBranch(id);
                IBranch RootBranch = GetBranch(CategoryBranch.ParentBranchID);
                TreeNode CategoryBranchNode = Treecontrol.GetTreeNodeByTag(CategoryBranch.BranchID.ToString(), TreeV.Nodes);
                var ls = Tree.Branches.Where(x => x.ParentBranchID == id).ToList();
                if (ls.Count() > 0)
                {
                    foreach (IBranch f in ls)
                    {
                        MoveBranchToParent(RootBranch, f);
                    }
                }

                TreeV.Nodes.Remove(CategoryBranchNode);
                CategoryFolder Folder = DMEEditor.ConfigEditor.CategoryFolders.Where(y => y.FolderName == CategoryBranch.BranchText && y.RootName == CategoryBranch.BranchClass).FirstOrDefault();
                DMEEditor.ConfigEditor.CategoryFolders.Remove(Folder);

                DMEEditor.ConfigEditor.SaveCategoryFoldersValues();
                DMEEditor.AddLogMessage("Success", "Removed Branch successfully", DateTime.Now, 0, null, Errors.Ok);

            }
            catch (Exception ex)
            {
                string mes = "";
                DMEEditor.AddLogMessage(ex.Message, "Could not remove category" + mes, DateTime.Now, -1, mes, Errors.Failed);

            };
            return DMEEditor.ErrorObject;

        }
        public IErrorsInfo SendActionFromBranchToBranch(IBranch ToBranch, IBranch CurrentBranch, string ActionType)
        {
            string targetBranchClass = ToBranch.GetType().Name;
            string dragedBranchClass = CurrentBranch.GetType().Name;


            try
            {

                Function2FunctionAction functionAction = DMEEditor.ConfigEditor.Function2Functions.Where(x => x.FromClass == dragedBranchClass && x.ToClass == targetBranchClass && x.ToMethod == ActionType).FirstOrDefault();
                if (functionAction != null)
                {
                    Treecontrol.RunMethod(ToBranch, ActionType);
                }
                //   DMEEditor.AddLogMessage("Success", "Added Database Connection", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not send action to branch";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }



        #endregion

        #region "Node Handling Functions"
        public void CreateDelagates()
        {
            // TreeV.DrawMode=TreeViewDrawMode.OwnerDrawText;
            TreeV.AllowDrop = true;
            TreeV.NodeMouseClick += TreeView1_NodeMouseClick;
            TreeV.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
            TreeV.AfterCheck += TreeView1_AfterCheck;

          
            TreeV.AfterSelect += TreeV_AfterSelect;
         
        }
        private void TreeV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey)
            {
                Treecontrol.TreeOP = "UnSelect";
                Treecontrol.StartselectBranchID = 0;
                int BranchID = Convert.ToInt32(TreeV.SelectedNode.Tag);
                TreeV.BeginUpdate();
                if (TreeV.SelectedNode.BackColor == Treecontrol.SelectBackColor)
                {
                    TreeV.SelectedNode.BackColor = Color.White;
                    Treecontrol.SelectedBranchs.Remove(BranchID);

                }
                else
                {
                    TreeV.SelectedNode.BackColor = Treecontrol.SelectBackColor;
                    Treecontrol.SelectedBranchs.Add(BranchID);
                }
                TreeV.EndUpdate();

            }
            if (e.KeyCode == Keys.LShiftKey) //|| !Startselect
            {

                Treecontrol.TreeOP = "StartSelect";
                if (Treecontrol.StartselectBranchID == 0)
                {
                    Treecontrol.StartselectBranchID = Treecontrol.SelectedBranchID;
                }
                if (Treecontrol.SelectedBranchID != Treecontrol.StartselectBranchID)
                {

                    IBranch startbr = Treecontrol.Branches.Where(x => x.BranchID == Treecontrol.StartselectBranchID).FirstOrDefault();
                    IBranch endbr = Treecontrol.Branches.Where(x => x.BranchID == Treecontrol.SelectedBranchID).FirstOrDefault();
                    if ((startbr != endbr) || (startbr.ParentBranchID == endbr.ParentBranchID) || (startbr.BranchClass == endbr.BranchClass))
                    {

                        TreeNode startnode;
                        TreeNode endnode;
                        bool found = false;

                        if (Treecontrol.SelectedBranchID > Treecontrol.StartselectBranchID)
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(Treecontrol.StartselectBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(Treecontrol.SelectedBranchID.ToString(), TreeV.Nodes);
                        }
                        else
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(Treecontrol.SelectedBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(Treecontrol.StartselectBranchID.ToString(), TreeV.Nodes);
                        }
                        TreeNode n = startnode;
                        while (!found)
                        {
                            TreeV.BeginUpdate();
                            n.BackColor = Treecontrol.SelectBackColor;
                            Treecontrol.SelectedBranchs.Add(Convert.ToInt32(n.Tag));
                            if (n == endnode)
                            {
                                found = true;
                            }
                            else
                            {
                                n = n.NextNode;
                            }
                            TreeV.EndUpdate();
                        }

                    }
                }


            }
            if (e.KeyCode == Keys.RShiftKey) //|| !Startselect
            {

                if (Treecontrol.SelectedBranchID != Treecontrol.StartselectBranchID)
                {
                    Treecontrol.TreeOP = "StartSelect";
                    if (Treecontrol.StartselectBranchID == 0)
                    {
                        Treecontrol.StartselectBranchID = Treecontrol.SelectedBranchID;
                    }
                    IBranch startbr = Treecontrol.Branches.Where(x => x.BranchID == Treecontrol.StartselectBranchID).FirstOrDefault();
                    IBranch endbr = Treecontrol.Branches.Where(x => x.BranchID == Treecontrol.SelectedBranchID).FirstOrDefault();
                    if ((startbr != endbr) || (startbr.ParentBranchID == endbr.ParentBranchID) || (startbr.BranchClass == endbr.BranchClass))
                    {

                        TreeNode startnode;
                        TreeNode endnode;
                        bool found = false;

                        if (Treecontrol.SelectedBranchID > Treecontrol.StartselectBranchID)
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(Treecontrol.StartselectBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(Treecontrol.SelectedBranchID.ToString(), TreeV.Nodes);
                        }
                        else
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(Treecontrol.SelectedBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(Treecontrol.StartselectBranchID.ToString(), TreeV.Nodes);
                        }
                        TreeNode n = startnode;
                        while (!found)
                        {
                            TreeV.BeginUpdate();
                            n.BackColor = Color.White;

                            Treecontrol.SelectedBranchs.Remove(Convert.ToInt32(n.Tag));
                            if (n == endnode)
                            {
                                found = true;
                            }
                            else
                            {
                                n = n.NextNode;
                            }
                            TreeV.EndUpdate();
                        }

                    }
                }


            }
        }

        // Returns the bounds of the specified node, including the region 
        // occupied by the node label and any node tag displayed.

        private void TreeV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Vary the response depending on which TreeViewAction
            // triggered the event. 
            //switch (e.Action)
            //{
            //    case TreeViewAction.ByKeyboard:
            Treecontrol.LastSelectedNode = e.Node;
            if (Treecontrol.TreeOP != "StartSelect")
            {
                Treecontrol.StartselectBranchID = Convert.ToInt32(Treecontrol.LastSelectedNode.Tag);
            }
            //        break;
            //    case TreeViewAction.ByMouse:
            //        LastSelectedNode = e.Node;
            //        if (TreeOP != "StartSelect")
            //        {
            //            StartselectBranchID = Convert.ToInt32(LastSelectedNode.Tag);
            //        }


            //        break;
            //}
        }
        public void NodeEvent(TreeNodeMouseClickEventArgs e)
        {

            TreeV.SelectedNode = e.Node;
            //IDM_Addin s = sender;

            int BranchID = Convert.ToInt32(e.Node.Tag);
            string BranchText = e.Node.Text;
            IBranch br = Treecontrol.Branches.Where(x => x.BranchID.ToString() == e.Node.Tag.ToString()).FirstOrDefault();
            Treecontrol.SelectedBranchID = BranchID;


            if (br != null)
            {
                if (e.Button == MouseButtons.Left)
                {

                    PassedArgs Passedarguments = new PassedArgs
                    {
                        Addin = null,
                        AddinName = br.BranchText,
                        AddinType = "",
                        DMView = null,
                        Id = BranchID,
                        CurrentEntity = BranchText,
                        DataSource = null,
                        EventType = Treecontrol.TreeEvent
                    };
                    //if (Control.ModifierKeys == Keys.LControlKey)
                    //{
                    //    TreeOP = "UnSelect";
                    //    StartselectBranchID = 0;

                    //    TreeV.BeginUpdate();
                    //    if (TreeV.SelectedNode.BackColor == SelectBackColor)
                    //    {
                    //        TreeV.SelectedNode.BackColor = Color.White;
                    //        SelectedBranchs.Remove(BranchID);

                    //    }
                    //    else
                    //    {
                    //        TreeV.SelectedNode.BackColor = SelectBackColor;
                    //        SelectedBranchs.Add(BranchID);
                    //    }
                    //    TreeV.EndUpdate();

                    //}
                    //if (Control.ModifierKeys == Keys.LShiftKey) //|| !Startselect
                    //{

                    //    TreeOP = "StartSelect";
                    //    if (StartselectBranchID == 0)
                    //    {
                    //        StartselectBranchID = SelectedBranchID;
                    //    }
                    //    if (SelectedBranchID != StartselectBranchID)
                    //    {

                    //        IBranch startbr = Branches.Where(x => x.BranchID == StartselectBranchID).FirstOrDefault();
                    //        IBranch endbr = Branches.Where(x => x.BranchID == SelectedBranchID).FirstOrDefault();
                    //        if ((startbr != endbr) || (startbr.ParentBranchID == endbr.ParentBranchID) || (startbr.BranchClass == endbr.BranchClass))
                    //        {

                    //            TreeNode startnode;
                    //            TreeNode endnode;
                    //            bool found = false;

                    //            if (SelectedBranchID > StartselectBranchID)
                    //            {
                    //                startnode = GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                    //                endnode = GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                    //            }
                    //            else
                    //            {
                    //                startnode = GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                    //                endnode = GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                    //            }
                    //            TreeNode n = startnode;
                    //            while (!found)
                    //            {
                    //                TreeV.BeginUpdate();
                    //                n.BackColor = SelectBackColor;
                    //                SelectedBranchs.Add(Convert.ToInt32(n.Tag));
                    //                if (n == endnode)
                    //                {
                    //                    found = true;
                    //                }
                    //                else
                    //                {
                    //                    n = n.NextNode;
                    //                }
                    //                TreeV.EndUpdate();
                    //            }

                    //        }
                    //    }


                    //}
                    //if (Control.ModifierKeys == Keys.RShiftKey) //|| !Startselect
                    //{

                    //    if (SelectedBranchID != StartselectBranchID)
                    //    {
                    //        TreeOP = "StartSelect";
                    //        if (StartselectBranchID == 0)
                    //        {
                    //            StartselectBranchID = SelectedBranchID;
                    //        }
                    //        IBranch startbr = Branches.Where(x => x.BranchID == StartselectBranchID).FirstOrDefault();
                    //        IBranch endbr = Branches.Where(x => x.BranchID == SelectedBranchID).FirstOrDefault();
                    //        if ((startbr != endbr) || (startbr.ParentBranchID == endbr.ParentBranchID) || (startbr.BranchClass == endbr.BranchClass))
                    //        {

                    //            TreeNode startnode;
                    //            TreeNode endnode;
                    //            bool found = false;

                    //            if (SelectedBranchID > StartselectBranchID)
                    //            {
                    //                startnode = GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                    //                endnode = GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                    //            }
                    //            else
                    //            {
                    //                startnode = GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                    //                endnode = GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                    //            }
                    //            TreeNode n = startnode;
                    //            while (!found)
                    //            {
                    //                TreeV.BeginUpdate();
                    //                n.BackColor = Color.White;

                    //                SelectedBranchs.Remove(Convert.ToInt32(n.Tag));
                    //                if (n == endnode)
                    //                {
                    //                    found = true;
                    //                }
                    //                else
                    //                {
                    //                    n = n.NextNode;
                    //                }
                    //                TreeV.EndUpdate();
                    //            }

                    //        }
                    //    }


                    //}
                }
                else
                {


                    Treecontrol.StartselectBranchID = 0;
                    Treecontrol.TreeOP = "NONE";
                }

                if (e.Button == MouseButtons.Right)
                {
                    Treecontrol.Nodemenu_MouseClick(e);
                }

            }


        }
        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            
            try
            {
                IBranch br = GetBranch(Convert.ToInt32(e.Node.Tag));
                CheckNodes(e.Node, e.Node.Checked);
                if (br.BranchType == EnumPointType.Entity)
                {

                    if (e.Node.Checked)
                    {
                        Treecontrol.SelectedBranchs.Add(br.BranchID);
                    }
                    else
                        Treecontrol.SelectedBranchs.Remove(br.BranchID);

                }
                else
                {
                    if (e.Node.Checked)
                    {
                        e.Node.Checked = false;
                    }
                  
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Fail", $"Error in Showing View on Tree ({ex.Message}) ", DateTime.Now, 0, null, Errors.Failed);

            }
           

        }
        private void CheckNodes(TreeNode node, bool check)
        {
            try
            {
                SetChildrenChecked(node, node.Checked);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Fail", $"Error in Setting Check for Node Tree ({ex.Message}) ", DateTime.Now, 0, null, Errors.Failed);
            }



        }
        private void SetChildrenChecked(TreeNode treeNode, bool checkedState)
        {
            foreach (TreeNode item in treeNode.Nodes)
            {
                if (item.Checked != checkedState)
                {

                    // int vitem = Convert.ToInt32(item.Tag.ToString().Substring(item.Tag.ToString().IndexOf('-') + 1));
                    item.Checked = checkedState;
                    if (item.Checked)
                    {
                        Treecontrol.SelectedBranchs.Add(Convert.ToInt32(item.Tag));
                    }
                    else
                        Treecontrol.SelectedBranchs.Remove(Convert.ToInt32(item.Tag));
                }
                SetChildrenChecked(item, item.Checked);
            }
        }
        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Treecontrol.TreeEvent = "MouseDoubleClick";
            Nodeclickhandler(e);

        }
        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Treecontrol.TreeEvent = "MouseClick";
            Nodeclickhandler(e);
        }
        private void Nodeclickhandler(TreeNodeMouseClickEventArgs e)
        {
            Treecontrol.SelectedNode = e.Node;
            Treecontrol.SelectedBranchID = Convert.ToInt32(e.Node.Tag);
            NodeEvent(e);
        }
        #endregion

    }
}
