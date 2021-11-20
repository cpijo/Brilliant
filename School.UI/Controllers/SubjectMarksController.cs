using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.MySecurity;
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
    public class SubjectMarksController : Controller
    {
        private ISubjectRepository courseRepository;
        public SubjectMarksController(ISubjectRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        #region Get Course
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Subject> model = courseRepository.GetAll();
            return PartialView("_TableSubject", model);
        }
        #endregion

        #region Get Course
        [HttpGet]
        public ActionResult GetSubject()
        {
            List<Subject> model = courseRepository.GetAll();
            return PartialView("_TableSubject", model);
        }
        #endregion

        #region Add New Record
        [HttpGet]
        public ActionResult AddRecord(Subject model)
        {
            return PartialView("_AddSubject", model);
        }
        #endregion
        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(Subject model)
        {
            try
            {
                model.SubjectId = Guid.NewGuid().ToString();
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

        #region Add New Record
        [HttpPost]
        public ActionResult UpdateView(Subject model)
        {
            return PartialView("_UpdateSubject", model);
        }
        #endregion

        #region Save Update Marks
        [HttpPost]
        public ActionResult Update(Subject model)
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
