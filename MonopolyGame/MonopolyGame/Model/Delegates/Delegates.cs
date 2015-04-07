namespace MonopolyGame.Model.Delegates
{
    using System;

    public delegate void PrintingMethod(object value);

    public delegate string ReadingMethod();

    public static class Delegates 
    {
        public static PrintingMethod PrintingMethodInstance { get; set; }

        public static ReadingMethod ReadingMethodIntance { get; set; }
    }
}
