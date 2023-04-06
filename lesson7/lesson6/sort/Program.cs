using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    class Program
    {

        static int[] inesrstion(int[] inted)
        {
           
            int j = 0;
            for (int i = 0; i < inted.Length; i++)

            {
                j = i;
                while (j > 0 && inted[j - 1] > inted[j])
                {
                    int temp = inted[j];
                    inted[j] = inted[j - 1];
                    inted[j - 1] = temp;
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
            for(int i = 0; i<inted.Length-1; i++)
            {
                int iMin = i;
                for (int j = 0; j< inted.Length; i++)
                {
                    if (inted[j] < inted[iMin])
                    {
                        iMin = i;
                    }
                    if (iMin != j){
                        int temp = inted[j];
                        inted[j] = inted[j - 1];
                        inted[j - 1] = temp;
                    }
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            string notSorted = Console.ReadLine();
            string[] abc = notSorted.Split(',');
            int[] inted = Array.ConvertAll(abc, int.Parse);
            inesrstion(inted);
            selectSort(inted);
            while (true) { }
        }
    }
}
