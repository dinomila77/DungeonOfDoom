using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DungeonsOfDoom.Core.Characters
{  
    class Goblin : Monster
    {       
        public Goblin() : base("Goblin","G", 30, 7, 11)
        {         
        }
        public override void Fight(Character opponent)
        {          
            SpecialAttack = RandomUtility.Randomizer(1, 10);

            if (Attack + SpecialAttack - opponent.Defense > 0)
            {
                Damage = Attack + SpecialAttack - opponent.Defense;
                opponent.Health -= Damage;
                DamageDone = true;
            }
            else
            {
                DamageDone = false;
            }
        }
    }
}
