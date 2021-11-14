using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace School.Entities.Fields
{
    public class User
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string UserName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Language { get; set; }
        public string Password { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string UserType { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
