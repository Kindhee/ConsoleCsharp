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

        int _maxHealth;
        int _health;
        int _defense;
        int _speed;
        int _stength;

        int _reward;

        bool _isInTeam;

        CapacitiesRegistration capacitiesRegistration = new CapacitiesRegistration();

        public Enemy(string name, AttributType attributType, int level, List<string> capacities, int health, int defense, int speed, int strength)
        {
            _name = name;

           _attributType = attributType;

            _level = level;

            _capacities = capacitiesRegistration.GetCapacities(capacities);

            _maxHealth = health;
            _health = health;
            _defense = defense;
            _speed = speed;
            _stength = strength;

            _reward = 1;

            _isInTeam = false;
        }

        public void LevelUp (Enemy enemy, int reward)
        {
            enemy.Level += reward;
            enemy.MaxHealth += reward;
            enemy.Defense += reward; 
            enemy.Speed += reward;
            enemy.Strength += reward;
        }

        // get / set
        public string Name { get => _name; set => _name = value; }
        public AttributType Type { get => _attributType;  set => _attributType = value; }
        public int Level { get => _level; set => _level = value; }
        public List<Capacity> Capacities { get => _capacities; set => _capacities = value; }
        public int Health { get => _health;  set => _health = value; }
        public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public int Defense { get => _defense;  set => _defense = value; }
        public int Speed { get => _speed;  set => _speed = value; }
        public int Strength { get => _stength; set => _stength = value; }
        public int Reward { get => _reward; set => _reward = value; }
        public bool isInTeam { get => _isInTeam; set => _isInTeam = value; }

    }
}
