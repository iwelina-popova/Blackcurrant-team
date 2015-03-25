namespace MonopolyGame.Model.Classes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class District
    {
        public List<StreetTile> Section { get; set; }

        public District()
        {
            this.Section = new List<StreetTile>();
        }

        public List<StreetTile> LoadDistrict(List<StreetTile> streets, StreetTile currentStreet)
        {
            foreach (var street in streets)
            {
                if (street.Color == currentStreet.Color)
                {
                    this.Section.Add(street);
                }
            }

            return this.Section;
        }

        public bool CheckDistrictOwner()
        {
            var owner = this.Section.First().Owner;
            foreach (var street in this.Section)
            {
                if (street.Owner != owner)
                {
                    return false;
                }
            }

            return true;
        }

        public int PayRent()
        {
            int districtRent = 0;

            foreach (var street in this.Section)
            {
                districtRent += street.BaseRent;
            }
            return districtRent;
        }
    }
}
