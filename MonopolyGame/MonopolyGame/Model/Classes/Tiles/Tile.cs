using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public abstract class Tile
    {
        public Tile(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void Action(Player player);
    }
}
