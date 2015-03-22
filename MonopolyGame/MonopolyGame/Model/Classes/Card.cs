using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Card 
    {
        private string description;

        public int Money { get; set; }

        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                this.description = value;
            }
        }
    }
}
