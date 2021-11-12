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
    public class DashboardController : Controller
    {
        private ICoursesRepository courseRepository;
        private ISubjectRepository subjectRepository;
        public DashboardController(ICoursesRepository courseRepository, ISubjectRepository subjectRepository)
        {
            this.courseRepository = courseRepository;
            this.subjectRepository = subjectRepository;
        }

        #region Get Course
        [HttpGet]
        public ActionResult GetRecord()
        {
            return PartialView("_defaultDashboard");
        }
        #endregion
    }
}