namespace MonopolyGame.Model.Common.Helpers
{
    using System;
    using System.Collections.Generic;

    using Model.Classes.Cards.Contracts;

    public static class CardHelpers
    {
        private static Random r = new Random();

        public static Queue<T> ShuffleCards<T>(T[] cards)
        {
            for (int n = cards.Length - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                var temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }

            var result = new Queue<T>();

            foreach (var item in cards)
            {
                // Console.WriteLine(item);
                result.Enqueue(item);
            }

            return result;
        }

        public static T DrawCard<T>(Queue<T> cards) where T : Card
        {
            T currentCard = cards.Dequeue();
            cards.Enqueue(currentCard);

            return currentCard;
        }
    }
}
