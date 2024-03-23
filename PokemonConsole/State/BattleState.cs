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
        int _size;
        char[,] _battleScreen;

        public BattleState(Enemy enemy)
        {
            _enemyInBattle = enemy;
/*            _size = 52;
            _battleScreen = new char[_size, 100];*/
        }


/*        void BattleScreen()
        {
            String lineRead;
            StreamReader mapTxt = new StreamReader("../../../txt/enemy.txt");
            lineRead = mapTxt.ReadLine();
            int lineNumber = 0;

            for (int colNumber = 0; colNumber < 52; colNumber++)
            {

                foreach (char charRead in lineRead)
                {
                    _battleScreen[colNumber, lineNumber] = charRead;
                    lineNumber++;

                }
                lineNumber = 0;
                lineRead = mapTxt.ReadLine();
                colNumber++;
            }

            mapTxt.Close();
        }

        void DrawBattleScreen()
        {

            for (int i = 0; i < 52; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    Console.Write(_battleScreen[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }*/
        override public void Run(Game game)
        {

            /*            BattleScreen();
                        DrawBattleScreen();*/


            Console.WriteLine(_enemyInBattle.Name);
            Console.WriteLine(_enemyInBattle.Level);
            Console.WriteLine(_enemyInBattle.Type);
            foreach (Capacity capacity in _enemyInBattle.Capacities)
            {
                Console.WriteLine(capacity.Name);
                Console.WriteLine(capacity.Type);
                Console.WriteLine(capacity.Attack);
                Console.WriteLine(capacity.Accuracy);
                _enemyInBattle.isInTeam = true;

            }
            Console.WriteLine(_enemyInBattle.Defense);
            Console.WriteLine(_enemyInBattle.Speed);

            char keyPressed = Console.ReadKey().KeyChar;

            // temporary
            if (keyPressed == 'e')
            {
                game.SetState(new OverworldState());
            }
        }
    }
}
