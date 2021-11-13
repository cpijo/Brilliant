using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.myStoreModels
{
    //https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/ajax-actionlink-and-html-actionlink-in-mvc/
    //https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/ajax-actionlink-and-html-actionlink-in-mvc/
    //https://www.pluralsight.com/guides/asp.net-mvc-getting-default-data-binding-right-for-hierarchical-views
    //public class OrderDisplayViewModel
    //{
    //    public Guid CustomerID { get; set; }

    //    [Display(Name = "Order Number")]
    //    public Guid OrderID { get; set; }

    //    [Display(Name = "Order Date")]
    //    public DateTime OrderDate { get; set; }

    //    [Display(Name = "PO / Description")]
    //    public string Description { get; set; }
    //}

    //public class Customer
    //{
    //public class CustomerOrdersListViewModel
    //{
    //    [Display(Name = "Customer Number")]
    //    public Guid CustomerID { get; set; }

    //    [Display(Name = "Customer Name")]
    //    public string CustomerName { get; set; }

    //    [Display(Name = "Country")]
    //    public string CountryNameEnglish { get; set; }

    //    [Display(Name = "Region")]
    //    public string RegionNameEnglish { get; set; }

    //    public List<OrderDisplayViewModel> Orders { get; set; }
    //}


    //    public Customer()
    //    {
    //        Orders = new HashSet<Order>();
    //    }

    //    [Key]
    //    [Column(Order = 0)]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public Guid CustomerID { get; set; }

    //    [Required]
    //    [MaxLength(128)]
    //    public string CustomerName { get; set; }

    //    [Required]
    //    [MaxLength(3)]
    //    public string CountryIso3 { get; set; }

    //    [MaxLength(3)]
    //    public string RegionCode { get; set; }

    //    public virtual Country Country { get; set; }

    //    public virtual Region Region { get; set; }

    //    public virtual ICollection<Order> Orders { get; set; }
    //}


    //public class Order
    //{
    //    public Order()
    //    {
    //        Items = new HashSet<Item>();
    //    }

    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public Guid OrderID { get; set; }

    //    [Required]
    //    public Guid CustomerID { get; set; }

    //    [Required]
    //    public DateTime OrderDate { get; set; }

    //    [Required]
    //    [MaxLength(128)]
    //    public string Description { get; set; }

    //    public virtual ICollection<Item> Items { get; set; }

    //    public virtual Customer Customer { get; set; }
    //}


    //public class CustomerDisplayViewModel
    //{
    //    [Display(Name = "Customer Number")]
    //    public Guid CustomerID { get; set; }

    //    [Display(Name = "Customer Name")]
    //    public string CustomerName { get; set; }

    //    [Display(Name = "Country")]
    //    public string CountryName { get; set; }

    //    [Display(Name = "State / Province / Region")]
    //    public string RegionName { get; set; }
    //}


    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<int> Scores;
    }

    class Teacher
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
    }
    class DataTransformations
    {
        static void Main_test0()
        {
            // Create the first data source.
            List<Student> students = new List<Student>()
        {
            new Student { First="Svetlana",
                Last="Omelchenko",
                ID=111,
                Street="123 Main Street",
                City="Seattle",
                Scores= new List<int> { 97, 92, 81, 60 } },
            new Student { First="Claire",
                Last="O’Donnell",
                ID=112,
                Street="124 Main Street",
                City="Redmond",
                Scores= new List<int> { 75, 84, 91, 39 } },
            new Student { First="Sven",
                Last="Mortensen",
                ID=113,
                Street="125 Main Street",
                City="Lake City",
                Scores= new List<int> { 88, 94, 65, 91 } },
        };

            // Create the second data source.
            List<Teacher> teachers = new List<Teacher>()
        {
            new Teacher { First="Ann", Last="Beebe", ID=945, City="Seattle" },
            new Teacher { First="Alex", Last="Robinson", ID=956, City="Redmond" },
            new Teacher { First="Michiyo", Last="Sato", ID=972, City="Tacoma" }
        };

            // Create the query.
            var peopleInSeattle = (from student in students
                                   where student.City == "Seattle"
                                   select student.Last)
                        .Concat(from teacher in teachers
                                where teacher.City == "Seattle"
                                select teacher.Last);

            Console.WriteLine("The following students and teachers live in Seattle:");
            // Execute the query.
            foreach (var person in peopleInSeattle)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        The following students and teachers live in Seattle:
        Omelchenko
        Beebe
     */



    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    class class_InnerJoinExample
    {
        /// <summary>
        /// Simple inner join.
        /// </summary>
        public static void InnerJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a collection of person-pet pairs. Each element in the collection
            // is an anonymous type containing both the person's name and their pet's name.
            var query = from person in people
                        join pet in pets on person equals pet.Owner
                        select new { OwnerName = person.FirstName, PetName = pet.Name };

            foreach (var ownerAndPet in query)
            {
                Console.WriteLine($"\"{ownerAndPet.PetName}\" is owned by {ownerAndPet.OwnerName}");
            }
        }
    
    // This code produces the following output:
    //
    // "Daisy" is owned by Magnus
    // "Barley" is owned by Terry
    // "Boots" is owned by Terry
    // "Whiskers" is owned by Charlotte
    // "Blue Moon" is owned by Rui





}

}





/*class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int EmployeeID { get; set; }
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StudentID { get; set; }
}

/// <summary>
/// Performs a join operation using a composite key.
/// </summary>
public static void CompositeKeyJoinExample()
{
    // Create a list of employees.
    List<Employee> employees = new List<Employee> {
        new Employee { FirstName = "Terry", LastName = "Adams", EmployeeID = 522459 },
         new Employee { FirstName = "Charlotte", LastName = "Weiss", EmployeeID = 204467 },
         new Employee { FirstName = "Magnus", LastName = "Hedland", EmployeeID = 866200 },
         new Employee { FirstName = "Vernette", LastName = "Price", EmployeeID = 437139 } };

    // Create a list of students.
    List<Student> students = new List<Student> {
        new Student { FirstName = "Vernette", LastName = "Price", StudentID = 9562 },
        new Student { FirstName = "Terry", LastName = "Earls", StudentID = 9870 },
        new Student { FirstName = "Terry", LastName = "Adams", StudentID = 9913 } };

    // Join the two data sources based on a composite key consisting of first and last name,
    // to determine which employees are also students.
    IEnumerable<string> query = from employee in employees
                                join student in students
                                on new { employee.FirstName, employee.LastName }
                                equals new { student.FirstName, student.LastName }
                                select employee.FirstName + " " + employee.LastName;

    Console.WriteLine("The following people are both employees and students:");
    foreach (string name in query)
        Console.WriteLine(name);
}

// This code produces the following output:
//
// The following people are both employees and students:
// Terry Adams
// Vernette Price*/

/*

foreach( Customer cust in customers)
{
   if (cust.IsValid) 
   {
      cust.CreditLimit = 1000;
    }
}


Converting this code to use LINQ isn't hard to do:
var validCustomers = from c in customers
                     where c.IsValid
                     select c;
foreach( Customer cust in validCustomers)
{
      cust.CreditLimit = 1000;
}


The code is terser if you'd prefer to use LINQ's Where method and a lambda expression:
var validCustomers = customers.Where(c => c.IsValid);
foreach( Customer cust in validCustomers)
{
    cust.CreditLimit = 1000;
}


var ValidCustomers = customers.Where(c => c.IsValid).ToList();
ValidCustomers.ForEach(c => c.CreditLimit = 1000);

    */
