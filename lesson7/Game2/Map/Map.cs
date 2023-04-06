namespace Game2
{


    internal class Map
    {


        List<ICover> covers = new List<ICover> { };
        List<IObstacle> obstacles = new List<IObstacle> { };
        StreamReader sr;
        Player p;
        List<Enemy> e = new List<Enemy> { };
        public Map(Player player)
        {
            p = player;

        }
        public MapItem[,,] map;
        public void LevelParseBack(string fileBack, string fileFore)
        {
            int z = 0;
            sr = new StreamReader(String.Concat(@"..\..\..\", fileBack));
            string[] lines = sr.ReadToEnd().Split("\n");
            int xleng = lines[0].Length;
            xleng -= 1;
            int yleng = lines.Length;
            map = new MapItem[2, yleng, xleng];
            for (int y = 0; y < yleng; y++)
            {
                string charline = lines[y];
                for (int x = 0; x < xleng; x++)
                {
                    Procces(charline, z, y, x);
                }
            }
            z = 1;
            LevelParseFront(fileFore, z);

        }

        private void LevelParseFront(string fileFore, int z)
        {
            sr = new StreamReader(String.Concat(@"..\..\..\", fileFore));
            string[] lines = sr.ReadToEnd().Split("\n");
            int xleng = lines[0].Length;
            xleng -= 1;
            int yleng = lines.Length;
            for (int y = 0; y < yleng; y++)
            {
                string charline = lines[y];
                for (int x = 0; x < xleng; x++)
                {
                    Procces(charline, z, y, x);
                }
            }


        }

        private void Procces(string charline, int z, int y, int x)
        {
            string Icon = charline[x].ToString();
            switch (Icon)
            {
                case ".":
                case " ":
                    Air a = new Air(x, y);
                    map[z, y, x] = a;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    break;
                case "@":
                    p.Xpos = x;
                    p.Ypos = y;
                   // map[z, y, x] = p;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    break;
                case "#":
                    Wall w = new Wall(x, y);
                    map[z, y, x] = w;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    obstacles.Add(w);
                    break;
                case "O":
                    Boulder b = new Boulder(x, y);
                    map[z, y, x] = b;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    obstacles.Add(b);
                    break;

                case "~":
                    Ditch d = new Ditch(x, y);
                    map[z, y, x] = d;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    covers.Add(d);
                    break;
                case "^":
                    Tree t = new Tree(x, y);
                    map[z, y, x] = t;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    covers.Add(t);
                    break;

                case "%":
                    Goblin g = new Goblin(x, y);
                    map[z, y, x] = g;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    e.Add(g);
                    break;
                case "T":
                    Orc o = new Orc(x, y);
                    map[z, y, x] = o;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    e.Add(o);
                    break;
                case "S":
                    Slime s = new Slime(x, y);
                    map[z, y, x] = s;
                    //map[z, y, x].Colour = ConsoleColor.White;
                    e.Add(s);
                    break;
            }


        }


        public void Draw(int level)
        {
            p.Colour = ConsoleColor.Black;
            map[1, p.Ypos, p.Xpos] = p;

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(2); x++)
                {

                    Console.SetCursorPosition(x, y);
                    if (map[level, y, x] != null && level == 1 && map[1, y, x].GetType() == typeof(Air))
                    {

                    }
                    else
                    {
                        
                        try { Console.BackgroundColor = map[level, y, x].Colour; }
                        catch(Exception e)
                        {

                        }
                        Console.Write(map[level, y, x].Icon);
                        
                    }




                }
            }


        }

        public bool Walkable(int Xtarget, int Ytarget)
        {

            if (map[1, Ytarget, Xtarget].GetType() == typeof(Air))
            {
                switch (map[0, Ytarget, Xtarget])
                {
                    case Wall:
                    case Boulder:
                        IObstacle w = (IObstacle)map[0, Ytarget, Xtarget];
                        w.Hinder();
                        return false;
                    case Ditch:
                    case Tree:
                    case Air:
                    default:
                        return true;
                }

            }
            else
            {
                switch (map[1, Ytarget, Xtarget])
                {
                    case Goblin:
                    case Orc:
                    case Slime:

                        Enemy enemy = (Enemy)map[1, Ytarget, Xtarget];

                        p.Attack(enemy);
                        enemy.Attack(p);
                        if (enemy.Health <= 0)
                        {
                            map[1, Ytarget, Xtarget] = null;
                            return true;
                        }


                        return false;
                }
            }

            return false;
        }

        public void EvalCurrentTile(int x, int y)
        {
            switch (map[0, y, x])
            {
                case ICover:
                    Effect ef = new Effect(1, "Cover");
                    ef.Defence = 1;
                    p.Effects.Add(ef);
                    break;

            }
        }

        public void PlayerMove(ConsoleKey key, Player p)
        {

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    //during proccesing if an @ is found then players posision is set to that
                    if (Walkable(p.Xpos, p.Ypos - 1) == true)
                    {
                        map[1, p.Ypos, p.Xpos] = new Air(p.Xpos,p.Ypos);
                        p.Ypos -= 1;
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (Walkable(p.Xpos - 1, p.Ypos) == true)
                    {
                        map[1, p.Ypos, p.Xpos] = new Air(p.Xpos, p.Ypos);
                        p.Xpos -= 1;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (Walkable(p.Xpos, p.Ypos + 1) == true)
                    {
                        map[1, p.Ypos, p.Xpos] = new Air(p.Xpos, p.Ypos);
                        p.Ypos += 1;
                        //Console.SetCursorPosition(p.Xpos, p.Ypos);
                        //Console.Write("@");
                        // p.Draw();
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (Walkable(p.Xpos + 1, p.Ypos) == true)
                    {
                        map[1, p.Ypos, p.Xpos] = new Air(p.Xpos, p.Ypos);
                        //map[p.Ypos, p.Xpos] = ".";
                        //map[p.Ypos, p.Xpos+1] = "@";
                        p.Xpos += 1;
                    }
                    break;

            }
        }
        /*
         * How to guide for th efuture
         * To update position clear entire map to null 
         * then asign objects to their posisiton 
         * after that call update to render them
         */

        /*public void CoverCheck(int x, int y)
        {
            for (int i = 0; i < covers.Count; i++)
            {
                if (covers[i].Xpos == x && covers[i].Ypos == y)
                {
                    Console.WriteLine("                                                    cover x and y{0},{1}",covers[i].Xpos,covers[i].Ypos);

                   Console.WriteLine("                                                    Cover at {0},{1}", x, y);

                    Console.WriteLine(covers[i].Icon);
                    map[y, x] = covers[i].Icon;
                }
            }
        }*/
        /*
        public void UpdateIcon(MapItem p)
        {
            // most likley will not be used
            this.Create();
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (i == p.Xpos && j == p.Ypos)
                    {
                        map[i, j] = p;
                        Console.WriteLine("x match found");
                    }
                    else
                    {
                        map[i, j] = new MapItem();
                    }
                }

            }
            Update();

        }
        */



    }
}
