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
            LoadCards();
        }

        public static Queue<ChanceCard> Cards { get; private set; }

        public override void Action(Player player)
        {
            ChanceCard currentCard = player.DrawCard(Cards);
            currentCard.Action(player);
        }

        private static void LoadCards()
        {
            var CardsArr = new[]
                {
                 new ChanceCard("Destributed Dental System Attack - you lose $150", -150),
                 new ChanceCard("Ouch - Heartbleed - you lose $100", -100),
                 new ChanceCard("You used float insted of decimal - you lose $50", -50),
                 new ChanceCard("Your Visual Studio license expired - you lose $75", -75),
                 new ChanceCard("Blue Screen of Death!!! - you lose $20", -20),
                 new ChanceCard("A flush of inspiration - your code compiled without any errors! - you win $100", 100),
                 new ChanceCard("You fixed a nasty bug - you win $50", 50),
                 new ChanceCard("You received a Telerik Academy Ninja Certificate - you win $150", 150),
                 new ChanceCard("Internet Explorer has extincted! - you win $75", 75),
                 new ChanceCard("Intenet boost! - you win $20", 20),
                };

            Cards = Card.Shuffle(CardsArr);

        }
    }
}
