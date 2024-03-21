using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonConsole.Items;

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
        public Inventory _inventory = new();

        public Player() : base(TileType.Player)
        {
            _posX = 8;
            _posY = 15;
            _lastPosX = 8;
            _lastPosY = 1;

            _dirX = 0;
            _dirY = 0;

            Inventory.AddItem("test", "items");
            Inventory.AddItem("potion", "items");
            Inventory.AddPokeBall("pokeball", 10);
            Inventory.AddItem("phone", "keys");

            Inventory.AddItem("test", "items", 5);
            //Inventory.AddItem(new Item("Fuck you", "lmao", false), "itm");
        }

        // get / set
        public int PosX { get => _posX;  set => _posX = value; }
        public int PosY { get => _posY;  set => _posY = value; }
        public int LastPosX { get => _lastPosX;  set => _lastPosX = value; }
        public int LastPosY { get => _lastPosY;  set => _lastPosY = value; }
        public int DirX { get => _dirX; set => _dirX = value; }
        public int DirY { get => _dirY; set => _dirY = value; }
        public Inventory Inventory { get => _inventory; }

    }
}
