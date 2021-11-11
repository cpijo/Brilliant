
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace School.Entities.Fields
{
    public class Teacher: User
    {
        [Display(Name = "Teacher Id")]
        public string TeacherId { get; set; }

        public Teacher()
        {
        }
        public void getDefaults()
        {
            CreatedDate = DateTime.Today;
            CreatedDate = DateTime.Today;
            TeacherId = Guid.NewGuid().ToString();
        }
    }
}