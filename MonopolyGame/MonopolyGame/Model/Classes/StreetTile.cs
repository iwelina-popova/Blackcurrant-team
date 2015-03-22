using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    using Interfaces;

    public class StreetTile : Tile, ITile
    {
        public StreetTile(int position, string name, StreetTileColor color, int price)
            : base(position)
        {
            this.Name = name;
            this.Color = color;
            this.Price = price;
        }


        public string Name { get; private set; }
        public StreetTileColor Color { get; set; }
        public Player Owner { get; private set; }
        public int Price { get; private set; }

        public void Action(Player player)
        {
            Console.WriteLine("Make your choice:\n1: Buy\n2: Skip");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": Buy(player); break;
                case "2": Skip(); break;
                default: throw new ArgumentOutOfRangeException("Incorrect choice!");
            }
        }

        public void Buy(Player player)
        {
            player.Money -= this.Price;
            Owner = player;
        }

        public void Skip()
        {

        }
    }
}
