using PokemonConsole.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

            // run
            game.Run();

        }
    }
}
