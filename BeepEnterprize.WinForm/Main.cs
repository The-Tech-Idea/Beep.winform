using Autofac;
using System.Linq;
using TheTechIdea.Beep;
using TheTechIdea.Logger;
using TheTechIdea.Beep.Workflow;
using TheTechIdea.Util;
using TheTechIdea.Tools;
using TheTechIdea.Beep.Editor;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.Tools;
using System.Threading;
using TheTechIdea;
using System;

namespace BeepEnterprize.Winform

{   
    public class MainApp
    {
        private static IContainer Container { get; set; }
        private static ContainerBuilder Builder { get; set; }
        #region "System Components"
        public IDMEEditor DMEEditor { get; set; }
        public IConfigEditor Config_editor { get; set; }
      
        public IDMLogger lg { get; set; }
        public IUtil util { get; set; }
        public  IVisManager vis { get; set; }
        public IErrorsInfo Erinfo { get; set; }
        public IJsonLoader jsonLoader { get; set; }
        public IAssemblyHandler LLoader { get; set; }
        public IClassCreator classCreator { get; set; }
        public IDataTypesHelper typesHelper { get; set; }
        public IETL eTL { get; set; }
        public IWorkFlowEditor WorkFlowEditor { get; set; }
        public IWorkFlowStepEditor WorkFlowStepEditor { get; set; }
        public IRuleParser ruleparser { get; set; }
        public IRulesEditor rulesEditor { get; set; }

        #endregion
        IProgress<PassedArgs> progress;
        CancellationToken token;
        public static IContainer Configure() //ContainerBuilder builder
        {
            Builder = new ContainerBuilder();
            Builder.RegisterType<ErrorsInfo>().As<IErrorsInfo>().SingleInstance();
            Builder.RegisterType<DMLogger>().As<IDMLogger>().SingleInstance();
            Builder.RegisterType<ConfigEditor>().As<IConfigEditor>().SingleInstance();
            Builder.RegisterType<DataTypesHelper>().As<IDataTypesHelper>().SingleInstance();
            Builder.RegisterType<DMEEditor>().As<IDMEEditor>().SingleInstance();
            Builder.RegisterType<WorkFlowEditor>().As<IWorkFlowEditor>().SingleInstance();
            Builder.RegisterType<WorkFlowStepEditor>().As<IWorkFlowStepEditor>().SingleInstance();
            Builder.RegisterType<RuleParser>().As<IRuleParser>().SingleInstance();
            Builder.RegisterType<RulesEditor>().As<IRulesEditor>().SingleInstance();
            Builder.RegisterType<Util>().As<IUtil>().SingleInstance();
            Builder.RegisterType<VisManager>().As<IVisManager>().SingleInstance();
            Builder.RegisterType<JsonLoader>().As<IJsonLoader>().SingleInstance();
            Builder.RegisterType<AssemblyHandler>().As<IAssemblyHandler>().SingleInstance();
            Builder.RegisterType<ClassCreator>().As<IClassCreator>().SingleInstance();
            Builder.RegisterType<ETL>().As<IETL>().SingleInstance();
            return Builder.Build();
           
        }
        public MainApp()
        {
            Container = Configure();
            using (var scope = Container.BeginLifetimeScope())
            {
                Config_editor = scope.Resolve<IConfigEditor>();
                LLoader = scope.Resolve<IAssemblyHandler>();
                eTL = scope.Resolve<IETL>();
                WorkFlowEditor = scope.Resolve<IWorkFlowEditor>();
                WorkFlowStepEditor = scope.Resolve<IWorkFlowStepEditor>();
                ruleparser = scope.Resolve<IRuleParser>();
                rulesEditor = scope.Resolve<IRulesEditor>();
                DMEEditor = scope.Resolve<IDMEEditor>();
                typesHelper = scope.Resolve<IDataTypesHelper>();
                classCreator = scope.Resolve<IClassCreator>();
                typesHelper.DMEEditor = DMEEditor;
                DMEEditor.typesHelper = typesHelper;
                DMEEditor.ETL = eTL;
                eTL.DMEEditor = DMEEditor;
                DMEEditor.assemblyHandler = LLoader;
                DMEEditor.classCreator = classCreator;

                DMEEditor.WorkFlowEditor = WorkFlowEditor;
                DMEEditor.WorkFlowEditor.DMEEditor = DMEEditor;
                WorkFlowStepEditor.DMEEditor = DMEEditor;
                DMEEditor.WorkFlowEditor.StepEditor = WorkFlowStepEditor;

                ruleparser.DMEEditor = DMEEditor;
                rulesEditor.DMEEditor = DMEEditor;
                rulesEditor.Parser = ruleparser;
                
                DMEEditor.ETL.RulesEditor = rulesEditor;

                vis = scope.Resolve<IVisManager>();
               
                LLoader.LoadAllAssembly( progress,token);
                Config_editor.LoadedAssemblies = LLoader.Assemblies.Select(c => c.DllLib).ToList();

                // Setup the Entry Screen 
                // the screen has to be in one the Addin DLL's loaded by the Assembly loader
                Config_editor.Config.SystemEntryFormName = @"Frm_main";
                //AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
                //{
                //    DMEEditor.AddLogMessage("Beep",eventArgs.Exception.ToString(),DateTime.Now,0,null,Errors.Failed);
                //};
                vis.ShowMainPage();

              
            }
        }
    }
}
