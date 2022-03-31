
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTechIdea.Beep.Containers.Models;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public class ApplicationUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public UserTypes UserType { get; set; }
        public bool AcceptNews { get; set; }
        public string Url { get; set; }
        public List<UserAddress> Addresses { get; set; }
        public List<UserPrivilege> Privileges { get; set; }
        public List<UserGroup> Groups { get; set; }
        public List<UserLicense> Licenses { get; set; }
       
        public ApplicationUser  AuthUser { get; set; }
       

    }
}
