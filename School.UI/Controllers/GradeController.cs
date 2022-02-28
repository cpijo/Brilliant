using School.Common.PagingHelper;
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
            List<Grades> _model = gradesRepository.GetAll();
            int totalData = _model.Count();
            List<Grades> model = _model.Take(10).ToList();
            childPage cpage = new childPage();
            cpage.StartPage = 1;
            cpage.CurrentPage = 1;
            cpage.EndPage = 5;
            cpage.TotalItems = totalData;
            cpage.TotalPages = (totalData / 10);
            Pager pager = new Pager(cpage, totalData, 1, 10, 5);
            Session["pager"] = pager;

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
        public ActionResult SaveRecord(Grades model)
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
        public ActionResult UpdateView(Grades model)
        {
            model.oldGradeId = model.GradeId;
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

    }
}
