using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class CommunityTile : Tile
    {
        private const string COMMUNITY_TILE_NAME = "Community Chest";

        public CommunityTile()
            : base(COMMUNITY_TILE_NAME)
        { }

        static CommunityTile() 
        {
            Cards = new Queue<CommunityCard>();
            LoadCards();
        }

        public static Queue<CommunityCard> Cards { get; private set; }

        public override void Action(Player player)
        {
            CommunityCard currentCard = player.DrawCard(Cards);
            currentCard.Action(player);
        }

        private static void LoadCards()
        {
            Cards.Enqueue(new CommunityCard("Test", 200));
            Cards.Enqueue(new CommunityCard("Description", 100));
            Cards.Enqueue(new CommunityCard("Stuff", 150));
        }
    }
}
