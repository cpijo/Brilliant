using School.Entities.Fields;
using School.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/*
namespace School.UI.Controllers
{
    
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class CourseController : Controller
    {
        private ICoursesRepository courseRepository;
        private ISubjectRepository subjectRepository;
        public CourseController(ICoursesRepository courseRepository, ISubjectRepository subjectRepository)
        {
            this.courseRepository = courseRepository;
            this.subjectRepository = subjectRepository;
        }

        #region Get Course
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Course> model = courseRepository.GetAll();
            return PartialView("_TableCourse", model);
        }
        #endregion

        #region Add New Record
        [HttpPost]
        public ActionResult GetSubjects(Course _model)
        {
            //return RedirectToAction("GetSubject", "Subject", new { courseId = model.CourseId, courseName = model.CourseName });
            List<Subject> model = subjectRepository.GetAll();
            return PartialView("_TableSubject", model);
        }
        #endregion


        #region Add New Record
        [HttpGet]
        public ActionResult AddRecord(Course model)
        {
            return PartialView("_AddCourse", model);
        }
        #endregion
        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(Course model)
        {
            try
            {
                model.CourseId = Guid.NewGuid().ToString();
                courseRepository.Save(model);

                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);

                //return RedirectToAction("GetStudentResults", "Student");
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Add New UpdateView
        [HttpPost]
        public ActionResult UpdateView(Course model)
        {
            return PartialView("_UpdateCourse", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Course model)
        {
            try
            {
                courseRepository.Update(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        

    }
}

 */
