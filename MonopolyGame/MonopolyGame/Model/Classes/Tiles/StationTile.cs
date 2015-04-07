namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Tiles.Contracts;

    public class StationTile : PropertyTile, IChoosableAction
    {
        private const int STATION_PRICE = 200;
        private const int STATION_RENT = 25;

        static StationTile()
        {
            NumberOfStations = 0;
        }

        public StationTile(string name)
            : base(name, STATION_PRICE, STATION_RENT)
        {
            NumberOfStations++;
            this.AddAction(new StationRentAction());
        }

        public static int NumberOfStations { get; private set; }
    }
}
