namespace PokemonConsole.State.Menus.Sous_Menus
{
    public class PokedexState : BlankState
    {
        override public void Run(Game game)
        {
            foreach(Enemy enemy in game.lEnemiesMeet)
            {
                Console.WriteLine(enemy.Name);
            }
        }
    }
        

}
