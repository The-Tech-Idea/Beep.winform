using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.AppBuilder.Controls
{
    public class ContainerControl
    {
        public ContainerControl()
        {
          
          
        }

       

        public PanelControl Panelcontrol { get; set; }
        public Control Container { get; set; }
     
        static Size mouseOffset;
        static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        public DMEEditor DMEEditor { get; set; }
        public ScreenDesigner ScreenDesigner { get; set; }
        public ContextMenuStrip ControlMenu { get; set; } = new ContextMenuStrip();
        public IErrorsInfo Bind(IPassedArgs args)
        {
           // Container = (GroupBox)Panelcontrol.BeepControl;

            try
            {
                if (Container != null)
                {
                    if (args != null)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Change Visual  {args.CurrentEntity} {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
        public IErrorsInfo Remove(PanelControl control)
        {
            try
            {
                if (Container != null)
                {
                    if (control != null)
                    {
                        PanelControl p = ScreenDesigner.Properties.Controls[ScreenDesigner.Properties.Controls.FindIndex(o => o.ID == control.ID)];
                        draggables.Remove(p.BeepControl);
                        Container.Controls.Remove(p.BeepControl);
                        ScreenDesigner.Properties.Controls.Remove(p);
                    }
                }

            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Change Visual  {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
        public IErrorsInfo ChangeVisual(IPassedArgs args)
        {

            try
            {
                foreach (PanelControl item in ScreenDesigner.Properties.Controls)
                {
                    if (item != null)
                    {
                        if (item.ParentControl != null)
                        {
                            if (item.ParentControl.ID == Panelcontrol.ID)
                            {
                                Point screenCoords = new Point(item.Left, item.Top);
                                //Point controlRelatedCoords = gbox.PointToClient(screenCoords);
                                item.BeepControl = CreateGuiControl(item, item.Name, screenCoords);

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Changing Visual in Control {Panelcontrol.Name}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;
        }
        public IErrorsInfo Init(IPassedArgs args)
        {
            try
            {

               // Container = (GroupBox)Panelcontrol.BeepControl;
                Container.DragDrop += Gbox_DragDrop;
                Container.DragEnter += Gbox_DragEnter;
                Container.DragOver += Gbox_DragOver;
                Container.DragLeave += Gbox_DragLeave;
                Container.Click += Gbox_Click;
                Container.MouseUp += Gbox_MouseUp;
                Container.ControlRemoved += Gbox_ControlRemoved;
                Container.Width = 200;
                Container.AllowDrop = true;
                Container.Height = 200;
                ControlMenu= ScreenDesigner.SetupControlContextMenu( ControlMenu_Click);
                ControlMenu.Click += ControlMenu_Click;
                if (Container != null)
                {
                    if (args != null)
                    {
                        //if (string.IsNullOrEmpty(args.CurrentEntity))
                        //{
                        //    Container.Text = args.CurrentEntity;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error in Init {Panelcontrol.Name}", DateTime.Now, 0, null, Errors.Failed);
            }
            return DMEEditor.ErrorObject;

        }
        private void ControlMenu_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;
            draggables.Remove(ScreenDesigner.SelectedControl);
            Container.Controls.Remove(ScreenDesigner.SelectedControl);
            ScreenDesigner.Properties.Controls.Remove(ScreenDesigner.SelectedPanelControl);
        }
        private void Gbox_MouseUp(object sender, MouseEventArgs e)
        {
            draggables[(Control)sender] = false;
        }
        private void Gbox_Click(object sender, EventArgs e)
        {

        }
        private void Gbox_ControlRemoved(object sender, ControlEventArgs e)
        {
            Control control = e.Control;
            if (!draggables.ContainsKey(control))
            {  // return if control is not draggable
                return;
            }

            draggables.Remove(control);
            Container.Controls.Remove(control);
            ScreenDesigner.Properties.Controls.Remove(ScreenDesigner.Properties.Controls[ScreenDesigner.Properties.Controls.FindIndex(p => p.BeepControl == control)]);
        }
        private void Gbox_DragLeave(object sender, EventArgs e)
        {

        }
        private void Gbox_DragOver(object sender, DragEventArgs e)
        {
            Container.SendToBack();
        }
        private void Gbox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void Gbox_DragDrop(object sender, DragEventArgs e)
        {
            string controlname = e.Data.GetData(DataFormats.Text).ToString();
            Point screenCoords = new Point(e.X, e.Y);
            Point controlRelatedCoords = Container.PointToClient(screenCoords);
            try
            {
                ScreenDesigner.Properties.ControlCount += 1;
                PanelControl panelControl = ScreenDesigner.CreatePanelControl(controlname, controlRelatedCoords, Panelcontrol);

                panelControl.BeepControl = CreateGuiControl(panelControl, controlname + ScreenDesigner.Properties.ControlCount, controlRelatedCoords);
                IBeepControlInterface controlInterface = (IBeepControlInterface)panelControl.AppComponent;
                controlInterface.Init(DMEEditor.Passedarguments);
            }
            catch (Exception ex)
            {

                DMEEditor.AddLogMessage("Beep", $"Error Dragedd item {ex.Message}", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Failed);
            }


            DMEEditor.AddLogMessage("Beep", $"Dragedd item", DateTime.Now, 0, null, TheTechIdea.Util.Errors.Ok);
        }
        public Control CreateGuiControl(PanelControl panelControl, string controlname, Point controlRelatedCoords, string name = null)
        {

            Control control = null;
            if (name == null)
            {
                ScreenDesigner.Properties.ControlCount++;
            }
            control = (Control)DMEEditor.assemblyHandler.CreateInstanceFromString(panelControl.AppComponent.ComponentType);
            if (control != null)
            {
                control.Name = name == null ? controlname : name;
                panelControl.AppComponent.ComponentName = control.Name;
                panelControl.Name = control.Name;
                panelControl.BeepControl = control;

                try
                {
                    control.Text = controlname;
                }
                catch (Exception)
                {


                }

                control.Location = controlRelatedCoords;
                control.Width = 100;
                control.Height = 25;
                panelControl.Left = controlRelatedCoords.X;
                panelControl.Top = controlRelatedCoords.Y;
                control.ContextMenuStrip = ControlMenu;
                control.Click += MainPanelControls_Click;
                control.MouseDown += MainPanelControls_MouseDown;
                control.MouseUp += MainPanelControls_MouseUp;
                control.MouseMove += MainPanelControls_MouseMove;
                draggables.Add(control, false);
                Container.Controls.Add(control);
            }

            return control;

        }
        public void MainPanelControls_MouseMove(object sender, MouseEventArgs e)
        {
            // only if dragging is turned on
            if (draggables[(Control)sender] == true)
            {
                // calculations of control's new position
                Point newLocationOffset = e.Location - mouseOffset;
                int newx = ((Control)sender).Left + newLocationOffset.X;
                int newy = ((Control)sender).Top + newLocationOffset.Y;
                // if (ScreenDesigner.IsControlInBoundries(this, newx, newy, ((Control)sender).Width, ((Control)sender).Height))
                // {
                ((Control)sender).Left += newLocationOffset.X;
                ((Control)sender).Top += newLocationOffset.Y;
                // }

            }
        }
        public void MainPanelControls_MouseUp(object sender, MouseEventArgs e)
        {
            draggables[(Control)sender] = false;
        }
        public void MainPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            // turning on dragging
            draggables[(Control)sender] = true;
            Control control = (Control)sender;
            ScreenDesigner.SelectedControl = control;
            ScreenDesigner.SelectedPanelControl = ScreenDesigner.Properties.Controls[ScreenDesigner.Properties.Controls.FindIndex(o => o.BeepControl == control)];
           
        }
        public void MainPanelControls_Click(object sender, EventArgs e)
        {
            ScreenDesigner.SelectedControl = sender as Control;
            if (ScreenDesigner.SelectedControl != null)
            {
                ScreenDesigner.propertyGrid1.SelectedObject = ScreenDesigner.SelectedControl;
            }

        }
       
    }
}
