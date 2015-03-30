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
    }
}
