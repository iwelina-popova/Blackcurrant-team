namespace MonopolyGame.Model.Classes.Tiles
{
    using System;

    using Enumerations;
    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;

    public class StreetTile : PropertyTile, IChoosableAction
    {
        static StreetTile()
        {
            BrowDistrictTiles = 0;
            YellowDistricTiles = 0;
            DarkBlueDistrictTiles = 0;
            LiteBlueDistrictTiles = 0;
            GreenDistrictTiles = 0;
            RedDistrictTiles = 0;
            PinkDistrictTiles = 0;
            OrangeDistrictTiles = 0;
        }

        public StreetTile(string name, int price, int baseRent, DistrictColor color)
            : base(name, price, baseRent)
        {
            this.Color = color;
            this.AddAction(new StreetRentAction());
            this.IncrementNumberOfStreets(this.Color);
        }

        public static int BrowDistrictTiles { get; private set; }

        public static int YellowDistricTiles { get; private set; }

        public static int DarkBlueDistrictTiles { get; private set; }

        public static int LiteBlueDistrictTiles { get; private set; }

        public static int GreenDistrictTiles { get; private set; }

        public static int RedDistrictTiles { get; private set; }

        public static int PinkDistrictTiles { get; private set; }

        public static int OrangeDistrictTiles { get; private set; }

        public DistrictColor Color { get; private set; }

        private void IncrementNumberOfStreets(DistrictColor color)
        {
            switch (color)
            {
                case DistrictColor.Brown: BrowDistrictTiles++; break;
                case DistrictColor.Yellow: YellowDistricTiles++; break;
                case DistrictColor.DarkBlue: DarkBlueDistrictTiles++; break;
                case DistrictColor.LiteBlue: LiteBlueDistrictTiles++; break;
                case DistrictColor.Green: GreenDistrictTiles++; break;
                case DistrictColor.Red: RedDistrictTiles++; break;
                case DistrictColor.Pink: PinkDistrictTiles++; break;
                case DistrictColor.Orange: OrangeDistrictTiles++; break;
            }
        }

        public static int GetNumberOfStreetsInDistrict(DistrictColor color)
        {
            switch (color)
            {
                case DistrictColor.Brown: return BrowDistrictTiles;
                case DistrictColor.Yellow: return YellowDistricTiles;
                case DistrictColor.DarkBlue: return DarkBlueDistrictTiles;
                case DistrictColor.LiteBlue: return LiteBlueDistrictTiles;
                case DistrictColor.Green: return GreenDistrictTiles;
                case DistrictColor.Red: return RedDistrictTiles;
                case DistrictColor.Pink: return PinkDistrictTiles;
                case DistrictColor.Orange: return OrangeDistrictTiles;
                default:
                    throw new ArgumentException("District color not supported");
	        }
        }
    }
}
