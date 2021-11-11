using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.ViewModels
{
    public class StudentResultsVM
    {
        public StudentResults StudentResults { get; set; }
        public List<StudentResults> StudentResultsList { get; set; }
        public string Grade { get; set; }
        public SelectList GradeDropboxItemList { get; set; }

        public StudentResultsVM()
        {
           StudentResults = new StudentResults();
           StudentResultsList = new List<StudentResults>();
        }
    }
}