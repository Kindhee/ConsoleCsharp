﻿using PokemonConsole.State;
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
        int _pokemonOnField;

        string _currentTurn;
        bool _combat;

        int _enemyRandom;

        Random _rand;


        public BattleState(Enemy enemy)
        {
            _enemyInBattle = enemy;
            _pokemonOnField = 0;

            _currentTurn = "You";
            _combat = false;

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

            if (_currentTurn == "You") {
                Console.WriteLine($"{attacker.Name} uses {attack.Name} on enemy {defender.Name}");
            } else {
                Console.WriteLine($"{attacker.Name} uses {attack.Name} on your {defender.Name}");
            }

            if (miss <= attack.Accuracy) { 

                int damage = attack.Attack - (attack.Attack * (defender.Defense / 100));
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
            Console.WriteLine("\nUse z and s to navigate and press Enter/Return to select:");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = " \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            if(game.lInTeam[_pokemonOnField].Speed < _enemyInBattle.Speed)
            {
                _currentTurn = "Enemy";
            }

            while (_combat == false)
            {
                if (_currentTurn == "You")
                {
                    while (!isSelected)
                    {
                        Console.SetCursorPosition(left, top);

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

                    switch (option)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            if (Attack(game.lInTeam[_pokemonOnField], game.lInTeam[_pokemonOnField].Capacities[option], _enemyInBattle) == true)
                            {
                                _combat = true;
                            }
                            else
                            {
                                isSelected = false;
                                _currentTurn = "Enemy";
                            }
                            break;

                        case 4:
                            game.SetState(new OverworldState());
                            _currentTurn = "Run";
                            _combat = true;
                            break;
                    }
                } else if (_currentTurn == "Enemy")
                {
                    _enemyRandom = _rand.Next(0,4);
                    if(Attack(_enemyInBattle, _enemyInBattle.Capacities[_enemyRandom], game.lInTeam[_pokemonOnField]) == true)
                    {
                        _combat = true;
                    }
                    else
                    {
                        _currentTurn = "You";
                    }
                }
            }
            // end of combat 
            switch(_currentTurn)
            {
                case "You":
                    Console.WriteLine("You won !");
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