using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Utilities;
using DungeonsOfDoom.Core.Characters;
using DungeonsOfDoom.Core.Presenters;
using DungeonsOfDoom.Core.Items;

namespace DungeonsOfDoom.Core
{

    public class Game 
    {
        // Fixa dry i AskForCommand!!!
        const int WorldWidth = 10;   
        const int WorldHeight = 10;
        Room[,] rooms;  
        Player player;
        bool playAgain;
        IGamePresenter presenter;

        public void Start()
        {
            Console.WriteLine("Enter 1 for Standard or press enter for Alternative");
            
            if (Console.ReadLine().ToLower() == "1")
            {
                presenter = new StandardGamePresenter();
            }
            else
            {
                presenter = new AlternativeGamePresenter();
            }

            do
            {
                presenter.WelcomeScreen();
                CreateRooms();
                CreatePlayer();
                do
                {                    
                    Console.Clear();                             
                    presenter.DisplayPlayerInfo(player);
                    presenter.DisplayRooms(player,rooms);
                    PlayerAction();
                    if (player.Health <= 0) break;
                    AskForCommand();

                } while (player.Health > 0);

                GameOver();
                
            } while (playAgain == true);
        }

        private void CreateRooms()
        {           
            rooms = new Room[WorldWidth, WorldHeight];             

            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)         
                {
                    Item item = null; 
                    if (RandomUtility.Try(8) && rooms[x, y] != rooms[0, 0])
                    {
                        if (RandomUtility.Try(50))
                        {
                            item = new Sword();
                        }
                        else
                        {
                            item = new Knife();
                        }
                    }

                    Monster monster = null;
                    if (RandomUtility.Try(20) && rooms[x, y] != rooms[0, 0] && item == null)
                    {
                        if (RandomUtility.Try(50))
                        {
                            monster = new Goblin();
                        }
                        else
                        {
                            monster = new Orc();
                        }
                    }

                    if (RandomUtility.Try(10) && rooms[x, y] != rooms[0, 0] && item == null && monster == null)
                    {
                        if (RandomUtility.Try(50))
                        {
                            item = new Water();
                        }
                        else
                        {
                            item = new Potion();
                        }
                    }
                    rooms[x, y] = new Room(RandomUtility.Randomizer(1,100), item, monster);                   
                }
            }
        }

        private void CreatePlayer()
        {
            Console.WriteLine("\nEnter your name: ");
            string name = Console.ReadLine();
            while (name.Length < 3)
            {               
                Console.WriteLine("Name must be at least 3 characters long!!!");
                name = Console.ReadLine();
            } 
            player = new Player(name, 50, 7, 10);           
        }

        private void PlayerAction()
        {
            Item roomItem = rooms[player.X, player.Y].Item;

            if (roomItem != null && roomItem.Weight <= 10 - player.BackpackWeight)
            {
                Console.WriteLine($"You found a { roomItem.Name}, press SPACE to pick it up");
            }
            else if(roomItem != null && roomItem.Weight > 10 - player.BackpackWeight)
            {
                Console.WriteLine($"You can't pick up the {roomItem.Name}, backpack is full...");
            }
            player.PlayerFight = false;

            Monster roomMonster = rooms[player.X, player.Y].Monster;
            if (roomMonster != null)
            {
                StringUtility.RollingText($"You are attacked by a {roomMonster.Name}!");
                Thread.Sleep(1500);
                player.PlayerFight = true;
                BattleGround(roomMonster);
            }
        }

        private void BattleGround(Monster monster)
        {            
            do
            {
                presenter.DisplayBattleStats(monster,player);
                Thread.Sleep(500);
                
                monster.Fight(player);
                if(monster.DamageDone == false)
                {
                    StringUtility.RollingText($"\t\t\t\t\t{monster.Name} attacks but you blocked it!");
                    Thread.Sleep(1000); 
                }
                else
                {
                    StringUtility.RollingText($"\t\t\t\t\t{monster.Name} attacks! You lose {monster.Damage} in health!");
                    Thread.Sleep(1000);
                }

                if (player.Health <= 0)
                    break;

                presenter.DisplayBattleStats(monster,player);
                
                player.Fight(monster);
                if (player.DamageDone == false)
                {
                    StringUtility.RollingText($"You attack but {monster.Name} blocks you!");
                    Thread.Sleep(1000);
                }
                else
                {
                    StringUtility.RollingText($"You attack! You did {player.Damage} in damage!");
                    Thread.Sleep(1000);
                }
                                                              
            } while (player.Health > 0 && monster.Health > 0);

            if (monster.Health <= 0)
            {
                rooms[player.X, player.Y].Monster = null; 
                Console.WriteLine($"\nYou have killed the {monster.Name}! Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void AskForCommand()
        {
            Item roomItem = rooms[player.X, player.Y].Item;
            if (player.PlayerFight == true && player.Health > 0)
            {
                Console.Clear();
                presenter.DisplayPlayerInfo(player);
                presenter.DisplayRooms(player, rooms);
            }
            
            Console.WriteLine("Press the arrow keys to move:");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (player.Y != 0)
                        player.Y--; break;
                case ConsoleKey.DownArrow:
                    if (player.Y != WorldHeight - 1)
                        player.Y++; break;
                case ConsoleKey.RightArrow:
                    if (player.X != WorldWidth - 1)
                        player.X++; break;
                case ConsoleKey.LeftArrow:
                    if (player.X != 0)
                        player.X--; break;

                case ConsoleKey.Spacebar:
                    if (roomItem == null)
                    {
                        break;
                    }
                    if (roomItem.Weight <= 10 - player.BackpackWeight)
                    {
                        roomItem.PickUp(player);
                        player.BackPack.Add(roomItem);
                        rooms[player.X, player.Y].Item = null;                        
                    }
                    break;

                case ConsoleKey.D1:
                    if(player.BackPack.Count == 0)
                    {
                        break;
                    }
                    if (player.BackPack[0] is HealthCare)
                    {
                        player.BackPack[0].Equip(player);
                        player.BackPack.RemoveAt(0);                       
                    }
                    else if (player.BackPack[0] is Weapon && player.Hands.Count <= 1)
                    {
                        player.BackPack[0].Equip(player);
                        player.Hands.Add(player.BackPack[0]);
                        player.BackPack.RemoveAt(0);                        
                    }
                    break;

                case ConsoleKey.D2:
                    if (player.BackPack.Count <= 1)
                    {
                        break;
                    }
                    if (player.BackPack[1] is HealthCare)
                    {
                        player.BackPack[1].Equip(player);
                        player.BackPack.RemoveAt(1);
                    }
                    else if (player.BackPack[1] is Weapon && player.Hands.Count <= 1)
                    {
                        player.BackPack[1].Equip(player);
                        player.Hands.Add(player.BackPack[1]);
                        player.BackPack.RemoveAt(1);
                    }                    
                    break;

                case ConsoleKey.D3:
                    if (player.BackPack.Count <= 2)
                    {
                        break;
                    }
                    if (player.BackPack[2] is HealthCare)
                    {
                        player.BackPack[2].Equip(player);
                        player.BackPack.RemoveAt(2);
                    }
                    else if (player.BackPack[2] is Weapon && player.Hands.Count <= 1)
                    {
                        player.BackPack[2].Equip(player);
                        player.Hands.Add(player.BackPack[2]);
                        player.BackPack.RemoveAt(2);
                    }
                    break;

                case ConsoleKey.D4:
                    if (player.BackPack.Count <= 3)
                    {
                        break;
                    }
                    if (player.BackPack[3] is HealthCare)
                    {
                        player.BackPack[3].Equip(player);
                        player.BackPack.RemoveAt(3);
                    }
                    else if (player.BackPack[3] is Weapon && player.Hands.Count <= 1)
                    {
                        player.BackPack[3].Equip(player);
                        player.Hands.Add(player.BackPack[3]);
                        player.BackPack.RemoveAt(3);
                    }
                    break;

                case ConsoleKey.D5:
                    if (player.BackPack.Count <= 4)
                    {
                        break;
                    }
                    if (player.BackPack[4] is HealthCare)
                    {
                        player.BackPack[4].Equip(player);
                        player.BackPack.RemoveAt(4);
                    }
                    else if (player.BackPack[4] is Weapon && player.Hands.Count <= 1)
                    {
                        player.BackPack[4].Equip(player);
                        player.Hands.Add(player.BackPack[4]);
                        player.BackPack.RemoveAt(4);
                    }
                    break;

                case ConsoleKey.Backspace:
                    if (player.Hands.Count == 0)
                    {
                        break;
                    }
                    if (player.Hands.Count != 0 && roomItem == null)
                    {
                        Console.WriteLine("Enter 1 or 2 to drop item");
                        
                        ConsoleKeyInfo input = Console.ReadKey();

                        if (input.Key == ConsoleKey.D1)
                        {
                            rooms[player.X, player.Y].Item = player.Hands.First();
                            player.Hands[0].DropItem(player);
                            player.Hands.RemoveAt(0);
                        }
                        else if (input.Key == ConsoleKey.D2 && player.Hands.Count > 1)
                        {
                            rooms[player.X, player.Y].Item = player.Hands.Last();
                            player.Hands[1].DropItem(player);
                            player.Hands.RemoveAt(1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
            }            
        }
 
        private void GameOver()
        {
            Console.WriteLine("\n\n\n");
            StringUtility.Color("red");
            Console.WriteLine("\t\t\t\tYOU ARE DEAD!!! \n");
            StringUtility.Color("white");
            Console.WriteLine("\t\t\t  Want to play again? Enter y/n \n");

            bool validAnswer = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Y: validAnswer = true; playAgain = true; break;

                    case ConsoleKey.N:
                        Console.WriteLine("\t\t\t  Too bad!!! \n\n\n\n\n\n\n\n\n\n\n"); validAnswer = true; playAgain = false;
                        break;

                    default: Console.WriteLine("\t\t\t  Just enter 'y' or 'n'!!! "); validAnswer = false; break;
                }
            } while (validAnswer == false);
        }
    }
}
