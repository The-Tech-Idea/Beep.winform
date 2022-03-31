using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeepEnterprize.Vis.Module;
using TheTechIdea.Beep;
using TheTechIdea.Util;

namespace BeepEnterprize.Winform.Vis.Helpers
{
    public class VisHelper : IVisHelper
    {
        public VisHelper(IDMEEditor pDMEEditor, IVisManager pVismanager)
        {
            DMEEditor = pDMEEditor;
            Vismanager = pVismanager;
        }
        public IDMEEditor DMEEditor { get; set; }
        public IVisManager Vismanager { get; set; }
        public VisManager vismanager { get { return (VisManager)Vismanager; }  }
        public int GetImageIndex(string imagename)
        {
            try
            {
                int imgindx = vismanager.Images.Images.IndexOfKey(imagename);
                return imgindx;
                // Tree.SelectedImageIndex = GetImageIndex("select.ico");
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public Bitmap GetImage(string imagename)
        {
            try
            {
                int idx = GetImageIndex(imagename);
                Bitmap img = (Bitmap)vismanager.Images.Images[idx];
                return img;
                // Tree.SelectedImageIndex = GetImageIndex("select.ico");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int GetImageIndexFromConnectioName(string Connectioname)
        {
            try
            {
                string drname = null;
                string iconname = null;
                ConnectionDriversConfig connectionDrivers;
                if (DMEEditor.ConfigEditor.DataConnections.Where(c => c.ConnectionName == Connectioname).Any())
                {
                    drname = DMEEditor.ConfigEditor.DataConnections.Where(c => c.ConnectionName == Connectioname).FirstOrDefault().DriverName;
                }

                if (drname != null)
                {
                    string drversion = DMEEditor.ConfigEditor.DataConnections.Where(c => c.ConnectionName == Connectioname).FirstOrDefault().DriverVersion;
                    if (DMEEditor.ConfigEditor.DataDriversClasses.Where(c => c.version == drversion && c.DriverClass == drname).Any())
                    {

                        connectionDrivers = DMEEditor.ConfigEditor.DataDriversClasses.Where(c => c.version == drversion && c.DriverClass == drname).FirstOrDefault();
                        if (connectionDrivers != null)
                        {
                            iconname = connectionDrivers.iconname;
                        }
                    }
                    else
                    {
                        connectionDrivers = DMEEditor.ConfigEditor.DataDriversClasses.Where(c => c.DriverClass == drname).FirstOrDefault();
                        if (connectionDrivers != null)
                        {
                            iconname = connectionDrivers.iconname;
                        }

                    }
                   
                    int imgindx = vismanager.Images.Images.IndexOfKey(iconname);
                    return imgindx;
                }
                else
                    return -1;
            }
            catch (Exception)
            {

                return -1;
            }

        }

    }
}
