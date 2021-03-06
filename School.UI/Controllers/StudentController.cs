using School.Common.PagingHelper;
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
    public class StudentController : Controller
    {
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;
        //private ICoursesRepository courseRepository;
        //private IGradesRepository gradesRepository;

        public StudentController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository)
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
            List<Student> students = studentRepository.GetAll();
            int totalData = students.Count();
            Session["students"] = students;

            List<Student> _students =  students.Take(10).ToList();
            childPage cpage = new childPage();
            cpage.StartPage = 1;
            cpage.CurrentPage = 1;
            cpage.EndPage = 5;
            cpage.TotalItems = totalData;
            cpage.TotalPages = (totalData / 10);
            Pager pager = new Pager(cpage, totalData, 1, 10, 5);

            Session["pager"] = pager;

            return PartialView("_ViewStudent", _students);
        }
        #endregion

        #region Get Student
        [HttpPost]
        public ActionResult GetRecordByPage(int pageNo,int startNo,int endNo,int currentNo)
        {
            List<Student> students = Session["students"] as List<Student>;
            int totalData = students.Count();
            Session["students"] = students;

            //int skip = 10 * page;  
            int skip = 10 * pageNo;  
            

            List<Student> _students = students.Skip(skip).Take(10).ToList();

            //_page = int.Parse(start_end_current[0]);
            //_start = int.Parse(start_end_current[0]);
            //_end = int.Parse(start_end_current[1]);
            //_current = int.Parse(start_end_current[2]);






            childPage cpage = new childPage();
            cpage.StartPage = 1;
            cpage.CurrentPage = pageNo;
            cpage.EndPage = 5;
            cpage.TotalItems = totalData;
            cpage.TotalPages = (totalData / 10);
            Pager pager = new Pager(cpage, totalData, 1, 10, 5);

            Session["pager"] = pager;

            return PartialView("_ViewStudent", _students);
        }
        #endregion


        #region Student Information
        [HttpPost]
        public ActionResult StudentInformation(string userId)
        {
            Student student = null;
            if (Session["students"]!=null)
            {
                List<Student>  students = Session["students"] as List<Student>;
                student = students.ToList().Where(x => x.StudentId == userId).FirstOrDefault();
            }
            else
            {
                List<Student> students = studentRepository.GetAll();
                student = students.ToList().Where(x => x.StudentId == userId).FirstOrDefault();
            }
            StudentViewModel model = new StudentViewModel();
            model.Student = student;

            return PartialView("_ViewStudentInfor", model);
        }
        #endregion




        //#region Get Student
        //[HttpGet]
        //public ActionResult GetRecord()
        //{
        //    List<Student> _model = studentRepository.GetAll();
        //    return PartialView("_ViewStudent", _model);
        //    //return PartialView("_TableStudent", _model);
        //}
        //#endregion

        #region Get Student By Filter
        [HttpPost]
        public ActionResult SearchRecord(string selectedValue)
        {
            List<Student> _model = studentRepository.GetAll();
            
            return PartialView("_TableStudent", _model);
        }
        #endregion


        #region Add New Record
        [HttpGet]
        public ActionResult AddRecord(Student model)
        {
            return PartialView("_AddStudent", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult Save(Student model)
        {
            try
            {
                model.StudentId = Guid.NewGuid().ToString();
                studentRepository.Save(model);

                //Learn from acumatica action.pressSave();
                // command.CommandText = "SELECT * FROM [schooldb].dbo.Student";
                //entity<Student>();
                //data<Student>.dataParameter = model;
                //action.Save();

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
        public ActionResult UpdateView(Student model, string StudentId, string Firstname, string Surname)
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

