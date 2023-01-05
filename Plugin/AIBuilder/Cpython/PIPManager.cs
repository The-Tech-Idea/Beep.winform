using AIBuilder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public class PIPManager
    {
        public string packagenames { get; } = "Plotly;plotly;Chart,PyQt5;PyQt5;Chart,Dash;Ploty and Dash App;Chart,pythonnet;Python.Net;Tools,qtconsole;qtconsole;Tools,jupyter;Jupyter;Tools,winpty;Pseudoterminals;Tools,ipython;IPython;Tools,pprint36;Pretty Print;Tools,tabulate;Tabular Print;Tools,Pillow;Imaging Library;Chart,Matplotlib;MatPlot;Chart,Numpy;Numpy;Compute,opencv-python;OpenCV;Chart,Requests;HTTP library;Tools,Keras;Keras;ML,TensorFlow;TensorFlow;ML,Theano;Theano Math;ML,NLTK;Natural Language Toolkit;ML,Fire;Fire Auto. command line interfaces Generation;Tools,Arrow;Arrow Date Manupliation;Tools,FlashText;FlashText;Tools,Scipy;SciPy Scientific Library;ML,SQLAlchemy;SQLAlcemy Database Abstraction;ML,wxPython;wx GUI toolkit;Gui,torch;PyTorch Tensors and Dynamic neural networks;ML,Luminoth;Luminoth Computer vision toolkit based on TensorFlow;Chart,BeautifulSoup;BeautifulSoup Screen-scraping library;Tools,Bokeh;Bokeh Interactive plots and applications;Chart,Poetry;Poetry dependency management and packaging made easy;Tools,Gensim;Gensim fast Vector Space Modelling;ML,pandas;Pandas data structures for data analysis-time series-statistics;ML,Pytil;tility library;Tools,scikit-learn;Scikit Learn machine learning and data mining;ML,NetworkX;Networkx creating and manipulating graphs and networks;ML,TextBlob;TextBlob text processing;ML,Mahotas;Mahotas Computer Vision;ML";
        public string packagecatgoryimages { get; } = "Tools;tools,ML;ml,GUI;gui,Chart;gfx,Compute;Compute";
        public List<packagelist> packages { get; set; } = new List<packagelist>();
        public List<packageCategoryImages> packageCategorys { get; set; } = new List<packageCategoryImages>();
        public string[] packs { get; set; }

        public PIPManager(ICPythonManager cPythonManager)
        {
            pythonManager=cPythonManager;
        }
        private ICPythonManager pythonManager;

        #region "Pip Handling"
        public void SetupPipMenu(ToolStripMenuItem packagesToolStripMenuItem)
        {
            string pname;
            string ptitle;
            string category;
            string[] packs = packagenames.Split(',');
            string[] packscategoriesimages = packagecatgoryimages.Split(',');
            foreach (string item in packscategoriesimages)
            {
                string[] imgs = item.Split(';');
                packageCategorys.Add(new packageCategoryImages { category = imgs[0], image = imgs[1] });

            }
            foreach (string item in packs)
            {
                try
                {
                    string[] pc = item.Split(';');

                    pname = pc[0];
                    ptitle = pc[1];
                    category = pc[2];

                    packages.Add(new packagelist { packagename = pname, packagetitle = ptitle, category = category, installpath = pythonManager.Packageinstallpath });
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Could not add {item}");
                }


            }
            ToolStripItem t = packagesToolStripMenuItem.DropDownItems.Add("Install pip");
            t.Click += Installpip_Click;
            t.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "install.ico");

            ToolStripItem tupdate = packagesToolStripMenuItem.DropDownItems.Add("Update pip");
            tupdate.Click += updatePIP_Click;
            tupdate.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "install.ico");
            t = packagesToolStripMenuItem.DropDownItems.Add("List Packages");
            t.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "list.ico");
            t.Click += PackagesInstalledbutton_Click;



            //ToolStripMenuItem AILMitem = new ToolStripMenuItem("ML");
            //ToolStripMenuItem GFXitem = new ToolStripMenuItem("GFX");
            //ToolStripMenuItem Toolsitem = new ToolStripMenuItem("Tools");
            //ToolStripMenuItem Computesitem = new ToolStripMenuItem("Compute");
            //ToolStripMenuItem Guisitem = new ToolStripMenuItem("GUI");
            //packagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {AILMitem, GFXitem ,Toolsitem, Computesitem,Guisitem });

            //t.Click += InstallPythonNetbutton_Click;
            // ToolStripMenuItem
            foreach (string item in packages.Select(o => o.category).Distinct().ToList())
            {
                ToolStripMenuItem o = new ToolStripMenuItem();
                o.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                o.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                o.Text = item;
                if (packageCategorys.Where(u => u.category.Equals(o.Text, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    switch (item)
                    {
                        case "Gui":

                            o.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "gui.ico");
                            break;
                        case "Tools":
                            o.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "tools.ico");
                            break;
                        case "GFX":
                            o.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "gfx.ico");
                            break;
                        case "ML":
                            o.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "ml.ico");
                            break;
                        case "Compute":
                            o.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "compute.ico");
                            break;
                        default:
                            break;
                    }


                }
                //        o.Text = item;

                packagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { o });
                foreach (packagelist package in packages.Where(p => p.category == item))
                {


                    t = o.DropDownItems.Add(package.packagetitle);


                    if (checkifpackageinstalled(package.packagename))
                    {
                        t.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "linked.ico");
                    }
                    else
                    {
                        t.Image = pythonManager.resourceManager.GetImage("TheTechIdea.Beep.AIBuilder.gfx.", "nolink.ico");
                    }
                    t.Click += PackagesToolStripMenuItem_Click;

                }
            }

        }
        public bool checkifpackageinstalled(string packagename)
        {
            if (packagename.Contains("-"))
            {
                packagename = packagename.Replace("-", "_");
            }
            string[] dirs = Directory.GetDirectories(pythonManager.Packageinstallpath, packagename + "*", SearchOption.TopDirectoryOnly);
            if (dirs.Length > 0)
            {
                return true;
            }
            else return false;

        }
        public void Installpip_Click(object sender, EventArgs e)
        {
           
        }
        public bool InstallPIP()
        {
            if (checkifpackageinstalled("pip"))
            {
                return true;
            }
            else
            {
                pythonManager.ProcessManager.runPythonScriptscommandlineAsync("py get-pip.py", $@"{pythonManager.BinPath}\scripts\");
                if (checkifpackageinstalled("pip"))
                {
                    //i.Image = global::TheTechIdea.Beep.AIBuilder.Properties.Resources.verified_account_32px;
                    //MessageBox.Show($"Success Install Package {n}");
                    return true;
                }
                else
                {
                    return false;
                    //   i.Image = global::TheTechIdea.Beep.AIBuilder.Properties.Resources.cancel_32px;
                    // MessageBox.Show($"Failed to Install Package {n}");
                }
            }
        }
        public bool InstallPackage(string packagename)
        {
            if (checkifpackageinstalled(packagename))
            {
                return true;
            }
            else
            {
                pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"pip.exe install {packagename}", $@"{pythonManager.BinPath}\scripts\");
                if (checkifpackageinstalled(packagename))
                {
                    //i.Image = global::TheTechIdea.Beep.AIBuilder.Properties.Resources.verified_account_32px;
                    //MessageBox.Show($"Success Install Package {n}");
                    return true;
                }
                else
                {
                    return false;
                    //   i.Image = global::TheTechIdea.Beep.AIBuilder.Properties.Resources.cancel_32px;
                    // MessageBox.Show($"Failed to Install Package {n}");
                }
            }
            
        }
        public void PackagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            string n = i.Text;
            string packagename = packages.Where(o => o.packagetitle.Equals(n, StringComparison.OrdinalIgnoreCase)).Select(o => o.packagename).FirstOrDefault();
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"pip.exe install {packagename}", $@"{pythonManager.BinPath}\scripts\");
            //if (checkifpackageinstalled(packagename))
            //{
            //    i.Image = global::AIBuilder.Properties.Resources.verified_account_32px;
            //    MessageBox.Show($"Success Install Package {n}");
            //}
            //else
            //{
            //    i.Image = global::AIBuilder.Properties.Resources.cancel_32px;
            //    MessageBox.Show($"Failed to Install Package {n}");
            //}

        }
        public void updatePIP_Click(object sender, EventArgs e)
        {


            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"{pythonManager.BinPath}\python.exe -m pip install --upgrade pip", $@"{pythonManager.BinPath}\scripts\");
        }
        public void InstallPythonNet()
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync("pip install pythonnet", $@"{pythonManager.BinPath}\scripts\");
        }
        public void PackagesInstalledbutton_Click(object sender, EventArgs e)
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"pip.exe list", $@"{pythonManager.BinPath}\scripts\");

        }
        public void QtConsoleRun()
        {
            //jupyter qtonsole
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"jupyter qtconsole ", $@"{pythonManager.AiFolderpath}");
        }
        public void QtConsoleStop()
        {
            //jupyter qtonsole
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"jupyter qtconsole stop", $@"{pythonManager.AiFolderpath}");
        }
        public void JupiterRun()
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"jupyter notebook ", $@"{pythonManager.AiFolderpath}");
        }
        public void JupiterStop()
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"jupyter notebook stop ", $@"{pythonManager.AiFolderpath}");
        }

       
        #endregion
    }
}
