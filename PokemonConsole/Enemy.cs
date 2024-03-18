using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Enemy : Tile
    {
        public int _health;

        public Enemy(int health) : base(TileType.Enemy)
        {
            _health = health;
        }
    }
}
