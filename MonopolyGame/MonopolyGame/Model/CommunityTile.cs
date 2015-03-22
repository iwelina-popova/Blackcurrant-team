using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class CommunityTile : Tile,ITile
    {
        using Interfaces;

        public CommunityTile(int position)
            : base(position)
        { }



        public void Action(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
