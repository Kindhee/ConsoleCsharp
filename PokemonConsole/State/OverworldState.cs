using PokemonConsole.State.Menus.Sous_Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PokemonConsole.State
{
    internal class OverworldState : BlankState
    {
        private string _name = "OVERWORLD";

        public override void Enter(BlankState oldState, Game game)
        {
            base.Enter(oldState, game);
            if (oldState is MenuOverwold) return;
            if (OperatingSystem.IsWindows())
            {
                _player = new SoundPlayer("aud/forest.wav");
                _player.PlayLooping();
            }
        }

        public override void Resume(BlankState oldState, Game game)
        {
            base.Resume(oldState, game);
            if (oldState is MenuOverwold) return;
            if (OperatingSystem.IsWindows())
            {
                _player.PlayLooping();
            }
        }

        public override void Pause(BlankState newState, Game game)
        {
            base.Pause(newState, game);
            if (newState is MenuOverwold) return;
            if (OperatingSystem.IsWindows())
            {
                _player.Stop();
            }
        }

        public override void Leave(BlankState newState, Game game)
        {
            base.Pause(newState, game);
            if (newState is MenuOverwold) return;
            if (OperatingSystem.IsWindows())
            {
                _player.Stop();
            }
        }

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
                        Tile t = game._map[game._player.PosX, game._player.PosY - 1];
                        string tile = t.GetString();
                        if (tile == " " || tile == "B")
                        {
                            game._player.PosY -= 1;
                        }
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            List<Enemy> enemies = new List<Enemy>();

                            Enemy enemyToBattle = game.NewEnemy();

                            enemies.Add(enemyToBattle);

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemies));
                        }
                    } else if(game.lInTeam.Count > 0) {

                        switch (game._currentMap)
                        {
                            case "lobby":
                                // update map
                                game._currentMap = "overworld";
                                break;

                            case "overworld":
                                // update map
                                game._currentMap = "arena";
                                break;

                            case "healcenter":
                                // update map
                                game._currentMap = "forest";
                                break;
                        }

                        // place player 
                        //game._player.PosX = 10;
                        game._player.PosY = 20;

                        game.ChangeMap(game._currentMap);
                        game.DrawMapInit();
                    } else
                    {
                        Console.WriteLine("\nPickup the pokeball");
                    }
                    break;

                case 'q':
                case 'Q':

                    game._player.DirX = -1;
                    game._player.DirY = 0;

                    if (game._player.PosX - 1 >= 0)
                    {
                        Tile t = game._map[game._player.PosX - 1, game._player.PosY];
                        string tile = t.GetString();
                        if (tile == " " || tile == "B")
                        {
                            game._player.PosX -= 1;
                        }
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            List<Enemy> enemies = new List<Enemy>();

                            Enemy enemyToBattle = game.NewEnemy();

                            enemies.Add(enemyToBattle);

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemies));
                        }
                    }
                    else
                    {
                        switch (game._currentMap)
                        {
                            case "overworld":
                                // update map
                                game._currentMap = "healcenter";
                                break;

                            case "pokecenter":
                                // update map
                                game._currentMap = "overworld";
                                break;
                        }

                        game.ChangeMap(game._currentMap);
                        game.DrawMapInit();

                        // place player
                        game._player.PosX = 20;
                        //game._player.PosY = 10;
                    }
                    break;

                case 's':
                case 'S':

                    game._player.DirX = 0;
                    game._player.DirY = 1;

                    if (game._player.PosY + 1 < game._size)
                    {
                        Tile t = game._map[game._player.PosX, game._player.PosY + 1];
                        string tile = t.GetString();
                        if (tile == " " || tile == "B")
                        {
                            game._player.PosY += 1;
                        }
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            List<Enemy> enemies = new List<Enemy>();

                            Enemy enemyToBattle = game.NewEnemy();

                            enemies.Add(enemyToBattle);

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemies));
                        }
                    } else
                    {

                        switch (game._currentMap)
                        {
                            case "arena":
                                // update map
                                game._currentMap = "overworld";
                                break;

                            case "forest":
                                //update map
                                game._currentMap = "healcenter";
                                break;  
                        }

                        game.ChangeMap(game._currentMap);
                        game.DrawMapInit();

                        // place player
                        //game._player.PosX = 10;
                        game._player.PosY = 0;

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
                        if (tile == " " || tile == "B")
                        {
                            game._player.PosX += 1;
                        }
                        if (tile == "B" && game.IsEncoutering() == true)
                        {
                            List<Enemy> enemies = new List<Enemy>();

                            Enemy enemyToBattle = game.NewEnemy();

                            enemies.Add(enemyToBattle);

                            game.AddMetPokemon(enemyToBattle, game);

                            Console.Clear();
                            game.PushState(new BattleState(enemies));
                        }
                    } else
                    {

                        switch (game._currentMap)
                        {
                            case "healcenter":
                                // update map
                                game._currentMap = "overworld";
                                break;

                            case "overworld":
                                // update map
                                game._currentMap = "pokecenter";
                                break;
                        }

                        game.ChangeMap(game._currentMap);
                        game.DrawMapInit();

                        // place player
                        game._player.PosX = 0;
                        //game._player.PosY = 10;

                    }
                    break;

                case 'e':
                    game.PushState(new MenuOverwold());
                    break;

                case 'a':

                    Tile tDir = game._map[game._player.PosX + game._player.DirX, game._player.PosY + game._player.DirY];
                    string tileDir = tDir.GetString();

                    switch (tileDir)
                    {
                        case "P":

                            game.PushState(new PokeCenterState());
                            break;

                        case "D":

                            foreach (var pokemon in game.lInTeam)
                            {
                                Console.WriteLine("Healed your pokemons !");
                                pokemon.Health = pokemon.MaxHealth;
                            }
                            break;

                        case "H":
                            Console.WriteLine("\nNobody is in the house...");
                            break;  

                        case "C":

                            Challenger challenger = new Challenger(3);
                            game.PushState(new BattleState(challenger.ChallengerTeam));
                            break;

                        case "O": 
                            game.OnPokeballPickUp();
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }

            
            // update player pos on the map 

            Console.SetCursorPosition(game._player.LastPosX * 2 + 1, game._player.LastPosY + 1);
            Console.Write(" ");
            Console.SetCursorPosition(game._player.PosX * 2 + 1, game._player.PosY + 1);
            Player.DrawPlayer();
        }
    }
}
