using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DungeonsOfDoom.Core.Presenters
{
    class StandardGamePresenter : IGamePresenter
    {
        public void WelcomeScreen()
        {
            Console.Clear();
            StringUtility.Color("red");
            //Console.WriteLine("Welcome to Dungeons of Doom!");
            Console.WriteLine(@"    ___                                          ___  ___                  __");
            Console.WriteLine(@"   / _ \__ _____  ___ ____ ___  ___  ___   ___  / _/ / _ \___  ___  __ _  / /");
            Console.WriteLine(@"  / // / // / _ \/ _ `/ -_) _ \/ _ \(_-<  / _ \/ _/ / // / _ \/ _ \/  ' \/_/ ");
            Console.WriteLine(@" /____/\_,_/_//_/\_, /\__/\___/_//_/___/  \___/_/  /____/\___/\___/_/_/_(_)  ");
            Console.WriteLine("                /___/                                                        \n");
            StringUtility.Color("white");
        }

        public void DisplayPlayerInfo(Player player)
        {
            Console.WriteLine($"Player name: {player.Name} Health: {player.Health} Attack: {player.Attack} Defense: {player.Defense}");      
            Console.WriteLine($"Position: {player.X} {player.Y}");
            Console.WriteLine($"Hands: (Backspace to drop item)");

            for (int i = 0; i < player.Hands.Count; i++)
            {
                Console.Write("{0} {1} ", i + 1, player.Hands[i].Name);
            }  
            Console.WriteLine($"\nBackpack Weight: {player.BackpackWeight} (To equip item press the number)");
            
            for (int i = 0; i < player.BackPack.Count; i++)
            {

                Console.WriteLine("Slot: {0} {1} ", i + 1, player.BackPack[i].Name);
            }
            Console.WriteLine();           
        }

        public void DisplayRooms(Player player, Room[,] rooms)
        {
            int worldHeight = rooms.GetLength(1);
            int worldWidth = rooms.GetLength(0);

            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {
                    if (y == player.Y && x == player.X)
                    {
                        StringUtility.Color("yellow");
                        Console.Write($"[{player.MapSymbol}]");
                        StringUtility.Color("white");
                    }
                    else if (rooms[x, y].Item != null)
                    {
                        StringUtility.Color("cyan");
                        Console.Write($"[{rooms[x, y].Item.MapSymbol}]");
                        StringUtility.Color("white");
                    }
                    else if (rooms[x, y].Monster != null)
                    {
                        StringUtility.Color("Red");
                        Console.Write($"[{rooms[x, y].Monster.MapSymbol}]");
                        StringUtility.Color("white");
                    }
                    else
                    {
                        StringUtility.Color("white");
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void DisplayBattleStats(Monster monster, Player player)
        {
            Console.Clear();
            Console.WriteLine($"Player Health: {player.Health}\t\t\tMonster Health: {monster.Health} \n");
        }
    }
}
