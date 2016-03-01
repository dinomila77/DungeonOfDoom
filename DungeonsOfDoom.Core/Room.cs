using DungeonsOfDoom.Core.Characters;
using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    class Room
    {
        public Room(int brightness,Item item,Monster monster)
        {
            Brightness = brightness;
            Item = item;
            Monster = monster;       
        }

        public int Brightness { get; private set; }
        public Item Item { get; set; }
        public Monster Monster { get; set; }
    }
}
