using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Model.Classes.Actions.Contracts
{
    public interface IAction
    {
        void Execute(IChoosableAction type, Player player);
    }
}
