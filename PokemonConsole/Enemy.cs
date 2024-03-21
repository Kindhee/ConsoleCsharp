using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Enemy
    {
        string _name;

        AttributType _attributType;

        int _level;

        List<Capacity> _capacities;

        int _health;
        int _defense;
        int _speed;

        bool _isInTeam;

        CapacitiesRegistration capacitiesRegistration = new CapacitiesRegistration();

        public Enemy(string name, AttributType attributType, int level, List<string> capacities, int health, int defense, int speed)
        {
            _name = name;

           _attributType = attributType;

            _level = level;

            _capacities = capacitiesRegistration.GetCapacities(capacities);

            _health = health;
            _defense = defense;
            _speed = speed;

            _isInTeam = false;
        }

        // get / set
        public string Name { get => _name; set => _name = value; }
        public AttributType Type { get => _attributType;  set => _attributType = value; }
        public int Level { get => _level; set => _level = value; }
        public List<Capacity> Capacities { get => _capacities; set => _capacities = value; }
        public int Health { get => _health;  set => _health = value; }
        public int Defense { get => _defense;  set => _defense = value; }
        public int Speed { get => _speed;  set => _speed = value; }
        public bool isInTeam { get => _isInTeam; set => _isInTeam = value; }

    }
}
