
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Characters
{
    abstract class Character : GameObject
    {
        public Character(string name,string mapSymbol, int health, int attack, int defense) : base(name, mapSymbol)
        {
            Health = health;
            Attack = attack;
            Defense = defense;
            SpecialAttack = 0;
            DamageDone = false;
        }

        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public bool DamageDone { get; set; }
        public int Damage { get; set; }

        public abstract void Fight(Character opponent); 
    }
}
