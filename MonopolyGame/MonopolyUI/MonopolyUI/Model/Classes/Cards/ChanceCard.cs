namespace MonopolyGame.Model.Classes.Cards
{
    using Model.Classes.Cards.Contracts;
    using Model.Enumerations;

    public class ChanceCard : Card
    {
        public ChanceCard(string description, CardType type, int money)
            : base(description, type, money)
        {
        }

        //public override void Action(Player player)
        //{
        //    player.AddMoney(base.Money);
        //}
    }
}
