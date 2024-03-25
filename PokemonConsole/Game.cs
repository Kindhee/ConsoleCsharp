﻿using PokemonConsole.State;
using PokemonConsole.State.Menus.Sous_Menus;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public  class Game
    {
        public Tile[,] _map;
        Tree _tree;
        Bush _bush;

        public int _size;
        public Player _player;
        private BlankState _State;
        private List<BlankState> _StateList;
        List<string[]> pokemons = Utils.GetListFromFile("txt/Pokemons.txt");

        int chance;
        Random rand = new Random();
        
        public BlankState State {get => StateList.Last(); set => throw new Exception("Use setState or pushState to set the State."); }
        public List<BlankState> StateList { get => _StateList; }

        private Dictionary<string, Enemy> _lEnemiesMeet = new Dictionary<string, Enemy>();
        public Dictionary<string, Enemy> lEnemiesMeet { get => _lEnemiesMeet; }

        private List<Enemy> _lInTeam = new List<Enemy>();
        public List<Enemy> lInTeam { get => _lInTeam; }

        public Game(int size, Player player)
        {
            _map = new Tile[size,size];
            _size = size;
            _player = player;
            _StateList = new List<BlankState>();

            _tree = new Tree();
            _bush = new Bush();

            // choose map
            LoadMap("overworld");

            // Temporary get pokemon in our team
            int index2 = rand.Next(0, pokemons.Count);

            string[] randPokemon2 = pokemons[index2];

            Enemy enemy2 = new Enemy(
                randPokemon2[0],
                (AttributType)int.Parse(randPokemon2[1]),
                int.Parse(randPokemon2[2]),
                new List<string>() { randPokemon2[3], randPokemon2[4], randPokemon2[5], randPokemon2[6] },
                int.Parse(randPokemon2[7]),
                int.Parse(randPokemon2[8]),
                int.Parse(randPokemon2[9]));

            enemy2.isInTeam = true;
            lInTeam.Add(enemy2);
            //

        }

        public void LoadMap(string name)
        {
            // empty map 
            String lineRead;
            StreamReader mapTxt = null;

            switch (name)
            {
                case "lobby":
                    mapTxt = new StreamReader("../../../txt/lobby.txt");
                    break;

                case "overworld":
                    mapTxt = new StreamReader("../../../txt/overworld.txt");
                    break;
            }

            lineRead = mapTxt.ReadLine();
            int lineNumber = 0;


            while (lineRead != null)
            {
                int colNumber = 0;
                foreach (char charRead in lineRead)
                {
                    switch (charRead)
                    {

                        case 't':
                            AddTree(colNumber, lineNumber, _tree);
                            break;

                        case 'b':
                            AddBush(colNumber, lineNumber, _bush);
                            break;

                        default:
                            _map[colNumber, lineNumber] = new Tile(TileType.Empty);
                            break;
                    }

                    colNumber++;
                }
                lineRead = mapTxt.ReadLine();
                lineNumber++;
            }

            mapTxt.Close();

            // put player on the map 
            _map[_player.PosX, _player.PosY] = _player;
        }


        public void DrawMapUpdate()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_map[i, j]._tileType != TileType.Empty)
                    {
                        Console.SetCursorPosition(i * 2 + 1, j + 1);
                        Console.Write(_map[i, j].GetString() + " ");
                    }
                }
            }
            Console.SetCursorPosition(0, _size+12);
        }


            public void DrawMapInit()
        {
            Console.Write("╔");
            for (int i = 0; i <= (_size*2)-1;  i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╗");
            for (int i = 0; i < _size; i++)
            {
                Console.Write("║");
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_map[j, i].GetString() + " ");
                }
                Console.WriteLine("║");
            }
            Console.Write("╚");
            for (int i = 0; i <= (_size * 2) - 1; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╝");

            Console.Write("\n\n");

            Console.WriteLine("Inventory: ");

            Console.WriteLine("Items:");
            for (int i = 0; i < _player.Inventory.Items.Count(); i++)
            {
                Console.WriteLine("\t"+_player.Inventory.Items[i].item.name + "   x" + _player.Inventory.Items[i].amount);
            }

            Console.WriteLine("Pokeballs:");
            for (int i = 0; i < _player.Inventory.Pokeballs.Count(); i++)
            {
                Console.WriteLine("\t" + _player.Inventory.Pokeballs[i].item.name + "   x" + _player.Inventory.Pokeballs[i].amount);
            }

            Console.WriteLine("Key Items:");
            for (int i = 0; i < _player.Inventory.Keys.Count(); i++)
            {
                Console.WriteLine("\t" + _player.Inventory.Keys[i].item.name + "   x" + _player.Inventory.Keys[i].amount);
            }
        }

        public void Run()
        {
            while(true)
            {
                // clear console
                //Console.Clear();

                Console.SetCursorPosition(0, 0);

                State.Run(this);

                State.HandleInput(this);

            }
        }

        public Enemy NewEnemy()
        {
            int index = rand.Next(0, pokemons.Count);

            string[] randPokemon = pokemons[index];

            Enemy enemy = new Enemy(
                randPokemon[0], 
                (AttributType)int.Parse(randPokemon[1]), 
                int.Parse(randPokemon[2]), 
                new List<string>() { randPokemon[3], randPokemon[4], randPokemon[5], randPokemon[6] }, 
                int.Parse(randPokemon[7]),
                int.Parse(randPokemon[8]),
                int.Parse(randPokemon[9] ));

            return enemy;
        }

        public void AddToTeam(Enemy enemy)
        {
            enemy.isInTeam = true;
        }

        public void AddBush (int posX, int posY, Bush bush)
        {
            _map[posX, posY] = bush;
        }

        public void AddTree(int posX, int posY, Tree tree)
        {
            _map[posX, posY] = tree;
        }

        public bool IsEncoutering()
        {
            chance = rand.Next(0, 11);
            if (chance <= 2)
            {
                return true;
            }
            return false;
        }

        public void SetState(BlankState state)
        {
            BlankState old = null;
            //Console.WriteLine(StateList.Count);
            if (StateList.Count > 0)
            {
                old = StateList.Last();
                old.Leave(state);
            }
            StateList.Clear();

            StateList.Add(state);
            if (old != null)
                state.Enter(old);
        }

        public void PushState(BlankState state)
        {
            BlankState old = StateList.Last();
            StateList.Add(state);
            state.Enter(old);
            old.Pause(state);
        }

        public void PopState()
        {
            BlankState old = StateList.Last();
            StateList.RemoveAt(StateList.Count - 1);
            BlankState newS = StateList.Last();
            old.Leave(newS);
            newS.Resume(old);

        }

        public void AddMetPokemon(Enemy newEnemy, Game game)
        {
            if (!game.lEnemiesMeet.ContainsKey(newEnemy.Name))
            {
                game.lEnemiesMeet.Add(newEnemy.Name, newEnemy);
            }
        }
    }
}
