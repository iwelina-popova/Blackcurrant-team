using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    using Interfaces;

    public class JailTile : Tile,ITile
    {
        private Random generator;
        private int cycle = 3;

        public JailTile(int position) 
            :base(position)
        { }

        public void Action(Player player)
        {
            throw new NotImplementedException();
        }

        public void PayJailTax(Player player)
        {
            player.Money -= 50;
        }

        public void TryToRollDoubles(Player player)
        {
            Dice dice = new Dice();
            int firstDice = dice.Roll();
            int secondDice = dice.Roll();

            if (firstDice != secondDice)
            {
                player.CanMove = false;
                --cycle;

                if (cycle == 0)
                {
                    player.Money -= 50;
                }
            }
            else
            {
                player.CanMove = true;
            }            
        }
    }
}
