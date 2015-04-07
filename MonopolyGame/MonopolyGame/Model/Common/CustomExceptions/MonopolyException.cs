namespace MonopolyGame.Model.Common.CustomExceptions
{
    using System;

    public abstract class MonopolyException:Exception
    {
        public MonopolyException(string message)
            :base(message)
        {

        }
    }
}
