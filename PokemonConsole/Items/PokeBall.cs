using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.Items
{
    internal class PokeBall : Item
    {
        float _catchMultiplier = 0.2f;

        public PokeBall(string name, string desc, float catchMultiplier) : base(name, desc, false)
        {
            _catchMultiplier = catchMultiplier;
        }
    }
}
