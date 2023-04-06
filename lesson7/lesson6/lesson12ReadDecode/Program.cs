using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson12FileReading
{
    class Program
    {
        static void Main(string[] args)
        {
            String read;
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\2160366\Downloads\decode.txt");
                StreamReader sr1 = new StreamReader(@"C:\Users\2160366\Downloads\number.txt");
                string input = sr1.ReadLine();
                string[] splitInput = input.Split(',');
                read = sr.ReadLine();

                foreach (string str in splitInput)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
                while (read != null)
                {
                    read = read.Replace('*', 'a');
                    read = read.Replace('%', 'i');
                    read = read.Replace('&', 'e');
                    read = read.Replace('#', 'o');
                    read = read.Replace('@', 'u');
                    Console.WriteLine(read);

                    read = sr.ReadLine();

                }
                sr.Close();




            }
            finally { }
            Console.ReadKey();



        }
    }
}


