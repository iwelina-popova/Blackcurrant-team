namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using System;

    public interface IAction
    {
        void Execute(IChoosableAction type, Player player);
    }
}
