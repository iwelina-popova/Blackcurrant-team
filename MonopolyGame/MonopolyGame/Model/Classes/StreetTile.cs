﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    public class StreetTile : Tile
    {
        public StreetTile(int position, string name, StreetTileColor color) 
            :base(position)
        {
            this.Name = name;
            this.Color = color;
        }


        public string Name { get; private set; }
        public StreetTileColor Color { get;  set; }
        public Player Owner { get; private set; }

        public override void Action(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
