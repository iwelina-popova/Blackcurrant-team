﻿namespace MonopolyGame.Model.Classes.Tiles.Contracts
{
    using System.Collections.Generic;

    using Model.Classes.Actions;
    using Model.Classes.Actions.Contracts;
    using Model.Common.Validators;

    public class ActionableTile : Tile,IActionable
    {
        private ICollection<IAction> actions;

        public ActionableTile(string name)
            : base(name) 
        {
            this.actions = new List<IAction>();  
        }

        public ICollection<IAction> Actions
        {
            get { return new List<IAction>(this.actions); }
        }

        public void AddAction(IAction action)
        {
            ObjectValidator.NullObjectValidation(action, "Action instance cannot be null");
            this.actions.Add(action);
        }
    }
}
