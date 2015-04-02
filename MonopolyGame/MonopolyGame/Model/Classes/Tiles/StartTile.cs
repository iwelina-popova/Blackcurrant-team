namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Tiles.Contracts;

    public class StartTile : Tile
    {
        private const string START_TILE_NAME = "Start";

        public StartTile()
            : base(START_TILE_NAME)
        {
        }
    }
}
