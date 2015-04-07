namespace MonopolyGame.Model.Classes
{
    using System.Collections.Generic;
    using System.Text;
    using System;

    using Model.Common.Validators;
    using Model.Classes.Cards.Contracts;
    using Model.Classes.Tiles.Contracts;
    using MonopolyGame.Model.Common.CustomExceptions;
    

    public class Player
    {
        private string name;
        private IEnumerable<PropertyTile> properties;

        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            this.Money = 1000;
            this.IsBankrupt = false;
            this.properties = new List<PropertyTile>();
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            private set 
            {
                ObjectValidator.StringNullOrEmptyValidator(value, "Name cannot be empty or null");
                this.name = value;
            }
        }

        public int Position { get; private set; }

        public int Money { get; private set; }

        public bool IsBankrupt { get; private set; }

        public IEnumerable<PropertyTile> Properties
        {
            get
            {
                return new List<PropertyTile>(this.properties);
            }
        }

        public void Move(int position)
        {
            this.Position = position;
        }

        public void AddMoney(int amount)
        {
            if (this.IsBankrupt)
            {
                throw new PlayerBankruptException(this.Name);
            }
            this.Money += amount;

        }

        public void WidthdrawMoney(int amount)
        {
                this.Money -= amount;

                if (this.Money < 0)
                {
                    this.IsBankrupt = true;
                }
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
