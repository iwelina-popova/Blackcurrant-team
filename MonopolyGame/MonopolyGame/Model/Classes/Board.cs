using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    using Enumerations;

    public class Board
    {
        private const int BOARD_SIZE = 40;
        private static Board instance;


        private Board()
        {
            this.BoardArr = new Tile[BOARD_SIZE];
            this.Players = new List<Player>();
            this.ChanceCards = new List<ChanceCard>();
            this.CommunityCards = new List<CommunityCard>();
            LoadTiles();
            LoadCards();
        }

        public Tile[] BoardArr { get; private set; }
        public List<ChanceCard> ChanceCards { get; private set; }
        public List<CommunityCard> CommunityCards { get; private set; }
       
        public static Board Instance
        {
            get {
                if (instance == null) 
                {
                    instance = new Board();
                }
                return instance;
            }
        }

        public int PlayerCount
        {
            get
            {
                return this.Players.Count;
            }
        }

        public List<Player> Players { get; private set; }

        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        private void LoadChanceCards()
        {
            this.ChanceCards.Add(new ChanceCard("First prize in NASA Challenge. You get a 100$ scholarship.", 100));
        }

        private void LoadCommunityCards()
        {
            this.CommunityCards.Add(new CommunityCard("Your Windows license has expired! Microsoft charged you 20$", 20));
        }

        private void LoadCards()
        {
            LoadChanceCards();
            LoadCommunityCards();
        }

        private void LoadTiles()
        {
            this.BoardArr[0] = new StartTile();
            this.BoardArr[1] = new StreetTile("Old Kent Road", 60, 2, StreetTileColor.Brown);
            this.BoardArr[2] = null;//new CommunityTile();
            this.BoardArr[3] = new StreetTile("Whitechapel Road", 60, 4, StreetTileColor.Brown);
            this.BoardArr[4] = new TaxTile("Income Tax", 200);
            this.BoardArr[5] = new StationTile("Kings Cross Station");
            this.BoardArr[6] = new StreetTile("The Angel Islington", 100, 6, StreetTileColor.LiteBlue);
            this.BoardArr[7] = null;//new ChanceTile();
            this.BoardArr[8] = new StreetTile("Euston Road", 100, 6, StreetTileColor.LiteBlue);
            this.BoardArr[9] = new StreetTile("Pentoville Road", 8, 120, StreetTileColor.LiteBlue);
            this.BoardArr[10] = new JailTile();
            this.BoardArr[11] = new StreetTile("Pall Mall", 140, 10, StreetTileColor.Pink);
            this.BoardArr[12] = new TaxTile("Electric Company", 150);
            this.BoardArr[13] = new StreetTile("Whitehall", 140, 10, StreetTileColor.Pink);
            this.BoardArr[14] = new StreetTile("Northmurl`d Avenue", 160, 12, StreetTileColor.Pink);
            this.BoardArr[15] = new StationTile("Marylebone Station");
            this.BoardArr[16] = new StreetTile("Bow Street", 180, 14, StreetTileColor.Orange);
            this.BoardArr[17] = null;//new CommunityTile();
            this.BoardArr[18] = new StreetTile("Marlborough Street", 180, 14, StreetTileColor.Orange);
            this.BoardArr[19] = new StreetTile("Vine Street", 200, 16, StreetTileColor.Orange);
            this.BoardArr[20] = null;
            this.BoardArr[21] = new StreetTile("Strand", 220, 18, StreetTileColor.Red);
            this.BoardArr[22] = null;//new ChanceTile();
            this.BoardArr[23] = new StreetTile("Fleet Street", 220, 18, StreetTileColor.Red);
            this.BoardArr[24] = new StreetTile("Trafalgar Square", 240, 20, StreetTileColor.Red);
            this.BoardArr[25] = new StationTile("Fenchurch st. Station");
            this.BoardArr[26] = new StreetTile("Leicester Square", 260, 22, StreetTileColor.Yellow);
            this.BoardArr[27] = new StreetTile("Coventry Street", 260, 22, StreetTileColor.Yellow);
            this.BoardArr[28] = new TaxTile("Water Works", 150);
            this.BoardArr[29] = new StreetTile("Piccadilly", 280, 22, StreetTileColor.Yellow);
            this.BoardArr[30] = new GoToJailTile();
            this.BoardArr[31] = new StreetTile("Regent Street", 300, 26, StreetTileColor.Green);
            this.BoardArr[32] = new StreetTile("Oxford Street", 300, 26, StreetTileColor.Green);
            this.BoardArr[33] = null;//new CommunityTile();
            this.BoardArr[34] = new StreetTile("Bond Street", 320, 28, StreetTileColor.Green);
            this.BoardArr[35] = new StationTile("Liverpool st. Station");
            this.BoardArr[36] = null;//new ChanceTile();
            this.BoardArr[37] = new StreetTile("Park Lane", 350, 35, StreetTileColor.DarkBlue);
            this.BoardArr[38] = new TaxTile("Super Tax", 100);
            this.BoardArr[39] = new StreetTile("Mayfair", 400, 50, StreetTileColor.DarkBlue);
        }
    }
}
