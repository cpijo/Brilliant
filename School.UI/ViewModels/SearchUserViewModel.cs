using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.ViewModels
{

    public class IsStaff
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }

    public class UserSearchViewModel
    {
        [Display(Name = "Last Name")]
        public string UserLastName_Search { get; set; }

        [Display(Name = "First Name")]
        public string UserFirstName_Search { get; set; }

        [Display(Name = "Email Address")]
        public string Email_Search { get; set; }

        [Display(Name = "IS Staff")]
        public int IsStaffSearch { get; set; }

    }

}