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
    public class SubjectResultController : Controller
    {
        private ISubjectResultRepository repository;
        private IStudentMarksRepository studentMarksRepository;
        public SubjectResultController(ISubjectResultRepository repository, IStudentMarksRepository studentMarksRepository)
        {
            this.repository = repository;
            this.studentMarksRepository = studentMarksRepository;
        }

        #region Pre Update
        [HttpPost]
        public ActionResult PreUpdate(SubjectResult model)
        {
            return PartialView("_UpdateSubjectResult", model);
        }
        #endregion


        #region Save Update
        [HttpPost]
        public ActionResult Update(SubjectResult model)
        {
            try
            {
                //StudentSubjectMarks model = new StudentSubjectMarks()
                //{
                //    StudentId = _model.StudentId,
                //    GradeId = _model.GradeId,
                //    ExamType = _model.ExamType,
                //    SubjectId = _model.SubjectId,
                //    MarkValue = _model.Marks,
                //    ExamDate = _model.ExamDate
                //};
         repository.Update(model);
        //studentMarksRepository.Update(model);
                return Json(new { result = "true", message = "Data updated Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}