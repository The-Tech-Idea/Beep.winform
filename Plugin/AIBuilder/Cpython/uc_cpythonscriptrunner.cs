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
using IronPython.Hosting;
using System.IO;
using AI;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using BeepEnterprize.Vis.Module;
using TheTechIdea.Beep.Vis;

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
		public PythonHandler Python { get; set; }
		public IVisManager Visutil { get; set; }
	
		IBranch RootAppBranch;
		IBranch branch;

	
	  
		
			BindingSource griddatasource = new BindingSource();
			public void RaiseObjectSelected()
		{
			throw new NotImplementedException();
		}
         
		public void Run(IPassedArgs Passedarg)
		{
			throw new NotImplementedException();
		}

		public void SetConfig(IDMEEditor pbl, IDMLogger plogger, IUtil putil, string[] args, IPassedArgs e, IErrorsInfo per)
		{
			Passedarg = e;
			Logger = plogger;
			ErrorObject = per;
			DMEEditor = pbl;
			Python = new PythonHandler(pbl,scripttextBox,OutputtextBox, griddatasource);
			griddatasource.DataSourceChanged += Griddatasource_DataSourceChanged;
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

				scripttextBox.Multiline = true;
				scripttextBox.WordWrap = false;
				scripttextBox.AcceptsTab = true;
				scripttextBox.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
				scripttextBox.Dock = DockStyle.Fill;
				scripttextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
				scripttextBox.SelectionColor = Color.Black;
			}
			catch (Exception rr)
			{


			}
			foreach (string cnname in Python.GetLocalDB())
			{
				this.LocalDBcomboBox.Items.Add(cnname);
			}
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
            
            LoadScriptbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "load64.png");
            Savebutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "save64.png");
            SaveAsbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "saveas64.png");
            Jupiterbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "jupyter64.png");
            QtConsolebutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "qt64.png");
            Runbutton.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "run64.png");
            Clearoutputbutton.BackgroundImage = Python.resourceManager.GetImage("AIBuilder.gfx.", "clear.png");
            Clearoutputbutton.Click += Clearoutputbutton_Click;
            LoadScriptbutton.MouseHover += AllButtons_MouseHover;
            Savebutton.MouseHover += AllButtons_MouseHover;
            SaveAsbutton.MouseHover += AllButtons_MouseHover;
            Jupiterbutton.MouseHover += AllButtons_MouseHover;
            QtConsolebutton.MouseHover += AllButtons_MouseHover;
            Runbutton.MouseHover += AllButtons_MouseHover;

            loadToolStripMenuItem.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "load.ico");
            saveToolStripMenuItem.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "saveas.ico");
            runToolStripMenuItem.Image = Python.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "run.ico");


            Python.LoadScriptFile(Path.Combine(Python.aifolder,"demo1.py"));


            Python.SetupPipMenu(packagesToolStripMenuItem);

				
				this.Disposed += Uc_cpythonscriptrunner_Disposed;
				//CreateFileWatcher(DMEEditor.ConfigEditor.Config.Folders.Where(c => c.FolderFilesType == FolderFileTypes.Scripts && c.FolderPath.Contains("AI")).FirstOrDefault().FolderPath);
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
            Python.QtConsoleRun();
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
            Clipboard.SetText(Path.Combine(Python.aifolder, "tmp.csv"));
        }
		private void Griddatasource_DataSourceChanged(object sender, EventArgs e)
		{
			OutputdataGridView.Refresh();
		}
		private void Uc_cpythonscriptrunner_Disposed(object sender, EventArgs e)
			{
				 Python.JupiterStop();
                Python.QtConsoleStop();
			  //  runPythonScriptscommandline($@"jupyter notebook stop ", $@"{aifolder}");
		  
			}
		private void Jupiterbutton_Click(object sender, EventArgs e)
			{
				 Python.JupiterRun();
			   // runPythonScriptscommandline($@"jupyter notebook ", $@"{aifolder}");
			}
		private void SavefilepictureBox_Click(object sender, EventArgs e)
			{

				Python.SaveTexttoFile();

			}
		private void RunScriptbutton_Click(object sender, EventArgs e)
			{
	  
			try
			{
				Python.RunScript();
			}
			catch (Exception ex)
			{
				

			}


		}
		private void SaveFilebutton_Click(object sender, EventArgs e)
		{
				Python.SaveTextAsFile();
		}
		private void LoadFilebutton_Click(object sender, EventArgs e)
		{
			Filenamelabel.Text= Python.LoadScriptFile(null);
		   
		}
		
	}
}