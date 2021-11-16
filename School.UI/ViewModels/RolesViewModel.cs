using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace School.UI.ViewModels
{
    public class RolesViewModel
    {
        public List<Roles> AllRoles { get; set; }
        public List<Roles> AvailableRoles { get; set; }
        public List<Roles> AssignedRoles { get; set; }

        public string SelectedUserId { get; set; }
        [Display(Name = "Available Roles")]
        public string SelectedAvailableRole { get; set; }
        public SelectList AvailableRoles_ { get; set; }

        [Display(Name = "Assigned Roles")]
        public string SelectedAssignedRole { get; set; }
        public SelectList AssignedRoles_ { get; set; }

        public string username { get; set; }

    }
}