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
            string[,] canvas = new string[3, 3];
            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLength(1); j++)
                {
                    canvas[i, j] = "*";
                    Console.Write(canvas[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            int step = 1;
            int numsteps = 1;
            int turnCount = 0;
            int state = 0;
            int x = 1;
            int y = 1;



            while (true)
            {
                canvas[y, x] = Convert.ToString(step);
                switch (state)
                {
                    case 0:
                        x += 1;
                        break;
                    case 1:
                        y -= 1;
                        break;
                    case 2:
                        x -= 1;
                        break;
                    case 3:
                        y += 1;
                        break;
                }
                
                for (int i = 0; i < canvas.GetLength(0); i++)
                {
                    for (int j = 0; j < canvas.GetLength(1); j++)
                    {
                        Console.Write(canvas[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
              
                
                if(step % numsteps == 0)
                {
                    turnCount++;
                    state = (state+1)%4;
                    if (turnCount%2==0)
                    {
                        numsteps++;
                    }
                }
                step++;
            }
            
        }

    }   
}

