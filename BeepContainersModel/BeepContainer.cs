using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTechIdea.Beep.Containers.Services;
using TheTechIdea.Beep.Containers.UserManagement;

namespace TheTechIdea.Beep.Containers.Models
{
    public class BeepContainer
    {
        public int ContainerID { get; set; }
        public string ContainerName { get; set; }
        public string ContainerFolderPath { get; set; }
        public string ContainerUrlPath { get; set; }
        public string SecretKey { get; set; }
        public string TokenKey { get; set; }
        public IBeepDMService DMService { get; set; }
        public  List<ApplicationUser> Users { get; set; }

    }
}
