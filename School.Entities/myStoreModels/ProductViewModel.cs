using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.myStoreModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public Decimal Price { get; set; }
        public int Rating { get; set; }

        public string BrandName { get; set; }
        public string SupplierName { get; set; }

        public string getRating()
        {
            if (Rating == 10)
            {
                return "*****";
            }
            else if (Rating >= 8)
            {
                return "****";
            }
            else if (Rating >= 6)
            {
                return "***";
            }
            else if (Rating >= 4)
            {
                return "**";
            }
            else
            {
                return "*";
            }
        }
    }



    public class Coordinate_defaultValue
    {
        public int X { get; set; } = 34; // get or set auto-property with initializer

        public int Y { get; } = 89;      // read-only auto-property with initializer

        public int Z { get; }            // read-only auto-property with no initializer
                                         // so it has to be initialized from constructor    

        public Coordinate_defaultValue()              // .ctor()
        {
            Z = 42;
        }
    }

    class Person_defaultValue
    {
        private string _name;
        public string Name
        {
            get
            {
                return string.IsNullOrEmpty(_name) ? "Default Name" : _name;
            }

            set { _name = value; }
        }

        private string lname = "Initial Name";
        public string lName
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }

    }



    public class DefaultValuesTest
    {
        public DefaultValuesTest()
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            {
                DefaultValueAttribute myAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];

                if (myAttribute != null)
                {
                    property.SetValue(this, myAttribute.Value);
                }
            }
        }

        public void DoTest()
        {
            var db = DefaultValueBool;
            var ds = DefaultValueString;
            var di = DefaultValueInt;
        }


        [System.ComponentModel.DefaultValue(true)]
        public bool DefaultValueBool { get; set; }

        [System.ComponentModel.DefaultValue("Good")]
        public string DefaultValueString { get; set; }

        [System.ComponentModel.DefaultValue(27)]
        public int DefaultValueInt { get; set; }
    }
}

/*

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public int AddressId { get; set; }
}

    public class Address
{
    public int AddressId { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Pin { get; set; }
}

public class EmployeeDetailsViewModel
{
    public Employee Employee { get; set; }
    public Address Address { get; set; }
    public string PageTitle { get; set; }
    public string PageHeader { get; set; }
}

public class EmployeeController : Controller
{
    public ViewResult Details()
    {
        //Employee Basic Details
        Employee employee = new Employee()
        {
            EmployeeId = 101,
            Name = "Dillip",
            Gender = "Male",
            Department = "IT",
            Salary = 10000,
            AddressId = 1001
        };
        //Employee Address
        Address address = new Address()
        {
            AddressId = 1001,
            City = "Bhubaneswar",
            State = "Odisha",
            Country = "India",
            Pin = "755019"
        };
        //Creating the View model
        EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
        {
            Employee = employee,
            Address = address,
            PageTitle = "Employee Details Page",
            PageHeader = "Employee Details",
        };
        //Pass the employeeDetailsViewModel to the view
        return View(employeeDetailsViewModel);
    }
}

<body>
<h1>@Model.PageHeader</h1>
<div>
    EmployeeID : @Model.Employee.EmployeeId
</div>
<div>
    Name : @Model.Employee.Name
</div>
<div>
    Gender : @Model.Employee.Gender
</div>
<div>
    Department : @Model.Employee.Department
</div>
<div>
    Salary : @Model.Employee.Salary
</div>
<h1>Employee Address</h1>
<div>
    City : @Model.Address.City
</div>
<div>
    State : @Model.Address.State
</div>
<div>
    Country : @Model.Address.Country
</div>
<div>
    Pin : @Model.Address.Pin
</div>
</body>

* 
* 
* 
* 
* public class ProductEditModel
{
public int ProductId { get; set; }

[Required(ErrorMessage = "Product Name is Required")]
[Display(Name = "Product Name")]
public string Name { get; set; }

public Decimal Price { get; set; }
public int Rating { get; set; }

public List<Brand> Brands { get; set; }
public List<Supplier> Suppliers { get; set; }

public int BrandID { get; set; }
public int SupplierID { get; set; }
}


This is not repeating yourself:
public class FooViewModel
{
public string Name {get;set;}
}

public class DomainModel
{
public string Name {get;set;}
}     


On the other hand, defining a mapping twice, is repeating yourself:
public void Method1(FooViewModel input)
{
//duplicate code: same mapping twice, see Method2
var domainModel = new DomainModel { Name = input.Name };
//logic
}

public void Method2(FooViewModel input)
{
//duplicate code: same mapping twice, see Method1
var domainModel = new DomainModel { Name = input.Name };
//logic
}    


note: this is also applicable to other layer types, to name a few: DTO, DAO, Entity, ViewModel, Domain, etc.
public class FooViewModel
{
public string Name {get; set;} 

//hey, a domain model class!
public DomainClass Genre {get;set;} 
}

public class DomainClass
{
public int Id {get; set;}      
public string Name {get;set;} 
}


[Bind(Exclude="CompanyId,TenantId")]
public class CustomerModel
{
public int Id { get; set; }
public int CompanyId { get; set; } // user cannot inject
public int TenantId { get; set; }  // ..
public string Name { get; set; }
public string Phone { get; set; }
// ...
}



public class DetailsPageLayoutModel : IDisposable
{
    public List<AttributeContainerEntity> AttributeContainers { get; set; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    public void Dispose(bool dispose)
    {
        // ??
    }
}

public class AttributeContainerEntity
{
    public Guid Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}
where AttributeContainerEntity should be my Table1 item:P

In my view i have like this:

@using (Model)
{
foreach (var item in Model.AttributeContainers)
{
    <div class="attribute-placeholder" style="top: @(item.Y)px; left: @(item.X)px; width: @(item.Width)px; height: @(item.Height)px;">
    </div>
}
}



 */





/* 

       #region Add New Record
       [HttpPost]
       public ActionResult GradeInformation(Student model, string StudentId, string Firstname, string Surname)
       {
           return PartialView("_GradeInformation", model);
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

       Tutorial: Create a more complex data model for an ASP.NET MVC app
       https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
    
     
     
 using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public List<int> ExamScores { get; set; }
}

class PopulateCollection
{
    static void Main()
    {
        // These data files are defined in How to join content from
        // dissimilar files (LINQ).

        // Each line of names.csv consists of a last name, a first name, and an
        // ID number, separated by commas. For example, Omelchenko,Svetlana,111
        string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");

        // Each line of scores.csv consists of an ID number and four test
        // scores, separated by commas. For example, 111, 97, 92, 81, 60
        string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

        // Merge the data sources using a named type.
        // var could be used instead of an explicit type. Note the dynamic
        // creation of a list of ints for the ExamScores member. The first item
        // is skipped in the split string because it is the student ID,
        // not an exam score.
        IEnumerable<Student> queryNamesScores =
            from nameLine in names
            let splitName = nameLine.Split(',')
            from scoreLine in scores
            let splitScoreLine = scoreLine.Split(',')
            where Convert.ToInt32(splitName[2]) == Convert.ToInt32(splitScoreLine[0])
            select new Student()
            {
                FirstName = splitName[0],
                LastName = splitName[1],
                ID = Convert.ToInt32(splitName[2]),
                ExamScores = (from scoreAsText in splitScoreLine.Skip(1)
                              select Convert.ToInt32(scoreAsText)).
                              ToList()
            };

        // Optional. Store the newly created student objects in memory
        // for faster access in future queries. This could be useful with
        // very large data files.
        List<Student> students = queryNamesScores.ToList();

        // Display each student's name and exam score average.
        foreach (var student in students)
        {
            Console.WriteLine("The average score of {0} {1} is {2}.",
                student.FirstName, student.LastName,
                student.ExamScores.Average());
        }

        //Keep console window open in debug mode
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
/* Output:
    The average score of Omelchenko Svetlana is 82.5.
    The average score of O'Donnell Claire is 72.25.
    The average score of Mortensen Sven is 84.5.
    The average score of Garcia Cesar is 88.25.
    The average score of Garcia Debra is 67.
    The average score of Fakhouri Fadi is 92.25.
    The average score of Feng Hanying is 88.
    The average score of Garcia Hugo is 85.75.
    The average score of Tucker Lance is 81.75.
    The average score of Adams Terry is 85.25.
    The average score of Zabokritski Eugene is 83.
    The average score of Tucker Michael is 92.
 
     
     
     
   //Define string array  
string[] names = { "Life is Beautiful",  
                              "Arshika Agarwal",  
                              "Seven Pounds",  
                              "Rupali Agarwal",  
                              "Pearl Solutions",  
                              "Vamika Agarwal",  
                              "Vidya Vrat Agarwal",  
                              "C-Sharp Corner Mumbai Chapter"  
                           };  
//Linq query  
IEnumerable<string> namesOfPeople = from name in names  
                                    where name.Length <= 16  
                                    select name;  
foreach (var name in namesOfPeople)  
{  
    txtDisplay.AppendText(name+"\n");  
}   
     
     
     
     */







public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Store[] Stores { get; set; }
}

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class linqTest { 
public static void Main_bookTest()
{
    List<Book> books = new List<Book>();
    var stores = books.SelectMany(x => x.Stores) // flatMap method, returns a collection of stores
                      .Distinct() // only keep different stores
                      .Select(x => // foreach store
                          new { // create a new object
                              Store = x, // that contains the store
                              Books = books.Where(book => book.Stores.Contains(x)).ToList() // and a list of each book that is in the store
                          })
                      .ToList();
    Console.WriteLine(stores);
}
}