using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Enemy : Tile
    {
        string _name;

        int _level;

        AttributType _attributType;

        List<Capacity> _capacities;

        int _health;
        int _defense;
        int _speed;

        bool _isInTeam;


        public Enemy(string name, int level, AttributType attributType, List<Capacity> capacities, int health, int defense, int speed) : base(TileType.Enemy)
        {
            _name = name;

            _level = level;

            _attributType = attributType;

            _capacities = capacities;

            _health = health;
            _defense = defense;
            _speed = speed;

            _isInTeam = false;
        }

        // get / set
        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level;  set => _level = value; }
        public AttributType Type { get => _attributType;  set => _attributType = value; }
        public List<Capacity> capacities { get => _capacities; set => _capacities = value; }
        public int Health { get => _health;  set => _health = value; }
        public int Defense { get => _defense;  set => _defense = value; }
        public int Speed { get => _speed;  set => _speed = value; }
        public bool isInTeam { get => _isInTeam; set => _isInTeam = value; }

    }
}
