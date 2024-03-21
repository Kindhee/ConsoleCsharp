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

        private Dictionary<string, Enemy> _lEnemiesMeet = new Dictionary<string, Enemy>();
        public Dictionary<string, Enemy> lEnemiesMeet { get => _lEnemiesMeet; }

        public Game(int size, Player player)
        {
            _map = new Tile[size,size];
            _size = size;
            _player = player;
            _StateList = new List<BlankState>();



            // generic can be used multiple times
            List<Enemy> _lEnemies = new List<Enemy>();

            Tree _tree = new Tree();

            Capacity _bite = new Capacity("Bite", AttributType.Fire, 5, 100);
            Capacity _stomp = new Capacity("Stomp", AttributType.Fire, 10, 90);

            Capacity _firePunch = new Capacity("Fire Punch", AttributType.Fire, 15, 95);
            Capacity _flameThrower = new Capacity("Flame Thrower", AttributType.Fire, 40, 60);

            Capacity _waterGun = new Capacity("Water Gun", AttributType.Water, 20, 80);
            Capacity _jetPunch = new Capacity("Jet Punch", AttributType.Water, 30, 70);

            Capacity _leafBlade = new Capacity("Leaf Blade", AttributType.Plant, 25, 75);
            Capacity _bulletSeed = new Capacity("Bullet Speed", AttributType.Plant, 15, 90);



            // move sets 
            List<Capacity> _capacitiesFire = new List<Capacity>() { _firePunch, _flameThrower, _bite, _stomp };
            List<Capacity> _capacitiesWater = new List<Capacity>() { _waterGun, _jetPunch, _bite, _stomp };
            List<Capacity> _capacitiesPlant = new List<Capacity>() { _leafBlade, _bulletSeed, _bite, _stomp };


            // enemies
            _lEnemies.Add(new Enemy("Charmander", 10, AttributType.Fire, _capacitiesFire, 10, 5, 25));
            _lEnemies.Add(new Enemy("Squirtle", 10, AttributType.Water, _capacitiesWater, 15, 10, 15));
            _lEnemies.Add(new Enemy("Bulbasaur", 10, AttributType.Plant, _capacitiesPlant, 20, 15, 5));



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
                            AddEnemy(colNumber, lineNumber, _lEnemies[0]);
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
            chance = 1;// rand.Next(0, 11);
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
