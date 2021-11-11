using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class TeacherClass
    {
        public int TeacherClassId { get; set; }
        public int TeacherId { get; set; }
        public int ClassName { get; set; }
        public int ClassId { get; set; }
    }
}
