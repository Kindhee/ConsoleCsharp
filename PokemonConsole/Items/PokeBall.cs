using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.Items
{
    public class PokeBall : Item
    {
        float _catchMultiplier = 0.2f;

        public PokeBall(string name, string desc, float catchMultiplier, int price=100, int sell=-0xfffffff) : base(name, desc, false, price, sell)
        {
            _catchMultiplier = catchMultiplier;
        }

        public float GetCatchMultiplier()
        {
            return _catchMultiplier;
        }
    }
}
