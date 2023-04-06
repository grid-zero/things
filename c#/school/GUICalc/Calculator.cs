using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GUICalc
{
   
    internal class Calculator
    {

        char[] ints = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string[] opperand = new string[] { "+", "-", "*", "/", "^", "×", "÷" };
        string[] bracket = new string[] { "(", ")" };
                    
        Dictionary<string, string> Variables = new Dictionary<string, string> { {"pi", "3.14159" }, {"π", "3.14159" }, {"ans", "0" }, { "Ans","0"} };        

        public Calculator()
        {           

        }


        public string Calculate(string ConsoleInput)
        {
            ConsoleInput = ConsoleInput.Replace('÷', '/');
            ConsoleInput = ConsoleInput.Replace('×', '*');
            if (ConsoleInput.Contains("="))
            {
                return EquationCalc(ConsoleInput);
            }

            string result = SimpleCalc(ConsoleInput);
            
            Variables["ans"] = result;
            Variables["Ans"] = result;
            return result;
        }

        private string SimpleCalc(string ConsoleInput)
        {

            List<string> splitInput = Regex.Split(ConsoleInput, @"\s*([-+/*^()])\s*").ToList();
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));
            splitInput = ReplaceVariables(splitInput, ref Variables);
            if (splitInput.Count == 0)
            {
                return "";
            }
            string result;
            if (splitInput.Contains("(") | splitInput.Contains(")"))
            {
                splitInput = EvaluateInputComplex(splitInput);
            }
            try
            {
                result = EvaluateInputSimple(splitInput)[0];
            }
            catch (Exception ex)
            {
                return "";
            }
            if (result == null)
            {
                result = "";

            }
            if(double.TryParse(splitInput[0],out double test) == true)
            {
                if(Math.Abs(test)>1e10 || Math.Abs(test) < 1e-10)
                {
                    result = test.ToString("E6");
                }
            }
            return result;
        }
    
        private string EquationCalc(string ConsoleInput)
        {
            List<string> splitInput = Regex.Split(ConsoleInput, @"\s*([=])\s*").ToList();
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));
            if (splitInput.Count == 0)
            {
                return "";
            }

            if (splitInput.Count >= 3)
            {
                if (splitInput[0].Contains("("))
                {
                    return "invalid input";
                }
                return Equation(splitInput);
            }
            return ConsoleInput;
        }

        
        private List<string> EvaluateInputComplex(List<string> input)
        {
            try
            {
                input = SimplifyPM(input);
                input = SimplifyConsecutiveSign(input);
                while (input.Contains("(") | input.Contains(")"))
                {
                    while (input.Contains("^"))
                    {

                        List<List<string>> splitBracket2 = SplitBrackets(input);
                        input = ParseBrackets(splitBracket2);
                        input = ExpOrderComplex(input);
                        input = SimplifyImplicetMult(input);
                        splitBracket2 = SplitBrackets(input);

                        if (splitBracket2[0][0] == "invalid brackets")
                        {
                            return splitBracket2[0];
                        }
                        if (splitBracket2[0][0] == "invalid input")
                        {
                            return splitBracket2[0];
                        }
                        input = ParseBracketsNew(splitBracket2);
                    }
                    List<List<string>> splitBracket = SplitBrackets(input);
                    input = ParseBrackets(splitBracket);
                    input = ExpOrderComplex(input);
                    input = SimplifyImplicetMult(input);
                    splitBracket = SplitBrackets(input);
                    if(splitBracket[0][0] == "invalid brackets")
                    {
                        return splitBracket[0];
                    }
                    if (splitBracket[0][0] == "invalid input")
                    {
                        return splitBracket[0];
                    }
                    input = ParseBrackets(splitBracket);
                    

                }
                
                input = ExpOrder(input);
                input = MDOrder(input);
                input = PMOrder(input);
                
            }

            finally
            {
                Console.WriteLine("Error in input");
                
            }
           return input;

        }

        private List<string> EvaluateInputSimple(List<string> input)
        {
            try
            {
                input = SimplifyPM(input);
                input = SimplifyConsecutiveSign(input);
                input = ExpOrder(input);
                input = MDOrder(input);
                input = PMOrder(input);


                if (input.Count != 0)
                {
                    float.Parse(input[0]);
                    return input;
                }
            }

            catch(Exception e)
            {
                input[0] = "invalid input";
                return input;

            }
            return input;

        }
        private string Equation(List<string> equation)
        {

            equation.RemoveAll(index => index == "=");
            equation.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));
            if (equation.Count != 2)
            {
                return "invalid equation arguments";
            }

            if (ints.Contains(equation[0][0]) | opperand.Any(index => equation[0].Contains(index)))
            {
                return "invalid variable name";
            }

            if (double.TryParse(EvaluateEquationRightSide(equation[1]), out double result) == false)
            {
                return "invalid right side of equation";
            }
            if (Variables.ContainsKey(equation[0]))
            {
                Variables[equation[0]] = result.ToString("F10");
                return result.ToString("F10");
            }
            Variables.Add(equation[0], result.ToString("F10"));
            return result.ToString("F10");



        }
        private string EvaluateEquationRightSide(string input)
        {

            List<string> splitInput = Regex.Split(input, @"\s*([-+/*^()])\s*").ToList();
            splitInput = ReplaceVariables(splitInput, ref Variables);
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));


            if (splitInput.Contains("(") | splitInput.Contains(")"))
            {
                splitInput = EvaluateInputComplex(splitInput);
            }

            string result = EvaluateInputSimple(splitInput)[0];
            return result;
        }
        private List<string> ReplaceVariables(List<string> input, ref Dictionary<string, string> variables)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (variables.ContainsKey(input[i]))
                {
                    input[i] = Variables[input[i]];
                }

            }
            return input;
        }

        private List<string> SimplifyImplicetMult(List<string> implicetInput)
        {
            for(int i = 0; i < implicetInput.Count-1; i++)
            {
                if (!opperand.Contains(implicetInput[i]) & !bracket.Contains(implicetInput[i])  & implicetInput[i+1] == "(")
                {                    
                    implicetInput.Insert(i, "(");
                    implicetInput.Insert(i + 2, "*");
                    
                    int open = 1;
                    int close = 0;
                    for(int j = i+3; j < implicetInput.Count; j++)
                    {
                        if (implicetInput[j] == "(")
                        {
                            open++;
                        }
                        if (implicetInput[j] == ")")
                        {
                            close++;
                        }
                        if (open == close + 1)
                        {
                            implicetInput.Insert(j+1,")");
                        }
                    }                   
                }

                if(implicetInput[i] == ")" & !opperand.Contains(implicetInput[i+1]) & !bracket.Contains(implicetInput[i + 1]))
                {                    
                    implicetInput.Insert(i+1, "*");                   
                    implicetInput.Insert(i + 3, ")");
                                  
                    int open = 0;
                    int close = 1;
                    for (int j = i; j > -1; j--)
                    {
                        if (implicetInput[j] == "(")
                        {
                            open++;
                        }
                        if (implicetInput[j] == ")")
                        {
                            close++;
                        }
                        if (close == open+1 & j !=implicetInput.Count-1)
                        {
                            implicetInput.Insert(j, "(");
                            break;
                        }
                    }
                }

                if(implicetInput[i] == ")" & implicetInput[i+1] == "(")
                {
                    implicetInput.Insert(i+1,"*");
                }

                if(ints.Contains(implicetInput[i].Last()) & ints.Contains(implicetInput[i+1][0]))
                {      
                    implicetInput.Insert(i + 1, "*");
                    implicetInput.Insert(i, "(");
                    implicetInput.Insert(i + 4, ")");
                }
            }

            return implicetInput;
        }
        private List<string> ParseBracketsNew(List<List<string>> bracketSplit)
        {
            foreach (List<string> list in bracketSplit)
            {
                foreach (string str in list)
                {
                    if (str == "invalid input")
                    {
                        bracketSplit.Clear();
                        bracketSplit.Add(new List<string> { "invalid input" });
                    }

                }
            }

            if (bracketSplit.Count == 0)
            {
                bracketSplit.Add(new List<string> { });
                return bracketSplit[0];
            }

            for (int i = 0; i < bracketSplit.Count; i++)
            {
                if (bracketSplit[i].Count < 2)
                {
                    continue;
                }
                if (bracketSplit[i][0] == "(" & bracketSplit[i][1] == ")")
                {
                    bracketSplit.Clear();
                    bracketSplit.Add(new List<string> { "invalid brackets" });
                    return bracketSplit[0];

                }
                if (bracketSplit[i][0] == "(" & bracketSplit[i].Last() == ")")
                {
                    string result = EvaluateInputSimple(bracketSplit[i].GetRange(1, bracketSplit[i].Count - 2))[0];
                    bracketSplit[i].Clear();
                    bracketSplit[i].Add(result);
                    bracketSplit[i].Insert(0, "(");
                    bracketSplit[i].Add(")");

                }
            }
            List<string> L = new List<string> { };
            foreach (List<string> index in bracketSplit)
            {
                L.AddRange(index);
            }

            return L;

        }
        private List<string> ParseBrackets(List<List<string>> bracketSplit)
        {
            foreach(List<string> list in bracketSplit)
            {
                foreach(string str in list)
                {
                    if (str == "invalid input")
                    {
                        bracketSplit.Clear();
                        bracketSplit.Add(new List<string> { "invalid input"});
                    }
                    
                }
            }

            if(bracketSplit.Count == 0)
            {
                bracketSplit.Add(new List<string> { }); 
                return bracketSplit[0];
            }
            
            for (int i = 0; i < bracketSplit.Count; i++)
            {
                if (bracketSplit[i].Count < 2)
                {
                    continue;
                }
                if (bracketSplit[i][0] == "(" & bracketSplit[i][1]== ")")
                {
                    bracketSplit.Clear();
                    bracketSplit.Add(new List<string> {"invalid brackets" });
                    return bracketSplit[0];
                    
                }
                if(bracketSplit[i][0] == "(" & bracketSplit[i].Last() == ")")
                {
                    string result = EvaluateInputSimple(bracketSplit[i].GetRange(1, bracketSplit[i].Count-2))[0];
                    bracketSplit[i].Clear();
                    bracketSplit[i].Add(result);

                }
            }
            List<string> L = new List<string> {};
            foreach (List<string> index in bracketSplit)
            {
                L.AddRange(index);
            }
            
            return L;

        }
        private List<List<string>> SplitBrackets(List<string> splitInput)
        {
            List<List<string>> bracketSplit = new List<List<string>>();
            bracketSplit.Add(new List<string>());
            if(splitInput.Count == 0)
            {
                return bracketSplit;
            }
            bracketSplit[0].Add(splitInput[0]);
            for (int i = 1, j = 0; i < splitInput.Count; i++)
            {

                if (splitInput[i] == "(")
                {
                    bracketSplit.Add(new List<string>());
                    j += 1;

                }
                bracketSplit[j].Add(splitInput[i]);
                if (splitInput[i] == ")")
                {
                    bracketSplit.Add(new List<string>());
                    j += 1;

                }
            }
            bracketSplit.RemoveAll(inputindex => inputindex.Count == 0);
            return bracketSplit;

        }

        private List<string> SimplifyConsecutiveSign(List<string> input)
        {
            string[] check = { "+", "-", "*", "/", "^" };

            for (int i = 1; i < input.Count; i++)
            {

                if (check.Contains(input[i - 1]) && input[i] == "-")
                {
                    double.TryParse(input[i + 1], out double n);
                    input[i + 1] = (n * -1).ToString("F10");
                    input.RemoveAt(i);
                }

                if (check.Contains(input[i - 1]) && input[i] == "+")
                {
                    double.TryParse(input[i + 1], out double n);
                    input[i + 1] = (n * 1).ToString("F10");
                    input.RemoveAt(i);
                }
            }
            return input;
        }
        private List<string> SimplifyPM(List<string> input)
        {
            string[] checkpm = { "+", "-" };
            for (int i = 1; i < input.Count; i++)
            {

                if (checkpm.Contains(input[i - 1]) && input[i] == "+")
                {
                    input.RemoveAt(i);
                    i--;

                }

                if (checkpm.Contains(input[i - 1]) && input[i] == "-")
                {
                    if (input[i - 1] == "-" && input[i] == "-")
                    {
                        input[i] = "+";
                        input.RemoveAt(i - 1);
                        i--;

                    }

                    else if (input[i - 1] == "+" && input[i] == "-")
                    {
                        input.RemoveAt(i - 1);
                        i--;
                    }
                }
            }


            if (input.Count != 0)
            {
                if (input[0] == "-")
                {
                    double.TryParse(input[1], out double n);
                    input[1] = (n * -1).ToString("F10");
                    input.RemoveAt(0);

                }
                if (input[0] == "+")
                {
                    double.TryParse(input[1], out double n);
                    input[1] = (n * 1).ToString("F10");
                    input.RemoveAt(0);

                }
            }
            return input;
        }
        private List<string> ExpOrderComplex(List<string> input)
        {
            int sign = 1;
            if (input.Count < 3)
            {
                return input;
            }
            for (int i = input.Count - 1; i > 0; i--)
            {
                if (input[i] == "^")
                {
                    if (double.TryParse(input[i - 1], out double test) == true && test < 0)
                    {
                        sign = -1;
                    }
                    if (i > 3 && input[i - 3] == "(" & input[i - 1] == ")")
                    {
                        input[i] = (Math.Pow(float.Parse(input[i - 2]), float.Parse(input[i + 1]))*sign).ToString("F10");                        
                        input.RemoveAt(i - 3);
                        input.RemoveAt(i - 3);
                        input.RemoveAt(i - 3);
                        input.RemoveAt(i - 2);                        

                        if (input.Count != 1)
                        {
                            i = input.Count - 1;
                        }
                    }
                    else
                    {
                        input[i] = (Math.Pow(float.Parse(input[i - 1]), float.Parse(input[i + 1]))*sign).ToString("F10");
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = input.Count - 1;
                        }
                    }
                }
            }
            return input;
        }

        private List<string> ExpOrder(List<string> input)
        {
            int sign = 1;
            if (input.Count < 3)
            {
                return input;
            }
            for (int i = input.Count - 1; i > 0; i--)
            {
                if (double.TryParse(input[i - 1], out double test) == true && test <0)
                {
                    sign = -1;
                }
                if (input[i] == "^")
                {
                    input[i] = (Math.Pow(float.Parse(input[i - 1]), float.Parse(input[i + 1]))*sign).ToString("F10");
                    input.RemoveAt(i - 1);
                    input.RemoveAt(i);
                    if (input.Count != 1)
                    {
                        i = input.Count-1;
                    }
                }
            }
            return input;
        }

        private List<string> MDOrder(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                switch (input[i])
                {
                    case "*":
                        input[i] = (float.Parse(input[i - 1]) * float.Parse(input[i + 1])).ToString("F10");
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                    case "/":
                        input[i] = (float.Parse(input[i - 1]) / float.Parse(input[i + 1])).ToString("F10");
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                }


            }
            return input;
        }

        private List<string> PMOrder(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                switch (input[i])
                {
                    case "+":
                        input[i] = (float.Parse(input[i - 1]) + float.Parse(input[i + 1])).ToString("F10");
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                    case "-":
                        input[i] = (float.Parse(input[i - 1]) - float.Parse(input[i + 1])).ToString("F10");
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                }

            }
            return input;
        }

        
    }
}
