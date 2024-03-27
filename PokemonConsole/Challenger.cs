using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{    public class Challenger : Tile
    {
        List<string[]> pokemons = Utils.GetListFromFile("txt/Pokemons.txt");

        Random rand = new Random();

        List<Enemy> lChallengerTeam = new List<Enemy>();
        public Challenger(int teamSize) : base(TileType.Challenger)
        {

            for (int i = 0; i < teamSize; i++)
            {
                int index = rand.Next(0, pokemons.Count);

                string[] randPokemon = pokemons[index];

                // level scaling
                int level = rand.Next(int.Parse(randPokemon[2]), int.Parse(randPokemon[3]));
                int scaling = level / 100;

                // stats affected
                int health = rand.Next(int.Parse(randPokemon[8]), int.Parse(randPokemon[9]));
                int defense = rand.Next(int.Parse(randPokemon[10]), int.Parse(randPokemon[11]));
                int speed = rand.Next(int.Parse(randPokemon[12]), int.Parse(randPokemon[13]));
                int strength = rand.Next(int.Parse(randPokemon[14]), int.Parse(randPokemon[15]));

                Enemy enemy = new Enemy(
                    randPokemon[0],                                                                         // name
                    (AttributType)int.Parse(randPokemon[1]),                                                // type
                    level,                                                                                  // level
                    new List<string>() { randPokemon[4], randPokemon[5], randPokemon[6], randPokemon[7] },  // capacities
                    health + (health * scaling),                                                            // health
                    defense + (defense * scaling),                                                          // defense
                    speed + (speed * scaling),                                                              // speed
                    strength + (strength * scaling));                                                       // strength

                lChallengerTeam.Add(enemy);
            }
        }
    }
}
