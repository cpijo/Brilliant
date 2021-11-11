using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Entities.Fields
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }


    public class AssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }

}