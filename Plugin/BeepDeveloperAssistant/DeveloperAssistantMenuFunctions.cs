using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using BeepEnterprize.Winform.Vis.CRUD;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.FunctionsandExtensions
{
    [AddinAttribute(Caption = "Developer Assistant", Name = "DeveloperAssistantMenuFunctions", misc = "DeveloperAssistantMenuFunctions", addinType = AddinType.Class, iconimage = "dev.ico",order =4)]
    public class DeveloperAssistantMenuFunctions : IFunctionExtension
    {
        public IDMEEditor DMEEditor { get; set; }
        public IPassedArgs Passedargs { get; set; }
        private VisManager Vismanager { get; set; }
        private ControlManager Controlmanager { get; set; }
        private CrudManager Crudmanager { get; set; }
        private MenuControl Menucontrol { get; set; }
        private ToolbarControl Toolbarcontrol { get; set; }
        private TreeControl TreeEditor { get; set; }

        CancellationTokenSource tokenSource;
        CancellationToken token;
        IDataSource DataSource;
        IBranch pbr;
        IBranch RootBranch;
        public DeveloperAssistantMenuFunctions(IDMEEditor pdMEEditor,VisManager pvisManager,TreeControl ptreeControl)
        {
            DMEEditor = pdMEEditor;
            Vismanager = pvisManager;
            TreeEditor = ptreeControl;
        }
        private void GetValues(IPassedArgs Passedarguments)
        {

            if (Passedarguments.Objects.Where(c => c.Name == "Vismanager").Any())
            {
                Vismanager = (VisManager)Passedarguments.Objects.Where(c => c.Name == "Vismanager").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "TreeControl").Any())
            {
                TreeEditor = (TreeControl)Passedarguments.Objects.Where(c => c.Name == "TreeControl").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "CrudManager").Any())
            {
                Crudmanager = (CrudManager)Passedarguments.Objects.Where(c => c.Name == "CrudManager").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "ControlManager").Any())
            {
                Controlmanager = (ControlManager)Passedarguments.Objects.Where(c => c.Name == "ControlManager").FirstOrDefault().obj;
            }
            if (Passedarguments.Objects.Where(c => c.Name == "MenuControl").Any())
            {
                Menucontrol = (MenuControl)Passedarguments.Objects.Where(c => c.Name == "MenuControl").FirstOrDefault().obj;
            }

            if (Passedarguments.Objects.Where(c => c.Name == "ToolbarControl").Any())
            {
                Toolbarcontrol = (ToolbarControl)Passedarguments.Objects.Where(c => c.Name == "ToolbarControl").FirstOrDefault().obj;
            }

            DataSource = DMEEditor.GetDataSource(Passedarguments.DatasourceName);
            DMEEditor.OpenDataSource(Passedarguments.DatasourceName);
            pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
            RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == pbr.BranchClass && x.BranchType == EnumPointType.Root)];
        }

         [CommandAttribute(Caption = "Create POCO Classes", Name = "createpoco", Click = true, iconimage = "createpoco.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CreatePOCOlasses(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                string iconimage;
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);

                    if (DataSource != null)
                    {

                        if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                        {
                            if (Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                            {

                                int i = 0;
                                //    TreeEditor.ShowWaiting();
                                //    TreeEditor.ChangeWaitingCaption($"Creating POCO Entities for total:{DataSource.EntitiesNames.Count}");
                                try
                                {
                                    if (!Directory.Exists(Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName)))
                                    {
                                        Directory.CreateDirectory(Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName));
                                    };
                                    {
                                        if (TreeEditor.SelectedBranchs.Count > 0)
                                        {
                                            foreach (int item in TreeEditor.SelectedBranchs)
                                            {
                                                IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);

                                                //         TreeEditor.AddCommentsWaiting($"{i} - Added {br.BranchText} to {Passedarguments.DatasourceName}");
                                                EntityStructure ent = DataSource.GetEntityStructure(br.BranchText, true);

                                                DMEEditor.classCreator.CreateClass(ent.EntityName, ent.Fields, Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName));
                                                i += 1;
                                            }
                                            DMEEditor.AddLogMessage("Success", $"Created POCO", DateTime.Now, 0, null, Errors.Ok);
                                            Vismanager.Controlmanager.MsgBox("Beep", "Created POCO Successfully");
                                        }
                                        //foreach (string tb in DataSource.EntitiesNames)
                                        //{

                                        //}

                                    }
                                }
                                catch (Exception ex1)
                                {

                                    DMEEditor.AddLogMessage("Fail", $"Could not Create Directory or error in Generating Class {ex1.Message}", DateTime.Now, 0, Passedarguments.DatasourceName, Errors.Failed);
                                }

                                //   TreeEditor.HideWaiting();
                            }

                        }

                    }
                }




            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Fail", $" error in Generating Class {ex.Message}", DateTime.Now, 0, Passedarguments.DatasourceName, Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Caption = "Create DLL Classes", Name = "createdll", Click = true, iconimage = "dllgen.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CreateDLLclasses(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                string iconimage;
                List<EntityStructure> ls = new List<EntityStructure>();
                EntityStructure entity = null;
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);

                    var progress = new Progress<PassedArgs>(percent => {

                        if (percent.EventType == "Update")
                        {
                            //   TreeEditor.AddCommentsWaiting(percent.ParameterString1);
                        }

                        //if (DMEEditor.ErrorObject.Flag == Errors.Failed)
                        //{
                        if (!string.IsNullOrEmpty(percent.EventType))
                        {
                            if (percent.EventType == "Error")
                            {
                                List<string> reterror = (List<string>)percent.Objects[0].obj;
                                foreach (var item in reterror)
                                {
                                    DMEEditor.AddLogMessage("Fail", item, DateTime.Now, 0, DataSource.DatasourceName, Errors.Failed);
                                }

                            }
                        }
                        //  }


                    });
                    if (DataSource != null)
                    {

                        if (DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                        {
                            if (Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                            {

                                int i = 0;
                                //    TreeEditor.ShowWaiting();
                                //   TreeEditor.ChangeWaitingCaption($"Creating POCO Entities for total:{DataSource.EntitiesNames.Count}");
                                try
                                {
                                    if (!Directory.Exists(Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName)))
                                    {
                                        Directory.CreateDirectory(Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName));
                                    };

                                    foreach (int item in TreeEditor.SelectedBranchs)
                                    {
                                        IBranch br = TreeEditor.treeBranchHandler.GetBranch(item);
                                        IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);

                                        if (srcds != null)
                                        {
                                            if (srcds.DatasourceName == Passedarguments.DatasourceName)
                                            {
                                                if (!DataSource.Entities.Where(p => p.EntityName.Equals(br.BranchText, StringComparison.OrdinalIgnoreCase)).Any())
                                                {
                                                    entity = (EntityStructure)srcds.GetEntityStructure(br.BranchText, true).Clone();
                                                }
                                                else
                                                {
                                                    entity = (EntityStructure)DataSource.Entities.Where(p => p.EntityName.Equals(br.BranchText, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Clone();
                                                }
                                                //     TreeEditor.AddCommentsWaiting($"{i}- Added Entity {entity.EntityName}");
                                                ls.Add(entity);
                                                i++;
                                            }

                                        }
                                    }
                                    string ret = "ok";
                                    //Control t = (Control)TreeEditor.TreeStrucure;
                                    if (ls.Count > 0)
                                    {
                                        ///   TreeEditor.AddCommentsWaiting($"Creating Entity {entity.EntityName} Files Then DLL");
                                        ret = DMEEditor.classCreator.CreateDLL(Regex.Replace(Passedarguments.DatasourceName, @"\s+", "_"), ls, Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName), progress, token, "TheTechIdea." + Regex.Replace(Passedarguments.DatasourceName, @"\s+", "_"));
                                    }
                                    if (ret == "ok")
                                    {
                                        DMEEditor.AddLogMessage("Success", $"Create DLL", DateTime.Now, 0, null, Errors.Ok);
                                        Vismanager.Controlmanager.MsgBox("Beep", "Created DLL Successfully");
                                    }
                                    else
                                    {
                                        //MessageBox.Show(t, ret,"Beep");
                                    }

                                }
                                catch (Exception ex1)
                                {

                                    DMEEditor.AddLogMessage("Fail", $"Could not Create Directory or error in Generating DLL {ex1.Message}", DateTime.Now, 0, Passedarguments.DatasourceName, Errors.Failed);
                                }

                                //  TreeEditor.HideWaiting();
                            }

                        }

                    }
                }





            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Fail", $" error in Generating DLL {ex.Message}", DateTime.Now, 0, Passedarguments.DatasourceName, Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
    }
}
