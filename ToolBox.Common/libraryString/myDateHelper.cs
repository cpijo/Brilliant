using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Common
{
    public class myDateHelper
    {
        private static string getMonthToNumber(string month)
        {
            string monthNumber = "";
            switch (month)
            {
                case "January":
                    monthNumber = "1";
                    break;
                case "February":
                    monthNumber = "2";
                    Console.WriteLine("February");
                    break;
                case "March":
                    monthNumber = "3";
                    Console.WriteLine("March");
                    break;
                case "April":
                    monthNumber = "4";
                    Console.WriteLine("April");
                    break;
                case "May":
                    monthNumber = "5";
                    Console.WriteLine("May");
                    break;
                case "June":
                    monthNumber = "6";
                    Console.WriteLine("June");
                    break;
                case "July":
                    monthNumber = "7";
                    Console.WriteLine("July");
                    break;
                case "August":
                    monthNumber = "8";
                    Console.WriteLine("August");
                    break;
                case "September":
                    monthNumber = "9";
                    Console.WriteLine("September");
                    break;
                case "October":
                    monthNumber = "10";
                    Console.WriteLine("October");
                    break;
                case "November":
                    monthNumber = "11";
                    Console.WriteLine("November");
                    break;
                case "December":
                    monthNumber = "12";
                    Console.WriteLine("December");
                    break;
                default:
                    monthNumber = "0";
                    Console.WriteLine("you did not enter correct value for month name");
                    break;
            }
            return monthNumber;
            //throw new NotImplementedException();
        }

        public static string getNumberToMonth(string _date, string todayDate)
        {
            if (_date == "" || _date =="Null" || _date == null)
            {
                _date = "01/01/2000";
            }

            string month = _date.Substring(3, 2);
            string newDate = _date.Substring(0,2)+" {0} "+ _date.Substring(6);
            if (_date == todayDate)
            {
                month = "0";
            }
            else if (int.Parse(todayDate.Substring(0, 2)) - int.Parse(_date.Substring(0, 2)) == 1)
            {
                 if (_date.Substring(2) == todayDate.Substring(2))
                {
                    month = "-1";
                }
            }
            string monthNumber = "";
            switch (month)
            {
                case "1":
                    monthNumber = "January";
                    newDate = String.Format(newDate, monthNumber);
                    break;
                case "2":
                    monthNumber = "February";
                    newDate = String.Format(newDate, monthNumber);
                    break;
                case "3":
                    monthNumber = "March";
                    newDate = String.Format(newDate, monthNumber);
                    break;
                case "4":
                    monthNumber = "April";
                    newDate = String.Format(newDate, monthNumber);
                    break;
                case "5":
                    monthNumber = "May";
                    newDate = String.Format(newDate, monthNumber);
                    break;
                case "6":
                    monthNumber = "June";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "7":
                    monthNumber = "July";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "8":
                    monthNumber = "August";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "9":
                    monthNumber = "September";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "10":
                    monthNumber = "October";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "11":
                    monthNumber = "November";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "12":
                    monthNumber = "December";
                    newDate = String.Format(newDate, monthNumber); 
                    break;
                case "0":
                    monthNumber = "Today";
                    newDate = monthNumber;
                    break;
                case "-1":
                    monthNumber = "Yesteday";
                    newDate = monthNumber;
                    break;
                default:
                    monthNumber = "0";                    
                    break;
            }
            return newDate;
            //throw new NotImplementedException();
        }


    }
}



//http://net-informations.com/q/faq/stringdate.html

//string iDate = "05/05/2005";
//DateTime oDate = Convert.ToDateTime(iDate);
//MessageBox.Show(oDate.Day + " " + oDate.Month + "  " + oDate.Year );

//string iDate = "2005-05-05";
//DateTime oDate = DateTime.Parse(iDate);
//MessageBox.Show(oDate.Day + " " + oDate.Month + "  " + oDate.Year);

//string iString = "2005-05-05 22:12 PM";
//DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
//MessageBox.Show(oDate.ToString());


