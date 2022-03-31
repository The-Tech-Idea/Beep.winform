using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBuilder
{
    public class packagelist
    {
        public packagelist()
        {

        }
        public string packagetitle { get; set; }
        public string packagename { get; set; }
        public string installpath { get; set; }
        public string sourcepath { get; set; }
        public bool installed { get; set; }
        public string category { get; set; }
    }
    public class packageCategoryImages
    {
        public packageCategoryImages()
        {

        }
       
        public string image { get; set; }
     
        public string category { get; set; }
    }
}
