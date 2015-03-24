using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class JailTile : Tile
    {
        private int cycle;

        public JailTile(int position)
            : base(position)
        {
            this.cycle = 3;
        }

        public override void Action(Player player)
        {
            Console.WriteLine("Make your choice:\n1: Pay tax from 50$!\n2: Try to roll doubles!");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": PayJailTax(player); break;
                case "2": StayInJail(player); break;
                default: throw new ArgumentOutOfRangeException("Incorrect choice!");
            }
        }

        public void PayJailTax(Player player)
        {
            player.WidthDrawMoney(50);
        }

        public void StayInJail(Player player)
        {
            if (!Dice.TryToRollDoubles())
            {
                player.CanMove = false;
                --cycle;

                if (cycle == 0)
                {
                    PayJailTax(player);
                }
            }
            else
            {
                player.CanMove = true;
            }
        }
    }
}
