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
            List<char> chars = new List<char>();
            for(int i = 0; i<26; i++)
            {
                chars.Add((char)(65 + i));
                Console.WriteLine(chars[i]);
            }
            while (true) { }
        }
    }
}
