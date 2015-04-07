namespace MonopolyGame.Model.Classes.Actions
{
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;
    using Model.Common.Validators;

    public class SellAction : IAction, ISellable
    {
        public void Execute(IChoosableAction type, Player player)
        {
            PropertyTile tile = type as PropertyTile;
            ObjectValidator.NullObjectValidation(tile, "The instance type should a be PropertyTile");
            this.Sell(player, tile);
        }

        public void Sell(Player player, PropertyTile property)
        {
            ObjectValidator.NullObjectValidation(player, "Player instance cannot be null");
            ObjectValidator.NullObjectValidation(property, "PropertyTile instance cannot be null");

            if (property.Owner == null)
            {
                player.AddMoney(property.Price);
                property.ChangeOwner(null);
            }
        }
    }
}
