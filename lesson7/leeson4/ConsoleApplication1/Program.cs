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
            int[] numbs = { 66, 56, 62, 74, 40, 11, 41, 1 };
            Console.WriteLine("The Max integer unsorted is: " + numbs.Max());
            Array.Sort(numbs);
            Console.WriteLine("The Max integer sorted is: " + numbs.Max());

            string txt = Console.ReadLine();

            char[] chars = txt.ToCharArray();
           
            for(int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'x')
                {
                    Console.WriteLine("The String Contains an x");
                }

            }
            Console.WriteLine("The Length of the string is: "+chars.Length);

            while (true) { }


        }
    }
}
