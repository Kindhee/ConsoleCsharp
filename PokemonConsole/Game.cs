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

        public Game(int size, Player player)
        {
            _map = new Tile[size,size];
            _size = size;
            _player = player;

            // empty map 
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _map[i, j] = new Tile(TileType.Empty);
                }
            }
            
            // put player on the map 
            _map[player._posX, player._posY] = player;
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

                DrawMap();

                // get key pressed
                char keyPressed = Console.ReadKey().KeyChar;

                // get last position of player
                _player._lastPosX = _player._posX;
                _player._lastPosY = _player._posY;

                switch (keyPressed) 
                {
                    case 'z':
                        if (_player._posY + 1 < _size && _map[_player._posX, _player._posY + 1].GetString() != "T") { _player._posY += 1; }
                        break;

                    case 'q':
                        if (_player._posX - 1 > 0 && _map[_player._posX - 1, _player._posY].GetString() != "T") { _player._posX -= 1; }
                        break;

                    case 's':
                        if (_player._posY - 1 > 0 && _map[_player._posX, _player._posY - 1].GetString() != "T") { _player._posY -= 1; }
                        break;

                    case 'd':
                        if (_player._posX + 1 < _size && _map[_player._posX + 1, _player._posY].GetString() != "T") { _player._posX += 1; }
                        break;

                    default : 
                        break;
                }

                // update player pos on the map 
                _map[_player._lastPosX, _player._lastPosY] = new Tile(TileType.Empty);
                _map[_player._posX, _player._posY] = new Tile(TileType.Player);

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
    }
}
