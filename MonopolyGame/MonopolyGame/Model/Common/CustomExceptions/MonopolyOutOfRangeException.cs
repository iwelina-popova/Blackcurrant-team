namespace MonopolyGame.Model.Common.CustomExceptions
{
    using System;

    class MonopolyOutOfRangeException:MonopolyException
    {
        public MonopolyOutOfRangeException(int current, int size)
            :base(string.Format("Reached position {0} with size {1}",current,size))
        {

        }
    }
}
