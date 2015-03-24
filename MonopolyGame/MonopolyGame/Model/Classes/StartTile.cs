﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class StartTile : Tile
    {
        public StartTile()
            : base(0) 
        { }
        
        public override void Action(Player player)
        {
            player.AddMoney(200);
        }
    }
}