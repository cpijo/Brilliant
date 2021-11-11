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
    public class StudentMaintananceController : Controller
    {
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;
        //private ICoursesRepository courseRepository;
        //private IGradesRepository gradesRepository;

        public StudentMaintananceController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
            //this.courseRepository = courseRepository;
            //this.gradesRepository = gradesRepository;
        }

        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Student> _model = studentRepository.GetAll();
            return PartialView("_ViewStudent", _model);
            //return PartialView("_TableStudent", _model);
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


        //#region Search By Filter
        //[HttpPost]
        //public ActionResult SearchResult(string selectedValue)
        //{
        //    List<Student> _model = studentResultsRepository.GetAll();

        //    return PartialView("_TableStudent", _model);
        //}
        //#endregion


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
        public ActionResult AddRecord(StudentModel model)
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
            emptyDictionary.Add("empty", "Null");

            Dictionary<string, string> ClassOrCourseDictionary = CostantData.dictSouthAfricanProvinces();

            list = dropdownHelper(emptyDictionary);
            model.CityDropboxItemList = new SelectList(list, "Value", "Text");

            list = dropdownHelper(emptyDictionary);
            model.SurbubDropboxItemList = new SelectList(list, "Value", "Text");

            list = dropdownHelper(emptyDictionary);
            model.ClassOrCourseDropboxItemList = new SelectList(list, "Value", "Text");

            list = dropdownHelper(emptyDictionary);
            model.LocationDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_AddStudent", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(StudentModel model)
        {
            try
            {
                model.getDefaults();
                StudentGrade sg = new StudentGrade();
                sg = model.getStudentGrade();
                sg.GradeId =  CostantData.getFieldId(CostantData.dictGrades(), model.ClassOrCourse.ClassName);

                if (model.AssignTeacher.IsAssign==true)
                {

                }

                //model.Student.StudentId = Guid.NewGuid().ToString();
                //studentRepository.Save(model);
                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("GetStudentResults", "Student");
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region dropBox Update
        [HttpPost]
        public ActionResult dropBoxUpdate(string selectedValue,string searchType)
        {
            StudentModel model = new StudentModel();
            //amazing data structures and algorithms challenges in C# + youtube
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            List<string> selectedProvice = new List<string>();
            List<string> location = new List<string>();
            List<SelectListItem> list = new List<SelectListItem>();

            switch (searchType)
            {
                case "grade":
                    switch (selectedValue)
                    {
                        case "Grade8":
                            dictionary = CostantData.dictGrade8Classes();
                            break;
                        case "Grade9":
                            dictionary = CostantData.dictGrade9Classes();
                            break;
                        case "Grade10":
                            dictionary = CostantData.dictGrade10Classes();
                            break;
                        case "Grade11":
                            dictionary = CostantData.dictGrade11Classes();
                            break;
                        case "Grade12":
                            dictionary = CostantData.dictGrade12Classes();
                            break;
                        default:
                            dictionary = CostantData.dictGrade8Classes();
                            break;
                    }
                    model.DropboxModel.name = "class";
                    //list = new List<SelectListItem>();
                    list = dropdownHelper(dictionary);
                    model.ClassOrCourseDropboxItemList = new SelectList(list, "Value", "Text");
                    break;
                case "province":
                    switch (selectedValue)
                    {
                        case "Gauteng":
                            location = CostantData.Gauteng();
                            break;
                        case "Limpopo":
                            location = CostantData.Limpopo();
                            break;
                        case "Kwazulu Natal":
                            location = CostantData.KwazuluNatal();
                            break;
                        case "Mpumalanga":
                            location = CostantData.Mpumalanga();
                            break;
                        case "North West":
                            location = CostantData.NorthWest();
                            break;
                        case "FreeState":
                            location = CostantData.FreeState();
                            break;
                        case "Eastern Cape":
                            location = CostantData.EasternCape();
                            break;
                        case "Northern Cape":
                            location = CostantData.NorthernCape();
                            break;
                        case "Western Cape":
                            location = CostantData.WesternCape();
                            break;
                        default:
                            break;
                    }
                    model.DropboxModel.name = "suburb";
                    for (int i = 0; i < location.Count; i++)
                    {
                        dictionary.Add("sub_" + i, location[i]);
                    }
                    list = dropdownHelper(dictionary);
                    model.SurbubDropboxItemList = new SelectList(list, "Value", "Text");
                    break;
                case "suburb":
                    location = CostantData.Gauteng();
                    model.DropboxModel.name = "location";
                    for (int i = 0; i < location.Count; i++)
                    {
                        dictionary.Add("sub_" + i, location[i]);
                    }
                    list = dropdownHelper(dictionary);
                    model.LocationDropboxItemList = new SelectList(list, "Value", "Text");
                    break;
                default:
                    location = CostantData.Gauteng();
                    break;
            }

            //if (location != null)
            //{
            //    for (int i = 0; i < location.Count; i++)
            //    {
            //        dictionary.Add("sub_" + i, location[i]);
            //    }
            //}

            //Session["SurbubDictionary"] = dictionary;
            //List<SelectListItem> list = new List<SelectListItem>();
            //list = dropdownHelper(dictionary);
            //model.UnkownItemList = new SelectList(list, "Value", "Text");
            return PartialView("_PartialDropBox", model);
            //return PartialView("~/Views/Register/_PartialDropBox.cshtml", model);
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

