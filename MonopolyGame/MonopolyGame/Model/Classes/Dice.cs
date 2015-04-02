using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class Dice
    {
        private Random generator;

        public Dice()
        {
            this.generator = new Random();
        }

        public int Roll()
        {
            int dice = this.generator.Next(1, 7);
            return dice;
        }

        public static bool TryToRollDoubles(Dice firstDice,Dice secondDice) 
        {
            return firstDice.Roll() == secondDice.Roll();
        }
    }
}
