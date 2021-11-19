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
    public class StudentPaymentController : BaseController
    {
        //https://developer.paygate.co.za/products/apiL

        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;


        public StudentPaymentController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
        }

        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Student> model = new List<Student>();
            return PartialView("_StudentPayment", model);
        }
        #endregion


        #region Get Student
        [HttpPost]
        public ActionResult PrePaymant()
        {
            List<Student> model = new List<Student>();
            return PartialView("_StudentPayment", model);
        }
        #endregion

        #region Post Student
        [HttpGet]
        public ActionResult viewStudentPayment()
        {
            List<StudentResults> model = studentResultsRepository.GetAll();
            return PartialView("_ViewStudentPayment", model);
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

    }
}

