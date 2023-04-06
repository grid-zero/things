using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Game2
{
    abstract class Player: MapItem
    {
        Random rnd = new Random();
        protected int maxHealth;
        protected int maxHealthExtra;
        protected int health =1;
        

        protected int defence;
        protected int defenceExtra;

        protected int barehandDamadgeMin =1;
        protected int barehandDamadgeMinExtra;
        
        protected int barehandDamadgeMax =2;
        protected int barehandDamadgeMaxExtra;

        protected int magic;
        protected int magicExtra;

        protected int strength;
        protected int strengthExtra;

        protected int range;
        protected int rangeExtra;


        protected List<Weapon> backpack;
        protected Weapon equiped;
        protected int xpos;
        protected int ypos;
        protected string icon = "@";
        protected List<Effect> effects = new List<Effect> { };
        


        public Player()
        {
            this.Health = health;
            this.BarehandDamadgeMin = 1;
            this.BarehandDamadgeMax = 2;
            this.Defence = 0;
            Icon = "@";
            Colour = ConsoleColor.Black;
        }
        public int MaxHealth { get; set; }
        public int MaxHealthExtra { get; set; }
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



        public int Defence { get; set; }
        public int DefenceExtra { get; set;}

        public int Magic { get; set; }
        public int MagicExtra { get; set; }

        public int Strength { get; set; }
        public int StrengthExtra { get; set; }
        public int Range { get; set; }
        public int RangeExtra { get; set; }

        public List<Weapon> Backpack { get; set; }
        public Weapon Equiped { get; set; }
        public string Icon { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int BarehandDamadgeMin { get; set; }
        public int BarehandDamadgeMax { get; set; }
        public List<Effect> Effects { get { return effects; } set { effects = value; } }
        public ConsoleColor Colour { get; set; }

        
        public void Draw()
        {
            Console.SetCursorPosition(Xpos, Ypos);
            Console.Write(this.icon);
        }
        public void EffectsClear()
        {
            MaxHealthExtra = 0;
            DefenceExtra = 0;
            MagicExtra = 0;
            StrengthExtra = 0;
            RangeExtra = 0;

        }
        public void TakeEffectTurn()
        {
            foreach(Effect e in Effects)
            {
                e.TakeTurn();
            }
        }
        public void ProcessEffects()
        {
            EffectsClear();
            foreach(Effect e in Effects)
            {
                
                e.Apply(this);
                
            }
        }
        
        public int TakeDamdge(int damadge)
        {
            
            int TotalDamadge = damadge - (Defence + DefenceExtra);
            
            if (TotalDamadge < 0)
            {
                TotalDamadge = 0;
            }
            return TotalDamadge;
        }



        public void Attack(Player player)
        {
            int Damadge = Equiped.Attack();
            player.Health -= Damadge;
            Game.writes.Add("");
            string s = String.Format("{0} was atacked with {1} for {2} damadge and is now on {3} health", player, Equiped, Damadge, Health);
            Game.writes.Add(s);
        }

        public void Attack(Enemy en)
        {
            string s0 = String.Format("DefenceBase: {0}, DefeneceExtra: {1}", Defence, DefenceExtra);
            
            int Damadge;
            if (Equiped == null)
            {
                Damadge = rnd.Next(BarehandDamadgeMin, BarehandDamadgeMax + 1);
            }
            else
            {
                Damadge = Equiped.Attack();
            }
            //Console.WriteLine("min dam {0} max dam {1}",BarehandDamadgeMin,barehandDamadgeMax);
            string s1 = String.Format("Damadge was {0}", Damadge);
            
            en.Health -= Damadge;
            string s2 = String.Format("{0} was atacked with {1} for {2} damadge and is now on {3} health", en, Equiped, Damadge, en.Health);
            Game.writes.Add(s0);
            Game.writes.Add(s1);
            Game.writes.Add(s2);
        }

        public void Equip(Weapon weapon)
        {
            Equiped = weapon;
        }

        public int TargetX { get; set; }
        public int TargetY { get; set; }

        public int AttackSelect(ConsoleKey key)
        {


           
                switch (key)
                {

                    case ConsoleKey.UpArrow:
                    //during proccesing if an @ is found then players posision is set to that 
                    
                      if (Tools.DistancePoint(xpos, ypos, TargetX, TargetY - 1) <= Equiped.range)
                      {

                            TargetY -= 1;
                                        
                      }

                        break;
                    case ConsoleKey.LeftArrow:
                       if (Tools.DistancePoint(xpos, ypos, TargetX-1, TargetY) <= Equiped.range)
                        {
                            
                            TargetX -= 1;
                            
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (Tools.DistancePoint(xpos, ypos, TargetX, TargetY + 1) <= Equiped.range)
                       {

                            TargetY += 1;
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (Tools.DistancePoint(xpos, ypos, TargetX+1, TargetY) <= Equiped.range)
                        {

                            TargetX += 1;
                        }
                        break;
                 
                }
            return 0;
            }
        }
        
    }
