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
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.FunctionsandExtensions
{
    [AddinAttribute(Caption = "Developer Assistant", Name = "DeveloperAssistantMenuFunctions", menu = "Beep", misc = "DeveloperAssistantMenuFunctions", ObjectType ="Beep",addinType = AddinType.Class, iconimage = "dev.ico",order =4)]
    public class DeveloperAssistantMenuFunctions : IFunctionExtension
    {
        public IDMEEditor DMEEditor { get; set; }
        public IPassedArgs Passedargs { get; set; }

        CancellationTokenSource tokenSource;

        CancellationToken token;


        private FunctionandExtensionsHelpers ExtensionsHelpers;
        public DeveloperAssistantMenuFunctions(IDMEEditor pdMEEditor,VisManager pvisManager,TreeControl ptreeControl)
        {

            DMEEditor = pdMEEditor;

            ExtensionsHelpers = new FunctionandExtensionsHelpers(DMEEditor, pvisManager, ptreeControl);
        }
       

         [CommandAttribute(Caption = "Create POCO Classes", Name = "createpoco", Click = true, iconimage = "createpoco.ico", ObjectType = "Beep", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CreatePOCOlasses(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                ExtensionsHelpers.GetValues(Passedarguments);
                //string iconimage;
                ExtensionsHelpers.pbr = ExtensionsHelpers.TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
                {
                   

                    if (ExtensionsHelpers.DataSource != null)
                    {

                        if (ExtensionsHelpers.DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                        {
                            if (ExtensionsHelpers.Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
                            {
                                PassedArgs args = new PassedArgs();
                                args.ParameterString1 = $"Creating POCO Entities Files for {Passedarguments.DatasourceName} ";
                                ExtensionsHelpers.Vismanager.ShowWaitForm(args);
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
                                        if (ExtensionsHelpers.TreeEditor.SelectedBranchs.Count > 0)
                                        {
                                            foreach (int item in ExtensionsHelpers.TreeEditor.SelectedBranchs)
                                            {
                                                args.ParameterString1 = $"Addin Entity  {item} ";
                                                ExtensionsHelpers.Vismanager.PasstoWaitForm(args);
                                                IBranch br = ExtensionsHelpers.TreeEditor.treeBranchHandler.GetBranch(item);

                                                //         TreeEditor.AddCommentsWaiting($"{i} - Added {br.BranchText} to {Passedarguments.DatasourceName}");
                                                EntityStructure ent = ExtensionsHelpers.DataSource.GetEntityStructure(br.BranchText, true);

                                                DMEEditor.classCreator.CreateClass(ent.EntityName, ent.Fields, Path.Combine(DMEEditor.ConfigEditor.Config.ScriptsPath, Passedarguments.DatasourceName));
                                                i += 1;
                                            }
                                            DMEEditor.AddLogMessage("Success", $"Created POCO", DateTime.Now, 0, null, Errors.Ok);
                                         //   ExtensionsHelpers.Vismanager.Controlmanager.MsgBox("Beep", "Created POCO Successfully");
                                        }
                                        //foreach (string tb in DataSource.EntitiesNames)
                                        //{

                                        //}
                                        ExtensionsHelpers.Vismanager.CloseWaitForm();
                                    }
                                }
                                catch (Exception ex1)
                                {

                                    DMEEditor.AddLogMessage("Fail", $"Could not Create Directory or error in Generating Class {ex1.Message}", DateTime.Now, 0, Passedarguments.DatasourceName, Errors.Failed);
                                    ExtensionsHelpers.Vismanager.CloseWaitForm();
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
                ExtensionsHelpers.Vismanager.CloseWaitForm();
            }
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Caption = "Create DLL Classes", Name = "createdll", Click = true, ObjectType = "Beep", iconimage = "dllgen.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CreateDLLclasses(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                //string iconimage;
                ExtensionsHelpers.GetValues(Passedarguments);
                List<EntityStructure> ls = new List<EntityStructure>();
                EntityStructure entity = null;
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                ExtensionsHelpers.pbr = ExtensionsHelpers.TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (ExtensionsHelpers.pbr.BranchType == EnumPointType.DataPoint)
                {
                   

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
                                    DMEEditor.AddLogMessage("Fail", item, DateTime.Now, 0, ExtensionsHelpers.DataSource.DatasourceName, Errors.Failed);
                                }

                            }
                        }
                        //  }


                    });
                    if (ExtensionsHelpers.DataSource != null)
                    {

                        if (ExtensionsHelpers.DataSource.ConnectionStatus == System.Data.ConnectionState.Open)
                        {
                            if (ExtensionsHelpers.Vismanager.Controlmanager.InputBoxYesNo("Beep DM", "Are you sure, this might take some time?") == BeepEnterprize.Vis.Module.DialogResult.Yes)
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
                                    PassedArgs args = new PassedArgs();
                                    args.ParameterString1 = $"Creating DLL for POCO Entities  {Passedarguments.DatasourceName} ";
                                    ExtensionsHelpers.Vismanager.ShowWaitForm(args);
                                    foreach (int item in ExtensionsHelpers.TreeEditor.SelectedBranchs)
                                    {
                                        IBranch br = ExtensionsHelpers.TreeEditor.treeBranchHandler.GetBranch(item);
                                        IDataSource srcds = DMEEditor.GetDataSource(br.DataSourceName);

                                        if (srcds != null)
                                        {
                                            if (srcds.DatasourceName == Passedarguments.DatasourceName)
                                            {
                                                args.ParameterString1 = $"Addin Entity  {br.BranchText} ";
                                                ExtensionsHelpers.Vismanager.PasstoWaitForm(args);
                                                if (!ExtensionsHelpers.DataSource.Entities.Where(p => p.EntityName.Equals(br.BranchText, StringComparison.OrdinalIgnoreCase)).Any())
                                                {
                                                    entity = (EntityStructure)srcds.GetEntityStructure(br.BranchText, true).Clone();
                                                }
                                                else
                                                {
                                                    entity = (EntityStructure)ExtensionsHelpers.DataSource.Entities.Where(p => p.EntityName.Equals(br.BranchText, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Clone();
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
                                    //    ExtensionsHelpers.Vismanager.Controlmanager.MsgBox("Beep", "Created DLL Successfully");
                                    }
                                    else
                                    {
                                        //MessageBox.Show(t, ret,"Beep");
                                    }

                                    ExtensionsHelpers.Vismanager.CloseWaitForm();
                                }
                                catch (Exception ex1)
                                {

                                    DMEEditor.AddLogMessage("Fail", $"Could not Create Directory or error in Generating DLL {ex1.Message}", DateTime.Now, 0, Passedarguments.DatasourceName, Errors.Failed);
                                    ExtensionsHelpers.Vismanager.CloseWaitForm();
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
