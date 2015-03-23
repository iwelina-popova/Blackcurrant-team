using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class CommunityTile : Tile
    {
        public CommunityTile(int position)
            : base(position)
        { }



        public override void Action(Player player)
        {
            //player.Money -= Community Sum
            throw new NotImplementedException();
        }
    }
}
