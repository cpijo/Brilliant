using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Entities.Fields
{
    public class StudentResults
    {
        //SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName ,m.SubjectId,sb.SubjectName,m.MarkValue
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string RegisteredId { get; set;}
        public string GradeId { get; set; }
        public string GradeName { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string MarkValue { get; set; }


        public string Email { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Course Code")]
        public string CourseId { get; set; }
        [Display(Name = "Course Description")]
        public string CourseName { get; set; }
        public string Grade{ get; set;}

    }
    public class StudentResultsModel
    {
        public Student Student { get; set; }
        public StudentResults StudentResults { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<SubjectResult> SubjectResult { get; set; }
        public StudentResultsModel()
        {
            Student = new Student();
            StudentResults = new StudentResults();
            Subjects = new List<Subject>();
            SubjectResult = new List<SubjectResult>();
        }
    }

    public class StudentAttendance
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeId { get; set; }
        public string SubjectId { get; set; }
        //public string AttendanceStatus { get; set; } = "Not Assign";

        private string _attendanceStatus;
        public string AttendanceStatus
        {
            get
            {
                return string.IsNullOrEmpty(_attendanceStatus) ? "not assign" : _attendanceStatus;
            }

            set {
                _attendanceStatus = value;
            }
        }

        //public string ExamQuarter { get; set; }
        //public string MarkValue { get; set; }
        //public string ExamType { get; set; }
    }

    public class Coordinate
    {
        public int X { get; set; } = 34; // get or set auto-property with initializer

        public int Y { get; } = 89;      // read-only auto-property with initializer

        public int Z { get; }            // read-only auto-property with no initializer
                                         // so it has to be initialized from constructor    

        public Coordinate()              // .ctor()
        {
            Z = 42;
        }

        private string name;
        public string Name
        {
            get
            {
                if (name == null)
                {
                    name = "Default Name";
                }
                return name;
            }
            set
            {
                name = value;
            }
        }

    }

    public class StudentSubjectMarks
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeId { get; set; }
        public string ExamQuarter { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string MarkValue { get; set; }
        public string ExamType { get; set; }
        public string Symbol { get; set; }
        public string ExamDate { get; set; }
    }

    public class StudentRegister_Attendence
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeId { get; set; }
        public string School { get; set; }
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
        public string RegisterDate { get; set; }
    }
    public class StudentAttendence
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeId { get; set; }
        public string School { get; set; }
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
        public string RegisterDate { get; set; }
    }



    public class StudentSubjectMarks0
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Grades Grade { get; set; }
    }
    public class StudentSubjectMarks_1
    {
        //public string StudentId { get; set; }
        //public string Firstname { get; set; }
        //public string Surname { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Marks { get; set; }
        public Student Student { get; set; }

        public List<Student> Students { get; set; }


        //public List<Student> Students { get; set; }      
        //public List<Subject> Subjects { get; set; }
        //public List<StudentSubjectMarks> StudentSubjectMarksList { get; set; }

        //public StudentSubjectMarks()
        //{
        //    //Students = new List<Student>();
        //    Subjects = new List<Subject>();
        //}


        public StudentSubjectMarks getStudentSubjectMarks(Student Student)
        {

            return new StudentSubjectMarks();
        }
        public List<StudentSubjectMarks> getStudentSubjectMarksList(Student Student)
        {

            return new List<StudentSubjectMarks>();
        }
    }
}