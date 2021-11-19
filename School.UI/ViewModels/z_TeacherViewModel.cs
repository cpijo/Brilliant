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
    public class z_TeacherViewModel
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


        public z_TeacherViewModel()
        {
            Teacher = new Teacher();
            Address = new Address();
            Teachers = new List<Teacher>();
            Grades = new Grades();
            ClassOrCourse = new ClassOrCourse();
            DropboxModel = new DropboxModel();
            //ClassOrCourseDropboxItemList = new SelectList( new[] {  new SelectListItem{ Value = "Select", Text = "--Select--"},
            //                                                        new SelectListItem{ Value = "ClassSie008", Text = "Physics Sience 8"},
            //                                                        new SelectListItem{ Value = "ClassBus008", Text = "Business 8"},
            //                                                        new SelectListItem{ Value = "ClassAcc008", Text = "Accounting 8"}
            //                                                     });

            ClassOrCourseDropboxItemList = new SelectList(new[]
            {
                new { Value = "Select", Text = "--Select--", Group = "Grade8" },
                new { Value = "ClassSie008", Text = "Physics Sience 8", Group = "Grade8" },
                new { Value = "ClassBus008", Text = "Business 8", Group = "Grade8" },
                new { Value = "ClassAcc008", Text = "Accounting 8", Group = "Grade8" },
            });
        }



        public List<SelectListItem> lists()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Value = "Select", Text = "--Select--"},
                new SelectListItem{ Value = "ClassSie008", Text = "Physics Sience 8"},
                new SelectListItem{ Value = "ClassBus008", Text = "Business 8"},
                new SelectListItem{ Value = "ClassAcc008", Text = "Accounting 8"}
            };

            return list;
        }

        public IEnumerable myClasses()
        {
            IEnumerable items = new[]
            {
                new { Value = "Select", Text = "--Select--", Group = "Grade8" },
                new { Value = "ClassSie008", Text = "Physics Sience 8", Group = "Grade8" },
                new { Value = "ClassBus008", Text = "Business 8", Group = "Grade8" },
                new { Value = "ClassAcc008", Text = "Accounting 8", Group = "Grade8" },
            };

            return items;
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



        public List<SelectListItem> lists_()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            Dictionary<string, string> lst = new Dictionary<string, string>();
            lst.Add("Select", "-Select-");
            lst.Add("ClassSie008", "Physics Sience 8");
            lst.Add("ClassBus008", "Business 8");
            lst.Add("ClassAcc008", "Accounting 8");

            // Arrange
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



            var Staff = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text = "Mike"},
                new SelectListItem{ Value = "2", Text = "Pete"},
                new SelectListItem{ Value = "3", Text = "Katy"},
                new SelectListItem{ Value = "4", Text = "Dean"}
            };


            List<SelectListItem> regions = new List<SelectListItem>()
            {

                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };


            return Staff;
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


    }
}