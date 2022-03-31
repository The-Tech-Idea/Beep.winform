using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using BeepEnterprize.Winform.Vis.CRUD;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Addin;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.FunctionsandExtensions
{
    [AddinAttribute(Caption = "Edit", Name = "EditMenuFunctions", misc = "EditMenuFunctions", addinType = AddinType.Class, iconimage = "edit.ico", order = 2)]
    public class EditMenuFunctions : IFunctionExtension
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
        public EditMenuFunctions(IDMEEditor pdMEEditor, VisManager pvisManager, TreeControl ptreeControl)
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
            if (!string.IsNullOrEmpty(Passedarguments.DatasourceName))
            {
                DataSource = DMEEditor.GetDataSource(Passedarguments.DatasourceName);
                if(DataSource!= null)
                {
                    DMEEditor.OpenDataSource(Passedarguments.DatasourceName);
                }
            }
            if (Passedarguments.Id>0)
            {
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                RootBranch = TreeEditor.Branches[TreeEditor.Branches.FindIndex(x => x.BranchClass == pbr.BranchClass && x.BranchType == EnumPointType.Root)];
            }
           
            
        }


        [CommandAttribute(Caption = "Turnon/Off CheckBox's", Name = "Turnon/Off CheckBox", Click = true, iconimage = "checkbox.ico", PointType = EnumPointType.Global)]
        public IErrorsInfo TurnonOffCheckBox(IPassedArgs Passedarguments)
        {
            DMEEditor.ErrorObject.Flag = Errors.Ok;
            try
            {
                GetValues(Passedarguments);
                TreeEditor.TurnonOffCheckBox(Passedarguments);

                DMEEditor.AddLogMessage("Success", $"Turn on/off entities", DateTime.Now, 0, null, Errors.Ok);
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Fail", $"Could not turn on/offf entities {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Name = "EditDefaults", Caption = "Edit Default", Click = true, iconimage = "editdefaults.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo EditDefault(IPassedArgs Passedarguments)
        {

            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //  DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);
                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == Passedarguments.DatasourceName)].DatasourceDefaults;
                    if (defaults != null)
                    {
                        string[] args = { "CopyDefaults", null, null };
                        List<ObjectItem> ob = new List<ObjectItem>(); ;
                        ObjectItem it = new ObjectItem();
                        it.obj = defaults;
                        it.Name = "Defaults";
                        ob.Add(it);
                        Passedarguments.CurrentEntity = Passedarguments.DatasourceName;
                        Passedarguments.Id = 0;
                        Passedarguments.ObjectType = "COPYDEFAULTS";
                        Passedarguments.ObjectName = Passedarguments.DatasourceName;
                        Passedarguments.Objects = ob;
                        Passedarguments.DatasourceName = Passedarguments.DatasourceName;
                        Passedarguments.EventType = "COPYDEFAULTS";

                        //  TreeEditor.args = (PassedArgs)Passedarguments;
                        DMEEditor.Passedarguments = Passedarguments;
                        DMEEditor.AddLogMessage("Success", $"Edit Defaults", DateTime.Now, 0, null, Errors.Ok);
                        Vismanager.ShowPage("uc_datasourceDefaults", (PassedArgs)Passedarguments);
                    }
                    else
                    {
                        string mes = "Could not get Defaults";
                        DMEEditor.AddLogMessage("Failed", mes, DateTime.Now, -1, mes, Errors.Failed);
                    }
                }


            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error getting defaults ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Name = "CopyDefaults", Caption = "Copy Default", Click = true, iconimage = "copydefaults.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo CopyDefault(IPassedArgs Passedarguments)
        {

            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //  DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
                pbr = TreeEditor.treeBranchHandler.GetBranch(Passedarguments.Id);
                if (pbr.BranchType == EnumPointType.DataPoint)
                {
                    GetValues(Passedarguments);
                    List<DefaultValue> defaults = DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == Passedarguments.DatasourceName)].DatasourceDefaults;
                    if (defaults != null)
                    {
                        string[] args = { "CopyDefaults", null, null };
                        List<ObjectItem> ob = new List<ObjectItem>(); ;
                        ObjectItem it = new ObjectItem();
                        it.obj = defaults;
                        it.Name = "Defaults";
                        ob.Add(it);
                        Passedarguments.CurrentEntity = Passedarguments.DatasourceName;
                        Passedarguments.Id = 0;
                        Passedarguments.ObjectType = "COPYDEFAULTS";
                        Passedarguments.ObjectName = Passedarguments.DatasourceName;
                        Passedarguments.Objects = ob;
                        Passedarguments.DatasourceName = Passedarguments.DatasourceName;
                        Passedarguments.EventType = "COPYDEFAULTS";

                        DMEEditor.AddLogMessage("Success", $"Copy Defaults", DateTime.Now, 0, null, Errors.Ok);
                        Vismanager.Controlmanager.MsgBox("Beep", "Defaults Copied Successfully");
                        DMEEditor.Passedarguments = Passedarguments;
                    }
                    else
                    {
                        string mes = "Could not get Defaults";
                        DMEEditor.AddLogMessage("Failed", mes, DateTime.Now, -1, mes, Errors.Failed);
                    }
                }


            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error getting defaults ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;
        }
        [CommandAttribute(Name = "PasteDefaults", Caption = "Paste Default", Click = true, iconimage = "pastedefaults.ico", PointType = EnumPointType.DataPoint)]
        public IErrorsInfo PasteDefault(IPassedArgs Passedarguments)
        {
            GetValues(Passedarguments);

            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //  DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
                if (DMEEditor.Passedarguments != null)
                {
                    if (DMEEditor.Passedarguments.ObjectType == "COPYDEFAULTS")
                    {
                        if (Passedarguments.Objects.Where(o => o.Name == "Defaults").Any())
                        {
                            List<DefaultValue> defaults = (List<DefaultValue>)Passedarguments.Objects.Where(o => o.Name == "Defaults").FirstOrDefault().obj;
                            DMEEditor.ConfigEditor.DataConnections[DMEEditor.ConfigEditor.DataConnections.FindIndex(i => i.ConnectionName == DataSource.DatasourceName)].DatasourceDefaults = defaults;
                            DMEEditor.ConfigEditor.SaveDataconnectionsValues();
                            DMEEditor.AddLogMessage("Success", $"Paste Defaults", DateTime.Now, 0, null, Errors.Ok);
                            Vismanager.Controlmanager.MsgBox("Beep", "Pasted Defaults Successfully");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error in  pasting Defaults ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;

        }
        [CommandAttribute(Name = "WorkFlowEditor", Caption = "WorkFlow Editor", Click = true, iconimage = "workflow.ico", PointType = EnumPointType.Global)]
        public IErrorsInfo WorkFlowEditor(IPassedArgs Passedarguments)
        {

            DMEEditor.ErrorObject.Flag = Errors.Ok;
            //  DMEEditor.Logger.WriteLog($"Filling Database Entites ) ");
            try
            {
             
                    GetValues(Passedarguments);
                     //  TreeEditor.args = (PassedArgs)Passedarguments;
                        DMEEditor.Passedarguments = Passedarguments;
                      //  DMEEditor.AddLogMessage("Success", $"Edit Defaults", DateTime.Now, 0, null, Errors.Ok);
                        Vismanager.ShowPage("uc_WorkflowEditor", (PassedArgs)Passedarguments);
            }
            catch (Exception ex)
            {
                DMEEditor.Logger.WriteLog($"Error getting defaults ({ex.Message}) ");
                DMEEditor.ErrorObject.Flag = Errors.Failed;
                DMEEditor.ErrorObject.Ex = ex;
            }
            return DMEEditor.ErrorObject;
        }

    }
}

