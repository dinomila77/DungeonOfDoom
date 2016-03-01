using DungeonsOfDoom.Core.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Presenters
{
    interface IGamePresenter
    {
        void WelcomeScreen();
        void DisplayRooms(Player player, Room[,] rooms);
        void DisplayPlayerInfo(Player player);
        void DisplayBattleStats(Monster monster, Player player);
    }
}
