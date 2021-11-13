using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
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
    public class StudentAttendanceController : BaseController
    {
        private IStudentAttendanceRepository studentAttendanceRepository;
        private IStudentSubjectMarksRepository studentSubjectMarksRepository;

        public StudentAttendanceController(IStudentAttendanceRepository studentAttendanceRepository,IStudentSubjectMarksRepository studentSubjectMarksRepository)
        {
            this.studentAttendanceRepository = studentAttendanceRepository;
            this.studentSubjectMarksRepository = studentSubjectMarksRepository;
        }

        #region Get Record
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<StudentAttendance> model = studentAttendanceRepository.GetById("");
            StudentAttendanceModel mod = new StudentAttendanceModel();
            //mod.StudentAttendance = new List<StudentAttendance>();
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

        #region dropBox Update
        [HttpPost]
        public ActionResult dropBoxUpdate(string selectedValue, string searchType)
        {
            StudentAttendanceModel model = new StudentAttendanceModel();
            Dictionary<string, string>  dictionary = getSubjects(selectedValue);

            List<SelectListItem> list = dropdownHelper(dictionary);
            model.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_PartialDropBox", model);
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





/*

        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Courses.Add(course);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(course);
        }

   
        [HttpPost]
        public ActionResult Save_simpler(List<string> rows, FormCollection collection)
        {
            //model = "{"_data":{"DateOfAttendance":"2021/10/12","attandance":"weekly","Grade":"Grade10","SubjectName":"ven008"}}"


            int totalRows = Convert.ToInt32(collection["TotalRows"]);

            rows.ForEach(x =>
            {
                var row = x.Split('-');
                var id = row[0];
                var name = row[1];
                var family = row[2];
            });
            return null;
        }









        #region Add New Record
        [HttpPost]
        public ActionResult PreUpdate(Student model, string StudentId, string Firstname, string Surname)
        {            
            return PartialView("_UpdateStudent", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Student model)
        {
            try
            {
                //studentRepository.Save(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region Get Student
        [HttpPost]
        public ActionResult GetStudentSubject(StudentResults studentResult, string Firstname)
        {
            Student student = new Student();
            student.StudentId = studentResult.StudentId;
            student.Firstname = studentResult.Firstname;
            student.LastName = studentResult.LastName;
            student.Email = studentResult.Email;
            StudentResultsModel model = new StudentResultsModel();
            //List<Subject> subjects = subjectRepository.GetAll();
            //List<Subject> subjects = subjectRepository.GetById(student.StudentId);

            //List<SubjectResult> subjectResult = subjectResultRepository.GetById(student.StudentId);

            //model.StudentResults = studentResult;
            //model.Student = student;
            //model.Subjects = subjects;
            return PartialView("_StudentResults", model);
        }
        #endregion

         */
    }
}

