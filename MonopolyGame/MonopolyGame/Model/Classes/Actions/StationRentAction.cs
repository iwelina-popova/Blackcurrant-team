namespace MonopolyGame.Model.Classes.Actions
{
    using System.Linq;

    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles;
    using Model.Classes.Tiles.Contracts;

    public class StationRentAction : BaseRentAction, IRentable
    {
        public override void PayRent(Player player, PropertyTile property)
        {
            base.PayRent(player, property);

            if (property.Owner != null && property.Owner != player)
            {
                int numberOfStationsOfOwner = property.Owner.Properties.Count(tile => tile is StationTile);



                if (numberOfStationsOfOwner == StationTile.NumberOfStations)
                {
                    property.Owner.AddMoney(property.BaseRent * numberOfStationsOfOwner);
                    player.WidthdrawMoney(property.BaseRent * numberOfStationsOfOwner);
                }
                else 
                {
                    property.Owner.AddMoney(property.BaseRent);
                    player.WidthdrawMoney(property.BaseRent);
                }
            }
        }
    }
}
