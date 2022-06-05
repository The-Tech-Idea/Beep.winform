using BeepEnterprize.Vis.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace KOC.DHUB3.TreeNodes
{
    public class HeavyOilRootNode : IBranch
    {
        public HeavyOilRootNode(int iD, IDMEEditor dMEEditor, IDataSource dataSource, string dataSourceName, ITree treeEditor, IVisManager visutil, EntityStructure entityStructure, int miscID, string name, int branchID, string iconImageName)
        {
            ID = iD;
            DMEEditor = dMEEditor;
            DataSource = dataSource;
            DataSourceName = dataSourceName;
            TreeEditor = treeEditor;
            Visutil = visutil;
            EntityStructure = entityStructure;
            MiscID = miscID;
            Name = name;
            BranchID = branchID;
            IconImageName = iconImageName;

        }
        public int ID { get  ; set  ; }
        public IDMEEditor DMEEditor { get  ; set  ; }
        public IDataSource DataSource { get  ; set  ; }
        public string DataSourceName { get  ; set  ; }
        public List<IBranch> ChildBranchs { get  ; set  ; }
        public ITree TreeEditor { get  ; set  ; }
        public IVisManager Visutil { get  ; set  ; }
        public List<string> BranchActions { get  ; set  ; }
        public EntityStructure EntityStructure { get  ; set  ; }
        public int MiscID { get  ; set  ; }
        public string Name { get  ; set  ; }
        public string BranchText { get; set; } = "Heavy Oil";
        public int Level { get; set; } = 0;
        public EnumPointType BranchType { get; set; } = EnumPointType.Root;
        public int BranchID { get; set; }
        public string IconImageName { get; set; }
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; } = "Root node for Heavy Oil Data Management";
        public string BranchClass { get; set; } = "Dhub3.HeavyOil";

        public IErrorsInfo CreateChildNodes()
        {
            throw new NotImplementedException();
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
                    BranchID = ID;
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
    }
}
