namespace MonopolyGame.Model.Classes.Tiles
{
    using System.Collections.Generic;

    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;
    using Model.Common.Validators;

    public class TaxTile : ChoosableActionTile, IChoosableAction
    {
        public TaxTile(string name, int tax)
            : base(name)
        {
            this.Tax = tax;
            this.AddAction(new TaxAction());
        }

        public int Tax { get; private set; }
    }
}