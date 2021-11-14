using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Entities.Fields
{
    public class Grades
    {
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public string GradeId { get; set; }
        public string Grade { get; set; }
        public string oldGradeId { get; set; }
    }
    public class StandardClass
    {
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public string GradeId { get; set; }
        public string Grade { get; set; }
    }

    public class GradeStudent
    {
        public Grades Grade { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public List<Grades> Grades { get; set; }
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }

        public GradeStudent()
        {
            Grades = new List<Grades>();
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
    }

}