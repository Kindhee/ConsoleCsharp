using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    internal class Item
    {
        public string name = "Item";
        public string desc = "Basic Item Moment";

        public int price = 100;
        public int sell = 100;

        public bool isKey = false;

        public bool canSell()
        {
            return sell > 0;
        }

        public void onOverWorldUse()
        {

        }

        public void onBattleUse()
        {

        }
    }
}
