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

        public struct StorageItemInfo
        {
            public Item item;
            public int nb;
        }
        readonly Dictionary<string, List<StorageItemInfo>> _bag = new();

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

        bool AddItem(Item item, string storage)
        {
            if (!storage.EndsWith("s"))
            {
                storage = storage + "s";
            }

            if (storage.ToLower() == "pokeballs")
            {
                if (item is not PokeBall) {
                    return false;
                }
            }

            try
            {
                // todo: this
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
