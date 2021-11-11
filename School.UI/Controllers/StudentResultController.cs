using Newtonsoft.Json;
using School.Common.Constants;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class StudentResultController : BaseController
    {
        private IStudentResultsRepository studentResultsRepository;
        private ISubjectRepository subjectRepository;
        private ISubjectResultRepository subjectResultRepository;
        public StudentResultController(IStudentResultsRepository studentResultsRepository, ISubjectRepository subjectRepository,
            ISubjectResultRepository subjectResultRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.subjectRepository = subjectRepository;
            this.subjectResultRepository = subjectResultRepository;
        }
        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<StudentResults> _model = studentResultsRepository.GetAll();
            StudentResultsVM model = new StudentResultsVM();
            model.StudentResultsList = _model;
            Dictionary<string, string> GradeDictionary = CostantData.dictGrades();
            List<SelectListItem>  list = dropdownHelper(GradeDictionary);
            model.GradeDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_ViewStudent", model);
        }
        #endregion
        #region Search By Dropbox
        [HttpPost]
        public ActionResult SearchByDropBox(string selectedValue, string StudentId, string GradeId, string queryType = "searchByGrade")
        {
            GradeId = CostantData.getFieldId(CostantData.dictGrades(), GradeId);
            dynamic _dynamic = new ExpandoObject();
            _dynamic.GradeId = GradeId; _dynamic.queryType = queryType;           
            List<StudentResults> _model = studentResultsRepository.GetByAny(_dynamic);
            return PartialView("_TableStudentSeachResult", _model);
        }
        #endregion

        #region Search By Dropbox
        [HttpPost]
        public ActionResult SearchByDropBox_Delete(string selectedValue,string StudentId ,string GradeId ,string queryType = "searchByGrade")
        {
            GradeId = CostantData.getFieldId(CostantData.dictGrades(), GradeId);
            dynamic _dynamic = new ExpandoObject();
            _dynamic.StudentId = "StudentId"; _dynamic.GradeId = GradeId; _dynamic.queryType = queryType;
            List<StudentResults> _model = studentResultsRepository.GetByAny(_dynamic);
            return PartialView("_TableStudentSeachResult", _model);
        }
        #endregion

        #region Search By Lastname
        [HttpPost]
        public ActionResult SearchByLastName(string studentName, string StudentId, string gradeId, string queryType = "searchByGradeAndName")
        {
            gradeId = CostantData.getFieldId(CostantData.dictGrades(), gradeId);
            dynamic _dynamic = new ExpandoObject();
            _dynamic.StudentId = "StudentId";
            _dynamic.GradeId = gradeId;
            _dynamic.queryType = queryType;
            _dynamic.studentName = studentName;
            List<StudentResults> _model = studentResultsRepository.GetByAny(_dynamic);
            return PartialView("_TableStudentSeachResult", _model);
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
