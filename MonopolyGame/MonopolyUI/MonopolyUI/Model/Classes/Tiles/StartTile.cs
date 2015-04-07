namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Tiles.Contracts;

    public class StartTile : Tile
    {
        private const string START_TILE_NAME = "Start";

        public StartTile(string name, int x, int y)
            : base(START_TILE_NAME, x, y)
        {
        }
    }
}
