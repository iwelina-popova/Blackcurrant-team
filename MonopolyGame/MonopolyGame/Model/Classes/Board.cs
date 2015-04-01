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
            this.Tiles = new Tile[BOARD_SIZE];
            this.Players = new List<Player>();
            LoadTiles();
        }

        public Tile[] Tiles { get; private set; }

        public static Board Instance
        {
            get
            {
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

        private void LoadTiles()
        {
            this.Tiles[0] = new StartTile();
            this.Tiles[1] = new StreetTile("Old Kent Road", 60, 2, StreetTileColor.Brown);
            this.Tiles[2] = new CommunityTile();
            this.Tiles[3] = new StreetTile("Whitechapel Road", 60, 4, StreetTileColor.Brown);
            this.Tiles[4] = new TaxTile("Income Tax", 200);
            this.Tiles[5] = new StationTile("Kings Cross Station");
            this.Tiles[6] = new StreetTile("The Angel Islington", 100, 6, StreetTileColor.LiteBlue);
            this.Tiles[7] = new ChanceTile();
            this.Tiles[8] = new StreetTile("Euston Road", 100, 6, StreetTileColor.LiteBlue);
            this.Tiles[9] = new StreetTile("Pentoville Road", 8, 120, StreetTileColor.LiteBlue);
            this.Tiles[10] = new JailTile();
            this.Tiles[11] = new StreetTile("Pall Mall", 140, 10, StreetTileColor.Pink);
            this.Tiles[12] = new TaxTile("Electric Company", 150);
            this.Tiles[13] = new StreetTile("Whitehall", 140, 10, StreetTileColor.Pink);
            this.Tiles[14] = new StreetTile("Northmurl`d Avenue", 160, 12, StreetTileColor.Pink);
            this.Tiles[15] = new StationTile("Marylebone Station");
            this.Tiles[16] = new StreetTile("Bow Street", 180, 14, StreetTileColor.Orange);
            this.Tiles[17] = new CommunityTile();
            this.Tiles[18] = new StreetTile("Marlborough Street", 180, 14, StreetTileColor.Orange);
            this.Tiles[19] = new StreetTile("Vine Street", 200, 16, StreetTileColor.Orange);
            this.Tiles[20] = null;
            this.Tiles[21] = new StreetTile("Strand", 220, 18, StreetTileColor.Red);
            this.Tiles[22] = new ChanceTile();
            this.Tiles[23] = new StreetTile("Fleet Street", 220, 18, StreetTileColor.Red);
            this.Tiles[24] = new StreetTile("Trafalgar Square", 240, 20, StreetTileColor.Red);
            this.Tiles[25] = new StationTile("Fenchurch st. Station");
            this.Tiles[26] = new StreetTile("Leicester Square", 260, 22, StreetTileColor.Yellow);
            this.Tiles[27] = new StreetTile("Coventry Street", 260, 22, StreetTileColor.Yellow);
            this.Tiles[28] = new TaxTile("Water Works", 150);
            this.Tiles[29] = new StreetTile("Piccadilly", 280, 22, StreetTileColor.Yellow);
            this.Tiles[30] = new GoToJailTile();
            this.Tiles[31] = new StreetTile("Regent Street", 300, 26, StreetTileColor.Green);
            this.Tiles[32] = new StreetTile("Oxford Street", 300, 26, StreetTileColor.Green);
            this.Tiles[33] = new CommunityTile();
            this.Tiles[34] = new StreetTile("Bond Street", 320, 28, StreetTileColor.Green);
            this.Tiles[35] = new StationTile("Liverpool st. Station");
            this.Tiles[36] = new ChanceTile();
            this.Tiles[37] = new StreetTile("Park Lane", 350, 35, StreetTileColor.DarkBlue);
            this.Tiles[38] = new TaxTile("Super Tax", 100);
            this.Tiles[39] = new StreetTile("Mayfair", 400, 50, StreetTileColor.DarkBlue);
        }
    }
}
