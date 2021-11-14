using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.ViewModels
{
    public class DropBoxViewModel
    {
        public string dropboxType { get; set; }

        public string Race { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Provincet { get; set; }
        public string Surbub { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Grade { get; set; }
        public string Class { get; set; }
        public string ClassOrCourse { get; set; }
        public string Subject { get; set; }

        public SelectList RaceDropboxItemList { get; set; }
        public SelectList GenderDropboxItemList { get; set; }
        public SelectList LanguageDropboxItemList { get; set; }
        public SelectList CountryDropboxItemList { get; set; }
        public SelectList ProvinceDropboxItemList { get; set; }
        public SelectList SurbubDropboxItemList { get; set; }
        public SelectList CityDropboxItemList { get; set; }
        public SelectList LocationDropboxItemList { get; set; }
        public SelectList GradeDropboxItemList { get; set; }
        public SelectList ClassDropboxItemList { get; set; }
        public SelectList ClassOrCourseDropboxItemList { get; set; }
        public SelectList SubjectDropboxItemList { get; set; }
    }
}