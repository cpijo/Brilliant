using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Models.StudentModel
{
    public class studentVM
    {
        public string StudentId { get; set; }
        public string fullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string present { get; set; }
        public string absent { get; set; }
        public string AttendanceStatus { get; set; }
    }

    public class teacherVM
    {
        public string DateOfAttendance { get; set; }
        public string attandance { get; set; }
        public string Grade { get; set; }
        public string SubjectName { get; set; }
    }

    public class StudentAttendanceVM
    {
        public List<studentVM> students { get; set; }
        public teacherVM teacher { get; set; }

        public string Grade { get; set; }
        public SelectList GradeDropboxItemList { get; set; }
        public string Subject { get; set; }
        public SelectList SubjectDropboxItemList { get; set; }

        public StudentAttendanceVM()
        {
            students = new List<studentVM>();
            teacher = new teacherVM();
        }
    }
        public class StudentAttendanceModel
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeId { get; set; }
        public string SubjectId { get; set; }

        public string attandance { get; set; }
        public SelectList AttendanceDropboxItemList { get; set; }
        public bool IsPresent { get; set; }
        public bool IsAbsent { get; set; }
        public string DateOfAttendance { get; set; }
        public string RecordingType { get; set; }

        public SelectList GradeDropboxItemList { get; set; }
        public SelectList ClassOrCourseDropboxItemList { get; set; }
        public SelectList SubjectDropboxItemList { get; set; }

        public List<StudentAttendance> StudentAttendance { get; set; }

        public Grades Grades { get; set; }
        public Subject Subject { get; set; }
        public ClassOrCourse ClassOrCourse { get; set; }

        private string _attendanceStatus;
        public string AttendanceStatus
        {
            get
            {
                return string.IsNullOrEmpty(_attendanceStatus) ? "not assign" : _attendanceStatus;
            }

            set
            {
                _attendanceStatus = value;
            }
        }

        public StudentAttendanceModel()
        {
            StudentAttendance = new List<StudentAttendance>(); 
        }
    }
}