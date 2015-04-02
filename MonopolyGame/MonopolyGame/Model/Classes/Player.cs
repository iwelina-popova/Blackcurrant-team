namespace MonopolyGame.Model.Classes
{
    using System.Collections.Generic;
    using System.Text;

    using Model.Classes.Cards.Contracts;
    using Model.Classes.Tiles.Contracts;

    public class Player
    {
        private IEnumerable<PropertyTile> properties;

        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            this.Money = 1000;
            this.CanMove = true;
            this.IsBankrupt = false;
            this.properties = new List<PropertyTile>();
        }

        public string Name { get; private set; }

        public int Position { get; private set; }

        public int Money { get; private set; }

        public bool CanMove { get; set; }

        public bool IsBankrupt { get; private set; }

        public IEnumerable<PropertyTile> Properties
        {
            get
            {
                return new List<PropertyTile>(this.properties);
            }
        }

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

        public bool WidthdrawMoney(int amount)
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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("Name: {0}", this.Name));
            result.AppendLine(string.Format("Position: {0}", this.Position));
            result.AppendLine(string.Format("Money: {0}", this.Money));
            return result.ToString();
        }
    }
}
