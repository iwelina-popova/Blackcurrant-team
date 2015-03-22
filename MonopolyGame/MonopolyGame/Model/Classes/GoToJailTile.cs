using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    using Interfaces;
    

    public class GoToJailTile: Tile,ITile
    {
        public GoToJailTile(int position) : base(position)
        { }
        public void Action(Player player)
        {
            //player.Position = Prison Position on the board
        }
    }
}
