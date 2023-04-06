using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a number");
            int n;
            bool allgood = int.TryParse(Console.ReadLine(), out n);
            if (allgood)
            {
                int numb = 0;
                for (int i = 0; i < n; i++)
                {
                    numb += (i + 1);
                }
                Console.WriteLine(numb);
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }



            while (true) { }
        }
    }
}


