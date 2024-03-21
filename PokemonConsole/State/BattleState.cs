using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State
{
    internal class BattleState : BlankState
    {
        Enemy _enemyInBattle;
        public BattleState(Enemy enemy)
        {
            _enemyInBattle = enemy;
        }
        override public void Run(Game game)
        {
            Console.WriteLine(_enemyInBattle.Name);
            Console.WriteLine(_enemyInBattle.Level);
            Console.WriteLine(_enemyInBattle.Type);
            foreach(Capacity capacity in _enemyInBattle.Capacities)
            {
                Console.WriteLine(capacity.Name);
                Console.WriteLine(capacity.Type);
                Console.WriteLine(capacity.Attack);
                Console.WriteLine(capacity.Accuracy);

            }
            Console.WriteLine(_enemyInBattle.Defense);
            Console.WriteLine(_enemyInBattle.Speed);

            // temporary
            game.SetState(new OverworldState());
        }
    }
}
