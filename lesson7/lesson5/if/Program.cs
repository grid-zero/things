using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @if
{
    class Program
    {


        static void isVowel()
        {

            var isVowel = Console.ReadKey();
            if (isVowel = 'a' || 'e' || 'i' || 'o' || 'u')
            {

            }

        }



        static void Main()
        {
            int a = 1;
            int b = 5;
            int c = 2;

            if (a>b && a>c)
            {
                Console.WriteLine("a is big");
            }else if (b > c)
            {
                Console.WriteLine("b is big");
            }else
            {
                Console.WriteLine("c is big");
            }



            if (a<0 || b<0 || c<0)
            {
                Console.WriteLine("there is a negative");
            }else
            {
                Console.WriteLine("there is no negative");
            }


            if (a%2 == 0)
            {
                Console.WriteLine("a is even");
            }
            if (b % 2 == 0)
            {
                Console.WriteLine("b is even");
            }
            if (c % 2 == 0)
            {
                Console.WriteLine("c is even");
            }

            


            while (true){ };
        }
       
    }
}
