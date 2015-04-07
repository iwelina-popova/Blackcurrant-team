namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Tiles.Contracts;

    public class CommunityTile : Tile
    {
        private const string COMMUNITY_TILE_NAME = "Community Chest";

        public CommunityTile()
            : base(COMMUNITY_TILE_NAME)
        {
        }

    }
}
