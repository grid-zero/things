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
            string thing = Console.ReadLine();
            string[] words = thing.Split(',');
            int[] numbs = new int[words.Length];
            for (int i = 0; i < numbs.Length; i++)
            {
                numbs[i] = int.Parse(words[i]);
            }
            int abc = numbs.Sum();
            //int minus = 
            //Console.WriteLine(abc);





            while (true) { }
        }
    }
}
