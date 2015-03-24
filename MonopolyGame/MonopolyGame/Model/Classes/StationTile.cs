using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    using Interfaces;

    public class StationTile : Tile,IBuyable
    {
        private const int STATION_PRICE = 200;
        private const int STATION_RENT = 25;

        public StationTile(int position, string name)
            : base(position)
        {
            this.Name = name;
            this.Owner = null;
            this.BaseRent = STATION_RENT;
            this.Price = STATION_PRICE;
        }

        public string Name { get; private set; }
        public Player Owner{ get; protected set; }
        public int Price { get; protected set; }
        public int BaseRent { get; protected set; }

        public override void Action(Player player)
        {
            if (this.Owner == null)
            {
                Console.WriteLine("Make your choice:\n1: Buy\n2: Skip");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": Buy(player); break;
                    case "2": break;
                    default: throw new ArgumentOutOfRangeException("Incorrect choice!");
                }
            }
            else 
            {
                PayRent(player);
            }
        }


        public bool Buy(Player player)
        {
            if (player.WidthDrawMoney(this.Price))
            {
                this.Owner = player;
                return true;
            }

            return false;
        }


        public bool PayRent(Player player)
        {
            if (this.Owner == null)
            {
                return player.WidthDrawMoney(this.BaseRent);
            }
            else 
            {
                //TODO:Implement advanced renting with calculation of properties
                throw new NotImplementedException("Implement Advanced renting");
            }
        }
    }
}
