using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Common
{
    public class myStringHelper
    {
        //https://www.dotnetperls.com/duplicates
        public List<string> RemoveDuplicatesIterative(List<string> items)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                // Assume not duplicate.
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (items[z] == items[i])
                    {
                        // This is a duplicate.
                        duplicate = true;
                        break;
                    }
                }
                // If not duplicate, add to result.
                if (!duplicate)
                {
                    result.Add(items[i]);
                }
            }
            return result;
        }
        //public List<userADS> RemoveDuplicatesIterative_Advanced(List<userADS> items)
        //{
        //    List<userADS> result = new List<userADS>();
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        // Assume not duplicate.
        //        bool duplicate = false;
        //        for (int z = 0; z < i; z++)
        //        {
        //            if (items[z].userPhone == items[i].userPhone)
        //            {
        //                // This is a duplicate.
        //                duplicate = true;
        //                break;
        //            }
        //        }
        //        // If not duplicate, add to result.
        //        if (!duplicate)
        //        {
        //            result.Add(items[i]);
        //        }
        //    }
        //    return result;
        //}

         void testMain(string[] args)

        {

            string s = "Name:{0} {1}, Location:{2}, Age:{3}";

            string msg = string.Format(s, "Suresh", "Dasari", "Hyderabad", 32);

            Console.WriteLine("Format Result: {0}", msg);

            Console.WriteLine("\nPress Enter Key to Exit..");

            Console.ReadLine();

        }

        public bool isNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (Char.IsDigit(number[i]))
                { }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool isNumberSimple(string number)
        {
            int isPhone;
            bool success = Int32.TryParse(number, out isPhone);
            if (success)
            {
                success=true;
            }
            else
            {
                success = false ;
            }
            return success;
        }

        static int validate_Number(string s)
        {
            string s1 = "";
            int f;
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j <= 9; j++)
                {
                    string c = j.ToString();
                    if (c[0] == s[i])
                    {
                        s1 += c[0];
                    }
                }

            if (s == s1)
                f = 0;
            else
                f = 1;

            return f;
        }

        public string myTrimStart_Easy(string inp, string chars)
        {
            while (chars.Contains(inp[0]))
            {
                inp = inp.Substring(1);
            }

            return inp;
        }

        public string myTrimEnd_Easy(string inp, string chars)
        {
            while (chars.Contains(inp[inp.Length - 1]))
            {
                inp = inp.Substring(0, inp.Length - 1);
            }

            return inp;
        }

        public string removeLeadingSpace(string myString)
        {
            myString = "example";
            int i = 0;
            // while there is an a in s
            while (myString.IndexOf("a") >= 0)
            {
                // Find and save the next index for an a
                i = myString.IndexOf("a");
                // Process the string at that index
                String ithLetter = myString.Substring(i, i + 1);
                //    
            }
            return myString;
        }

        public static void RemoveDuplicates<T>(IList<T> list)
        {
            if (list == null)
            {
                return;
            }
            int i = 1;
            while (i < list.Count)
            {
                int j = 0;
                bool remove = false;
                while (j < i && !remove)
                {
                    if (list[i].Equals(list[j]))
                    {
                        remove = true;
                    }
                    j++;
                }
                if (remove)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }



    }
}
