using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.Items
{
    internal class HealthItem : Item
    {
        public int _healAmount = 42;

        public HealthItem(string name, string desc, bool isKeyItem, int healAmount) : base(name, desc, isKeyItem)
        {
            _healAmount = healAmount;
        }
    }
}
