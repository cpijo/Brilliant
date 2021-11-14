using School.Entities.Fields;
using School.Services.Interface;
using School.UI.ViewModels;
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
    public class SubjectController : Controller
    {
        private ISubjectRepository subjectRepository;
        public SubjectController(ISubjectRepository courseRepository)
        {
            this.subjectRepository = courseRepository;
        }

        #region Get Record
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Subject> model = subjectRepository.GetAll();
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
        #region Save Subject Results 
        [HttpPost]
        public ActionResult Save(Subject model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SubjectId))
                {
                    model.SubjectId = Guid.NewGuid().ToString();
                }




                subjectRepository.Save(model);

                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Pre Update Record
        [HttpPost]
        public ActionResult PreUpdate(Subject model)
        {
            model.oldSubjectId = model.SubjectId;
            return PartialView("_UpdateSubject", model);
        }
        #endregion

        #region Update Record
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

        
        //#region Get Course
        //[HttpGet]
        //public ActionResult GetSubject()
        //{
        //    List<Subject> model = subjectRepository.GetAll();
        //    return PartialView("_TableSubject", model);
        //}
        //#endregion

        //#region Get Subject Teacher By Id
        //[HttpPost]
        //public ActionResult GetGradeTeacherById(string userId, string Firstname)
        //{
        //    List<Subject> model = subjectRepository.GetById(userId);
        //    return PartialView("_TableGradeTeacher", model);
        //}
        //#endregion   
    }
}