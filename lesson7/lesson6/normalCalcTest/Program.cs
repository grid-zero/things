using System.Text.RegularExpressions;

namespace normalCalcTest
{
    class Program
    {

        static void Main(string[] args)
        {
            while(true)
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
        }
        
    }
}