namespace MonopolyGame.Model.Classes.Tiles
{
    using System.Collections.Generic;

    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;    
    using Model.Common.Validators;
    using Model.Classes.Tiles.Contracts;

    public class TaxTile : ActionableTile,IActionable
    {
        public TaxTile(string name, int tax) 
            : base(name) 
        {
            this.Tax = tax;
            this.AddAction(new TaxAction());
        }

        public int Tax { get; private set; }

        //public override void Action(Player player)
        //{
        //    Pay(player);
        //}

        //public bool Pay(Player player) 
        //{
        //    return player.WidthdrawMoney(this.Tax);
        //}
    }
}