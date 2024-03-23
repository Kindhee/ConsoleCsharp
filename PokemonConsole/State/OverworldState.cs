using PokemonConsole.State.Menus.Sous_Menus;
using System;
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
            List<Tile> bushTiles = new List<Tile>(); 

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

                    game._player.DirX = 0;
                    game._player.DirY = -1;

                    if (game._player.PosY - 1 >= 0)
                    {
                        Tile t = game._map[game._player.PosX, game._player.PosY-1];
                        string tile = t.GetString();
                        if (tile != "T")
                        {
                            game._player.PosY -= 1;
                        }
                        if (tile == "B")
                        {
                            bushTiles.Add(t);

                            if (game.IsEncoutering() == true)
                            {
                                Enemy enemyToBattle = game.NewEnemy();

                                game.AddMetPokemon(enemyToBattle, game);

                                Console.Clear();
                                game.PushState(new BattleState(enemyToBattle));
                            }
                        }
                    }

                    break;

                case 'q':

                    game._player.DirX = -1;
                    game._player.DirY = 0;

                    if (game._player.PosX - 1 > 0)
                    {
                        Tile t = game._map[game._player.PosX - 1, game._player.PosY];
                        string tile = t.GetString();
                        if (tile != "T")
                        {
                            game._player.PosX -= 1;
                        }
                        if (tile == "B")
                        {
                            bushTiles.Add(t);

                            if (game.IsEncoutering() == true)
                            {
                                Enemy enemyToBattle = game.NewEnemy();

                                game.AddMetPokemon(enemyToBattle, game);

                                Console.Clear();
                                game.PushState(new BattleState(enemyToBattle));
                            }
                        }
                    }

                    break;

                case 's':


                    game._player.DirX = 0;
                    game._player.DirY = 1;

                    if (game._player.PosY + 1 < game._size)
                    {
                        Tile t = game._map[game._player.PosX, game._player.PosY +1 ];
                        string tile = t.GetString();
                        if (tile != "T")
                        {
                            game._player.PosY += 1;
                        }
                        if (tile == "B")
                        {
                            bushTiles.Add(t);

                            if (game.IsEncoutering() == true)
                            {
                                Enemy enemyToBattle = game.NewEnemy();

                                game.AddMetPokemon(enemyToBattle, game);

                                Console.Clear();
                                game.PushState(new BattleState(enemyToBattle));
                            }
                        }
                    }
                    break;

                case 'd':

                    
                    game._player.DirX = 1;
                    game._player.DirY = 0;

                    if (game._player.PosX + 1 < game._size)
                    {
                        Tile t = game._map[game._player.PosX + 1, game._player.PosY];
                        string tile = t.GetString();
                        if (tile != "T")
                        {
                            game._player.PosX += 1;
                        }
                        if (tile == "B")
                        {
                            bushTiles.Add(t);

                            if (game.IsEncoutering() == true)
                            {
                                Enemy enemyToBattle = game.NewEnemy();

                                game.AddMetPokemon(enemyToBattle, game);

                                Console.Clear();
                                game.PushState(new BattleState(enemyToBattle));
                            }
                        }
                    }
                    break;

                case 'e':
                    game.PushState(new MenuOverwold());
                    break;

                default:
                    break;
            }

            game._map[game._player.LastPosX, game._player.LastPosY] = new Tile(TileType.Empty);

            // update player pos on the map 
            game._map[game._player.LastPosX, game._player.LastPosY] = new Tile(TileType.Empty);
            game._map[game._player.PosX, game._player.PosY] = new Tile(TileType.Player);

            /* _map[_player._lastPosX, _player._lastPosY] = new Tile(TileType.Empty);
            _map[_player._posX, _player._posY] = new Tile(TileType.Player);*/
        }
    }
}
