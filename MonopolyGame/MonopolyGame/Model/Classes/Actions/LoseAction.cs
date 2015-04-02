namespace MonopolyGame.Model.Classes.Actions
{
    using Model.Classes.Actions.Contracts;
    using Model.Classes.Cards.Contracts;
    using Model.Common.Validators;

    class LoseAction : IAction
    {
        public void Execute(IActionable type, Player player)
        {
            Card card = type as Card;
            ObjectValidator.NullObjectValidation(card, "The instance type should a be Card");
            player.WidthdrawMoney(card.Money);
        }
    }
}
