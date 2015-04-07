namespace MonopolyGame.Model.Common.CustomExceptions
{
    using System;
    public class MonopolyArgumentException:MonopolyException
    {
        public MonopolyArgumentException(string message)
            :base(message)
        {

        }
    }
}
