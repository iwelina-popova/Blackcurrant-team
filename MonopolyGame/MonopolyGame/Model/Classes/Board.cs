using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    public class Board
    {
        private const int BOARD_SIZE = 40;

        public Board()
        {
            this.BoardArr = new Tile[BOARD_SIZE];
            this.Players = new List<Player>();

            LoadTiles();
        }

        public Tile[] BoardArr { get; private set; }

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

        public void LoadTiles()
        {
            this.BoardArr[0] = new StartTile();
            this.BoardArr[1] = new StreetTile(1, "Old Kent Road", StreetTileColor.Brown, 100);
            this.BoardArr[2] = new CommunityTile(2);
            this.BoardArr[3] = new StreetTile(3, "Whitechapel Road", StreetTileColor.Brown, 100);
            this.BoardArr[4] = new TaxTile(4, "Income Tax");
            this.BoardArr[5] = new StationTile(5, "Kings Cross Station");
            this.BoardArr[6] = new StreetTile(6, "The Angel Islington", StreetTileColor.LiteBlue, 100);
            this.BoardArr[7] = new ChanceTile(7);
            this.BoardArr[8] = new StreetTile(8, "Euston Road", StreetTileColor.LiteBlue, 100);
            this.BoardArr[9] = new StreetTile(9, "Pentoville Road", StreetTileColor.LiteBlue, 100);
            this.BoardArr[10] = new JailTile(10);
            this.BoardArr[11] = new StreetTile(11, "Pall Mall", StreetTileColor.Pink, 100);
            this.BoardArr[12] = new TaxTile(12, "Electric Company");
            this.BoardArr[13] = new StreetTile(13, "Whitehall", StreetTileColor.Pink, 100);
            this.BoardArr[14] = new StreetTile(14, "Northmurl`d Avenue", StreetTileColor.Pink, 100);
            this.BoardArr[15] = new StationTile(15, "Marylebone Station");
            this.BoardArr[16] = new StreetTile(16, "Bow Street", StreetTileColor.Orange, 100);
            this.BoardArr[17] = new CommunityTile(17);
        }
    }
}
