using PokemonConsole.State.Menus.Sous_Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State
{
    public class MenuOverwold : BlankState
    {

        override public void Run(Game game)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse z and s to navigate and press Enter to select:");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = " \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : " ")}Return to game\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : " ")}Team\u001b[0m");
                Console.WriteLine($"{(option == 3 ? decorator : " ")}Inventory\u001b[0m");
                Console.WriteLine($"{(option == 4 ? decorator : " ")}Pokedex\u001b[0m");
                Console.WriteLine($"{(option == 5 ? decorator : " ")}Exit\u001b[0m");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Z:
                        option = option == 1 ? 5 : option - 1;
                        break;

                    case ConsoleKey.S:
                        option = option == 5 ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

           switch(option)
            {
                case 1:
                    Console.Clear();
                    game.DrawMapInit();
                    game.SetState(new OverworldState());
                    break;

                case 2:
                    Console.Clear();
                    game.SetState(new TeamState());
                    break;

                case 3:
                    Console.Clear();
                    game.PushState(new InventoryState());
                    break; 
               
                case 4:
                    Console.Clear();
                    game.SetState(new PokedexState());
                    break; 
                
                case 5:
                    Console.Clear();
                    game.SetState(new Menu());
                    break;
            }
        }
    }
}
