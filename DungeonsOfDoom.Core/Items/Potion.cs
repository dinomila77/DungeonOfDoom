using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    class Potion : HealthCare
    {
        public Potion() : base("Health Potion", 2)
        {
        }

        public override void Equip(Player player)
        {
            player.BackpackWeight -= Weight;
            player.Health += 10;
        }

        public override void DropItem(Player player)
        {
            player.BackpackWeight -= Weight;
        }
    }
}
