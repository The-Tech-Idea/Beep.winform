using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public class ContainerUser
    {
        public ContainerUser()
        {

        }
        public ContainerUser(string pUsername)
        {
            Guid = new Guid( ).ToString();
            Username = pUsername;

        }
        public string Username { get; set; }
        public string Guid { get; set; }
        public List<UserPrivilege> UserPrivileges { get; set; } = new List<UserPrivilege>();
        public List<UserGroup> GroupPrivileges { get; set; } = new List<UserGroup>();

    }
}
