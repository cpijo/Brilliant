using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class StudentClass
    {
        public int StudentClassId { get; set; }
        public int StudentId { get; set; }
        public int ClassName { get; set; }
        public int ClassId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
