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
            game.DrawMapUpdate();
        }

        public override void HandleInput(Game game)
        {

            base.HandleInput(game);

            // get key pressed
            char keyPressed = Console.ReadKey(true).KeyChar;

            // get last position of player
            game._player.LastPosX = game._player.PosX;
            game._player.LastPosY = game._player.PosY;

            switch (keyPressed)
            {
                case 'z':
                case 'Z':

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
                        if (tile == "B" && game.IsEncoutering() == true){
                                Enemy enemyToBattle = game.NewEnemy();

                                game.AddMetPokemon(enemyToBattle, game);

                                Console.Clear();
                                game.PushState(new BattleState(enemyToBattle));
                        }
                    }
                    break;

                case 'q':
                case 'Q':

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
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            Enemy enemyToBattle = game.NewEnemy();

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemyToBattle));
                        }
                    }
                    break;

                case 's':
                case 'S':

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
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            Enemy enemyToBattle = game.NewEnemy();

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemyToBattle));
                        }
                    }
                    break;

                case 'd':
                case 'D':

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
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            Enemy enemyToBattle = game.NewEnemy();

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemyToBattle));
                        }
                    }
                    break;

                case 'e':
                    game.PushState(new MenuOverwold());
                    break;

                default:
                    break;
            }

            

            // update player pos on the map 

            Console.SetCursorPosition(game._player.LastPosX * 2 + 1, game._player.LastPosY + 1);
            Console.Write(" ");
            Console.SetCursorPosition(game._player.PosX * 2 + 1, game._player.PosY + 1);
            Console.Write("P");

            /* _map[_player._lastPosX, _player._lastPosY] = new Tile(TileType.Empty);
            _map[_player._posX, _player._posY] = new Tile(TileType.Player);*/
        }
    }
}
