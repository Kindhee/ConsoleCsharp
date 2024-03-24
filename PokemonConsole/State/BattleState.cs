using PokemonConsole.State;
using PokemonConsole;
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
        Random _rand;
        int _pokemonOnField;
        bool _combat;

        public BattleState(Enemy enemy)
        {
            _enemyInBattle = enemy;
            _rand = new Random();
            _pokemonOnField = 0;
            _combat = false;
        }

        bool isDead(Enemy enemy)
        {
            if (enemy.Health <= 0) {
                return true;
            }
            return false;
        }
        bool Attack(Enemy attacker, Capacity attack, Enemy defender)
        {
            int miss = _rand.Next(0,100);

            if (miss <= attack.Accuracy)
            {
                Console.WriteLine(attack.Name);

                defender.Health -= attack.Attack - (attack.Attack * (defender.Defense / 100));

                Console.WriteLine(attack.Attack - (attack.Attack * (defender.Defense / 100)));

                if(isDead(defender) == true)
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Attack Missed !");
            }
            return false;
        }

        override public void Run(Game game)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse z and s to navigate and press Enter/Return to select:");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = " \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (_combat == false)
            {
                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);

                    Console.WriteLine(_enemyInBattle.Health);

                    Console.WriteLine($"{(option == 0 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[0].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[0].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[0].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 1 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[1].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[1].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[1].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 2 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[2].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[2].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[2].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 3 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[3].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[3].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[3].Accuracy}\u001b[0m");


                    Console.WriteLine($"{(option == 4 ? decorator : " ")}Run\u001b[0m");


                    key = Console.ReadKey(false);

                    switch (key.Key)
                    {
                        case ConsoleKey.Z:
                            option = option == 0 ? 4 : option - 1;
                            break;

                        case ConsoleKey.S:
                            option = option == 4 ? 0 : option + 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                switch(option)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        if(Attack(game.lInTeam[_pokemonOnField], game.lInTeam[_pokemonOnField].Capacities[option], _enemyInBattle) == true)
                        {
                            _combat = true;
                        } else
                        {
                            isSelected = false;
                        }
                        break;

                    case 4:
                        game.SetState(new OverworldState());
                        break;
                }
            }
            // end of combat
            Console.WriteLine("End of combat");
            game.SetState(new OverworldState());
        }
    }
}


/*
Console.WriteLine(_enemyInBattle.Health);

Attack(game.lInTeam[0], game.lInTeam[0].Capacities[0], _enemyInBattle);

Console.WriteLine(_enemyInBattle.Health);

char keyPressed = Console.ReadKey().KeyChar;

// temporary
if (keyPressed == 'e')
{
    game.SetState(new OverworldState());
}*/