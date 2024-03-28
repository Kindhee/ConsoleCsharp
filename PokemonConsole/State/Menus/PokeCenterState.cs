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
        Enemy _firstSelect;
        Enemy _secondSelect;
        int _firstSelectColumn = -1;
        int _secondSelectColumn = -1;
        int _firstSelectIndex = -1;
        int _secondSelectIndex = -1;
        override public void Run(Game game)
        {

            ConsoleKeyInfo key;

            int column = 1;
            int option = 0;
            int i;
            var decorator = " ";
            var decoratorNav = " \u001b[32m";
            var decoratorSelect = " \u001b[33m";
            bool isSelected = false;

            Console.Clear();
            Console.WriteLine("Press e to go back to the Menu\n");

           /* Console.WriteLine($"{(option == 1 ? decorator : " ")}Game\u001b[0m");
            Console.WriteLine($"{(option == 2 ? decorator : " ")}Exit\u001b[0m");*/

            Console.WriteLine("Your team :\n");


            while (!isSelected)
            {
                Console.SetCursorPosition(0, 1);
                i = 0;
                foreach (var pokemonInTeam in game.lInTeam)
                {
                    Console.SetCursorPosition(0, i + 3);
                    if ( column == 1 && option == i)
                    {
                        decorator = decoratorNav;
                    }
                    else
                    {
                        if (_firstSelectColumn == 1 && _firstSelectIndex == i)
                        {
                            decorator = decoratorSelect;
                        }
                        else
                        {
                            decorator = " ";
                        }
                    }
                    Console.WriteLine($"{decorator}" + pokemonInTeam.Name + "\u001b[0m");
                    i++;
                }

                if (game.lPokemonCatch.Count > 0)
                {
                    Console.SetCursorPosition(20, 2);
                    Console.Write("Your Pokemons :\n");
                    i = 0;
                    foreach (var pokemonCatch in game.lPokemonCatch)
                    {
                        if (column == 2 && option == i)
                        {
                            decorator = decoratorNav;
                        }
                        else
                        {
                            if (_firstSelectColumn == 2 && _firstSelectIndex == i)
                            {
                                decorator = decoratorSelect;
                            }
                            else
                            {
                                decorator = " ";
                            }
                        }
                        Console.SetCursorPosition(20, i + 3);
                        Console.WriteLine($"{decorator}" + pokemonCatch.Name + "\u001b[0m");
                        i++;
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
                        option = column == 1 ? option == 0 ? game.lInTeam.Count - 1 : option - 1 : option == 0 ? game.lPokemonCatch.Count - 1 : option - 1;
                        break;

                    case ConsoleKey.S:
                        option = column == 1 ? option == game.lInTeam.Count - 1 ? 0 : option + 1 : option == game.lPokemonCatch.Count - 1 ? 0 : option + 1;
                        break;

                    case ConsoleKey.D:
                        column = column == 2 ? 1 : 2;
                        option = 0;
                        break;

                    case ConsoleKey.Q:
                        column = column == 1 ? 2 : 1;
                        option = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (_firstSelect == null)
                        {
                            _firstSelect = column == 1 ? game.lInTeam[option] : game.lPokemonCatch[option];
                            _firstSelectIndex = option;
                            _firstSelectColumn = column;
                        }
                        else
                        {
                            _secondSelect = column == 1 ? game.lInTeam[option] : game.lPokemonCatch[option];
                            _secondSelectIndex = option;
                            _secondSelectColumn = column;
                            isSelected = true;
                        }
                        break;
                }
            }
            if (_firstSelect != _secondSelect)
            {
                if (_firstSelect.isInTeam)
                {
                    if (_secondSelect.isInTeam)
                    {
                        game.lInTeam[_firstSelectIndex] = _secondSelect;
                        game.lInTeam[_secondSelectIndex] = _firstSelect;
                    }
                    else
                    {
                        _firstSelect.isInTeam = false;
                        _secondSelect.isInTeam = true;
                        game.lInTeam[_firstSelectIndex] = _secondSelect;
                        game.lPokemonCatch[_secondSelectIndex] = _firstSelect;
                    }
                }
                else
                {
                    if (_secondSelect.isInTeam)
                    {
                        _firstSelect.isInTeam = true;
                        _secondSelect.isInTeam = false;
                        game.lPokemonCatch[_firstSelectIndex] = _secondSelect;
                        game.lInTeam[_secondSelectIndex] = _firstSelect;
                    }
                    else
                    {
                        game.lPokemonCatch[_firstSelectIndex] = _secondSelect;
                        game.lPokemonCatch[_secondSelectIndex] = _firstSelect;
                    }
                }
            }
            _firstSelectIndex = -1;
            _secondSelectIndex = -1;
            _firstSelectColumn = -1;
            _secondSelectColumn = -1;
            _firstSelect = null;
            _secondSelect = null;
            isSelected = false;


        }
    }
}

