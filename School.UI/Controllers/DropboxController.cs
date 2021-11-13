using Newtonsoft.Json;
using School.Common.Constants;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.StudentModel;
using School.UI.ViewModels;
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
    public class DropboxController : BaseController
    {
        private IStudentResultsRepository studentResultsRepository;
        private ISubjectRepository subjectRepository;
        private ISubjectResultRepository subjectResultRepository;
        private IStudentAttendanceRepository studentAttendanceRepository;
        public DropboxController(IStudentResultsRepository studentResultsRepository, ISubjectRepository subjectRepository,
            ISubjectResultRepository subjectResultRepository,  IStudentAttendanceRepository studentAttendanceRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.subjectRepository = subjectRepository;
            this.studentAttendanceRepository = studentAttendanceRepository;
        }

        #region Get Record
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
        #region Search By Dropbox
        [HttpPost]
        public ActionResult SearchByDropBox(string selectedValue, string StudentId, string GradeId, string queryType = "searchByGrade")
        {
            GradeId = CostantData.getFieldId(CostantData.dictGrades(), GradeId);
            dynamic _dynamic = new ExpandoObject();
            _dynamic.GradeId = GradeId; _dynamic.queryType = queryType;           
            List<StudentResults> _model = studentResultsRepository.GetByAny(_dynamic);
            return PartialView("_TableStudentSeachResult", _model);
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


    }
}



/*

    
    //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }


    
    
    
 
 public class ProductBaseController : Controller
{
	public virtual ActionResult Add()
	{
		DoA();
		DoB();
		return View();
	}

	public virtual ActionResult Delete(int id)
	{
		// ...
		return View();
	}

	
	public virtual ActionResult SomeOtherAction()
	{
		return View();
	}
}

public ProductController : ProductBaseController
{
	// display custom product page
	public override ActionResult Add()
	{
		DoA();
		DoC();
		DoD();
		DoE();
		return View();
	}

	// all other request get routed into base class
}

 
  
  namespace ShadowMoses.Core.Mvc
{
    public class MyControllerBaseController : Controller
    {
        [HttpGet]
        public FileResult CommonAction1()
        {
            return null;
        }
        [HttpGet]
        public ActionResult CommonAction2(string textIn)
        {
            return null;
        }
    }
}

namespace MvcApplication6.Controllers
{
    public class HomeController : MyControllerBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

}


    https://social.msdn.microsoft.com/Forums/en-US/4809541c-ceb8-4043-bbd7-1483e1a9724f/routing-to-a-base-controller?forum=aspmvc
 routes.MapRoute("CommonAction",
                "{action}",
                new { controller = "MyControllerBase" },
                new { action = "CommonAction(1|2)" },
                new[] { "ShadowMoses.Core.Mvc" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
     

 Base controller  
 
 namespace CMS.Core.Controllers {
    public class PageController : Controller {
        public virtual ActionResult DisplayHome() {
            // Logic
            return View();
        }
    }
}   


Client specific controller

namespace CMS.ClientCore.Controllers {
    public class PageController : Core.Controllers.PageController {
        public override ActionResult DisplayHome() {
            return Content("Client Home"); // Just for testing
        }
    }
}

Route

routes.MapRouteInLowercase(
    "Home",
    "",
    new { controller = "Page", action = "DisplayHome" },
    new[] { "CMS.Core.Controllers", "CMS.ClientCore.Controllers" }
);

 
    


    public class BaseExp1Controller : Controller
    {
        public virtual ActionResult ViewInBaseClass()
        {
            return PartialView();
        }



        //public abstract ActionResult ViewInBaseClass2() { Get;Set; }

    }




public class HomeController : Controller  
    {  
        public ActionResult Index()  
        {  
            var Book = new List<Book>()  
            {  
                new Book {BookName = "Programming in C#"},  
                new Book {BookName = "Programming in C++"},  
                new Book {BookName = "Programming in Java"}  
            };  
   
            var Customer = new List<Customer>()  
            {  
                new Customer {CustomerName = "Zain"},  
                new Customer {CustomerName = "Hassan"},  
                new Customer {CustomerName = "Syed"}  
            };  
   
            var CustomerViewModel = new CustomerViewModel  
            {  
                Books = Book,  
                Customers = Customer  
            };  
   
            return View(CustomerViewModel);  
        }  
    }  

     */
