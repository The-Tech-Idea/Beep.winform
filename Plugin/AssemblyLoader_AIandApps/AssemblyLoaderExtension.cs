using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.AI;

using TheTechIdea.Beep.AppModule;
using TheTechIdea.Beep.ConfigUtil;
using TheTechIdea.Beep.Report;
using TheTechIdea.Beep.Vis;

using TheTechIdea.Tools;
using TheTechIdea.Util;
using IOrder = TheTechIdea.Beep.Vis.IOrder;

namespace AssemblyLoaderExtension
{
    public class AssemblyLoaderExtension : ILoaderExtention
    {
        public AppDomain CurrentDomain { get; set; }
   
        public IAssemblyHandler Loader { get; set; }
        public AssemblyLoaderExtension(IAssemblyHandler ploader)
        {
            Loader = ploader;
          
          //  DMEEditor = 
            CurrentDomain = AppDomain.CurrentDomain;
         
            CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        public IErrorsInfo LoadAllAssembly()
        {
            ErrorsInfo er = new ErrorsInfo();
           

                foreach (var item in Loader.Assemblies)
                {
                    try
                    {
                        ScanAssembly(item.DllLib);
                    }
                    catch (Exception ex)
                    {

                        
                    }
                  
                }
               
          
            
            return er;
        }
        #region "Class Extractors"
        private bool ScanAssembly(Assembly asm)
        {
            Type[] t;

            try
            {
                try
                {
                    t = asm.GetTypes();
                }
                catch (Exception ex2)
                {
                    //DMEEditor.AddLogMessage("Failed", $"Could not get types for {asm.GetName().ToString()}", DateTime.Now, -1, asm.GetName().ToString(), Errors.Failed);
                    try
                    {
                        //DMEEditor.AddLogMessage("Try", $"Trying to get exported types for {asm.GetName().ToString()}", DateTime.Now, -1, asm.GetName().ToString(), Errors.Ok);
                        t = asm.GetExportedTypes();
                    }
                    catch (Exception ex3)
                    {
                        t = null;
                        //DMEEditor.AddLogMessage("Failed", $"Could not get types for {asm.GetName().ToString()}", DateTime.Now, -1, asm.GetName().ToString(), Errors.Failed);
                    }

                }

                if (t != null)
                {
                    foreach (var mytype in t) //asm.DefinedTypes
                    {
                        
                        TypeInfo type = mytype.GetTypeInfo();
                        string[] p = asm.FullName.Split(new char[] { ',' });
                        p[1] = p[1].Substring(p[1].IndexOf("=") + 1);
                        Console.WriteLine(p[1]);
                        //-------------------------------------------------------


                        //-------------------------------------------------------

                        //-------------------------------------------------------
                        // Get IBranch Definitions
                        //-------------------------------------------------------
                        // Get IAppBuilder  Definitions
                        if (type.ImplementedInterfaces.Contains(typeof(IAppBuilder)))
                        {
                            
                            Loader.ConfigEditor.AppWritersClasses.Add(Loader.GetAssemblyClassDefinition(type, "IAppBuilder"));
                        }
                        if (type.ImplementedInterfaces.Contains(typeof(IAppComponent)))
                        {
                            
                            Loader.ConfigEditor.AppComponents.Add(Loader.GetAssemblyClassDefinition(type, "IAppComponent"));
                        }
                        if (type.ImplementedInterfaces.Contains(typeof(TheTechIdea.Beep.AppModule.IAppBlock)))
                        {

                            Loader.ConfigEditor.AppComponents.Add(Loader.GetAssemblyClassDefinition(type, "IAppBlock"));
                        }
                        if (type.ImplementedInterfaces.Contains(typeof(IAppDesigner)))
                        {
                           
                            Loader.ConfigEditor.AppWritersClasses.Add(Loader.GetAssemblyClassDefinition(type, "IAppDesigner"));
                        }
                        if (type.ImplementedInterfaces.Contains(typeof(IAppScreen)))
                        {
                           
                            Loader.ConfigEditor.AppComponents.Add(Loader.GetAssemblyClassDefinition(type, "IAppScreen"));
                        }

                        //-------------------------------------------------------
                        // Get Reports Implementations Definitions
                        if (type.ImplementedInterfaces.Contains(typeof(IReportDMWriter)))
                        {
                            
                            Loader.ConfigEditor.ReportWritersClasses.Add(Loader.GetAssemblyClassDefinition(type, "IReportDMWriter"));
                        }
                        //-------------------------------------------------------

                        // --- Get all AI app Interfaces
                        //-----------------------------------------------------
                        if (type.ImplementedInterfaces.Contains(typeof(IAAPP)))
                        {
                            AssemblyClassDefinition xcls = new AssemblyClassDefinition();
                            xcls.Methods = new List<MethodsClass>();
                            xcls.className = type.Name;
                            xcls.dllname = type.Module.Name;
                            xcls.PackageName = type.FullName;
                            xcls.componentType = "IAAPP";
                            foreach (MethodInfo methods in type.GetMethods()
                                         .Where(m => m.GetCustomAttributes(typeof(MLMethod), false).Length > 0)
                                          .ToArray())
                            {

                                MLMethod methodAttribute = methods.GetCustomAttribute<MLMethod>();
                                MethodsClass x = new MethodsClass();
                                x.Caption = methodAttribute.Caption;
                                x.Info = methods;
                                x.Hidden = methodAttribute.Hidden;
                                x.Click = methodAttribute.Click;
                                x.type = typeof(MLMethod);
                                x.DoubleClick = methodAttribute.DoubleClick;

                                xcls.Methods.Add(x);
                            }
                            foreach (MethodInfo methods in type.GetMethods()
                                        .Where(m => m.GetCustomAttributes(typeof(MLPredict), false).Length > 0)
                                         .ToArray())
                            {

                                MLPredict methodAttribute = methods.GetCustomAttribute<MLPredict>();
                                MethodsClass x = new MethodsClass();
                                x.Caption = methodAttribute.Caption;
                                x.Info = methods;
                                x.Hidden = methodAttribute.Hidden;
                                x.Click = methodAttribute.Click;
                                x.type = typeof(MLPredict);
                                x.DoubleClick = methodAttribute.DoubleClick;

                                xcls.Methods.Add(x);
                            }
                            foreach (MethodInfo methods in type.GetMethods()
                                     .Where(m => m.GetCustomAttributes(typeof(MLLoadModule), false).Length > 0)
                                      .ToArray())
                            {

                                MLLoadModule methodAttribute = methods.GetCustomAttribute<MLLoadModule>();
                                MethodsClass x = new MethodsClass();
                                x.Caption = methodAttribute.Caption;
                                x.Info = methods;
                                x.Hidden = methodAttribute.Hidden;
                                x.Click = methodAttribute.Click;
                                x.type = typeof(MLLoadModule);
                                x.DoubleClick = methodAttribute.DoubleClick;
                                xcls.Methods.Add(x);
                            }
                            foreach (MethodInfo methods in type.GetMethods()
                                  .Where(m => m.GetCustomAttributes(typeof(MLEval), false).Length > 0)
                                   .ToArray())
                            {

                                MLEval methodAttribute = methods.GetCustomAttribute<MLEval>();
                                MethodsClass x = new MethodsClass();
                                x.Caption = methodAttribute.Caption;
                                x.Info = methods;
                                x.Hidden = methodAttribute.Hidden;
                                x.Click = methodAttribute.Click;
                                x.type = typeof(MLEval);
                                x.DoubleClick = methodAttribute.DoubleClick;
                                xcls.Methods.Add(x);
                            }
                            foreach (MethodInfo methods in type.GetMethods()
                                 .Where(m => m.GetCustomAttributes(typeof(MLLoadData), false).Length > 0)
                                  .ToArray())
                            {

                                MLLoadData methodAttribute = methods.GetCustomAttribute<MLLoadData>();
                                MethodsClass x = new MethodsClass();
                                x.Caption = methodAttribute.Caption;
                                x.Info = methods;
                                x.Hidden = methodAttribute.Hidden;
                                x.Click = methodAttribute.Click;
                                x.type = typeof(MLLoadData);
                                x.DoubleClick = methodAttribute.DoubleClick;
                                xcls.Methods.Add(x);
                            }
                            if (type.ImplementedInterfaces.Contains(typeof(IOrder)))
                            {
                                try
                                {
                                    IOrder cls = (IOrder)Activator.CreateInstance(type);
                                    xcls.Order = cls.Order;
                                    cls = null;
                                }
                                catch (Exception)
                                {


                                }

                            }
                            Loader.ConfigEditor.BranchesClasses.Add(xcls);
                        }
                        // --- Get all AI app Interfaces
                        //-----------------------------------------------------


                    }
                }

            }
            catch (Exception ex)
            {
                //DMEEditor.AddLogMessage("Failed", $"Could not get Any types for {asm.GetName().ToString()}" , DateTime.Now, -1, asm.GetName().ToString(), Errors.Failed);
            };

            return true;


        }
        #endregion "Class Extractors"
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Ignore missing resources
            if (args.Name.Contains(".resources"))
                return null;
            string filename = args.Name.Split(',')[0] + ".dll".ToLower();
            string filenamewo = args.Name.Split(',')[0];
            // check for assemblies already loaded
            //   var s = AppDomain.CurrentDomain.GetAssemblies();
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.StartsWith(filenamewo));
            if (assembly == null)
            {
                assemblies_rep s = Loader.Assemblies.FirstOrDefault(a => a.DllLib.FullName.StartsWith(filenamewo));
                if (s != null)
                {
                    assembly = s.DllLib;
                }

            }
            if (assembly != null)
                return assembly;
            foreach (var moduleDir in Loader.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.OtherDLL))
            {
                var di = new DirectoryInfo(moduleDir.FolderPath);
                var module = di.GetFiles().FirstOrDefault(i => i.Name == filename);
                if (module != null)
                {
                    return Assembly.LoadFrom(module.FullName);
                }
            }
            if (assembly != null)
                return assembly;
            foreach (var moduleDir in Loader.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.ConnectionDriver))
            {
                var di = new DirectoryInfo(moduleDir.FolderPath);
                var module = di.GetFiles().FirstOrDefault(i => i.Name == filename);
                if (module != null)
                {
                    return Assembly.LoadFrom(module.FullName);
                }
            }
            if (assembly != null)
                return assembly;
            foreach (var moduleDir in Loader.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.ProjectClass))
            {
                var di = new DirectoryInfo(moduleDir.FolderPath);
                var module = di.GetFiles().FirstOrDefault(i => i.Name == filename);
                if (module != null)
                {
                    return Assembly.LoadFrom(module.FullName);
                }
            }


            return null;

        }
        public IErrorsInfo Scan()
        {
            ErrorsInfo er = new ErrorsInfo();
            try
            {

                LoadAllAssembly();
                er.Flag = Errors.Ok;
            }
            catch (Exception ex)
            {
                er.Ex = ex;
                er.Flag = Errors.Failed;
                er.Message = ex.Message;

            }
            return er;
        }
    }
}
