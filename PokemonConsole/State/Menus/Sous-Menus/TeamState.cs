using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State.Menus.Sous_Menus
{
    public class TeamState : BlankState
    {
        override public void Run(Game game)
        {
            Console.WriteLine("Press e to go back to the Menu");
            Console.WriteLine("");

            foreach (var enemy in game.lInTeam)
            {
                if (enemy.isInTeam == true)
                {
                    Console.Write(enemy.Name);
                    Console.Write(" | Level : " + enemy.Level);
                    Console.Write(" | Health : " + enemy.Health + "/" + enemy.MaxHealth);
                    Console.WriteLine();
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
