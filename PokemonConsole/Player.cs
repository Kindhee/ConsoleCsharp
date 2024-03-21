using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Player : Tile
    {

        int _posX;
        int _posY;
        int _lastPosX;
        int _lastPosY;

        int _dirX;
        int _dirY;

        public Player() : base(TileType.Player)
        {
            _posX = 8;
            _posY = 15;
            _lastPosX = 8;
            _lastPosY = 1;

            _dirX = 0;
            _dirY = 0;
        }

        // get / set
        public int PosX { get => _posX;  set => _posX = value; }
        public int PosY { get => _posY;  set => _posY = value; }
        public int LastPosX { get => _lastPosX;  set => _lastPosX = value; }
        public int LastPosY { get => _lastPosY;  set => _lastPosY = value; }
        public int DirX { get => _dirX; set => _dirX = value; }
        public int DirY { get => _dirY; set => _dirY = value; }

    }
}
