using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    class Program
    {
        public static void swap(int[] inted, int i, int j)
        {
            int temp = inted[i];
            inted[i] = inted[j];
            inted[j] = temp;
        }

        static int[] inesrstion(int[] inted)
        {
            int j = 0;
            for (int i = 0; i < inted.Length; i++)
            {
                j = i;
                while (j > 0 && inted[j - 1] > inted[j])
                {
                    swap(inted, j, j - 1);
                    j -= 1;
                }
            }

            foreach (int i in inted)
            {
                Console.Write(i + " ");
            }
            return null;
        }

        static int[] selectSort(int[] inted)
        {
            for (int j = 0; j < inted.Length - 1; j++)
            {
                int iMin = j;
                for (int i = j + 1; i < inted.Length; i++)
                {
                    if (inted[i] < inted[iMin])
                    {
                        iMin = i;
                    }
                }
                if (iMin != j)
                {
                    swap(inted, j, iMin);
                }
            }

            foreach (int i in inted)
            {
                Console.Write(i + " ");
            }
            return null;
        }

        static int[] bubble(int[] inted)
        {
            for (int i = 1; i < inted.Length; i++)
            {
                for (int j = 0; j < inted.Length - 1; j++)
                {
                    if (inted[j] > inted[j + 1])
                    {
                        swap(inted, j, j + 1);
                    }
                }
            }
            foreach (int i in inted)
            {
                Console.Write(i + " ");
            }
            return null;
        }

        static int[] search(int[] inted)
        {
            Console.WriteLine("Enter a number to find");
            int find = int.Parse(Console.ReadLine());
            int min = 0;
            int max = inted.Length - 1;
            int n = ((min + max) / 2);
            while(max!=min)
            {
                if (inted[n] > find)
                {
                    max = n-1;
                }
                else if (inted[n] < find)
                {
                    min = n+1;
                }
                n = ((min + max) / 2);
                if (inted[n] == find)
                {
                    Console.WriteLine("index " + n + " Contains " + inted[n]);
                    max = min;
                    return null;
                }
            }
            if (inted[n] != find)
            {
                Console.WriteLine("Array does not contain " + find);
            }
            return null;
        }


            static void Main(string[] args)
            {
                Console.WriteLine("1d unsorrted array entry");
                string notSorted = Console.ReadLine();

                string[] abc = notSorted.Split(',');
                int[] inted = Array.ConvertAll(abc, int.Parse);
                int[] inted1 = Array.ConvertAll(abc, int.Parse);
                int[] inted2 = Array.ConvertAll(abc, int.Parse);
                int[] inted3 = Array.ConvertAll(abc, int.Parse);
                inesrstion(inted);
                Console.WriteLine("");
                selectSort(inted1);
                Console.WriteLine("");
                bubble(inted2);
                Console.WriteLine("");
                search(inted2);
                Console.WriteLine("");
                Console.ReadKey();

            }
        }
    }
