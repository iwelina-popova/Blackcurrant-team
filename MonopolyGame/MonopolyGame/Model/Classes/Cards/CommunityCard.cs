using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes
{
    public class CommunityCard : Card
    {
        public CommunityCard(string description, int money)
            : base(description, money)
        {

        }

        public override void Action(Player player)
        {
            player.WidthDrawMoney(base.Money);
        }
    }
}
