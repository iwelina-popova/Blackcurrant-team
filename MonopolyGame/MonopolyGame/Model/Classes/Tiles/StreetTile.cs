﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    using Interfaces;
    using Enumerations;

    public class StreetTile : StationTile,IBuyable
    {
        public StreetTile(int position, string name, int price, int baseRent, StreetTileColor color)
            : base(position, name)
        {
            this.BaseRent = baseRent;
            this.Price = price;
            this.Color = color;
        }

        public StreetTileColor Color { get; private set; }

    }
}