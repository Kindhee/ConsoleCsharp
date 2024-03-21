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
        Bush _bush;

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

        List<string> _PokemonNames;
        List<AttributType> _PokemonTypes;
        List<List<Capacity>> _PokemonCapacities;



        public void Init() {
            /* string text = File.ReadAllText("path");
            var thing = JsonSerializer.Deserialize<Thing>(text);*/

            // only player
            _player = new Player();

            // generic can be used multiple times
            _tree = new Tree();
            _bush = new Bush();

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
            _PokemonNames = new List<string>() { "Charmander", "Squirtle", "Bulbasaur"};
            _PokemonTypes = new List<AttributType>() { AttributType.Fire, AttributType.Water, AttributType.Plant };
            _PokemonCapacities = new List<List<Capacity>>() { _capacitiesFire, _capacitiesWater, _capacitiesPlant };

           /* _lEnemies.Add(new Enemy("Charmander", 10, AttributType.Fire, _capacitiesFire, 10, 5, 25));
            _lEnemies.Add(new Enemy("Squirtle", 10, AttributType.Water, _capacitiesWater, 15, 10, 15));
            _lEnemies.Add(new Enemy("Bulbasaur", 10, AttributType.Plant, _capacitiesPlant, 20, 15, 5));*/


        }

        // get / set
        public Player player { get => _player; set => _player = value; }
        public Tree tree { get => _tree; set => _tree = value; }
        public Bush bush { get => _bush; set => _bush = value; }
        public List<string> PokemonNames { get => _PokemonNames; set => _PokemonNames = value; }
        public List<AttributType> PokemonTypes { get => _PokemonTypes; set => _PokemonTypes = value; }
        public List<List<Capacity>> PokemonCapacities { get => _PokemonCapacities; set => _PokemonCapacities = value; }
    }
}


