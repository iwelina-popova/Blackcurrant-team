using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class Tile
    {
        public Tile(int position)
        {
            this.Position = position;
        }

        public int Position { get; private set; }
    }
}
