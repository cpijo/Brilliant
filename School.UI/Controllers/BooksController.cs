using School.Entities.Fields;
using School.Entities.Fields.StudyMaterial;
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
    public class BooksController : BaseController
    {
        string Filelocation = System.Configuration.ConfigurationManager.AppSettings["books.DownloadFolder"];
        private IBooksRepository gradesRepository;
        public BooksController(IBooksRepository gradesRepository)
        {
            this.gradesRepository = gradesRepository;
        }

        #region Get Grades
        [HttpGet]
        public ActionResult ViewRecord()
        {
            List<Books> model = gradesRepository.GetAll();
            return PartialView("_ViewBooks", model);
        }
        #endregion
        #region Get Grades
        [HttpGet]
        public ActionResult SearchRecord()
        {
            List<Books> model = gradesRepository.GetAll();
            return PartialView("_TableBooks", model);
        }
        #endregion

        //#region Download Books
        //public virtual ActionResult DownloadFile(string Filelocation, string Filename)
        //{
        //    Filelocation = this.Filelocation;
        //    return base.Download(Filelocation, Filename);
        //}
        //#endregion

    }
}
