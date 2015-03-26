using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class StartTile : Tile
    {
        private const string START_TILE_NAME = "Start";
        public StartTile()
            : base(START_TILE_NAME) 
        { }
        
        public override void Action(Player player)
        {
            player.AddMoney(200);
        }
    }
}
