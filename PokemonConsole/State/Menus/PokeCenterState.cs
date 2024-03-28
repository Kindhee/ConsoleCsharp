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
            Console.Clear();
            Console.WriteLine("Press e to go back to the Menu");

           /* Console.WriteLine($"{(option == 1 ? decorator : " ")}Game\u001b[0m");
            Console.WriteLine($"{(option == 2 ? decorator : " ")}Exit\u001b[0m");*/

            Console.WriteLine("Your team :");
            foreach (var pokemonInTeam in game.lInTeam)
            {
                Console.WriteLine(pokemonInTeam.Name);
            }



            if(game.lPokemonCatch.Count > 0)
            {
                Console.SetCursorPosition(20, 1);
                Console.Write("Your Pokemons :");
                int i = 0;
                foreach (var pokemonCatch in game.lPokemonCatch)
                {
                    Console.SetCursorPosition(20, i + 2);
                    Console.WriteLine(pokemonCatch.Name);
                    i++;
                }
            }

            char keyPressed = Console.ReadKey(true).KeyChar;

            if (keyPressed == 'e')
            {
                game.PushState(new MenuOverwold());
            }
        }
    }
}
