namespace MonopolyGame.Model.Classes.Tiles.Contracts
{
    using System;

    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Common.Validators;
    using Model.Delegates;

    public abstract class PropertyTile : ChoosableActionTile, IChoosableAction
    {
        public PropertyTile(string name, int price, int rent, Player owner = null)
            : base(name)
        {
            this.Price = price;
            this.BaseRent = rent;
            this.Owner = owner;
            this.AddAction(new BuyAction());
            this.AddAction(new SellAction());
        }

        public Player Owner { get; protected set; }

        public int Price { get; protected set; }

        public int BaseRent { get; protected set; }

        public void ChangeOwner(Player newOwner)
        {
            this.Owner = newOwner;
        }
    }
}
