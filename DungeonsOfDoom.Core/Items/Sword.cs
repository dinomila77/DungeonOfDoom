using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    class Sword : Weapon
    {
        public Sword() : base("Sword",6)
        {
        }
        
        public override void Equip(Player player)
        {
            if (player.Hands.Count <= 1)
            {
                player.BackpackWeight -= Weight;
                player.Attack += 6;
            }           
        }

        public override void DropItem(Player player)
        {
            player.Attack -= 6;
        }
    }
}
