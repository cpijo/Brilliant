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
    //[userPagePermissionAttribute(permissionID = new int[] { 500 })]
    public class z_TeachingRolesController : BaseController
    {
        private ITeachingRolesRepository teachingRolesRepository;

        public z_TeachingRolesController(ITeachingRolesRepository teachingRolesRepository)
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
        public ActionResult SaveRoles(string teacherId, TeacherRoleSimpleViewModel _model, string grade, FormCollection formCollection)
        {
            try
            {
                string hidInput = formCollection["hidInput"];
                string hiddenGrade = formCollection["hiddenGrade"];
                string hiddenClass = formCollection["hiddenClass"];
                string _teacherId = formCollection["hiddenTeacherId"];

                _teacherId = TempData["roles.TeacherId"] as string;
                _teacherId= Session["roles.TeacherId"] as string;

                if (Session["selectedTeacher"] != null)
                {
                    Teacher teacher = Session["teacher"] as Teacher;
                    _teacherId = teacher.TeacherId;
                }

                List<TeachingRoles> teachingRoles = myDeserialiseFromJson<List<TeachingRoles>>.Deserialise(hidInput);
                foreach (TeachingRoles cust in teachingRoles)
                {
                    cust.TeacherId = _teacherId;
                    cust.ClassId = hiddenClass;
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


















        [HttpPost]
        public ActionResult Edit_Exclude([Bind(Exclude = "StudentId, StudentName")] Student std)
        {
            var name = std.Firstname;

            //@Html.Label("StudentId:")  
            //@Html.TextBox("StudentName")

            return RedirectToAction("TestIndex");
        }

        /*
        https://csharp.hotexamples.com/examples/-/SelectList/-/php-selectlist-class-examples.html
        https://csharp.hotexamples.com/examples/-/SelectList/-/php-selectlist-class-examples.html
        https://csharp.hotexamples.com/examples/-/SelectList/-/php-selectlist-class-examples.html
        https://csharp.hotexamples.com/examples/-/SelectList/-/php-selectlist-class-examples.html
        public void SelectHelpersUseCurrentCultureToConvertValues()
        {
            // Arrange
            HtmlHelper defaultValueHelper = MvcHelper.GetHtmlHelper(new ViewDataDictionary
            {
                { "foo", new[] { new DateTime(1900, 1, 1, 0, 0, 1) } },
                { "bar", new DateTime(1900, 1, 1, 0, 0, 1) }
            });
            HtmlHelper helper = MvcHelper.GetHtmlHelper();
            SelectList selectList = new SelectList(GetSampleCultureAnonymousObjects(), "Date", "FullWord", new DateTime(1900, 1, 1, 0, 0, 0));

            var tests = new[]
            {
                // DropDownList(name, selectList, optionLabel)
                new
                {
                    Html = "<select id=\"foo\" name=\"foo\"><option selected=\"selected\" value=\"01/01/1900 00:00:00\">Alpha</option>" + Environment.NewLine
                         + "<option value=\"01/01/1900 00:00:01\">Bravo</option>" + Environment.NewLine
                         + "<option value=\"01/01/1900 00:00:02\">Charlie</option>" + Environment.NewLine
                         + "</select>",
                    Action = new Func<MvcHtmlString>(() => helper.DropDownList("foo", selectList, (string)null))
                },
                // DropDownList(name, selectList, optionLabel) (With default value selected from ViewData)
                new
                {
                    Html = "<select id=\"bar\" name=\"bar\"><option value=\"01/01/1900 00:00:00\">Alpha</option>" + Environment.NewLine
                         + "<option selected=\"selected\" value=\"01/01/1900 00:00:01\">Bravo</option>" + Environment.NewLine
                         + "<option value=\"01/01/1900 00:00:02\">Charlie</option>" + Environment.NewLine
                         + "</select>",
                    Action = new Func<MvcHtmlString>(() => defaultValueHelper.DropDownList("bar", selectList, (string)null))
                },
                // ListBox(name, selectList)
                new
                {
                    Html = "<select id=\"foo\" multiple=\"multiple\" name=\"foo\"><option selected=\"selected\" value=\"01/01/1900 00:00:00\">Alpha</option>" + Environment.NewLine
                         + "<option value=\"01/01/1900 00:00:01\">Bravo</option>" + Environment.NewLine
                         + "<option value=\"01/01/1900 00:00:02\">Charlie</option>" + Environment.NewLine
                         + "</select>",
                    Action = new Func<MvcHtmlString>(() => helper.ListBox("foo", selectList))
                },
                // ListBox(name, selectList) (With default value selected from ViewData)
                new
                {
                    Html = "<select id=\"foo\" multiple=\"multiple\" name=\"foo\"><option value=\"01/01/1900 00:00:00\">Alpha</option>" + Environment.NewLine
                         + "<option selected=\"selected\" value=\"01/01/1900 00:00:01\">Bravo</option>" + Environment.NewLine
                         + "<option value=\"01/01/1900 00:00:02\">Charlie</option>" + Environment.NewLine
                         + "</select>",
                    Action = new Func<MvcHtmlString>(() => defaultValueHelper.ListBox("foo", selectList))
                }
            };

            // Act && Assert
            foreach (var test in tests)
            {
                Assert.Equal(test.Html, test.Action().ToHtmlString());
            }
        }


        */











        public void DropDownListUsesExplicitValueIfNotProvidedInViewData()
        {
            /*
            // Arrange
            HtmlHelper helper = MvcHelper.GetHtmlHelper(new ViewDataDictionary());
            SelectList selectList = new SelectList(MultiSelectListTest.GetSampleAnonymousObjects(), "Letter", "FullWord", "C");

            // Act
            MvcHtmlString html = helper.DropDownList("foo", selectList, (string)null );

            // Assert
            Assert.Equal(
                "<select id=\"foo\" name=\"foo\"><option value=\"A\">Alpha</option>" + Environment.NewLine
              + "<option value=\"B\">Bravo</option>" + Environment.NewLine
              + "<option selected=\"selected\" value=\"C\">Charlie</option>" + Environment.NewLine
              + "</select>",
                html.ToHtmlString());

            */
        }
        public enum MySkills
        {
            ASPNETMVC,
            ASPNETWEPAPI,
            CSHARP,
            DOCUSIGN,
            JQUERY
        }

        public void dropboxPopulating()
        {
            var myskill = new List<ConvertEnum>();
            foreach (MySkills lang in Enum.GetValues(typeof(MySkills)))
                myskill.Add(new ConvertEnum
                {
                    Value = (int)lang,
                    Text = lang.ToString()
                });
            ViewBag.MySkillEnum = myskill;
        }
        public void dropboxPopulating_Usage()
        {
            //https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/

            /*<tr>
    <td> Populating From Enum </td>
    <td> @Html.DropDownList("MySkills", new SelectList(ViewBag.MySkillEnum, "Value", "Text")) </td>
</tr>*/
        }


    }

    public struct ConvertEnum
    {
        public int Value
        {
            get;
            set;
        }
        public String Text
        {
            get;
            set;
        }
    }
}

