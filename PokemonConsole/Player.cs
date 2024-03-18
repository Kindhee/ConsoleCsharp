using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Player : Tile
    {
        public int _health;
        public int _posX;
        public int _posY;
        public int _lastPosX;
        public int _lastPosY;

        public Player(int health) : base(TileType.Player)
        {
            _posX = 8;
            _posY = 1;
            _lastPosX = 8;
            _lastPosY = 1;  
            _health = health;
        }
    }
}
