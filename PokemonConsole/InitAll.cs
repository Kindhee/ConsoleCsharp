using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class InitAll
    {
        Player _player;
        Tree _tree;

        Capacity _waterGun;
        Capacity _firePunch;
        Capacity _leafBlade;
        Capacity _flameThrower;

        List<Capacity> _capacities;

        Enemy _enemy;

        public void Init() {
            /* string text = File.ReadAllText("path");
            var thing = JsonSerializer.Deserialize<Thing>(text);*/

            // only player
            _player = new Player(1, 10, 10, 10, 10, 10);

            // generic tree can be used multiple times
            _tree = new Tree();

            // capacities 
            _waterGun = new Capacity("Water Gun", AttributType.Water, 20, 80);
            _firePunch = new Capacity("Fire Punch", AttributType.Fire, 10, 100);
            _leafBlade = new Capacity("Leaf Blade", AttributType.Plant, 15, 90);
            _flameThrower = new Capacity("Flame Thrower", AttributType.Fire, 40, 60);

            // move sets 
            _capacities = new List<Capacity>() { _waterGun, _firePunch, _leafBlade, _flameThrower };

            // enemies
            _enemy = new Enemy(10, AttributType.Fire, _capacities, 10, 5, 15);
        }

        // get / set
        public Player player { get => _player; set => _player = value; }
        public Tree tree { get => _tree; set => _tree = value; }
        public List<Capacity> capacities { get => _capacities; set => _capacities = value; }
        public Enemy enemy { get => _enemy; set => _enemy = value; }
    }
}


