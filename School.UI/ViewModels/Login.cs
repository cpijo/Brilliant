using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.UI.ViewModel
{
    //https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/what-is-model-and-viewmodel-in-mvc-pattern/
    //this will represent domain of the application  
    public class Login
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }

    //this will help in rendering great views  
    public class LoginViewModel
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String RePassword { get; set; }
    }


    public class Transforming_Model_from_ViewModel
    {
        public void mapping_exp(LoginViewModel viewModel)
        {
            //validate the ViewModel  
            //transforming Model (Domain Model) which is Login from ViewModel which is LoginViewModel  
            var login = new Login()
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            };
            //save the login var 

        }
    }
}




namespace School.UI.ViewModel_exp1
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

    }

    public class CustomerViewModel
    {
        public List<Book> Books { get; set; }
        public List<Customer> Customers { get; set; }
    }


    public class Book_Custormer_Usage
    {
        public void mapping_exp()
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

        }
    }

}