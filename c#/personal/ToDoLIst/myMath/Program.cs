using System;

namespace myMath
{
    class BestMath
    {
        public BestMath()
        {

        }

        public string plus(string number, string number2)
        {
            string example = "7777";
            string example2 = "7777";

            
            List<char> result = new List<char> { };
            for(int i = 0; i< Math.Max(number.Length, number2.Length); i++)
            {
                int a = int.Parse(number[number.Length-1].ToString());
                int b = int.Parse(number2[number2.Length - 1].ToString());
                int calc = a + b;
                string temp = calc.ToString();
                result.Append(temp[temp.Length - 1]);
                if (calc > 9)
                {
                    if(result.Count == 1)
                    {
                        result.Insert(0, '1');
                    }
                    else
                    {
                        result[result.Count - 2] = plus("1", result[result.Count - 2].ToString())[0];
                    }
                }
            }
            foreach(char c in result)
            {
                Console.Write(c);
            }
           

            return result.ToString();
        }

        
    }
        
   public class program
    {
        public static void Main(string[] args)
        {
            BestMath bestMath = new BestMath();
            Console.WriteLine(bestMath.plus("123", "123"));
        }
    }
}