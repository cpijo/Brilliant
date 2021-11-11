using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.ViewModels
{
    public class StudentSubjectMarksVM
    {
        public StudentSubjectMarks StudentSubjectMarks { get; set; }
        public List<StudentSubjectMarks> StudentSubjectMarksList { get; set; }
        public string Grade { get; set; }
        public SelectList GradeDropboxItemList { get; set; }
        public string Subject { get; set; }
        public SelectList SubjectDropboxItemList { get; set; }

        public StudentSubjectMarksVM()
        {
            StudentSubjectMarks = new StudentSubjectMarks();
            StudentSubjectMarksList = new List<StudentSubjectMarks>();
        }
    }
}