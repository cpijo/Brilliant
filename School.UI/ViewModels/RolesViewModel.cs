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
        public List<Roles> AllAvailableRoles { get; set; }
        public List<Roles> AllAssignedRoles { get; set; }

        public string SelectedUserId { get; set; }
        [Display(Name = "Available Roles")]
        public string availableRole { get; set; }
        public SelectList AvailableRoles_SelectList { get; set; }

        [Display(Name = "Assigned Roles")]
        public string assignedRole { get; set; }
        public SelectList AssignedRoles_SelectList { get; set; }

        public string username { get; set; }

    }

    public class myRole
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public bool adminRole { get; set; }
    }
}