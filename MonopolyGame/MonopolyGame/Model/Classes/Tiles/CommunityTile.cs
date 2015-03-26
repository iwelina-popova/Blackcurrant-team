using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class CommunityTile : Tile
    {
        private const string COMMUNITY_TILE_NAME = "Community Chest";

        public CommunityTile()
            : base(COMMUNITY_TILE_NAME)
        { }



        public override void Action(Player player)
        {
            //player.Money -= Community Sum
            throw new NotImplementedException();
        }
    }
}
