using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Models.Common
{
    public class SelectListHelper
    {
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
    }


}