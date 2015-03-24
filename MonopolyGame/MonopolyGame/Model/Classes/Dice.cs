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
            return generator.Next(1, 7);
        }

        public static bool TryToRollDoubles() 
        {
            return new Dice().Roll() == new Dice().Roll();
        }
    }
}
