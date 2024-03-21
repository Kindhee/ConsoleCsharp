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

        public Item(string name, string desc, bool isKeyItem=false, int price=100, int sell=-0xfffffff) {
            _name = name;
            _desc = desc;
            _isKey = isKeyItem;
            _price = price;
            if (sell == -0xfffffff)
                _sell = price/2;
            else
                _sell = sell;
        }

        public int _price = 100;
        public int _sell = 100;

        private bool _isKey = false;

        public string name { get => _name; set => _name = value; }
        public string desc { get => _desc; set => _desc = value; }
        public bool isKey { get => _isKey; }
        public int price { get => _price; set => _price = value; }
        public int sell { get => _sell; set => _sell = value; }

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
