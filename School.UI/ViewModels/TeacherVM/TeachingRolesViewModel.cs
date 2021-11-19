using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.UI.ViewModels.TeacherVM
{
    public class TeachingRolesViewModel
    {
        public TeachingRoles TeachingRoles { get; set; }
        public List<TeachingRoles> TeachingRolesList { get; set; }
        public string TeacherId { get; set; }
        public string SubjectId { get; set; }
        public string ClassId { get; set; }
        public string GradeId { get; set; }

        public TeachingRolesViewModel()
        {
            TeachingRoles = new TeachingRoles();
            TeachingRolesList = new List<TeachingRoles>();
        }
    }

}