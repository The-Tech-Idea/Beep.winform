using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TheTechIdea.Beep.AppModule;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder
{
    public class AppbuilderSaveandLoad
    {
        public AppbuilderSaveandLoad(IDMEEditor pDMEEditor)
        {
            DMEEditor = pDMEEditor;
        }
        public IDMEEditor DMEEditor { get; set; }
     
        public ScreenDesigner ScreenDesigner { get; set; }
        #region "Json"
        public void SaveDesignerProperties()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save Designer Session";
            saveFile.InitialDirectory = DMEEditor.ConfigEditor.Config.Folders.Where(o => o.FolderFilesType == FolderFileTypes.Reports).FirstOrDefault().FolderPath;
            saveFile.ShowDialog();
            if (string.IsNullOrEmpty(saveFile.FileName))
            {
                return;
            }
           
          
            foreach (PanelControl ctl in ScreenDesigner.Properties.Controls)
            {

                //    DMEEditor.ConfigEditor.JsonLoader.Serialize(Path.Combine(DMEEditor.ConfigEditor.Config.Folders.Where(o => o.FolderFilesType == FolderFileTypes.Reports).FirstOrDefault().FolderPath, ctl.Name), ctl);
                BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                Type type = ctl.BeepControl.GetType();
                PropertyInfo[] properties = type.GetProperties(flags);
              
                ctl.ControlsProperties.Clear();
                foreach (PropertyInfo prop in properties)
                {
                    try
                    {
                        var vl = prop.GetValue(ctl.BeepControl, null);
                        object ret = null;
                        if (vl != null)
                        {
                            ret = prop.GetValue(ctl.BeepControl, null);
                        }
                        if (ret != null)
                        {
                            if (!prop.Name.ToString().Equals("WindowTarget", StringComparison.InvariantCultureIgnoreCase) &&  !prop.Name.ToString().Equals("ImeMode", StringComparison.InvariantCultureIgnoreCase) && !prop.Name.ToString().Equals("AccessibleRole", StringComparison.InvariantCultureIgnoreCase) && prop.CanWrite && !prop.Name.Equals("Parent", StringComparison.InvariantCultureIgnoreCase) && !prop.Name.Equals("Controls", StringComparison.InvariantCultureIgnoreCase) && !prop.Name.Equals("ParentControl", StringComparison.InvariantCultureIgnoreCase) && !prop.Name.Equals("BindingContext", StringComparison.InvariantCultureIgnoreCase) && !prop.Name.Equals("WindowTarget", StringComparison.InvariantCultureIgnoreCase))
                            {
                                Console.WriteLine(ret.ToString() + '-' + prop.Name);
                                ctl.ControlsProperties.Add(new ControlsProperties() { Name = prop.Name, Type = prop.PropertyType.AssemblyQualifiedName, Value = ret });
                            }
                            if (prop.Name == "Name")
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        DMEEditor.AddLogMessage("Beep", $"Error in saveing Designer Properties  - {ex.Message}", DateTime.Now, 0, null, Errors.Failed);
                    }
                   
                }
            }
            DMEEditor.ConfigEditor.JsonLoader.Serialize( saveFile.FileName, ScreenDesigner.Properties);
        }
        private OpenFileDialog openFile = new OpenFileDialog();
        private Control CreateControl(PanelControl item)
        {
            
            string vsname = item.Name;
            Point location = new Point();
            var val = item.ControlsProperties.FirstOrDefault(p => p.Name.Equals("Location", StringComparison.InvariantCultureIgnoreCase)).Value;
            string[] vs = val.ToString().Split('\u002C');
            location = new Point(int.Parse(vs[0]), int.Parse(vs[1]));
            item.Left = location.X;
            item.Top = location.Y;
            IBeepControlInterface controlInterface = (IBeepControlInterface)item.AppComponent;
            controlInterface.DMEEditor = (DMEEditor)DMEEditor;
            controlInterface.ScreenDesigner = ScreenDesigner;
            controlInterface.Panelcontrol = item;
            item.BeepControl = ScreenDesigner.CreateGuiControl(item, item.Name, location);
            controlInterface.Init(DMEEditor.Passedarguments);
        //    controlInterface.ChangeVisual(DMEEditor.Passedarguments);
            return item.BeepControl;
        }
        private void DrawControls()
        {
            int cnt = ScreenDesigner.Properties.Controls.Count();
            for (int i = 0; i <cnt; i++)
            { 
                if(ScreenDesigner.Properties.Controls[i].ParentControl == null )
                {
                    
                    ScreenDesigner.Properties.Controls[i].BeepControl = CreateControl(ScreenDesigner.Properties.Controls[i]);
                }
               
            }
            for (int i = 0; i < cnt; i++)
            {
                PanelControl item = ScreenDesigner.Properties.Controls[i];
                if (ScreenDesigner.Properties.Controls[i].ParentControl != null)
                {
                    PanelControl ParentControl= ScreenDesigner.Properties.Controls[ScreenDesigner.Properties.Controls.FindIndex(o=>o.ID==ScreenDesigner.Properties.Controls[i].ParentControl.ID)];
                    IBeepControlInterface controlInterface = (IBeepControlInterface)ParentControl.AppComponent;
                    controlInterface.ChangeVisual(DMEEditor.Passedarguments);
                    
                }
            }
           
        }
        public void LoadDesignerProperties()
        {
            openFile = new OpenFileDialog();
            openFile.InitialDirectory = DMEEditor.ConfigEditor.Config.Folders.Where(o => o.FolderFilesType == FolderFileTypes.Reports).FirstOrDefault().FolderPath;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ScreenDesigner.Properties = new DesignerProperties();

                ScreenDesigner.Properties = DMEEditor.ConfigEditor.JsonLoader.DeserializeSingleObject<DesignerProperties>( openFile.FileName);
                if (ScreenDesigner.Properties != null)
                {
                    DrawControls();
                }
                SetPropertiesforControls();
            }
        }
        private void SetPropertiesforControls()
        {
            Type t = null;
            string properttypename = null;
            foreach (PanelControl panelControl in ScreenDesigner.Properties.Controls)
            {
                Control ctl = panelControl.BeepControl;
                BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                Type type = ctl.GetType();
                PropertyInfo[] properties = type.GetProperties(flags);
                foreach (PropertyInfo prop in properties)
                {
                    ControlsProperties ctlprop = panelControl.ControlsProperties.FirstOrDefault(p => p.Name.Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase));
                    if (ctlprop != null)
                    {
                        try
                        {
                            //   System.Windows.Forms.Appearance appearance = Appearance.Button;

                            t = prop.PropertyType;
                            properttypename = t.Name;
                            if (t != null)
                            {
                                if (t.IsEnum)
                                {
                                    ctlprop.Value = Enum.Parse(t, ctlprop.Value.ToString());
                                    prop.SetValue(ctl, ctlprop.Value, null);
                                }
                                else
                                {
                                    string[] vls;
                                    bool skip = false;
                                    switch (properttypename)
                                    {
                                        case "Cursor":
                                            try
                                            {
                                                ctlprop.Value = (System.Windows.Forms.Cursor)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {
                                                PropertyInfo[] cursorproperties = typeof(System.Windows.Forms.Cursors).GetProperties();
                                                PropertyInfo cursorprop = cursorproperties.Where(o => o.Name.Equals(ctlprop.Value.ToString(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                                                ctlprop.Value = cursorprop.GetValue(typeof(System.Windows.Forms.Cursors), null);
                                            }




                                            break;
                                        case "IWindowTarget":
                                        case "ControlNativeWindow-WindowTarget":
                                        case "System.Windows.Forms.BindingContext":
                                        case "ImeMode":
                                        case "BindingContext":
                                            
                                            skip = true;
                                            break;
                                        case "BackgroundImageLayout":
                                            ctlprop.Value = Enum.Parse(t, ctlprop.Value.ToString());
                                            break;
                                        case "Padding":
                                            Padding padding;

                                            try
                                            {
                                                ctlprop.Value = (Padding)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {
                                                vls = ctlprop.Value.ToString().Split(',');
                                                padding = new Padding(int.Parse(vls[0]), int.Parse(vls[1]), int.Parse(vls[2]), int.Parse(vls[3]));
                                                ctlprop.Value = padding;
                                            }


                                            break;
                                        case "Rectangle":
                                            Rectangle rectangle;

                                            try
                                            {
                                                ctlprop.Value = (Rectangle)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {
                                                vls = ctlprop.Value.ToString().Split(',');
                                                rectangle = new Rectangle(int.Parse(vls[0]), int.Parse(vls[1]), int.Parse(vls[2]), int.Parse(vls[3]));
                                                ctlprop.Value = rectangle;
                                            }




                                            break;

                                        case "Font":
                                            //Microsoft Sans Serif, 12pt, style=Bold, Underline, Strikeout,Regular

                                            try
                                            {
                                                ctlprop.Value = (Font)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {

                                                vls = ctlprop.Value.ToString().Split(',');
                                                FontStyle fontStyle = new FontStyle();
                                                if (vls.Length == 3)
                                                {
                                                    string[] style = vls[2].Split(',');
                                                    if (style.Contains("Italic "))
                                                    {
                                                        fontStyle = fontStyle | FontStyle.Italic;
                                                    }
                                                    if (style.Contains("Bold"))
                                                    {
                                                        fontStyle = fontStyle | FontStyle.Bold;
                                                    }
                                                    if (style.Contains("Underline"))
                                                    {
                                                        fontStyle = fontStyle | FontStyle.Underline;
                                                    }
                                                    if (style.Contains("Strikeout"))
                                                    {
                                                        fontStyle = fontStyle | FontStyle.Strikeout;
                                                    }
                                                    if (style.Contains("Regular"))
                                                    {
                                                        fontStyle = fontStyle | FontStyle.Regular;
                                                    }
                                                }
                                                string valpnt = vls[1].Substring(0, vls[1].IndexOf('p'));
                                                Font font = new Font(vls[0], float.Parse(valpnt), fontStyle);
                                                ctlprop.Value = font;
                                            }





                                            break;
                                        case "Color[]":

                                            //string colors = ctlprop.Value.ToString();
                                            //colors = colors.Remove(colors.Length - 1);
                                            //colors = colors.Remove(0, 1);
                                            //colors = Regex.Replace(colors, @"\s", "");
                                            //colors.Trim();
                                            //colors = colors.Replace("\\", "");
                                            //string[] colrs = colors.Split('"');

                                            //if (colrs.Length > 0)
                                            //{
                                            //    int cnt = colrs.Where(c => c.Length > 1).Count();
                                            //    Color[] colorsColors = new Color[cnt];
                                            //    int j = 0;
                                            //    for (int i = 0; i < colrs.Length; i++)
                                            //    {
                                            //        if (colrs[i].Length > 1)
                                            //        {
                                            //            if (colrs[i].Contains(","))
                                            //            {
                                            //                string[] rgbs = colrs[i].Split(',');
                                            //                colorsColors[j] = Color.FromArgb(int.Parse(rgbs[0]), int.Parse(rgbs[1]), int.Parse(rgbs[2]));
                                            //            }
                                            //            else
                                            //                colorsColors[j] = Color.FromName(colrs[i]);
                                            //            j++;
                                            //        }

                                            //    }
                                            //    ctlprop.Value = colorsColors;
                                            //}
                                            ctlprop.Value = (Color[])ctlprop.Value;
                                            break;
                                        case "Color":
                                            try
                                            {
                                                ctlprop.Value = (Color)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {

                                                ctlprop.Value = Color.FromName(ctlprop.Value.ToString());
                                            }

                                            break;
                                        case "Size":
                                            try
                                            {
                                                ctlprop.Value = (Size)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {

                                                Size size = new Size();
                                                vls = ctlprop.Value.ToString().Split(',');
                                                size.Width = int.Parse(vls[0]);
                                                size.Height = int.Parse(vls[1]);
                                                ctlprop.Value = size;
                                            }


                                            break;
                                        case "Point":


                                            try
                                            {
                                                ctlprop.Value = (Point)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {

                                                Point point = new Point();
                                                vls = ctlprop.Value.ToString().Split(',');
                                                point.X = int.Parse(vls[0]);
                                                point.Y = int.Parse(vls[1]);
                                                ctlprop.Value = point;
                                            }



                                            break;
                                        case "Height":
                                        case "Width":
                                        case "Left":
                                        case "Top":
                                        case "Int32":
                                            ctlprop.Value = Int32.Parse(ctlprop.Value.ToString());
                                            break;
                                        case "BorderSkin":

                                            try
                                            {
                                                ctlprop.Value = (BorderSkin)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {
                                                BorderSkin a = new BorderSkin();
                                                a = DMEEditor.ConfigEditor.JsonLoader.DeserializeSingleObjectFromjsonString<BorderSkin>(ctlprop.Value.ToString());
                                                ctlprop.Value = a;
                                            }


                                            break;
                                        case "AutoCompleteStringCollection":

                                            try
                                            {
                                                ctlprop.Value = (AutoCompleteStringCollection)ctlprop.Value;
                                            }
                                            catch (Exception)
                                            {
                                                AutoCompleteStringCollection a = new AutoCompleteStringCollection();
                                                a = DMEEditor.ConfigEditor.JsonLoader.DeserializeSingleObjectFromjsonString<AutoCompleteStringCollection>(ctlprop.Value.ToString());
                                                ctlprop.Value = a;
                                            }
                                            break;
                                    }
                                    if (!skip)
                                    {
                                        prop.SetValue(ctl, ctlprop.Value, null);
                                    }

                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            DMEEditor.AddLogMessage($"{prop.Name}_{properttypename}");
                        }

                    }
                }
            }
        }



        #endregion
    }
}
