using System;
using System.Text;
namespace FileEncrypter
{
    public class program
    {

        
        public static void Main(string[] args)
        {
            string filepath;
            string encoder;

            for (; ; )
            {
                
                Console.WriteLine("Enter one (1) to encrypt a file \nenter two (2) to unencypt a file to cmd \nenter three (3) to unencrpyt a file to output file");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int selection) == false)
                {
                    Console.WriteLine("invalid selection");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("enter file path");
                        filepath = Console.ReadLine();
                        Console.WriteLine("enter password");
                        encoder = Console.ReadLine();
                        encode(filepath, encoder);
                    break;
                    case 2:
                        Console.WriteLine("enter file path");
                        filepath = Console.ReadLine();
                        Console.WriteLine("enter password");
                        encoder = Console.ReadLine();
                        string[] result = decode(filepath, encoder);
                        foreach(string str in result)
                        {
                            Console.WriteLine(str);
                        }
                        break;
                    case 3:
                        Console.WriteLine("enter file path");
                        filepath = Console.ReadLine();
                        Console.WriteLine("enter password");
                        encoder = Console.ReadLine();
                        string[] result2 = decode(filepath, encoder);
                        File.WriteAllLines(filepath, result2);
                        break;

                }
            }
        }

        private static void encode(string filepath, string encoder)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("no such file exists");
                return;
            }
           
            string[] file = File.ReadAllLines(filepath);
            for(int i = 0, x = 0; i < file.Length; i++)
            {
                char[] encodedline = new char[file[i].Length];
                for(int j = 0; j < file[i].Length; j++, x++)
                {                  
                    int charkey = (int)file[i][j];
                    int encodecharkey = (int)encoder[x%encoder.Length];
                    charkey = charkey + encodecharkey;
                    charkey = charkey % 95;
                    
                    charkey += 32;
                    
                    encodedline[j] = (char)charkey;
                }
                file[i] = new String(encodedline);
            }
            File.WriteAllLines(filepath,file);
        }

        private static string[] decode(string filepath, string encoder)
        {

            if (!File.Exists(filepath))
            {
                Console.WriteLine("no such file exists");
                return new string[] { "Error" };
            }
            
            string[] file = File.ReadAllLines(filepath);
            for (int i = 0, x = 0; i < file.Length; i++)
            {
                char[] encodedline = new char[file[i].Length];
                for (int j = 0; j < file[i].Length; j++, x++)
                {

                    int charkey = (int)file[i][j];
                    
                    int encodecharkey = (int)encoder[x % encoder.Length];
                    charkey = charkey - encodecharkey;
                    

                    int temp = charkey % 95;

                    charkey = (temp+95)%95;
                    if (charkey > 63)
                    {
                        
                        charkey -= 32;
                    }
                    else
                    {
                        charkey = 95 + charkey;
                        charkey -= 32;
                    }

                    encodedline[j] = (char)charkey;
                }
                file[i] = new String(encodedline);
                
            }
            return file;
        }
    }
}