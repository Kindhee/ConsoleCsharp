using PokemonConsole.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public BlankState State {get => StateList.Last(); set => throw new Exception("Use setState or pushState to set the State."); }
        public List<BlankState> StateList { get => _StateList; }

        public Game(int size, Player player)
        {
            _map = new Tile[size,size];
            _size = size;
            _player = player;
            _StateList = new List<BlankState>();

            // empty map 
            for(int i = 0; i < size; i++)
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
            Console.Write("╔");
            for (int i = 0; i <= (_size*2)-1;  i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╗");
            for (int i = _size - 1; i >= 0; i--)
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
                Console.Clear();

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

        public void SetState(BlankState state)
        {
            BlankState old = null;
            Console.WriteLine(StateList.Count);
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
