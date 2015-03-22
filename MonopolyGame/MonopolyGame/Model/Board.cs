using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model
{
    class Board
    {
        public Board()
        {
            this.BoardArr = new ITile[40];
            this.Players = new List<Player>();

            //for (int i = 0; i < this.BoardArr.Length; i++)
            //{
            //    if (i < this.BoardArr.Length - 2)
            //    {
            //        this.BoardArr[i] = new CardTile(i);
            //    }
            //    this.BoardArr[BoardArr.Length - 1] = new MoneyTile(i);
            //}
        }

        public ITile[] BoardArr { get; private set; }

        public int PlayerCount
        {
            get
            {
                return this.Players.Count;
            }
        }

        public List<Player> Players { get; private set; }

        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }


    }
}
