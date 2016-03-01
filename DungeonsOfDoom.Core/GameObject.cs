using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    abstract class GameObject
    {
        public GameObject(string name, string mapSymbol)
        {
            Name = name;
            MapSymbol = mapSymbol;         
        }
        public string Name { get; private set; }
        public string MapSymbol { get; private set; }
    }
}
