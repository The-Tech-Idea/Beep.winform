using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private ImageList GetImageList(int IconSize)
        {


            switch (IconSize)
            {
                case 16:
                    return vismanager.Images16;
                    break;
                case 32:
                    return vismanager.Images32;
                    break;
                case 64:
                    return vismanager.Images64;
                    break;
                case 128:
                    return vismanager.Images128;
                    break;
                case 256:
                    return vismanager.Images256;
                    break;
                default:
                    return vismanager.Images;
                    break;
            }

        }
        public int GetImageIndex(string imagename,int size)
        {
            try
            {
                int imgindx = GetImageList(size).Images.IndexOfKey(imagename);
                if (imgindx == -1)
                {
                    GetImageList(1000).Images.IndexOfKey(imagename);
                }
                return imgindx;
                // Tree.SelectedImageIndex = GetImageIndex("select.ico");
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public Bitmap GetImage(string imagename, int size)
        {
            try
            {
                int idx = GetImageIndex(imagename,size);
                if (idx == -1)
                {
                   idx= GetImageList(1000).Images.IndexOfKey(imagename);
                }
                Bitmap img = (Bitmap)GetImageList(size).Images[idx];
                return img;
                // Tree.SelectedImageIndex = GetImageIndex("select.ico");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int GetImageIndexFromConnectioName(string Connectioname, int size)
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
                   
                    int imgindx = GetImageList(size).Images.IndexOfKey(iconname);
                    if (imgindx != -1) {
                        imgindx = GetImageList(1000).Images.IndexOfKey(iconname);
                    }
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
