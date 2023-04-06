using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Orc:Enemy
    {
        public Orc(int xpos, int ypos)
        {
            BarehandDamadgeMin = 3;
            BarehandDamadgeMax = 4;
            Health = 14;
            Icon = "T";
            Xpos = xpos;
            Ypos = ypos;
            Colour = ConsoleColor.Black;
        }
    }
}
