using PokemonConsole.State;
using PokemonConsole;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PokemonConsole.Items;
using System.Numerics;
using PokemonConsole.State.Menus.Sous_Menus;

namespace PokemonConsole.State
{
    public class BattleState : BlankState
    {

        TypeManager _typeManager;

        int _pokemonOnField;
        int _enemyOnField;

        string _currentTurn;
        bool _combat;

        int _enemyRandom;

        int _turnPlayed;

        Enemy _selectedPKM;
        public Enemy SelectedPKM { get { return _selectedPKM; } set { _selectedPKM = value; } }

        PokeBall _captureBall;
        public PokeBall CaptureBall { get { return _captureBall; } set { _captureBall = value; } }

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

        public override void Enter(BlankState oldState, Game game)
        {
            base.Enter(oldState, game);
            if (OperatingSystem.IsWindows())
            {
                string mode = (_enemyTeam.Count != 1) ? "trainer" : "wild";
                _player = new System.Media.SoundPlayer($"aud/battle_{mode}.wav");
                _player.Play();
            }
        }

        public override void Resume(BlankState oldState, Game game)
        {
            base.Resume(oldState, game);
            if (oldState is InventoryState || oldState is PokeSelectScreen) return;
            if (OperatingSystem.IsWindows())
            {
                _player.Play();
            }
        }

        public override void Pause(BlankState newState, Game game)
        {
            base.Pause(newState, game);
            if (newState is InventoryState || newState is PokeSelectScreen) return;
            if (OperatingSystem.IsWindows())
            {
                _player.Stop();
            }
        }

        public override void Leave(BlankState newState, Game game)
        {
            base.Pause(newState, game);
            if (OperatingSystem.IsWindows())
            {
                _player.Stop();
            }
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
                    defender.Health = 0;
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

            for (int i =0; i < game.lInTeam.Count; i++)
            {
                if (game.lInTeam[i].Health > 0)
                {
                    _pokemonOnField = i;
                    test = true;
                    break;
                }
            }

            if (test == false) {

                Console.WriteLine("You don't have any Pokemon that can fight");
                Console.WriteLine("Go heal them");

                game.PushState(new OverworldState());
                Console.ReadKey();
                game.DrawMapInit();

                _currentTurn = "Unable";
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

                    Console.WriteLine($"{(option == 4 ? decorator : " ")}Inventory\u001b[0m");

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

                if (option == 4)
                {
                    SelectedPKM = null;
                    CaptureBall = null;
                    game.PushState(new State.Menus.Sous_Menus.InventoryState());
                    while (SelectedPKM == null && CaptureBall == null)
                        game.StateList.Last().Run(game);
                    game.PopState();
                    if (CaptureBall == null) break;
                    if (_enemyTeam.Count != 1)
                    {
                        Console.WriteLine("Can't capture trainer's pokemon");
                        isSelected = false;
                        _turnPlayed += 1;
                        _currentTurn = "Enemy";
                        break;
                    }

                    (bool doCatch, int shakeCount) = HandleCapture();

                    for (int i = 0; i < shakeCount; i++)
                    {
                        Thread.Sleep(1000);
                        string dots = ".";
                        int j = 0;
                        while (j < i)
                        {
                            dots += ".";
                            j++;
                        }
                        Console.WriteLine("It shakes" + dots);
                    }

                    if (doCatch)
                    {
                        if(game.lInTeam.Count == 6)
                        {
                            game.lPokemonCatch.Add(_enemyTeam[_enemyOnField]);
                        }
                        else
                        {
                            game.lInTeam.Add(_enemyTeam[_enemyOnField]);
                            _enemyTeam[_enemyOnField].isInTeam = true;

                        }
                        _turnPlayed = 2;
                        _combat = true;
                        _currentTurn = "Capture";
                        break;
                    }
                    else
                    {
                        string message;
                        if (shakeCount == 0)
                            message = "Oh, no! The Pokémon broke free!";
                        else if (shakeCount == 1)
                            message = "Darn! The Pokémon broke free!";
                        else if (shakeCount == 2)
                            message = "Aargh! Almost had it!";
                        else
                            message = "Shoot! It was so close, too!";
                        Console.WriteLine(message);
                        Console.ReadKey(true);
                        isSelected = false;
                        _turnPlayed += 1;
                        _currentTurn = "Enemy";
                    }
                }
                else if (option == 5)
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
                                    isSelected = false;
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

                    if (_enemyTeam.Count > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You defeated the trainer !\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You won !\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    game.lInTeam[_pokemonOnField].LevelUp(game.lInTeam[_pokemonOnField], _enemyTeam[_enemyOnField].Reward);

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

                case "Unable":
                case "Run":
                    Console.WriteLine("You ran");
                    break;

                case "Capture":
                    Console.WriteLine($"Gotcha! {_enemyTeam[_enemyOnField].Name} was caught! ");
                    break;
            }

            Console.WriteLine("End of combat");
            game.PushState(new OverworldState());
            Console.ReadKey();
            game.DrawMapInit();
        }

        public Tuple<bool, int> HandleCapture()
        {
            if (CaptureBall.name.ToLower() == "master ball")
                return new Tuple<bool, int>(true, 3);
            Enemy pkm = _enemyTeam[0];

            float a = ((3 * pkm.MaxHealth - 2 * pkm.Health) * CaptureBall.GetCatchMultiplier())*100 / (3 * pkm.MaxHealth);
            a = Math.Max(a, 1);
            float rand = _rand.Next(255/2);
            if (rand <= a) return new Tuple<bool, int>(true, 3);
            int shakeCount = 0;
            int ball = 150;
            if (CaptureBall.name.ToLower() == "poké ball")
                ball = 255;
            else if (CaptureBall.name.ToLower() == "great ball")
                ball = 200;
            float d = CaptureBall.GetCatchMultiplier()*10000/ball;
            if (d >= 60)
                shakeCount = 3;
            else
            {
                float x = d * a / (255 / 2);
                if (x < 10)
                    shakeCount = 0;
                else if (x < 30)
                    shakeCount = 1;
                else if (x < 70)
                    shakeCount = 2;
                else
                    shakeCount = 3;
            }
            return new Tuple<bool, int>(false, shakeCount);
        }
    }
}