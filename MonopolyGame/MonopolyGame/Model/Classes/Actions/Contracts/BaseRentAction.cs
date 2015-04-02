namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using System;

    using Model.Classes.Tiles.Contracts;
    using Model.Common.Validators;

    public abstract class BaseRentAction : IAction, IRentable
    {
        public void Execute(IChoosableAction type, Player player)
        {
            PropertyTile tile = type as PropertyTile;
            ObjectValidator.NullObjectValidation(tile, "The instance type should a be PropertyTile");
            this.PayRent(player, tile);
        }

        public virtual void PayRent(Player player, Tiles.Contracts.PropertyTile property)
        {
            ObjectValidator.NullObjectValidation(player, "Player instance cannot be null");
            ObjectValidator.NullObjectValidation(property, "PropertyTile instance cannot be null");

            if (property.Owner == null)
            {
                player.WidthdrawMoney(property.BaseRent);
            }
        }
    }
}
