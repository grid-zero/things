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
            Console.WriteLine("Please enter matrix dimension y then x");
            int yd = int.Parse(Console.ReadLine());
            int xd = int.Parse(Console.ReadLine());
            int yd2 = int.Parse(Console.ReadLine());
            int xd2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter matrix with values sepperated by , and rows sepperated by @ ie. 1,2,@,3,4");
            string thing = Console.ReadLine();
            string thing2 = Console.ReadLine();

            string[] words = thing.Split(',');
            string[] words2 = thing2.Split(',');
            Console.WriteLine(words.Length);
            int[,] numbs = new int[yd, xd];
            int[,] numbs2 = new int[yd2, xd2];
            int[,] result = new int[yd, xd2];
            Console.WriteLine("Please enter opperand(+-*/)");
            var Opperand = Console.ReadLine();
            for (int j = 0, i = 0, o = 0; i < words.Length; i++)
            {
                if (words[i] == "@")
                {
                    j++;
                    o = 0;
                    i++;
                }
                numbs[j, o] = int.Parse(words[i]);
                o++;
            }
            //Console.WriteLine("numbs2 x" + numbs2.GetLength(1));
            Console.WriteLine("numbs2 y" + numbs2.GetLength(0));
            for (int z = 0, c = 0, v = 0; z < words2.Length; z++)
            {
                if (words2[z] == "@")
                {
                    c++;
                    v = 0;
                    z++;
                }
                numbs2[c, v] = int.Parse(words2[z]);
                v++;

                //Console.Write(" c = " + c);
                Console.Write(" v = " + v);
            }

            Console.WriteLine("matrix 1: ");
            for (int ij = 0; ij < numbs.GetLength(0); ij++)
            {
                for (int ji = 0; ji < numbs.GetLength(1); ji++)
                {
                    Console.Write(numbs[ij, ji].ToString() + " ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("matrix 2: ");
            for (int ij = 0; ij < numbs2.GetLength(0); ij++)
            {

                for (int ji = 0; ji < numbs2.GetLength(1); ji++)
                {
                    Console.Write(numbs2[ij, ji].ToString() + " ");
                }
                Console.WriteLine();

            }



            switch (Opperand)
            {

                case "+":
                    for (int i = 0; i < numbs.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbs.GetLength(1); j++)
                        {
                            result[i, j] = numbs[i, j] + numbs2[i, j];
                        }
                    }
                    break;
                case "-":
                    for (int i = 0; i < numbs.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbs.GetLength(1); j++)
                        {
                            result[i, j] = numbs[i, j] - numbs2[i, j];
                        }
                    }
                    break;
                case "*":
                    for (int i = 0; i < numbs.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbs2.GetLength(1); j++)
                        {
                            for (int n = 0; n < numbs2.GetLength(0); n++)
                            {
                                Console.WriteLine(numbs[i, n] + "*" + numbs2[n, j]);

                                result[i, j] += numbs[i, n] * numbs2[n, j];
                            }
                        }
                    }
                    break;

            }
            Console.WriteLine("rsult: ");
            for (int ij = 0; ij < result.GetLength(0); ij++)
            {
                for (int ji = 0; ji < result.GetLength(1); ji++)
                {
                    Console.Write(result[ij, ji].ToString() + " ");
                }
                Console.WriteLine();
            }

            while (true) { }
        }
    }
}




