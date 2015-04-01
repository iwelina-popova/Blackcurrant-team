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
            var CardsArr = new[]
               {
                new CommunityCard("Your HDD burnt - you lose $150", -150),
                new CommunityCard("Your RAM burnt - you lose $100", -100),
                new CommunityCard("You get a raise - you win $150", 150),
                new CommunityCard("You receive 2GB RAM - you win $100", 100),
                new CommunityCard("Your laptop computer crashed - you lose $50", -50),
                new CommunityCard("You spill coffe on your keyboard - you lose $20", -20),
                new CommunityCard("Your dog ate you laptop computer recharger - you lose $75", -75),
                new CommunityCard("You receive a new battery for your laptop computer - you win $75", 75),
                new CommunityCard("A gift! - new smartphone for you - you win $50", 50),
                new CommunityCard("You have a birthday! - you win $20", 20),
               };

            Cards = Card.Shuffle(CardsArr);

        }
    }
}
