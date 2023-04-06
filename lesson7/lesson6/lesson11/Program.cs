using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //string s = Console.ReadLine();

            Hashtable wordCount = new Hashtable();

            // string[] Splitword = s.Split(' ');
            var LogFile0 = File.ReadAllLines(@"..\..\nouns.txt");
            var nouns = new List<string>(LogFile0);

            var LogFile1 = File.ReadAllLines(@"..\..\adjectives.txt");
            var adj = new List<string>(LogFile1);

            var LogFile2 = File.ReadAllLines(@"..\..\verbs.txt");
            var verbs = new List<string>(LogFile2);

            var LogFile3 = File.ReadAllLines(@"..\..\subj.txt");
            var subj = new List<string>(LogFile3);

            var LogFile4 = File.ReadAllLines(@"..\..\names.txt");
            var names = new List<string>(LogFile4);



         
            Console.WriteLine("The " + adj[rnd.Next(0, adj.Count)]+" "+ nouns[rnd.Next(0, nouns.Count)] +" "+verbs[rnd.Next(0, verbs.Count)]+ " the "+ nouns[rnd.Next(0, nouns.Count)]);
    
            Console.WriteLine("{0}'s {1} score was {2}%. {0}'s score is ranked {3}. I suggest that {0} should {4} more {5}",names[rnd.Next(0,names.Count)],subj[rnd.Next(0,subj.Count)],rnd.Next(0,101),rnd.Next(1,21),verbs[rnd.Next(0,verbs.Count)],nouns[rnd.Next(0,nouns.Count)]);
     
            Console.ReadKey();
        }
    }
}


