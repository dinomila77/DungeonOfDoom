
using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DungeonsOfDoom.Core.Characters
{
    class Player : Character
    {        
        public Player(string name, int health, int attack, int defense) : base (name,"P",health,attack,defense)
        {
            try
            {
                if (name.Length < 3)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ett fel uppstod: " + e.Message);
                Console.ReadLine();              
            }

            Hands = new List<Item>();
            BackPack = new List<Item>();
            PlayerFight = false;
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

        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Hands { get; set; }
        public List<Item> BackPack { get; set; }
        public int BackpackWeight { get; set; }
        public bool PlayerFight { get; set; }
    }
}
