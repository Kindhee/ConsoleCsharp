using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State.Menus.Sous_Menus
{
    internal class PokeSelectScreen : BlankState
    {
        byte index = 0;
        Enemy selection;
        private string decorator = " \u001b[32m";
        override public void Run(Game game)
        {
            Console.Clear();
            for (int i = 0; i < game.lInTeam.Count; i++)
            {
                var enemy = game.lInTeam[i];
                if (enemy.isInTeam)
                {
                    if (i == index)
                        Console.Write(decorator);
                    Console.Write(enemy.Name);
                    Console.Write(" | Level : " + enemy.Level);
                    Console.Write(" | Health : " + enemy.Health+"/"+enemy.MaxHealth);
                    Console.WriteLine("\n\u001b[0m");
                }
            }

            ConsoleKey keyPressed = Console.ReadKey(true).Key;

            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                    index -= 1;
                    if (index == 255)
                        index = 0;
                    break;
                case ConsoleKey.DownArrow:
                    index += 1;
                    if (index > game.lInTeam.Count - 1)
                        index = (byte)(game.lInTeam.Count - 1);
                    break;
                case ConsoleKey.Enter:
                    selection = game.lInTeam[index];
                    game.PopState();
                    break;
                default:
                    break;
            }
        }

        public override void Leave(BlankState newState, Game game)
        {
            base.Leave(newState, game);
            game.SelectedPKM = selection;
        }
    }
}
