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
    public class GradeController : Controller
    {
        private IGradesRepository gradesRepository;
        public GradeController(IGradesRepository gradesRepository)
        {
            this.gradesRepository = gradesRepository;
        }

        #region Get Grades
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Grades> model = gradesRepository.GetAll();
            return PartialView("_TableGrade", model);
        }
        #endregion

        #region Add New Record
        [HttpGet]
        public ActionResult AddRecord(Grades model)
        {
            return PartialView("_AddGrade", model);
        }
        #endregion


        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(Grades model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.GradeId))
                {
                    model.GradeId = Guid.NewGuid().ToString();
                }

                gradesRepository.Save(model);

                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Add New Record
        [HttpPost]
        public ActionResult PreUpdate(Grades model)
        {
            return PartialView("_UpdateGrade", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Grades model)
        {
            try
            {
                gradesRepository.Update(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        //#region Get Record By Id
        //[HttpPost]
        //public ActionResult GetRecordById(string userId,string Firstname)
        //{
        //    List<Grades> model = gradesRepository.GetById(userId);
        //    return PartialView("_TableGrade", model);
        //}
        //#endregion

    }
}
