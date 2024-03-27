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
        int _pokemonOnField;
        int _enemyOnField;

        string _currentTurn;
        bool _combat;

        int _enemyRandom;

        int _turnPlayed;

        Random _rand;

        List<Enemy> _enemyTeam;

        public BattleState(List<Enemy> enemies)
        {
            _enemyTeam = enemies;

            _pokemonOnField = 0;
            _enemyOnField = 0;

            _currentTurn = "You";
            _combat = false;

            _turnPlayed = 0;

            _rand = new Random();

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

            Console.WriteLine(" ");

            if (_currentTurn == "You") {
                Console.WriteLine($"{attacker.Name} uses {attack.Name} on enemy {defender.Name}");
            } else {
                Console.WriteLine($"{attacker.Name} uses {attack.Name} on your {defender.Name}");
            }

            if (miss <= attack.Accuracy) { 

                int damage = (attack.Attack + (attack.Attack * (attacker.Strength / 100))) - (attack.Attack * (defender.Defense / 100));
                defender.Health -= damage;

                Console.WriteLine($"It deals {damage} damage !");

                if (isDead(defender) == true)
                {
                    return true;
                } 
                return false;
            }
            else
            {
                if (_currentTurn == "You") {
                    Console.WriteLine($"Your {attacker.Name} missed !");
                } else {
                    Console.WriteLine($"Enemy {attacker.Name} missed !");
                }
            }
            return false;
        }
        override public void Run(Game game)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = " \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            bool test = false;

            foreach (var pokemon in game.lInTeam)
            {
                if(pokemon.Health > 0)
                {
                    test = true;
                }
            }

            if (test == false) {

                Console.WriteLine("You don't have any Pokemon that can fight");
                Console.WriteLine("Go heal them");

                game.SetState(new OverworldState());
                Console.ReadKey();
                game.DrawMapInit();

                _combat = true;
            }

            while (_combat == false)
            {
                Console.ReadKey(true);
                Console.Clear();

                _turnPlayed = 0;

                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);

                    Console.WriteLine($"\nYour {game.lInTeam[_pokemonOnField].Name} pokemon hp : {game.lInTeam[_pokemonOnField].Health}\n");
                    Console.WriteLine($"\nEnemy {_enemyTeam[_enemyOnField].Name} pokemon hp : {_enemyTeam[_enemyOnField].Health}\n\n");

                    Console.WriteLine("Use z and s to navigate and press Enter/Return to select:");

                    Console.WriteLine($"{(option == 0 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[0].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[0].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[0].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 1 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[1].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[1].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[1].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 2 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[2].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[2].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[2].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 3 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[3].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[3].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[3].Accuracy}\u001b[0m");


                    Console.WriteLine($"{(option == 4 ? decorator : " ")}Run\u001b[0m");

                    key = Console.ReadKey(true);

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

                if(option == 4)
                {
                    _currentTurn = "Run";
                    _combat = true;
                    game.SetState(new OverworldState());
                    break;
                }

                if(game.lInTeam[_pokemonOnField].Speed < _enemyTeam[_enemyOnField].Speed)
                {
                    _currentTurn = "Enemy";
                }

                while (_turnPlayed != 2)
                {
                    if (_currentTurn == "You")
                    {
                        if (Attack(game.lInTeam[_pokemonOnField], game.lInTeam[_pokemonOnField].Capacities[option], _enemyTeam[_enemyOnField]) == true)
                        {
                            test = false;

                            for (int index = 0; index < _enemyTeam.Count; index++)
                            {
                                if (_enemyTeam[index].Health > 0)
                                {
                                    Console.WriteLine("");

                                    Console.WriteLine($"Enemy {_enemyTeam[_enemyOnField].Name} fainted");

                                    _enemyOnField = index;

                                    Console.WriteLine($"They throw {_enemyTeam[_enemyOnField].Name} in combat");

                                    test = true;
                                    _turnPlayed = 2;
                                    break;
                                }
                            }

                            if (test == false)
                            {
                                _turnPlayed = 2;
                                _combat = true;
                                break;
                            }
                        }
                        else
                        {
                            isSelected = false;
                            _turnPlayed += 1;
                            _currentTurn = "Enemy";
                        }
                    }
                    else if (_currentTurn == "Enemy")
                    {
                        _enemyRandom = _rand.Next(0, 4);
                        if (Attack(_enemyTeam[_enemyOnField], _enemyTeam[_enemyOnField].Capacities[_enemyRandom], game.lInTeam[_pokemonOnField]) == true)
                        {
                            test = false;

                            for(int index = 0; index < game.lInTeam.Count; index++)
                            {
                                if (game.lInTeam[index].Health > 0)
                                {
                                    Console.WriteLine("");

                                    Console.WriteLine($"Your {game.lInTeam[_pokemonOnField].Name} fainted");

                                    _pokemonOnField = index;

                                    Console.WriteLine($"Go {game.lInTeam[_pokemonOnField].Name}");

                                    test = true;
                                    _turnPlayed = 2;
                                    break;
                                }
                            }

                            if(test == false) {
                                _turnPlayed = 2;
                                _combat = true;
                                break;
                            }
                        }
                        else
                        {
                            _turnPlayed += 1;
                            _currentTurn = "You";
                        }
                    }
                }
            }

            Console.WriteLine(" ");

            // end of combat
            switch (_currentTurn)
            {
                case "You":
                    Console.WriteLine("You won !\n");

                    game.lInTeam[_pokemonOnField].Level += _enemyTeam[_enemyOnField].Reward;
                    Console.WriteLine($"Your {game.lInTeam[_pokemonOnField].Name} gained {_enemyTeam[_enemyOnField].Reward} level !");
                    Console.WriteLine($"Your {game.lInTeam[_pokemonOnField].Name} is now level {game.lInTeam[_pokemonOnField].Level}");

                    break;

                case "Enemy":
                    Console.WriteLine("Your Pokemon fainted");
                    break;

                case "Run":
                    Console.WriteLine("You ran");
                    break;
            }

            Console.WriteLine("End of combat");
            game.SetState(new OverworldState());
            Console.ReadKey();
            game.DrawMapInit();
        }
    }
}