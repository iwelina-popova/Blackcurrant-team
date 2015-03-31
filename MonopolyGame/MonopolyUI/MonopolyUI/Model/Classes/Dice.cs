﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class Dice
    {
        private static Random generator;

        static Dice()
        {
            generator = new Random();
        }

        public static int Roll()
        {
            int dice = generator.Next(1, 7);
            return dice;

            //return generator.Next(1, 7);
        }

        public static bool TryToRollDoubles(int firstRoll,int secondRoll) 
        {
            return firstRoll == secondRoll;
        }
    }
}
