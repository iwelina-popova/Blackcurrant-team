using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using Model.Common.Validators;
    using Model.Classes.Tiles.Contracts;

    public abstract class BaseRentAction : IAction,IRentable
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
