using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class Classes
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string OldClassId { get; set; }
    }
    public class GradeClass
    {
        public string GradeId { get; set; }
        public string GradeName { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        //public string Title { get; set; }
    }
}
