using AIBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTechIdea.Beep.AIBuilder.Cpython
{
    public class IDEManager
    {
        public IDEManager(ICPythonManager cPythonManager)
        {
            pythonManager = cPythonManager;
        }
        private ICPythonManager pythonManager;
        public void SetupPipMenu(ToolStripMenuItem packagesToolStripMenuItem)
        {
            string pname;
            string ptitle;
            string category;
            string[] packs = pythonManager.PIPManager.packagenames.Split(',');
            string[] packscategoriesimages = pythonManager.PIPManager.packagecatgoryimages.Split(',');
            foreach (string item in packscategoriesimages)
            {
                string[] imgs = item.Split(';');
                pythonManager.PIPManager.packageCategorys.Add(new packageCategoryImages { category = imgs[0], image = imgs[1] });

            }
            foreach (string item in packs)
            {
                try
                {
                    string[] pc = item.Split(';');

                    pname = pc[0];
                    ptitle = pc[1];
                    category = pc[2];

                    pythonManager.PIPManager.packages.Add(new packagelist { packagename = pname, packagetitle = ptitle, category = category, installpath = pythonManager.Packageinstallpath });
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
            foreach (string item in pythonManager.PIPManager.packages.Select(o => o.category).Distinct().ToList())
            {
                ToolStripMenuItem o = new ToolStripMenuItem();
                o.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                o.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                o.Text = item;
                if (pythonManager.PIPManager.packageCategorys.Where(u => u.category.Equals(o.Text, StringComparison.OrdinalIgnoreCase)).Any())
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
                foreach (packagelist package in pythonManager.PIPManager.packages.Where(p => p.category == item))
                {


                    t = o.DropDownItems.Add(package.packagetitle);


                    if (pythonManager.PIPManager.checkifpackageinstalled(package.packagename))
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
        public void Installpip_Click(object sender, EventArgs e)
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync("py get-pip.py", $@"{pythonManager.BinPath}\scripts\");
        }
        public void PackagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            string n = i.Text;
            string packagename = pythonManager.PIPManager.packages.Where(o => o.packagetitle.Equals(n, StringComparison.OrdinalIgnoreCase)).Select(o => o.packagename).FirstOrDefault();
            pythonManager.PIPManager.InstallPackage(packagename);
        }
        public void updatePIP_Click(object sender, EventArgs e)
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"{pythonManager.BinPath}\python.exe -m pip install --upgrade pip", $@"{pythonManager.BinPath}\scripts\");
        }
        public void PackagesInstalledbutton_Click(object sender, EventArgs e)
        {
            pythonManager.ProcessManager.runPythonScriptscommandlineAsync($@"pip.exe list", $@"{pythonManager.BinPath}\scripts\");

        }
    }
}
