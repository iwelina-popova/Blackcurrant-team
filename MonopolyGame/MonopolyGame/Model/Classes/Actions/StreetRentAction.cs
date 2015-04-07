namespace MonopolyGame.Model.Classes.Actions
{
    using System.Linq;

    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles;
    using Model.Classes.Tiles.Contracts;
    using Model.Common.Validators;
    using Model.Enumerations;

    public class StreetRentAction : BaseRentAction, IRentable
    {
        public override void PayRent(Player player, PropertyTile property)
        {
            base.PayRent(player, property);

            if (property.Owner != null && property.Owner != player)
            {
                StreetTile streetProperty = property as StreetTile;
                ObjectValidator.NullObjectValidation(streetProperty, "Property instance should be a StreetTile");

                int numberOfStreetsInDistrict = streetProperty.Owner.Properties
                    .Count(tile => tile is StreetTile && ((StreetTile)tile).Color == streetProperty.Color);

                if (numberOfStreetsInDistrict == StreetTile.GetNumberOfStreetsInDistrict(streetProperty.Color))
                {
                    streetProperty.Owner.AddMoney(streetProperty.BaseRent * numberOfStreetsInDistrict);
                    player.WidthdrawMoney(streetProperty.BaseRent * numberOfStreetsInDistrict);
                }
                else 
                {
                    streetProperty.Owner.AddMoney(streetProperty.BaseRent);
                    player.WidthdrawMoney(streetProperty.BaseRent);
                }
            }
        }
    }
}
