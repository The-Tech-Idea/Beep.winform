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
using System.Threading;
using TheTechIdea;
using System;
using TheTechIdea.Beep.Tools;
using Beep.Winform.Vis;

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

        #endregion
        CancellationTokenSource tokenSource;
        CancellationToken token;
        public static IContainer Configure() //ContainerBuilder builder
        {
            Builder = new ContainerBuilder();
            Builder.RegisterType<ErrorsInfo>().As<IErrorsInfo>().SingleInstance();
            Builder.RegisterType<DMLogger>().As<IDMLogger>().SingleInstance();
            Builder.RegisterType<ConfigEditor>().As<IConfigEditor>().SingleInstance();
            Builder.RegisterType<DMEEditor>().As<IDMEEditor>().SingleInstance();
            Builder.RegisterType<Util>().As<IUtil>().SingleInstance();
            Builder.RegisterType<VisManager>().As<IVisManager>().SingleInstance();
            Builder.RegisterType<JsonLoader>().As<IJsonLoader>().SingleInstance();
            Builder.RegisterType<AssemblyHandler>().As<IAssemblyHandler>().SingleInstance();
            return Builder.Build();
           
        }
        public MainApp()
        {

            Container = Configure();
            using (var scope = Container.BeginLifetimeScope())
            {
                Config_editor = scope.Resolve<IConfigEditor>();
                LLoader = scope.Resolve<IAssemblyHandler>();
                DMEEditor = scope.Resolve<IDMEEditor>();
             
                vis = scope.Resolve<IVisManager>();
            

                vis.Title = "Beep - The Data Plaform";
                vis.IconUrl = "SimpleODM.ico";

                // Show Image Log instead of above Text Title
                //vis.LogoUrl = "dh3.png";



                DMEEditor.AddLogMessage("Started Assembly Loader");

                // Create A parameter object for Wait Form
                PassedArgs p = new PassedArgs();
                p.ParameterString1 = "Loading DLL's";
                // Show Wait Form
                vis.ShowWaitForm(p);
                // Passing Message to WaitForm
                vis.PasstoWaitForm(p);
               
                    var progress = new Progress<PassedArgs>(percent => {

                        p.ParameterString1 = percent.ParameterString1;
                        vis.PasstoWaitForm(p);
                    });
                    DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "IProgress", obj = progress });
                    tokenSource = new CancellationTokenSource();
                    token = tokenSource.Token;
                    DMEEditor.Passedarguments.Objects.Add(new ObjectItem() { Name = "CancellationToken", obj = token });
              
                // Prepare Async Data Notification from Assembly loader to WaitForm
              
                

                // Load Assemblies
                LLoader.LoadAllAssembly(progress, token);
                Config_editor.LoadedAssemblies = LLoader.Assemblies.Select(c => c.DllLib).ToList();

                // Create Default Parameter object
                DMEEditor.Passedarguments = new PassedArgs();
                DMEEditor.Passedarguments.Objects = new System.Collections.Generic.List<ObjectItem>();

                // Setup the Entry Screen 
                // the screen has to be in one the Addin DLL's loaded by the Assembly loader
                // Config_editor.Config.SystemEntryFormName = @"MainForm";
                Config_editor.Config.SystemEntryFormName = @"Frm_Main";
                
                DMEEditor.AddLogMessage("Show Main Page");
                // Show Beep Data Management System Tree
                vis.BeepObjectsName = "Beep";

                //vis.AppObjectsName = "App";
                vis.IsBeepDataOn = true;

                // Show or Hide Custome App Tree
                vis.IsAppOn = false;
                // This Flag for Showing Main Form
                
                vis.IsShowingMainForm =true; 
                vis.ShowMainPage();
               

            }
        }
    }
}
