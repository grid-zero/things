using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    class Program
    {
        static void Main()
        {
            int[,] board = new int[10, 10];

            for (int i = 0; i<board.GetLength(0); i++)
            {
                for (int j = 0; i < board.GetLength(1); j++)
                {
                    board[i, j] = 1;
                }
            }

        }
    }
}
