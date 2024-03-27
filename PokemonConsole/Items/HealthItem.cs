using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.Items
{
    internal class HealthItem : Item
    {
        private int _healAmount = 42;

        public HealthItem(string name, string desc, bool isKeyItem, int healAmount, int price=100, int sell = -0xfffffff) : base(name, desc, isKeyItem, price, sell)
        {
            _healAmount = healAmount;
        }

        public override void onOverWorldUse(Game game)
        {
            if (game.SelectedPKM == null)
            {
                game.PushState(new State.Menus.Sous_Menus.PokeSelectScreen());
                while (game.SelectedPKM == null) {
                    game.StateList.Last().Run(game);
                }
                game.SelectedPKM.Health += _healAmount;
                while (game.SelectedPKM.Health > game.SelectedPKM.MaxHealth) {
                    game.SelectedPKM.Health -= 1;
                }
                base.onOverWorldUse(game);
                game.SelectedPKM = null;
            }
        }
    }
}
