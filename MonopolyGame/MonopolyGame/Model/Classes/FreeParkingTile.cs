using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    class FreeParkingTile : Tile
    {
        public FreeParkingTile(int position) 
            :base(position)
        { }

        public override void Action(Player player)
        {
            //Player doesn`t do anything...
        }
    }
}
