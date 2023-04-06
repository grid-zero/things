using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Game2
{
    internal static class Tools
    {

        public static void Destroy(Effect o)
        {
            o = null;
        }

        public static int DistancePoint(int currentx, int currenty,int targetx, int targety)
        {
            int distance = (int) Sqrt ( Pow( currentx + targetx, 2 ) + Pow( currenty + targety, 2 ) );
            return distance;
        }
    }
}
