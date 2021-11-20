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
    public class SubjectTeacherController : Controller
    {
        private ISubjectTeacherRepository subjectRepository;
        public SubjectTeacherController(ISubjectTeacherRepository repository)
        {
            this.subjectRepository = repository;
        }

        #region Get Course
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Subject> model = subjectRepository.GetAll();
            return PartialView("_TableSubject", model);
        }
        #endregion

        #region Get Course
        [HttpGet]
        public ActionResult GetSubject()
        {
            List<Subject> model = subjectRepository.GetAll();
            return PartialView("_TableSubject", model);
        }
        #endregion

        #region Get Subject Teacher By Id
        [HttpPost]
        public ActionResult GetSubjectByTeacher(string userId, string GradeId)
        {
            List<Subject> model = subjectRepository.GetById(userId, GradeId);
            return PartialView("_TableSubjectTeacher", model);
        }
        #endregion



        #region Get Subject Teacher By Id
        [HttpPost]
        public ActionResult GetRecordById(string userId,string GradeId, string Firstname)
        {
            string gradeAndTeacher = GradeId + "," + userId;
            List<Subject> model = subjectRepository.GetById(gradeAndTeacher);
            return PartialView("_TableSubjectTeacher", model);
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
                subjectRepository.Save(model);

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

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Subject model)
        {
            try
            {
                subjectRepository.Update(model);
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