using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.DelegateHandler
{
    //https://tomchizek.medium.com/net-core-actions-routes-handlers-and-methods-aab3ac7a25f3
    class delegateSimple
    {
        class Program_2
        {
            public void Add(int x, int y)
            {
                Console.WriteLine("Sum is:" + (x + y));
            }
            public void Subtract(int x, int y)
            {
                Console.WriteLine("Difference is:" + (x - y));
            }
            public void Multiply(int x, int y)
            {
                Console.WriteLine("Product is:" + (x * y));
            }
            public void Divide(int x, int y)
            {
                Console.WriteLine("Quotient is:" + (x / y));
            }
        }
        public delegate void MultiCastDelegate(int a, int b);
        class ClsDelegate
        {
            static void Main()
            {
                Program_2 obj1 = new Program_2();
                MultiCastDelegate objD = new MultiCastDelegate(obj1.Multiply);
                objD += obj1.Add;
                objD += obj1.Subtract;
                objD += obj1.Divide;
                objD(40, 10);
                objD -= obj1.Add;
                objD -= obj1.Divide;
                objD(50, 10);
                Console.ReadLine();
            }
        }
    }


    public delegate T add<T>(T param1, T param2); // generic delegate

    class Program_co
    {
        static void Main_co(string[] args)
        {
            add<int> sum = Sum;
            Console.WriteLine(sum(10, 20));

            add<string> con = Concat;
            Console.WriteLine(con("Hello ", "World!!"));
        }

        public static int Sum(int val1, int val2)
        {
            return val1 + val2;
        }

        public static string Concat(string str1, string str2)
        {
            return str1 + str2;
        }
    }


}



/*
 * https://tomchizek.medium.com/net-core-mvc-http-request-routing-7821a7f7d2d2
 
     app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "deeper",
        pattern: "{controller}/{action}/{subaction}/{id?}");
    endpoints.MapControllerRoute(
        name: "paging",
        pattern: "{controller}/{action}/{id} page={page}");
    endpoints.MapControllerRoute(
        name: "paging-deeper",
        pattern: "{controller}/{action}/{subaction}/{id} page={page}");
});
     
 
 [Route("Home")]
public class HomeController : Controller
{...}
[Route("StarCharts")]
public class StarChartsController : Controller
{...}
[Route("Stars")]
public class StarsController : Controller
{...}
[Route("Planets")]
public class PlanetsController : Controller
{...}   



     
     */
