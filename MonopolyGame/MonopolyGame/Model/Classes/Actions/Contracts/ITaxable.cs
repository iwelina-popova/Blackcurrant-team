namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using System;

    public interface ITaxable
    {
        void PayTax(Player player, int amount);
    }
}
