using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    using MonopolyGame.Interfaces;

    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            this.Money = 1000;
            this.CanMove = true;
        }

        public string Name { get; private set; }
        public int Position { get; private set; }
        public int Money { get; set; }
        public bool CanMove { get; set; }
        
        public void Move(Dice dice, ITile[] board)
        {
            this.Position += dice.Roll();
            if (this.Position >= board.Length)
            {
                this.Position -= board.Length - 1;
            }
            board[this.Position].Action(this);
        }

        public void ChangeMoney(int amount)
        {
            this.Money += amount;
        }

        public void DrawCard(Card card)
        {
            ChangeMoney(card.Money);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(String.Format("Name: {0}", this.Name));
            result.AppendLine(String.Format("Position: {0}", this.Position));
            result.AppendLine(String.Format("Money: {0}", this.Money));
            return result.ToString();
        }
    }
}
