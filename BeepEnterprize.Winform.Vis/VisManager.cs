using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        
        public IDMEEditor DMEEditor { get; set; }
        public IDM_Addin MenuStrip { get; set; }
        public IDM_Addin ToolStrip { get; set; }
        public IDM_Addin Tree { get; set; }
        public bool WaitFormShown { get; set;}=false;
        public IDM_Addin SecondaryTree { get; set; }
        public IDM_Addin SecondaryToolStrip { get ; set ; }
        public IDM_Addin SecondaryMenuStrip { get; set ; }

        public List<ObjectItem> objects { get; set; } = new List<ObjectItem>();
       
        public IVisHelper visHelper { get; set; }
        public IControlManager Controlmanager { get; set; }
        public ControlManager _controlManager { get { return (ControlManager)Controlmanager; } }
        public ErrorsInfo ErrorsandMesseges { get; set; }
        public VisManager(IDMEEditor pdmeeditor)
        {
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
        }
        #region "Winform Implemetation Properties"
        public ImageList Images { get; set; } = new ImageList();
        private Control _container;
        public Control Container { get { return _container; } set { _container =value; _controlManager.DisplayPanel = value; } }
        #endregion
        public WizardManager wizardManager { get; set; }
        IDM_Addin MainFormView;
        public IErrorsInfo loadpalette()
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
        public IErrorsInfo savepalette()
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
                            DMEEditor.Passedarguments.Objects.AddRange(CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects));
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
            
            if (!e.Where(c => c.Name == "VISUTIL").Any())
            {
                ObjectItem v = new ObjectItem { Name = "VISUTIL", obj = (IVisManager)this };
                e.Add(v);
            }
          
            if (objects.Count > 0)
            {
                IEnumerable<ObjectItem> diff = objects.Except<ObjectItem>(e);
                if (diff.Any())
                {
                    foreach (ObjectItem item in diff)
                    {
                        e.Add(item);
                    }
                   
                }
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
                return ShowUserControlDialogOnControl( usercontrolname, Container, pDMEEditor, args, e);
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
                   // form.FormBorderStyle = FormBorderStyle.None;
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
            //form.GetType().GetField("")
        }
        public event EventHandler<FormClosingEventArgs> PreClose;
        private void Form_PreClose(object sender, FormClosingEventArgs e)
        {
            PreClose?.Invoke(this, e);
        }

        private IDM_Addin ShowUserControlDialogOnControl( string formname, Control control, IDMEEditor pDMEEditor, string[] args, IPassedArgs e)
        {
            control.Controls.Clear();
            ErrorsandMesseges.Flag = Errors.Ok;
            //Form form = new Form();
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
                            }
                            e.Objects.AddRange(CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects));
                            addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                            uc_Container container = (uc_Container)control;
                            container.AddControl(addin.AddinName, uc, ContainerTypeEnum.SinglePanel);
                          //  control.Controls.Clear();
                           // control.Controls.Add(uc);

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
                        }
                        e.Objects.AddRange(CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects));
                        addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
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
                    }
                    e.Objects.AddRange(CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects));
                    addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                    form.Text = addin.AddinName;
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
            //form.GetType().GetField("")
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
                        }
                        e.Objects.AddRange(CreateArgsParameterForVisUtil(DMEEditor.Passedarguments.Objects));
                        addin.SetConfig(pDMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, e, ErrorsandMesseges);
                        addin.Run(e);
                        addin = null;
                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Fail", $"Error While Loading Assembly ({ex.Message})", DateTime.Now, 0, "", Errors.Failed);
            }

            return addin;
            //form.GetType().GetField("")
        }
        //--------------------------------------------------

        #endregion
        #region "Wait Forms"
        BeepWait form;
        
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 

            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
        private async void startwait(PassedArgs Passedarguments)
        {
            string[] args = null;
            form = (BeepWait)Application.OpenForms["BeepWait"];
            if (form != null)
            {
                CloseWaitForm();
            }
            await Task.Run(() => {
                form = new BeepWait();
                //form.SetConfig(DMEEditor, DMEEditor.Logger, DMEEditor.Utilfunction, args, Passedarguments, ErrorsandMesseges);
                //form.Run(Passedarguments);
                form.TopMost=true;
               // Form frm = (Form)MainFormView;
                form.StartPosition = FormStartPosition.CenterScreen;
               // form.Parent = frm;
                form.ShowDialog();
   
            }).ConfigureAwait(true);
        }
        public IErrorsInfo ShowWaitForm(PassedArgs Passedarguments)
        {
            try
            {
                
                ErrorsandMesseges = new ErrorsInfo();
                startwait(Passedarguments);
                WaitFormShown=true;
                while ((BeepWait)Application.OpenForms["BeepWait"] == null) Application.DoEvents();
                form = (BeepWait)Application.OpenForms["BeepWait"];

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
                form = (BeepWait)Application.OpenForms["BeepWait"];
                if (form != null)
                {
                    SetText(form, form.messege, Passedarguments.ParameterString1);
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
                form = (BeepWait)Application.OpenForms["BeepWait"];
                if (form != null)
                {
                    if (form.InvokeRequired)
                    {
                        form.BeginInvoke((MethodInvoker)delegate () { form.CloseForm(); });
                        WaitFormShown = false;
                    }
                    else
                    {
                        form.Close();//Fault tolerance this code should never be executed
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
            }else
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

       

    }
}
