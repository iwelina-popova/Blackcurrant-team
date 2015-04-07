namespace MonopolyGame.Model.Classes.Actions
{
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles;
    using Model.Common.Validators;

    public class TaxAction : IAction, ITaxable
    {
        public void Execute(IChoosableAction type, Player player)
        {
            TaxTile tile = type as TaxTile;
            ObjectValidator.NullObjectValidation(tile, "The instance type should a be TaxTile");
            this.PayTax(player, tile.Tax);
        }

        public void PayTax(Player player, int amount)
        {
            player.WidthdrawMoney(amount);
        }
    }
}
