using System;
using System.Collections.Generic;
using System.Text;

namespace BeepEnterprize.Vis.Module
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string EmailConfirmed { get; set; }
        string PasswordConfirmed { get; set; }
        
        string Address { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string PostalCode { get; set; }
        string Country { get; set; }
        string Fax { get; set; }
        string FaxNumber { get; set; }
        string PhoneNumber { get; set; }    
        string PhoneNumberConfirmed { get; set; }

        string Company { get; set; }
        string CompanyNumber { get; set; }
        string Department { get; set; }
        string Position { get; set; }
        List<IPrivilege>   Privileges { get; set; }
        IProfile Profile { get; set; }
        bool IsLoggedin { get; set; }
        bool IsAdmin { get; set; }

    }
}
