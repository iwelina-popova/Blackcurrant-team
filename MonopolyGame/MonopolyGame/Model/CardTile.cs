using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class CardTile : Tile, ITile
    {
        public CardTile(int position)
            : base(position)
        { }

        public void Action(Player player)
        {
            player.LoseMoney(500);
        }
    }
}
