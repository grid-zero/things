using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Bow:Weapon
    {
        public Bow()
        {
            minDamadge = 1;
            maxDamadge = 5;
            range = 3;
        }
    }
}
