using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Interfaces
{
    using Classes;

    interface IBuyable
    {
        Player Owner { get; }
        int Price { get; }
        int BaseRent { get; }

        bool Buy(Player player);
        bool PayRent(Player player);
    }
}
