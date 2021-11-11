using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.StudentModel;
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
    public class StudentAttendanceController : BaseController
    {
        private IStudentAttendanceRepository studentAttendanceRepository;
        private IStudentSubjectMarksRepository studentSubjectMarksRepository;

        public StudentAttendanceController(IStudentAttendanceRepository studentAttendanceRepository,IStudentSubjectMarksRepository studentSubjectMarksRepository)
        {
            this.studentAttendanceRepository = studentAttendanceRepository;
            this.studentSubjectMarksRepository = studentSubjectMarksRepository;
        }

        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            List<StudentAttendance> model = studentAttendanceRepository.GetById("");
            StudentAttendanceModel mod = new StudentAttendanceModel();
            //mod.StudentAttendance = new List<StudentAttendance>();
            mod.StudentAttendance = model;

            List<SelectListItem> list = new List<SelectListItem>();
            Dictionary<string, string> dictionary = CostantData.dictGrades();
            list = dropdownHelper(dictionary);
            mod.GradeDropboxItemList = new SelectList(list, "Value", "Text");

            dictionary = new Dictionary<string, string>();
            dictionary = CostantData.dictAllSubjects();
            list = dropdownHelper(dictionary);
            mod.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            dictionary = new Dictionary<string, string>();
            dictionary.Add("daily", "Daily");
            dictionary.Add("weekly", "Weekly");
            list = dropdownHelper(dictionary);
            mod.AttendanceDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_ViewStudentAttendance", mod);
        }
        #endregion

        #region dropBox Update
        [HttpPost]
        public ActionResult dropBoxUpdate(string selectedValue, string searchType)
        {
            StudentAttendanceModel model = new StudentAttendanceModel();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            switch (selectedValue)
            {
                case "Grade8":
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
                case "Grade9":
                    dictionary = CostantData.dictGrade9Subjects();
                    break;
                case "Grade10":
                    dictionary = CostantData.dictGrade10Subjects();
                    break;
                case "Grade11":
                    dictionary = CostantData.dictGrade11Subjects();
                    break;
                case "Grade12":
                    dictionary = CostantData.dictGrade12Subjects();
                    break;
                default:
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
            }

            List<SelectListItem> list = dropdownHelper(dictionary);
            model.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_PartialDropBox", model);
        }
        #endregion

        #region dropBox Update
        [HttpPost]
        public ActionResult dropBoxUpdate_New(string selectedValue, string searchType)
        {
            StudentAttendanceVM model = new StudentAttendanceVM();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
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

            List<SelectListItem> list = dropdownHelper(dictionary);
            model.SubjectDropboxItemList = new SelectList(list, "Value", "Text");

            return PartialView("_PartialDropBox", model);
        }
        #endregion

        #region Search By Filter
        [HttpPost]
        public ActionResult SearchResult(string teacherId, string gradeId,string subjectId,string searchDate, string queryType = "searchByGrade")
        {
            //Passing an anonymous object as an argument in C#
            gradeId = CostantData.getFieldId(CostantData.dictGrades(), gradeId);
            //GradeId = CostantData.getDictionaryValueByIndex(CostantData.dictGrades(),int.Parse(GradeId));

            dynamic anonymous = new ExpandoObject();
            anonymous.StudentId = "StudentId"; anonymous.GradeId = gradeId; anonymous.queryType = queryType;

            //dynamic anonymous = new { StudentId = "StudentId", GradeId = "GradeI2" , queryType = "searchByGrade" };

           // StudentAttendanceModel mod = new StudentAttendanceModel();


            //List<StudentAttendance> model = studentResultsRepository.GetByAny(anonymous);

            //var anonymousList = new[] {
            //                            new { txt = "test1" },
            //                            new { txt = "test2" },
            //                            new { txt = "test3" }
            //                           };

            //return PartialView("_TableStudentSeachResult", _model);

            return PartialView("_TableStudentSeachResult");
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(string teacherModel, string jsonString, string dictionary)
        {

            try
            {
                StudentAttendanceVM model = myDeserialiseFromJson<StudentAttendanceVM>.Deserialise(jsonString);
                //StudentAttendanceModel model = JsonConvert.DeserializeObject<StudentAttendanceModel>(jsonString);

                // model.StudentId = Guid.NewGuid().ToString();
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










































        //#region Get Student By Filter
        //[HttpPost]
        //public ActionResult SearchRecord(string selectedValue)
        //{
        //    List<Student> _model = studentRepository.GetAll();

        //    return PartialView("_TableStudent", _model);
        //}
        //#endregion


        //#region Add New Record
        //[HttpGet]
        //public ActionResult AddRecord(Student model)
        //{
        //    return PartialView("_AddStudent", model);
        //}
        //#endregion


        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Courses.Add(course);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(course);
        }

   
        [HttpPost]
        public ActionResult Save_simpler(List<string> rows, FormCollection collection)
        {
            //model = "{"_data":{"DateOfAttendance":"2021/10/12","attandance":"weekly","Grade":"Grade10","SubjectName":"ven008"}}"


            int totalRows = Convert.ToInt32(collection["TotalRows"]);

            rows.ForEach(x =>
            {
                var row = x.Split('-');
                var id = row[0];
                var name = row[1];
                var family = row[2];
            });
            return null;
        }




        [HttpPost]
        public ActionResult Save_0000(Student inputModel)
        {
            if (ModelState.IsValid)
            {
                string message = string.Format("Created user '{0}' aged '{1}' in the system."
                  , inputModel.Firstname, inputModel.Age);
                return Json(new Student { Firstname = message });
            }
            else
            {
                string errorMessage = "<div class=\"validation-summary-errors\">"
                  + "The following errors occurred:<ul>";
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        errorMessage += "<li class=\"field-validation-error\">"
                         + error.ErrorMessage + "</li>";
                    }
                }
                errorMessage += "</ul>";
                return Json(new Student { Firstname = errorMessage });
            }
        }



        /*
        [HttpPost]
        public ActionResult Upsert([FromBody] Employee myJSON)
        {
            string myMessage = (myJSON != null) ? "Not Null" : "isNull";
            return Json(myMessage);
        }

        public class Employee
        {
            public string name { get; set; }
            public int age { get; set; }
            public string city { get; set; }
        }
        */


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
                //studentRepository.Save(model);
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


        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                /*
                // Getting all Customer data    
                var customerData = (from tempcustomer in _context.Customers
                                    select tempcustomer);

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.CompanyName == searchValue);
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                */
                return null;
                //return Json(new { dra/ = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        /* */
    }
}

