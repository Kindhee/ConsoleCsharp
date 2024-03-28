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

        TypeManager _typeManager;

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
            _typeManager = new TypeManager();

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{attacker.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"uses {attack.Name} on enemy {defender.Name}");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{attacker.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"uses {attack.Name} on your {defender.Name}");
            }


            if (miss <= attack.Accuracy) {

                double d = (((attack.Attack + (attack.Attack * (attacker.Strength / 100f))) - (attack.Attack * (defender.Defense / 100f))));
                int damage = (int)(d  * _typeManager.GetRatioType(attack.Type, defender.Type));
                defender.Health -= damage;

                string effectiveness = "";

                switch(_typeManager.GetRatioType(attack.Type, defender.Type))
                {
                    case 0.5:
                        effectiveness = "It's not very effective...";
                        break;

                    case 1.0:
                        effectiveness = "It's effective.";
                        break;

                    case 2.0:
                        effectiveness = "It's very effective !";
                        break;

                }

                Console.WriteLine($"{effectiveness} It deals {damage} damage !");

                if (isDead(defender) == true)
                {
                    return true;
                } 
                return false;
            }
            else
            {
                if (_currentTurn == "You") {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{attacker.Name} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"missed !");
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{attacker.Name} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" missed !");
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

            bool haveCapture = false;
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

                    // Your Pokemon
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{game.lInTeam[_pokemonOnField].Name} ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"| HP : {game.lInTeam[_pokemonOnField].Health} | Type : {game.lInTeam[_pokemonOnField].Type}\n");

                    // Enemy Pokemon

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_enemyTeam[_enemyOnField].Name} ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"| HP : {_enemyTeam[_enemyOnField].Health} | Type : {_enemyTeam[_enemyOnField].Type}\n\n");

                    Console.WriteLine("Use z and s to navigate and press Enter/Return to select your capacity:\n");

                    Console.WriteLine($"{(option == 0 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[0].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[0].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[0].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 1 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[1].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[1].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[1].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 2 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[2].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[2].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[2].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 3 ? decorator : " ")}{game.lInTeam[_pokemonOnField].Capacities[3].Name} | Attack : {game.lInTeam[_pokemonOnField].Capacities[3].Attack} | Accuracy : {game.lInTeam[_pokemonOnField].Capacities[3].Accuracy}\u001b[0m");

                    Console.WriteLine($"{(option == 4 ? decorator : " ")}Try to capture\u001b[0m");

                    Console.WriteLine($"{(option == 5 ? decorator : " ")}Run\u001b[0m");

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.Z:
                            option = option == 0 ? 5 : option - 1;
                            break;

                        case ConsoleKey.S:
                            option = option == 5 ? 0 : option + 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                if(option == 5)
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
                        if (option == 4)
                        {
                            if (_enemyTeam.Count != 1)
                            {
                                Console.WriteLine("Can't capture trainer's pokemon");
                                isSelected = false;
                                _turnPlayed += 1;
                                _currentTurn = "Enemy";
                            }
                            else
                            {
                                if (_rand.Next(0, 100) < 0 + _enemyTeam[_enemyOnField].Health)
                                {
                                    haveCapture = !haveCapture;
                                }

                                if (haveCapture)
                                {
                                    if (game.lInTeam.Count >= 6)
                                    {
                                        Console.WriteLine("Your team is full");
                                        game.lPokemonCatch.Add(_enemyTeam[_enemyOnField]);

                                    }
                                    else
                                    {
                                        game.lInTeam.Add(_enemyTeam[_enemyOnField]);
                                    }
                                    Console.WriteLine("\nCapture succeed");
                                    _enemyTeam[_enemyOnField].isInTeam = true;
                                    _turnPlayed += 1;
                                    _combat = true;
                                    _currentTurn = "Enemy";
                                }
                                else
                                {
                                    Console.WriteLine("\nCapture failed");
                                    isSelected = false;
                                    _turnPlayed += 1;
                                    _currentTurn = "Enemy";
                                }
                            }
                        }
                        else if (Attack(game.lInTeam[_pokemonOnField], game.lInTeam[_pokemonOnField].Capacities[option], _enemyTeam[_enemyOnField]) == true)
                        {
                            test = false;

                            for (int index = 0; index < _enemyTeam.Count; index++)
                            {
                                if (_enemyTeam[index].Health > 0)
                                {
                                    Console.WriteLine("");

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write($"{_enemyTeam[_enemyOnField].Name} ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"fainted");

                                    _enemyOnField = index;

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write($"{_enemyTeam[_enemyOnField].Name} ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"is now up !");

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

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write($"{game.lInTeam[_pokemonOnField].Name} ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"fainted");


                                    _pokemonOnField = index;

                                    Console.Write($"Go ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"{game.lInTeam[_pokemonOnField].Name}");
                                    Console.ForegroundColor = ConsoleColor.White;

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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You won !\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    game.lInTeam[_pokemonOnField].Level += _enemyTeam[_enemyOnField].Reward;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{game.lInTeam[_pokemonOnField].Name} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"gained {_enemyTeam[_enemyOnField].Reward} level !");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{game.lInTeam[_pokemonOnField].Name} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"is now level {game.lInTeam[_pokemonOnField].Level}");

                    break;

                case "Enemy":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your Pokemon fainted");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "Run":
                    Console.WriteLine("You ran");
                    break;

                case "Capture":
                    break;
            }

            Console.WriteLine("End of combat");
            game.SetState(new OverworldState());
            Console.ReadKey();
            game.DrawMapInit();
        }
    }
}