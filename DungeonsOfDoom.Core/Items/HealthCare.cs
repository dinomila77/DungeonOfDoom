using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    abstract class HealthCare : Item
    {
        public HealthCare(string name, int weight) : base(name,"H",weight)
        {           
        }
    }
}
