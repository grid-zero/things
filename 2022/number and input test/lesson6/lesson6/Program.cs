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
            string thing2 = Console.ReadLine();
            string Operrand = Console.ReadLine();
            string[] words = thing.Split(',');
            string[] words2 = thing2.Split(',');
            //int[] numbs = new int[words.Length];
            //int[] numbs2 = new int[words2.Length];
            double[] numbs = Array.ConvertAll(words, double.Parse);
            double[] numbs2 = Array.ConvertAll(words2, double.Parse);
            double[] result = new double[numbs.Length];
            switch (Operrand) {
                case "+":

                    for (int i = 0; i < numbs.Length; i++)
                    {
                        result[i] = numbs[i] + numbs2[i];
                        Console.WriteLine(result[i]);
                    }
                    break;
                case "-":

                    for (int i = 0; i < numbs.Length; i++)
                    {
                        result[i] = numbs[i] - numbs2[i];
                        Console.WriteLine(result[i]);
                    }
                    break;
                case "*":
                    for (int i = 0; i < numbs.Length; i++)
                    {
                     result[i] = numbs[i] * numbs2[i];
                     Console.WriteLine(result[i]);
                    }
                    break;
                case "/":
                    for (int i = 0; i < numbs.Length; i++)
                    {
                        result[i] = (numbs[i]/numbs2[i]);
                        Console.WriteLine("divided"+result[i]);
                    }
                    break;

        }

            while (true) { }
        }
    }
}


