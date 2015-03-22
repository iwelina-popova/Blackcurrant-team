using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class Board
    {
        public Board(int size)
        {
            this.BoardArr = new ITile[size];
            this.Players = new List<Player>();

            LoadTiles();
        }

        public ITile[] BoardArr { get; private set; }

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
            this.BoardArr[1] = new StreetTile(1, "Old Kent Road", StreetTileColor.Brown);
        }
    }
}
