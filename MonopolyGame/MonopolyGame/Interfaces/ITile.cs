namespace MonopolyGame.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Model;

    interface ITile
    {
        void Action(Player player);
    }
}
