using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Skins;

namespace BeepEnterPrize.DevExpress
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                if (cnt.SkinName.Contains("Office 2007") || cnt.SkinName == "Caramel")
                    continue;
                if (!cnt.SkinName.Contains("DevExpress")) { }
                   // comboBoxEdit1.Properties.Items.Add(cnt.SkinName);
                else switch (cnt.SkinName)
                            {
                                case "DevExpress Style":
                                    //  comboBoxEdit1.Properties.Items.Add("Default Skin");
                                    break;
                                case "DevExpress Dark Style":
                                    //  comboBoxEdit1.Properties.Items.Add("Default Dark Skin");
                                    break;
                            }
            }
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
