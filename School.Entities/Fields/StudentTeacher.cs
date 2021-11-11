using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class StudentTeacher
    {
        public int StudentTeacherId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
