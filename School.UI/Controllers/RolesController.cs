using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.StudentModel;
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
    public class RolesController : BaseController
    {
        private IStudentResultsRepository studentResultsRepository;
        private ISubjectRepository subjectRepository;
        private ISubjectResultRepository subjectResultRepository;
        private ITeacherRegisterRepository teacherRegisterRepository;
        private IRolesRepository rolesRepository;
        private IUserRolesRepository userRolesRepository;
        public RolesController(IStudentResultsRepository studentResultsRepository, ISubjectRepository subjectRepository,
            ISubjectResultRepository subjectResultRepository, ITeacherRegisterRepository teacherRegisterRepository, IRolesRepository rolesRepository,
            IUserRolesRepository userRolesRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.subjectRepository = subjectRepository;
            this.subjectResultRepository = subjectResultRepository;
            this.teacherRegisterRepository = teacherRegisterRepository;
            this.rolesRepository= rolesRepository;
            this.userRolesRepository = userRolesRepository;
        }
        #region Get Student
        [HttpGet]
        public ActionResult GetRecord()
        {
            //List<RolesViewModel> _model = studentResultsRepository.GetAll();
            TeacherViewModel model = new TeacherViewModel();
            List<Teacher> teachers = teacherRegisterRepository.GetAll();
            model.Teachers = teachers;

            //Session["teacher"] = model;
            //return PartialView("_ViewTeacher", model);

            //Dictionary<string, string> genderDictionary = CostantData.dictGender();
            //List<SelectListItem> list = new List<SelectListItem>();
            //list = dropdownHelper(genderDictionary);
            //model.AvailableRoles_SelectList = new SelectList(list, "Value", "Text");

            //genderDictionary = CostantData.dictGrades();
            //list = dropdownHelper(genderDictionary);
            //model.AssignedRoles_SelectList = new SelectList("", "Value", "Text");

            return PartialView("_ViewUser", model);
        }
        #endregion

        #region assign Roles
        [HttpPost]
        public ActionResult assignRoles(string userId,string Firstname, string LastName)
        {

            RolesViewModel model = new RolesViewModel();
            List<Roles> rolesAll = new List<Roles>();
            rolesAll = rolesRepository.GetAll();

            List<Roles> rolePerUser = new List<Roles>();
            rolePerUser = rolesRepository.GetById(userId);


            for (int i = 0; i < rolesAll.Count; i++)
            {
                foreach (Roles r in rolePerUser)
                {
                    if (r.RoleID == rolesAll[i].RoleID)
                    {
                        rolesAll.RemoveAt(i);
                    }
                }
            }

            Dictionary<string, string> genderDictionary = CostantData.dictGender();

            List<SelectListItem> availableRole = new List<SelectListItem>();
            availableRole = dropdownHelper(rolesAll);
            model.AvailableRoles_SelectList = new SelectList(availableRole, "Value", "Text");

            List<SelectListItem> assignedRole = new List<SelectListItem>();
            assignedRole = dropdownHelper(rolePerUser);
            model.AssignedRoles_SelectList = new SelectList(assignedRole, "Value", "Text");

            model.SelectedUserId = userId;

            Session["assignedRole"] = assignedRole;

            return PartialView("_PartialRoles", model);
        }
        #endregion
        #region save Roles
        [HttpPost]
        public ActionResult SaveRoles(string userId, string Firstname, string LastName, FormCollection formCollection)
        {
            string SelectedUserId = formCollection["SelectedUserId"];
            string _availableRole = formCollection["availableRole"];
            string RolesObject = formCollection["assignedRole"];


            List<int> ListRolesInts = new List<int>();
            List<UserRoles> roles = new List<UserRoles>();
            if (RolesObject != null)
            {
                string[] ArrayIds = RolesObject.Split(',');
                foreach (var id in ArrayIds)
                {
                    ListRolesInts.Add(int.Parse(id));
                    roles.Add(new UserRoles()
                    {
                        RoleID = int.Parse(id),
                        UserId = SelectedUserId,
                    });
                }
            }


            if (Session["assignedRole"]!=null)
            {

            }


            userRolesRepository.SaveMany(roles);   
            
            return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
