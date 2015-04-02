namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;

    public class StationTile : PropertyTile,IActionable
    {
        private const int STATION_PRICE = 200;
        private const int STATION_RENT = 25;

        public StationTile(string name)
            : base(name, STATION_PRICE, STATION_RENT)
        {
            NumberOfStations++;
        }

        static StationTile()
        {
            NumberOfStations = 0;
        }

        public static int NumberOfStations { get; private set; }

        //public override bool PayRent(Player player)
        //{
        //    if (this.Owner != null && this.Owner != player) 
        //    {
        //        int numberOfStationsOfOwner = this.Owner.Properties.Count(property => property is StationTile);
                
        //        this.Owner.AddMoney(this.BaseRent*numberOfStationsOfOwner);
        //        player.WidthdrawMoney(this.BaseRent*numberOfStationsOfOwner);

        //        return true;
        //    }

        //   return base.PayRent(player);
        //}
    }
}
