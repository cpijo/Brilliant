using School.Common.Constants;
using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    public class BaseController : Controller
    {

        //public virtual ActionResult Download(string Filelocation, string Filename)
        //{
        //    //string Filename = TempData["fileName"] as string;
        //    var type = System.Net.Mime.MediaTypeNames.Application.Octet;
        //    Filename = Filename.Replace(",", ",");
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(Filelocation + Filename);
        //    string myfileName = Filename;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Filename);

        //    return File(fileBytes, type, Filename);
        //}

        public static List<SelectListItem> dropdownHelper(List<Roles> roles)
        {

            Dictionary<int, string> SurbubDictionary = new Dictionary<int, string>();
            foreach (Roles role in roles)
            {
                SurbubDictionary.Add(role.RoleID, role.RoleName);
            }

            return  SurbubDictionary
            .Select(item => new SelectListItem
            {
                Value = item.Key.ToString(),
                Text = item.Value.ToString(),
                Selected = true
            })
            .ToList();
        }



        public static List<SelectListItem> dropdownHelper(Dictionary<string, string> SurbubDictionary)
        {
            return SurbubDictionary
            .Select(item => new SelectListItem
            {
                Value = item.Key.ToString(),
                Text = item.Value.ToString(),
                Selected = true
            })
            .ToList();
        }

        public static Dictionary<string, string> getSubjects(string selectedValue)
        {
            Dictionary<string, string> dictionary;
            switch (selectedValue)
            {
                case "Grade8":
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
                case "Grade9":
                    dictionary = CostantData.dictGrade9Subjects();
                    break;
                case "Grade10":
                    dictionary = CostantData.dictGrade10Subjects();
                    break;
                case "Grade11":
                    dictionary = CostantData.dictGrade11Subjects();
                    break;
                case "Grade12":
                    dictionary = CostantData.dictGrade12Subjects();
                    break;
                default:
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
            }

            return dictionary;
        }

        public SelectList dropBoxDictionary(string selectedValue, string searchType)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();


            switch (selectedValue)
            {
                case "Grade8":
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
                case "Grade9":
                    dictionary = CostantData.dictGrade9Subjects();
                    break;
                case "Grade10":
                    dictionary = CostantData.dictGrade10Subjects();
                    break;
                case "Grade11":
                    dictionary = CostantData.dictGrade11Subjects();
                    break;
                case "Grade12":
                    dictionary = CostantData.dictGrade12Subjects();
                    break;
                default:
                    dictionary = CostantData.dictGrade8Subjects();
                    break;
            }

            List<SelectListItem> list = dropdownHelper(dictionary);
            SelectList selectList = new SelectList(list, "Value", "Text");
            return selectList;

        }
    }
}