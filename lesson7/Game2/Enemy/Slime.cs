using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Slime:Enemy
    {
        public Slime(int xpos, int ypos)
        {
            BarehandDamadgeMin = 0;
            BarehandDamadgeMax = 0;
            Health = 5;
            Icon = "S";
            Xpos = xpos;
            Ypos = ypos;
            Colour = ConsoleColor.Black;
        }
    }
}
