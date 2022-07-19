using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beep.Winform.Controls;
using BeepEnterprize.Vis.Module;
using TheTechIdea;
using TheTechIdea.Beep;

namespace BeepEnterprize.Winform.Vis.Wizards
{
    public class WizardManager : IWizardManager
    {
        public event EventHandler<NodeChangeEventHandler> WizardCloseEvent;
        public event EventHandler<NodeChangeEventHandler> WizardNextNodeEvent;
        public event EventHandler<NodeChangeEventHandler> WizardPreviousNodeEvent;
        public event EventHandler<NodeChangeEventHandler> WizardNodeChangeEvent;
        public WizardManager(IDMEEditor pDMEEditor, IVisManager pvisManager)
        {
            State = new WizardState(this);
            Nodes = new LinkedList<IWizardNode>();
            DMEEditor = pDMEEditor;
            visManager = (VisManager)pvisManager;
            WizardParentForm = new BeepForm();
            ColorsTemplate=new ColorTemplate();
            ColorsTemplate.ForColor = Color.White;
            ColorsTemplate.BackColor = Color.SteelBlue;
            //Title = ptitle;
            //Description = pDescription;
        }
        public string Title { get;set;}
        public string Description { get;set;}
        public VisManager visManager { get; set; }
        public IDMEEditor DMEEditor { get; set; }
        public int StartLeft { get; set; } = 3;
        public int StartTop { get; set; } = 70;
        public int Height { get; set; } = 25;
        private int _SelectedIndex =-1;
        public int SelectedIndex { get { return _SelectedIndex; } }
        private int _CurrentIdx =-1;
        public int CurrentIdx { get { return _CurrentIdx; }  } 
        public int Count { get { return Nodes.Count; } } 
     
        public bool Cancel { get; set; }=false;
        public LinkedList<IWizardNode> Nodes { get; set; } 
        public WizardState State { get; set; }
        public ColorTemplate ColorsTemplate { get; set; }=new ColorTemplate();
        public IWizardNode entryform {
            get {
                if (Nodes != null)
                {
                    return Nodes.First();
                }
                else
                    return null;
                ;
            }
        }
        public IWizardNode lastform {
            get {
                if (Nodes != null)
                {
                    return Nodes.Last();
                }
                else
                    return null;
                ;
            }
        }
        public ControlManager controlManager { get;set; }
      
        private void ShowWizardNode(int idx)
        {
            WizardNode node = (WizardNode)GetNode(idx);
            node.IsActive = true;
          //  IWizardNode curnode = GetNode(idx);
            var e = new NodeChangeEventHandler() { CurrentNode = node, ToNode = null };
            WizardNodeChangeEvent?.Invoke(this, e);
            if (!e.Cancel)
            {
                IDM_Addin addin = (IDM_Addin)node.Addin;
                Control ctl = (Control)node.Addin;
                DMEEditor.ErrorObject.Flag = TheTechIdea.Util.Errors.Ok;
                addin.Run(DMEEditor.Passedarguments);
                if (DMEEditor.ErrorObject.Flag == TheTechIdea.Util.Errors.Ok)
                {
                    DisplayPanel.Controls.Clear();
                    DisplayPanel.Controls.Add(ctl);
                    // DisplayPanel.SendToBack();
                    ctl.Dock = DockStyle.Fill;
                    addin.Run(DMEEditor.Passedarguments);
                }
                LeaveButtons(node);
                _SelectedIndex = node.Index;
                HilightPanel.Top = node.Wizardbutton.Top;
            }
         }
        public void MoveNext()
        {
            if (Nodes.Count > 0)
            {
                if (_SelectedIndex != Nodes.Last.Value.Index)
                {
                   
                    IWizardNode curnode = GetNode(_SelectedIndex);
                    IWizardNode retval = GetNextNode(_SelectedIndex);
                    var e = new NodeChangeEventHandler() { CurrentNode = curnode, ToNode = retval };
                    WizardNodeChangeEvent?.Invoke(this,e) ;
                    if (!e.Cancel)
                    {
                        if (retval != null)
                        {
                            curnode.IsActive = false;
                            _SelectedIndex = retval.Index;
                            ShowWizardNode(_SelectedIndex);
                        }
                    }
                    

                }
            }

        }
        public void MovePrevious()
        {
            if (Nodes.Count > 0)
            {
                if (_SelectedIndex != Nodes.First.Value.Index)
                {
                    IWizardNode curnode = GetNode(_SelectedIndex);
                    IWizardNode retval = GetPreviousNode(_SelectedIndex);
                    var e = new NodeChangeEventHandler() { CurrentNode = curnode, ToNode = retval };
                    WizardNodeChangeEvent?.Invoke(this, e);
                    if (!e.Cancel)
                    {
                        if (retval != null)
                        {
                            _SelectedIndex = retval.Index;
                            ShowWizardNode(_SelectedIndex);
                        }
                    }
                      

                }
            }
        }
        public int AddNode(IWizardNode node)
        {
            try
            {
                _CurrentIdx += 1;
                node.Index = CurrentIdx;
                SetColorTemplateForNode(node);
                node.WizardNodeClickEvent += Node_WizardNodeClick;
                node.WizardNodeEnterEvent += Node_WizardNodeEnterEvent;
                LinkedListNode<IWizardNode> linkedListNode = new LinkedListNode<IWizardNode>(node);
                Nodes.AddLast(linkedListNode);
                WizardButton b = (WizardButton)node.Wizardbutton;
                SidePanel.Controls.Add(b.button);
                return CurrentIdx;
            }
            catch (Exception )
            {

              return -1;
            }
          
        }
        public int AddNode(IDM_Addin addin,string title, string text)
        {
            try
            {
                _CurrentIdx += 1;
                int top = StartTop + (CurrentIdx * (Height + 10));
                IWizardNode node =new WizardNode(addin, title,  text, CurrentIdx, StartLeft, top, SidePanel.Width-(StartLeft*2), Height,  ColorsTemplate.ForColor, ColorsTemplate.BackColor);
                SetColorTemplateForNode(node);
                node.WizardNodeClickEvent += Node_WizardNodeClick;
                node.WizardNodeEnterEvent += Node_WizardNodeEnterEvent;
                LinkedListNode<IWizardNode> linkedListNode = new LinkedListNode<IWizardNode>(node);
                Nodes.AddLast(linkedListNode);
                WizardButton b = (WizardButton)node.Wizardbutton;
                SidePanel.Controls.Add(b.button);
                Nodes.AddLast(linkedListNode);
                
                return CurrentIdx;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public int AddNode(IDM_Addin addin,string title, string text,  Color forcolor, Color backcolor)
        {
            try
            {
                _CurrentIdx += 1;
                int top = StartTop + (CurrentIdx * (Height + 10));
                IWizardNode node = new WizardNode(addin, title, text, CurrentIdx, StartLeft, top, SidePanel.Width - (StartLeft * 2), Height, forcolor, backcolor);
                SetColorTemplateForNode(node);
                node.WizardNodeClickEvent += Node_WizardNodeClick;
                node.WizardNodeEnterEvent += Node_WizardNodeEnterEvent;
                LinkedListNode<IWizardNode> linkedListNode = new LinkedListNode<IWizardNode>(node);
                Nodes.AddLast(linkedListNode);
                WizardButton b = (WizardButton)node.Wizardbutton;
                SidePanel.Controls.Add(b.button);
                return CurrentIdx;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        private void Node_WizardNodeClick(object sender, IWizardNode e)
        {
            if (Nodes.Count > 0)
            {
                   if (e != null)
                    {
                        _SelectedIndex = e.Index;
                        ShowWizardNode(_SelectedIndex);
                    }

               
            }
        }
        private void Node_WizardNodeEnterEvent(object sender, IWizardNode e)
        {
           //   LeaveButtons(e);
        }
        public int RemoveNode(IWizardNode node)
        {
            try
            {
                int retval = node.Index;
                
                Nodes.Remove(node);
                
                return retval;
            }
            catch (Exception )
            {

                return -1;
            }
           
        }
        public int RemoveNode(int nodeindex)
        {
            try
            {
                IWizardNode node = Nodes.Where(p=>p.Index==nodeindex).FirstOrDefault();
                if (node != null)
                {
                    Nodes.Remove(node);
                    return nodeindex;
                }else
                    return -2;


            }
            catch (Exception)
            {

                return -1;
            }

        }
        private void SetColorTemplateForNode(IWizardNode node)
        {
            if (node != null)
            {
                node.Wizardbutton.BackColor = ColorsTemplate.BackColor;
                node.Wizardbutton.ForColor = ColorsTemplate.ForColor;
                node.Wizardbutton.HiBackColor = ColorsTemplate.HiBackColor;
                node.Wizardbutton.HiForColor = ColorsTemplate.HiForColor;
                node.Wizardbutton.HoverBackColor = ColorsTemplate.HoverBackColor;
                node.Wizardbutton.HoverForColor = ColorsTemplate.HoverForColor;

            }
        }
        private IWizardNode GetNode(int idx)
        {
            return Nodes.FirstOrDefault(p=>p.Index==idx);
        }
        private IWizardNode GetNextNode(int idx)
        {
            LinkedListNode<IWizardNode> linkedListNode = Nodes.Find(GetNode(idx));
            if (linkedListNode != null)
            {
                return linkedListNode.Next.Value;
            }
            else
                return null;

        }
        private IWizardNode GetPreviousNode(int idx)
            {
                LinkedListNode<IWizardNode> linkedListNode = Nodes.Find(GetNode(idx));
                if (linkedListNode != null)
                {
                    return linkedListNode.Previous.Value;
                }
                else
                    return null;

            }
        private void LeaveButtons(IWizardNode e)
        {
            if (Nodes.Count > 0)
            {
                if (_SelectedIndex != -1)
                {
                   
                    if (e != null)
                    {
                        foreach (IWizardNode node in Nodes)
                        {
                            if (node.Index != e.Index)
                            {
                                node.LeaveButton();
                            }
                        }
                    }

                }
            }
        }
      
        #region "Winforms Controls and Drawings"
        private Panel FooterPanel=new Panel();
        private Panel SidePanel=new Panel();
        private Button NextButton=new Button();
        private Button PreviousButton=new Button();
        private Button HomeNavButton = new Button();
        private Button ExitButton = new Button();
        private Panel DisplayPanel = new Panel();
        private BeepForm WizardParentForm;
       
        private Label TitleLabel = new Label();
        private Label DescriptionLabel = new Label();
        private Panel HilightPanel = new Panel();

        public void InitWizardForm()
        {
            WizardParentForm=new BeepForm();
            FooterPanel = new Panel();
            SidePanel = new Panel();
            NextButton = new Button();
            PreviousButton = new Button();
            HomeNavButton = new Button();
            DisplayPanel = new Panel();
            TitleLabel = new Label();
            ExitButton=new Button();
            HilightPanel=new Panel();

            DescriptionLabel = new Label();
            WizardParentForm.Width = 1200;
            WizardParentForm.Height = 800;
            StartLeft  = 3;
            StartTop = 70;
            _CurrentIdx = -1;
            _SelectedIndex = -1;
            WizardParentForm.Controls.Clear();
            this.SidePanel.BackColor = ColorsTemplate.PanelAltBackColor;
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(183, 634);
            this.SidePanel.TabIndex = 0;
            
            WizardParentForm.Controls.Add(this.SidePanel);
            // 
            // footerpanel
            // 
            this.FooterPanel.BackColor = ColorsTemplate.PanelBackColor;
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(183, 586);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(695, 48);
            this.FooterPanel.TabIndex = 1;
            WizardParentForm.Controls.Add(this.FooterPanel);

            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayPanel.Location = new System.Drawing.Point(183, 0);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(695, 586);
            this.DisplayPanel.TabIndex = 2;
            this.DisplayPanel.BackColor = Color.White;
           

            WizardParentForm.Controls.Add(this.DisplayPanel);
          
            this.NextButton.BackColor = ColorsTemplate.BackColor;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.ForeColor = ColorsTemplate.ForColor;
            this.NextButton.Location = new System.Drawing.Point(497, 11);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(90, 25);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click -= NextButton_Click;
            this.NextButton.Click += NextButton_Click;
            FooterPanel.Controls.Add(this.NextButton);
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackColor = ColorsTemplate.BackColor;
            this.PreviousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousButton.ForeColor = ColorsTemplate.ForColor;
            this.PreviousButton.Location = new System.Drawing.Point(401, 11);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(90, 25);
            this.PreviousButton.TabIndex = 0;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = false;
            this.PreviousButton.Click -= PreviousButton_Click;
            this.PreviousButton.Click += PreviousButton_Click;
            FooterPanel.Controls.Add(this.PreviousButton);

            this.ExitButton.BackColor = ColorsTemplate.BackColor;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = ColorsTemplate.ForColor;
            this.ExitButton.Location = new System.Drawing.Point(StartLeft, SidePanel.Height-30);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(SidePanel.Width - (StartLeft * 2), 25);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Save";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += ExitButton_Click;
            SidePanel.Controls.Add(this.ExitButton);

            HilightPanel.BackColor = ColorsTemplate.HiBackColor;
            HilightPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            HilightPanel.Location = new System.Drawing.Point(StartLeft-5, SidePanel.Height - 30);
            HilightPanel.Name = "HilightPanel";
            HilightPanel.Size = new System.Drawing.Size(5, 25);
            HilightPanel.TabIndex = 0;
            SidePanel.Controls.Add(HilightPanel);



            TitleLabel.Text = Title;
            TitleLabel.AutoSize = false;
            TitleLabel.Left = StartLeft;
            TitleLabel.Width = SidePanel.Width - 6;
            TitleLabel.Top = 10;
            TitleLabel.Font = new Font("Arial" ,12, FontStyle.Bold);
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            TitleLabel.ForeColor = ColorsTemplate.ForColor;
            DescriptionLabel.Text = Description;
            DescriptionLabel.AutoSize = false;
            DescriptionLabel.Left = StartLeft;
            DescriptionLabel.Width = SidePanel.Width - 6;
            DescriptionLabel.Height=
            DescriptionLabel.Top = TitleLabel.Height+12;
            DescriptionLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            DescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            DescriptionLabel.ForeColor = ColorsTemplate.ForColor;
            SidePanel.Controls.Add(TitleLabel);
            SidePanel.Controls.Add(DescriptionLabel);
            this.DisplayPanel.BringToFront();
            this.SidePanel.SendToBack();
            WizardParentForm.Text = "Import Data Wizard";
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            MoveNext();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Show()
        {
            if (WizardParentForm != null)
            {
                WizardParentForm.Show();
                ShowWizardNode(0);
            }
            

        }
        public void Hide()
        {
            if (WizardParentForm != null)
            {
                WizardParentForm.Hide();
            }
            

        }
        private void Close()
        {
            NodeChangeEventHandler nodeChangeEventHandler = new NodeChangeEventHandler() { Cancel = false };
            WizardCloseEvent?.Invoke(this, nodeChangeEventHandler);
            if (!nodeChangeEventHandler.Cancel)
            {
                WizardParentForm.Close();
            }
         
        }

        public class NodeChangeEventHandler
        {
            public NodeChangeEventHandler()
            {

            }
            public IWizardNode CurrentNode { get;set; }
            public IWizardNode ToNode { get; set; }
            public bool Cancel { get; set; }=false;
        }
        #endregion
    }
}
