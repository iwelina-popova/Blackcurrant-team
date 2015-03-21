using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class MoneyTile : Tile,ITile
    {
        public MoneyTile(int position) 
            :base(position)
        {
        }

        public void Action(Player player)
        {
            player.GainMoney(500);
        }
    }
}
