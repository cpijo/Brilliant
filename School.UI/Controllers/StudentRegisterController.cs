﻿using School.Common.Constants;
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
    public class StudentRegisterController : Controller
    {
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;

        public StudentRegisterController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
        }

        #region Create Record
        [HttpGet]
        public ActionResult CreateRecord(StudentViewModel model)
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

            return PartialView("_CreateStudent", model);
        }
        #endregion

        #region Save Record 
        [HttpPost]
        public ActionResult SaveRecord(StudentViewModel model)
        {
            try
            {
                model.getDefaults();
                StudentGrade sg = new StudentGrade();
                sg = model.getStudentGrade();
                sg.GradeId = CostantData.getFieldId(CostantData.dictGrades(), model.ClassOrCourse.ClassName);

                if (model.AssignTeacher.IsAssign == true)
                {
                }
                model.Student.StudentId = Guid.NewGuid().ToString();
                model.Student.UserName = model.Student.StudentId;
                model.Student.UserId = model.Student.StudentId;
                studentRepository.Save(model.Student);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Student> students = studentRepository.GetAll();
            Session["teacher"] = students;
            return PartialView("_ViewStudent", students);
        }
        #endregion

        #region Teacher Information
        [HttpPost]
        public ActionResult TeacherInformation(string userId)
        {
            Student student = null;
            if (Session["teacher"] != null)
            {
                List<Student> students = Session["teacher"] as List<Student>;
                student = students.ToList().Where(x => x.StudentId == userId).FirstOrDefault();
            }
            else
            {
                List<Student> students = studentRepository.GetAll();
                student = students.ToList().Where(x => x.StudentId == userId).FirstOrDefault();
            }
            StudentViewModel model = new StudentViewModel();
            model.Student = student;

            return PartialView("_ViewTeacherInfor", model);
        }
        #endregion











        #region Get Student
        [HttpGet]
        public ActionResult GetReport()
        {
            List<Student> _model = studentRepository.GetAll();

            return PartialView("_StudentRegisteredReport", _model);
        }
        #endregion



        #region Grade Information
        [HttpPost]
        public ActionResult GradeInformation(Student model, string StudentId, string Firstname, string Surname)
        {
            return PartialView("_GradeInformation", model);
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

























































        #region Get Student By Filter
        [HttpPost]
        public ActionResult SearchRecord(string selectedValue)
        {
            List<Student> _model = studentRepository.GetAll();
            
            return PartialView("_TableStudent", _model);
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
        public ActionResult Update(Student model)
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

