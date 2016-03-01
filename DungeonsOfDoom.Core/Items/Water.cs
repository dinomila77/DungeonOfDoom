using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    class Water : HealthCare
    {
        public Water() : base("Bottle of Water", 1)
        {
        }
        
        public override void Equip(Player player)
        {
            player.BackpackWeight -= Weight;
            player.Health += 5;
        }

        public override void DropItem(Player player)
        {
            player.BackpackWeight -= Weight;
        }
    }
}
