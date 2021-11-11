using School.Entities.Fields;
using School.UI.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public Address Address { get; set; }
        public Grades Grades { get; set; }
        public ClassOrCourse ClassOrCourse { get; set; }
        public AssignTeacher AssignTeacher { get; set; }
        public DropboxModel DropboxModel { get; set; }
        public SelectList RaceDropboxItemList { get; set; }
        public SelectList GenderDropboxItemList { get; set; }
        public SelectList LookingForDropboxItemList { get; set; }
        public SelectList LanguageDropboxItemList { get; set; }
        public SelectList CountryDropboxItemList { get; set; }
        public SelectList ProvinceDropboxItemList { get; set; }
        public SelectList SurbubDropboxItemList { get; set; }
        public SelectList GradeDropboxItemList { get; set; }
        public SelectList ClassOrCourseDropboxItemList { get; set; }
        public SelectList CityDropboxItemList { get; set; }
        public SelectList LocationDropboxItemList { get; set; }

        //public string UnkownItem { get; set; }
        //public SelectList UnkownItemList { get; set; }

        public StudentViewModel()
        {
            Student = new Student();
            Address = new Address();
            Grades = new Grades();
            ClassOrCourse = new ClassOrCourse();
            AssignTeacher = new AssignTeacher();
            DropboxModel = new DropboxModel();
        }

        public void getDefaults()
        {
            Student.StudentId = Guid.NewGuid().ToString();
            Student.CreatedDate = DateTime.Today;
            Student.CreatedDate = DateTime.Today;
            Address.StudentId = Student.StudentId;
            Address.CreatedDate = Student.CreatedDate;
            Address.CreatedDate = Student.CreatedDate;
            //AssignTeacher.IsAssign = true;
        }

        public StudentGrade getStudentGrade()
        {
            StudentGrade sg = new StudentGrade();
            sg.StudentId = Student.StudentId;
            sg.CreatedDate = Student.CreatedDate;
            sg.CreatedDate = Student.CreatedDate;
            //sg.GradeId = CostantData.getFieldId("");
            return sg;
        }

    }
}