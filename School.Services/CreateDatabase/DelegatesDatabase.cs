using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.CreateDatabase
{
    //User Specific Notifications Using ASP.NET MVC And SignalR
    //https://www.c-sharpcorner.com/article/user-specific-notifications-using-asp-net-mvc-and-signalr/

    public delegate void DelEventHandler();
    public class DelegatesDatabase
    {
        public static event DelEventHandler eventDel;
        public void CreateDatabase(int x, int y)
        {
            Console.WriteLine("Create Database:" + (x + y));
        }
        public void UseDatabase(int x, int y)
        {
            Console.WriteLine("Use Database is:" + (x - y));
        }
        public void CreateDatabaseTables(int x, int y)
        {
            Console.WriteLine("Create Database Tables is:" + (x * y));
        }
        public void InsertTablesData(int x, int y)
        {
            Console.WriteLine("Insert TablesData is:" + (x * y));
        }
    }


   
    public class DelegateTestOne
    {
        public static event DelEventHandler eventDel;
        void Main_Test(string[] args)
        {
            DelegatesDatabase del = new DelegatesDatabase();
            //eventDel += new DelEventHandler(del.CreateDatabase);
            //eventDel += new DelEventHandler(del.UseDatabase);
            //eventDel += new DelEventHandler(del.CreateDatabaseTables);
            //eventDel += new DelEventHandler(del.InsertTablesData);
            eventDel.Invoke();

            Console.ReadLine();
        }
     }



}
