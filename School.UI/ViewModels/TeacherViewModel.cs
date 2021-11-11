using School.Entities.Fields;
using School.UI.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.UI.ViewModels
{
    public class TeacherViewModel
    {
        public Teacher Teacher { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Address Address { get; set; }
        public AssignTeacher AssignTeacher { get; set; }
        public Grades Grades { get; set; }
        public ClassOrCourse ClassOrCourse { get; set; }

        public TeacherViewModel()
        {
            Teacher = new Teacher();
            Address = new Address();
            Teachers = new List<Teacher>();
            Grades = new Grades();
            ClassOrCourse = new ClassOrCourse();
        }
    }
}