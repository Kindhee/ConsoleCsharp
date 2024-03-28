using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole.State.Menus.Sous_Menus
{
    internal class InventoryState : BlankState
    {
        private List<List<Inventory.StorageItemInfo>> bags;
        private byte bIndex;
        private byte iIndex;
        private string bagTitle;

        private string decorator;

        private bool inBattle;
        private BattleState battleState;

        ConsoleKeyInfo key;

        override public void Enter(BlankState state, Game game)
        {
            if (state is BattleState)
            {
                inBattle = true;
                battleState = (BattleState)state;
            }

            bags = new List<List<Inventory.StorageItemInfo>>();

            bags.Add(game._player.Inventory.Items);
            bags.Add(game._player.Inventory.Pokeballs);
            bags.Add(game._player.Inventory.CDs);
            bags.Add(game._player.Inventory.Keys);

            bIndex = 0;
            decorator = " \u001b[32m";
        }

        public override void Run(Game game)
        {
            base.Run(game);
            Console.Clear();

            Console.WriteLine("INVENTORY");
            if (bIndex == 0)
                bagTitle = "Items";
            else if(bIndex == 1)
                bagTitle = "Poke Balls";
            else if (bIndex == 2)
                bagTitle = "CDs";
            else if (bIndex == 3)
                bagTitle = "Key Items";
            Console.WriteLine(bagTitle);
            Console.WriteLine(bIndex + " | " + iIndex);
            Console.WriteLine();

            for (int i = 0; i < bags[bIndex].Count; i++)
            {
                if (i == iIndex)
                    Console.Write(decorator);
                Inventory.StorageItemInfo item = bags[bIndex][i];

                Console.WriteLine(item.item.name + "  x" + item.amount);
                Console.WriteLine("\t"+item.item.desc);

                Console.Write("\n\u001b[0m");
            }

            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    bIndex += 1;
                    if (bIndex >= bags.Count)
                    {
                        bIndex -= 1;
                        break;
                    }
                    iIndex = 0;
                    break;
                case ConsoleKey.Q:
                case ConsoleKey.LeftArrow:
                    bIndex -= 1;
                    if (bIndex == 255)
                    {
                        bIndex = 0;
                        break;
                    }
                    iIndex = 0;
                    break;
                case ConsoleKey.Z:
                case ConsoleKey.UpArrow:
                    iIndex -= 1;
                    if (iIndex == 255)
                    {
                        iIndex = 0;
                        break;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    iIndex += 1;
                    if (iIndex >= bags[bIndex].Count)
                    {
                        iIndex = (byte)(bags[bIndex].Count-1);
                        break;
                    }
                    break;
                case ConsoleKey.E:
                case ConsoleKey.Escape:
                    game.PopState();
                    break;
                case ConsoleKey.Enter:
                    if (inBattle)
                        bags[bIndex][iIndex].item.OnBattleUse(game, battleState);
                    else
                        bags[bIndex][iIndex].item.OnOverWorldUse(game);
                    break;
                default:
                    break;
            }
        }
    }
}
