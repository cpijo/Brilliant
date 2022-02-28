using School.Common.PagingHelper;
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
            List<Subject> _model = subjectRepository.GetAll();
            int totalData = _model.Count();
            List<Subject> model = _model.Take(10).ToList();
            childPage cpage = new childPage();
            cpage.StartPage = 1;
            cpage.CurrentPage = 1;
            cpage.EndPage = 5;
            cpage.TotalItems = totalData;
            cpage.TotalPages = (totalData / 10);
            Pager pager = new Pager(cpage, totalData, 1, 10, 5);
            Session["pager"] = pager;
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
        public ActionResult SaveRecord(Subject model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SubjectId))
                {
                    model.SubjectId = Guid.NewGuid().ToString();
                }

                subjectRepository.Save(model);
                bool status = subjectRepository.IsSuccess();

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
        public ActionResult UpdateView(Subject model)//UpdateView
        {
            model.oldSubjectId = model.SubjectId;
            return PartialView("_UpdateSubject", model);
        }
        #endregion

        #region Update Record
        [HttpPost]
        public ActionResult Update(Subject model)//UpdateRecord
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