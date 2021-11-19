using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.DelegateHandler
{

    class linq_test
    {
        static void Main_linq_test(string[] args)
        {
            IEnumerable<Fruit> fruits = new List<Fruit> {
            new Fruit {
               Name = "Apple",
               Size = "Small"
            },
            new Fruit {
               Name = "Orange",
               Size = "Small"
            },
            new Fruit {
               Name = "Mango",
               Size = "Medium"
            }
         };
            foreach (var fruit in fruits)
            {
                Console.WriteLine($"Fruit Details Before Update. {fruit.Name}, {fruit.Size}");
            }
            foreach (var fruit in fruits.Where(w => w.Size == "Small"))
            {
                fruit.Size = "Large";
            }
            foreach (var fruit in fruits)
            {
                Console.WriteLine($"Fruit Details After Update. {fruit.Name}, {fruit.Size}");
            }
            Console.ReadLine();
        }
    }
    public class Fruit
    {
        public string Name { get; set; }
        public string Size { get; set; }
    }


}
