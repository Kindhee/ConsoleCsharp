using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State
{
    public class Menu : BlankState
    { 

        override public void Run(Game game)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse z and s to navigate and press Enter/Return to select:");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = " \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : " ")}Game\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : " ")}Exit\u001b[0m");

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.Z:
                        option = option == 1 ? 2 : option - 1;
                        break;

                    case ConsoleKey.S:
                        option = option == 2 ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            if (option == 1)
            {
                Console.Clear();
                game.DrawMap();
                game.SetState(new OverworldState());
            } 
            else if (option == 2)
            {
                // quit 
            }
        }
    }
}
