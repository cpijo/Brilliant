using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.UI.ViewModels.TeacherVM
{
    public class TeacherTimesheetViewModel
    {
        public Teacher Teacher { get; set; }

        public TeacherTimesheetViewModel()
        {
            Teacher = new Teacher();
        }
    }
}