using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Entities.Fields
{
    public class Subject
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Marks { get; set; }
        public string oldSubjectId { get; set; }
    }
    public class SubjectResult
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Marks { get; set; }
        public string Symbol { get; set; }
        public string StudentId { get; set; }
    }
}