using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;
namespace Beep.DExpress.Common.DXTree
{
    [ClassProperties(FileType = "REPORTING")]
    public class DXReportDesignerNode : IBranch
    {
        public DXReportDesignerNode()
        {

        }
        public DXReportDesignerNode(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename, string ConnectionName)
        {



            TreeEditor = pTreeEditor;
            DMEEditor = pDMEEditor;
            ParentBranchID = pParentNode.ID;
            BranchText = pBranchText;
            BranchType = pBranchType;
            ReportDefinition = ConnectionName;
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
        public string BranchText { get; set; } = "Report Designer";
        public IDMEEditor DMEEditor { get; set; }
        public IDataSource DataSource { get; set; }
        public string DataSourceName { get; set; }
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Function;
        public int BranchID { get; set; }
        public string IconImageName { get; set; } = "reportdesigner.ico";
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
        public string ReportDefinition { get; set; }
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
        [CommandAttribute(Caption = "Show", Hidden = false)]
        public IErrorsInfo Show()
        {

            try
            {
                string[] args = { BranchText };
                
               
                PassedArgs Passedarguments = new PassedArgs
                {  // Obj= obj,
                    Addin = null,
                    AddinName = null,
                    AddinType = null,
                    DMView = null,
                    CurrentEntity = BranchText,
                    ObjectName = ReportDefinition,
                    Id = BranchID,
                    Objects=setobjects(),
                    ObjectType = "DXREPORT",
                    DataSource = DataSource,
                    EventType = "Run"

                };

                
                    Visutil.ShowPage("Frm_DxDesigner", Passedarguments, DisplayType.Popup);
               

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
               
                PassedArgs Passedarguments = new PassedArgs
                {  // Obj= obj,
                    Addin = null,
                    AddinName = null,
                    AddinType = null,
                    DMView = null,
                    CurrentEntity = BranchText,
                    ObjectName = ReportDefinition,
                    Id = BranchID,
                    Objects=setobjects(),
                    ObjectType = "DXREPORT",
                    DataSource = DataSource,
                    EventType = "Run"

                };

                    Visutil.ShowPage("Frm_DxDesigner",  Passedarguments,DisplayType.Popup);
                

                DMEEditor.AddLogMessage("Success", "Shown Module " + BranchText, DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Show Module " + BranchText;
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;
        }
        #endregion Exposed Interface"
        #region "Other Methods"
        public IErrorsInfo CreateNodes()
        {

            try
            {


                DMEEditor.AddLogMessage("Success", "Created child Nodes", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                string mes = "Could not Create child Nodes";
                DMEEditor.AddLogMessage(ex.Message, mes, DateTime.Now, -1, mes, Errors.Failed);
            };
            return DMEEditor.ErrorObject;

        }
        private List<ObjectItem> setobjects()
        {
            List<ObjectItem> e = new List<ObjectItem>();
            ObjectItem t;
            if (e.Any(c => c.Name == "VISUTIL"))
            {
                e.Remove(e.Where(i => i.Name == "VISUTIL").FirstOrDefault());

            }
            t = new ObjectItem() { Name = "VISUTIL", obj = Visutil };
            e.Add(t);
            if (e.Any(i => i.Name == "Branch"))
            {
                e.Remove(e.Where(i => i.Name == "Branch").FirstOrDefault());

            }
            t = new ObjectItem() { Name = "Branch", obj = this };
            e.Add(t);
            if (e.Any(i => i.Name == "RootReportBranch"))
            {
                e.Remove(e.Where(i => i.Name == "RootReportBranch").FirstOrDefault());

            }
            IBranch RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == "REPORTING" && x.BranchType == EnumPointType.Root)];
            t = new ObjectItem() { Name = "RootReportBranch", obj = RootBranch };
            e.Add(t);
            if (e.Any(c => c.Name == "ReportDefinition"))
            {
                e.Remove(e.Where(i => i.Name == "ReportDefinition").FirstOrDefault());

            }
            t = new ObjectItem() { Name = "ReportDefinition", obj = DMEEditor.ConfigEditor.ReportsDefinition.Where(p => p.Name.Equals(ReportDefinition, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() };
            e.Add(t);
            return e;
        }
        #endregion"Other Methods"
    }
}
