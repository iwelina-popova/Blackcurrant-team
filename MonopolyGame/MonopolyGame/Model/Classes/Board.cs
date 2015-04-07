namespace MonopolyGame.Model.Classes
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Model.Common.Validators;
    using Model.Classes.Tiles.Contracts;
    using MonopolyGame.Model.Common.CustomExceptions;

    public class Board
    {
        private const int BOARD_SIZE = 40;
        private static Board instance;
        private IList<Tile> tiles;

        private Board()
        {
            this.tiles = new List<Tile>(BOARD_SIZE);
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

        public int Size
        {
            get 
            {
                return this.tiles.Count;
            }
        }

        //public IList<Tile> Tiles
        //{
        //    get
        //    {
        //        return new List<Tile>(this.tiles);
        //    }
        //}

        public void AddTile(Tile tile)
        {
            ObjectValidator.NullObjectValidation(tile, "Tile cannot be null");
            this.tiles.Add(tile);
        }

        public void AddTileAtPosition(Tile tile, int position)
        {
            ObjectValidator.NullObjectValidation(tile, "Tile cannot be null");
            this.tiles[position] = tile;
        }

        public Tile GetTileAtPosition(int position)
        {
            if (position >= this.tiles.Count || position < 0)
            {
                throw new MonopolyOutOfRangeException(position, Board.BOARD_SIZE - 1);
            }
            return this.tiles[position];
        }
    }
}
