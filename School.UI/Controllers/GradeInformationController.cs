using School.Entities.Fields;
using School.Services.Interface;
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
    public class GradeInformationController : Controller
    {
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;
        //private ICoursesRepository courseRepository;
        //private IGradesRepository gradesRepository;

        public GradeInformationController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
            //this.courseRepository = courseRepository;
            //this.gradesRepository = gradesRepository;
        }

        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Student> _model = studentRepository.GetAll();
            return PartialView("_ViewStudent", _model);
            //return PartialView("_TableStudent", _model);
        }
        #endregion

        #region Get Student By Filter
        [HttpPost]
        public ActionResult SearchRecord(string selectedValue)
        {
            List<Student> _model = studentRepository.GetAll();
            
            return PartialView("_TableStudent", _model);
        }
        #endregion


        #region Add New Record
        [HttpGet]
        public ActionResult AddRecord(Student model)
        {
            return PartialView("_AddStudent", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(Student model)
        {
            try
            {
                model.StudentId = Guid.NewGuid().ToString();
                studentRepository.Save(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("GetStudentResults", "Student");
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Add New Record
        [HttpPost]
        public ActionResult PreDradeInformation(Student model, string StudentId, string Firstname, string Surname)
        {            
            return PartialView("_defaultDashboard", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Student model)
        {
            try
            {
                studentRepository.Save(model);
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
       /* */
    }
}

