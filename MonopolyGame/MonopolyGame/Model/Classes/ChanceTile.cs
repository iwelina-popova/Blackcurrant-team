using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class ChanceTile : Tile
    {
        public ChanceTile(int position)
            : base(position)
        { }



        public override void Action(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
