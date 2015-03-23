using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    public class GoToJailTile: Tile
    {
        public GoToJailTile(int position) : base(position)
        { }
        public override void Action(Player player)
        {
            //player.Position = Prison Position on the board
        }
    }
}
