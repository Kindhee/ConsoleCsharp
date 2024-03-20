using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.Items
{
    public class Item
    {
        string _name = "Item";
        string _desc = "Basic Item Moment";

        public Item(string name, string desc, bool isKeyItem) {
            _name = name;
            _desc = desc;
            _isKey = isKeyItem;
        }

        public int price = 100;
        public int sell = 100;

        private bool _isKey = false;

        public string name { get => _name; set => _name = value; }
        public string desc { get => _desc; set => _desc = value; }
        public bool isKey { get => _isKey; }

        public bool canSell()
        {
            return sell > 0;
        }

        public bool RemoveOnUse()
        {
            return !_isKey;
        }

        public void onOverWorldUse()
        {

        }

        public void onBattleUse()
        {

        }
    }
}
