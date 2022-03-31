using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Controls
{
    public class TreeNodeEvents
    {
        string TreeEvent { get; set; }
        string TreeOP { get; set; }
        public TreeNode SelectedNode { get; set; }
        public TreeNode LastSelectedNode { get; set; }
        public Color SelectBackColor { get; set; } = Color.Red;

        public int StartselectBranchID { get; set; } = 0;
        public int SelectBranchID { get; set; } = 0;
        public int SelectedBranchID { get; set; } = 0;
        public TreeNodeEvents(IDMEEditor pDMEEditor, TreeControl ptreeControl)
        {
            DMEEditor = pDMEEditor;
            treeControl = ptreeControl;
            Tree = ptreeControl;
            Treecontrol = ptreeControl;
            visManager = (VisManager)Treecontrol.Vismanager;
            TreeV = Treecontrol.TreeV;
            TreeV.AllowDrop = true;
            TreeV.NodeMouseClick += TreeView1_NodeMouseClick;
            TreeV.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
            TreeV.AfterCheck += TreeView1_AfterCheck;

            //   TreeV.DrawNode += TreeV_DrawNode;
            TreeV.AfterSelect += TreeV_AfterSelect;

        }
        public IDMEEditor DMEEditor { get; set; }
        public TreeControl treeControl { get; set; }
        private ITree Tree { get; set; }
        private TreeControl Treecontrol { get; set; }
        private VisManager visManager { get; set; }
        public System.Windows.Forms.TreeView TreeV { get; set; }
        private bool IsSelecting = false;

        #region "Node Handling Functions"
       
        private void TreeV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey)
            {
                TreeOP = "UnSelect";
                StartselectBranchID = 0;
                int BranchID = Convert.ToInt32(TreeV.SelectedNode.Tag);
                TreeV.BeginUpdate();
                if (TreeV.SelectedNode.BackColor == SelectBackColor)
                {
                    TreeV.SelectedNode.BackColor = Color.White;
                    Treecontrol.SelectedBranchs.Remove(BranchID);

                }
                else
                {
                    TreeV.SelectedNode.BackColor = SelectBackColor;
                    Treecontrol.SelectedBranchs.Add(BranchID);
                }
                TreeV.EndUpdate();

            }
            if (e.KeyCode == Keys.LShiftKey) //|| !Startselect
            {

                IsSelecting = true;
                TreeOP = "StartSelect";
                if (StartselectBranchID == 0)
                {
                    StartselectBranchID = SelectedBranchID;
                }
                if (SelectedBranchID != StartselectBranchID)
                {

                    IBranch startbr = Tree.Branches.Where(x => x.BranchID == StartselectBranchID).FirstOrDefault();
                    IBranch endbr = Tree.Branches.Where(x => x.BranchID == SelectedBranchID).FirstOrDefault();
                    if ((startbr != endbr) || (startbr.ParentBranchID == endbr.ParentBranchID) || (startbr.BranchClass == endbr.BranchClass))
                    {

                        TreeNode startnode;
                        TreeNode endnode;
                        bool found = false;

                        if (SelectedBranchID > StartselectBranchID)
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                        }
                        else
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                        }
                        TreeNode n = startnode;
                        while (!found)
                        {
                            TreeV.BeginUpdate();
                            n.BackColor = SelectBackColor;
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

                if (SelectedBranchID != StartselectBranchID)
                {
                    TreeOP = "StartSelect";
                    if (StartselectBranchID == 0)
                    {
                        StartselectBranchID = SelectedBranchID;
                    }
                    IBranch startbr = Tree.Branches.Where(x => x.BranchID == StartselectBranchID).FirstOrDefault();
                    IBranch endbr = Tree.Branches.Where(x => x.BranchID == SelectedBranchID).FirstOrDefault();
                    if ((startbr != endbr) || (startbr.ParentBranchID == endbr.ParentBranchID) || (startbr.BranchClass == endbr.BranchClass))
                    {

                        TreeNode startnode;
                        TreeNode endnode;
                        bool found = false;

                        if (SelectedBranchID > StartselectBranchID)
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                        }
                        else
                        {
                            startnode = Treecontrol.GetTreeNodeByTag(SelectedBranchID.ToString(), TreeV.Nodes);
                            endnode = Treecontrol.GetTreeNodeByTag(StartselectBranchID.ToString(), TreeV.Nodes);
                        }
                        TreeNode n = startnode;
                        while (!found)
                        {
                            TreeV.BeginUpdate();
                            n.BackColor = Color.White;

                            Tree.SelectedBranchs.Remove(Convert.ToInt32(n.Tag));
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
            LastSelectedNode = e.Node;
            if (TreeOP != "StartSelect")
            {
                StartselectBranchID = Convert.ToInt32(LastSelectedNode.Tag);
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
            int BranchID = Convert.ToInt32(e.Node.Tag);
            string BranchText = e.Node.Text;
            IBranch br = Tree.Branches.Where(x => x.BranchID.ToString() == e.Node.Tag.ToString()).FirstOrDefault();
            SelectedBranchID = BranchID;
            if (br != null)
            {
                if (e.Button == MouseButtons.Left)
                {

                    DMEEditor.Passedarguments = new PassedArgs
                    {
                        Addin = null,
                        AddinName = br.BranchText,
                        AddinType = "",
                        DMView = null,
                        Id = BranchID,
                        CurrentEntity = BranchText,
                        DataSource = null,
                        EventType = TreeEvent
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


                    StartselectBranchID = 0;
                    TreeOP = "NONE";
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
                IBranch br = Treecontrol.treeBranchHandler.GetBranch(Convert.ToInt32(e.Node.Tag));
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
                    e.Node.Checked = false;
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
            TreeEvent = "MouseDoubleClick";
            Nodeclickhandler(e);

        }
        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeEvent = "MouseClick";
            Nodeclickhandler(e);
        }
        private void Nodeclickhandler(TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
            SelectedBranchID = Convert.ToInt32(e.Node.Tag);
            NodeEvent(e);
        }
        #endregion
    }
}
