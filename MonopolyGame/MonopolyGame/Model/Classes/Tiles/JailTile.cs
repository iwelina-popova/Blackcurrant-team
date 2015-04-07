namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;
    using Model.Delegates;

    public class JailTile : TaxTile, IChoosableAction
    {
        private const string JAIL_TILE_NAME = "Jail";
        private const int JAIL_TAX = 50;
        private int cycle;

        public JailTile()
            : base(JAIL_TILE_NAME, JAIL_TAX)
        {
            //this.cycle = 3;
        }

        //public override void Action(Player player)
        //{
        //    Delegates.PrintingMethodInstance("Make your choice:\n1: Pay tax from 50$!\n2: Try to roll doubles!");
        //    string input = Delegates.ReadingMethodIntance();

        //    switch (input)
        //    {
        //        case "1": PayJailTax(player); break;
        //        case "2": EscapeFree(player); break;
        //        default: throw new ArgumentOutOfRangeException("Incorrect choice!");
        //    }
        //}

        //public void PayJailTax(Player player)
        //{
        //    player.WidthdrawMoney(50);
        //}

        //public void EscapeFree(Player player)
        //{
        //    if (!Dice.TryToRollDoubles(Dice.Roll(), Dice.Roll()))
        //    {
        //        player.CanMove = false;
        //        --cycle;

        //        if (cycle == 0)
        //        {
        //            PayJailTax(player);
        //        }
        //    }
        //    else
        //    {
        //        player.CanMove = true;
        //    }
        //}
    }
}
