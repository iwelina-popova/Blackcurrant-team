namespace MonopolyGame.Model.Classes.Actions
{
    using System.Linq;
    using Model.Classes.Tiles;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;

    class StationRentAction : BaseRentAction, IRentable
    {
        public override void PayRent(Player player, PropertyTile property)
        {
            base.PayRent(player, property);

            if (property.Owner != null && property.Owner != player)
            {
                int numberOfStationsOfOwner = property.Owner.Properties.Count(tile => tile is StationTile);

                property.Owner.AddMoney(property.BaseRent * numberOfStationsOfOwner);
                player.WidthdrawMoney(property.BaseRent * numberOfStationsOfOwner);
            }
        }
    }
}
