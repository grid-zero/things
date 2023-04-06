using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public abstract class Weapon
    {
        Random r = new Random();

        public int minDamadge;
        public int maxDamadge;
        public int range;

        public int Attack()
        {
           int Damadge = (r.Next(minDamadge,maxDamadge));
           return Damadge;
        }



    }
}
