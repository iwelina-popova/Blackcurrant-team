using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public abstract class Card
    {
        public Card(string description, int money)
        {
            this.Description = description;
            this.Money = money;
        }
        public int Money { get; set; }

        public string Description { get; private set; }

        public abstract void Action(Player player);

        public override string ToString()
        {
            return this.Description;
        }

        static Random r = new Random();

        internal static Queue<T> Shuffle<T>(T[] cards)
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
    }
}
