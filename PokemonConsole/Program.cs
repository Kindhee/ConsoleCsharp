using PokemonConsole.State;
using PokemonConsole.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class Program
    {
        static void Main(string[] args)
        {

            // define entities 
            Player playerOne = new Player(1, 10, 10, 10, 10, 10);

            Enemy enemyOne = new Enemy(1, AttributType.Fire, 10, 10, 10, 10, 10);

            Tree tree = new Tree();

            // game - we define the size of the map here
            Game game = new Game(20, playerOne);

            game.SetState(new OverworldState());

            // add entities other than player 
            game.AddEnemy(1, 2, enemyOne);

            game.AddTree(3, 7, tree);

            // run
            game.Run();

        }
    }
}
