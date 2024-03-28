using PokemonConsole.State;
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
        public string _currentMap;
        public int _size;
        public Player _player;
        private BlankState _State;
        private List<BlankState> _StateList;
        List<string[]> pokemons = Utils.GetListFromFile("txt/Pokemons.txt");

        Enemy _selectedPkm;

        int chance;
        Random rand = new Random();
        
        public BlankState State {get => StateList.Last(); set => throw new Exception("Use setState or pushState to set the State."); }
        public List<BlankState> StateList { get => _StateList; }

        private List<Enemy> _lEnemiesMeet = new List<Enemy>();
        public List<Enemy> lEnemiesMeet { get => _lEnemiesMeet; }

        private List<Enemy> _lInTeam = new List<Enemy>();
        public List<Enemy> lInTeam { get => _lInTeam; }

        private List<Enemy> _lPokemonCatch = new List<Enemy>();
        public List<Enemy> lPokemonCatch { get => _lPokemonCatch; }
        
        public Enemy SelectedPKM { get => _selectedPkm; set => _selectedPkm = value; }
        
        public Game(int size, Player player)
        {
            Console.WindowHeight= size+15; 
            _map = new Tile[size,size];
            _size = size;
            _player = player;
            _StateList = new List<BlankState>();

            // choose map
            _currentMap = "lobby";
            LoadMap(_currentMap);
        }

        public void LoadMap(string name)
        {
            // empty map 
            String lineRead;
            StreamReader mapTxt = new StreamReader($"../../../txt/maps/{name}.txt");
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
                            _map[colNumber, lineNumber] = new Tree();

                            break;

                        case 'b':
                            _map[colNumber, lineNumber] = new Bush();
                            break;

                        case 'r':
                            _map[colNumber, lineNumber] = new Tile(TileType.Roof);
                            break;

                        case 'w':
                            _map[colNumber, lineNumber] = new Tile(TileType.Wall);
                            break;

                        case 'p':
                            _map[colNumber, lineNumber] = new Tile(TileType.Pokedoor);
                            break;

                        case 'd':
                            _map[colNumber, lineNumber] = new Tile(TileType.Door);
                            break;

                        case 'c':
                            _map[colNumber, lineNumber] = new Tile(TileType.Challenger);
                            break;

                        case 'o':
                            _map[colNumber, lineNumber] = new Tile(TileType.Pokeball);
                            break;

                        case 'h':
                            _map[colNumber, lineNumber] = new Tile(TileType.DoorH);
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

        }


        public void DrawMapUpdate()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (!(i == _player.PosX && j == _player.PosY))
                    {
                        switch(_map[i, j]._tileType)
                        {
                            case TileType.Bush:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case TileType.Tree:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;


                            case TileType.Roof:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case TileType.Wall:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case TileType.Pokedoor:
                            
                            case TileType.DoorH:
                            case TileType.Door:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case TileType.Challenger:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case TileType.Pokeball:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case TileType.Empty:
                                Console.SetCursorPosition(i * 2 + 1, j + 1);
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            default:
                                Console.Write(_map[i, j].GetString() + " ");
                                break;
                        }   
                    }
                }
            }
            Console.SetCursorPosition(0, _size+12);
        }


        public void DrawMapInit()
        {
            Console.Clear();
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
                    if (i == _player.PosY && j == _player.PosX)
                    {
                        Player.DrawPlayer();
                    }
                    else
                    {
                        switch (_map[j, i]._tileType)
                        {

                            case (TileType.Bush):
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;


                            case (TileType.Tree):
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case (TileType.Roof):
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case (TileType.Wall):
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case (TileType.Pokedoor):
                            case (TileType.DoorH):
                            case (TileType.Door):
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case (TileType.Challenger):
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case (TileType.Pokeball):
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case (TileType.Empty):
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            default:
                                Console.Write(_map[i, j].GetString() + " ");
                                break;

                        }
                    }
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

        public void ChangeMap(string mapName)
        {
            LoadMap(mapName);
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

            // level scaling
            int level = rand.Next(int.Parse(randPokemon[2]), int.Parse(randPokemon[3]));
            int scaling = level / 100;

            // stats affected
            int health = rand.Next(int.Parse(randPokemon[8]), int.Parse(randPokemon[9]));
            int defense = rand.Next(int.Parse(randPokemon[10]), int.Parse(randPokemon[11]));
            int speed = rand.Next(int.Parse(randPokemon[12]), int.Parse(randPokemon[13]));
            int strength = rand.Next(int.Parse(randPokemon[14]), int.Parse(randPokemon[15]));

            Enemy enemy = new Enemy(
                randPokemon[0],                                                                         // name
                (AttributType)int.Parse(randPokemon[1]),                                                // type
                level,                                                                                  // level
                new List<string>() { randPokemon[4], randPokemon[5], randPokemon[6], randPokemon[7] },  // capacities
                health + (health * scaling),                                                            // health
                defense + (defense * scaling),                                                          // defense
                speed + (speed * scaling),                                                              // speed
                strength + (strength * scaling));                                                       // strength

            return enemy;
        }

        public void AddToTeam(Enemy enemy)
        {
            enemy.isInTeam = true;
        }
        public bool IsEncoutering()
        {
            chance = rand.Next(0, 10);
            if (chance == 0)
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
                old.Leave(state, this);
            }
            StateList.Clear();

            StateList.Add(state);
            if (old != null)
                state.Enter(old, this);
        }

        public void PushState(BlankState state)
        {
            BlankState old = StateList.Last();
            StateList.Add(state);
            state.Enter(old, this);
            old.Pause(state, this);
        }

        public void PopState()
        {
            BlankState old = StateList.Last();
            StateList.RemoveAt(StateList.Count - 1);
            BlankState newS = StateList.Last();
            old.Leave(newS, this);
            newS.Resume(old, this);

        }

        public void AddMetPokemon(Enemy newEnemy, Game game)
        {
            bool test = true;

            foreach(var enemy in lEnemiesMeet)
            {
                if(enemy.Name == newEnemy.Name)
                {
                    test = false;
                }
            }
            if (test == true) {
                game.lEnemiesMeet.Add(newEnemy);
            }
        }

        public void OnPokeballPickUp()
        {
            if (lInTeam.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = rand.Next(0, pokemons.Count);

                    string[] randPokemon = pokemons[index];

                    // level scaling
                    int level = rand.Next(int.Parse(randPokemon[2]), int.Parse(randPokemon[3]));
                    int scaling = level / 100;

                    // stats affected
                    int health = rand.Next(int.Parse(randPokemon[8]), int.Parse(randPokemon[9]));
                    int defense = rand.Next(int.Parse(randPokemon[10]), int.Parse(randPokemon[11]));
                    int speed = rand.Next(int.Parse(randPokemon[12]), int.Parse(randPokemon[13]));
                    int strength = rand.Next(int.Parse(randPokemon[14]), int.Parse(randPokemon[15]));

                    Enemy enemy = new Enemy(
                        randPokemon[0],                                                                         // name
                        (AttributType)int.Parse(randPokemon[1]),                                                // type
                        level,                                                                                  // level
                        new List<string>() { randPokemon[4], randPokemon[5], randPokemon[6], randPokemon[7] },  // capacities
                        health + (health * scaling),                                                            // health
                        defense + (defense * scaling),                                                          // defense
                        speed + (speed * scaling),                                                              // speed
                        strength + (strength * scaling));                                                       // strength

                    enemy.isInTeam = true;

                    lInTeam.Add(enemy);
                    lEnemiesMeet.Add(enemy);
                    //
                }

                for (int i = 0; i < lInTeam.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{lInTeam[i].Name} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" has been added to the team !");
                }
            } else
            {
                Console.WriteLine("You already took your pokemons");
            }
        }
    }
}
