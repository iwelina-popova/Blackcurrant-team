using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    using Model.Delegates;

    public abstract class PropertyTile : Tile
    {
        public PropertyTile(string name, int price, int rent, Player owner = null) 
            :base(name)
        {
            this.Price = price;
            this.BaseRent = rent;
            this.Owner = owner;
        }

        public Player Owner { get; protected set; }
        public int Price { get; protected set; }
        public int BaseRent { get; protected set; }

        public override void Action(Player player)
        {
            if (this.Owner == null)
            {
                if (player.Money >= this.Price)
                {
                    PrintingMethodInstance.Instance("Make your choice:\n1: Buy\n2: Skip");
                    string input = ReadingMethodIntance.Instance();

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
            else
            {
                PayRent(player);
            }
        }


        public bool Buy(Player player)
        {
            if (player.WidthdrawMoney(this.Price))
            {
                this.Owner = player;
                player.Properties.Add(this);
                return true;
            }

            return false;
        }

        public virtual bool PayRent(Player player) 
        {
            if (this.Owner == null)
            {
                return player.WidthdrawMoney(this.BaseRent);
            }

            return true;
        }
    }
}
