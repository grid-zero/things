using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Game2
{
    internal class Game
    {
        Mage mage;
        Map rings;
        Goblin gnob;
        List<Enemy> enemies;
        public static List<string> writes = new List<string> { ""};
        public static List<string> changes = new List<string> { "" };
        bool atackmode = false;

        public Game()
        {
            
        }

        public void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Epic game that is the best in the wld";
            mage = new Mage();
            //gnob = new Goblin(6, 1);
            Bow s = new Bow();
            rings = new Map(mage);
            

            mage.Equip(s);

            rings.LevelParseBack(@"Data.txt", @"DataFore.txt");


            //process player and enemy positions for a map


           
            DisplayInfo();
            rings.Draw(0);
            rings.Draw(1);
            mage.Draw();
            GameLoop();

        }

        public void DisplayInfo()
        {
            Console.WriteLine("~~~~~~~Legend~~~~~~");
            Console.WriteLine("% = Goblin");
            Console.WriteLine("T = Orc");
            Console.WriteLine("S = Slime");
            Console.WriteLine("# = Wall");
            Console.WriteLine("O = Boulder");
            Console.WriteLine("~ = Ditch");
            Console.WriteLine("^ = Tree");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
       
    
        private void PlayerInput()
        {
            //pass the player and the key pressed to the player move function
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            
           
            if (key == ConsoleKey.Z)
            {
                atackmode = !atackmode;
                mage.TargetX = mage.Xpos;
                mage.TargetY = mage.Ypos;

            }
            if (atackmode == false)
            {
                rings.PlayerMove(key, mage);
            }
            if (atackmode == true)
            {
                AttackSelect(key);
            }
           
            
           
        }

        public void AttackSelect(ConsoleKey key)
        {
           
            int targetx = mage.Xpos;
            int targety = mage.Ypos;
            int x = targetx; 
            int y = targety;
           

            targetx = x;
            targety = y;
              
            
            mage.AttackSelect(key);
            rings.map[0, mage.TargetY, mage.TargetX].Colour = ConsoleColor.Red;
            rings.map[1, mage.TargetY, mage.TargetX].Colour = ConsoleColor.Red;



        }




        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("You Died");
            Console.WriteLine("Game Over");
        }
        public void Procces()
        {
            mage.TakeEffectTurn();
            PlayerInput();
            rings.EvalCurrentTile(mage.Xpos, mage.Ypos);
           
            mage.ProcessEffects();

        }
        public void DrawUserStats()
        {
            Console.SetCursorPosition(rings.map.GetLength(2), 0);

            Console.WriteLine("Health {0}",mage.Health);
            Console.SetCursorPosition(rings.map.GetLength(2), 1);
            Console.WriteLine("Defence {0} (+{1})",mage.Defence+mage.DefenceExtra,mage.DefenceExtra);
            Console.SetCursorPosition(rings.map.GetLength(2), 2);
            if (mage.Equiped != null)
            {
                Console.WriteLine("Average Damadge {0}",(mage.Equiped.minDamadge+mage.Equiped.maxDamadge)/2);
            }
            Console.SetCursorPosition(rings.map.GetLength(2), 3);
            Console.WriteLine("Xpos {0} Ypos {1}",mage.Xpos,mage.Ypos);
            foreach (Effect ef in mage.Effects)
            {
                
                if (ef.Defence != 0)
                {
                    Console.Write("{0} Defence from {1}",ef.Defence,ef.Source);
                }

                
            }
            
           

        }
        public void Draw()
        {
            Clear();
            rings.Draw(0);
            rings.Draw(1);
            DrawUserStats();
            
            
            
            Console.SetCursorPosition(rings.map.GetLength(2), rings.map.GetLength(1));

            foreach(string str in writes)
            {
                Console.WriteLine(str);
               
               
            }
            writes.Clear();
        }
        public void Clear()
        {
            for(int i = 0; i < rings.map.GetLength(1); i++)
            {
                Console.SetCursorPosition(rings.map.GetLength(2), i);
                Console.Write("                                                                                      ");
            }
            Console.SetCursorPosition(rings.map.GetLength(2), rings.map.GetLength(1));
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");
        }
        private void GameLoop()
        {
            while (true)
            {
                //Draw the map
                //changes made
                //  player charector is no longer actually part of the map
                //  this can be done as only the plater interacts with the map
                // if other entities are required to interact then cover check or second static array must be implemented

                if (mage.Health <= 0)
                {
                    GameOver();
                    return;
                }

                Procces();

                Draw();
                

                //Clear();






                //Loop through map array and check things posistion


                //proccess player input and movement on the map.




            }

        }

       
    }
}
