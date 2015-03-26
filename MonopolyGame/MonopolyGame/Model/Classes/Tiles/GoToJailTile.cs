using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class GoToJailTile: Tile
    {
        private const string GOTO_JAIL_TILE_NAME = "Go to Jail";

        public GoToJailTile() : base(GOTO_JAIL_TILE_NAME)
        { }
        public override void Action(Player player)
        {
            //player.Position = Prison Position on the board
        }
    }
}
