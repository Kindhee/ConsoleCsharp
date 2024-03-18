using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Enemy : Tile
    {
        int _level;

        AttributType _attributType;

        int _attack;
        int _health;
        int _defense;
        int _speed;
        int _accuracy;


        public Enemy(int level, AttributType attributType, int health, int attack, int defense, int speed, int accuracy) : base(TileType.Enemy)
        {
            _level = level;

            _attributType = attributType;

            _health = health;
            _attack = attack;
            _defense = defense;
            _speed = speed;
            _accuracy = accuracy;
        }

        // get / set
        public int Level { get => _level; private set => _level = value; }
        public AttributType Type { get => _attributType; private set => _attributType = value; }
        public int Health { get => _health; private set => _health = value; }
        public int Attack { get => _attack; private set => _attack = value; }
        public int Defense { get => _defense; private set => _defense = value; }
        public int Speed { get => _speed; private set => _speed = value; }
        public int Accuracy { get => _accuracy; private set => _accuracy = value; }

    }
}
