namespace MonopolyGame.Model.Common.CustomExceptions
{
    using System;

    public class PlayerBankruptException:MonopolyException
    {
        public PlayerBankruptException(string playerName)
            :base(playerName +" "+ "is bankrupt")
        {
            
        }
    }
}
