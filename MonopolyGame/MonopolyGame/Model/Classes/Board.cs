namespace MonopolyGame.Model.Classes
{
    using System.Collections.Generic;

    using Enumerations;
    using Model.Classes.Tiles.Contracts;

    public class Board
    {
        private const int BOARD_SIZE = 40;
        private static Board instance;
        private IList<Tile> tiles;

        private Board()
        {
            this.tiles = new List<Tile>(BOARD_SIZE);
        }

        public IList<Tile> Tiles
        {
            get
            {
                return new List<Tile>(this.tiles);
            }
        }

        public void AddTile(Tile tile)
        {
            this.tiles.Add(tile);
        }

        public void AddTileAtPosition(Tile tile, int position) 
        {
            this.tiles[position] = tile;
        }

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
    }
}
