using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class StudentRolesController : BaseController
    {
        private IStudentResultsRepository studentResultsRepository;
        private ISubjectRepository subjectRepository;
        private ISubjectResultRepository subjectResultRepository;
        public StudentRolesController(IStudentResultsRepository studentResultsRepository, ISubjectRepository subjectRepository,
            ISubjectResultRepository subjectResultRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.subjectRepository = subjectRepository;
            this.subjectResultRepository = subjectResultRepository;
        }
        #region Get Student
        [HttpGet]
        public ActionResult GetRoles()
        {
            List<StudentResults> _model = studentResultsRepository.GetAll();
            //return PartialView("_ViewStudent", _model);
            return PartialView("_StudentRoles", _model);
        }
        #endregion

        #region Get Student
        [HttpPost]
        public ActionResult GetStudentResult(StudentResults studentResult, string Firstname)
        {
            Student student = new Student();
            student.StudentId = studentResult.StudentId;
            student.Firstname = studentResult.Firstname;
            student.LastName = studentResult.LastName;
            student.Email = studentResult.Email;
            StudentResultsModel model = new StudentResultsModel();
            //List<Subject> subjects = subjectRepository.GetAll();
            //List<Subject> subjects = subjectRepository.GetById(student.StudentId);

            List<SubjectResult> subjectResult = subjectResultRepository.GetById(student.StudentId);

            model.StudentResults = studentResult;
            model.Student = student;
            model.SubjectResult = subjectResult;
            //model.Subjects = subjects;
            return PartialView("_StudentSubjectResult", model);
        }
        #endregion




























        #region View Student Results Page
        [HttpGet]
        public ActionResult PreGetRecord()
        {
            List<StudentResults> studentList = studentResultsRepository.GetAll();
            return PartialView("_BasePage", studentList);
        }
        #endregion



        #region Get Student
        [HttpGet]
        public ActionResult GetRecordResult()
        {
            List<StudentResults> _model = studentResultsRepository.GetAll();
            return PartialView("_ViewStudentResults", _model);
            //return PartialView("_TableStudentResults", _model);
        }
        #endregion



    }
}

