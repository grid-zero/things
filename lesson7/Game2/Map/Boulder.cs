using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Boulder:IObstacle
    {
     

        public Boulder(int xpos, int ypos)
        {
            Xpos = xpos;
            Ypos = ypos;
            Icon = "O";
            Colour = ConsoleColor.Black;
        }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public string Icon { get; set; }
        public ConsoleColor Colour { get; set; }

        public void Hinder()
        {
            Game.writes.Add(String.Format("You hit a boulder!"));
        }
    }
}
