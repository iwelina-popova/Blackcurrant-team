using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    using Interfaces;

    public class TaxTile : Tile,ITile
    {
        public TaxTile(int position, String name) 
            : base(position) 
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Action(Player player)
        {
            throw new NotImplementedException();
        }
    }
}