namespace MonopolyGame.Model.Classes.Tiles.Contracts
{
    using Model.Common.Validators;

    public abstract class Tile
    {
        private string name;

        public Tile(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ObjectValidator.StringNullOrEmptyValidator(value, "The name should not me null or empty string");
                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("name: {0}", this.Name);
        }
    }
}
