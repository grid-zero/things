using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace McCalculator
{
    class Program
    {

        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.loadInfo();
            Dictionary<string, int> items = calc.GetItem();
            foreach(KeyValuePair<string, int> pair in items)
            {
                Console.WriteLine("{0}: {1}",pair.Key,pair.Value);
            }
        }
         
    }

    class Calculator
    {
        List<List<string>> parsedData = new List<List<string>>();
        Dictionary<string,int> items = new Dictionary<string, int>();
        public Calculator()
        {

        }

        public void loadInfo()
        {
            string[] data = File.ReadAllLines(@"..\..\..\data.txt");
            
            int position = 0;
            parsedData.Add(new List<string>());
            foreach (string line in data)
            {

                if (line == "BREAK")
                {
                    parsedData.Add(new List<string>());
                    position += 1;
                    continue;
                }
                parsedData[position].Add(line);

            }
        }
        public Dictionary<string, int> GetItem()
        {
            Console.WriteLine("enter item name");
            string input = Console.ReadLine();
            int index = 0;
            for(int i = 0; i < parsedData.Count; i++)
            {
                if (parsedData[i].Contains(input))
                {
                    index = i;
                    break;
                }
            }

            for(int i = 2; i < parsedData[index].Count; i++)
            {
                GetItemRecurse(parsedData[index][i]);
            }
            return items;
            
        }

       
        public void GetItemRecurse(string input)
        {
            int index = 0;
            for (int i = 0; i < parsedData.Count; i++)
            {
                if (parsedData[i].Contains(input))
                {
                    index = i;
                    break;
                }
            }
            if (parsedData[index].Count == 2)
            {
                if (!items.ContainsKey(input))
                {
                    items.Add(input, 0);
                }
                items[input]+=int.Parse(parsedData[index][1]);
            }
        }
        public void AddItem()
        {
            Console.WriteLine("Enter item name then quantity produced then ingredeints\n type EXIT to finish");
            bool exited = false;
            List<string> items = new List<string>();
            while (exited == false)
            {
                string input = Console.ReadLine();
                if (input == "EXIT")
                {
                    exited = true;
                    break;
                }
                items.Add(input);
            }
            //items.Insert(0, "\n");
            items.Add("BREAK");
            File.AppendAllLines(@"..\..\..\data.txt", items); 
        }
    }
}