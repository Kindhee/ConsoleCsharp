using PokemonConsole.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Inventory
    {
        //List<Item> items = new();
        //List<Item> pokemon

        public class StorageItemInfo
        {
            public Item item;
            public int amount;

            public StorageItemInfo(Item newItem, int amount)
            {
                this.item = newItem;
                this.amount = amount;
            }
        }
        public Dictionary<string, List<StorageItemInfo>> _bag = new();

        internal ItemRegistry database = new();

        public Inventory() {
            _bag["items"] = new List<StorageItemInfo>();
            _bag["pokeballs"] = new List<StorageItemInfo>();
            _bag["cds"] = new List<StorageItemInfo>();
            _bag["keys"] = new List<StorageItemInfo>();

            //_bag["pokeballs"]
            //_bag["items"].Add(new HealthItem("Potion", "Spray your Pokemon with this.\nHeals 20 HPs.", false, 20));
        }

        public List<StorageItemInfo> Items { get => _bag["items"]; }
        public List<StorageItemInfo> Pokeballs { get => _bag["pokeballs"]; }
        public List<StorageItemInfo> CDs { get => _bag["cds"]; }
        public List<StorageItemInfo> Keys { get => _bag["keys"]; }

        public bool AddPokeBall(string ball_id, int amount=1)
        {
            var item = database.pokeballs[ball_id];

            // todo: this
            for (int i = 0; i < _bag["pokeballs"].Count; i++)
            {
                var storItem = _bag["pokeballs"][i];
                if (storItem.item.name == item.name && storItem.item.desc == item.desc)
                {
                    _bag["pokeballs"][i].amount = storItem.amount + amount;
                    return true;
                }
            }
            _bag["pokeballs"].Add(new StorageItemInfo(item, amount));
            return true;
        }

        public bool AddItem(string item_id, string storage, int amount=1)
        {
            var item = database.items[item_id];

            if (!storage.EndsWith("s"))
            {
                storage = storage + "s";
            }

            try
            {
                for (int i = 0; i < _bag[storage].Count; i++)
                {
                    var storItem = _bag[storage][i];
                    if (storItem.item.name == item.name && storItem.item.desc == item.desc)
                    {
                        _bag[storage][i].amount = storItem.amount+amount;
                        return true;
                    }
                }
                _bag[storage].Add(new StorageItemInfo(item, amount));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public void RemoveItem(Item item, bool fullRemove=false)
        {
            (StorageItemInfo sItem, string storage) = GetItemInStorage(item);
            if (sItem == null)
                return;
            if (!fullRemove)
                sItem.amount -= 1;
            else
                sItem.amount = 0;
            if (sItem.amount <= 0)
            {
                _bag[storage].Remove(sItem);
            }
        }

        //Awful
        public Tuple<StorageItemInfo, string> GetItemInStorage(Item item)
        {
            StorageItemInfo sItem;
            sItem = GetItemInStorage(item, "items");
            if (sItem != null)
                return new(sItem, "items");
            sItem = GetItemInStorage(item, "pokeballs");
            if (sItem != null)
                return new(sItem, "pokeballs");
            sItem = GetItemInStorage(item, "cds");
            if (sItem != null)
                return new(sItem, "cds");
            sItem = GetItemInStorage(item, "keys");
            if (sItem != null)
                return new(sItem, "keys");
            return new(null, null);
        }

        public StorageItemInfo GetItemInStorage(Item item, string storage)
        {
            for (int i = 0; i < _bag[storage].Count; i++)
            {
                var storItem = _bag[storage][i];
                if (storItem.item.name == item.name && storItem.item.desc == item.desc)
                {
                    return storItem;
                }
            }
            return null;
        }
    }
}
