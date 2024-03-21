using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.Items
{
    public class ItemRegistry
    {
        public Dictionary<string, Item> items;
        public Dictionary<string, PokeBall> pokeballs;

        public ItemRegistry() {
            items = new Dictionary<string, Item>();
            pokeballs = new Dictionary<string, PokeBall>();

            items["test"] = new Item("TestItem", "Can't you see him? He's looking at you right now.", false);
            items["potion"] = new HealthItem("Potion", "Restores Pokémon HP by 20.", false, 300);
            items["sPotion"] = new HealthItem("Super Potion", "Restores Pokémon HP by 50.", false, 50, 700);
            items["hPotion"] = new HealthItem("Hyper Potion", "Restores Pokémon HP by 200.", false, 200, 1500);

            items["phone"] = new Item("iPhone 13+", "What? You can't afford the brand new iPhone 15 Pro Max at $2000? HAH!", true);

            pokeballs["pokeball"] = new PokeBall("Poké Ball", "A Ball thrown to catch a wild Pokémon. It is designed in a capsule style.", 1f);
            pokeballs["greatball"] = new PokeBall("Super Ball", "A good, quality Ball that offers a higher Pokémon catch rate than a standard Poké Ball.", 1.5f);
            pokeballs["hyperball"] = new PokeBall("Hyper Ball", "A better Ball with a higher catch rate than a Great Ball.", 2f);
            pokeballs["masterball"] = new PokeBall("Master Ball", "The best Ball with the ultimate performance. It will catch any wild Pokémon without fail. ", 255f);
        }
    }
}
