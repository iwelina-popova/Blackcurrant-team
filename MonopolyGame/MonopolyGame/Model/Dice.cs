using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class Dice
    {
        private Random generator;

        public Dice()
        {
            this.generator = new Random();
        }

        public int Roll()
        {
            return generator.Next(0, 13);
        }
    }
}
