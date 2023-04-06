using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string continued = "";
        while (continued != "n")
        {
            Console.WriteLine("stander(s)or matrix(m)");
        var type = Console.ReadLine();
            if (type == "s")
            {
                //Initialie variables and List
                double result = 0;
                //double number0 = 0;
                //double number1 = 0;
                List<int> numbs = new List<int>();

                //Prompt User for Opperation type and the number of values to add
                Console.WriteLine("Welcome to a simple calculator\nPlease choose which operation you would like to peform(+,-,*,/,sqr,sqrt)");
                var Opperand = (Console.ReadLine());
                Console.WriteLine("Please enter the number of values you would like to enter(ignore if square or sqrt)");
                int amount = int.Parse(Console.ReadLine());

                //If they enter + then do this
                switch (Opperand)
                {
                    case "+":
                        Console.WriteLine("Please enter " + amount + " numbers");//Prompt for Numbers
                        numbs.Add(int.Parse(Console.ReadLine()));//Prompt then add the first number to avoid
                        result = numbs[0];                     //issues like dividing or timesing by zero
                        for (int i = 1; i < amount; i++)
                        {
                            //Prompt for numbers untill all are added and add(or other opperation) them together
                            numbs.Add(int.Parse(Console.ReadLine()));
                            result += numbs[i];
                        }
                        break;

                    case "-":
                        Console.WriteLine("Please enter " + amount + " numbers");
                        numbs.Add(int.Parse(Console.ReadLine()));
                        result = numbs[0];
                        for (int i = 1; i < amount; i++)
                        {

                            numbs.Add(int.Parse(Console.ReadLine()));
                            result -= numbs[i];
                        }
                        break;

                    case "*":
                        Console.WriteLine("Please enter " + amount + " numbers");
                        numbs.Add(int.Parse(Console.ReadLine()));
                        result = numbs[0];
                        for (int i = 1; i < amount; i++)
                        {
                            numbs.Add(int.Parse(Console.ReadLine()));
                            result *= numbs[i];
                        }
                        break;

                    case "/":
                        Console.WriteLine("Please enter " + amount + " numbers");
                        numbs.Add(int.Parse(Console.ReadLine()));
                        result = numbs[0];
                        for (int i = 1; i < amount; i++)
                        {

                            numbs.Add(int.Parse(Console.ReadLine()));
                            result /= numbs[i];
                        }
                        break;

                    case "sqr":
                        Console.WriteLine("Please enter 1 number");
                        numbs.Add(int.Parse(Console.ReadLine()));
                        result = Math.Pow(numbs[0], 2);
                        break;

                    case "sqrt":
                        Console.WriteLine("Please enter 1 number");
                        numbs.Add(int.Parse(Console.ReadLine()));
                        result = Math.Sqrt(numbs[0]);
                        break;
                }


                //output result
                Console.WriteLine("The result is: " + result);

            }
            else if (type == "m")
            {
                Console.WriteLine("Please enter matrix");
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
                        Console.WriteLine("numbs x" + numbs.GetLength(0));
                        Console.WriteLine("numbs y" + numbs2.GetLength(1));
                        Console.WriteLine("numbs 2 y" + numbs2.GetLength(0));
                        for (int i = 0; i < numbs.GetLength(0); i++)
                        {
                            for (int j = 0; j < numbs2.GetLength(1); j++)
                            {
                                for (int n = 0; n < numbs2.GetLength(1); n++)
                                {
                                    Console.Write(" i = " + i);
                                    Console.Write(" j = " + j);
                                    Console.Write(" n = " + n);
                                    Console.WriteLine("");
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
            }
            Console.WriteLine("coninue with more claculations?(y/n)(case sensative)");
            continued = Console.ReadLine();
        }
        while (true) { }
    }
}