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

        //public override void Action(Player player)
        //{
        //    if (this.Owner == null)
        //    {
        //        if (player.Money >= this.Price)
        //        {
        //            Delegates.PrintingMethodInstance("Make your choice:\n1: Buy\n2: Skip");
        //            string input = Delegates.ReadingMethodIntance();

        //            switch (input)
        //            {
        //                case "1": Buy(player); break;
        //                case "2": break;
        //                default: throw new ArgumentOutOfRangeException("Incorrect choice!");
        //            }
        //        }
        //        else
        //        {
        //            PayRent(player);
        //        }
        //    }
        //    else
        //    {
        //        PayRent(player);
        //    }
        //}

        //public bool Buy(Player player)
        //{
        //    if (player.WidthdrawMoney(this.Price))
        //    {
        //        this.Owner = player;
        //        player.Properties.Add(this);
        //        return true;
        //    }

        //    return false;
        //}

        //public virtual bool PayRent(Player player) 
        //{
        //    if (this.Owner == null)
        //    {
        //        return player.WidthdrawMoney(this.BaseRent);
        //    }

        //    return true;
        //}      
    }
}
