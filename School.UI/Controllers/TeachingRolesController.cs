using School.Common.Constants;
using School.Common.JsonStringHelper;
using School.Entities.Fields;
using School.Services.Interface;
using School.UI.Models.MySecurity;
using School.UI.ViewModels;
using School.UI.ViewModels.TeacherVM;
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
    [userPagePermissionAttribute(permissionID = new int[] { 500 })]
    public class TeachingRolesController : BaseController
    {
        private ITeachingRolesRepository teachingRolesRepository;
        public TeachingRolesController(ITeachingRolesRepository teachingRolesRepository)
        {
            this.teachingRolesRepository = teachingRolesRepository;
        }

        #region Get Subjects
        [HttpPost]
        public ActionResult GetSubjects(string grade)
        {
            TeacherRoleSimpleViewModel model = new TeacherRoleSimpleViewModel();
            //if (Session["selectedTeacher"] != null)
            //{
            //    Teacher teacher = Session["teacher"] as Teacher;
            //    model.TeacherViewModel.Teacher = teacher;
            //}

            Dictionary<string, string> dictionary = getSubjects(grade);

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                model.TeacherRoles.Add(new TeacherRoleSimpleViewModel { GradeId = grade, SubjectId = item.Key, SubjectName = item.Value });
            }
            return PartialView("_TeacherRolesTable", model);
        }
        #endregion

        #region Save Roles
        [HttpPost]
        public ActionResult SaveRoles(string jsonStringSubject, string jsonStringRoles, FormCollection formCollection)
        {
            try
            {
                //string hidInput = formCollection["hidInput"];
                //string hiddenGrade = formCollection["hiddenGrade"];
                //string hiddenClass = formCollection["hiddenClass"];
                //string _teacherId = formCollection["hiddenTeacherId"];

                string _teacherId = TempData["roles.TeacherId"] as string;
                 _teacherId = Session["roles.TeacherId"] as string;

                if (Session["selectedTeacher"] != null)
                {
                    Teacher teacher = Session["selectedTeacher"] as Teacher;
                    _teacherId = teacher.TeacherId;
                }
                TeachingRoles teachingRole = myDeserialiseFromJson<TeachingRoles>.Deserialise(jsonStringRoles);
                List<TeachingRoles> teachingRoles = myDeserialiseFromJson<List<TeachingRoles>>.Deserialise(jsonStringSubject);
                foreach (TeachingRoles cust in teachingRoles)
                {
                    cust.TeacherId = teachingRole.TeacherId;
                    cust.GradeId = teachingRole.GradeId;
                    cust.ClassId = teachingRole.ClassId;
                }

                List<TeacherRoleSimpleViewModel> teacherRoleSimple = myDeserialiseFromJson<List<TeacherRoleSimpleViewModel>>.Deserialise(jsonStringSubject);
                for (int i = 0; i < teacherRoleSimple.Count; i++)
                {
                    if (teacherRoleSimple[i].IsSelected == false)
                    {
                        teacherRoleSimple.RemoveAt(i);
                    }
                    else
                    {
                        teacherRoleSimple[i].TeacherId = teachingRole.TeacherId;
                        teacherRoleSimple[i].GradeId = teachingRole.GradeId;
                        teacherRoleSimple[i].ClassId = teachingRole.ClassId;
                    }
                }



                teachingRolesRepository.SaveMany(teachingRoles);

                return Json(new { result = "true", message = "Data saved Successfully", title = "Request Successfully" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}
