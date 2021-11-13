using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School.Common.DelegateHandler8
{
    //https://csharpindepth.com/articles/Events


    //https://csharpindepth.com/articles/Events

    //private EventHandler _myEvent;

    //public event EventHandler MyEvent
    //{
    //    add
    //    {
    //        lock (this)
    //        {
    //            _myEvent += value;
    //        }
    //    }
    //    remove
    //    {
    //        lock (this)
    //        {
    //            _myEvent -= value;
    //        }
    //    }
    //}



    class Test
    {
        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }

            remove
            {
                Console.WriteLine("remove operation");
            }
        }

        static void Main_33()
        {
            Test t = new Test();

            t.MyEvent += new EventHandler(t.DoNothing);
            t.MyEvent -= null;
        }

        void DoNothing(object sender, EventArgs e)
        {
        }
    }
}

namespace School.Common.DelegateHandler
{
    //http://etutorials.org/Programming/visual-c-sharp/Part+II+Advanced+C/Chapter+6+Delegates+and+Attributes/Handling+Events/
    //https://www.akadia.com/services/dotnet_delegates_and_events.html
    //https://www.tutorialspoint.com/compile_csharp_online.php
    public delegate string MyDel(string str);

    class EventProgram
    {
        event MyDel MyEvent;

        public EventProgram()
        {
            this.MyEvent += new MyDel(this.WelcomeUser);
        }

        public string WelcomeUser(string username)
        {
            return "Welcome " + username;
        }

        static void Main_6(string[] args)
        {
            EventProgram obj1 = new EventProgram();
            string result = obj1.MyEvent("Tutorials Point");
            Console.WriteLine(result);
        }

    }
}
