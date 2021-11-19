using School.Common.Constants;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.StudentModel;
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
    public class TimesheetController : Controller
    {
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;
        //private ICoursesRepository courseRepository;
        //private IGradesRepository gradesRepository;

        public TimesheetController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
            //this.courseRepository = courseRepository;
            //this.gradesRepository = gradesRepository;
        }

        #region Get Timesheet
        [HttpGet]
        public ActionResult GetRecord()
        {
            //Sage 300 people
            List<Student> _model = studentRepository.GetAll();
            return PartialView("_ViewTimesheet", _model);
        }
        #endregion

        #region Get Student By Filter
        [HttpPost]
        public ActionResult SearchRecord(string selectedValue)
        {
            List<Student> _model = studentRepository.GetAll();
            
            return PartialView("_TableStudent", _model);
        }
        #endregion

        private static List<SelectListItem> dropdownHelper(Dictionary<string, string> SurbubDictionary)
        {
            return SurbubDictionary
            .Select(item => new SelectListItem
            {
                Value = item.Key.ToString(),
                Text = item.Value.ToString(),
                Selected = true
            })
            .ToList();
        }
    }
}

