using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Models.Common.MVCHelpers
{

public class DropboxHelper
{
    public List<SelectListItem> GetDownList(Dictionary<string, string> SurbubDictionary)
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

    public string GetValueByKey(string key, Dictionary<string, string> dictionary)
    {
        foreach (KeyValuePair<string, string> pair in dictionary)
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }
        return "";
    }
}
}