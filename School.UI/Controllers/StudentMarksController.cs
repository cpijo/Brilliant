using School.Common.Constants;
using School.Common.JsonStringHelper;
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
    public class StudentMarksController : BaseController
    {
       // private IStudentMarksRepository studentSubjectMarksRepository;
        private ISubjectRepository subjectRepository;
        private IStudentMarksRepository studentMarksRepository;

        public StudentMarksController(ISubjectRepository subjectRepository,
            IStudentMarksRepository studentMarksRepository)
        {
            this.subjectRepository = subjectRepository;
            this.studentMarksRepository = studentMarksRepository;
        }

        #region Get Record
        [HttpGet]
        public ActionResult GetRecord(string teacherId, string GradeId, string examType)
        {
                dynamic _dynamic = new ExpandoObject();
                _dynamic.GradeId = "Grade8";
                _dynamic.SubjectId = "Eng008";
                _dynamic.TeacherId = "TC00000008";
                _dynamic.type = "start";

            List<StudentSubjectMarks> _StudentSubjectMarks = studentMarksRepository.GetByAny(_dynamic);
            StudentSubjectMarksVM model = new StudentSubjectMarksVM();
            model.StudentSubjectMarksList = _StudentSubjectMarks;
            Dictionary<string, string> GradeDictionary = CostantData.dictGrades();
            List<SelectListItem> list = dropdownHelper(GradeDictionary);
            model.GradeDropboxItemList = new SelectList(list, "Value", "Text", "Grade8");
            model.Subject = "English 8";
            // string _genda = model.User.Gender;
            //model.GenderDropboxItemList = new SelectList(list, "Value", "Text", _genda);

            return PartialView("_TableRecordSubjectMarks", model);
        }
        #endregion

        #region Search By Filter
        [HttpPost]
        public ActionResult SearchRecord(string searchDate, string subjectId, string GradeId, string queryType = "searchByGrade")
        {
            GradeId = CostantData.getFieldId(CostantData.dictGrades(), GradeId);
            dynamic _dynamic = new ExpandoObject();
            _dynamic.GradeId = GradeId;
            _dynamic.SubjectId = subjectId;
            _dynamic.ExamDate = searchDate;
            _dynamic.type = "existingRecords";

            List<StudentSubjectMarks> _StudentSubjectMarks = studentMarksRepository.GetByAny(_dynamic);
            StudentSubjectMarksVM model = new StudentSubjectMarksVM();
            model.StudentSubjectMarksList = _StudentSubjectMarks;
            //StudentSubjectMarksList
            if (_StudentSubjectMarks.Count == 0)
            {
                return Json(new { result = "false", message = "No records found 0n " + searchDate, title = "Empty Records" }, JsonRequestBehavior.AllowGet);
            }

            return PartialView("_TableSubjectMarksOnly", model);
        }
        #endregion


        #region Search By Filter
        [HttpPost]
        public ActionResult SaveRecord(string jsonString, string tabledata, string searchDate, string subjectId, string GradeId, string queryType = "searchByGrade")
        {
            try
            {
                GradeId = CostantData.getFieldId(CostantData.dictGrades(), GradeId);
                dynamic _dynamic = new ExpandoObject();
                _dynamic.GradeId = GradeId;
                _dynamic.SubjectId = subjectId;
                _dynamic.ExamDate = searchDate;
                _dynamic.type = "hasRecords";

                List<StudentSubjectMarks> _StudentSubjectMarks = studentMarksRepository.GetByAny(_dynamic);

                if (_StudentSubjectMarks != null)
                {
                    return Json(new { result = "false", message = $"This date {searchDate} is alread recorded in the database", title = "The date has Records" }, JsonRequestBehavior.AllowGet);
                }

                List<StudentSubjectMarks> modelList = myDeserialiseFromJson<List<StudentSubjectMarks>>.Deserialise(jsonString);
                studentMarksRepository.SaveMany(modelList);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region dropBox Update
        [HttpPost]
        public ActionResult UpdateDropBox(string selectedValue, string searchType)
        {
            #region using database still working on it
            /*
            List<Subject> subjects = new List<Subject> ();
           
            if (Session["subjects"] ==null)
            {
                subjects = gradeClassRepository.GetAll();
                Session["subjects"] = subjects;
            }
            else
            {
                subjects = gradeClassRepository.GetAll();
                Session["subjects"] = subjects;
            }

            */
            #endregion

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            StudentSubjectMarksVM model = new StudentSubjectMarksVM();
            
                     switch (selectedValue)
                    {
                case "Grade8":
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
                case "Grade9":
                    dictionary = CostantData.dictGrade9Subjects();
                            break;
                        case "Grade10":
                    dictionary = CostantData.dictGrade10Subjects();
                            break;
                        case "Grade11":
                   dictionary = CostantData.dictGrade11Subjects();
                            break;
                        case "Grade12":
                    dictionary = CostantData.dictGrade12Subjects();
                            break;
                        default:
                    dictionary = CostantData.dictGrade8Subjects();
                            break;
                    }

            List<SelectListItem> list = dropdownHelper(dictionary);
            model.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_PartialDropBox", model);
        }

        [HttpPost]
        public ActionResult UpdateTable(string gradeId, string subjectId)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            StudentSubjectMarksVM model = new StudentSubjectMarksVM();
  
            dynamic _dynamic = new ExpandoObject();
            _dynamic.GradeId = gradeId;// "Grade8";
            _dynamic.SubjectId = subjectId;// "Eng008";
            _dynamic.type = "start";

            switch (gradeId)
            {
                case "Grade8":
                    _dynamic.TeacherId = "TC00000008";
                    break;
                case "Grade9":
                    _dynamic.TeacherId = "TC00000009";
                    break;
                case "Grade10":
                    _dynamic.TeacherId = "TC00000010";
                    break;
                case "Grade11":
                    _dynamic.TeacherId = "TC00000011";
                    break;
                case "Grade12":
                    _dynamic.TeacherId = "TC00000012";
                    break;
                default:
                    _dynamic.TeacherId = "TC00000008";
                    break;
            }
       
            List<StudentSubjectMarks> _StudentSubjectMarks = studentMarksRepository.GetByAny(_dynamic);
            model.StudentSubjectMarksList = _StudentSubjectMarks;          
            return PartialView("_TableRecordSubjectMarksOnly", model);
        }

        private List<Subject> getSubjectByGrade(string selectedValue, Dictionary<string, string> dictionary)
        {
            List<Subject> subjects = Session["subjects"] as List<Subject>;
            subjects = subjects.Where(a => a.SubjectId == selectedValue).ToList();
            foreach (Subject sub in subjects)
            {
                dictionary.Add(sub.SubjectId, sub.SubjectName);
            }

            return subjects;
        }


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



        #endregion

    }
}