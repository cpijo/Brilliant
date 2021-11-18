using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.MySecurity;
using School.UI.ViewModels;
using School.UI.ViewModels.TeacherVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    [userPagePermissionAttribute(permissionID = new int[] { 500 })]
    public class TeacherRegisterController : BaseController
    {
        //Select Words (Ctrl+Shift+Arrow)
        //referrences (ALT+Enter)
        //ALT+Arrow to select a line and move up or down
        //ALT+Tab  Changing ot Tab from One Program to Another


        private ITeacherRepository tearcherRepository;
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;
        private ITeacherRegisterRepository teacherRegisterRepository;
        public TeacherRegisterController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository, 
            ITeacherRepository tearcherRepository, ITeacherRegisterRepository teacherRegisterRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
            this.tearcherRepository= tearcherRepository;
            this.teacherRegisterRepository = teacherRegisterRepository;
        }

        #region Create Record
        [HttpGet]
        public ActionResult CreateRecord(TeacherViewModel model)
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

            return PartialView("_CreateTeacher", model);
        }
        #endregion

        #region Save Student 
        [HttpPost]
        public ActionResult SaveRecord(TeacherViewModel model)
        {
            try
            {
                model.getDefaults();
                //StudentGrade sg = new StudentGrade();
                //sg = model.getStudentGrade();
                //sg.GradeId = CostantData.getFieldId(CostantData.dictGrades(), model.ClassOrCourse.ClassName);

                if (model.AssignTeacher.IsAssign == true)
                {
                }
                model.Teacher.TeacherId = Guid.NewGuid().ToString();
                model.Teacher.UserName = model.Teacher.TeacherId;
                model.Teacher.UserId = model.Teacher.TeacherId;

                teacherRegisterRepository.Save(model.Teacher);


                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region  Update dropBox
        [HttpPost]
        public ActionResult dropBoxUpdate(string selectedValue, string searchType)
        {
            TeacherViewModel model = new TeacherViewModel();
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
            return PartialView("_PartialDropBox", model);
        }
        #endregion


        #region Get Record
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<Teacher> model = teacherRegisterRepository.GetAll();
            Session["teacher"] = model;
            return PartialView("_ViewTeacher", model);
        }
        #endregion

        #region Get Record
        [HttpPost]
        public ActionResult GetByAny(string selectedValue)
        {
            dynamic _dynamic = new ExpandoObject();
            _dynamic.searchValue = selectedValue;
            _dynamic.type = "byGrade";
            List<Teacher> model = teacherRegisterRepository.GetByAny(_dynamic);

            return PartialView("_TableTeacher", model);
        }
        #endregion


        #region dropBox Update Simple
        [HttpPost]
        public ActionResult dropBoxUpdateSimple(string selectedValue, string searchType)
        {
            DropBoxViewModel model = new DropBoxViewModel();
            model.dropboxType = "grade";
            //model.GradeDropboxItemList = dropBoxDictionary(selectedValue, searchType);


            Dictionary<string, string> GradeDictionary = CostantData.dictGrades();
            List<SelectListItem> list = dropdownHelper(GradeDictionary);
            model.GradeDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_dropBoxOnly", model);
        }
        #endregion;



        #region Teacher Information
        [HttpPost]
        public ActionResult TeacherInformation(string userId)
        {

            Teacher teacher = null;
            if (Session["teacher"] != null)
            {
                List<Teacher> teachers = Session["teacher"] as List<Teacher>;
                teacher = teachers.ToList().Where(x => x.TeacherId == userId).FirstOrDefault();
            }
            else
            {
                List<Teacher> students = tearcherRepository.GetAll();
                teacher = students.ToList().Where(x => x.TeacherId == userId).FirstOrDefault();
            }

            TeacherViewModel model = new TeacherViewModel();
            model.Teacher = teacher;

            return PartialView("_ViewTeacherInfor", model);
        }
        #endregion


        #region Teacher Information
        [HttpPost]
        public ActionResult TeacherRoles(string userId)
        {

            Teacher teacher = null;
            if (Session["teacher"] != null)
            {
                List<Teacher> teachers = Session["teacher"] as List<Teacher>;
                teacher = teachers.ToList().Where(x => x.TeacherId == userId).FirstOrDefault();
                Session["selectedTeacher"] = teacher;
            }
            else
            {
                List<Teacher> students = tearcherRepository.GetAll();
                teacher = students.ToList().Where(x => x.TeacherId == userId).FirstOrDefault();
                Session["selectedTeacher"] = teacher;
            }

            TeacherRoleSimpleViewModel model = new TeacherRoleSimpleViewModel();
            model.TeacherViewModel.Teacher = teacher;
            //TeacherViewModel model = new TeacherViewModel();
            //model.Teacher = teacher;

            Dictionary<string, string> GradeDictionary = CostantData.dictGrades();
            List<SelectListItem> list = dropdownHelper(GradeDictionary);
            model.TeacherViewModel.GradeDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_TeacherRoles", model);
        }
        #endregion

        #region Get Subjects
        [HttpPost]
        public ActionResult GetSubjects(string grade)
        {
            TeacherRoleSimpleViewModel model = new TeacherRoleSimpleViewModel();
            //if (Session["selectedTeacher"] != null)
            //{
            //    Teacher teacher = Session["teacher"] as Teacher;
            //    model.TeacherViewModel.Teacher = teacher;
            //}

            Dictionary<string, string> dictionary = getSubjects(grade);

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                model.TeacherRoles.Add(new TeacherRoleSimpleViewModel {GradeId=grade, SubjectId = item.Key, SubjectName = item.Value});
            }
            return PartialView("_TeacherRolesTable", model);
        }
        #endregion

        #region Save Roles
        [HttpPost]
        public ActionResult SaveRoles(TeacherRoleSimpleViewModel _model, string grade, FormCollection formCollection)
        {
            try
            {
                string hidInput = formCollection["hidInput"];
                List<TeacherRoleSimpleViewModel> modelList = myDeserialiseFromJson<List<TeacherRoleSimpleViewModel>>.Deserialise(hidInput);

                var SelectedUserId = formCollection["TeacherRolesId"];// as List<TeacherRoleSimpleViewModel>();
                TeacherRoleSimpleViewModel model = new TeacherRoleSimpleViewModel();
                Dictionary<string, string> dictionary = getSubjects(grade);

                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    model.TeacherRoles.Add(new TeacherRoleSimpleViewModel { SubjectId = item.Key, SubjectName = item.Value, Grade = grade });
                }
                return PartialView("_PartialDropBox", model);
            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        [HttpPost]
        public ActionResult Edit_Include([Bind(Include = "StudentId, StudentName")] Student std)
        {
            var name = std.Firstname;

            //@Html.Label("StudentId:")  
            //@Html.TextBox("StudentName")

            return RedirectToAction("TestIndex");
        }

        [HttpPost]
        public ActionResult Edit_Exclude([Bind(Exclude = "StudentId, StudentName")] Student std)
        {
            var name = std.Firstname;

            //@Html.Label("StudentId:")  
            //@Html.TextBox("StudentName")

            return RedirectToAction("TestIndex");
        }

    }
}

