using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.AppManager;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace Beep.DExpress.Common.DXTree
{
    public class DXReportDefinitionNode : IBranch
    {
        public DXReportDefinitionNode()
        {

        }
        public DXReportDefinitionNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename, string ConnectionName)
        {



            TreeEditor = pTreeEditor;
            DMEEditor = pDMEEditor;
            ParentBranchID = pParentNode.ID;
            BranchText = pBranchText;
            BranchType = pBranchType;
          //  IconImageName = pimagename;

            if (pID != 0)

            {
                ID = pID;
                BranchID = pID;
            }
        }

        #region "Properties"
        public int ID { get; set; }
        public EntityStructure EntityStructure { get; set; }
        public string Name { get; set; }
        public string BranchText { get; set; } = "Cloud";
        public IDMEEditor DMEEditor { get; set; }
        public IDataSource DataSource { get; set; }
        public string DataSourceName { get; set; }
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Report;
        public int BranchID { get; set; }
        public string IconImageName { get; set; } = "reportdefinition.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchClass { get; set; } = "REPORTING";
        public List<IBranch> ChildBranchs { get; set; } = new List<IBranch>();
        public ITree TreeEditor { get; set; }
        public List<string> BranchActions { get; set; }
        public object TreeStrucure { get; set; }
        public IVisManager Visutil { get; set; }
        public int MiscID { get; set; }
        public AddinTreeStructure AddinTreeStructure { get; set; }

        #endregion "Properties"
        #region "Interface Methods"
        public IErrorsInfo CreateChildNodes()
        {

            try
            {
                CreateNodes();

                DMEEditor.AddLogMessage("Success", "Added Child Nodes", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Child Nodes";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }

        public IErrorsInfo ExecuteBranchAction(string ActionName)
        {
            throw new NotImplementedException();
        }

        public IErrorsInfo MenuItemClicked(string ActionNam)
        {
            throw new NotImplementedException();
        }

        public IErrorsInfo RemoveChildNodes()
        {
            throw new NotImplementedException();
        }

        public IErrorsInfo SetConfig(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename)
        {
            try
            {
                TreeEditor = pTreeEditor;
                DMEEditor = pDMEEditor;
                ParentBranchID = pParentNode.ID;
                BranchText = pBranchText;
                BranchType = pBranchType;
                IconImageName = pimagename;
                if (pID != 0)
                {
                    ID = pID;
                }

                //   DMEEditor.AddLogMessage("Success", "Set Config OK", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Set Config";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion "Interface Methods"
        #region "Exposed Interface"
        [CommandAttribute(Caption = "Edit", Hidden = false)]
        public IErrorsInfo edit()
        {

            try
            {
                string[] args = { BranchText };
               
                List<ObjectItem> ob = new List<ObjectItem>(); ;
                ObjectItem it = new ObjectItem();
                it.obj = this;
                it.Name = "Branch";
                ob.Add(it);
                IBranch RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "REPORTING" && x.BranchType == EnumPointType.Root)];
                it = new ObjectItem();
                it.obj = RootBranch;
                it.Name = "RootReportBranch";
                ob.Add(it);
                PassedArgs Passedarguments = new PassedArgs
                {  // Obj= obj,
                    Addin = null,
                    AddinName = null,
                    AddinType = null,
                    DMView = null,
                    CurrentEntity = BranchText,
                    ObjectName = BranchText,
                    Id = BranchID,
                    ObjectType = "REPORTDEFINITION",
                    DataSource = DataSource,
                    Objects=ob,
                    EventType = "EDIT"

                };

               
                    Visutil.ShowPage("uc_reportdefinition",  Passedarguments);
               

                DMEEditor.AddLogMessage("Success", "Shown Module " + BranchText, DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Show Module " + BranchText;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        //[CommandAttribute(Caption = "Create Snap Report", Hidden = false)]
        //public IErrorsInfo CreateSnap()
        //{

        //    try
        //    {
        //        //string[] args = { BranchText };

        //        //List<ObjectItem> ob = new List<ObjectItem>(); ;
        //        //ObjectItem it = new ObjectItem();
        //        //it.obj = this;
        //        //it.Name = "Branch";
        //        //ob.Add(it);
        //        //IBranch RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "REPORTING" && x.BranchType == EnumBranchType.Root)];
        //        //it = new ObjectItem();
        //        //it.obj = RootBranch;
        //        //it.Name = "RootReportBranch";
        //        //ob.Add(it);
        //        //PassedArgs Passedarguments = new PassedArgs
        //        //{  // Obj= obj,
        //        //    Addin = null,
        //        //    AddinName = null,
        //        //    AddinType = null,
        //        //    DMView = null,
        //        //    CurrentEntity = BranchText,
        //        //    ObjectName = BranchText,
        //        //    Id = BranchID,
        //        //    ObjectType = "REPORTDEFINITION",
        //        //    DataSource = DataSource,
        //        //    Objects = ob,
        //        //    EventType = "CREATEREPORT"

        //        //};


        //        //Visutil.ShowUserControlPopUp("Frm_DxSnapManager", DMEEditor, args, Passedarguments);
        //        CreateSnapreport();
        //        CreateNodes();
        //        DMEEditor.AddLogMessage("Success", "Shown Module " + BranchText, DateTime.Now, 0, null, Errors.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = "Could not Show Module " + BranchText;
        //        DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
        //    };
        //    return DMEEditor.ErrorObject;
        //}
        [CommandAttribute(Caption = "Create Report ", Hidden = false)]
        public IErrorsInfo CreateReportDesigner()
        {

            try
            {
                //string[] args = { BranchText };

                //List<ObjectItem> ob = new List<ObjectItem>(); ;
                //ObjectItem it = new ObjectItem();
                //it.obj = this;
                //it.Name = "Branch";
                //ob.Add(it);
                //IBranch RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "REPORTING" && x.BranchType == EnumBranchType.Root)];
                //it = new ObjectItem();
                //it.obj = RootBranch;
                //it.Name = "RootReportBranch";
                //ob.Add(it);
                //PassedArgs Passedarguments = new PassedArgs
                //{  // Obj= obj,
                //    Addin = null,
                //    AddinName = null,
                //    AddinType = null,
                //    DMView = null,
                //    CurrentEntity = BranchText,
                //    ObjectName = BranchText,
                //    Id = BranchID,
                //    ObjectType = "REPORTDEFINITION",
                //    DataSource = DataSource,
                //    Objects = ob,
                //    EventType = "CREATEREPORT"

                //};


                //Visutil.ShowUserControlPopUp("Frm_DxDesigner", DMEEditor, args, Passedarguments);
                CreateReport();
                CreateNodes();
                DMEEditor.AddLogMessage("Success", "Shown Module " + BranchText, DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Show Module " + BranchText;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Create Dashboard ", Hidden = false)]
        public IErrorsInfo CreateDashboardDesigner()
        {

            try
            {
                //string[] args = { BranchText };

                //List<ObjectItem> ob = new List<ObjectItem>(); ;
                //ObjectItem it = new ObjectItem();
                //it.obj = this;
                //it.Name = "Branch";
                //ob.Add(it);
                //IBranch RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "REPORTING" && x.BranchType == EnumBranchType.Root)];
                //it = new ObjectItem();
                //it.obj = RootBranch;
                //it.Name = "RootReportBranch";
                //ob.Add(it);
                //PassedArgs Passedarguments = new PassedArgs
                //{  // Obj= obj,
                //    Addin = null,
                //    AddinName = null,
                //    AddinType = null,
                //    DMView = null,
                //    CurrentEntity = BranchText,
                //    ObjectName = BranchText,
                //    Id = BranchID,
                //    ObjectType = "REPORTDEFINITION",
                //    DataSource = DataSource,
                //    Objects = ob,
                //    EventType = "CREATEREPORT"

                //};


                //Visutil.ShowUserControlPopUp("Frm_DxDesigner", DMEEditor, args, Passedarguments);
                CreateDashboard();
                CreateNodes();
                DMEEditor.AddLogMessage("Success", "Shown Module " + BranchText, DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Show Module " + BranchText;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "DoubleClick", Hidden = true, DoubleClick = true)]
        public IErrorsInfo DoubleClick()
        {

            try
            {
                string[] args = { BranchText };
                List<ObjectItem> ob = new List<ObjectItem>(); ;
                ObjectItem it = new ObjectItem();
                it.obj = this;
                it.Name = "Branch";
                ob.Add(it);
                IBranch RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "REPORTING" && x.BranchType == EnumPointType.Root)];
                it = new ObjectItem();
                it.obj = RootBranch;
                it.Name = "RootReportBranch";
                ob.Add(it);
                PassedArgs Passedarguments = new PassedArgs
                {  // Obj= obj,
                    Addin = null,
                    AddinName = null,
                    AddinType = null,
                    DMView = null,
                    CurrentEntity = BranchText,
                    ObjectName = BranchText,
                    Id = BranchID,
                    Objects = ob,
                    ObjectType = "REPORTDEFINITION",
                    DataSource = DataSource,
                    EventType = "EDIT"

                };

                
                    Visutil.ShowPage("uc_reportdefinition",  Passedarguments, DisplayType.Popup);
               

                DMEEditor.AddLogMessage("Success", "Shown Module " + BranchText, DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Show Module " + BranchText;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Caption = "Remove", iconimage = "remove.ico")]
        public IErrorsInfo Remove()
        {
            try
            {
                AppTemplate ap = DMEEditor.ConfigEditor.ReportsDefinition[DMEEditor.ConfigEditor.ReportsDefinition.FindIndex(p => p.Name == BranchText)];
                DMEEditor.ConfigEditor.ReportsDefinition.Remove(ap);
                DMEEditor.ConfigEditor.SaveReportDefinitionsValues();
                IBranch parent = TreeEditor.treeBranchHandler.GetBranch(ParentBranchID);
                if (parent != null)
                {
                    parent.CreateChildNodes();
                }
                // DMEEditor.AddLogMessage("Success", "Created Query Entity", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not remove Report";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion Exposed Interface"
        #region "Other Methods"
        private void CreateSnapreport()
        {
            ReportsList x = new ReportsList();
            x.ReportDefinition = BranchText;
            x.ReportEngine = "DXSNAPREPORT";
            string reponame = "";
            if (Visutil.Controlmanager.InputBox("Beep DM", "What is the Report Name", ref reponame) == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(reponame))
                {
                    x.ReportName = reponame;
                    DMEEditor.ConfigEditor.Reportslist.Add(x);
                    DMEEditor.ConfigEditor.SaveReportsValues();
                }
            };
        }
        private void CreateReport()
        {
            ReportsList x = new ReportsList();
            x.ReportDefinition = BranchText;
            x.ReportEngine = "DXREPORT";
            string reponame = "";
            if (Visutil.Controlmanager.InputBox("Beep DM", "What is the Report Name", ref reponame) == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(reponame))
                {
                    x.ReportName = reponame;
                    DMEEditor.ConfigEditor.Reportslist.Add(x);
                    DMEEditor.ConfigEditor.SaveReportsValues();
                }
            }    ;
         

        }
        private void CreateDashboard()
        {
            ReportsList x = new ReportsList();
            x.ReportDefinition = BranchText;
            x.ReportEngine = "DXDASH";
            string reponame = "";
            if (Visutil.Controlmanager.InputBox("Beep DM", "What is the Dashboard Name", ref reponame) == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(reponame))
                {
                    x.ReportName = reponame;
                    DMEEditor.ConfigEditor.Reportslist.Add(x);
                    DMEEditor.ConfigEditor.SaveReportsValues();
                }
            };


        }
        public IErrorsInfo CreateNodes()
        {

            try
            {
                DMEEditor.ConfigEditor.LoadReportsValues();
                foreach (ReportsList item in DMEEditor.ConfigEditor.Reportslist.Where(e=>e.ReportDefinition.Equals(BranchText,StringComparison.OrdinalIgnoreCase)))
                {

                    //reportdesigner
                    if (!ChildBranchs.Where(p => p.BranchText.Equals(item.ReportName, StringComparison.OrdinalIgnoreCase)).Any())
                    {
                        switch (item.ReportEngine)
                        {
                            case "DXREPORT":
                                DXReportDesignerNode entityNode = new DXReportDesignerNode(TreeEditor, DMEEditor, this, item.ReportName, TreeEditor.SeqID, EnumPointType.Function, "reportdesigner.ico", item.ReportDefinition);
                                entityNode.ReportDefinition = item.ReportDefinition;
                                TreeEditor.treeBranchHandler.AddBranch(this, entityNode);
                                ChildBranchs.Add(entityNode);
                                break;
                            //case "DXSNAPREPORT":
                            //    DXSnapReportDesignerNode entityNode1 = new DXSnapReportDesignerNode(TreeEditor, DMEEditor, this, item.ReportName, TreeEditor.SeqID, EnumPointType.Function, "snapdesigner.ico", item.ReportDefinition);
                            //    entityNode1.ReportDefinition = item.ReportDefinition;
                            //    TreeEditor.treeBranchHandler.AddBranch(this, entityNode1);
                            //    ChildBranchs.Add(entityNode1);
                            //    break;
                            case "DXDASH":
                                DXDashboardNode entityNode2 = new DXDashboardNode(TreeEditor, DMEEditor, this, item.ReportName, TreeEditor.SeqID, EnumPointType.Function, "chart.ico", item.ReportDefinition);
                                entityNode2.ReportDefinition = item.ReportDefinition;
                                TreeEditor.treeBranchHandler.AddBranch(this, entityNode2);
                                ChildBranchs.Add(entityNode2);
                                break;
                        }

                    }

                }

                DMEEditor.AddLogMessage("Success", "Created child Nodes", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Create child Nodes";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }
        #endregion"Other Methods"
    }
}
