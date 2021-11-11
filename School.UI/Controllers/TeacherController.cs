using School.Common.Constants;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.StudentModel;
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
    public class TeacherController : Controller
    {
        private ITeacherRepository studentRepository;
        public TeacherController(ITeacherRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        /*
        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Teacher> model = studentRepository.GetAll();
            Session["teacher"] = model;
            return PartialView("_ViewTeacher", model);
        }
        #endregion


        #region View Student
        [HttpPost]
        public ActionResult ViewTeacher(string userId)
        {
         
            Teacher teacher = null;
            if (Session["teacher"] != null)
            {
                List<Teacher> teachers = Session["teacher"] as List<Teacher>;
                teacher = teachers.ToList().Where(x => x.TeacherId == userId).FirstOrDefault();
            }
            else
            {
                List<Teacher> students = studentRepository.GetAll();
                teacher = students.ToList().Where(x => x.TeacherId == userId).FirstOrDefault();
            }

            TeacherViewModel model = new TeacherViewModel();
            model.Teacher = teacher;

            return PartialView("_ViewTeacherInfor", model);
        }
        #endregion

        */


        #region Get Student By Filter
        [HttpPost]
        public ActionResult SearchRecord(string selectedValue)
        {
            List<Teacher> _model = studentRepository.GetAll();
            
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

        #region Add New Record
        [HttpGet]
        public ActionResult AddRecord(StudentViewModel model)
        {
            //StudentModel _model = new StudentModel();
            Dictionary<string, string> genderDictionary = CostantData.dictGender();
            List<SelectListItem> list = new List<SelectListItem>();
            list = dropdownHelper(genderDictionary);
            model.GenderDropboxItemList = new SelectList(list, "Value", "Text");

            genderDictionary = CostantData.dictLookingFor();
            list = new List<SelectListItem>();
            list = dropdownHelper(genderDictionary);
            model.LookingForDropboxItemList = new SelectList(list, "Value", "Text");

            Dictionary<string, string> LanguageDictionary = CostantData.dictLanguages();
            list = new List<SelectListItem>();
            list = dropdownHelper(LanguageDictionary);
            model.LanguageDropboxItemList = new SelectList(list, "Value", "Text");

            Dictionary<string, string> RaceDictionary = CostantData.dictRaces();
            list = dropdownHelper(RaceDictionary);
            model.RaceDropboxItemList = new SelectList(list, "Value", "Text");

            Dictionary<string, string> countryDictionary = new Dictionary<string, string>();
            countryDictionary.Add("South Africa", "South Africa");
            list = dropdownHelper(countryDictionary);
            model.CountryDropboxItemList = new SelectList(list, "Value", "Text");

            Dictionary<string, string> ProvinceDictionary = CostantData.dictSouthAfricanProvinces();
            list = dropdownHelper(ProvinceDictionary);
            model.ProvinceDropboxItemList = new SelectList(list, "Value", "Text");

            Dictionary<string, string> GradeDictionary = CostantData.dictGrades();
            list = dropdownHelper(GradeDictionary);
            model.GradeDropboxItemList = new SelectList(list, "Value", "Text");

            Dictionary<string, string> emptyDictionary = new Dictionary<string, string>();
            emptyDictionary.Add("empty", "");

            Dictionary<string, string> ClassOrCourseDictionary = CostantData.dictSouthAfricanProvinces();

            list = dropdownHelper(emptyDictionary);
            model.CityDropboxItemList = new SelectList(list, "Value", "Text");

            list = dropdownHelper(emptyDictionary);
            model.SurbubDropboxItemList = new SelectList(list, "Value", "Text");

            list = dropdownHelper(emptyDictionary);
            model.ClassOrCourseDropboxItemList = new SelectList(list, "Value", "Text");

            list = dropdownHelper(emptyDictionary);
            model.LocationDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_AddTeacher", model);
        }
        #endregion

        //#region Add New Record
        //[HttpGet]
        //public ActionResult AddRecord(Student model)
        //{
        //    return PartialView("_AddStudent", model);
        //}
        //#endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(Teacher model)
        {
            try
            {
                model.TeacherId = Guid.NewGuid().ToString();
                studentRepository.Save(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("GetStudentResults", "Student");
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Add New Record
        [HttpPost]
        public ActionResult PreUpdate(Student model, string StudentId, string Firstname, string Surname)
        {            
            return PartialView("_UpdateStudent", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Update(Teacher model)
        {
            try
            {
                studentRepository.Save(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        
        #region Get Student
        [HttpPost]
        public ActionResult GetStudentSubject(StudentResults studentResult, string Firstname)
        {
            Student student = new Student();
            student.StudentId = studentResult.StudentId;
            student.Firstname = studentResult.Firstname;
            student.LastName = studentResult.LastName;
            student.Email = studentResult.Email;
            StudentResultsModel model = new StudentResultsModel();
            //List<Subject> subjects = subjectRepository.GetAll();
            //List<Subject> subjects = subjectRepository.GetById(student.StudentId);

            //List<SubjectResult> subjectResult = subjectResultRepository.GetById(student.StudentId);

            //model.StudentResults = studentResult;
            //model.Student = student;
            //model.Subjects = subjects;
            return PartialView("_StudentResults", model);
        }
        #endregion
       /* */
    }
}

