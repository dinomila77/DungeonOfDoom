using DungeonsOfDoom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
                game.Start();
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Oops... Something went wrong!");
            }
        }      
    }
}
 