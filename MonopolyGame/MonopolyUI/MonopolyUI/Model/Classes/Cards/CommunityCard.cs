namespace MonopolyGame.Model.Classes
{
    using Model.Classes.Cards.Contracts;
    using Model.Enumerations;

    public class CommunityCard : Card
    {
        public CommunityCard(string description, CardType type, int money)
            : base(description, type, money)
        {
        }

        //public override void Action(Player player)
        //{
        //    player.AddMoney(base.Money);
        //}
    }
}
