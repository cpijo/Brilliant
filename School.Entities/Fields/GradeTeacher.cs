using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class GradeTeacher
    {
        public int GradeTeacherId { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
    }
}
