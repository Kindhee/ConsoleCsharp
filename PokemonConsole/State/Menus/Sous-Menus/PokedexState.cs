namespace PokemonConsole.State.Menus.Sous_Menus
{
    public class PokedexState : BlankState
    {
        override public void Run(Game game)
        {
            Console.WriteLine("Press e to go back to the Menu");

            foreach(var enemy in game.lEnemiesMeet)
            {
                Console.Write(enemy.Value.Name);
                Console.Write(" | Type : " + enemy.Value.Type);
                Console.Write(" | Capacities : " + enemy.Value.Capacities[0].Name + 
                                            "; " + enemy.Value.Capacities[1].Name + 
                                            "; " + enemy.Value.Capacities[2].Name + 
                                            "; " + enemy.Value.Capacities[3].Name);
                Console.WriteLine();
            }

            char keyPressed = Console.ReadKey(true).KeyChar;
            
            if(keyPressed == 'e')
            {
                game.SetState(new MenuOverwold());
            }
        }
    }
        

}
