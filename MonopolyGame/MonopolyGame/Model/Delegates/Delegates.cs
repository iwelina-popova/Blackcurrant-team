using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Delegates
{
    public delegate void PrintingMethod(object value);
    public delegate string ReadingMethod();

    public static class Delegates 
    {
        public static PrintingMethod PrintingMethodInstance { get; set; }
        public static ReadingMethod ReadingMethodIntance { get; set; }
    }
}
