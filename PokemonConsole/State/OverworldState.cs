﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State
{
    internal class OverworldState : BlankState
    {
        private string _name = "OVERWORLD";

        override public void Run(Game game)
        {
            base.Run(game);
            game.DrawMap();
        }

        public override void HandleInput(Game game)
        {
            base.HandleInput(game);
            // get key pressed
            char keyPressed = Console.ReadKey().KeyChar;

            // get last position of player
            game._player.LastPosX = game._player.PosX;
            game._player.LastPosY = game._player.PosY;

            /* _player._lastPosX = _player._posX;
            _player._lastPosY = _player._posY;*/

            switch (keyPressed)
            {
                case 'z':
                    if (game._player.PosY + 1 < game._size)
                    {
                        string tile = game._map[game._player.PosX, game._player.PosY + 1].GetString();
                        if (tile != "T")
                        {
                            game._player.PosY += 1;
                        }
                        if (tile == "E")
                        {
                            game.PushState(new BattleState());
                        }
                    }

                    break;

                case 'q':
                    if (game._player.PosY - 1 > 0)
                    {
                        string tile = game._map[game._player.PosX - 1, game._player.PosY].GetString();
                        if (tile != "T")
                        {
                            game._player.PosX -= 1;
                        }
                        if (tile == "E")
                        {
                            game.PushState(new BattleState());
                        }
                    }

                    break;

                case 's':
                    if (game._player.PosY - 1 > 0)
                    {
                        string tile = game._map[game._player.PosX, game._player.PosY - 1].GetString();
                        if (tile != "T")
                        {
                            game._player.PosY -= 1;
                        }
                        if (tile == "E")
                        {
                            game.PushState(new BattleState());
                        }
                    }
                    break;

                case 'd':
                    if (game._player.PosX + 1 < game._size)
                    {
                        string tile = game._map[game._player.PosX + 1, game._player.PosY].GetString();
                        if (tile != "T")
                        {
                            game._player.PosX += 1;
                        }
                        if (tile == "E")
                        {
                            game.PushState(new BattleState());
                        }
                    }
                    break;

                default:
                    break;
            }

            // update player pos on the map 
            game._map[game._player.LastPosX, game._player.LastPosY] = new Tile(TileType.Empty);
            game._map[game._player.PosX, game._player.PosY] = new Tile(TileType.Player);

            /* _map[_player._lastPosX, _player._lastPosY] = new Tile(TileType.Empty);
            _map[_player._posX, _player._posY] = new Tile(TileType.Player);*/
        }
    }
}
