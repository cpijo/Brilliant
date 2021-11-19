using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Entities.Fields
{
    public class TeachingRoles
    {
        public string TeacherId { get; set; }
        public string SubjectId { get; set; }
        public string ClassId { get; set; }
        public string GradeId { get; set; }

        //public TeachingRoles(string teacherId)
        //{
        //    TeacherId = teacherId;
        //}
    }

}