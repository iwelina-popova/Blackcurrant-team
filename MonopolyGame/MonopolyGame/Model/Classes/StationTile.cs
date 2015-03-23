using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    public class StationTile : Tile
    {
        
        public StationTile(int position, string name)
            : base(position)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override void Action(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
