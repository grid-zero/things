using System;
using System.Text.RegularExpressions;
namespace ctf
{
    public class program
    {
        public static Boolean isAlpha(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z\s,]*$");
            return rg.IsMatch(strToCheck);
        }
        public static void Main(string[] args)
        {
            string[] linescringe = File.ReadLines(@"C:\Users\azzhu\Documents\programming\c#\personal\ToDoLIst\test\input.txt").ToArray();
            List<string> lines = new List<string>(linescringe);
            int sum = 0;
            for(int i = 0; i < lines.Count; i++)
            {
                if(isAlpha(lines[i]) == true){
                    continue;
                }
                if(int.Parse(lines[i]) % 28 == 0)
                {
                    sum += int.Parse(lines[i]);
                    continue;
                }
                /*else if (int.Parse(lines[i]) % 7 == 0)
                {
                    sum += int.Parse(lines[i]);
                    continue;
                }*/
                
            }
            Console.WriteLine(sum);
        }
    }
}