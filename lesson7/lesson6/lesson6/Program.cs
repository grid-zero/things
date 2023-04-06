using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    class Program
    {
        enum Months
        {
            January=1,
            Febuary,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December,
        }
        static void Main(string[] args)
        {


            int.TryParse(Console.ReadLine(), out int month);
            Months index = (Months)month;
            switch (index)
            {
                case Months.January:
                    Console.WriteLine("January has 31 days.");
                    break;
                case Months.Febuary:
                    Console.WriteLine("Febuary has 28 days.");
                    break;
                case Months.March:
                    Console.WriteLine("March has 31 days.");
                    break;
                case Months.April:
                    Console.WriteLine("April has 30 days.");
                    break;
                case Months.May:
                    Console.WriteLine("May has 31 days.");
                    break;
                case Months.June:
                    Console.WriteLine("June has 30 days.");
                    break;
                case Months.July:
                    Console.WriteLine("July has 31 days.");
                    break;
                case Months.August:
                    Console.WriteLine("August has 31 days.");
                    break;
                case Months.September:
                    Console.WriteLine("September has 30 days.");
                    break;
                case Months.October:
                    Console.WriteLine("October has 31 days.");
                    break;
                case Months.November:
                    Console.WriteLine("Novmember has 30 days.");
                    break;
                case Months.December:
                    Console.WriteLine("May has 31 days.");
                    break;
                default:
                   
                    o
                    break;


            }
            Console.ReadKey();




        }
    }
}
