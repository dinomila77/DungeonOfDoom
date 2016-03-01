using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Characters
{
    abstract class Monster : Character
    {
        public Monster(string name,string mapSymbol, int health, int attack, int defense) : base(name,mapSymbol,health,attack,defense)
        {            
        }       
    }
}
