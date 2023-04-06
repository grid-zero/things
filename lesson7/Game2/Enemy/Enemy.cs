using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
   
    abstract class Enemy : MapItem
    {
        protected int health =1;
        protected string icon;
        public int xpos;
        public int ypos;
        protected int barehandDamadgeMin;
        protected int barehandDamadgeMax;

        public int Health
        {
            get { return health; }
            set
            {
                if (health <= 0)
                {
                    this.health = 0;
                    return;

                }
                health = value;
            }
        }

        public string Icon { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int BarehandDamadgeMin { get; set; }
        public int BarehandDamadgeMax { get; set; }
        public ConsoleColor Colour { get; set; }

        /* public void Draw()
         {
             Console.SetCursorPosition(Xpos,Ypos);
             Console.Write(Icon);
         }*/
        Random rnd = new Random();

        public void Attack(Player player)
        {
            int Damadge = rnd.Next(BarehandDamadgeMin, BarehandDamadgeMax+1);
            Damadge = player.TakeDamdge(Damadge);
            string s0 = String.Format("Damadge was {0}", Damadge);
           
            player.Health -= Damadge;
            string s1 = String.Format("{0} was atacked for {1} damadge and is now on {2} health", player, Damadge, player.Health); 
            Game.writes.Add(s0);
            Game.writes.Add(s1);
        }

    }
}
