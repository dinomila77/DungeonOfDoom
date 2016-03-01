using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    abstract class Item : GameObject
    {
        public Item(string name, string mapSymbol, int weight) : base(name,mapSymbol)
        {  
            Weight = weight;           
        }

        public int Weight { get; private set; }       

        public virtual void PickUp(Player player)
        {
            player.BackpackWeight += Weight;
        }

        public abstract void Equip(Player player);

        public abstract void DropItem(Player player);
    }
}
