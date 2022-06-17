using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;
using Point = System.Drawing.Point;

namespace BeepEnterprize.Winform.Vis.Controls
{
    public class TreeNodeDragandDropHandler 
    {
        public TreeNodeDragandDropHandler(IDMEEditor pDMEEditor, TreeControl ptreeControl)
        {
            DMEEditor = pDMEEditor;
            treeControl = ptreeControl;
            TreeV = ptreeControl.TreeV;
          

            TreeV.DragDrop += Tree_DragDrop;
            TreeV.DragEnter += Tree_DragEnter;
            TreeV.DragLeave += Tree_DragLeave;
            TreeV.ItemDrag += Tree_ItemDrag;
            TreeV.DragOver += Tree_DragOver;

        }
        public IDMEEditor DMEEditor { get; set; }
        public TreeControl treeControl { get; set; }

        public System.Windows.Forms.TreeView TreeV { get; set; }
        #region "Drag and Drop"
        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }
        //------------ Drag and Drop -----------------
        private void Tree_DragLeave(object sender, EventArgs e)
        {
            // null;  //throw new NotImplementedException();

        }

        private void Tree_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void Tree_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = TreeV.PointToClient(new Point(e.X, e.Y));
           
            // Retrieve the node at the drop location.
            TreeNode targetNode = TreeV.GetNodeAt(targetPoint);
            if (targetNode != null)
            {
                if (!e.Data.GetDataPresent(typeof(IBranch)))
                {
                    return;
                }
                IBranch targetBranch = (IBranch)targetNode.Tag;
                // Retrieve the node that was dragged.
                IBranch dragedBranch = (IBranch)e.Data.GetData(e.Data.GetFormats()[0]);
                TreeNode dragedNode = treeControl.GetTreeNodeByID(dragedBranch.BranchID, TreeV.Nodes);
                string targetBranchClass = targetBranch.GetType().Name;
                string dragedBranchClass = dragedBranch.GetType().Name;
                Function2FunctionAction functionAction = DMEEditor.ConfigEditor.Function2Functions.Where(x => x.FromClass == dragedBranchClass && x.ToClass == targetBranchClass && x.Event == "DragandDrop").FirstOrDefault();
                //---------------------------------------------------------
                if (targetBranch.BranchClass == dragedBranch.BranchClass)
                {
                    switch (targetBranch.BranchType)
                    {
                        case EnumPointType.Root:
                            if (treeControl.treeBranchHandler.CheckifBranchExistinCategory(dragedBranch.BranchText, dragedBranch.BranchClass) != null)
                            {
                                if (dragedBranch.BranchType == EnumPointType.DataPoint)
                                {
                                    treeControl.treeBranchHandler.MoveBranchToParent(targetBranch, dragedBranch);
                                }
                            }

                            break;

                           
                        case EnumPointType.Category:
                          //  if (dragedBranch.BranchClass == "VIEW")
                           // {
                                if (dragedBranch.BranchType == EnumPointType.DataPoint)
                                {
                                    treeControl.treeBranchHandler.MoveBranchToParent(targetBranch, dragedBranch);
                                };
                           // };
                            break;
                        case EnumPointType.DataPoint:
                        case EnumPointType.Entity:
                            if (dragedBranch.BranchClass == "VIEW")
                            {
                                if (dragedBranch.BranchType == EnumPointType.Entity && dragedBranch.DataSourceName == targetBranch.DataSourceName)
                                {
                                    treeControl.treeBranchHandler.MoveBranchToParent(targetBranch, dragedBranch);
                                }
                            }


                            break;
                        default:
                            break;
                    }

                }
                // Check if Function connected to this event
                if (functionAction != null) //functionAction
                {
                    switch (targetBranch.BranchType)
                    {
                        case EnumPointType.Root:
                            DMEEditor.Passedarguments = new PassedArgs
                            {
                                ObjectName = "DATABASE",
                                ObjectType = "TABLE",
                                EventType = "DragandDrop",
                                ParameterString1 = "Create View using Table",
                                Objects = new List<ObjectItem> { new ObjectItem { Name = "Branch", obj = dragedBranch } }
                            };



                            SendActionFromBranchToBranch(targetBranch, dragedBranch, functionAction.ToMethod);
                            break;
                        case EnumPointType.DataPoint:
                            DMEEditor.Passedarguments = new PassedArgs
                            {
                                ObjectName = "DATABASE",
                                ObjectType = "TABLE",
                                EventType = "DragandDrop",
                                ParameterString1 = "Add Entity Child",
                                DataSource = dragedBranch.DataSource,
                                DatasourceName = dragedBranch.DataSourceName,
                                CurrentEntity = dragedBranch.BranchText,
                                Id = dragedBranch.BranchID,
                                Objects = new List<ObjectItem> { new ObjectItem { Name = "ChildBranch", obj = dragedBranch } }
                            };
                            SendActionFromBranchToBranch(targetBranch, dragedBranch, functionAction.ToMethod);
                            break;
                        case EnumPointType.Category:
                            if (dragedBranch.BranchType == EnumPointType.DataPoint)
                            {
                                treeControl.treeBranchHandler.MoveBranchToParent(targetBranch, dragedBranch);
                            }

                            break;
                        case EnumPointType.Entity:
                            IDataSource ds = DMEEditor.GetDataSource(dragedBranch.DataSourceName);
                            EntityStructure ent = ds.GetEntityStructure(dragedBranch.BranchText, true);
                            DMEEditor.Passedarguments = new PassedArgs
                            {
                                ObjectName = "DATABASE",
                                ObjectType = "TABLE",
                                EventType = "COPYENTITY",
                                ParameterString1 = "COPYENTITY",

                                DataSource = dragedBranch.DataSource,
                                DatasourceName = dragedBranch.DataSourceName,
                                CurrentEntity = dragedBranch.BranchText,
                                Id = dragedBranch.BranchID,
                                Objects = new List<ObjectItem> { new ObjectItem { Name = "Branch", obj = dragedBranch }, new ObjectItem { Name = "Entity", obj = ent } }
                            };



                            SendActionFromBranchToBranch(targetBranch, dragedBranch, functionAction.ToMethod);


                            break;
                        default:
                            break;
                    }
                }
            }

           
            //if (targetBranch.BranchType == EnumBranchType.Root)
            //{
            //    // Confirm that the node at the drop location is not 
            //    // the dragged node or a descendant of the dragged node.
            //    IDMDataView v = DME.viewEditor.GetView(Visutil.GetNodeID(targetNode).NodeIndex);
            //    IRDBSource ds = (IRDBSource)DME.GetDataSource(v.MainDataSourceID);
            //    if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            //    {
            //        // If it is a move operation, remove the node from its current 
            //        // location and add it to the node at the drop location.
            //        if (e.Effect == DragDropEffects.Move)
            //        {

            //            int tabid = DME.viewEditor.AddEntitytoDataView(ds, draggedNode.Text.ToUpper(),ds.GetSchemaName(), "", v.id);
            //            //  Visutil.ShowTableonTree(MainNode, v.id, tabid, true);

            //            //draggedNode.Remove();
            //            //targetNode.Nodes.Add(draggedNode);
            //        }

            //        // If it is a copy operation, clone the dragged node 
            //        // and add it to the node at the drop location.
            //        //else if (e.Effect == DragDropEffects.Copy)
            //        //{
            //        //    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
            //        //}

            //        // Expand the node at the location 
            //        // to show the dropped node.
            //        targetNode.Expand();
            //    }
            //}

        }
        public IErrorsInfo SendActionFromBranchToBranch(IBranch ParentBranch, IBranch CurrentBranch, string ActionType)
        {
            return DMEEditor.ErrorObject;
        }
        private void Tree_ItemDrag(object sender, ItemDragEventArgs e)

        {
            //if (CurrentNode != null)
            //{counties.xls,counties
            //    if (CurrentNode.nodeType == "EN")
            //    {
            // Move the dragged node when the left mouse button is used.
            System.Windows.Forms.IDataObject x = new System.Windows.Forms.DataObject();

            TreeNode n = (TreeNode)e.Item;
            if (e.Button == MouseButtons.Left)
            {
                IBranch branch = (IBranch)n.Tag;
                x.SetData(branch);
                switch (branch.BranchType)
                {
                    case EnumPointType.Root:
                        break;
                    case EnumPointType.DataPoint:
                      //  TreeV.DoDragDrop(x, System.Windows.Forms.DragDropEffects.Move);
                        break;
                    case EnumPointType.Category:
                        break;
                    case EnumPointType.Entity:
                        TreeV.DoDragDrop(x, System.Windows.Forms.DragDropEffects.Move);
                        break;
                    default:
                        break;
                }
            }




            // Copy the dragged node when the right mouse button is used.
            //else if (e.Button == MouseButtons.Right)
            //{
            //    Tree.DoDragDrop(e.Item, DragDropEffects.Copy);
            //}
            //  }

            //}


        }

        private void Tree_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            System.Drawing.Point targetPoint = TreeV.PointToClient(new System.Drawing.Point(e.X, e.Y));

            // Select the node at the mouse position.
            TreeV.SelectedNode = TreeV.GetNodeAt(targetPoint);
        }
        #endregion

    }
}
