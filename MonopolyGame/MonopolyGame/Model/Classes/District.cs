namespace MonopolyGame.Model.Classes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class District
    {
        public List<StreetTile> LoadDistrict(List<StreetTile> streets, StreetTile currentStreet)
        {
            List<StreetTile> district = new List<StreetTile>();

            foreach (var street in streets)
            {
                if (street.Color == currentStreet.Color)
                {
                    district.Add(street);
                }
            }

            return district;
        }

        public bool CheckDistrictOwner(List<StreetTile> district)
        {
            var owner = district.First().Owner;
            foreach (var street in district)
            {
                if (street.Owner != owner)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
