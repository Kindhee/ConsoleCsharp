using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        // get / set
        public int PosX { get => _posX; private set => _posX = value; }
        public int PosY { get => _posY; private set => _posY = value; }
        public int LastPosX { get => _lastPosX; private set => _lastPosX = value; }
        public int LastPosY { get => _lastPosY; private set => _lastPosY = value; }
        public int Level { get => _level; private set => _level = value; }
        public int Health { get => _health; private set => _health = value; }
        public int Attack { get => _attack; private set => _attack = value; }
        public int Defense { get => _defense; private set => _defense = value; }
        public int Speed { get => _speed; private set => _speed = value; }
        public int Accuracy { get => _accuracy; private set => _accuracy = value; }


    }
}
