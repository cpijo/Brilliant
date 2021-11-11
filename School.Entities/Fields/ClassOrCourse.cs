using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class ClassOrCourse
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
    }

    public class StudentGrade
    {
        public string GradeStudentId { get; set; }
        public string StudentId { get; set; }
        public string GradeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
