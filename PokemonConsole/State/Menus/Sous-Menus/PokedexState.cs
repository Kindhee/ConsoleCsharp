namespace PokemonConsole.State.Menus.Sous_Menus
{
    public class PokedexState : BlankState
    {
        override public void Run(Game game)
        {
            Console.WriteLine("Press e to go back to the Menu\n");

            foreach(var enemy in game.lEnemiesMeet)
            {
                Console.Write(enemy.Name);
                Console.Write(" | Type : " + enemy.Type);
                Console.Write(" | Capacities : " + enemy.Capacities[0].Name + 
                                            "; " + enemy.Capacities[1].Name + 
                                            "; " + enemy.Capacities[2].Name + 
                                            "; " + enemy.Capacities[3].Name);
                Console.WriteLine("\n");
            }

            char keyPressed = Console.ReadKey(true).KeyChar;
            
            if(keyPressed == 'e')
            {
                game.PushState(new MenuOverwold());
            }
        }
    }
        

}
