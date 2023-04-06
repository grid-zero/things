using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Goblin : Enemy
    {
        public Goblin(int xpos, int ypos)
        {
            BarehandDamadgeMin = 1;
            BarehandDamadgeMax = 2;
            Health = 7;
            Icon = "%";
            Xpos = xpos;
            Ypos = ypos;
            Colour = ConsoleColor.Black;

        }
    }
}
