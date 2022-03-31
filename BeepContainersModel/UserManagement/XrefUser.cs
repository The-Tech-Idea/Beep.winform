using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TheTechIdea.Beep.Containers.Models;

namespace TheTechIdea.Beep.Containers.UserManagement
{
    public class XrefUser
    {
        public int XrefUserID { get; set; }
        [ForeignKey("UserName")]
        public ApplicationUser ParentUser { get; set; }
        public UserRelations Relation { get; set; }
    }
}
