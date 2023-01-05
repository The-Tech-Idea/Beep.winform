using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.AIBuilder
{
    public class ResourceManager
    {
        public ResourceManager()
        {

        }
       
        public Image GetImage(string path,string fullName)
        {
            Bitmap image = null;
            Stream stream;
            Assembly assembly = Assembly.GetCallingAssembly();
            // Is this just a single (ie. one-time) image?
            stream = assembly.GetManifestResourceStream(path + fullName);
            if (stream != null)
            {
                image = new Bitmap(stream);
                stream.Close();
                return image;
            }
            else
                return null;
        }
        public Icon GetIcon(string path, string fullName)
        {
            Icon icon = null;
            Stream stream;
            Assembly assembly = Assembly.GetCallingAssembly();
            // Is this just a single (ie. one-time) image?
            stream = assembly.GetManifestResourceStream(path + fullName);
            if (stream != null)
            {
                icon = new Icon(stream);
                stream.Close();
                return icon;
            }
            else
                return null;
        }
        public List<string> GetImageList(Assembly assembly)
        {
            System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            string resourceName = assembly.GetName().Name;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourceName, assembly);
            System.Resources.ResourceSet resourceSet = rm.GetResourceSet(culture, true, true);
            List<string> resources = new List<string>();
            foreach (DictionaryEntry resource in resourceSet)
            {
                resources.Add((string)resource.Key);
            }
            rm.ReleaseAllResources();
            return resources;
        }
       
    }
}
