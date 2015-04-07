namespace MonopolyGame.Model.Classes.Tiles.Contracts
{
    using Model.Common.Validators;

    public abstract class Tile
    {
        private string name;

        protected Tile(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public int X { get; protected set; }
        public int Y { get; protected set; }

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

        //public abstract void Action(Player player);
    }
}
