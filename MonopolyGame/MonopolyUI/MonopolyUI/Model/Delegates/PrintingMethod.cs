using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Delegates
{
    public delegate void PrintingMethod(object value);

    public static class PrintingMethodInstance 
    {
        public static PrintingMethod Instance { get; set; }
    }
}
