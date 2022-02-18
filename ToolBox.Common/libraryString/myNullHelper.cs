using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Common
{
    public static class myNullHelper
    {

        public static string nullToEmptyString(string input)
        {
            if (input == null)
            {
                input = "";
            }
            return input;
        }

        public static object nullToEmpty(object input)
        {
            var hh= input.GetType();
            if (input.GetType() == typeof(string))
            {
                if (input == null)
                {
                    input = "";
                }
            }
            else if (input.GetType() == typeof(int))
            {
                if (input == null)
                {
                    input = 0;
                }
            }
          
            return input;
        }
    }
}
