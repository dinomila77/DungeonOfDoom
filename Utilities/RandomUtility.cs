using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class RandomUtility
    {
        static Random random = new Random();

        public static int Randomizer(int min,int max)
        {
            return random.Next(min, max + 1);
        }        
        public static bool Try(int value)
        {
            return random.Next(1, 101) < value;
        }
    }
}
