namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IChoosableAction
    {
        ICollection<IAction> Actions { get; }

        void AddAction(IAction action);
    }
}
