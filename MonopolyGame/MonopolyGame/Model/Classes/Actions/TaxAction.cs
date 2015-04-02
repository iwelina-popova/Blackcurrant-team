namespace MonopolyGame.Model.Classes.Actions
{
    using Model.Classes.Actions.Contracts;
    using Model.Common.Validators;
    using Model.Classes.Tiles;

    class TaxAction : IAction, ITaxable
    {
        public void Execute(IActionable type, Player player)
        {
            TaxTile tile = type as TaxTile;
            ObjectValidator.NullObjectValidation(tile, "The instance type should a be TaxTile");
            PayTax(player, tile.Tax);
        }

        public void PayTax(Player player, int amount)
        {
            player.WidthdrawMoney(amount);
        }
    }
}
