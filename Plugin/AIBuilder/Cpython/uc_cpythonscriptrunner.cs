using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTechIdea;
using TheTechIdea.Beep;
using TheTechIdea.Beep.DataBase;
using TheTechIdea.Beep.Vis;
using TheTechIdea.Logger;
using TheTechIdea.Util;
using Microsoft.Scripting.Hosting;
using System.IO;
using AI;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using BeepEnterprize.Vis.Module;
using ScintillaNET;
using TheTechIdea.Beep.AIBuilder.Cpython;
using BeepEnterprize.Winform.Vis;

namespace AIBuilder.Cpython
{
    [AddinAttribute(Caption = "CPython Editor", Name = "uc_cpythonscriptrunner", misc = "AI",addinType = AddinType.Control)]
    public partial class uc_cpythonscriptrunner : UserControl,IDM_Addin
	{
		public uc_cpythonscriptrunner()
		{
			InitializeComponent();
		}
		public string ParentName { get; set; }
		public string AddinName { get; set; } = "Iron Python";
		public string Description { get; set; } = "Iron Python";
		public string ObjectName { get; set; }
		public string ObjectType { get; set; } = "UserControl";
		public Boolean DefaultCreate { get; set; } = true;
		public string DllPath { get; set; }
		public string DllName { get; set; }
		public string NameSpace { get; set; }
		public DataSet Dset { get; set; }
		public IErrorsInfo ErrorObject { get; set; }
		public IDMLogger Logger { get; set; }
		public IDMEEditor DMEEditor { get; set; }
		public EntityStructure EntityStructure { get; set; }
		public string EntityName { get; set; }
		public IPassedArgs Passedarg { get; set; }
	//	public PythonHandler Python { get; set; }
        public CPythonManager CPythonManager { get; set; }
		public IVisManager Visutil { get; set; }
        VisManager visManager;
	
		IBranch RootAppBranch;
		IBranch branch;

     


        BindingSource griddatasource = new BindingSource();
		
         
		public void Run(IPassedArgs Passedarg)
		{
			
		}

		public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
		{
			Passedarg = e;
			Logger = plogger;
			ErrorObject = per;
			DMEEditor = pbl;
			//Python = new PythonHandler(pbl,TextArea,OutputtextBox, griddatasource);
			griddatasource.DataSourceChanged += Griddatasource_DataSourceChanged;
            Visutil = (IVisManager)e.Objects.Where(c => c.Name == "VISUTIL").FirstOrDefault().obj;
            visManager = (VisManager)Visutil;
            if (e.Objects.Where(c => c.Name == "Branch").Any())
			{
				branch = (IBranch)e.Objects.Where(c => c.Name == "Branch").FirstOrDefault().obj;
			}
			if (e.Objects.Where(c => c.Name == "RootAppBranch").Any())
			{
				RootAppBranch = (IBranch)e.Objects.Where(c => c.Name == "RootAppBranch").FirstOrDefault().obj;
			}
	   
			//  Console.SetOut(TextWriter.Synchronized(BoxWriter));
			try
			{

				//scripttextBox1.Multiline = true;
				//scripttextBox1.WordWrap = false;
				//scripttextBox1.AcceptsTab = true;
				//scripttextBox1.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
				//scripttextBox1.Dock = DockStyle.Fill;
				//scripttextBox1.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
				//scripttextBox1.SelectionColor = Color.Black;

			}
			catch (Exception rr)
			{


			}
			//foreach (string cnname in Python.GetLocalDB())
			//{
			//	this.LocalDBcomboBox.Items.Add(cnname);
			//}
			//  this.Disposed += Uc_cpythonscriptrunner_Disposed;
			this.loadToolStripMenuItem.Click += LoadFilebutton_Click;
			 this.saveToolStripMenuItem.Click += SaveFilebutton_Click;
			 this.runToolStripMenuItem.Click += RunScriptbutton_Click;
			 this.Runbutton.Click += RunScriptbutton_Click;
			 this.Savebutton.Click += SavefilepictureBox_Click;
			 this.SaveAsbutton.Click += SaveFilebutton_Click;
			 this.LoadScriptbutton.Click += LoadFilebutton_Click;
			 this.Jupiterbutton.Click += Jupiterbutton_Click;
			//this.tmpfilepathbutton.Click += Tmpfilepathbutton_Click;
			this.Insertlocaldbpathbutton.Click += Insertlocaldbpathbutton_Click;
            this.QtConsolebutton.Click += QtConsolebutton_Click;
			OutputdataGridView.DataSource = griddatasource;

            //         LoadScriptbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "load64.png");
            //         Savebutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "save64.png");
            //         SaveAsbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "saveas64.png");
            //         Jupiterbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "jupyter64.png");
            //         QtConsolebutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "qt64.png");
            //         Runbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "run64.png");
            //         Clearoutputbutton.BackgroundImage = Python.resourceManager.GetImage("AIBuilder.gfx.", "clear.png");
            //         Clearoutputbutton.Click += Clearoutputbutton_Click;
            //         LoadScriptbutton.MouseHover += AllButtons_MouseHover;
            //         Savebutton.MouseHover += AllButtons_MouseHover;
            //         SaveAsbutton.MouseHover += AllButtons_MouseHover;
            //         Jupiterbutton.MouseHover += AllButtons_MouseHover;
            //         QtConsolebutton.MouseHover += AllButtons_MouseHover;
            //         Runbutton.MouseHover += AllButtons_MouseHover;

            //         loadToolStripMenuItem.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "load.ico");
            //         saveToolStripMenuItem.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "saveas.ico");
            //         runToolStripMenuItem.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "run.ico");
            //         Python.SetupPipMenu(packagesToolStripMenuItem);
            //         if (Python.checkifpackageinstalled("pythonnet"))
            //         {
            //	Python.InstallPythonNet();

            //}
            CPythonManager = new CPythonManager(DMEEditor, DMEEditor.ConfigEditor.JsonLoader);
            CPythonManager.SendMessege += CPythonManager_SendMessege;
            LoadScriptbutton.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "load64.png");
            Savebutton.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "save64.png");
            SaveAsbutton.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "saveas64.png");
            Jupiterbutton.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "jupyter64.png");
            QtConsolebutton.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "qt64.png");
            Runbutton.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "run64.png");
            Clearoutputbutton.BackgroundImage = CPythonManager.resourceManager.GetImage("AIBuilder.gfx.", "clear.png");
            Clearoutputbutton.Click += Clearoutputbutton_Click;
            LoadScriptbutton.MouseHover += AllButtons_MouseHover;
            Savebutton.MouseHover += AllButtons_MouseHover;
            SaveAsbutton.MouseHover += AllButtons_MouseHover;
            Jupiterbutton.MouseHover += AllButtons_MouseHover;
            QtConsolebutton.MouseHover += AllButtons_MouseHover;
            Runbutton.MouseHover += AllButtons_MouseHover;

            loadToolStripMenuItem.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "load.ico");
            saveToolStripMenuItem.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "saveas.ico");
            runToolStripMenuItem.Image = CPythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "run.ico");
            CPythonManager.PIPManager.SetupPipMenu(packagesToolStripMenuItem);
            //if (CPythonManager.checkifpackageinstalled("pythonnet"))
            //{
            //    CPythonManager.InstallPythonNet();

            //}
            this.Disposed += Uc_cpythonscriptrunner_Disposed;

            // BASIC CONFIG
            TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            TextArea.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;

            // STYLING
            InitColors();
            InitSyntaxColoring();

            // NUMBER MARGIN
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();

            // CODE FOLDING MARGIN
            InitCodeFolding();

            // DRAG DROP
            InitDragDropFile();

            // DEFAULT FILE
            //  LoadDataFromFile("../../MainForm.cs");
            //  TextArea.Text="";
            string retval = CPythonManager.FileManager.LoadScriptFile(Path.Combine(CPythonManager.AiFolderpath, "demo1.py"));
            if ( retval!= null)
            {
                TextArea.Text = CPythonManager.Script;
                Filenamelabel.Text = retval;
            }    ;
            // INIT HOTKEYS
              InitHotkeys();


        }
        public int numOutputLines { get; set; }
        private void CPythonManager_SendMessege(object sender, string e)
        {
            if (!String.IsNullOrEmpty(e))
            {
               
                //Add the text to the collected output.

                this.OutputtextBox.BeginInvoke(new Action(() =>
                {
                    this.OutputtextBox.AppendText(Environment.NewLine +
                    $">{e}");
                }));
            }

        }

        private void Clearoutputbutton_Click(object sender, EventArgs e)
        {
            OutputtextBox.Text = "";
        }

        private void AllButtons_MouseHover(object sender, EventArgs e)
        {
            PictureBox p =(PictureBox)sender;
            Hoverpanel.Left = p.Left - 6;
        }

        private void QtConsolebutton_Click(object sender, EventArgs e)
        {
            //CPythonManager.QtConsoleRun();
        }
        private void Insertlocaldbpathbutton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.LocalDBcomboBox.Text))
			{
                string path = "";
				ConnectionProperties cn = DMEEditor.ConfigEditor.DataConnections.Where(o => o.ConnectionName.Equals(this.LocalDBcomboBox.Text, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
				if (cn != null)
				{
                    //
                    //scripttextBox.AppendText(Path.Combine(cn.FilePath, cn.FileName));
                    if (cn.FilePath.StartsWith("."))
                    {
                        path= cn.FilePath.Remove(0,1);
                        char[] invalidPathChars = Path.GetInvalidPathChars();
                        path = DMEEditor.ConfigEditor.ExePath + path + cn.FileName;
                       
                    }else
                        path = Path.Combine(cn.FilePath,  cn.FileName);
                    Clipboard.SetText(path);
				}
			   
			}
			
		}
		private void Tmpfilepathbutton_Click(object sender, EventArgs e)
		{
			//scripttextBox.AppendText(Path.Combine(Python.aifolder,"tmp.csv"));
            Clipboard.SetText(Path.Combine(CPythonManager.AiFolderpath, "tmp.csv"));
        }
		private void Griddatasource_DataSourceChanged(object sender, EventArgs e)
		{
			OutputdataGridView.Refresh();
		}
		private void Uc_cpythonscriptrunner_Disposed(object sender, EventArgs e)
			{
				// Python.JupiterStop();
               //  Python.QtConsoleStop();
			  //  runPythonScriptscommandline($@"jupyter notebook stop ", $@"{aifolder}");
		  
			}
		private void Jupiterbutton_Click(object sender, EventArgs e)
			{
				// Python.JupiterRun();
			   // runPythonScriptscommandline($@"jupyter notebook ", $@"{aifolder}");
			}
		private void SavefilepictureBox_Click(object sender, EventArgs e)
			{

            CPythonManager.FileManager.SaveTexttoFile();

			}
		private void RunScriptbutton_Click(object sender, EventArgs e)
			{
	  
			try
			{
				this.TextArea.Text = this.TextArea.Text.Replace("BeepPath",DMEEditor.ConfigEditor.ExePath);
				this.TextArea.Text = this.TextArea.Text.Replace("BeepLib", $"{Path.Combine(DMEEditor.ConfigEditor.ExePath, "lib")}");
				this.TextArea.Text = this.TextArea.Text.Replace("BeepClasses",$"{Path.Combine(DMEEditor.ConfigEditor.ExePath, "ProjectClasses")}");
				this.TextArea.Text = this.TextArea.Text.Replace("BeepDrivers", $"{Path.Combine(DMEEditor.ConfigEditor.ExePath, "ConnectionDrivers")}");
				this.TextArea.Text = this.TextArea.Text.Replace("BeepOtherDLL", $"{Path.Combine(DMEEditor.ConfigEditor.ExePath, "OtherDLL")}");

                CPythonManager.ProcessManager.RunScript( this.TextArea.Text );
			}
			catch (Exception ex)
			{
				

			}


		}
		private void SaveFilebutton_Click(object sender, EventArgs e)
		{
            CPythonManager.FileManager.SaveTextAsFile();
		}
		private void LoadFilebutton_Click(object sender, EventArgs e)
		{
            string retval = CPythonManager.FileManager.LoadScriptFile(null);
            if (retval != null)
            {
                TextArea.Text = CPythonManager.Script;
                Filenamelabel.Text = retval;
            }

        }
        private void OnTextChanged(object sender, EventArgs e)
        {

        }
        private void InitSyntaxColoring()
        {

            // Configure the default style
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Consolas";
            TextArea.Styles[Style.Default].Size = 10;
            TextArea.Styles[Style.Default].BackColor = IntToColor(0x212121);
            TextArea.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            TextArea.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            TextArea.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
            TextArea.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
            TextArea.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
            TextArea.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            TextArea.Styles[Style.Cpp.Number].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Cpp.String].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
            TextArea.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            TextArea.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
            TextArea.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
            TextArea.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
            TextArea.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
            TextArea.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
            TextArea.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            TextArea.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            TextArea.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);

            TextArea.Lexer = Lexer.Python;

            TextArea.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            TextArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }
        #region Numbers, Bookmarks, Code Folding

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        private void InitNumberMargin()
        {

            TextArea.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            TextArea.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = TextArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            TextArea.MarginClick += TextArea_MarginClick;
        }

        private void InitBookmarkMargin()
        {

            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = TextArea.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = TextArea.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {

            TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            TextArea.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            TextArea.SetProperty("fold", "1");
            TextArea.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            TextArea.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            TextArea.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            TextArea.Margins[FOLDING_MARGIN].Sensitive = true;
            TextArea.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                TextArea.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                TextArea.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            TextArea.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            TextArea.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            TextArea.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            TextArea.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            TextArea.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            TextArea.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            TextArea.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            TextArea.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        #endregion
        #region Drag & Drop File

        public void InitDragDropFile()
        {

            TextArea.AllowDrop = true;
            TextArea.DragEnter += delegate (object sender, DragEventArgs e) {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            TextArea.DragDrop += delegate (object sender, DragEventArgs e) {

                // get file drop
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {

                    Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                    if (a != null)
                    {

                        string path = a.GetValue(0).ToString();

                        LoadDataFromFile(path);

                    }
                }
            };

        }

        private void LoadDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                Filenamelabel.Text = Path.GetFileName(path);
                TextArea.Text = File.ReadAllText(path);
            }
        }

        #endregion
        #region Main Menu Commands

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadDataFromFile(openFileDialog1.FileName);
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSearch();
        }

        private void findDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFindDialog();
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenReplaceDialog();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.SelectAll();
        }

        private void selectLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Line line = TextArea.Lines[TextArea.CurrentLine];
            TextArea.SetSelection(line.Position + line.Length, line.Position);
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.SetEmptySelection(0);
        }

        private void indentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indent();
        }

        private void outdentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Outdent();
        }

        private void uppercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uppercase();
        }

        private void lowercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lowercase();
        }

        private void wordWrapToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // toggle word wrap
         //   wordWrapItem.Checked = !wordWrapItem.Checked;
          //  TextArea.WrapMode = wordWrapItem.Checked ? WrapMode.Word : WrapMode.None;
        }

        private void indentGuidesToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // // toggle indent guides
//indentGuidesItem.Checked = !indentGuidesItem.Checked;
           // TextArea.IndentationGuides = indentGuidesItem.Checked ? IndentView.LookBoth : IndentView.None;
        }

        private void hiddenCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // toggle view whitespace
          //  hiddenCharactersItem.Checked = !hiddenCharactersItem.Checked;
          //  TextArea.ViewWhitespace = hiddenCharactersItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomDefault();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.FoldAll(FoldAction.Contract);
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.FoldAll(FoldAction.Expand);
        }


        #endregion
        #region Uppercase / Lowercase

        private void Lowercase()
        {

            // save the selection
            int start = TextArea.SelectionStart;
            int end = TextArea.SelectionEnd;

            // modify the selected text
            TextArea.ReplaceSelection(TextArea.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            TextArea.SetSelection(start, end);
        }

        private void Uppercase()
        {

            // save the selection
            int start = TextArea.SelectionStart;
            int end = TextArea.SelectionEnd;

            // modify the selected text
            TextArea.ReplaceSelection(TextArea.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            TextArea.SetSelection(start, end);
        }

        #endregion
        #region Indent / Outdent

        private void Indent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to indent,
            // although the indentation function exists. Pressing TAB with the editor focused confirms this.
            GenerateKeystrokes("{TAB}");
        }

        private void Outdent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to outdent,
            // although the indentation function exists. Pressing Shift+Tab with the editor focused confirms this.
            GenerateKeystrokes("+{TAB}");
        }

        private void GenerateKeystrokes(string keys)
        {
            HotKeyManager.Enable = false;
            TextArea.Focus();
            SendKeys.Send(keys);
            HotKeyManager.Enable = true;
        }

        #endregion
        private void InitColors()
        {

            TextArea.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }
        private void InitHotkeys()
        {

            // register the hotkeys with the WaitForm
            HotKeyManager.AddHotKey(visManager.MainForm, OpenSearch, Keys.F, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, OpenFindDialog, Keys.F, true, false, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, OpenReplaceDialog, Keys.R, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, OpenReplaceDialog, Keys.H, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, ZoomDefault, Keys.D0, true);
            HotKeyManager.AddHotKey(this.visManager.MainForm, CloseSearch, Keys.Escape);

            // remove conflicting hotkeys from scintilla
            TextArea.ClearCmdKey(Keys.Control | Keys.F);
            TextArea.ClearCmdKey(Keys.Control | Keys.R);
            TextArea.ClearCmdKey(Keys.Control | Keys.H);
            TextArea.ClearCmdKey(Keys.Control | Keys.L);
            TextArea.ClearCmdKey(Keys.Control | Keys.U);

        }
        #region Zoom

        private void ZoomIn()
        {
            TextArea.ZoomIn();
        }

        private void ZoomOut()
        {
            TextArea.ZoomOut();
        }

        private void ZoomDefault()
        {
            TextArea.Zoom = 0;
        }


        #endregion

        #region Quick Search Bar

        bool SearchIsOpen = false;

        private void OpenSearch()
        {

            SearchManager.SearchBox = TxtSearch;
            SearchManager.TextArea = TextArea;

            if (!SearchIsOpen)
            {
                SearchIsOpen = true;
                InvokeIfNeeded(delegate () {
                    PanelSearch.Visible = true;
                    TxtSearch.Text = SearchManager.LastSearch;
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
            else
            {
                InvokeIfNeeded(delegate () {
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
        }
        private void CloseSearch()
        {
            if (SearchIsOpen)
            {
                SearchIsOpen = false;
                InvokeIfNeeded(delegate () {
                    PanelSearch.Visible = false;
                    //CurBrowser.GetBrowser().StopFinding(true);
                });
            }
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            CloseSearch();
        }

        private void BtnPrevSearch_Click(object sender, EventArgs e)
        {
            SearchManager.Find(false, false);
        }
        private void BtnNextSearch_Click(object sender, EventArgs e)
        {
            SearchManager.Find(true, false);
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchManager.Find(true, true);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotKeyManager.IsHotkey(e, Keys.Enter))
            {
                SearchManager.Find(true, false);
            }
            if (HotKeyManager.IsHotkey(e, Keys.Enter, true) || HotKeyManager.IsHotkey(e, Keys.Enter, false, true))
            {
                SearchManager.Find(false, false);
            }
        }

        #endregion

        #region Find & Replace Dialog

        private void OpenFindDialog()
        {

        }
        private void OpenReplaceDialog()
        {


        }

        #endregion

        #region Utils

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        #endregion
    }
}