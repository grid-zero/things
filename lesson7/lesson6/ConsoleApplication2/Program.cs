using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string continued = "";
        while (continued != "n")
        {
            Console.WriteLine("please select standard (s) or matrix (m) mode");
            var type = Console.ReadLine();
            if (type == "s")
            {
                
                    Console.WriteLine("PLease enter an equation, supported operands are +,-,*,/,^, then press enter");
                    string input = Console.ReadLine();
                    string inputSpace = Regex.Replace(input, " ", "");

                    string[] splitInput = Regex.Split(inputSpace, @"(\+|\-|\*|\/|\^)");
                    List<string> stringList = splitInput.ToList();
                    string[] check = { "+", "-", "*", "/", "^" };

                    for (int i = 0; i < stringList.Count; i++)
                    {
                        if (stringList[i] == "")
                        {
                            stringList.RemoveAt(i);
                        }
                    }

                    int order = 2;
                    for (int i = 1; i < stringList.Count; i++)
                    {
                        if (check.Contains(stringList[i - 1]) && stringList[i] == "-")
                        {
                            int.TryParse(stringList[i + 1], out int n);
                            stringList[i + 1] = (n * -1).ToString();
                            stringList.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < stringList.Count; i++)
                    {
                        try
                        {
                            double temp;

                            if (order == 2)
                            {
                                if (stringList[i] == "^")
                                {

                                    temp = Math.Pow(double.Parse(stringList[i - 1]), double.Parse(stringList[i + 1]));
                                    stringList[i] = temp.ToString();
                                    stringList.RemoveAt(i - 1);
                                    stringList.RemoveAt(i);
                                    i = 0;
                                }

                                else if (i == stringList.Count - 1)
                                {

                                    order = 1;
                                    i = 0;
                                }
                            }

                            if (order == 1)
                            {
                                switch (stringList[i])
                                {
                                    case "*":
                                        temp = (double.Parse(stringList[i - 1]) * (double.Parse(stringList[i + 1])));
                                        stringList[i] = temp.ToString();
                                        stringList.RemoveAt(i - 1);
                                        stringList.RemoveAt(i);
                                        i = 0;
                                        break;

                                    case "/":
                                        temp = (double.Parse(stringList[i - 1]) / (double.Parse(stringList[i + 1]) + 0.0));
                                        stringList[i] = temp.ToString();
                                        stringList.RemoveAt(i - 1);
                                        stringList.RemoveAt(i);
                                        i = 0;
                                        break;

                                    default:
                                        if (i == stringList.Count - 1)
                                        {
                                            order = 0;
                                            i = 0;
                                        }
                                        break;
                                }
                            }

                            if (order == 0)
                            {
                                switch (stringList[i])
                                {
                                    case "+":
                                        temp = (double.Parse(stringList[i - 1]) + double.Parse(stringList[i + 1]));
                                        stringList[i] = temp.ToString();
                                        stringList.RemoveAt(i - 1);
                                        stringList.RemoveAt(i);
                                        i = 0;
                                        break;

                                    case "-":
                                        temp = (double.Parse(stringList[i - 1]) - double.Parse(stringList[i + 1]));
                                        stringList[i] = temp.ToString();
                                        stringList.RemoveAt(i - 1);
                                        stringList.RemoveAt(i);
                                        i = 0;
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "\nPlease Enter Valid Input");
                        }
                    }
                    Console.WriteLine(input + " = " + stringList[0].ToString());

                
            }

            else if (type == "m")
            {
                
                Console.WriteLine("Please enter opperand(+ or - or *)");
                var Operand = Console.ReadLine();

                int xd;
                int yd;
                int xd2;
                int yd2;
               
                Console.WriteLine("Please enter matrix x length then y length for 2 matrices, ie: a matrix\n 1 2 3\n 4 5 6\n would take input x is 3, y is 2 in the form\n 3 \n 2");

                xd = int.Parse(Console.ReadLine());
                yd = int.Parse(Console.ReadLine());

                xd2 = int.Parse(Console.ReadLine());
                yd2 = int.Parse(Console.ReadLine());

                   

                Console.WriteLine("Please enter matrix with values sepperated by ' ' and rows optionaly sepperated by ',' ie. 1 2,3 4 or 1 2 3 4");
                string input = Console.ReadLine();
                string input2 = Console.ReadLine();

                int[] splitInput = Array.ConvertAll(input.Split(' ',','),int.Parse);
                int[] splitInput2 = Array.ConvertAll(input2.Split(' ', ','), int.Parse);

                int[,] numbs = new int[yd, xd];
                int[,] numbs2 = new int[yd2, xd2];
                int[,] result = new int[yd, xd2];               

                for (int j = 0, i = 0, n = 0; i < splitInput.Length; i++,n++)
                {
                    numbs[j,n] = splitInput[i];
                    if ((i+1) % xd  == 0)
                    {
                        j++;
                        n = -1;
                    }
                }

                for (int j = 0, i = 0, n = 0; i < splitInput2.Length; i++, n++)
                {
                    numbs2[j, n] = splitInput2[i];
                    if ((i + 1) % xd2 == 0)
                    {
                        j++;
                        n = -1;
                    }
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

                switch (Operand)
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
                                    result[i, j] += numbs[i, n] * numbs2[n, j];
                                }
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("error: Invalid Input");
                        break;
                }
                
                Console.WriteLine("result: ");
                for (int ij = 0; ij < result.GetLength(0); ij++)
                {
                    for (int ji = 0; ji < result.GetLength(1); ji++)
                    {
                        Console.Write(result[ij, ji].ToString()+" ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("coninue with more claculations?(y/n)(case sensative)");
            continued = Console.ReadLine();
        }
        Console.ReadKey();
    }
}