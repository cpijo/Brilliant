using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.MySecurity;
using School.UI.Models.StudentModel;
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
    [userPagePermissionAttribute(permissionID = new int[] { 500 })]
    public class StudentAttendanceController : BaseController
    {
        private IStudentAttendanceRepository studentAttendanceRepository;
        public StudentAttendanceController(IStudentAttendanceRepository studentAttendanceRepository)
        {
            this.studentAttendanceRepository = studentAttendanceRepository;
        }

        #region Get Record
        [HttpGet]
        public ActionResult GetRecord()
        {

            List<StudentAttendance> model = studentAttendanceRepository.GetById("");
            StudentAttendanceModel mod = new StudentAttendanceModel();
            mod.StudentAttendance = model;
            Dictionary<string, string> dictionary = CostantData.dictGrades();
            List<SelectListItem> list = dropdownHelper(dictionary);
            mod.GradeDropboxItemList = new SelectList(list, "Value", "Text");

            dictionary = new Dictionary<string, string>();
            dictionary = CostantData.dictAllSubjects();
            list = dropdownHelper(dictionary);
            mod.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            dictionary = new Dictionary<string, string>();
            dictionary.Add("daily", "Daily");
            dictionary.Add("weekly", "Weekly");
            list = dropdownHelper(dictionary);
            mod.AttendanceDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_ViewStudentAttendance", mod);
        }
        #endregion

        #region Save Record
        [HttpPost]
        public ActionResult SaveRecord(string jsonString)
        {
            try
            {
                List<StudentAttendance> model = myDeserialiseFromJson<List<StudentAttendance>>.Deserialise(jsonString);
                //StudentAttendanceModel model = JsonConvert.DeserializeObject<StudentAttendanceModel>(jsonString);

                // model.StudentId = Guid.NewGuid().ToString();
                //studentRepository.Save(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("GetStudentResults", "Student");
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
            StudentAttendanceModel model = new StudentAttendanceModel();
            Dictionary<string, string> dictionary = getSubjects(selectedValue);

            List<SelectListItem> list = dropdownHelper(dictionary);
            model.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_PartialDropBox", model);
        }
        #endregion

        [HttpPost]
        public ActionResult UpdateTable(string gradeId, string subjectId, string attendanceDate, string examType)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            
            dynamic _dynamic = new ExpandoObject();
            _dynamic.GradeId = gradeId;// "Grade8";
            _dynamic.SubjectId = subjectId;// "Eng008";
            _dynamic.TeacherId = "TC00000008";
            //_dynamic.ExamType = examType;// "Eng008";
            _dynamic.AttendanceDate = attendanceDate;// "Eng008";
            //_dynamic.queryType = "markRegister";
            _dynamic.type = "markRegister";

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

            List<StudentAttendance> _StudentSubjectMarks = studentAttendanceRepository.GetByAny(_dynamic);
            StudentAttendanceModel model = new StudentAttendanceModel();
            model.StudentAttendance = _StudentSubjectMarks;
            return PartialView("_TableStudentAttendance", model);
        }
























        [HttpPost]
        public ActionResult Save_0000(Student inputModel)
        {
            if (ModelState.IsValid)
            {
                string message = string.Format("Created user '{0}' aged '{1}' in the system."
                  , inputModel.Firstname, inputModel.Age);
                return Json(new Student { Firstname = message });
            }
            else
            {
                string errorMessage = "<div class=\"validation-summary-errors\">"
                  + "The following errors occurred:<ul>";
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        errorMessage += "<li class=\"field-validation-error\">"
                         + error.ErrorMessage + "</li>";
                    }
                }
                errorMessage += "</ul>";
                return Json(new Student { Firstname = errorMessage });
            }
        }

    }
}

