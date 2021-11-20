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
    public class GradeTeacherController : Controller
    {
        private IGradeTeacherRepository gradesRepository;
        private ISubjectTeacherRepository subjectRepository;
        public GradeTeacherController(IGradeTeacherRepository gradesRepository, ISubjectTeacherRepository subjectRepository)
        {
            this.gradesRepository = gradesRepository;
            this.subjectRepository= subjectRepository;
        }

        #region Get Grades
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Grades> model = gradesRepository.GetAll();
            return PartialView("_TableGrade", model);
        }
        #endregion
        #region Get Record By Id
        [HttpPost]
        public ActionResult GetRecordById_simple(string userId,string Firstname)
        {
            List<Grades> model = gradesRepository.GetById(userId);
            return PartialView("_ViewGradeStudent", model);
            //return PartialView("_TableGradeTeacher", model);
        }
        #endregion

        #region Get Record By Id
        [HttpPost]
        public ActionResult GetGradeAndStudentById(string userId,string Firstname)
        {

            List<Grades> model = gradesRepository.GetById(userId);

            //List<Grades> model = gradesRepository.GetById(userId, Firstname);
            GradeStudent modelList = new GradeStudent();
            modelList.Grades = model;
            List<Subject> subjects = subjectRepository.GetById(userId, "");
            modelList.Subjects = subjects;

            return PartialView("_ViewGradeStudent", modelList);
            //return PartialView("_TableGradeTeacher", model);
        }
        #endregion

        //#region Get Grade Teacher By Id
        //[HttpPost]
        //public ActionResult GetGradeTeacherById(string userId, string Firstname)
        //{
        //    List<Grades> model = gradesRepository.GetById(userId);
        //    return PartialView("_TableGradeTeacher", model);
        //}
        //#endregion


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
                model.GradeId = Guid.NewGuid().ToString();
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
