using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Effect
    {
        int turnTimer;
        int defence;
        int health;
        int magic;
        int strength;
        int range;
        string source;
        public List<int> status;
        
        
        

        //an effect with a duration is made
        //directly after that depending on where it is called some of the fields are updated
        // ie. Effect.Defence =10;

        public Effect(int turnTimer, string source)
        {
            this.turnTimer = turnTimer;
            this.source = source;
            
        }

        public int Defence { get; set; }
        public int Health { get; set; }
        public int Magic { get; set; }

        public int Strength { get; set; }
        public int Range { get; set; }
        public string Source { get { return source; } set { source = value; } }

        public void AddStatus()
        {
            
            status.Add(Defence);
            status.Add(Health);
            status.Add(Magic);
            status.Add(Strength);
            status.Add(Range);
        }

        public void Apply(Player p)
        {
            
            p.MaxHealthExtra += Health;
            p.DefenceExtra += Defence;
            p.MagicExtra += Magic;
            p.StrengthExtra += Strength;
            p.RangeExtra += Range;
        }

        public void TakeTurn()
        {
            
            turnTimer--;
            if (turnTimer == 0)
            {
                Health = 0;
                Defence = 0;
                Magic = 0;
                Strength = 0;
                range = 0;
            }
        }
    }
}
