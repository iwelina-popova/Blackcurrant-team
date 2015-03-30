using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Delegates
{
    public delegate string ReadingMethod();

    public static class ReadingMethodIntance
    {
        public static ReadingMethod Instance { get; set; }
    }
}
