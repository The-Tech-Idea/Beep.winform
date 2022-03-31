using System.Collections.Generic;
using TheTechIdea.Beep.Containers.Models.UserManagement;
using TheTechIdea.Util;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public interface IUserManager
    {
      
        List<ContainerUser> Users { get; set; }

        IErrorsInfo AddUser(string pUsername);
        IErrorsInfo RemoveUser(string pUsername);
        IErrorsInfo RemoveUserGroup(ContainerUser pUser, GroupPriv pGrp);
        IErrorsInfo RemoveUserPriv(ContainerUser pUser, UserPrivilege ppriv);
        IErrorsInfo UpdateUser(ContainerUser pUser);
        IErrorsInfo UpdateUserGroup(ContainerUser pUser, GroupPriv pGrp);
        IErrorsInfo UpdateUserPriv(ContainerUser pUser, UserPrivilege ppriv);
    }
}