namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Tiles.Contracts;

    public class GoToJailTile : Tile
    {
        private const string GOTO_JAIL_TILE_NAME = "Go to Jail";

        public GoToJailTile(string name, int x, int y)
            : base(GOTO_JAIL_TILE_NAME, x, y)
        {
        }
    }
}
