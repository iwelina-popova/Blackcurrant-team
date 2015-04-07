namespace MonopolyGame.Model.Classes.Tiles
{
    using Model.Classes.Tiles.Contracts;

    public class ChanceTile : Tile
    {
        private const string CHANCE_TILE_NAME = "Chance";

        public ChanceTile()
            : base(CHANCE_TILE_NAME)
        {
        }

        //public override void Action(Player player)
        //{
        //    ChanceCard currentCard = player.DrawCard(Cards);
        //    currentCard.Action(player);
        //}
    }
}
