using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State.Menus.Sous_Menus
{
    
    internal class PokeCenterState : BlankState
    {
        override public void Run(Game game)
        {
            ConsoleKeyInfo key;

            int option = 1;
            int optionNumber = 1;
            var decorator = " \u001b[32m";
            bool isSelected = false;

            Console.Clear();
            Console.WriteLine("Press e to go back to the Menu");

           /* Console.WriteLine($"{(option == 1 ? decorator : " ")}Game\u001b[0m");
            Console.WriteLine($"{(option == 2 ? decorator : " ")}Exit\u001b[0m");*/

            Console.WriteLine("Your team :");


            while (!isSelected)
            {
                Console.SetCursorPosition(0, 1);

                optionNumber = 1;
                foreach (var pokemonInTeam in game.lInTeam)
                {
                    Console.SetCursorPosition(0, optionNumber +1);
                    Console.WriteLine($"{(option == optionNumber ? decorator : " ")}" + pokemonInTeam.Name + "\u001b[0m");
                    optionNumber++;
                }

                if (game.lPokemonCatch.Count > 0)
                {
                    Console.SetCursorPosition(20, 1);
                    Console.Write("Your Pokemons :");
                    optionNumber = 1;
                    foreach (var pokemonCatch in game.lPokemonCatch)
                    {
                        Console.SetCursorPosition(20, optionNumber + 2);
                        Console.WriteLine($"{(option == optionNumber ? decorator : " ")}" + pokemonCatch.Name + "\u001b[0m");
                        optionNumber++;
                    }
                }



                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        isSelected= true;
                        Console.Clear();
                        game.DrawMapInit();
                        game.PushState(new OverworldState());
                        break;

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
        }
    }
}

