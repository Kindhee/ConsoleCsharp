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

        public HealthItem(string name, string desc, bool isKeyItem, int healAmount, int price=100, int sell = -0xfffffff) : base(name, desc, isKeyItem, price, sell)
        {
            _healAmount = healAmount;
        }
    }
}
