using PokemonConsole.State;
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

            game.SetState(new Menu());

            // add entities other than player 
            game.AddEnemy(2, 2, init.enemyFire);
            game.AddEnemy(2, 4, init.enemyPlant);
            game.AddEnemy(2, 6, init.enemyWater);

            game.AddTree(3, 7, init.tree);

            // run
            game.Run();

        }
    }
}
