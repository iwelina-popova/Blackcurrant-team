using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    public interface IActionable
    {
        ICollection<IAction> Actions {get;}

        void AddAction(IAction action);
    }
}
