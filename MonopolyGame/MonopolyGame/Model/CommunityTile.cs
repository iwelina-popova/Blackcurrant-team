using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{

    using Interfaces;
    public class CommunityTile : Tile,ITile
    {
        public CommunityTile(int position)
            : base(position)
        { }



        public void Action(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
