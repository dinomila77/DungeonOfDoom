using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    abstract class Weapon : Item
    {
        public Weapon(string name, int weight) : base(name,"W",weight)
        {
        }       
    }
}
