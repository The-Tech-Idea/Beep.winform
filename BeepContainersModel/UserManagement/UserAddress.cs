using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using TheTechIdea.Beep.Containers.Models;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public class UserAddress
    {
        public int UserAddressID { get; set; }
      
        public ApplicationUser User { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
       
        public Country Country { get; set; }
        public string Zcode { get; set; }
        public AddressTypes AddressType { get; set; }


    }

}
