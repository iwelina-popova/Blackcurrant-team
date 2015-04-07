namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Tiles.Contracts;

    public class CommunityTile : Tile
    {
        private const string COMMUNITY_TILE_NAME = "Community Chest";

        public CommunityTile(string name, int x, int y)
            : base(COMMUNITY_TILE_NAME, x, y)
        {
        }

        //public override void Action(Player player)
        //{
        //    CommunityCard currentCard = player.DrawCard(Cards);
        //    currentCard.Action(player);
        //}
    }
}
