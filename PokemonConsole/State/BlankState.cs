using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State
{
    public class BlankState
    {
        private string _name = "BLANK";

        public string Name { get { return _name; } }
        public virtual void Enter(BlankState oldState, Game game)
        {

        }

        public virtual void Leave(BlankState newState, Game game)
        {

        }

        public virtual void Run(Game game)
        {

        }

        public virtual void HandleInput(Game game)
        {

        }

        public virtual void Pause(BlankState newState, Game game) { }

        public virtual void Resume(BlankState oldState, Game game) { }
    }
}
