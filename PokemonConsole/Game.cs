using PokemonConsole.State;
using PokemonConsole.State.Menus.Sous_Menus;
using System;
using System.Collections.Generic;
using System.Linq;
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

        int chance;
        Random rand = new Random(); 
        

        public BlankState State {get => StateList.Last(); set => throw new Exception("Use setState or pushState to set the State."); }
        public List<BlankState> StateList { get => _StateList; }

        private List<Enemy> _lEnemiesMeet = new List<Enemy> { };
        public List<Enemy> lEnemiesMeet { get => lEnemiesMeet; }

        public Game(int size, Player player)
        {
            _map = new Tile[size,size];
            _size = size;
            _player = player;
            _StateList = new List<BlankState>();

            // empty map 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _map[i, j] = new Tile(TileType.Empty);
                }
            }
            
            // put player on the map 
            _map[player.PosX, player.PosY] = player;
        }

        public void DrawMap()
        {
            for(int i = _size - 1; i >= 0; i--)
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

        public void AddEnemy(int posX, int posY, Enemy enemy)
        {
            _map[posX, posY] = enemy;
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
    }
}
