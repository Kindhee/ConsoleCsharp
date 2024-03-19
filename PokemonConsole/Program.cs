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
            InitAll init = new InitAll();
            init.Init();

            // game - we define the size of the map here
            Game game = new Game(20, init.player);

            game.SetState(new OverworldState());

            // add entities other than player 
            //game.AddEnemy(1, 1, enemyOne);

            game.AddTree(3, 7, init.tree);

            // run
            game.Run();

        }
    }
}
