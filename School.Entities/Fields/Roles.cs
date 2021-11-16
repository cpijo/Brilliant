using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    public class UserRoles
    {
        public int RoleID { get; set; }
        public string UserId { get; set; }
    }
}
