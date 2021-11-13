using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.DelegateHandler
{
    //https://www.akadia.com/services/dotnet_delegates_and_events.html
    public class PrintHelper
    {
        // declare delegate 
        public delegate void BeforePrint();

        //declare event of type delegate
        public event BeforePrint beforePrintEvent;

        public PrintHelper()
        {
        }
        public void PrintNumber(int num)
        {
            //call delegate method before going to print
            if (beforePrintEvent != null)
                beforePrintEvent();
            Console.WriteLine("Number: {0,-12:N0}", num);
        }
        public void PrintDecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Decimal: {0:G}", dec);
            
        }
        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();
            Console.WriteLine("Money: {0:C}", money);
        }
        public void PrintTemperature(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();
            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();
            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
}
