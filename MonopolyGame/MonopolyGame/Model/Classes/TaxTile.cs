using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class TaxTile : Tile
    {
        public TaxTile(int position, String name, int tax) 
            : base(position) 
        {
            this.Name = name;
            this.Tax = tax;
        }

        public int Tax { get; private set; }
        public string Name { get; private set; }

        public override void Action(Player player)
        {
            Pay(player);
        }

        public bool Pay(Player player) 
        {
            return player.WidthDrawMoney(this.Tax);
        }
    }
}