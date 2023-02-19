using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;
using BeepEnterprize.Vis.Module;
using BeepEnterprize.Winform.Vis.Controls;
using BeepEnterprize.Winform.Vis.Helpers;
using BeepEnterprize.Winform.Vis.Wizards;

using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.Vis;
using TheTechIdea.PrintManagers;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis
{
    public class VisManager : IVisManager
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public IDM_Addin MenuStrip { get; set; }
        public IDM_Addin ToolStrip { get; set; }
        public IDM_Addin Tree { get; set; }
        public bool WaitFormShown { get; set;}=false;
        public IDM_Addin SecondaryTree { get; set; }
        public IDM_Addin SecondaryToolStrip { get ; set ; }
        public IDM_Addin SecondaryMenuStrip { get; set ; }
        public List<ObjectItem> objects { get; set; } = new List<ObjectItem>();
        public bool IsBeepDataOn { get; set; } = true;
        public bool IsAppOn { get; set; } = true;
        public int TreeIconSize { get; set; } = 32;
        public bool TreeExpand { get; set ; }=false;
        public int SecondaryTreeIconSize { get; set; } = 32;
        public bool SecondaryTreeExpand { get; set; }=false;
        public bool IsDevModeOn { get; set; } = false;
        public string AppObjectsName { get; set; }
        public string BeepObjectsName { get; set; }="Beep";
        public IVisHelper visHelper { get; set; }
        public IControlManager Controlmanager { get; set; }
        public ControlManager _controlManager { get { return (ControlManager)Controlmanager; } }
        public ErrorsInfo ErrorsandMesseges { get; set; }
        public IDM_Addin CurrentDisplayedAddin { get; set; }
        public bool IsDataModified { get; set; }
        bool _showLogWindow = true;
        bool _showTreeWindow = true;
        public bool ShowLogWindow { get => _showLogWindow; set { SetLogWindows(value); } }
        private void SetLogWindows(bool val)
        {
            IMainForm frm= (IMainForm)MainForm;
            frm.ShowLogWindow( val);
        }
        public bool ShowTreeWindow { get => _showTreeWindow; set { SetTreeWindow(value); } }
        private void SetTreeWindow(bool val)
        {
            IMainForm frm = (IMainForm)MainForm;
            frm.ShowTreeWindow(val);
        }
        public int Width { get; set; } = 1800;
        public int Height { get; set; } = 1000;
        public VisManager(IDMEEditor pdmeeditor)
        {
            IsDataModified = false;
            CurrentDisplayedAddin = null;
            DMEEditor = pdmeeditor;
            visHelper = new VisHelper(DMEEditor,this);

            Tree = new TreeControl(DMEEditor, this);
            ToolStrip = new ToolbarControl(DMEEditor, (TreeControl)Tree);
            MenuStrip = new MenuControl(DMEEditor, (TreeControl)Tree);

            SecondaryTree = new TreeControl(DMEEditor, this);
            SecondaryToolStrip = new ToolbarControl(DMEEditor, (TreeControl)SecondaryTree);
            SecondaryMenuStrip = new MenuControl(DMEEditor, (TreeControl)SecondaryTree);

            Controlmanager = new ControlManager(DMEEditor, this);
            wizardManager = new WizardManager(DMEEditor,this);
            if (DMEEditor.Passedarguments == null)
            {

                DMEEditor.Passedarguments = new PassedArgs();
                DMEEditor.Passedarguments.Objects = new List<ObjectItem>();

            }
            DMEEditor.Passedarguments.Objects = CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects);

            Images = new ImageList();
            Images.ColorDepth = ColorDepth.Depth32Bit;
            Images.ImageSize = new Size(20, 20);
            Images16 = new ImageList();
            Images16.ImageSize = new Size(16, 16);
            Images16.ColorDepth = ColorDepth.Depth32Bit;
            Images32 = new ImageList();
            Images32.ImageSize = new Size(32, 32);
            Images32.ColorDepth = ColorDepth.Depth32Bit;
            Images64 = new ImageList();
            Images64.ImageSize = new Size(64, 64);
            Images64.ColorDepth = ColorDepth.Depth32Bit;
            Images128 = new ImageList();
            Images128.ImageSize = new Size(128 ,128);
            Images128.ColorDepth = ColorDepth.Depth32Bit;
            Images256 = new ImageList();
            Images256.ImageSize = new Size(256, 256);
            Images256.ColorDepth = ColorDepth.Depth32Bit;
            List<string> paths = Directory.GetFiles(DMEEditor.ConfigEditor.Config.Folders.Where(x => x.FolderFilesType == FolderFileTypes.GFX).FirstOrDefault().FolderPath, "*.ico", SearchOption.AllDirectories).ToList();
            foreach (string filename_w_path in paths)
            {
                try
                {
                    string filename = Path.GetFileName(filename_w_path);
                    ImagesUrls.Add(new FileStorage() { FileName = filename, Url = filename_w_path });
                    Image im = Image.FromFile(filename_w_path);
                    if (im != null)
                    {
                        Images16.Images.Add(filename, im);
                        Images32.Images.Add(filename, im);
                        Images64.Images.Add(filename, im);
                        Images128.Images.Add(filename, im);
                        Images256.Images.Add(filename, im);
                        Images.Images.Add(filename, im);

                        //switch (im.Size.Height)
                        //{
                        //    case 16:
                        //        Images16.Images.Add(filename,im );
                        //        break;
                        //    case 32:
                        //        Images32.Images.Add(filename, im);
                        //        break;
                        //    case 64:
                        //        Images64.Images.Add(filename, im);
                        //        break;
                        //    case 128:
                        //        Images128.Images.Add(filename, im);
                        //        break;
                        //    case 256:
                        //        Images256.Images.Add(filename, im);
                        //        break;
                        //    default:
                        //        Images.Images.Add(filename, im);
                        //        break;
                        //}
                        ImagesUrls.Add(new FileStorage() { FileName = filename, Url = filename_w_path });
                    }
                   
                }
                catch (FileLoadException ex)
                {
                    DMEEditor.ErrorObject.Flag = Errors.Failed;
                    DMEEditor.ErrorObject.Ex = ex;
                    DMEEditor.Logger.WriteLog($"Error Loading icons ({ex.Message})");
                }
            }
            paths = Directory.GetFiles(DMEEditor.ConfigEditor.Config.Folders.Where(x => x.FolderFilesType == FolderFileTypes.GFX).FirstOrDefault().FolderPath, "*.png", SearchOption.AllDirectories).ToList();
            foreach (string filename_w_path in paths)
            {
                try
                {
                    string filename = Path.GetFileName(filename_w_path);
                    Images.Images.Add(filename, Image.FromFile(filename_w_path));
                    ImagesUrls.Add(new FileStorage() { FileName = filename, Url = filename_w_path });

                }
                catch (FileLoadException ex)
                {
                    DMEEditor.ErrorObject.Flag = Errors.Failed;
                    DMEEditor.ErrorObject.Ex = ex;
                    DMEEditor.Logger.WriteLog($"Error Loading icons ({ex.Message})");
                }
            }
        }
        #region "Winform Implemetation Properties"
        public ImageList Images { get; set; } = new ImageList();
        public ImageList Images16 { get; set; } = new ImageList();
        public ImageList Images32 { get; set; } = new ImageList();
        public ImageList Images64 { get; set; } = new ImageList();
        public ImageList Images128 { get; set; } = new ImageList();
        public ImageList Images256 { get; set; } = new ImageList();
        public List<IFileStorage> ImagesUrls { get; set; } = new List<IFileStorage>();
        BeepWait BeepWaitForm { get; set; }
        public IWaitForm WaitForm { get; set; }
        private Control _container;
        public Form MainForm { get; set; }
        IDisplayContainer container;
        public IDisplayContainer Container { get { return (IDisplayContainer)_container; } set { _container = (Control)value; _controlManager.DisplayPanel = (Control)value; } }
        #endregion
        public WizardManager wizardManager { get; set; }
        public bool IsShowingMainForm { get; set; } = false;
        IDM_Addin MainFormView;
        public IErrorsInfo LoadSetting()
        {
            try
            {
                ErrorsandMesseges.Flag = Errors.Ok;
                ErrorsandMesseges.Message = $"Function Executed";
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo SaveSetting()
        {
            try
            {
                ErrorsandMesseges.Flag = Errors.Ok;
                ErrorsandMesseges.Message = $"Function Executed";
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo CheckSystemEntryDataisSet()
        {
            ErrorsandMesseges.Flag = Errors.Ok;

            try
            {
                if (string.IsNullOrEmpty(DMEEditor.ConfigEditor.Config.SystemEntryFormName))
                {
                    ErrorsandMesseges.Flag = Errors.Failed;
                }
            }
            catch (System.Exception ex)
            {

                DMEEditor.AddLogMessage("Fail", $"Error check main System entry variables ({ex.Message})", DateTime.Now, 0, "", Errors.Failed);

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo ShowMainPage()
        {
            try
            {
                PassedArgs E=null;
                ErrorsandMesseges = new ErrorsInfo();
                ErrorsandMesseges = (ErrorsInfo)CheckSystemEntryDataisSet();
                if (ErrorsandMesseges.Flag == Errors.Ok)
                {
                    string[] args = { null, null, null };
                    if (DMEEditor.Passedarguments == null)
                    {
                        E = CreateDefaultArgsForVisUtil();
                    }   
                    else
                    {
                        DMEEditor.Passedarguments.Objects=CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects);
                        E = (PassedArgs)DMEEditor.Passedarguments;
                    }
                    MainFormView = ShowForm(DMEEditor.ConfigEditor.Config.SystemEntryFormName, DMEEditor, args, E);
                }
                ErrorsandMesseges.Flag = Errors.Ok;
                ErrorsandMesseges.Message = $"Function Executed";
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo ShowPage(string pagename, PassedArgs Passedarguments,DisplayType displayType= DisplayType.InControl)
        {
            try
            {
                ErrorsandMesseges = new ErrorsInfo();
                AddinAttribute attrib = new AddinAttribute();
               
                if (IsDataModified)
                {
                    if(Controlmanager.InputBoxYesNo("Beep","Module/Data not Saved, Do you want to continue?")== BeepEnterprize.Vis.Module.DialogResult.No)
                    {
                        return ErrorsandMesseges;
                    }
                 
                }
                CurrentDisplayedAddin = null;
                IsDataModified = false;
                if (DMEEditor.assemblyHandler.AddIns.Where(c => c.ObjectName.Equals(pagename, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Type type = DMEEditor.assemblyHandler.AddIns.Where(c => c.ObjectName.Equals(pagename, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().GetType();
                    attrib = (AddinAttribute)type.GetCustomAttribute(typeof(AddinAttribute), false);
                    if (attrib != null)
                    {
                        if (attrib.displayType == DisplayType.Popup)
                        {
                            displayType = DisplayType.Popup;
                        }
                        switch (attrib.addinType)
                        {
                            case AddinType.Form:
                                ShowForm(pagename, DMEEditor, new string[] { }, Passedarguments);
                                break;
                            case AddinType.Control:
                                if (displayType == DisplayType.InControl)
                                {
                                    ShowUserControlInContainer(pagename, DMEEditor, new string[] { }, Passedarguments);
                                }
                                else
                                {
                                    ShowUserControlPopUp(pagename, DMEEditor, new string[] { }, Passedarguments);
                                }
                                break;
                            case AddinType.Class:
                                RunAddinClass(pagename, DMEEditor, new string[] { }, Passedarguments);
                                break;
                            case AddinType.Page:
                                break;
                            case AddinType.Link:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        DMEEditor.AddLogMessage("Beep Vis", $"Could Find Attrib for Addin {pagename}", DateTime.Now, 0, pagename, Errors.Failed);
                }
                else
                    DMEEditor.AddLogMessage("Beep Vis", $"Could Find  Addin {pagename}", DateTime.Now, 0, pagename, Errors.Failed);
                ErrorsandMesseges.Flag = Errors.Ok;
                ErrorsandMesseges.Message = $"Function Executed";
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                DMEEditor.AddLogMessage("Beep Vis", $"Error in Getting Addin {pagename}", DateTime.Now, 0, pagename, Errors.Failed);

            }
            return ErrorsandMesseges;
        }
        #region "Misc"
        private List<ObjectItem> CreateArgsParameterForVisUtil(List<ObjectItem> e)
        {
            
            if (!e.Where(c => c.Name.Equals("VISUTIL",StringComparison.InvariantCultureIgnoreCase)).Any())
            {
                ObjectItem v = new ObjectItem { Name = "VISUTIL", obj = this };
                e.Add(v);
            }
          
            if (objects.Count > 0)
            {
                foreach (ObjectItem o in objects)
                {
                    if (!e.Where(c => c.Name.Equals(o.Name, StringComparison.InvariantCultureIgnoreCase)).Any())
                    {
                        ObjectItem v = new ObjectItem { Name = o.Name, obj = o.obj};
                        e.Add(v);
                    }
                }
                //IEnumerable<ObjectItem> diff = objects.Except<ObjectItem>(e);
                //if (diff.Any())
                //{
                //    foreach (ObjectItem item in diff)
                //    {
                //        e.Add(item);
                //    }
                   
                //}
            }
           
            return e;
        }
        private PassedArgs CreateDefaultArgsForVisUtil()
        {
            List<ObjectItem> items = new List<ObjectItem>(); ;
            items=CreateArgsParameterForVisUtil(items);

            PassedArgs E = new PassedArgs { Objects = items };
            return E;
        }
        #endregion
        #region "Show Control/Form in Winforms Method"
        //--------------- User Control Show methods
        public IDM_Addin ShowUserControlInContainer(string usercontrolname,  IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            // string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Addin\";
            if (DMEEditor.assemblyHandler.AddIns.Where(x => x.ObjectName.Equals(usercontrolname, StringComparison.OrdinalIgnoreCase)).Any())
            {
                return ShowUserControlDialogOnControl( usercontrolname, (Control)Container, pDMEEditor, args, e);
            }
            else
            {
                return null;
            }

        }
        public IDM_Addin ShowUserControlPopUp(string usercontrolname, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            if (DMEEditor.assemblyHandler.AddIns.Where(x => x.ObjectName.Equals(usercontrolname, StringComparison.OrdinalIgnoreCase)).Any())
            {
                string path = DMEEditor.assemblyHandler.AddIns.Where(x => x.ObjectName.Equals(usercontrolname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().DllPath;

                return ShowUserControlDialog(  usercontrolname, pDMEEditor, args, e);
            }
            else
            {
                return null;
            }

        }
        private IDM_Addin ShowUserControlDialog(  string formname, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            ErrorsandMesseges.Flag = Errors.Ok;
            BeepForm form = new BeepForm();
           // var path = Path.Combine(dllpath, dllname);
            IDM_Addin addin = null;
            if (e == null)
            {
                e = new PassedArgs();
            }
            try
            {
                // Assembly assembly = Assembly.LoadFile(path);
                //Type type = assembly.GetType(dllname + ".UserControls." + formname);
                Type type = DMEEditor.assemblyHandler.AddIns.Where(c => c.ObjectName.Equals(formname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().GetType();
                UserControl uc = (UserControl)Activator.CreateInstance(type);
                if (uc != null)
                {
                    addin = (IDM_Addin)uc;
                    if (e.Objects == null)
                    {
                        e.Objects = new List<ObjectItem>();
                    }
                    e.Objects.AddRange(CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects));
                    form.Text = addin.AddinName;
                    addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                    form.AddControl(uc,addin.AddinName);
                    form.Width = uc.Width + 70;
                    form.Height = uc.Height + 70;
                    uc.Dock = DockStyle.Fill;
                    CurrentDisplayedAddin = addin;
                    IsDataModified = false;
                    form.Title = addin.AddinName;
                    form.PreClose -= Form_PreClose;
                    form.PreClose += Form_PreClose;
                    form.Show();
                }
                else
                {
                    DMEEditor.AddLogMessage("Fail", $"Error Could not Show UserControl { uc.Name}", DateTime.Now, 0, "", Errors.Failed);
                }
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Fail", $"Error While Loading Assembly ({ex.Message})", DateTime.Now, 0, "", Errors.Failed);


            }
            return addin;
            //BeepWaitForm.GetType().GetField("")
        }
        public event EventHandler<FormClosingEventArgs> PreClose;
        private void Form_PreClose(object sender, FormClosingEventArgs e)
        {
            PreClose?.Invoke(this, e);
        }

        private IDM_Addin ShowUserControlDialogOnControl( string formname, Control control, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            
            ErrorsandMesseges.Flag = Errors.Ok;
            //Form BeepWaitForm = new Form();
            // var path = Path.Combine(dllpath, dllname);
            UserControl uc = new UserControl();
            IDM_Addin addin = null;
            if (e == null)
            {
                e = new PassedArgs();
            }
            try
            {
                //Assembly assembly = Assembly.LoadFile(path);
                //Type type = assembly.GetType(dllname + ".UserControls." + formname);
                Type type = DMEEditor.assemblyHandler.AddIns.Where(c => c.ObjectName.Equals(formname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().GetType(); //dllname.Remove(dllname.IndexOf(".")) + ".Forms." + formname
                AddinAttribute attrib = (AddinAttribute)type.GetCustomAttribute(typeof(AddinAttribute), false);
                if (attrib != null)
                {
                    if (attrib.addinType != AddinType.Class)
                    {
                        uc = (UserControl)Activator.CreateInstance(type);
                        if (uc != null)
                        {
                            addin = (IDM_Addin)uc;
                            if (e.Objects == null)
                            {
                                e.Objects = new List<ObjectItem>();
                                e.Objects=CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects);
                            }
                            else
                            {
                                e.Objects=CreateArgsParameterForVisUtil(e.Objects);
                            }
                           
                            addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                            CurrentDisplayedAddin = addin;
                            IsDataModified = false;
                            container = (IDisplayContainer)control;
                            string title = null;
                            if (e.Objects.Any(o => o.Name.Equals("TitleText", StringComparison.CurrentCultureIgnoreCase)))
                            {
                                ObjectItem x = e.Objects.First(o => o.Name.Equals("TitleText", StringComparison.CurrentCultureIgnoreCase));
                                title = (string)x.obj;
                                e.Objects.Remove(x);
                            }
                            else
                                title = addin.AddinName;
                            container.AddControl(title, uc, ContainerTypeEnum.TabbedPanel);
                            uc.Dock = DockStyle.Fill;

                        }
                        else
                        {

                            DMEEditor.AddLogMessage("Fail", $"Error Could not Show UserControl { uc.Name}", DateTime.Now, 0, "", Errors.Failed);
                        }
                    }
                    else
                    {
                        addin = (IDM_Addin)Activator.CreateInstance(type);
                        if (e.Objects == null)
                        {
                            e.Objects = new List<ObjectItem>();
                            e.Objects = CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects);
                        }
                        else
                        {
                            e.Objects = CreateArgsParameterForVisUtil(e.Objects);
                        }

                        addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                        CurrentDisplayedAddin = addin;
                        IsDataModified = false;
                        addin.Run(e);
                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Fail", $"Error While Loading Assembly ({ex.Message})", DateTime.Now, 0, "", Errors.Failed);
            }

            return addin;
        }
        //-----------------------------------------
        private IDM_Addin ShowForm(string formname, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            if (DMEEditor.assemblyHandler.AddIns.Where(x => x.ObjectName.Equals(formname, StringComparison.OrdinalIgnoreCase)).Any())
            {
                return ShowFormDialog( formname, pDMEEditor, args, e);
            }
            else
            {
                return null;
            }
        }
        private IDM_Addin ShowFormDialog( string formname, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            Form form = null;
            IDM_Addin addin = null;
            // var path = Path.Combine(dllpath, dllname);
            ErrorsandMesseges.Flag = Errors.Ok;
            if (e == null)
            {
                e = new PassedArgs();
            }
            try
            {
                // Assembly assembly = Assembly.LoadFile(path);
                Type type = DMEEditor.assemblyHandler.AddIns.Where(c => c.ObjectName.Equals(formname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().GetType(); //dllname.Remove(dllname.IndexOf(".")) + ".Forms." + formname
                form = (Form)Activator.CreateInstance(type);
                if (form != null)
                {
                    addin = (IDM_Addin)form;
                    if (e.Objects == null)
                    {
                        e.Objects = new List<ObjectItem>();
                        e.Objects = CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects);
                    }
                    else
                    {
                        e.Objects = CreateArgsParameterForVisUtil(e.Objects);
                    }
                    addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                    form.Text = addin.AddinName;
                    IsDataModified = false;
                    CurrentDisplayedAddin = addin;
                    form.ShowInTaskbar=true;
                    if (IsShowingMainForm)
                    {
                        if (!string.IsNullOrEmpty(Title))
                        {
                            form.Width = Width; form.Height=Height;
                            form.Text = Title;
                        }
                    }
                    if (!string.IsNullOrEmpty(IconUrl))
                    {
                        string Iconp = ImagesUrls.Where(p => p.FileName.Equals(IconUrl)).FirstOrDefault().Url;
                        form.Icon =new Icon(Iconp);
                    }
                   
                    form.ShowDialog();
                }
                else
                {
                    ErrorsandMesseges.Flag = Errors.Failed;
                    ErrorsandMesseges.Message = $"Error Could not Show Form { form.Name}";
                    DMEEditor.AddLogMessage("Fail", $"Error Could not Show Form { form.Name}", DateTime.Now, 0, "", Errors.Failed);
                };
            }
            catch (Exception ex)
            {
                DMEEditor.AddLogMessage("Fail", $"Error While Loading Assembly ({ex.Message})", DateTime.Now, 0, "", Errors.Failed);
            }
          
            return addin;
            //BeepWaitForm.GetType().GetField("")
        }
        //---------------- Run Class Addin -----------------
        private IDM_Addin RunAddinClass(string classname, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            IDM_Addin addin = null;
           
            ErrorsandMesseges.Flag = Errors.Ok;
          
            if (e == null)
            {
                e = new PassedArgs();
            }
            try
            {
                Type type = DMEEditor.assemblyHandler.AddIns.Where(c => c.ObjectName.Equals(classname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().GetType(); //dllname.Remove(dllname.IndexOf(".")) + ".Forms." + formname
                AddinAttribute attrib = (AddinAttribute)type.GetCustomAttribute(typeof(AddinAttribute), false);
                if (attrib != null)
                {
                    if (attrib.addinType == AddinType.Class)
                    {
                        addin = (IDM_Addin)Activator.CreateInstance(type);
                        if (e.Objects == null)
                        {
                            e.Objects = new List<ObjectItem>();
                            e.Objects = CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects);
                        }
                        else
                       
                        {
                            e.Objects = CreateArgsParameterForVisUtil(e.Objects);
                        }
                        addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                        CurrentDisplayedAddin = addin;
                        IsDataModified = false;
                        addin.Run(e);
                     
                    }
                }

            }
            catch (Exception ex)
            {
                CurrentDisplayedAddin = null;
                IsDataModified = false;
                DMEEditor.AddLogMessage("Fail", $"Error While Loading Assembly ({ex.Message})", DateTime.Now, 0, "", Errors.Failed);
            }

            return addin;
            //BeepWaitForm.GetType().GetField("")
        }
        //--------------------------------------------------

        #endregion
        #region "Wait Forms"
        delegate void SetTextCallback(Form f, TextBox ctrl, string text);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling BeepWaitForm</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(Form form, TextBox ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 

            //if (ctrl.InvokeRequired)
            //{
            //    SetTextCallback d = new SetTextCallback(SetText);
            //    BeepWaitForm.Invoke(d, new object[] { BeepWaitForm, ctrl, text });
            //}
            //else
            //{
              //  ctrl.Text = text;
                ctrl.BeginInvoke(new Action(() => {
                    ctrl.AppendText(text + Environment.NewLine);
                    ctrl.SelectionStart = ctrl.Text.Length;
                    ctrl.ScrollToCaret();
                }));
            //}
        }
        private async void startwait(PassedArgs Passedarguments)
        {
            string[] args = null;
            BeepWaitForm = (BeepWait)Application.OpenForms["BeepWait"];
            if (BeepWaitForm != null)
            {
                CloseWaitForm();
            }
            await Task.Run(() => {
                BeepWaitForm = new BeepWait();
                if (!string.IsNullOrEmpty(Title))
                {
                    BeepWaitForm.Title.Text = Title;
                }
                Debug.WriteLine($"Getting Logourl {LogoUrl}");
                if (!string.IsNullOrEmpty(LogoUrl))
                {
                    string logurl = ImagesUrls.Where(p => p.FileName.Equals(LogoUrl)).FirstOrDefault().Url;
                    Debug.WriteLine($"found or not = {logurl}");

                    BeepWaitForm.SetImage(logurl);
                }
                Debug.WriteLine($"not found logurl");
                BeepWaitForm.TopMost=true;
               // Form frm = (Form)MainFormView;
                BeepWaitForm.StartPosition = FormStartPosition.CenterScreen;
               // BeepWaitForm.Parent = frm;
                BeepWaitForm.ShowDialog();
   
            });
        }
        public IErrorsInfo ShowWaitForm(PassedArgs Passedarguments)
        {
            try
            {
                BeepWaitForm = (BeepWait)Application.OpenForms["BeepWait"];
                if (BeepWaitForm != null)
                {
                    CloseWaitForm();
                }

                ErrorsandMesseges = new ErrorsInfo();

                startwait(Passedarguments);
                WaitFormShown=true;
                while ((BeepWait)Application.OpenForms["BeepWait"] == null) Application.DoEvents();
                BeepWaitForm = (BeepWait)Application.OpenForms["BeepWait"];
              
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo PasstoWaitForm(PassedArgs Passedarguments)
        {
            try
            {

                ErrorsandMesseges = new ErrorsInfo();
                BeepWaitForm = (BeepWait)Application.OpenForms["BeepWait"];
                if (BeepWaitForm != null)
                {
                    SetText(BeepWaitForm, BeepWaitForm.messege, Passedarguments.ParameterString1);
                    WaitFormShown = true;
                }

            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo CloseWaitForm()
        {
            try
            {
                BeepWaitForm = (BeepWait)Application.OpenForms["BeepWait"];
                if (BeepWaitForm != null)
                {
                    if (BeepWaitForm.InvokeRequired)
                    {
                        BeepWaitForm.BeginInvoke((MethodInvoker)delegate () { BeepWaitForm.CloseForm(); });
                        WaitFormShown = false;
                    }
                    else
                    {
                        BeepWaitForm.BeginInvoke((MethodInvoker)delegate () { BeepWaitForm.CloseForm(); });
                        WaitFormShown = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;

            }
            return ErrorsandMesseges;
        }
        #endregion
        #region "Resource Loaders"
        public Image GetImage(string fullName)
        {
            Bitmap image = null;
            Stream stream;
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Is this just a single (ie. one-time) image?
            stream = assembly.GetManifestResourceStream(fullName);
            if (stream != null)
            {
               
                image = new Bitmap(stream);
                stream.Close();
                return image;
            }
            else
            {
                assembly = Assembly.GetCallingAssembly();
                stream = assembly.GetManifestResourceStream(fullName);
                if (stream != null)
                {
                    image = new Bitmap(stream);
                    stream.Close();
                    return image;
                }
            }
            return null;
        }
        public List<string> GetImageList(Assembly assembly)
        {
            System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            string resourceName = assembly.GetName().Name ;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourceName, assembly);
            System.Resources.ResourceSet resourceSet = rm.GetResourceSet(culture, true, true);
            List<string> resources = new List<string>();
            foreach (DictionaryEntry resource in resourceSet)
            {
                resources.Add((string)resource.Key);
            }
            rm.ReleaseAllResources();
            return resources;
        }
        #endregion
        public IErrorsInfo PrintGrid(IPassedArgs e)
        {
            try
            {
                ErrorsandMesseges = new ErrorsInfo();
               // List<ReportColumn> columns = new List<ReportColumn>();
                object obj = null;
                object obj2 = null;
                DataGridView dv = null;
                DataTable dt = new DataTable();
                //if (e.Objects.Where(c => c.Name == "ReportColumn").Any())
                //{
                //    columns = (List<ReportColumn>)e.Objects.FirstOrDefault(c => c.Name == "ReportColumn").obj;

                //}
                if (e.Objects.Where(c => c.Name == "DATA").Any())
                {
                    obj = (object)e.Objects.FirstOrDefault(c => c.Name == "DATA").obj;

                }
                if (e.Objects.Where(c => c.Name == "DataGridView").Any())
                {
                    obj2 = (object)e.Objects.FirstOrDefault(c => c.Name == "DataGridView").obj;

                }
                //var f = new ReportForm();
                //f.ReportColumns = columns;
                //f.ReportData = obj;
                //f.ShowDialog();
                //DataGrid grid = new DataGrid();
                 dv= (DataGridView)obj2;
                 dt = (DataTable)obj;
                DataGridPrinting pr = new DataGridPrinting(e.CurrentEntity, dv, dt);
                pr.Print();

                //PrintingSystem printingSystem = new PrintingSystem();
                //DataGridLink dgLink = new DataGridLink();
                //dgLink.DataGrid = grid;

                //printingSystem.Links.Add(dgLink);
                //dgLink.ShowPreviewDialog();

                ErrorsandMesseges.Flag = Errors.Ok;
                ErrorsandMesseges.Message = $"Function Executed";
            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;

            }
            return ErrorsandMesseges;
           
        }
        public IErrorsInfo CallAddinRun()
        {
            try
            {
                if (CurrentDisplayedAddin != null)
                {
                    CurrentDisplayedAddin.Run(DMEEditor.Passedarguments);
                }
            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Message = ex.Message;
                DMEEditor.ErrorObject.Flag = Errors.Failed;
            }

            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo CloseAddin()
        {
            try
            {
                if (CurrentDisplayedAddin != null)
                {
                    Form frm = (Form)CurrentDisplayedAddin;
                    frm.Close();
                }
            }
            catch (Exception ex)
            {
                DMEEditor.ErrorObject.Ex = ex;
                DMEEditor.ErrorObject.Message = ex.Message;
                DMEEditor.ErrorObject.Flag = Errors.Failed;
            }

            return DMEEditor.ErrorObject;
        }
    }
}
