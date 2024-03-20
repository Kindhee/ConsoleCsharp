﻿using PokemonConsole.State.Menus.Sous_Menus;
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

        Capacity _bite;
        Capacity _stomp;

        Capacity _firePunch;
        Capacity _flameThrower;

        Capacity _waterGun;
        Capacity _jetPunch;

        Capacity _leafBlade;
        Capacity _bulletSeed;

        List<Capacity> _capacitiesWater;
        List<Capacity> _capacitiesFire;
        List<Capacity> _capacitiesPlant;

        List<Enemy> _lEnemies = new List<Enemy>();



        public void Init() {
            /* string text = File.ReadAllText("path");
            var thing = JsonSerializer.Deserialize<Thing>(text);*/

            // only player
            _player = new Player(1, 10, 10, 10, 10, 10);

            // generic can be used multiple times
            _tree = new Tree();

            // capacities 

            _bite = new Capacity("Bite", AttributType.Fire, 5, 100);
            _stomp = new Capacity("Stomp", AttributType.Fire, 10, 90);

            _firePunch = new Capacity("Fire Punch", AttributType.Fire, 15, 95);
            _flameThrower = new Capacity("Flame Thrower", AttributType.Fire, 40, 60);

            _waterGun = new Capacity("Water Gun", AttributType.Water, 20, 80);
            _jetPunch = new Capacity("Jet Punch", AttributType.Water, 30, 70);

            _leafBlade = new Capacity("Leaf Blade", AttributType.Plant, 25, 75);
            _bulletSeed = new Capacity("Bullet Speed", AttributType.Plant, 15, 90);



            // move sets 
            _capacitiesFire = new List<Capacity>() { _firePunch, _flameThrower, _bite, _stomp };
            _capacitiesWater = new List<Capacity>() { _waterGun, _jetPunch, _bite, _stomp };
            _capacitiesPlant = new List<Capacity>() { _leafBlade, _bulletSeed, _bite, _stomp };


            // enemies
            _lEnemies.Add(new Enemy("Charmander", 10, AttributType.Fire, _capacitiesFire, 10, 5, 25));
            _lEnemies.Add(new Enemy("Squirtle", 10, AttributType.Water, _capacitiesWater, 15, 10, 15));
            _lEnemies.Add(new Enemy("Bulbasaur", 10, AttributType.Plant, _capacitiesPlant, 20, 15, 5));


        }

        // get / set
        public Player player { get => _player; set => _player = value; }
        public Tree tree { get => _tree; set => _tree = value; }
        public Enemy enemyFire { get => _lEnemies[0]; set => _lEnemies[0] = value; }
        public Enemy enemyWater { get => _lEnemies[1]; set => _lEnemies[1] = value; }
        public Enemy enemyPlant { get => _lEnemies[2]; set => _lEnemies[2] = value; }
        public List<Enemy> enemies { get => _lEnemies; set => _lEnemies = value; }
    }
}

