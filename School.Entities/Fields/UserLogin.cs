using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Entities.Fields
{
    public class UserLogin
    {
        //" SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname'," +
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string userType { get; set; }
    }
}