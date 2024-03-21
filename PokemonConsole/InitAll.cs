using PokemonConsole.State.Menus.Sous_Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class InitAll
    {
        Player _player;

        Tree _tree;
        Bush _bush;

        public void Init() {

            // only player
            _player = new Player();

            // generic can be used multiple times
            _tree = new Tree();
            _bush = new Bush();

        }

        // get / set
        public Player player { get => _player; set => _player = value; }
        public Tree tree { get => _tree; set => _tree = value; }
        public Bush bush { get => _bush; set => _bush = value; }
    }
}


