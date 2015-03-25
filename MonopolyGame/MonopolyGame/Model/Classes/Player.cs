using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            this.Money = 1000;
            this.CanMove = true;
            this.IsBankrupt = false;
        }

        public string Name { get; private set; }
        public int Position { get; private set; }
        public int Money { get; private set; }
        public bool CanMove { get; set; }
        public bool IsBankrupt { get; private set; }
        
        public void Move(int spaces, int boardSize)
        {
                this.Position += spaces;

                if (this.Position >= boardSize)
                {
                    this.Position -= boardSize;
                    this.AddMoney(200);
                }
        }

        public bool AddMoney(int amount)
        {
            if (!this.IsBankrupt)
            {
                this.Money += amount;
            }

            return !this.IsBankrupt;
        }

        public bool WidthDrawMoney(int amount) 
        {
            if (!this.IsBankrupt)
            {
                this.Money -= amount;
                
                if (this.Money < 0)
                {
                    this.IsBankrupt = true;
                }
            }

            return !this.IsBankrupt;
        }

        public bool DrawCard(Card card)
        {
            if (!this.IsBankrupt)
            {
                AddMoney(card.Money);
            }

            return !this.IsBankrupt;
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
