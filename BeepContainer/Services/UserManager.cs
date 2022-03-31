using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTechIdea.Util;
using TheTechIdea.Beep.Containers.Models;
using TheTechIdea.Beep.Containers.Models.UserManagement;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public class UserManager : IUserManager
    {
        public UserManager()
        {
            ErrorsandMesseges = new ErrorsInfo();
        }
        public IErrorsInfo ErrorsandMesseges { get; set; }
        public List<ContainerUser> Users { get; set; } = new List<ContainerUser>();
        public IErrorsInfo AddUser(string pUsername)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist
                if (Users.Where(p => p.Username.Equals(pUsername, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    ErrorsandMesseges.Flag = Errors.Failed;
                    ErrorsandMesseges.Message = $"User Exists";
                }
                else
                {
                    Users.Add(new ContainerUser(pUsername));
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }

            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Add user";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo RemoveUser(string pUsername)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist
                ContainerUser user = Users.Where(p => p.Username.Equals(pUsername, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (user == null)
                {
                    ErrorsandMesseges.Flag = Errors.Failed;
                    ErrorsandMesseges.Message = $"User Does not Exists";
                }
                else
                {
                    Users.Remove(user);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }

            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Add user";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo UpdateUser(ContainerUser pUser)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist

                if (!Users.Where(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users.Add(pUser);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }
                else
                {
                    int idx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                    Users[idx] = pUser;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Updated";
                }

            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Update/Add user";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo UpdateUserPriv(ContainerUser pUser, UserPrivilege ppriv)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist
                int UserIdx = -1;
                int PrivIdx = -1;
                if (!Users.Where(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users.Add(pUser);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }
                else
                {
                    UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                    Users[UserIdx] = pUser;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Updated";
                }
                UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                List<UserPrivilege> grps = Users[UserIdx].UserPrivileges.ToList();
                if (!grps.Where(p => p.Privileges.PrivilegeName.Equals(ppriv.Privileges.PrivilegeName, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users[UserIdx].UserPrivileges.Add(ppriv);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Privilge Added";
                }
                else
                {
                    PrivIdx = Users[UserIdx].UserPrivileges.FindIndex(p => p.Privileges.PrivilegeName.Equals(ppriv.Privileges.PrivilegeName, StringComparison.OrdinalIgnoreCase));
                    Users[UserIdx].UserPrivileges[PrivIdx] = ppriv;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Privilge Updated";
                }


            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Update/Add user";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo RemoveUserPriv(ContainerUser pUser, UserPrivilege ppriv)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist
                int UserIdx = -1;
                int PrivIdx = -1;
                if (!Users.Where(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users.Add(pUser);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }
                else
                {
                    UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                    Users[UserIdx] = pUser;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Updated";
                }
                UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                List<UserPrivilege> grps = Users[UserIdx].UserPrivileges.ToList();
                if (!grps.Where(p => p.Privileges.PrivilegeName.Equals(ppriv.Privileges.PrivilegeName, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users[UserIdx].UserPrivileges.Remove(ppriv);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Privilge Removed";
                }
                else
                {

                    ErrorsandMesseges.Flag = Errors.Failed;
                    ErrorsandMesseges.Message = $"User Privilge Not Found";
                }


            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Remove user Privilge";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo UpdateUserGroup(ContainerUser pUser, GroupPriv pGrp)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist
                int UserIdx = -1;
                int PrivIdx = -1;
                if (!Users.Where(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users.Add(pUser);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }
                else
                {
                    UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                    Users[UserIdx] = pUser;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Updated";
                }
                UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                List<GroupPriv> grps = Users[UserIdx].GroupPrivileges.Select(p=>p.GroupData).ToList();
                if (!grps.Where(p => p.GroupName.Equals(pGrp.GroupName, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    grps.Add(pGrp);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Group Added";
                }
                else
                {
                    PrivIdx = grps.FindIndex(p => p.GroupName.Equals(pGrp.GroupName, StringComparison.OrdinalIgnoreCase));
                    grps[PrivIdx] = pGrp;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Group Updated";
                }


            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Update/Add user Groups";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
        public IErrorsInfo RemoveUserGroup(ContainerUser pUser, GroupPriv pGrp)
        {
            try
            {
                ErrorsInfo ErrorsandMesseges = new ErrorsInfo();
                // -- check if user already Exist
                int UserIdx = -1;
                int PrivIdx = -1;
                if (!Users.Where(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    Users.Add(pUser);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Added";
                }
                else
                {
                    UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                    Users[UserIdx] = pUser;
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Updated";
                }
                UserIdx = Users.FindIndex(p => p.Username.Equals(pUser.Username, StringComparison.OrdinalIgnoreCase));
                List<GroupPriv> grps = Users[UserIdx].GroupPrivileges.Select(p => p.GroupData).ToList();
                if (!grps.Where(p => p.GroupName.Equals(pGrp.GroupName, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    grps.Remove(pGrp);
                    ErrorsandMesseges.Flag = Errors.Ok;
                    ErrorsandMesseges.Message = $"User Group Removed";
                }
                else
                {

                    ErrorsandMesseges.Flag = Errors.Failed;
                    ErrorsandMesseges.Message = $"User Group Not found";
                }


            }
            catch (Exception ex)
            {
                ErrorsandMesseges.Flag = Errors.Failed;
                ErrorsandMesseges.Message = ex.Message;
                ErrorsandMesseges.Ex = ex;
                ErrorsandMesseges.Fucntion = "Remove user Groups";
                ErrorsandMesseges.Module = "Container User Management";

            }
            return ErrorsandMesseges;
        }
    }
}
