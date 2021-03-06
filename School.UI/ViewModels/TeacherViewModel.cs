using School.Entities.Fields;
using School.UI.Models.StudentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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


        public TeacherViewModel()
        {
            Teacher = new Teacher();
            Address = new Address();
            Teachers = new List<Teacher>();
            Grades = new Grades();
            ClassOrCourse = new ClassOrCourse();
            DropboxModel = new DropboxModel();
            ClassOrCourseDropboxItemList = mySelectList();
        }

        public void getDefaults()
        {
            Teacher.TeacherId = Guid.NewGuid().ToString();
            Teacher.CreatedDate = DateTime.Today;
            Teacher.CreatedDate = DateTime.Today;
            Address.StudentId = Teacher.TeacherId;
            Address.CreatedDate = Teacher.CreatedDate;
            Address.CreatedDate = Teacher.CreatedDate;
        }

        public SelectList mySelectList()
        {
            IEnumerable items = new[]
            {
                new { Value = "Select", Text = "--Select--", Group = "Grade8" },
                new { Value = "ClassSie008", Text = "Physics Sience 8", Group = "Grade8" },
                new { Value = "ClassBus008", Text = "Business 8", Group = "Grade8" },
                new { Value = "ClassAcc008", Text = "Accounting 8", Group = "Grade8" },
            };

            SelectList selectList = new SelectList(items,
                                                    "Value",
                                                    "Text",
                                                    "Group"
                                                    );

            return selectList;
        }
    }
}