using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using TheTechIdea.Beep.Containers.Models;
using TheTechIdea.Beep.Containers.Models.UserManagement;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public class UserPrivilege
    {
        public int UserPrivilegeID { get; set; }
       
        public ApplicationUser User { get; set; }
        public PrivilegePriv Privileges { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
