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
        int _level;

        int _attack;
        int _health;
        int _defense;
        int _speed;
        int _accuracy;

        int _posX;
        int _posY;
        int _lastPosX;
        int _lastPosY;

        public Inventory _inventory = new();

        public Player(int level, int health, int attack, int defense, int speed, int accuracy) : base(TileType.Player)
        {
            _posX = 8;
            _posY = 1;
            _lastPosX = 8;
            _lastPosY = 1;

            _level = level;

            _health = health;
            _attack = attack;
            _defense = defense;
            _speed = speed;
            _accuracy = accuracy;

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
        public int Level { get => _level;  set => _level = value; }
        public int Health { get => _health;  set => _health = value; }
        public int Attack { get => _attack;  set => _attack = value; }
        public int Defense { get => _defense;  set => _defense = value; }
        public int Speed { get => _speed;  set => _speed = value; }
        public int Accuracy { get => _accuracy;  set => _accuracy = value; }
        public Inventory Inventory { get => _inventory; }


    }
}
