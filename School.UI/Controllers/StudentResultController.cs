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
        private IStudentMarksRepository studentMarksRepository;
        public StudentResultController(IStudentResultsRepository studentResultsRepository, ISubjectRepository subjectRepository,
            ISubjectResultRepository subjectResultRepository, IStudentMarksRepository studentMarksRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.subjectRepository = subjectRepository;
            this.subjectResultRepository = subjectResultRepository;
            this.studentMarksRepository = studentMarksRepository;
        }

        #region Get Record
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


        #region Get Record
        [HttpGet]
        public ActionResult SearchRecord()
        {
            return PartialView("_ViewStudent");
        }
        #endregion


        #region Pre UpdateRecord
        [HttpPost]
        public ActionResult PreUpdate(StudentSubjectMarks model)
        {
            return PartialView("_UpdateSubjectMarks", model);
        }
        #endregion

        #region Save UpdateRecord
        [HttpPost]
        public ActionResult Update(StudentSubjectMarks model)
        {
            try
            {
                model.GradeId = CostantData.getFieldId(CostantData.dictGrades(), model.GradeId.Trim());
                studentMarksRepository.Update(model);
                return Json(new { result = "true", message = "Data updated Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
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


        #region Search By Lastname
        [HttpPost]
        public ActionResult SearchByLastName(string studentName, string StudentId, string gradeId, string queryType = "searchByGradeAndName")
        {
            gradeId = CostantData.getFieldId(CostantData.dictGrades(), gradeId);
            dynamic _dynamic = new ExpandoObject();
            //_dynamic.StudentId = "StudentId";
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
            studentResult.GradeName = studentResult.CourseId;
            studentResult.GradeId = studentResult.CourseId;
            model.StudentResults = studentResult;
            model.Student = student;
            model.SubjectResult = subjectResult;
            //model.Subjects = subjects;
            return PartialView("_StudentSubjectResult", model);
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
