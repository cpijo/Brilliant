using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.UI.ViewModels.TeacherVM
{
    public class TeacherRoleViewModel
    {
        public Grades Grade { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public List<Grades> Grades { get; set; }
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }

        public TeacherRoleViewModel()
        {
            Grades = new List<Grades>();
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
    }

    public class TeacherRoleSimpleViewModel
    {
        [Display(Name = "Student Number")]
        public string TeacherId { get; set; }
        [Display(Name = "Grade Id")]
        public string GradeId { get; set; }
        public string Grade { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        [Display(Name = "Subject Id")]
        public string SubjectId { get; set; }
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
        [Display(Name = "Select")]
        public bool IsSelected { get; set; }
        public string Status { get; set; }
        public List<TeacherRoleSimpleViewModel> TeacherRoles { get; set; }
        public TeacherViewModel TeacherViewModel = new TeacherViewModel();

        public TeacherRoleSimpleViewModel()
        {
            IsSelected = false;
            TeacherViewModel = new TeacherViewModel();
            TeacherRoles = new List<TeacherRoleSimpleViewModel>();
        }

    }
}