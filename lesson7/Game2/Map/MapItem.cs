using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal interface MapItem
    {

       
        public string Icon { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }  
        public ConsoleColor Colour { get; set; }

       
    }
}
