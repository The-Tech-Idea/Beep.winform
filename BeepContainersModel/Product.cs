using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.Containers.Models
{
    public class Product
    {
        
        public int ProductID { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
}
