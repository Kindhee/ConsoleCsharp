using PokemonConsole.State;
using PokemonConsole.State.Menus.Sous_Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public  class Game
    {
        public Tile[,] _map;
        public int _size;
        public Player _player;
        private BlankState _State;
        private List<BlankState> _StateList;
        List<string[]> pokemons = Utils.GetListFromFile("Json/Pokemons.txt");

        int chance;
        Random rand = new Random();
        
        public BlankState State {get => StateList.Last(); set => throw new Exception("Use setState or pushState to set the State."); }
        public List<BlankState> StateList { get => _StateList; }

        private Dictionary<string, Enemy> _lEnemiesMeet = new Dictionary<string, Enemy>();
        public Dictionary<string, Enemy> lEnemiesMeet { get => _lEnemiesMeet; }

        public Game(int size, Player player)
        {
            _map = new Tile[size,size];
            _size = size;
            _player = player;
            _StateList = new List<BlankState>();

            Tree _tree = new Tree();
            Bush _bush = new Bush();

            // empty map 
            String lineRead;
            StreamReader mapTxt = new StreamReader("../../../txt/map.txt");
            lineRead = mapTxt.ReadLine();
            int lineNumber = 0;


            while (lineRead != null)
            {
                int colNumber = 0;
                foreach  (char charRead in lineRead)
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

            //



            /*for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _map[i, j] = new Tile(TileType.Empty);
                }
            }*/
            
            // put player on the map 
            _map[player.PosX, player.PosY] = player;
        }

        public void DrawMap()
        {
            for(int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_map[j, i].GetString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
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
            chance = rand.Next(0, 1);
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
