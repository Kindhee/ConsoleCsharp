using PokemonConsole.State;
using PokemonConsole.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PokemonConsole
{
    public class Program
    {
        // import
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        static void Main(string[] args)
        {
            // set console for .exe
            IntPtr hConsole = GetStdHandle(-11); // Standard output handle

            uint mode;
            GetConsoleMode(hConsole, out mode);

            mode |= 0x0004; // Enable Virtual Terminal Processing / ANSI handling

            // Set the new console mode
            SetConsoleMode(hConsole, mode);

            Player _player = new Player();

            TypeManager typeManager = new TypeManager();

            // game - we define the size of the map here
            Game game = new Game(21, _player);

            game.SetState(new Menu());

            // run
            game.Run();

        }
    }
}
