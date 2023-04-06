using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leeson4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = {"Tesla", "Honda", "Suzuki", "BMW","Toyota"};


            Console.WriteLine(cars[0]);
            foreach(string i in cars)
            {
                Console.WriteLine(i);
            }
            Array.Sort(cars);
            Console.WriteLine("\n");
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(cars.Length);
            Console.WriteLine(cars.Last());




            while (true) { }
        }
    }
}
