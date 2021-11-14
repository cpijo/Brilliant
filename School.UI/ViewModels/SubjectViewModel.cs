using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.ViewModels
{

    public class SubjectViewModel: Subject
    {
        public string Grade { get; set; }
        public SelectList GradeDropboxItemList { get; set; }
        public string Class { get; set; }
        public SelectList ClassDropboxItemList { get; set; }
    }
}