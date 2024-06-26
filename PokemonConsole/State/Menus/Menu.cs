﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PokemonConsole.State
{
    public class Menu : BlankState
    {
        public override void Enter(BlankState oldState, Game game)
        {
            base.Enter(oldState, game);
            if (OperatingSystem.IsWindows())
            {
                _player = new SoundPlayer("aud/title.wav");
                _player.Load();
                _player.PlayLooping();
            }
        }

        public override void Leave(BlankState newState, Game game)
        {
            base.Leave(newState, game);
            if (OperatingSystem.IsWindows())
            {
                _player.Stop();
            }
        }

        override public void Run(Game game)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.WriteLine("                                   ,'\\");
            Console.WriteLine("    _.----.        ____         ,'  _\\   ___     ___    ____");
            Console.WriteLine("_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |   \\   |`..");
            Console.WriteLine("\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.  \\  |   |");
            Console.WriteLine("\\.     \\ \\   |  __  |  |/    ,',' _  `. |          | __ |    \\_|   |");
            Console.WriteLine("   \\    \\/   /,' _`.|      ,' /  / / /  |          ,' _`.          |");
            Console.WriteLine("    \\     ,-'/  /   \\    ,'   |  \\/ / ,`.         /  /  \\|         |");
            Console.WriteLine("     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/ |  |\\.    |");
            Console.WriteLine("      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\     /   |  |   |");
            Console.WriteLine("       \\    \\ `.__,'|  |`-._    `|      |  | \\/ | `.__,'|   |  |   |");
            Console.WriteLine("        \\_.-'       |__|    `-._ |      '--      '-.|    '-.|  |   |");
            Console.WriteLine("                                `'                             '-._|");


            Console.WriteLine("\nUse z and s to navigate and press Enter to select:\n");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = " \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? decorator : " ")}Game\u001b[0m");
                Console.WriteLine($"{(option == 2 ? decorator : " ")}Exit\u001b[0m");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Z:
                        option = option == 1 ? 2 : option - 1;
                        break;

                    case ConsoleKey.S:
                        option = option == 2 ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            if (option == 1)
            {
                Console.Clear();
                game.DrawMapInit();
                game.SetState(new OverworldState());
            } 
            else if (option == 2)
            {
                System.Environment.Exit(1);
            }
        }
    }
}
