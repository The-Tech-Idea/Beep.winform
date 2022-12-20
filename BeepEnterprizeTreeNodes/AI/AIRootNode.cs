using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;



namespace BeepEnterprize.Vis.Module
{
    [AddinAttribute(Caption = "AI", misc = "Beep", FileType = "Beep", iconimage = "ai.ico", menu = "AI", ObjectType = "Beep")]
    public class AIBuilder : IBranch, IOrder
    {
        public AIBuilder()
        {

        }
        public AIBuilder(ITree pTreeEditor, IDMEEditor pDMEEditor, IBranch pParentNode, string pBranchText, int pID, EnumPointType pBranchType, string pimagename)
        {

            BranchText = "AI";
            BranchClass = "AI";
            IconImageName = "ai.ico";
            BranchType = EnumPointType.Root;

        }

        public string ObjectType { get; set; } = "Beep";
        public int Order { get; set; } = 0;
        public object TreeStrucure { get; set; }
        public IVisManager Visutil { get; set; }
        public int ID { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public IDataSource DataSource { get; set; }
        public string DataSourceName { get; set; }
        public List<IBranch> ChildBranchs { get; set; } = new List<IBranch>();
        public ITree TreeEditor { get; set; }
        public List<string> BranchActions { get; set; } = new List<string>();
        public EntityStructure EntityStructure { get; set; }
        public int MiscID { get; set; }
        public string Name { get; set; }
        public string BranchText { get; set; } = "AI";
        public int Level { get; set; }
        public EnumPointType BranchType { get; set; } = EnumPointType.Root;
        public int BranchID { get; set; }
        public string IconImageName { get; set; } = "ai.ico";
        public string BranchStatus { get; set; }
        public int ParentBranchID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchClass { get; set; } = "AI";
        public object ParentBranch { get; set; }

        #region "Interface Methods"

        public IErrorsInfo CreateChildNodes()
        {

            try
            {

                CreateNodes();
                foreach (CategoryFolder i in DMEEditor.ConfigEditor.CategoryFolders.Where(x => x.RootName == "AI"))
                {

                    CreateCategoryNode(i);


                }
            

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
      
        #endregion Exposed Interface"
        #region "Other Methods"
        public IErrorsInfo CreateNodes()
        {

            try
            {
                CreateFolders();
                DMEEditor.ConfigEditor.LoadAIScriptsValues();
                TreeEditor.treeBranchHandler.RemoveChildBranchs(this);
                List<AssemblyClassDefinition> ls = DMEEditor.ConfigEditor.BranchesClasses.Where(p => p.classProperties != null).ToList();
                List<AssemblyClassDefinition> aibranchs = ls.Where(p => p.classProperties.menu.Equals("AI",StringComparison.InvariantCultureIgnoreCase) && p.PackageName!=this.Name).ToList();
                foreach (AssemblyClassDefinition item in aibranchs)
                {
                   
                            
                        Type adc = DMEEditor.assemblyHandler.GetType(item.PackageName);
                       // ConstructorInfo ctor = adc.GetConstructors().First();
                        //  ObjectActivator<IBranch> createdActivator = GetActivator<IBranch>(ctor);
                        IBranch br = (IBranch)DMEEditor.assemblyHandler.GetInstance(item.PackageName);
                        int id = TreeEditor.SeqID;
                        br.Name = item.PackageName;
                    
                        br.ID = id;
                        br.BranchID = id;
                        br.DMEEditor = DMEEditor;
                        br.TreeEditor = TreeEditor;
                        br.BranchID = id;
                        br.ID = id;
                        TreeEditor.treeBranchHandler.AddBranch(this, br);
                       
                        br.Visutil = Visutil;

                        br.DMEEditor = DMEEditor;

                        ChildBranchs.Add(br);
                    br.CreateChildNodes();




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
        public  IBranch  CreateCategoryNode(CategoryFolder p)
        {
            AICategoryNode categoryBranch = null;
            try
            {
                 categoryBranch = new AICategoryNode(TreeEditor, DMEEditor, this, p.FolderName, TreeEditor.SeqID, EnumPointType.Category, "category.ico");
                TreeEditor.treeBranchHandler.AddBranch(this, categoryBranch);
                ChildBranchs.Add(categoryBranch);
                categoryBranch.CreateChildNodes();


            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error Creating Category  View Node ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return categoryBranch;

        }
        #endregion"Other Methods"
        #region "Files Management"
        public string GetFilePath(string AIEngineName)
        {
            string retval = null;
            try
            {
                CreateFolders();
                if (DMEEditor.ErrorObject.Flag == Errors.Ok)
                {
                    retval = Path.Combine(DMEEditor.ConfigEditor.Config.ExePath + @"AI", AIEngineName);
                }
                return retval;
            }
            catch (Exception ex)
            {
                string errmsg = $"Error getting File for {AIEngineName} ";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                return null;
            }

        }
        private IErrorsInfo CreateFolders()
        {
            try
            {
                if (DMEEditor.ConfigEditor.Config.Folders == null)
                {
                    DMEEditor.ConfigEditor.Config.Folders.Add(new StorageFolders(Path.Combine(DMEEditor.ConfigEditor.Config.ExePath ,@"AI"), FolderFileTypes.Scripts));
                }
                if (!DMEEditor.ConfigEditor.Config.Folders.Where(i => i.FolderFilesType == FolderFileTypes.Scripts).Any())
                {
                    DMEEditor.ConfigEditor.Config.Folders.Add(new StorageFolders(Path.Combine(DMEEditor.ConfigEditor.Config.ExePath, @"AI"), FolderFileTypes.Scripts));
                }
                DMEEditor.ConfigEditor.CreateDirConfig(Path.Combine(DMEEditor.ConfigEditor.Config.ExePath , @"AI"), FolderFileTypes.Scripts);

                DMEEditor.ConfigEditor.SaveConfigValues();

            }
            catch (Exception ex)
            {

                string errmsg = $"Error Creating Reports Folder";
                DMEEditor.AddLogMessage("Fail", $"{errmsg}:{ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }

      


        #endregion
    }
}

    