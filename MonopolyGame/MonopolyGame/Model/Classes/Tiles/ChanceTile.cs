using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class ChanceTile : Tile
    {
        private const string CHANCE_TILE_NAME = "Chance";

        public ChanceTile()
            : base(CHANCE_TILE_NAME)
        { }

        static ChanceTile() 
        {
            Cards = new Queue<ChanceCard>();
        }

        public static Queue<ChanceCard> Cards { get; private set; }

        public override void Action(Player player)
        {
            ChanceCard currentCard = player.DrawCard(Cards);
            currentCard.Action(player);
        }

        private static void LoadCards() 
        {
            Cards.Enqueue(new ChanceCard("test", 200));
            Cards.Enqueue(new ChanceCard("Description", 100));
            Cards.Enqueue(new ChanceCard("Stuff", 150));
        }
    }
}
