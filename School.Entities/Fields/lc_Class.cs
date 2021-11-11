using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    class lc_Class
    {
        public int classId { get; set; }
    }
    class lc_Teaching
    {
        public int teachingId { get; set; }
        public int SubjectId { get; set; }
        public int classId { get; set; }
        public int teacherId { get; set; }
    }

    class lc_Teacher
    {
        public int teacherId { get; set; }
    }
}
