namespace MonopolyGame.Model.Classes
{
    using System;

    public class Dice
    {
        private Random generator;

        public Dice()
        {
            this.generator = new Random();
        }

        public static bool TryToRollDoubles(Dice firstDice, Dice secondDice)
        {
            return firstDice.Roll() == secondDice.Roll();
        }

        public int Roll()
        {
            int dice = this.generator.Next(1, 7);
            return dice;
        }
    }
}
