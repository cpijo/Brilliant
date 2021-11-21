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
    public class GradeClassController : Controller
    {
        private IGradeClassRepository gradesRepository;
        public GradeClassController(IGradeClassRepository gradesRepository)
        {
            this.gradesRepository = gradesRepository;
        }

        #region Get Grades
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<GradeClass> model = gradesRepository.GetAll();
            return PartialView("_TableGradeClass", model);
        }
        #endregion

        #region Get Grades
        [HttpGet]
        public ActionResult SearchRecord()
        {
            List<GradeClass> model = gradesRepository.GetAll();
            return PartialView("_TableGradeClass", model);
        }
        #endregion

        #region Add New Record
        [HttpPost]
        public ActionResult AddRecord(GradeClass model)
        {
            return PartialView("_AddGradeClass", model);
        }
        #endregion


        #region Save Student Results 
        [HttpPost]
        public ActionResult SaveRecord(GradeClass model)
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
        public ActionResult UpdateView(GradeClass model)
        {
           // model.oldGradeId = model.GradeId;
            return PartialView("_UpdateGradeClass", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(GradeClass model)
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

    }
}
