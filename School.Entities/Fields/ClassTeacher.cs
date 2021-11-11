using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class ClassTeacher
    {
        public int ClassTeacherId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
