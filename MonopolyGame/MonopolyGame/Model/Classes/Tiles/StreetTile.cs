﻿namespace MonopolyGame.Model.Classes.Tiles
{
    using Enumerations;
    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;

    public class StreetTile : PropertyTile,IActionable
    {
        public StreetTile(string name, int price, int baseRent, StreetTileColor color)
            : base(name, price, baseRent)
        {
            this.Color = color;
            IncrementNumberOfStreets(this.Color);
        }

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

        public StreetTileColor Color { get; private set; }

        public static int BrowDistrictTiles { get; private set; }
        public static int YellowDistricTiles { get; private set; }
        public static int DarkBlueDistrictTiles { get; private set; }
        public static int LiteBlueDistrictTiles { get; private set; }
        public static int GreenDistrictTiles { get; private set; }
        public static int RedDistrictTiles { get; private set; }
        public static int PinkDistrictTiles { get; private set; }
        public static int OrangeDistrictTiles { get; private set; }


        public void IncrementNumberOfStreets(StreetTileColor color) 
        {
            switch (color)
            {
                case StreetTileColor.Brown: BrowDistrictTiles++; break;
                case StreetTileColor.Yellow: YellowDistricTiles++; break;
                case StreetTileColor.DarkBlue: DarkBlueDistrictTiles++; break;
                case StreetTileColor.LiteBlue: LiteBlueDistrictTiles++; break;
                case StreetTileColor.Green: GreenDistrictTiles++; break;
                case StreetTileColor.Red: RedDistrictTiles++; break;
                case StreetTileColor.Pink: PinkDistrictTiles++; break;
                case StreetTileColor.Orange: OrangeDistrictTiles++; break;
            }
        }

        //public override bool PayRent(Player player)
        //{
        //    if (this.Owner != null && this.Owner != player) 
        //    {
        //        int numberOfStreetsInDistrict = this.Owner.Properties
        //            .Count(property => property is StreetTile && ((StreetTile)property).Color == this.Color);

        //        this.Owner.AddMoney(this.BaseRent * numberOfStreetsInDistrict);
        //        player.WidthdrawMoney(this.BaseRent * numberOfStreetsInDistrict);

        //        return true;
        //    }

        //    return base.PayRent(player);
        //}
    }
}
